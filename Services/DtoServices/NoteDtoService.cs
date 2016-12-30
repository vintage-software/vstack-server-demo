using Persistence.Mappers;
using Services.Converters;
using Services.General;
using Services.Services;
using System.Collections.Generic;
using System.Linq;
using Vstack.Services.General;
using Vstack.Services.Queryable;
using Vstack.Services.Services;
using Dmn = Domain;

namespace Services.DtoServices
{
    public class NoteDtoService
        : BaseUndeletedDtoService<Dto.Note, Dmn.Note, NoteMapper, NoteConverter, NoteService, Permissions>
    {
        private readonly NotebookService notebookService = new NotebookService();
        private readonly AccountService accountService = new AccountService();

        public NoteDtoService()
            : this(Permissions.Empty)
        {
        }

        public NoteDtoService(Permissions permissions)
            : base(new NoteService(), permissions, false)
        {
        }

        protected override IEnumerable<DtoActionResult<Dmn.Note>> CanDeleteMany(VsIncludeEnumerable<Dmn.Note, NoteMapper> domains)
        {
            return domains
                .Include(domain => domain.Notebook)
                .Select(domain =>
                {
                    DtoRestStatus status = this.Permissions.HasPermissionsForAccount(domain.Notebook.AccountId) ?
                        DtoRestStatus.Success : DtoRestStatus.Forbidden;
                    return new DtoActionResult<Dmn.Note>(status, domain);
                })
               .ToList();
        }

        protected override DtoRestStatus CanRead(IEnumerable<int> noteIds)
        {
            IEnumerable<Dmn.Account> accounts = this.Service.Get(noteIds)
                .Include(note => note.Notebook)
                .Include(note => note.Notebook.Account)
                .Select(note => note.Notebook.Account)
                .ToList();

            bool hasPermission = accounts
                .Select(account => account.Id)
                .All(accountId => this.Permissions.HasPermissionsForAccount(accountId));

            return hasPermission ? DtoRestStatus.Success : DtoRestStatus.Forbidden;
        }

        protected override DtoRestStatus CanReadAll()
        {
            return DtoRestStatus.BadRequest;
        }

        protected override IEnumerable<DtoActionResult<Dmn.Note>> ConstructMany(IEnumerable<Dto.Note> dtos)
        {
            IEnumerable<int> notebookIds = dtos
                .Select(dto => dto.NotebookId)
                .Distinct()
                .ToList();

            IEnumerable<Dmn.Notebook> notebooks = this.notebookService.Get(notebookIds)
                .ToList();

            return dtos
                .Select(dto =>
                {
                    Dmn.Notebook notebook = notebooks.FirstOrDefault(i => i.Id == dto.NotebookId);

                    if (this.Permissions.HasPermissionsForAccount(notebook.AccountId) == false)
                    {
                        return new DtoActionResult<Dmn.Note>(DtoRestStatus.Forbidden);
                    }

                    Dmn.Note domain = new Dmn.Note(dto.Title, dto.Content, dto.NotebookId);

                    return new DtoActionResult<Dmn.Note>(DtoRestStatus.Success, domain);
                })
                .ToList();
        }

        protected override IEnumerable<DtoActionResult<Dmn.Note>> UpdateMany(VsUpdateEnumerable<Dto.Note, Dmn.Note, NoteMapper> updates)
        {
            IEnumerable<int> notebookIds = updates.Dtos
                   .Select(dto => dto.NotebookId)
                   .Distinct()
                   .ToList();

            IEnumerable<Dmn.Notebook> notebooks = this.notebookService.Get(notebookIds)
                .ToList();

            return updates
                .Include(dmn => dmn.Notebook)
                .Select(pair =>
                {
                    if (this.Permissions.HasPermissionsForAccount(pair.Domain.Notebook.AccountId) == false)
                    {
                        return new DtoActionResult<Dmn.Note>(DtoRestStatus.Forbidden, pair.Domain);
                    }

                    Dmn.Notebook newNotebook = notebooks.FirstOrDefault(notebook => notebook.Id == pair.Dto.NotebookId);
                    if (this.Permissions.HasPermissionsForAccount(newNotebook.AccountId) == false)
                    {
                        return new DtoActionResult<Dmn.Note>(DtoRestStatus.Forbidden, pair.Domain);
                    }

                    pair.Domain.Title = pair.Dto.Title;
                    pair.Domain.Content = pair.Dto.Content;
                    pair.Domain.NotebookId = pair.Dto.NotebookId;

                    return new DtoActionResult<Dmn.Note>(DtoRestStatus.Success, pair.Domain);
                })
                .ToList();
        }
    }
}

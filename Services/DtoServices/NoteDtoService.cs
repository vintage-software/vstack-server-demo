using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Vstack.Services.General;
using Vstack.Services.Services;
using Dmn = Domain;

namespace Services.DtoServices
{
    public class NoteDtoService
        : BaseUndeletedSingleDtoService<Dto.Note, Dmn.Note, Mappers.NoteMapper, Converters.NoteConverter, NoteService, General.Permissions>
    {
        private readonly NotebookService notebookService = new NotebookService();

        public NoteDtoService()
            : this(General.Permissions.Empty)
        {
        }

        public NoteDtoService(General.Permissions permissions)
            : base(new NoteService(), permissions, false)
        {
        }

        protected override IEnumerable<Expression<Func<Dmn.Note, object>>> UpdateIncludes
        {
            get
            {
                return new Expression<Func<Dmn.Note, object>>[]
                {
                    note => note.Notebook
                };
            }
        }

        protected override DtoRestStatus CanDelete(Dmn.Note domain)
        {
            return this.Permissions.IsInternal() ? DtoRestStatus.Success : DtoRestStatus.Forbidden;
        }

        protected override DtoRestStatus CanRead(IEnumerable<int> ids)
        {
            return ids.All(id => this.Permissions.HasPermissionsForAccount(id)) ? DtoRestStatus.Success : DtoRestStatus.Forbidden;
        }

        protected override DtoRestStatus CanReadAll()
        {
            return DtoRestStatus.BadRequest;
        }

        protected override DtoActionResult<Dmn.Note> Construct(Dto.Note dto)
        {
            if (this.Permissions.GetAccountId().HasValue == false)
            {
                return new DtoActionResult<Dmn.Note>(DtoRestStatus.Forbidden);
            }

            Dmn.Note domain = new Dmn.Note(dto.Title, dto.Body, dto.NotebookId);

            return new DtoActionResult<Dmn.Note>(DtoRestStatus.Success, domain);
        }

        protected override DtoRestStatus Update(Dmn.Note domain, Dto.Note dto)
        {
            if (this.Permissions.HasPermissionsForAccount(domain.Notebook.AccountId) == false)
            {
                return DtoRestStatus.Forbidden;
            }

            // need to find alternate solution for this
            if (this.notebookService.Get(dto.NotebookId).FirstOrDefault()?.AccountId != domain.Notebook.AccountId)
            {
                return DtoRestStatus.Forbidden;
            }

            domain.Title = dto.Title;
            domain.Body = dto.Body;
            domain.NotebookId = dto.NotebookId;

            return DtoRestStatus.Success;
        }
    }
}

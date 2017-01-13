using Persistence.Mappers;
using Services.Converters;
using Services.General;
using Services.Services;
using System.Collections.Generic;
using System.Linq;
using Vstack.Services.General;
using Vstack.Services.Services;
using Dmn = Domain;

namespace Services.DtoServices
{
    public class NotebookDtoService
        : BaseUndeletedSingleDtoService<Dto.Notebook, Dmn.Notebook, NotebookMapper, NotebookConverter, NotebookService, Permissions>
    {
        public NotebookDtoService(NotebookService notebookService, Permissions permissions)
            : base(notebookService, permissions, false)
        {
        }

        protected override DtoRestStatus CanDelete(Dmn.Notebook domain)
        {
            return this.Permissions.IsInternal() ? DtoRestStatus.Success : DtoRestStatus.Forbidden;
        }

        protected override DtoRestStatus CanRead(IEnumerable<int> ids)
        {
            bool ownsNotebooks = this.Service.Get(ids).All(dmn => this.Permissions.HasPermissionsForAccount(dmn.AccountId));

            return ownsNotebooks ? DtoRestStatus.Success : DtoRestStatus.Forbidden;
        }

        protected override DtoRestStatus CanReadAll()
        {
            return DtoRestStatus.BadRequest;
        }

        protected override DtoActionResult<Dmn.Notebook> Construct(Dto.Notebook dto)
        {
            if (this.Permissions.HasPermissionsForAccount(dto.AccountId) == false)
            {
                return new DtoActionResult<Dmn.Notebook>(DtoRestStatus.Forbidden);
            }

            Dmn.Notebook domain = new Dmn.Notebook(dto.Title, dto.Description, dto.AccountId);

            return new DtoActionResult<Dmn.Notebook>(DtoRestStatus.Success, domain);
        }

        protected override DtoRestStatus Update(Dmn.Notebook domain, Dto.Notebook dto)
        {
            if (this.Permissions.HasPermissionsForAccount(domain.AccountId) == false)
            {
                return DtoRestStatus.Forbidden;
            }

            domain.Title = dto.Title;
            domain.Description = dto.Description;

            return DtoRestStatus.Success;
        }
    }
}

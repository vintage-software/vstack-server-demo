using Persistence.Mappers;
using Services.General;
using System.Linq;
using Vstack.Services.Filters;
using Vstack.Services.General;
using Dmn = Domain;

namespace Services.Filters.Notebook
{
    public class ByAccountId : IPrimaryDtoFilter<Dmn.Notebook, NotebookMapper, Permissions>
    {
        private readonly int accountId;

        public ByAccountId(int accountId)
        {
            this.accountId = accountId;
        }

        public DtoRestStatus HasPrimaryPermissions(Permissions permissions)
        {
            return permissions.HasPermissionsForAccount(this.accountId) ? DtoRestStatus.Success : DtoRestStatus.Forbidden;
        }

        public IQueryable<Dmn.Notebook> PrimaryFilter(NotebookMapper mapper)
        {
            return mapper.GetByAccountId(this.accountId);
        }
    }
}

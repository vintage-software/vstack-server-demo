using Domain;
using System.Linq;
using Vstack.Services.Mappers;

namespace Persistence.Mappers
{
    public class NotebookMapper : BaseEfMapper<DbContext, Notebook>
    {
        public NotebookMapper()
            : base(new DbContext())
        {
        }

        public IQueryable<Notebook> GetByAccountId(int accountId)
        {
            return this.Context.Notebooks.Where(notebook => notebook.AccountId == accountId);
        }
    }
}

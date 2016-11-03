using Domain;
using Services.Persistence;
using System.Linq;
using Vstack.Services.Mappers;

namespace Services.Mappers
{
    public class NotebookMapper : BaseEfMapper<DbContext, Notebook>
    {
        public NotebookMapper()
            : base(new DbContext())
        {
        }

        public IQueryable<Notebook> GetByAccountId(int accountId)
        {
            return this.Context.Notebooks.Where(i => i.AccountId == accountId);
        }
    }
}

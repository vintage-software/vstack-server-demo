using Domain;
using Services.Persistence;
using Vstack.Services.Mappers;

namespace Services.Mappers
{
    public class NotebookMapper : BaseEfMapper<DbContext, Notebook>
    {
        public NotebookMapper()
            : base(new DbContext())
        {
        }
    }
}

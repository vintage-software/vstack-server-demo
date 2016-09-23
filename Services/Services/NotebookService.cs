using Services.Mappers;
using Vstack.Services.Services;
using Dmn = Domain;

namespace Services.Services
{
    public class NotebookService : BaseService<Dmn.Notebook, NotebookMapper>
    {
        public NotebookService()
            : base(new NotebookMapper())
        {
        }
    }
}

using Persistence.Mappers;
using Vstack.Services.Services;
using Dmn = Domain;

namespace Services.Services
{
    public class NoteService : BaseService<Dmn.Note, NoteMapper>
    {
        public NoteService()
            : base(new NoteMapper())
        {
        }
    }
}

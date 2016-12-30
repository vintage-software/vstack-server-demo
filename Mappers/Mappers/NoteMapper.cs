using Domain;
using Vstack.Services.Mappers;

namespace Persistence.Mappers
{
    public class NoteMapper : BaseEfMapper<DbContext, Note>
    {
        public NoteMapper()
            : base(new DbContext())
        {
        }
    }
}

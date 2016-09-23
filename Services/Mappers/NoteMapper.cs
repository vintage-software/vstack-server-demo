using Domain;
using Services.Persistence;
using Vstack.Services.Mappers;

namespace Services.Mappers
{
    public class NoteMapper : BaseEfMapper<DbContext, Note>
    {
        public NoteMapper()
            : base(new DbContext())
        {
        }
    }
}

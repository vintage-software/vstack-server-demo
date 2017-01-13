using Persistence.Mappers;
using Services.Converters;
using Services.DtoServices;
using Services.Services;
using Dto = Services.Dto;

namespace WebApi.Controllers
{
    public class NotesController
        : BaseController<Dto.Note, Domain.Note, NoteMapper, NoteConverter, NoteService, NoteDtoService>
    {
        public NotesController(NoteDtoService dtoService)
            : base(dtoService)
        {
        }
    }
}

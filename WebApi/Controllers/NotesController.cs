using Services.Converters;
using Services.DtoServices;
using Services.Mappers;
using Services.Services;
using Dto = Services.Dto;

namespace WebApi.Controllers
{
    public class NotesController
        : BaseController<Dto.Note, Domain.Note, NoteMapper, NoteConverter, NoteService, NoteDtoService>
    {
    }
}

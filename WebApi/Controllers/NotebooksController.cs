using Services.Converters;
using Services.DtoServices;
using Services.Mappers;
using Services.Services;
using Dto = Services.Dto;

namespace WebApi.Controllers
{
    public class NotebooksController
        : BaseController<Dto.Notebook, Domain.Notebook, NotebookMapper, NotebookConverter, NotebookService, NotebookDtoService>
    {
    }
}

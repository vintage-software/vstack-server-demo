using Services.General;
using System.Security.Claims;
using Vstack.Legacy.Api.Web.Controllers;
using Vstack.Services.Converters;
using Vstack.Services.Domain;
using Vstack.Services.Dto;
using Vstack.Services.General;
using Vstack.Services.Services;
using WebApi.Authentication;

namespace WebApi.Controllers
{
    public class BaseController<TDto, TDmn, TMapper, TConverter, TService, TDtoService>
        : EntityRestfulController<TDto, TDmn, TMapper, TConverter, TService, TDtoService, Permissions>
        where TDto : class, IRestDto
        where TDmn : class, IServiceDomain
        where TMapper : IMapper<TDmn>
        where TConverter : class, IDomainConverter<TDto, TDmn, Permissions>, new()
        where TService : BaseService<TDmn, TMapper>
        where TDtoService : BaseDtoService<TDto, TDmn, TMapper, TConverter, TService, Permissions>, new()
    {
        ClaimsProvider claimsProvider = new ClaimsProvider();

        public override Permissions Permissions
        {
            get
            {
                return this.claimsProvider.GetPermissions((ClaimsIdentity)this.User.Identity);
            }
        }
    }
}

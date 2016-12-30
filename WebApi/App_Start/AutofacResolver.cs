using Autofac;
using Autofac.Integration.WebApi;
using Services;
using System.Linq;
using System.Reflection;
using System.Web.Http.Dependencies;
using Vstack.Common.Extensions;

namespace WebApi.App_Start
{
    public class AutofacResolver : BaseAutofacResolver
    {
        private readonly Assembly mapperAssembly = Assembly.GetAssembly(typeof(Persistence.Mappers.AccountMapper));

        private readonly Assembly serviceAssembly = Assembly.GetAssembly(typeof(Services.Services.AccountService));

        private readonly Assembly webAssembly = Assembly.GetExecutingAssembly();

        private static AutofacResolver instance;

        private IContainer container;

        protected override IContainer Container
        {
            get
            {
                if (this.container == null)
                {
                    var builder = new ContainerBuilder();
                    builder.RegisterTypes(this.mapperAssembly.FindConcreteClasses().ToArray()).AsImplementedInterfaces().SingleInstance();
                    builder.RegisterTypes(this.serviceAssembly.GetTypes());
                    builder.RegisterApiControllers(this.webAssembly);
                    this.container = builder.Build(this.Options);
                }

                return this.container;
            }
        }

        public static AutofacResolver Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AutofacResolver();
                }
                return instance;
            }
        }

        public IDependencyResolver DependencyResolver
        {
            get
            {
                return new AutofacWebApiDependencyResolver(this.Container);
            }
        }
    }
}

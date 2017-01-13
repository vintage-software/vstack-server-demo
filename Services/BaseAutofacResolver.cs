using Autofac;
using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using Vstack.Common.Extensions;
using Vstack.Services.General;

namespace Services
{
    public abstract class BaseAutofacResolver : IResolver, IDisposable
    {
        protected abstract IContainer Container { get; }

        protected ContainerBuildOptions Options { get; } = ContainerBuildOptions.ExcludeDefaultModules;

        public ILifetimeScope BeginLifetimeScope()
        {
            return this.Container.BeginLifetimeScope();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public object Resolve(Type type)
        {
            return this.Container.Resolve(type);
        }

        public object Resolve(Type type, string[] parameters)
        {
            IEnumerable<KeyValuePair<string, object>> namedParameters = type.GetConvertibleNamedParameters(parameters);
            return this.Container.Resolve(type, namedParameters.Select(kvPair => new NamedParameter(kvPair.Key, kvPair.Value)));
        }

        public T Resolve<T>()
        {
            return this.Container.Resolve<T>();
        }

        public T Resolve<T>(string[] parameters)
        {
            IEnumerable<KeyValuePair<string, object>> namedParameters = typeof(T).GetConvertibleNamedParameters(parameters);
            return this.Container.Resolve<T>(namedParameters.Select(kvPair => new NamedParameter(kvPair.Key, kvPair.Value)));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Container.Dispose();
            }
        }
    }
}

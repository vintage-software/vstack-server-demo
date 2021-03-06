﻿using Newtonsoft.Json;
using System.Web.Http;
using Vstack.Api.General;
using Vstack.Api.Web.General;
using Vstack.Common.Extensions;
using Vstack.Services.Web.General;

namespace WebApi.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.ValidateNotNullParameter(nameof(config));

            config.DependencyResolver = AutofacResolver.Instance.DependencyResolver;

            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            settings.ContractResolver = new WebApiContractResolver();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            config.XsrfSuppressDefaultHostAuthentication();
            config.MapHttpAttributeRoutes(new WebApiDirectRouteProvider());
        }
    }
}

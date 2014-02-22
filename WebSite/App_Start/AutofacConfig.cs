using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Utility.Logging.NLog.Autofac;
using Grunch.Data;
using FluentValidation;
using FluentValidation.Mvc;
using Grunch.Services;

namespace WebSite
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterModelBinders(assembly);
            builder.RegisterModelBinderProvider();
            //builder.RegisterHubs(assembly);
            builder.RegisterControllers(assembly).PropertiesAutowired();
            builder.RegisterApiControllers(assembly).PropertiesAutowired();

            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterModule<NLogLoggerAutofacModule>();
            builder.RegisterModule<AutofacFluentValidationModule>();

#if !DEBUG
            builder.RegisterType<ZeroFeatureService>().As<IFeatureService>();
#else
            builder.RegisterType<ConfigurationManagerService>().As<IConfigurationManagerService>();
            builder.RegisterType<AppConfigFeatureService>().As<IFeatureService>();
#endif

            //builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();

            builder.RegisterType<OrderDbContext>().As<IOrderDbContext>();

            IContainer container = builder.Build();
            //container.ActivateGlimpse();

            // MVC dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // WebAPI dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // SignalR dependency resolver
            //GlobalHost.DependencyResolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(container);

            // Set up the FluentValidation provider factory and add it as a Model validator
            var fluentValidationModelValidatorProvider = new FluentValidationModelValidatorProvider(new AutofacValidatorFactory(container));
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            fluentValidationModelValidatorProvider.AddImplicitRequiredValidator = false;
            ModelValidatorProviders.Providers.Add(fluentValidationModelValidatorProvider);
        }
    }
}
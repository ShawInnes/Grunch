using Autofac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite
{
    public class AutofacFluentValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            AssemblyScanner findValidatorsInAssembly = AssemblyScanner.FindValidatorsInAssembly(typeof(Grunch.Validation.GroupOrderValidator).Assembly);
            foreach (AssemblyScanner.AssemblyScanResult item in findValidatorsInAssembly)
            {
                builder
                    .RegisterType(item.ValidatorType)
                    .Keyed<IValidator>(item.InterfaceType)
                    .As<IValidator>();
            }

            //builder.RegisterType<RegisterModelValidator>()
            //        .Keyed<IValidator>(typeof(IValidator<RegisterModel>))
            //        .As<IValidator>();
            //builder.RegisterType<RegisterExternalLoginModelValidator>()
            //        .Keyed<IValidator>(typeof(IValidator<RegisterExternalLoginModel>))
            //        .As<IValidator>();
            //builder.RegisterType<LoginModelValidator>()
            //        .Keyed<IValidator>(typeof(IValidator<LoginModel>))
            //        .As<IValidator>();
            //builder.RegisterType<LocalPasswordModelValidator>()
            //        .Keyed<IValidator>(typeof(IValidator<LocalPasswordModel>))
            //        .As<IValidator>();
        }
    }
}

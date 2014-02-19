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
        }
    }
}

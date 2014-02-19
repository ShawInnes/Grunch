using Autofac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite
{
    public class AutofacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IContainer container;

        public AutofacValidatorFactory(IContainer container)
        {
            this.container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator = container.ResolveOptionalKeyed<IValidator>(validatorType);
            return validator;
        }        
    }
}
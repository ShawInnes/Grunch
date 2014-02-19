using FluentValidation;
using Grunch.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunch.Validation
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.EmailAddress).NotNull().EmailAddress();
        }
    }
}

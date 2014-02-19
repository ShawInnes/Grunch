using FluentValidation;
using Grunch.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunch.Validation
{
    public class GroupOrderValidator : AbstractValidator<GroupOrder>
    {
        public GroupOrderValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Owner).NotNull();
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.Description).NotNull();
        }
    }
}

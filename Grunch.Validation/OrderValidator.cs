using FluentValidation;
using Grunch.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunch.Validation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Person).NotNull();
            RuleFor(x => x.OrderDescription).NotNull();
            RuleFor(x => x.Amount).InclusiveBetween(0.0, 100.0);
        }
    }
}
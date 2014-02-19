using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Grunch.Core
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Person { get; set; }

        public string OrderDescription { get; set; }

        public double Amount { get; set; }
    }
}
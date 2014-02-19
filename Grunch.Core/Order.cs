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

        [Required(ErrorMessage = "A Person is required")]
        public string Person { get; set; }

        [Required(ErrorMessage = "An Order Description is required")]
        public string OrderDescription { get; set; }

        [Required(ErrorMessage = "An Amount is required")]
        [Range(0.01, 100.0, ErrorMessage = "Amount must be >= 0.01 and <= 100.0")]
        public double Amount { get; set; }
    }
}

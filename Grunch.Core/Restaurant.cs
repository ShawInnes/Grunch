using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grunch.Core
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        public int SuburbId { get; set; }
        public virtual Suburb Suburb { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(25)]
        public string Email { get; set; }

        [StringLength(25)]
        public string Address { get; set; }

        public virtual ICollection<MenuGrouping> MenuGroupings { get; set; }
    }
}

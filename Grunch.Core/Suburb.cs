using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grunch.Core
{
    public class Suburb
    {
        [Key]
        public int Id { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }        
    }
}
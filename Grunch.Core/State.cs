using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grunch.Core
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        [StringLength(25)]
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grunch.Core
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [StringLength(2)]
        public string Code { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}

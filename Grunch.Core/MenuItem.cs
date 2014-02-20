using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grunch.Core
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public int SortOrder { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public double Price { get; set; }
    }
}

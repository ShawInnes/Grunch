using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grunch.Core
{
    public class GroupOrder
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Owner { get; set; }
        
        //public ApplicationIdentity OwnerIdentity { get; set; }

        public string Description { get; set; }

        public OrderStatus Status { get; set; }    
        
        public virtual List<Order> Orders { get; set; }

        /// <summary>
        /// Initializes a new instance of the GroupOrder class.
        /// </summary>
        public GroupOrder()
        {
            Date = DateTime.Now.Date;
            Status = OrderStatus.Open;
            Orders = new List<Order>();
        }
    }
}
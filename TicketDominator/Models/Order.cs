using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketDominator.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public DateTime OrderDate { get; set; }
        public string HowPaid { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public double DiscountAmount { get; set; }

    }
}
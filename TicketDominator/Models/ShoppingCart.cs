using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketDominator.Models
{
    public class ShoppingCart
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public Ticket Ticket { get; set; }

        [Required]
        public Guid UserId { get; internal set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
        
    }
}
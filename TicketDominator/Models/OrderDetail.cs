using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketDominator.Models
{
    public class OrderDetail
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public Ticket Ticket { get; set; }
        [Required]
        [Range (1, 100)]
        public int Quantity { get; set; }

		[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
		public Double PricePaidEach { get; set; }

    }
}
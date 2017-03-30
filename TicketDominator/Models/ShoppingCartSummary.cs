using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketDominator.Models
{
    public class ShoppingCartSummary
    {
        public int Quantity { get; set; }

		[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
		public double TotalValue { get; set; }
    }
}
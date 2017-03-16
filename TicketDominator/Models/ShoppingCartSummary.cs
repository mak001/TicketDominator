using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketDominator.Models
{
    public class ShoppingCartSummary
    {
        public int Quantity { get; set; }
        public double TotalValue { get; set; }
    }
}
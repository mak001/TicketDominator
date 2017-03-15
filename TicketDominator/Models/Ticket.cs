using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TicketDominator.Models
{
    public class Ticket
    {

		[Key]
		public int Id { get; set; }
        public string Artist { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }
		
    }
}
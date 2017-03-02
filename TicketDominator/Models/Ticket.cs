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
		public float Price { get; set; }
		public string Artist { get; set; }
		public string Venue { get; set; }
    }
}
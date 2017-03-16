using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketDominator.Models;

namespace TicketDominator.Controllers
{
    public class TicketsController : Controller
    {
        // GET: Tickets
        public ActionResult Index()
        {
			using (TicketDominatorContext context = new TicketDominatorContext()) {
				var list = context.Tickets.OrderBy(x => x.Artist).ToList();
				return View(list);
			}
		}

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
			if (id == null) {
				return RedirectToAction("Index");
			}

			Ticket result = null;
			using (TicketDominatorContext context = new TicketDominatorContext()) {
				result = context.Tickets.FirstOrDefault(x => x.Id == id);
			}
			return View(result);
		}

    }
}

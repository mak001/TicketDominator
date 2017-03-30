using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicketDominator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
			if (User.IsInRole("Admin")) {
				return this.RedirectToAction("Index", "AdminTickets");
			} else {
				return this.RedirectToAction("Index", "Tickets");
			}
        }
    }
}
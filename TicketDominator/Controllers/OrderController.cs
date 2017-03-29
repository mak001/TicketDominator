using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TicketDominator.Models;

namespace TicketDominator.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Details(int id) {
			Guid UserID = UserHelper.GetUserId();
			ViewBag.ApplicationUser = UserHelper.GetApplicationUser();

			using (TicketDominatorContext context = new TicketDominatorContext()) {
				var order = context.Orders
					.Include(p => p.OrderDetails.Select(c => c.Ticket))
					.FirstOrDefault(x => x.Id == id && x.UserId == UserID);
				return View(order);
			}
		}
    }
}
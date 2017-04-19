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
			ViewBag.ApplicationUser = UserHelper.GetApplicationUser();

			using (TicketDominatorContext context = new TicketDominatorContext()) {
				var UserId = UserHelper.GetUserId();

				List<Order> orders = context.Orders.ToList();

				if (!User.IsInRole("Admin")) {
					orders = context.Orders.Where(x => x.UserId == UserId).ToList();
				}

				if (Request.IsAjaxRequest()) {
					return Json(orders, JsonRequestBehavior.AllowGet);
				}

				return View(orders);
			}
        }

		public ActionResult Details(int? id) {
			if (id == null) {
				return this.RedirectToAction("Index");
			}

			Guid UserID = UserHelper.GetUserId();
			ViewBag.ApplicationUser = UserHelper.GetApplicationUser();

			using (TicketDominatorContext context = new TicketDominatorContext()) {
				IQueryable<Order> orders = context.Orders.Include(p => p.OrderDetails.Select(c => c.Ticket));

				Order order;

				if (User.IsInRole("Admin")) {
					order = orders.FirstOrDefault(x => x.Id == id);
				} else {
					order = orders.FirstOrDefault(x => x.Id == id && x.UserId == UserID);
				}

				if (order == null) {
					return this.RedirectToAction("Index");
				}

				if (Request.IsAjaxRequest()) {
					return Json(order, JsonRequestBehavior.AllowGet);
				}

				return View(order);
			}
		}
    }
}
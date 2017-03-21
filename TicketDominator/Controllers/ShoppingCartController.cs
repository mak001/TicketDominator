using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TicketDominator.Models;

namespace TicketDominator.Controllers
{
    public class ShoppingCartController : Controller
    {
        private Guid UserId = UserHelper.GetUserId();

        private ShoppingCartSummary GetShoppingCartSummary(TicketDominatorContext context)
        {
            ShoppingCartSummary summary = new ShoppingCartSummary();
            var cartList = context.ShoppingCarts.Where(x => x.UserId == UserId);
            if (cartList != null && cartList.Count() > 0)
            {
                summary.TotalValue = cartList.Sum(x => x.Quantity * x.Ticket.Price);
                summary.Quantity = cartList.Sum(x => x.Quantity);
            }
            return summary;
        }

        // GET: SHoppingCart
        public ActionResult Index()
        {
			using (TicketDominatorContext context = new TicketDominatorContext()) {

				ViewBag.Summary = GetShoppingCartSummary(context);

				var carts = context.ShoppingCarts.Include("Ticket").Where(x => x.UserId == UserId);
				return View(carts.ToList());
			}
        }

		public ActionResult Partial() {
			using (TicketDominatorContext context = new TicketDominatorContext()) {
				ShoppingCartSummary summary = GetShoppingCartSummary(context);
				return PartialView("_AjaxCartSummary", summary);
			}
		}

		public ActionResult AddToCart(int id)
        {
            using (TicketDominatorContext context = new TicketDominatorContext())
            {
                Ticket addTicket = context.Tickets.FirstOrDefault(x => x.Id == id);

                if (addTicket != null)
                {
                    var sameItemInCart = context.ShoppingCarts.FirstOrDefault(x => x.Ticket.Id == id && x.UserId == UserId);
                    if (sameItemInCart == null)
                    {
                        ShoppingCart sc = new ShoppingCart
                        {
                            Ticket = addTicket,
                            UserId = UserId,
                            Quantity = 1,
                            DateAdded = DateTime.Now
                        };
                        context.ShoppingCarts.Add(sc);
                    } else
                    {
                        sameItemInCart.Quantity++;
                    }

                    context.SaveChanges();
                }
                ShoppingCartSummary summary = GetShoppingCartSummary(context);
                return PartialView("_AjaxCartSummary", summary);
            }
        }


		[Authorize]
		[HttpGet]
		public ActionResult Checkout() {
			using (TicketDominatorContext context = new TicketDominatorContext()) {
				return null;
			}
		}

    }
}

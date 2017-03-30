using System.Linq;
using X.PagedList;
using System.Web.Mvc;
using TicketDominator.Models;

namespace TicketDominator.Controllers
{
    public class TicketsController : Controller
    {
        // GET: Tickets
        public ActionResult Index(int page = 1, int pageQty = 12, string sortExp = "date", string sortOrder = "asc")
        {
			if (User.IsInRole("Admin")) {
				return this.RedirectToAction("Index", "AdminTickets");
			}

			using (TicketDominatorContext context = new TicketDominatorContext()) {
				ViewBag.SortExpression = sortExp;
				ViewBag.SortOrder = sortOrder;

				//var items = from i in context.Tickets where i.Amount > 0 select i;
				var items = context.Tickets.Where(x => x.Amount > 0);

				switch (sortExp) {
					case "date":
						if (sortOrder == "desc") {
							items = items.OrderByDescending(x => x.Date);
						} else {
							items = items.OrderBy(x => x.Date);
						}
						break;

					case "artist":
						if (sortOrder == "desc") {
							items = items.OrderByDescending(x => x.Artist);
						} else {
							items = items.OrderBy(x => x.Artist);
						}
						break;

					case "venue":
						if (sortOrder == "desc") {
							items = items.OrderByDescending(x => x.Venue);
						} else {
							items = items.OrderBy(x => x.Venue);
						}

						break;
				}

				return View(items.ToPagedList(page, pageQty));
			}
		}

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
			if (User.IsInRole("Admin")) {
				return this.RedirectToAction("Index", "AdminTickets");
			}

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

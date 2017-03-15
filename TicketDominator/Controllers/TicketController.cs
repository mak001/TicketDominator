using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketDominator.Models;

// TODO

namespace TicketDominator.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
			using (TicketDominatorContext context = new TicketDominatorContext()) {
				var list = context.Tickets.OrderBy(x => x.Artist).ToList();
				return View(list);
			}
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            Ticket result = null;
            using (TicketDominatorContext context = new TicketDominatorContext())
            {
                result = context.Tickets.FirstOrDefault(x => x.Id == id);
            }
            return View(result);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            using (TicketDominatorContext context = new TicketDominatorContext()) {
                return View();
            }
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create(Ticket obj)
        {
            try
            {
                // TODO: Add insert logic here
                using (TicketDominatorContext context = new TicketDominatorContext()) {
                    context.Tickets.Add(obj);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }    
            }
            catch
            {
                return View();
            }
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            Ticket result = null;
            using (TicketDominatorContext context = new TicketDominatorContext()) {
                result = context.Tickets.FirstOrDefault(x => x.Id == id);
            }
            return View(result);
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Ticket obj)
        {
            try
            {
                using (TicketDominatorContext context = new TicketDominatorContext()) {
                    var item = context.Tickets.FirstOrDefault(x => x.Id == id);
                    TryUpdateModel(item);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ticket/CustomerList
        public ActionResult CustomerList()
        {
            using (TicketDominatorContext context = new TicketDominatorContext())
            {
                var list = context.Tickets.OrderBy(x => x.Artist).ToList();
                return View(list);
            }
        }
    }
}

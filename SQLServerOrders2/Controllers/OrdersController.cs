using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using SQLServerOrders2.DAL;
using SQLServerOrders2.Models;
using SQLServerOrders2.ViewModel;

namespace SQLServerOrders2.Controllers
{
  //  [Authorize]
    public class OrdersController : Controller
    {
        private OrdersDbContext db = new OrdersDbContext();

        // GET: Orders
        public ActionResult Index(string searchOrder)
        {
            var model = db.Orders.Include(o => o.Contact);


            var orders = from o in model
                           select o;

            if (!String.IsNullOrEmpty(searchOrder))
            {
                model = orders.Where(c => c.OrderDescription.Contains(searchOrder));
            }




            return View(model);





           
        }


        public ActionResult SortOrders(string sortBy)
        {
            var model = db.Orders.Include(o => o.Contact).ToList();



            switch (sortBy)
            {

                case "orderid":
                    model = db.Orders.Include(o => o.Contact).OrderBy(c => c.OrderId).ToList();
                    break;

                case "orderdate":
                    model = db.Orders.Include(o => o.Contact).OrderBy(c => c.OrderDate).ToList();
                    break;

                case "orderamount":
                    model = db.Orders.Include(o => o.Contact).OrderBy(c => c.OrderAmount).ToList();
                    break;

                default:
                    
                    break;
            }

            return View("Index", model);
        }


       


        // [AllowAnonymous]
        public ActionResult GetOrders()
        {
            return Json(db.Orders.ToList(), JsonRequestBehavior.AllowGet);
        }
        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create(int? id)

        {
            if (id == null)
            {
                var model = new Order();

                ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "FullName");
                return View(model);
            }

            else
            {
                var model = new vm_AddOrderFromContact();
                var contact = db.Contacts.Find(id);
                model.ContactId = contact.ContactId;
                model.FullName = contact.FullName;


                return View("CreateOrderWithContactId", model);

            }

        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,ContactId,OrderDate,OrderDescription,OrderAmount")] Order order)
        {

            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "FirstName", order.ContactId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "FullName", order.ContactId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,ContactId,OrderDate,OrderDescription,OrderAmount")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "FirstName", order.ContactId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

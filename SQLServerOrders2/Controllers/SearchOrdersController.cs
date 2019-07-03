using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SQLServerOrders2.BLL;
using SQLServerOrders2.DAL;
using SQLServerOrders2.Models;

namespace SQLServerOrders2.Controllers
{

    [Authorize]
    public class SearchOrdersController : Controller
    {
        private OrdersDbContext db = new OrdersDbContext();
        private IOrdersServiceLayer svc = new OrdersServiceLayerImpl();
        // GET: SearchOrders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Contact);
            return View(orders.ToList());
        }




        [AllowAnonymous]
        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var allOrders = svc.getAllOrders();


            var orders = (from o in allOrders
                          where o.OrderDescription.StartsWith(prefix)
                          select new
                          {
                              label = o.OrderDescription,
                              val = o.OrderId
                          }).ToList();

            return Json(orders);
        }




        // GET: SearchOrders/Details/5
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

        // GET: SearchOrders/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "FirstName");
            return View();
        }

        // POST: SearchOrders/Create
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

        // GET: SearchOrders/Edit/5
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
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "FirstName", order.ContactId);
            return View(order);
        }

        // POST: SearchOrders/Edit/5
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

        // GET: SearchOrders/Delete/5
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

        // POST: SearchOrders/Delete/5
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

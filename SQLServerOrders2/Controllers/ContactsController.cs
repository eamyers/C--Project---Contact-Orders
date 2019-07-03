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
    /// <summary>
    /// Controller returns logical views.
    /// </summary>
    public class ContactsController : Controller
    {
        private IContactsServiceLayer _service;
        //I cannot get Ninject to work for dependency injection.



        /// <summary>
        /// Controller constructor uses instantiated service layer impl- needs DI
        /// </summary>
        public ContactsController()
        {
            this._service = new ContactsServiceLayerImpl();
        }


        /// <summary>
        /// Returns index view with contact list and possibility to search.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string search)
        {
            if (TempData["error"] != null)
            {
                ViewBag.Error = TempData["error"].ToString();
            }

           


            var model = _service.getAllContacts();

            //this is for search function
            var contacts = from c in model
                           select c;

            if(!String.IsNullOrEmpty(search))
            {
                model = contacts.Where(c => c.LastName.Contains(search));
            }

            return View(model);
        }



        ///// <summary>
        ///// Returns index view with contact list and possibility to search.
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult Index()
        //{
        //    if (TempData["error"] != null)
        //    {
        //        ViewBag.Error = TempData["error"].ToString();
        //    }


        //    var model = _service.getAllContacts();

        //    return View(model);
        //}



    



        /// <summary>
        /// Pass table header via url action to bll->dal for sorting
        /// DAL holds switch statement for header title parameters.
        /// </summary>
        /// <param name="sortBy">lastname, createddate</param>
        /// <returns>descending sorted list</returns>
        public ActionResult SortContacts(string sortBy)
        {
            var model = _service.GetSortedContacts(sortBy);

            return View("Index", model);
        }



        /// <summary>
        /// Returns 1 contact-  GET contacts/details/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var model = new Contact();
            try
            {
                model = _service.getContact(id);
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction("Index");
               
            }


            return View(model);
        }




        /// <summary>
        /// Returns create view with empty contact.
        /// No bll or dal.
        /// GET: Contacts/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var model = new Contact();

            return View(model);
        }



        /// <summary>
        /// Creates new contact from contact view form 
        /// POST: Contacts/Create
        /// Binding protects from overposting
        /// </summary>
        /// <param name="contact">contact-form binding</param>
        /// <returns>redirects to index or returns create view if invalid</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactId,FirstName,LastName,DateOfBirth,AllowContactByPhone,CreatedDate,Role", Exclude = "FullName")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _service.createContact(contact);
                
                return RedirectToAction("Index");

            }
            else
            {
                return View(contact);
            }

        }



        /// <summary>
        /// GET: Contacts/Edit/5
        /// </summary>
        /// <param name="id">Gets edit page with contact model from db</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var model = new Contact();
            try
            {
                model = _service.getContact(id);
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction("Index");
            }
            return View(model);

        }



        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactId,FirstName,LastName,DateOfBirth,AllowContactByPhone,CreatedDate,Role")] Contact contact)
        {
            try
            {
                _service.editContact(contact);
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }



        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            Contact contact = new Contact();
            try
            {
                contact = _service.getContact(id);
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction("Index");
            }
            return View(contact);

        }



        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            _service.deleteContact(id);
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                OrdersDbContext db = new OrdersDbContext();

                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

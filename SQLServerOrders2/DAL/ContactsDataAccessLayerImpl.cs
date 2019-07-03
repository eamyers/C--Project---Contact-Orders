using SQLServerOrders2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SQLServerOrders2.DAL
{
    public class ContactsDataAccessLayerImpl : IContactsDataAccessLayer
    {

        private OrdersDbContext db = new OrdersDbContext();

        public void createContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }



        /// <summary>
        /// breaks parameter pattern b/c service layer retreived contact during check
        /// 
        /// </summary>
        /// <param name="contact"></param>
        public void deleteContact(Contact contact)
        {
            db.Contacts.Remove(contact);
            
            db.SaveChanges();
        }



        public void editContact(Contact contact)
        {

             db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
        }



        public IQueryable<Contact> getAllContacts()
        {
            IQueryable<Contact> fromDb = db.Contacts;

            return fromDb;

        }


        public List<Contact> GetSortedContacts(string sortBy)
        {
             switch (sortBy)
            {
               
                case "lastname":
                    return db.Contacts.OrderBy(c => c.LastName).ToList();
                   

                case "createddate":
                    return db.Contacts.OrderBy(c => c.CreatedDate).ToList();
                   

                default:
                    return db.Contacts.ToList();
          
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contact getContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            return contact;
        }

       
    }
}
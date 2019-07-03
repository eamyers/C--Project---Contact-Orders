using SQLServerOrders2.DAL;
using SQLServerOrders2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SQLServerOrders2.BLL
{
    public class ContactsServiceLayerImpl : IContactsServiceLayer
    {
        private IContactsDataAccessLayer _dal;

        public ContactsServiceLayerImpl()
        {
            this._dal = new ContactsDataAccessLayerImpl();
        }


        public void createContact(Contact contact)
        {
            _dal.createContact(contact);
        }


        public void deleteContact(int id)
        {
            Contact contact = checkContact(id);

            _dal.deleteContact(contact);
        }



        public void editContact(Contact contact)
        {

            checkContact(contact.ContactId);
            _dal.editContact(contact);
        }



        public IQueryable<Contact> getAllContacts()
        {
            return _dal.getAllContacts();

        }



        /// <summary>
        /// Validation on if sortby is not needed - dal switch statement handles via default
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns>sortedlist</returns>
        public List<Contact> GetSortedContacts(string sortBy)
        {
            
            return _dal.GetSortedContacts(sortBy);
        }



        public Contact getContact(int id)
        {

            Contact contact = checkContact(id);
            return contact;

        }



        private Contact checkContact(int id)
        {

            Contact contact = _dal.getContact(id);

            if (contact == null)
            {
                throw new Exception("Contact doesn't exist");
            }
            return contact;

        }
    }
}
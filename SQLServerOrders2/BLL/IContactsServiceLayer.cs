using SQLServerOrders2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SQLServerOrders2.BLL
{
   public interface IContactsServiceLayer
    {
        IQueryable<Contact> getAllContacts();

        List<Contact> GetSortedContacts(string sortBy);

        Contact getContact(int id);

        void createContact(Contact contact);

        void editContact(Contact contact);

        void deleteContact(int id);
    }
}

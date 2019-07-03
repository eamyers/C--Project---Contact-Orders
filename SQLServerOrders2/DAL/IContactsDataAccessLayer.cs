using SQLServerOrders2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerOrders2.DAL
{
    interface IContactsDataAccessLayer
    {

        List<Contact> GetSortedContacts(string sortBy);
        IQueryable<Contact> getAllContacts();

        Contact getContact(int id);

        void createContact(Contact contact);

        void editContact(Contact contact);

        void deleteContact(Contact contact);
    }
}

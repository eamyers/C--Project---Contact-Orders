using SQLServerOrders2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQLServerOrders2.DAL
{
    public class OrdersInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<OrdersDbContext>
    {

        protected override void Seed(OrdersDbContext context)
        {
            var contacts = new List<Contact>
            {
                new Contact {ContactId=1, FirstName = "Moon", LastName = "Beam", DateOfBirth = new DateTime(1987, 01, 01), AllowContactByPhone = true, Role = "Contractor" },
                 new Contact {ContactId=2, FirstName = "Beth", LastName = "Salinger", DateOfBirth = new DateTime(1988, 08, 07), AllowContactByPhone = false, Role = "Captain" },
                  new Contact {ContactId=3, FirstName = "Sarah", LastName = "Kempfert", Role="Accountant" }
            };

            contacts.ForEach(c => context.Contacts.Add(c));
            context.SaveChanges();


            var orders = new List<Order>
            {
                new Order { ContactId = 1, OrderDate = new DateTime(2019, 08,04), OrderDescription = "flyswatter", OrderAmount = 2.50m },
                 new Order {ContactId = 1, OrderDate = new DateTime(2019, 05,04), OrderDescription = "misquito", OrderAmount = 100m  },
                  new Order { ContactId = 2, OrderDate = new DateTime(2019, 01,01), OrderDescription = "fireworks", OrderAmount = 67.99m }
            };

            orders.ForEach(o => context.Orders.Add(o));
            context.SaveChanges();
        }

    }
}
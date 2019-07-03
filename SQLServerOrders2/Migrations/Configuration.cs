namespace SQLServerOrders2.Migrations
{
    using SQLServerOrders2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SQLServerOrders2.DAL.OrdersDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
      
        }

        protected override void Seed(SQLServerOrders2.DAL.OrdersDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Contacts.AddOrUpdate(c => c.ContactId,
                new Contact() { ContactId = 1, FirstName = "Moon", LastName = "Beam", DateOfBirth = new DateTime(1987, 01, 01), AllowContactByPhone = true, Role = "Contractor" },
                new Contact() { ContactId = 2, FirstName = "Beth", LastName = "Salinger", DateOfBirth = new DateTime(1988, 08, 07), AllowContactByPhone = false, Role = "Captain" },
                new Contact() { ContactId = 3, FirstName = "Sarah", LastName = "Kempfert", DateOfBirth = new DateTime(1988, 03, 19), Role = "Accountant" });

     
          

            context.Orders.AddOrUpdate(o => o.OrderId,
                new Order() { ContactId = 1, OrderDate = new DateTime(2019, 08, 04), OrderDescription = "flyswatter", OrderAmount = 2.50m },
                new Order() { ContactId = 1, OrderDate = new DateTime(2019, 05, 04), OrderDescription = "misquito", OrderAmount = 100m },
                new Order() { ContactId = 2, OrderDate = new DateTime(2019, 01, 01), OrderDescription = "fireworks", OrderAmount = 67.99m }
                );
         
            context.SaveChanges();
        }
    }
}

using SQLServerOrders2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SQLServerOrders2.DAL
{
    public class OrdersDbContext : DbContext
    {
       
        public OrdersDbContext() : base ("OrdersSandboxDb")
        {
           
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders { get; set; }


      

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLServerOrders2.Models;

namespace SQLServerOrders2.DAL
{
    public class OrdersDataAccessLayerImpl : IOrdersDataAccessLayer
    {

        private OrdersDbContext db = new OrdersDbContext();

        public void createOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void deleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void editOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> getAllOrders()
        {
            IQueryable<Order> fromDb = db.Orders;

            return fromDb;
        }

        public Order getOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
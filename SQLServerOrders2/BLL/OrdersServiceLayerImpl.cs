using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLServerOrders2.DAL;
using SQLServerOrders2.Models;

namespace SQLServerOrders2.BLL
{
    public class OrdersServiceLayerImpl : IOrdersServiceLayer
    {

        private IOrdersDataAccessLayer _dal;


            public OrdersServiceLayerImpl()
        {
            _dal = new OrdersDataAccessLayerImpl();
        }

        public void createOrder(Order order)
        {
            _dal.createOrder(order);
        }

        public void deleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void editOrder(Order order)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Order> getAllOrders()
        {
         return _dal.getAllOrders();
        }

        public Order getOrder(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetSortedOrders(string sortBy)
        {
            throw new NotImplementedException();
        }
    }
}
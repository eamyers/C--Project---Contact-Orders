using SQLServerOrders2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerOrders2.DAL
{
    interface IOrdersDataAccessLayer
    {

        IQueryable<Order> getAllOrders();

        Order getOrder(int id);

        void createOrder(Order order);

        void editOrder(Order order);

        void deleteOrder(int id);
    }
}

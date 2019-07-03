using SQLServerOrders2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerOrders2.BLL
{
    interface IOrdersServiceLayer
    {

        IQueryable<Order> getAllOrders();

        List<Order> GetSortedOrders(string sortBy);

        Order getOrder(int id);

        void createOrder(Order order);

        void editOrder(Order order);

        void deleteOrder(int id);
    }
}

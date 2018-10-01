using System.Collections.Generic;
using HomeWorkMVC1.Domain.Entities;
using HomeWorkMVC1.Models.Cart;
using HomeWorkMVC1.Models.Order;

namespace HomeWorkMVC1.Infrastructure.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<Order> GetUserOrders(string userName);
        Order GetOrderById(int id);
        Order CreateOrder(OrderViewModel orderModel, CartViewModel transformCart, string userName);
    }

}

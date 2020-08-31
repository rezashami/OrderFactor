using System.Collections.Generic;
using Simulation.Models;

namespace Simulation.Data{
    public interface IOrderItemRepo
    {
        bool SaveChanges();

        IEnumerable<OrderItem> GetOrderItems();
        OrderItem GetOrderItemById(int id);
        void CreateOrderItem(OrderItem cmd);
        void UpdateOrderItem(OrderItem cmd);
        void DeleteOrderItem(OrderItem cmd);
    }
}
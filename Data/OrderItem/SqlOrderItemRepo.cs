using System;
using System.Collections.Generic;
using System.Linq;
using Simulation.Models;

namespace Simulation.Data{
    public class SqlOrderItemRepo : IOrderItemRepo
    {
        private readonly SimulationContext _context;

        public SqlOrderItemRepo(SimulationContext context)
        {
            _context = context;       
        }
        public void CreateOrderItem(OrderItem cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.orderItems.Add(cmd);
        }

        public void DeleteOrderItem(OrderItem cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.orderItems.Remove(cmd);
        }

        public OrderItem GetOrderItemById(int id)
        {
            return _context.orderItems.FirstOrDefault(p => p.orderId == id);
        }

        public IEnumerable<OrderItem> GetOrderItems()
        {
            return _context.orderItems.ToList();
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateOrderItem(OrderItem cmd)
        {
           
        }
    }
}
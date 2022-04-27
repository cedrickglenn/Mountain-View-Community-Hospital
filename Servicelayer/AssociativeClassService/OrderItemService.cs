using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.AssociativeClassService
{
    public class OrderItemService
    {
        private MVCHContext _context;

        public OrderItemService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<OrderItem> GetOrderItems()
        {
            return _context.OrderItems;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            _context.SaveChanges();
        }
    }
}

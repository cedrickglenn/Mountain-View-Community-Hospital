using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.AssociativeClassService
{
    public class OrderServiceService
    {
        private MVCHContext _context;

        public OrderServiceService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<OrderService> GetOrderServices()
        {
            return _context.OrderServices;
        }

        public void AddOrderService(OrderService orderService)
        {
            _context.OrderServices.Add(orderService);
            _context.SaveChanges();
        }

        public void UpdateOrderService(OrderService orderService)
        {
            _context.OrderServices.Update(orderService);
            _context.SaveChanges();
        }
    }
}

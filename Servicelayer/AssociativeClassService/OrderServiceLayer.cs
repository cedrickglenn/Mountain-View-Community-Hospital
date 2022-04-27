using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using Microsoft.EntityFrameworkCore;

namespace Servicelayer.AssociativeClassService
{
    public class OrderServiceLayer
    {
        private MVCHContext _context;

        public OrderServiceLayer(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Order> GetOrders()
        {
            return _context.Orders
                .Include(c=>c.PhysicianLink)
                .Include(c=>c.PatientLink);
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}

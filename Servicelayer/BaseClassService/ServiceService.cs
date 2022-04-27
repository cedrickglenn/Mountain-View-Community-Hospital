using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.BaseClassService
{
    public class ServiceService
    {
        private MVCHContext _context;

        public ServiceService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Service> GetServices()
        {
            return _context.Services;
        }

        public void AddService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
        }
    }
}

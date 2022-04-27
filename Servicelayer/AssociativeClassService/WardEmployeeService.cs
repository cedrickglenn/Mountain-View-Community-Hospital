using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.AssociativeClassService
{
    public class WardEmployeeService
    {
        private MVCHContext _context;

        public WardEmployeeService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<WardEmployee> GetWardEmployees()
        {
            return _context.WardEmployees;
        }

        public void AddWardEmployee(WardEmployee wardEmployee)
        {
            _context.WardEmployees.Add(wardEmployee);
            _context.SaveChanges();
        }

        public void UpdateWardEmployee(WardEmployee wardEmployee)
        {
            _context.WardEmployees.Update(wardEmployee);
            _context.SaveChanges();
        }
    }
}

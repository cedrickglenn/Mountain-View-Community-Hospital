using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.AssociativeClassService
{
    public class UnitEmployeeService
    {
        private MVCHContext _context;

        public UnitEmployeeService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<UnitEmployee> GetUnitEmployees()
        {
            return _context.UnitEmployees;
        }

        public void AddUnitEmployee(UnitEmployee unitEmployee)
        {
            _context.UnitEmployees.Add(unitEmployee);
            _context.SaveChanges();
        }

        public void UpdateUnitEmployee(UnitEmployee unitEmployee)
        {
            _context.UnitEmployees.Update(unitEmployee);
            _context.SaveChanges();
        }
    }
}

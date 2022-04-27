using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.AssociativeClassService
{
    public class EmployeeSpecialtyService
    {
        private MVCHContext _context;

        public EmployeeSpecialtyService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<EmployeeSpecialty> GetEmployeeSpecialties()
        {
            return _context.EmployeeSpecialties;
        }

        public void AddEmployeeSpecialty(EmployeeSpecialty employeeSpecialty)
        {
            _context.EmployeeSpecialties.Add(employeeSpecialty);
            _context.SaveChanges();
        }

        public void UpdateEmployeeSpecialty(EmployeeSpecialty employeeSpecialty)
        {
            _context.EmployeeSpecialties.Update(employeeSpecialty);
            _context.SaveChanges();
        }
    }
}

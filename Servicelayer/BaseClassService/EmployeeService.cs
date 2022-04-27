using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using Microsoft.EntityFrameworkCore;

namespace Servicelayer.BaseClassService
{
    public class EmployeeService
    {
        private MVCHContext _context;

        public EmployeeService(MVCHContext context)
        {
            _context = context;
        }
        
        public IQueryable<Employee> GetEmployees()
        {
            return _context.Employees;
        }

        public IQueryable<Nurse> GetNurses()
        {
            return _context.Nurses;
        }
        public IQueryable<Staff> GetStaff()
        {
            return _context.Staff;
        }
        public IQueryable<Technician> GetTechnicians()
        {
            return _context.Technicians;
        }

        public void AddNurse(Nurse nurse)
        {
            _context.Nurses.Add(nurse);
            _context.SaveChanges();
        }

        public void UpdateNurse(Nurse nurse)
        {
            _context.Nurses.Update(nurse);
            _context.SaveChanges();

        }
        public void AddStaff(Staff staff)
        {
            _context.Staff.Add(staff);
            _context.SaveChanges();
        }

        public void UpdateStaff(Staff staff)
        {
            _context.Staff.Update(staff);

            _context.SaveChanges();

        }
        public void AddTechnician(Technician technician)
        {
            _context.Technicians.Add(technician);
            _context.SaveChanges();
        }

        public void UpdateTechnician(Technician technician)
        {
            _context.Technicians.Update(technician);
            _context.SaveChanges();

        }
    }
}

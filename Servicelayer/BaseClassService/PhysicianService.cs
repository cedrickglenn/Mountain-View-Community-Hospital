using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using Microsoft.EntityFrameworkCore;

namespace Servicelayer.BaseClassService
{
    public class PhysicianService
    {
        private MVCHContext _context;

        public PhysicianService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Physician> GetPhysicians()
        {
            return _context.Physicians;
        }

        public void AddPhysicians(Physician physician)
        {
            _context.Physicians.Add(physician);
            _context.SaveChanges();
        }

        public void UpdatePhysicians(Physician physician)
        {
            _context.Physicians.Update(physician);
            _context.SaveChanges();
        }
    }
}

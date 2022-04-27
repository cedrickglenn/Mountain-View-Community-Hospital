using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.BaseClassService
{
    public class SpecialtyService
    {
        private MVCHContext _context;

        public SpecialtyService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Specialty> GetSpecialties()
        {
            return _context.Specialties;
        }

        public void AddSpecialty(Specialty specialty)
        {
            _context.Specialties.Add(specialty);
            _context.SaveChanges();
        }

        public void UpdateSpecialty(Specialty specialty)
        {
            _context.Specialties.Update(specialty);
            _context.SaveChanges();
        }
    }
}

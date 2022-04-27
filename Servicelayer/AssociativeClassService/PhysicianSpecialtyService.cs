using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.AssociativeClassService
{
    public class PhysicianSpecialtyService
    {
        private MVCHContext _context;

        public PhysicianSpecialtyService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<PhysicianSpecialty> GetPhysicianSpecialties()
        {
            return _context.PhysicianSpecialties;
        }

        public void AddPhysicianSpecialty(PhysicianSpecialty physicianSpecialty)
        {
            _context.PhysicianSpecialties.Add(physicianSpecialty);
            _context.SaveChanges();
        }

        public void UpdatePhysicianSpecialty(PhysicianSpecialty physicianSpecialty)
        {
            _context.PhysicianSpecialties.Update(physicianSpecialty);
            _context.SaveChanges();
        }
    }
}

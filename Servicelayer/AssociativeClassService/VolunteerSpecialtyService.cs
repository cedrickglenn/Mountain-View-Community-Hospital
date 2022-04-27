using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.AssociativeClassService
{
    public class VolunteerSpecialtyService
    {
        private MVCHContext _context;

        public VolunteerSpecialtyService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<VolunteerSpecialty> GetVolunteerSpecialties()
        {
            return _context.VolunteerSpecialties;
        }

        public void AddVolunteerSpecialty(VolunteerSpecialty volunteerSpecialty)
        {
            _context.VolunteerSpecialties.Add(volunteerSpecialty);
            _context.SaveChanges();
        }

        public void UpdateVolunteerSpecialty(VolunteerSpecialty volunteerSpecialty)
        {
            _context.VolunteerSpecialties.Update(volunteerSpecialty);
            _context.SaveChanges();
        }
    }
}

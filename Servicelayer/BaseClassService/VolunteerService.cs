using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using Microsoft.EntityFrameworkCore;

namespace Servicelayer.BaseClassService
{
    public class VolunteerService
    {
        private MVCHContext _context;

        public VolunteerService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Volunteer> GetVolunteers()
        {
            return _context.Volunteers;
        }
        public void AddVolunteer(Volunteer volunteer)
        {
            _context.Volunteers.Add(volunteer);
            _context.SaveChanges();
        }
        public void UpdateVolunteer(Volunteer volunteer)
        {
            _context.Volunteers.Update(volunteer);
            _context.SaveChanges();
        }
    }
}

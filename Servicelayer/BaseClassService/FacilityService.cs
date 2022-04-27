using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.BaseClassService
{
    public class FacilityService
    {
        private MVCHContext _context;

        public FacilityService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Facility> GetFacilities()
        {
            return _context.Facilities;
        }

        public void AddFacility(Facility facility)
        {
            _context.Facilities.Add(facility);
            _context.SaveChanges();
        }

        public void UpdateFacility(Facility facility)
        {
            _context.Facilities.Update(facility);
            _context.SaveChanges();
        }
    }
}

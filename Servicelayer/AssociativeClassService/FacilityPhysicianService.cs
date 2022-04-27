using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.AssociativeClassService
{
    public class FacilityPhysicianService
    {
        private MVCHContext _context;

        public FacilityPhysicianService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<FacilityPhysician> GetFacilityPhysicians()
        {
            return _context.FacilityPhysicians;
        }

        public void AddFacilityPhysician(FacilityPhysician facilityPhysician)
        {
            _context.FacilityPhysicians.Add(facilityPhysician);
            _context.SaveChanges();
        }

        public void UpdateFacilityPhysician(FacilityPhysician facilityPhysician)
        {
            _context.FacilityPhysicians.Update(facilityPhysician);
            _context.SaveChanges();
        }
    }
}

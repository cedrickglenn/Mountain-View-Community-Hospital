using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.BaseClassService
{
    public class BedService
    {
        private MVCHContext _context;

        public BedService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Bed> GetBeds()
        {
            return _context.Beds;
        }

        public void AddBed(Bed bed)
        {
            _context.Beds.Add(bed);
            _context.SaveChanges();
        }

        public void UpdateBed(Bed bed)
        {
            _context.Beds.Update(bed);
            _context.SaveChanges();
        }
    }
}

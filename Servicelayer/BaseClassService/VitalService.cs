using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.BaseClassService
{
    public class VitalService
    {
        private MVCHContext _context;

        public VitalService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Vital> GetVitals()
        {
            return _context.Vitals;
        }

        public void AddVital(Vital vital)
        {
            _context.Vitals.Add(vital);
            _context.SaveChanges();
        }

        public void UpdateVital(Vital vital)
        {
            _context.Vitals.Update(vital);
            _context.SaveChanges();
        }
    }
}

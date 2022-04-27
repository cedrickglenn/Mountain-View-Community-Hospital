using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.BaseClassService
{
    public class WardService
    {
        private MVCHContext _context;

        public WardService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Ward> GetWards()
        {
            return _context.Wards;
        }

        public void AddWard(Ward ward)
        {
            _context.Wards.Add(ward);
            _context.SaveChanges();
        }

        public void UpdateWard(Ward ward)
        {
            _context.Wards.Update(ward);
            _context.SaveChanges();
        }
    }
}

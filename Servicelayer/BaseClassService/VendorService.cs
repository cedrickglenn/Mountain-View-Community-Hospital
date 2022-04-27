using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.BaseClassService
{
    public class VendorService
    {
        private MVCHContext _context;

        public VendorService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Vendor> GetVendors()
        {
            return _context.Vendors;
        }

        public void AddVendor(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            _context.SaveChanges();
        }

        public void UpdateVendor(Vendor vendor)
        {
            _context.Vendors.Update(vendor);
            _context.SaveChanges();
        }
    }
}

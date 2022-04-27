using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.AssociativeClassService
{
    public class VendorSupplyService
    {
        private MVCHContext _context;

        public VendorSupplyService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<VendorSupply> GetVendorSupplies()
        {
            return _context.VendorSupplies;
        }

        public void AddVendorSupply(VendorSupply vendorSupply)
        {
            _context.VendorSupplies.Add(vendorSupply);
            _context.SaveChanges();
        }

        public void UpdateVendorSupply(VendorSupply vendorSupply)
        {
            _context.VendorSupplies.Update(vendorSupply);
            _context.SaveChanges();
        }
    }
}

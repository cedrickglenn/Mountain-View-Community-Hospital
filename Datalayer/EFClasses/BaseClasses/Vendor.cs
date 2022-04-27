using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class Vendor
    {
        public string VendorId { get; set; }
        public string Name { get; set; }

        public ICollection<VendorSupply>? VendorSupplies { get; set; }
    }
}

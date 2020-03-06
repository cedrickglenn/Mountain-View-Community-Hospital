using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;

namespace Datalayer.EFClasses.AssociativeClasses
{
    public class VendorSupply
    {
        public string VendorSupplyId { get; set; }
        public int Quantity { get; set; }

        public Vendor VendorLink { get; set; }
        public Item ItemLink { get; set; }
        public string? VendorId { get; set; }
        public string ItemId { get; set; }
    }
}

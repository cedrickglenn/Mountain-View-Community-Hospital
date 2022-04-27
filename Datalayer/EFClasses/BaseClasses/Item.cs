using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class Item
    {
        public string ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitCost { get; set; }

        public ICollection<VendorSupply> VendorSupplies { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }  
    }
}

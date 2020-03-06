using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;

namespace Datalayer.EFClasses.AssociativeClasses
{
    public class OrderService
    {
        public string OrderServiceId { get; set; }
        public int Quantity { get; set; }

        public Order OrderLink { get; set; }
        public Service ServiceLink { get; set; }
        public string OrderId { get; set; }
        public string? ServiceId { get; set; }

    }
}

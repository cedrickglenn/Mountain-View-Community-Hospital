using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;

namespace Datalayer.EFClasses.AssociativeClasses
{
    public class OrderItem
    {
        public string OrderItemId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Subtotal { get; set; }
        public int Quantity { get; set; }

        public PatientOrder PatientOrderLink { get; set; }
        public Item ItemLink { get; set; }
        public string PatientOrderId { get; set; }
        public string? ItemId { get; set; }

    }
}

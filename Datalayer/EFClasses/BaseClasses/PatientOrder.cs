using System;
using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class PatientOrder
    {
        public string PatientOrderId { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime DateTime { get; set; }
        public Patient PatientLink { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public string? PatientId { get; set; }

    }
}

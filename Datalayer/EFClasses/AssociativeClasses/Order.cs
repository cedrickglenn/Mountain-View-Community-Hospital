using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.AssociativeClasses
{
    public class Order
    {
        public string OrderId { get; set; }
        public DateTime DateTime { get; set; }
        public string Instructions { get; set; }

        public Physician PhysicianLink { get; set; }
        public Patient PatientLink { get; set; }
        public ICollection<OrderService> OrderServices { get; set; }
        public string? PhysicianId { get; set; }
        public string? PatientId { get; set; }
    }
}

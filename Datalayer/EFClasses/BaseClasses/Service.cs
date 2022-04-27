using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class Service
    {
        public string ServiceId { get; set; }
        public string Name { get; set; }

        public ICollection<OrderService>? OrderServices { get; set; }
    }
}

using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class Vital
    {
        public string VitalId { get; set; }
        public string Description { get; set; }

        public ICollection<VitalRecord> VitalRecords { get; set; }
    }
}

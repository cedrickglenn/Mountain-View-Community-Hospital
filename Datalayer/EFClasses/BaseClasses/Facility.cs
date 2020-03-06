using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class Facility
    {
        public string FacilityId { get; set; }
        public string Name { get; set; }

        public ICollection<Ward> Wards { get; set; }
        public ICollection<FacilityPhysician> FacilityPhysicians { get; set; }
        public ICollection<WorkUnit> WorkUnits { get; set; }

    }
}

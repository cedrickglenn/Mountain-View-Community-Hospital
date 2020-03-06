using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class WorkUnit
    {
        public string WorkUnitId { get; set; }
        public string Name { get; set; }
        public string Floor { get; set; }

        public ICollection<UnitEmployee> UnitEmployees { get; set; }
        public ICollection<Bed> Beds { get; set; }
        public ICollection<Volunteer> Volunteers { get; set; }
        public Facility FacilityLink { get; set; }
        public string FacilityId { get; set; }
    }
}

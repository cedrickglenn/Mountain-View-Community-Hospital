using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class Ward
    {
        public string WardId { get; set; }
        public string Name { get; set; }

        public ICollection<WardEmployee> WardEmployees { get; set; }
        public ICollection<Inpatient> Inpatients { get; set; }
        public Facility FacilityLink { get; set; }
        public string FacilityId { get; set; }
    }
}

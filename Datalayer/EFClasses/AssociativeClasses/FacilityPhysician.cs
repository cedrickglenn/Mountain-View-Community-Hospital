using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.AssociativeClasses
{
    public class FacilityPhysician
    {
        public string FacilityPhysicianId { get; set; }
        public DateTime DateAssigned { get; set; }

        public Facility FacilityLink { get; set; }
        public Physician PhysicianLink { get; set; }
        public string FacilityId { get; set; }
        public string? PhysicianId { get; set; }

    }
}

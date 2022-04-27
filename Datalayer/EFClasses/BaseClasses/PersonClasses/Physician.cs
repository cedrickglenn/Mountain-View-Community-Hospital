using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;

namespace Datalayer.EFClasses.BaseClasses.PersonClasses
{
    public class Physician : Person
    {
 
        public string PagerNumber { get; set; }
        public string DEANumber { get; set; }


        public ICollection<Diagnosis>? Diagnoses { get; set; }
        public ICollection<Treatment>? Treatments{ get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<PhysicianSpecialty> PhysicianSpecialties { get; set; }
        public ICollection<FacilityPhysician>? FacilityPhysicians { get; set; }
    }
}

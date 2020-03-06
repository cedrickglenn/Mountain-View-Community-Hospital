using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class Specialty
    {
        public string SpecialtyId { get; set; }
        public string Name { get; set; }
        public ICollection<PhysicianSpecialty> PhysicianSpecialties { get; set; }
        public ICollection<EmployeeSpecialty> EmployeeSpecialties { get; set; }
        public ICollection<VolunteerSpecialty> VolunteerSpecialties { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.AssociativeClasses
{
    public class PhysicianSpecialty
    {
        public string PhysicianSpecialtyId { get; set; }
        public DateTime DateAcquired { get; set; }

        public Physician PhysicianLink { get; set; }
        public Specialty SpecialtyLink { get; set; }
        public string PhysicianId { get; set; }
        public string SpecialtyId { get; set; }
    }
}

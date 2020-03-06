using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.AssociativeClasses
{
    public class Treatment
    {
        public string TreatmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }

        public Patient PatientLink { get; set; }
        public Physician PhysicianLink { get; set; }
        public Service ServiceLink { get; set; }
        public string? PatientId { get; set; }
        public string? PhysicianId { get; set; }
        public string? ServiceId { get; set; }
    }
}

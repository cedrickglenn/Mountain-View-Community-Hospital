using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.AssociativeClasses
{
    public class Diagnosis
    {
        public string DiagnosisId { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }

        public Patient PatientLink { get; set; }
        public Physician PhysicianLink { get; set; }
        public Condition ConditionLink { get; set; }
        public string ConditionId { get; set; }
        public string PatientId { get; set; }
        public string PhysicianId { get; set; }
    }
}

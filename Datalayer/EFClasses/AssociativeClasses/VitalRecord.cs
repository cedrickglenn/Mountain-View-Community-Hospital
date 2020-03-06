using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.AssociativeClasses
{
    public class VitalRecord
    {
        public string VitalRecordId { get; set; }
        public string Value { get; set; }
        public DateTime DateTime { get; set; }

        public Patient PatientLink { get; set; }
        public Vital VitalLink { get; set; }
        public Nurse NurseLink { get; set; }
        public string PatientId { get; set; }
        public string VitalId { get; set; }
        public string NurseId { get; set; }
        
    }
}

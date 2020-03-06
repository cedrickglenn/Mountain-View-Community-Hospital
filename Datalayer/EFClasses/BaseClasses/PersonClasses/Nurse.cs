using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;

namespace Datalayer.EFClasses.BaseClasses.PersonClasses
{
    public class Nurse : Employee
    {
        public string NurseId { get; set; }
        public string Degree { get; set; }
        public string License { get; set; }

        public ICollection<VitalRecord> VitalRecords { get; set; }
    }
}

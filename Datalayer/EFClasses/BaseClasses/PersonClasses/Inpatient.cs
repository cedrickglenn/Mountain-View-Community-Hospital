using System;

namespace Datalayer.EFClasses.BaseClasses.PersonClasses
{
    public class Inpatient : Patient
    {
        public string InpatientId { get; set; }
        public DateTime DateAdmitted { get; set; }
        public DateTime DischargeDate { get; set; }

        public Bed BedLink { get; set; }
        public Ward WardLink { get; set; }
        public string? BedId { get; set; }
        public string? WardId { get; set; }
    }
}

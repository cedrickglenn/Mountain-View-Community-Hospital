using System;
using System.Collections.Generic;

namespace Datalayer.EFClasses.BaseClasses.PersonClasses
{
    public class Outpatient : Patient
    {
        public string OutpatientId { get; set; }
        public DateTime VisitDate { get; set; }

        public ICollection<Visit> Visits { get; set; }

    }
}

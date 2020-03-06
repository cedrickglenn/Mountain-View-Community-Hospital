using System;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class Visit
    {
        public string VisitId { get; set; }
        public DateTime DateTime { get; set; }
        public Outpatient OutpatientLink { get; set; }
        public string? OutpatientId { get; set; }
    }
}

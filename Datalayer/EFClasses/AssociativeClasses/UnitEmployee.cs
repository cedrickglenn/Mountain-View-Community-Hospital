using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.AssociativeClasses
{
    public class UnitEmployee
    {
        public string UnitEmployeeId { get; set; }
        public DateTime DateAssigned { get; set; }

        public WorkUnit WorkUnitLink { get; set; }
        public Employee EmployeeLink { get; set; }
        public string WorkUnitId { get; set; }
        public string? EmployeeId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.AssociativeClasses
{
    public class WardEmployee
    {
        public string WardEmployeeId { get; set; }
        public DateTime DateAssigned { get; set; }

        public Ward WardLink { get; set; }
        public Employee EmployeeLink { get; set; }
        public string WardId { get; set; }
        public string? EmployeeId { get; set; }
    }
}

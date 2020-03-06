using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.AssociativeClasses
{
    public class EmployeeSpecialty
    {
        public string EmployeeSpecialtyId { get; set; }
        public DateTime DateAcquired { get; set; }

        public Employee EmployeeLink { get; set; }
        public Specialty SpecialtyLink { get; set; }
        public string EmployeeId { get; set; }
        public string? SpecialtyId { get; set; }

    }
}

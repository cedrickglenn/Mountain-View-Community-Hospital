using System;
using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;

namespace Datalayer.EFClasses.BaseClasses.PersonClasses
{
    public class Employee : Person
    {
        public string EmployeeId { get; set; }
        public DateTime DateHired { get; set; }
        public char EmployeeType { get; set; }

        public ICollection<EmployeeSpecialty> EmployeeSpecialties { get; set; }
        public ICollection<WardEmployee> WardEmployees { get; set; }
        public ICollection<UnitEmployee> UnitEmployees { get; set; }

    }
}

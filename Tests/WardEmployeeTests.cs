using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using NUnit.Framework;
using Servicelayer.AssociativeClassService;

namespace Tests
{
    public class WardEmployeeTests
    {
        [Test]
        public void AddWardEmployeeTest()
        {
            var serv = new WardEmployeeService(new MVCHContext());
            serv.AddWardEmployee(new WardEmployee
            {
                WardId = "WRD-000001",
                EmployeeId = "PER-000031",
                DateAssigned = DateTime.Now
            });
            serv.AddWardEmployee(new WardEmployee
            {
                WardId = "WRD-000002",
                EmployeeId = "PER-000032",
                DateAssigned = DateTime.Now
            });
            serv.AddWardEmployee(new WardEmployee
            {
                WardId = "WRD-000003",
                EmployeeId = "PER-000033",
                DateAssigned = DateTime.Now
            });
            serv.AddWardEmployee(new WardEmployee
            {
                WardId = "WRD-000004",
                EmployeeId = "PER-000034",
                DateAssigned = DateTime.Now
            });
            serv.AddWardEmployee(new WardEmployee
            {
                WardId = "WRD-000005",
                EmployeeId = "PER-000035",
                DateAssigned = DateTime.Now
            });
            serv.AddWardEmployee(new WardEmployee
            {
                WardId = "WRD-000006",
                EmployeeId = "PER-000036",
                DateAssigned = DateTime.Now
            });
            serv.AddWardEmployee(new WardEmployee
            {
                WardId = "WRD-000007",
                EmployeeId = "PER-000037",
                DateAssigned = DateTime.Now
            });
            serv.AddWardEmployee(new WardEmployee
            {
                WardId = "WRD-000008",
                EmployeeId = "PER-000038",
                DateAssigned = DateTime.Now
            });
            serv.AddWardEmployee(new WardEmployee
            {
                WardId = "WRD-000009",
                EmployeeId = "PER-000039",
                DateAssigned = DateTime.Now
            });
            serv.AddWardEmployee(new WardEmployee
            {
                WardId = "WRD-000010",
                EmployeeId = "PER-000040",
                DateAssigned = DateTime.Now
            });
        }
    }
}

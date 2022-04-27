using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using NUnit.Framework;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace Tests
{
    public class EmployeeSpecialtyTests
    {
        [Test]
        public void AddEmployeeSpecialtyTest()
        {
            var serv = new EmployeeSpecialtyService(new MVCHContext());
            serv.AddEmployeeSpecialty(new EmployeeSpecialty
            {
                EmployeeId = "PER-000031",
                SpecialtyId = "SPY-000001",
                DateAcquired = DateTime.Now
            });
            serv.AddEmployeeSpecialty(new EmployeeSpecialty
            {
                EmployeeId = "PER-000032",
                SpecialtyId = "SPY-000002",
                DateAcquired = DateTime.Now
            });
            serv.AddEmployeeSpecialty(new EmployeeSpecialty
            {
                EmployeeId = "PER-000033",
                SpecialtyId = "SPY-000003",
                DateAcquired = DateTime.Now
            });
            serv.AddEmployeeSpecialty(new EmployeeSpecialty
            {
                EmployeeId = "PER-000034",
                SpecialtyId = "SPY-000004",
                DateAcquired = DateTime.Now
            });
            serv.AddEmployeeSpecialty(new EmployeeSpecialty
            {
                EmployeeId = "PER-000035",
                SpecialtyId = "SPY-000005",
                DateAcquired = DateTime.Now
            });
            serv.AddEmployeeSpecialty(new EmployeeSpecialty
            {
                EmployeeId = "PER-000036",
                SpecialtyId = "SPY-000001",
                DateAcquired = DateTime.Now
            });
            serv.AddEmployeeSpecialty(new EmployeeSpecialty
            {
                EmployeeId = "PER-000037",
                SpecialtyId = "SPY-000002",
                DateAcquired = DateTime.Now
            });
            serv.AddEmployeeSpecialty(new EmployeeSpecialty
            {
                EmployeeId = "PER-000038",
                SpecialtyId = "SPY-000003",
                DateAcquired = DateTime.Now
            });
            serv.AddEmployeeSpecialty(new EmployeeSpecialty
            {
                EmployeeId = "PER-000039",
                SpecialtyId = "SPY-000004",
                DateAcquired = DateTime.Now
            });
            serv.AddEmployeeSpecialty(new EmployeeSpecialty
            {
                EmployeeId = "PER-000040",
                SpecialtyId = "SPY-000005",
                DateAcquired = DateTime.Now
            });

        }
    }
}

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
    public class PhysicianSpecialtyTests
    {
        [Test]
        public void AddPhysicianSpecialtyTest()
        {
            var serv = new PhysicianSpecialtyService(new MVCHContext());
            serv.AddPhysicianSpecialty(new PhysicianSpecialty
            {
                PhysicianId = "PER-000020",
                SpecialtyId = "SPY-000001",
                DateAcquired = DateTime.Now
            });
            serv.AddPhysicianSpecialty(new PhysicianSpecialty
            {
                PhysicianId = "PER-000019",
                SpecialtyId = "SPY-000002",
                DateAcquired = DateTime.Now
            });
            serv.AddPhysicianSpecialty(new PhysicianSpecialty
            {
                PhysicianId = "PER-000018",
                SpecialtyId = "SPY-000003",
                DateAcquired = DateTime.Now
            });
            serv.AddPhysicianSpecialty(new PhysicianSpecialty
            {
                PhysicianId = "PER-000017",
                SpecialtyId = "SPY-000004",
                DateAcquired = DateTime.Now
            });
            serv.AddPhysicianSpecialty(new PhysicianSpecialty
            {
                PhysicianId = "PER-000016",
                SpecialtyId = "SPY-000005",
                DateAcquired = DateTime.Now
            });
            serv.AddPhysicianSpecialty(new PhysicianSpecialty
            {
                PhysicianId = "PER-000015",
                SpecialtyId = "SPY-000001",
                DateAcquired = DateTime.Now
            });
            serv.AddPhysicianSpecialty(new PhysicianSpecialty
            {
                PhysicianId = "PER-000014",
                SpecialtyId = "SPY-000002",
                DateAcquired = DateTime.Now
            });
            serv.AddPhysicianSpecialty(new PhysicianSpecialty
            {
                PhysicianId = "PER-000013",
                SpecialtyId = "SPY-000003",
                DateAcquired = DateTime.Now
            });
            serv.AddPhysicianSpecialty(new PhysicianSpecialty
            {
                PhysicianId = "PER-000012",
                SpecialtyId = "SPY-000004",
                DateAcquired = DateTime.Now
            });
            serv.AddPhysicianSpecialty(new PhysicianSpecialty
            {
                PhysicianId = "PER-000011",
                SpecialtyId = "SPY-000005",
                DateAcquired = DateTime.Now
            });

        }
    }
}

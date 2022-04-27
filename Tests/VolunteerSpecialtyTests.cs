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
    public class VolunteerSpecialtyTests
    {
        [Test]
        public void AddVolunteerSpecialtyTest()
        {
            var serv = new VolunteerSpecialtyService(new MVCHContext());
            serv.AddVolunteerSpecialty(new VolunteerSpecialty
            {
                VolunteerId = "PER-000041",
                SpecialtyId = "SPY-000001",
                DateAcquired = DateTime.Now
            });
            serv.AddVolunteerSpecialty(new VolunteerSpecialty
            {
                VolunteerId = "PER-000042",
                SpecialtyId = "SPY-000002",
                DateAcquired = DateTime.Now
            });
            serv.AddVolunteerSpecialty(new VolunteerSpecialty
            {
                VolunteerId = "PER-000043",
                SpecialtyId = "SPY-000003",
                DateAcquired = DateTime.Now
            });
            serv.AddVolunteerSpecialty(new VolunteerSpecialty
            {
                VolunteerId = "PER-000044",
                SpecialtyId = "SPY-000004",
                DateAcquired = DateTime.Now
            });
            serv.AddVolunteerSpecialty(new VolunteerSpecialty
            {
                VolunteerId = "PER-000045",
                SpecialtyId = "SPY-000005",
                DateAcquired = DateTime.Now
            });
            serv.AddVolunteerSpecialty(new VolunteerSpecialty
            {
                VolunteerId = "PER-000046",
                SpecialtyId = "SPY-000001",
                DateAcquired = DateTime.Now
            });
            serv.AddVolunteerSpecialty(new VolunteerSpecialty
            {
                VolunteerId = "PER-000047",
                SpecialtyId = "SPY-000002",
                DateAcquired = DateTime.Now
            });
            serv.AddVolunteerSpecialty(new VolunteerSpecialty
            {
                VolunteerId = "PER-000048",
                SpecialtyId = "SPY-000003",
                DateAcquired = DateTime.Now
            });
            serv.AddVolunteerSpecialty(new VolunteerSpecialty
            {
                VolunteerId = "PER-000049",
                SpecialtyId = "SPY-000004",
                DateAcquired = DateTime.Now
            });
            serv.AddVolunteerSpecialty(new VolunteerSpecialty
            {
                VolunteerId = "PER-000050",
                SpecialtyId = "SPY-000005",
                DateAcquired = DateTime.Now
            });


        }
    }
}

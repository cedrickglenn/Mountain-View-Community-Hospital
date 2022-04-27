using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using NUnit.Framework;
using Servicelayer.BaseClassService;

namespace Tests
{
    public class FacilityTests
    {
        [Test]
        public void AddFacilityTest()
        {
            var serv = new FacilityService(new MVCHContext());
            serv.AddFacility(new Facility
            {
                Name = "MVCH Hospital Facility 1"
            });
            serv.AddFacility(new Facility
            {
                Name = "MVCH Hospital Facility 2"
            });
            serv.AddFacility(new Facility
            {
                Name = "MVCH Hospital Facility 3"
            });
            serv.AddFacility(new Facility
            {
                Name = "MVCH Hospital Facility 4"
            });
            serv.AddFacility(new Facility
            {
                Name = "MVCH Hospital Facility 5"
            });
            serv.AddFacility(new Facility
            {
                Name = "MVCH Hospital Facility 6"
            });
            serv.AddFacility(new Facility
            {
                Name = "MVCH Hospital Facility 7"
            });
            serv.AddFacility(new Facility
            {
                Name = "MVCH Hospital Facility 8"
            });
            serv.AddFacility(new Facility
            {
                Name = "MVCH Hospital Facility 9"
            });
            serv.AddFacility(new Facility
            {
                Name = "MVCH Hospital Facility 10"
            });

        }
    }
}

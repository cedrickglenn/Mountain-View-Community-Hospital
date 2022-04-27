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
    public class WardTests
    {
        [Test]
        public void AddWardTest()
        {
            var serv = new WardService(new MVCHContext());
            serv.AddWard(new Ward
            {
                Name = "Ward 1",
                FacilityId = "FAC-000001"
            });
            serv.AddWard(new Ward
            {
                Name = "Ward 2",
                FacilityId = "FAC-000001"
            });
            serv.AddWard(new Ward
            {
                Name = "Ward 1",
                FacilityId = "FAC-000002"
            });
            serv.AddWard(new Ward
            {
                Name = "Ward 1",
                FacilityId = "FAC-000003"
            });
            serv.AddWard(new Ward
            {
                Name = "Ward 1",
                FacilityId = "FAC-000004"
            });
            serv.AddWard(new Ward
            {
                Name = "Ward 1",
                FacilityId = "FAC-000005"
            });
            serv.AddWard(new Ward
            {
                Name = "Ward 1",
                FacilityId = "FAC-000006"
            });
            serv.AddWard(new Ward
            {
                Name = "Ward 1",
                FacilityId = "FAC-000007"
            });
            serv.AddWard(new Ward
            {
                Name = "Ward 1",
                FacilityId = "FAC-000008"
            });
            serv.AddWard(new Ward
            {
                Name = "Ward 1",
                FacilityId = "FAC-000009"
            });
            serv.AddWard(new Ward
            {
                Name = "Ward 1",
                FacilityId = "FAC-000010"
            });


        }
    }
}

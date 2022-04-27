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
    public class WorkUnitTests
    {
        [Test]
        public void AddWorkUnitTest()
        {
            var serv = new WorkUnitService(new MVCHContext());
            serv.AddWorkUnit(new WorkUnit
            {
                Name = "Intensive Care Unit",
                Floor = "2nd Floor",
                FacilityId = "FAC-000001"
            });
            serv.AddWorkUnit(new WorkUnit
            {
                Name = "Intensive Care Unit",
                Floor = "2nd Floor",
                FacilityId = "FAC-000002"
            });
            serv.AddWorkUnit(new WorkUnit
            {
                Name = "Intensive Care Unit",
                Floor = "2nd Floor",
                FacilityId = "FAC-000003"
            });
            serv.AddWorkUnit(new WorkUnit
            {
                Name = "Intensive Care Unit",
                Floor = "2nd Floor",
                FacilityId = "FAC-000004"
            });
            serv.AddWorkUnit(new WorkUnit
            {
                Name = "Intensive Care Unit",
                Floor = "2nd Floor",
                FacilityId = "FAC-000005"
            });
            serv.AddWorkUnit(new WorkUnit
            {
                Name = "Intensive Care Unit",
                Floor = "2nd Floor",
                FacilityId = "FAC-000006"
            });
            serv.AddWorkUnit(new WorkUnit
            {
                Name = "Intensive Care Unit",
                Floor = "2nd Floor",
                FacilityId = "FAC-000007"
            });
            serv.AddWorkUnit(new WorkUnit
            {
                Name = "Intensive Care Unit",
                Floor = "2nd Floor",
                FacilityId = "FAC-000008"
            });
            serv.AddWorkUnit(new WorkUnit
            {
                Name = "Intensive Care Unit",
                Floor = "2nd Floor",
                FacilityId = "FAC-000009"
            });
            serv.AddWorkUnit(new WorkUnit
            {
                Name = "Intensive Care Unit",
                Floor = "2nd Floor",
                FacilityId = "FAC-000010"
            });
            serv.AddWorkUnit(new WorkUnit
            {
                Name = "Cardiology",
                Floor = "3rd Floor",
                FacilityId = "FAC-000001"
            });

        }
    }
}

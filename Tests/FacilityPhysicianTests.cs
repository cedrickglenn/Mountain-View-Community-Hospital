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
    public class FacilityPhysicianTests
    {
        [Test]
        public void AddFacilityPhysicianTest()
        {
            var serv = new FacilityPhysicianService(new MVCHContext());
            serv.AddFacilityPhysician(new FacilityPhysician
            {
                PhysicianId = "PER-000020",
                FacilityId = "FAC-000001",
                DateAssigned = DateTime.Now
            });
            serv.AddFacilityPhysician(new FacilityPhysician
            {
                PhysicianId = "PER-000019",
                FacilityId = "FAC-000002",
                DateAssigned = DateTime.Now
            });
            serv.AddFacilityPhysician(new FacilityPhysician
            {
                PhysicianId = "PER-000018",
                FacilityId = "FAC-000003",
                DateAssigned = DateTime.Now
            });
            serv.AddFacilityPhysician(new FacilityPhysician
            {
                PhysicianId = "PER-000017",
                FacilityId = "FAC-000004",
                DateAssigned = DateTime.Now
            });
            serv.AddFacilityPhysician(new FacilityPhysician
            {
                PhysicianId = "PER-000016",
                FacilityId = "FAC-000005",
                DateAssigned = DateTime.Now
            });
            serv.AddFacilityPhysician(new FacilityPhysician
            {
                PhysicianId = "PER-000015",
                FacilityId = "FAC-000006",
                DateAssigned = DateTime.Now
            });
            serv.AddFacilityPhysician(new FacilityPhysician
            {
                PhysicianId = "PER-000014",
                FacilityId = "FAC-000007",
                DateAssigned = DateTime.Now
            });
            serv.AddFacilityPhysician(new FacilityPhysician
            {
                PhysicianId = "PER-000013",
                FacilityId = "FAC-000008",
                DateAssigned = DateTime.Now
            });
            serv.AddFacilityPhysician(new FacilityPhysician
            {
                PhysicianId = "PER-000012",
                FacilityId = "FAC-000009",
                DateAssigned = DateTime.Now
            });
            serv.AddFacilityPhysician(new FacilityPhysician
            {
                PhysicianId = "PER-000011",
                FacilityId = "FAC-000010",
                DateAssigned = DateTime.Now
            });

        }
    }
}

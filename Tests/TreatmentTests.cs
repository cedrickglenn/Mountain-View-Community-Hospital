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
    public class TreatmentTests
    {
        [Test]
        public void AddTreatmentTest()
        {
            var serv = new TreatmentService(new MVCHContext());
            serv.AddTreatment(new Treatment
            {
                Description = "Patient exhibits some side effects from the treatment",
                DateTime = DateTime.Now,
                ProcedureId = "00.01",
                PatientId = "PER-000021",
                PhysicianId = "PER-000020"
            });
            serv.AddTreatment(new Treatment   
            {
                Description = "Heart functions as normal",
                DateTime = DateTime.Now,
                ProcedureId = "00.02",
                PatientId = "PER-000022",
                PhysicianId = "PER-000019"
            });
            serv.AddTreatment(new Treatment
            {
                Description = "Treatment successful",
                DateTime = DateTime.Now,
                ProcedureId = "00.03",
                PatientId = "PER-000023",
                PhysicianId = "PER-000018"
            });
            serv.AddTreatment(new Treatment
            {
                Description = "Patient exhibits some side effects after the treatment",
                DateTime = DateTime.Now,
                ProcedureId = "00.09",
                PatientId = "PER-000024",
                PhysicianId = "PER-000017"
            });
            serv.AddTreatment(new Treatment
            {
                Description = "Patient need to be confined for observation",
                DateTime = DateTime.Now,
                ProcedureId = "00.91",
                PatientId = "PER-000025",
                PhysicianId = "PER-000016"
            });
        }
    }
}

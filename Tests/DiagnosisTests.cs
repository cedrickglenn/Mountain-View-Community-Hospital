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
    public class DiagnosisTests
    {
        [Test]
        public void AddDiagnosisTest()
        {
            var serv = new DiagnosisService(new MVCHContext());
            serv.AddDiagnosis(new Diagnosis
            {
                Description = "Severe case",
                DateTime = DateTime.Now,
                ConditionId = "001.0",
                PatientId = "PER-000021",
                PhysicianId = "PER-000020"
            });
            serv.AddDiagnosis(new Diagnosis
            {
                Description = "Mild fever",
                DateTime = DateTime.Now,
                ConditionId = "002.0",
                PatientId = "PER-000022",
                PhysicianId = "PER-000019"
            });
            serv.AddDiagnosis(new Diagnosis
            {
                Description = "Masakit ang tiyan",
                DateTime = DateTime.Now,
                ConditionId = "003.0",
                PatientId = "PER-000023",
                PhysicianId = "PER-000018"
            });
            serv.AddDiagnosis(new Diagnosis
            {
                Description = "Moderate case",
                DateTime = DateTime.Now,
                ConditionId = "001.1",
                PatientId = "PER-000024",
                PhysicianId = "PER-000017"
            });
            serv.AddDiagnosis(new Diagnosis
            {
                Description = "Severe case",
                DateTime = DateTime.Now,
                ConditionId = "001.9",
                PatientId = "PER-000025",
                PhysicianId = "PER-000016"
            });
        }
    }
}

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
    public class VitalRecordTests
    {
        [Test]
        public void AddVitalRecordTest()
        {
            var serv = new VitalRecordService(new MVCHContext());
            serv.AddVitalRecord(new VitalRecord
            {
                Value = "5 feet 9 inches",
                DateTime = DateTime.Now,
                VitalId = "VTL-000001",
                PatientId = "PER-000021",
                NurseId = "PER-000031"
            });
            serv.AddVitalRecord(new VitalRecord
            {
                Value = "76 kg",
                DateTime = DateTime.Now,
                VitalId = "VTL-000002",
                PatientId = "PER-000021",
                NurseId = "PER-000031"
            });
            serv.AddVitalRecord(new VitalRecord
            {
                Value = "120/80",
                DateTime = DateTime.Now,
                VitalId = "VTL-000003",
                PatientId = "PER-000021",
                NurseId = "PER-000031"
            });
            serv.AddVitalRecord(new VitalRecord
            {
                Value = "120 bpm",
                DateTime = DateTime.Now,
                VitalId = "VTL-000004",
                PatientId = "PER-000021",
                NurseId = "PER-000031"
            });
            serv.AddVitalRecord(new VitalRecord
            {
                Value = "36.2 C",
                DateTime = DateTime.Now,
                VitalId = "VTL-000005",
                PatientId = "PER-000021",
                NurseId = "PER-000031"
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;
using NUnit.Framework;
using Servicelayer.BaseClassService;

namespace Tests
{
    public class PatientOrderTests
    {
        [Test]
        public void AddPatientOrderTest()
        {
            var serv = new PatientOrderService(new MVCHContext());
            serv.AddPatientOrder(new PatientOrder
            {
                DateTime = DateTime.Now,
                PatientId = "PER-000021"

            });
            serv.AddPatientOrder(new PatientOrder
            {
                DateTime = DateTime.Now,
                PatientId = "PER-000022"
            });
            serv.AddPatientOrder(new PatientOrder
            {
                DateTime = DateTime.Now,
                PatientId = "PER-000023"
            });
            serv.AddPatientOrder(new PatientOrder
            {
                DateTime = DateTime.Now,
                PatientId = "PER-000024"
            });
            serv.AddPatientOrder(new PatientOrder
            {
                DateTime = DateTime.Now,
                PatientId = "PER-000025"
            });
        }
    }
}

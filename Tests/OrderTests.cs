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
    public class OrderTests
    {
        [Test]
        public void AddOrderTest()
        {
            var serv = new OrderServiceLayer(new MVCHContext());
            serv.AddOrder(new Order
            {
                DateTime = DateTime.Now,
                Instructions = "Exercise care in administering x-ray.",
                PatientId = "PER-000021",
                PhysicianId = "PER-000011",
            });
            serv.AddOrder(new Order
            {
                DateTime = DateTime.Now,
                Instructions = "Exercise care in administering x-ray.",
                PatientId = "PER-000022",
                PhysicianId = "PER-000012",
            });
            serv.AddOrder(new Order
            {
                DateTime = DateTime.Now,
                Instructions = "Exercise care in administering x-ray.",
                PatientId = "PER-000023",
                PhysicianId = "PER-000013",
            });
            serv.AddOrder(new Order
            {
                DateTime = DateTime.Now,
                Instructions = "Exercise care in administering x-ray.",
                PatientId = "PER-000024",
                PhysicianId = "PER-000014",
            });
            serv.AddOrder(new Order
            {
                DateTime = DateTime.Now,
                Instructions = "Exercise care in administering x-ray.",
                PatientId = "PER-000025",
                PhysicianId = "PER-000015",
            });
            


        }
    }
}

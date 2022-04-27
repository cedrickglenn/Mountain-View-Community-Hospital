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
    public class VisitTests
    {
        [Test]
        public void AddVisitTest()
        {
            var serv = new VisitService(new MVCHContext());
            serv.AddVisit(new Visit
            {
                DateTime = DateTime.Now.AddDays(2),
                OutpatientId = "PER-000026"
            });
            serv.AddVisit(new Visit
            {
                DateTime = DateTime.Now.AddDays(2),
                OutpatientId = "PER-000027"
            });
            serv.AddVisit(new Visit
            {
                DateTime = DateTime.Now.AddDays(2),
                OutpatientId = "PER-000028"
            });
            serv.AddVisit(new Visit
            {
                DateTime = DateTime.Now.AddDays(2),
                OutpatientId = "PER-000029"
            });
            serv.AddVisit(new Visit
            {
                DateTime = DateTime.Now.AddDays(2),
                OutpatientId = "PER-000030"
            });
            serv.AddVisit(new Visit
            {
                DateTime = DateTime.Now,
                OutpatientId = "PER-000027"
            });
            serv.AddVisit(new Visit
            {
                DateTime = DateTime.Now,
                OutpatientId = "PER-000028"
            });
            serv.AddVisit(new Visit
            {
                DateTime = DateTime.Now,
                OutpatientId = "PER-000029"
            });
            serv.AddVisit(new Visit
            {
                DateTime = DateTime.Now,
                OutpatientId = "PER-000030"
            });

        }
    }
}

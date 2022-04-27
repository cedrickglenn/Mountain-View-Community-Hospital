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
    public class ServiceTests
    {
        [Test]
        public void AddServiceTest()
        {
            var serv = new ServiceService(new MVCHContext());
            serv.AddService(new Service
            {
                Name = "X-Ray"
            });
            serv.AddService(new Service
            {
                Name = "CT Scan"
            });
            serv.AddService(new Service
            {
                Name = "Dialysis"
            });
            serv.AddService(new Service
            {
                Name = "Complete Blood Count"
            });
            serv.AddService(new Service
            {
                Name = "Urinalysis"
            });
            serv.AddService(new Service
            {
                Name = "Fecalysis"
            });
            serv.AddService(new Service
            {
                Name = "Euthanasia"
            });

        }
    }
}

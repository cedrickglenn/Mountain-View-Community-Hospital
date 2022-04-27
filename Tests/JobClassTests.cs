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
    public class JobClassTests
    {
        [Test]
        public void AddJobClassTest()
        {
            var serv = new JobClassService(new MVCHContext());
            serv.AddJobClass(new JobClass
            {
                Name = "Secretary"
            }); 
            serv.AddJobClass(new JobClass
            {
                Name = "Administrative Assistant"
            });
            serv.AddJobClass(new JobClass
            {
                Name = "Admitting Specialist"
            });
            serv.AddJobClass(new JobClass
            {
                Name = "Collection Specialist"
            });
            serv.AddJobClass(new JobClass
            {
                Name = "Cashier"
            });
            serv.AddJobClass(new JobClass
            {
                Name = "Manager"
            });
            serv.AddJobClass(new JobClass
            {
                Name = "Logistics Specialist"
            });




        }
    }
}

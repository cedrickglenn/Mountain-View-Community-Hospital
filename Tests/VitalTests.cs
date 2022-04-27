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
    public class VitalTests
    {
        [Test]
        public void AddVitalTest()
        {
            var serv = new VitalService(new MVCHContext());
            serv.AddVital(new Vital
            {
                Description = "Height"
            });
            serv.AddVital(new Vital
            {
                Description = "Weight"
            });
            serv.AddVital(new Vital
            {
                Description = "Blood Pressure"
            });

            serv.AddVital(new Vital
            {
                Description = "Pulse"
            });
            serv.AddVital(new Vital
            {
                Description = "Temperature"
            });


        }
    }
}

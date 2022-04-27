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
    public class VendorTests
    {
        [Test]
        public void AddVendorTest()
        {
            var serv = new VendorService(new MVCHContext());
            serv.AddVendor(new Vendor
            {
                Name = "Indoplas Philippines"
            });
            serv.AddVendor(new Vendor
            {
                Name = "Destiny Care Diagnostics Supplies"
            });
            serv.AddVendor(new Vendor
            {
                Name = "Medical Supplies Depot"
            });
            serv.AddVendor(new Vendor
            {
                Name = "Zenith Medical Equipment Inc."
            });
            serv.AddVendor(new Vendor
            {
                Name = "Taiwan Trade Inc."
            });


        }
    }
}

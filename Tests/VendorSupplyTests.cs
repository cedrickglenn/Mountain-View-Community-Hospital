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
    public class VendorSupplyTests
    {
        [Test]
        public void AddVendorSupplyTest()
        {
            var serv = new VendorSupplyService(new MVCHContext());
            serv.AddVendorSupply(new VendorSupply
            {
                VendorId = "VEN-000001",
                ItemId = "ITM-000001",
                Quantity = 50
            });
            serv.AddVendorSupply(new VendorSupply
            {
                VendorId = "VEN-000002",
                ItemId = "ITM-000002",
                Quantity = 40
            });
            serv.AddVendorSupply(new VendorSupply
            {
                VendorId = "VEN-000003",
                ItemId = "ITM-000003",
                Quantity = 30
            });
            serv.AddVendorSupply(new VendorSupply
            {
                VendorId = "VEN-000004",
                ItemId = "ITM-000004",
                Quantity = 20
            });
            serv.AddVendorSupply(new VendorSupply
            {
                VendorId = "VEN-000005",
                ItemId = "ITM-000005",
                Quantity = 10
            });

        }
    }
}

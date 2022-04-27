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
    public class ItemTests
    {
        [Test]
        public void AddItemTest()
        {
            var serv = new ItemService(new MVCHContext());
            serv.AddItem(new Item
            {
                Name = "Hospital Stretcher",
                Description = "For easy transport of patients during emergencies",
                UnitCost = 5000
            });
            serv.AddItem(new Item
            {
                Name = "Defibrillator",
                Description = "Restores a normal heartbeat through electric pulse or shock to the heart",
                UnitCost = 125000
            });
            serv.AddItem(new Item
            {
                Name = "Anesthesia Machine",
                Description = "For the purpose of inducing and maintaining anesthesia",
                UnitCost = 500000
            }); 
            serv.AddItem(new Item
            {
                Name = "Wheelchair",
                Description = "For easy transport of leg-impaired persons",
                UnitCost = 12500
            });
            serv.AddItem(new Item
            {
                Name = "Sterilized Blanket",
                Description = "Warms and comforts patients",
                UnitCost = 5000
            });

        }
    }
}

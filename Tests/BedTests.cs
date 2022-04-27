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
    public class BedTests
    {
        [Test]
        public void AddBedTest()
        {
            var serv = new BedService(new MVCHContext());
            serv.AddBed(new Bed
            {
                RoomNumber = "1",
                WorkUnitId = "WKS-000001"
            });
            serv.AddBed(new Bed
            {
                RoomNumber = "2",
                WorkUnitId = "WKS-000001"
            });
            serv.AddBed(new Bed
            {
                RoomNumber = "1",
                WorkUnitId = "WKS-000002"
            });
            serv.AddBed(new Bed
            {
                RoomNumber = "1",
                WorkUnitId = "WKS-000003"
            });
            serv.AddBed(new Bed
            {
                RoomNumber = "1",
                WorkUnitId = "WKS-000004"
            });
            serv.AddBed(new Bed
            {
                RoomNumber = "1",
                WorkUnitId = "WKS-000005"
            });
            serv.AddBed(new Bed
            {
                RoomNumber = "1",
                WorkUnitId = "WKS-000006"
            });
            serv.AddBed(new Bed
            {
                RoomNumber = "1",
                WorkUnitId = "WKS-000007"
            });
            serv.AddBed(new Bed
            {
                RoomNumber = "1",
                WorkUnitId = "WKS-000008"
            });
            serv.AddBed(new Bed
            {
                RoomNumber = "1",
                WorkUnitId = "WKS-000009"
            });
            serv.AddBed(new Bed
            {
                RoomNumber = "1",
                WorkUnitId = "WKS-000010"
            });

        }
    }
}

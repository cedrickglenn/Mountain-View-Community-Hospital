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
    public class OrderServiceTests
    {
        [Test]
        public void AddOrderServiceTest()
        {
            var serv = new OrderServiceService(new MVCHContext());
            serv.AddOrderService(new OrderService
            {
               OrderId = "ORD-000001",
               ServiceId = "SVC-000001",
               Quantity = 1
            });
            serv.AddOrderService(new OrderService
            {
                OrderId = "ORD-000002",
                ServiceId = "SVC-000002",
                Quantity = 1
            });
            serv.AddOrderService(new OrderService
            {
                OrderId = "ORD-000003",
                ServiceId = "SVC-000003",
                Quantity = 1
            });
            serv.AddOrderService(new OrderService
            {
                OrderId = "ORD-000004",
                ServiceId = "SVC-000004",
                Quantity = 1
            });
            serv.AddOrderService(new OrderService
            {
                OrderId = "ORD-000005",
                ServiceId = "SVC-000005",
                Quantity = 1
            });
            serv.AddOrderService(new OrderService
            {
                OrderId = "ORD-000001",
                ServiceId = "SVC-000001",
                Quantity = 1
            });
            serv.AddOrderService(new OrderService
            {
                OrderId = "ORD-000001",
                ServiceId = "SVC-000001",
                Quantity = 1
            });


        }
    }
}

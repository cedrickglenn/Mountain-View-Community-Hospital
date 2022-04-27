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
    public class OrderItemTests
    {
        [Test]
        public void AddOrderItemTest()
        {
            var serv = new OrderItemService(new MVCHContext());
            serv.AddOrderItem(new OrderItem
            {
                PatientOrderId = "POR-000001",
                ItemId = "ITM-000001",
                DateTime = DateTime.Now,
                Subtotal = 99999,
                Quantity = 50
            }); 
            serv.AddOrderItem(new OrderItem
            {
                PatientOrderId = "POR-000002",
                ItemId = "ITM-000002",
                DateTime = DateTime.Now,
                Subtotal = 99999,
                Quantity = 40
            });
            serv.AddOrderItem(new OrderItem
            {
                PatientOrderId = "POR-000003",
                ItemId = "ITM-000003",
                DateTime = DateTime.Now,
                Subtotal = 99999,
                Quantity = 30
            });
            serv.AddOrderItem(new OrderItem
            {
                PatientOrderId = "POR-000004",
                ItemId = "ITM-000004",
                DateTime = DateTime.Now,
                Subtotal = 99999,
                Quantity = 20
            });
            serv.AddOrderItem(new OrderItem
            {
                PatientOrderId = "POR-000005",
                ItemId = "ITM-000005",
                DateTime = DateTime.Now,
                Subtotal = 99999,
                Quantity = 10
            });


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class PatientOrder
    {
        private decimal _totalCost;
        public string PatientOrderId { get; set; }

        public decimal TotalCost
        {
            get
            {
                _totalCost = CalculateTotalCost();
                return _totalCost;
            }
            set => _totalCost = value;
        }
        
        private decimal CalculateTotalCost()
        {
            return OrderItems.Sum(c => c.Subtotal);
        }

        public DateTime DateTime { get; set; }
        public Patient PatientLink { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public string PatientId { get; set; }

      

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;
using Microsoft.EntityFrameworkCore;

namespace Servicelayer.BaseClassService
{
    public class PatientOrderService
    {
        private MVCHContext _context;

        public PatientOrderService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<PatientOrder> GetPatientOrders()
        {
            return _context.PatientOrders
                .Include(c=>c.OrderItems);
        }

        public void AddPatientOrder(PatientOrder patientOrder)
        {
            _context.PatientOrders.Add(patientOrder);
            _context.SaveChanges();
        }

        public void UpdatePatientOrder(PatientOrder patientOrder)
        {
            _context.PatientOrders.Update(patientOrder);
            _context.SaveChanges();
        }
    }
}

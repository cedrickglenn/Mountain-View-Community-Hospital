using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using Microsoft.EntityFrameworkCore;

namespace Servicelayer.AssociativeClassService
{
    public class TreatmentService
    {
        private MVCHContext _context;

        public TreatmentService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Treatment> GetTreatments()
        {
            return _context.Treatments
                .Include(c=>c.PatientLink)
                .Include(c=>c.PhysicianLink)
                .Include(c=>c.ProcedureLink);
        }

        public void AddTreatment(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
            _context.SaveChanges();
        }

        public void UpdateTreatment(Treatment treatment)
        {
            _context.Treatments.Update(treatment);
            _context.SaveChanges();
        }
    }
}

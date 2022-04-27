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
    public class DiagnosisService
    {
        private MVCHContext _context;

        public DiagnosisService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Diagnosis> GetDiagnoses()
        {
            return _context.Diagnoses
                .Include(c=>c.ConditionLink)
                .Include(c=>c.PhysicianLink)
                .Include(c=>c.PatientLink);
        }

        public void AddDiagnosis(Diagnosis diagnosis)
        {
            _context.Diagnoses.Add(diagnosis);
            _context.SaveChanges();
        }

        public void UpdateDiagnosis(Diagnosis diagnosis)
        {
            _context.Diagnoses.Update(diagnosis);
            _context.SaveChanges();
        }
    }
}

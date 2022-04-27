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
    public class VitalRecordService
    {
        private MVCHContext _context;

        public VitalRecordService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<VitalRecord> GetVitalRecords()
        {
            return _context.VitalRecords
                .Include(c=>c.PatientLink)
                .Include(c=>c.NurseLink)
                .Include(c=>c.VitalLink);
        }

        public void AddVitalRecord(VitalRecord vitalRecord)
        {
            _context.VitalRecords.Add(vitalRecord);
            _context.SaveChanges();
        }

        public void UpdateVitalRecord(VitalRecord vitalRecord)
        {
            _context.VitalRecords.Update(vitalRecord);
            _context.SaveChanges();
        }
    }
}

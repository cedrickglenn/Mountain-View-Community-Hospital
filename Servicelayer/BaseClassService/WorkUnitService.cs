using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.BaseClassService
{
    public class WorkUnitService
    {
        private MVCHContext _context;

        public WorkUnitService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<WorkUnit> GetWorkUnits()
        {
            return _context.WorkUnits;
        }

        public void AddWorkUnit(WorkUnit workUnit)
        {
            _context.WorkUnits.Add(workUnit);
            _context.SaveChanges();
        }

        public void UpdateWorkUnit(WorkUnit workUnit)
        {
            _context.WorkUnits.Update(workUnit);
            _context.SaveChanges();
        }
    }
}

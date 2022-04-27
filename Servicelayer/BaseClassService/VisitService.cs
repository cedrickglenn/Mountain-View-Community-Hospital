using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.BaseClassService
{
    public class VisitService
    {
        private MVCHContext _context;

        public VisitService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Visit> GetVisits()
        {
            return _context.Visits;
        }

        public void AddVisit(Visit visit)
        {
            _context.Visits.Add(visit);
            _context.SaveChanges();
        }

        public void UpdateVisit(Visit visit)
        {
            _context.Visits.Update(visit);
            _context.SaveChanges();
        }
    }
}

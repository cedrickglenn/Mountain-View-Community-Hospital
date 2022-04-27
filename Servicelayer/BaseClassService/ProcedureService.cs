using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.BaseClassService
{
    public class ProcedureService
    {
        private MVCHContext _context;

        public ProcedureService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Procedure> GetProcedures()
        {
            return _context.Procedures;
        }

        public void AddProcedure(Procedure procedure)
        {
            _context.Procedures.Add(procedure);
            _context.SaveChanges();
        }

        public void UpdateProcedure(Procedure procedure)
        {
            _context.Procedures.Update(procedure);
            _context.SaveChanges();
        }
    }
}

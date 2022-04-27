using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.BaseClassService
{
    public class ConditionService
    {
        private MVCHContext _context;

        public ConditionService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Condition> GetConditions()
        {
            return _context.Conditions;
        }

        public void AddCondition(Condition condition)
        {
            _context.Conditions.Add(condition);
            _context.SaveChanges();
        }

        public void UpdateCondition(Condition condition)
        {
            _context.Conditions.Update(condition);
            _context.SaveChanges();
        }
    }
}

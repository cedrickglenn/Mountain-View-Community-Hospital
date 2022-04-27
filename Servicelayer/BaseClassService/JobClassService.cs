using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;

namespace Servicelayer.BaseClassService
{
    public class JobClassService
    {
        private MVCHContext _context;

        public JobClassService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<JobClass> GetJobClasses()
        {
            return _context.JobClasses;
        }

        public void AddJobClass(JobClass jobClass)
        {
            _context.JobClasses.Add(jobClass);
            _context.SaveChanges();
        }

        public void UpdateJobClass(JobClass jobClass)
        {
            _context.JobClasses.Update(jobClass);
            _context.SaveChanges();
        }
    }
}

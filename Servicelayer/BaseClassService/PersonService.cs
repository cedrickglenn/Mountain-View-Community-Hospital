using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using Microsoft.EntityFrameworkCore;

namespace Servicelayer.BaseClassService
{
    public class PersonService
    {
        private MVCHContext _context;

        public PersonService(MVCHContext context)
        {
            _context = context;
        }

        public IQueryable<Person> GetPersons()
        {
            return _context.Persons;
        }

        public void AddPerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
        }
    }
}

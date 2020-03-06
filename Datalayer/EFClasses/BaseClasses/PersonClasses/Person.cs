using System;
using System.Collections.Generic;

namespace Datalayer.EFClasses.BaseClasses.PersonClasses
{
    public class Person
    {
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public char PersonType { get; set; }


        public ICollection<Patient> Patients { get; set; }
        public ICollection<Volunteer> Volunteers { get; set; }
    }
}

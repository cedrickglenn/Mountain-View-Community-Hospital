using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalayer.EFClasses.BaseClasses.PersonClasses
{
    public class Person
    {
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string FullName => $"{FirstName} {MiddleInitial} {LastName}";
        public string FullAddressWithZip => $"{Address}, {City}, {State}, {Zip}";
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Discriminator { get; set; }


        public ICollection<Patient>? PatientContacts { get; set; }
        public ICollection<Patient>? Dependents { get; set; }
        public ICollection<Volunteer>? Volunteers { get; set; }
    }
}

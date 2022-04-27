using System;
using System.Collections.Generic;

namespace Datalayer.EFClasses.BaseClasses.PersonClasses
{
    public class Outpatient : Patient
    {
        public DateTime VisitDate { get; set; }

        public ICollection<Visit>? Visits { get; set; }
        public Outpatient CreateCopy(Outpatient itemToCopy)
        {
            var outpatient = new Outpatient
            {
                PersonId = itemToCopy.PersonId,
                Discriminator = itemToCopy.Discriminator,
                FirstName =  itemToCopy.FirstName,
                MiddleInitial = itemToCopy.MiddleInitial,
                LastName = itemToCopy.LastName,   
                Address =  itemToCopy.Address,
                City = itemToCopy.City,
                State = itemToCopy.State,
                Zip = itemToCopy.Zip,
                BirthDate = itemToCopy.BirthDate,
                Email = itemToCopy.Email,
                PhoneNumber = itemToCopy.PhoneNumber,
                ContactPersonId = itemToCopy.ContactPersonId,
                ContactRelationship = itemToCopy.ContactRelationship,
                SubscriberPersonId = itemToCopy.SubscriberPersonId,
                SubscriberRelationship = itemToCopy.SubscriberRelationship,
                DateOfContact = itemToCopy.DateOfContact,
                MedicalRecordNumber =  itemToCopy.MedicalRecordNumber,
                InsuranceCompanyName = itemToCopy.InsuranceCompanyName,
                GroupNumber = itemToCopy.GroupNumber,
                PolicyNumber = itemToCopy.PolicyNumber,
                InsurancePhoneNumber = itemToCopy.InsurancePhoneNumber,
                Visits = itemToCopy.Visits
            };
            return outpatient;
        }
    }
}

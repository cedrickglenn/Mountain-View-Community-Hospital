using System;

namespace Datalayer.EFClasses.BaseClasses.PersonClasses
{
    public class Inpatient : Patient
    {
        public DateTime DateAdmitted { get; set; }
        public DateTime? DischargeDate { get; set; }

        public Bed BedLink { get; set; }
        public Ward WardLink { get; set; }
        public string? BedId { get; set; }
        public string WardId { get; set; }

        public Inpatient CreateCopy(Inpatient itemToCopy)
        {
            var inpatient = new Inpatient
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
                DateAdmitted = itemToCopy.DateAdmitted,
                DischargeDate = itemToCopy.DischargeDate,
                BedId = itemToCopy.BedId,
                WardId = itemToCopy.WardId
            };
            return inpatient;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using Microsoft.EntityFrameworkCore;

namespace Servicelayer.BaseClassService
{
    public class PatientService
    {
        private MVCHContext _context;

        public PatientService(MVCHContext context)
        {
            _context = context;
        }
        
        public IQueryable<Patient> GetPatients()
        {
            return _context.Patients.Include(c => c.ContactPersonLink)
                .Include(c=>c.SubscriberPersonLink);
        }

        public IQueryable<Inpatient> GetInpatients()
        {
            return _context.Inpatients.Include(c => c.ContactPersonLink)
                .Include(c=>c.SubscriberPersonLink)
                .Include(c=>c.WardLink)
                .Include(c=>c.BedLink);
        }
        public IQueryable<Outpatient> GetOutpatients()
        {
            return _context.Outpatients.Include(c => c.ContactPersonLink)
                .Include(c => c.SubscriberPersonLink);
        }
        public void AddInpatient(Inpatient patient)
        {
            _context.Inpatients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdateInpatient(Inpatient patientToUpdate)
        {
            var inpatient = _context.Inpatients.Find(patientToUpdate.PersonId);
            inpatient.FirstName = patientToUpdate.FirstName;
            inpatient.MiddleInitial = patientToUpdate.MiddleInitial;
            inpatient.LastName = patientToUpdate.LastName;
            inpatient.Address = patientToUpdate.Address;
            inpatient.City = patientToUpdate.City;
            inpatient.State = patientToUpdate.State;
            inpatient.Zip = patientToUpdate.Zip;
            inpatient.Email = patientToUpdate.Email;
            inpatient.PhoneNumber = patientToUpdate.PhoneNumber;
            inpatient.BirthDate = patientToUpdate.BirthDate;
            inpatient.MedicalRecordNumber = patientToUpdate.MedicalRecordNumber;
            inpatient.ContactPersonId = patientToUpdate.ContactPersonId;
            inpatient.ContactRelationship = patientToUpdate.ContactRelationship;
            inpatient.SubscriberPersonId = patientToUpdate.SubscriberPersonId;
            inpatient.SubscriberRelationship = patientToUpdate.SubscriberRelationship;
            inpatient.DateOfContact = patientToUpdate.DateOfContact;
            inpatient.InsuranceCompanyName = patientToUpdate.InsuranceCompanyName;
            inpatient.InsurancePhoneNumber = patientToUpdate.InsurancePhoneNumber;
            inpatient.PolicyNumber = patientToUpdate.PolicyNumber;
            inpatient.GroupNumber = patientToUpdate.GroupNumber;
            inpatient.BedId = patientToUpdate.BedId;
            inpatient.DateAdmitted = patientToUpdate.DateAdmitted;
            inpatient.DischargeDate = patientToUpdate.DischargeDate;
            inpatient.WardId = patientToUpdate.WardId;
            _context.SaveChanges();

        }
        public void AddOutpatient(Outpatient patient)
        {
            _context.Outpatients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdateOutpatient(Outpatient patientToUpdate)
        {
            var outpatient = _context.Outpatients.Find(patientToUpdate.PersonId);
            outpatient.FirstName = patientToUpdate.FirstName;
            outpatient.MiddleInitial = patientToUpdate.MiddleInitial;
            outpatient.LastName = patientToUpdate.LastName;
            outpatient.Address = patientToUpdate.Address;
            outpatient.City = patientToUpdate.City;
            outpatient.State = patientToUpdate.State;
            outpatient.Zip = patientToUpdate.Zip;
            outpatient.Email = patientToUpdate.Email;
            outpatient.PhoneNumber = patientToUpdate.PhoneNumber;
            outpatient.BirthDate = patientToUpdate.BirthDate;
            outpatient.MedicalRecordNumber = patientToUpdate.MedicalRecordNumber;
            outpatient.ContactPersonId = patientToUpdate.ContactPersonId;
            outpatient.ContactRelationship = patientToUpdate.ContactRelationship;
            outpatient.SubscriberPersonId = patientToUpdate.SubscriberPersonId;
            outpatient.SubscriberRelationship = patientToUpdate.SubscriberRelationship;
            outpatient.DateOfContact = patientToUpdate.DateOfContact;
            outpatient.InsuranceCompanyName = patientToUpdate.InsuranceCompanyName;
            outpatient.InsurancePhoneNumber = patientToUpdate.InsurancePhoneNumber;
            outpatient.PolicyNumber = patientToUpdate.PolicyNumber;
            outpatient.GroupNumber = patientToUpdate.GroupNumber;
            _context.SaveChanges();

        }
    }
}

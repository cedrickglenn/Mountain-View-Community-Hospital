using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using NUnit.Framework;
using Servicelayer.BaseClassService;

namespace Tests
{
    public class PatientTests
    {
        [Test]
        public void AddPatientTests()
        {
            var serv = new PatientService(new MVCHContext());
            serv.AddInpatient(new Inpatient
            {
                FirstName = "Cedrick",
                LastName = "Sederiosa",
                MiddleInitial = "S.",
                Address = "3212 Kahel St., Sto. Domingo II, Pampanga",
                City = "Davao City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "cedrickglenn@gmail.com",
                PhoneNumber = "+639495940509",
                Zip = "8000",
                DateOfContact = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                ContactPersonId = "PER-000001",
                ContactRelationship = "Brother",
                InsurancePhoneNumber = "+639495940509",
                InsuranceCompanyName = "AH OY",
                MedicalRecordNumber = "123123123123213",
                PolicyNumber = "123",
                GroupNumber =  "123213",
                DateAdmitted = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                WardId = "WRD-000001",
                BedId = "BED-000001"

            });
            serv.AddInpatient(new Inpatient
            {
                FirstName = "John",
                LastName = "Branzuela",
                MiddleInitial = "C.",
                Address = "Sasa Dose",
                City = "Davao City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("10/04/1999", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "jb@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                DateOfContact = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                ContactPersonId = "PER-000001",
                ContactRelationship = "Brother",
                InsurancePhoneNumber = "+639495940509",
                InsuranceCompanyName = "AH OY",
                MedicalRecordNumber = "123123123123213",
                PolicyNumber = "123",
                GroupNumber = "123213",
                WardId = "WRD-000001",
                BedId = "BED-000002"
            });
            serv.AddInpatient(new Inpatient
            {
                FirstName = "Nathan",
                LastName = "Naanep",
                MiddleInitial = "G.",
                Address = "Ilonggo",
                City = "Koronadal City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("03/25/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "ahyahwa@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                DateOfContact = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                ContactPersonId = "PER-000001",
                ContactRelationship = "Brother",
                InsurancePhoneNumber = "+639495940509",
                InsuranceCompanyName = "AH OY",
                MedicalRecordNumber = "123123123123213",
                PolicyNumber = "123",
                GroupNumber = "123213",
                WardId = "WRD-000002",
                BedId = "BED-000001"
            });
            serv.AddInpatient(new Inpatient
            {
                    FirstName = "Mecca",
                    LastName = "Umapas",
                    MiddleInitial = "S.",
                    Address = "Surigao",
                    City = "Surigao",
                    State = "Philippines",
                    BirthDate = DateTime.ParseExact("10/30/1999", "mm/dd/yyyy", new CultureInfo("en-PH")),
                    Email = "iwanttodestroykonoha@gmail.com",
                    PhoneNumber = "+63969696969",
                    Zip = "8000",
                    DateOfContact = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                    ContactPersonId = "PER-000001",
                    ContactRelationship = "Brother",
                    InsurancePhoneNumber = "+639495940509",
                    InsuranceCompanyName = "AH OY",
                    MedicalRecordNumber = "123123123123213",
                    PolicyNumber = "123",
                    GroupNumber = "123213",
                    WardId = "WRD-000003",
                    BedId = "BED-000001"
            });
            serv.AddInpatient(new Inpatient
            {
                FirstName = "Yoshi",
                LastName = "Aizawa",
                MiddleInitial = "M.",
                Address = "Mintal",
                City = "Davao City",
                State = "Japan",
                BirthDate = DateTime.ParseExact("12/13/1999", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "ilovezan@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                DateOfContact = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                ContactPersonId = "PER-000001",
                ContactRelationship = "Brother",
                InsurancePhoneNumber = "+639495940509",
                InsuranceCompanyName = "AH OY",
                MedicalRecordNumber = "123123123123213",
                PolicyNumber = "123",
                GroupNumber = "123213",
                WardId = "WRD-000001",
                BedId = "BED-000003"
            });
            serv.AddOutpatient(new Outpatient()
            {
                FirstName = "Adrian",
                LastName = "De Guzman",
                MiddleInitial = "A.",
                Address = "Ilonggo",
                City = "Tacurong City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("06/08/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "aids@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                DateOfContact = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                ContactPersonId = "PER-000001",
                ContactRelationship = "Brother",
                InsurancePhoneNumber = "+639495940509",
                InsuranceCompanyName = "AH OY",
                MedicalRecordNumber = "123123123123213",
                PolicyNumber = "123",
                GroupNumber = "123213",
                VisitDate = DateTime.UtcNow
            });
            serv.AddOutpatient(new Outpatient
            {
                FirstName = "Abigail",
                LastName = "M.",
                MiddleInitial = "M.",
                Address = "3212 Kahel St., Sto. Domingo II, Pampanga",
                City = "Davao City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "lalalaala@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                DateOfContact = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                ContactPersonId = "PER-000001",
                ContactRelationship = "Brother",
                InsurancePhoneNumber = "+639495940509",
                InsuranceCompanyName = "AH OY",
                MedicalRecordNumber = "123123123123213",
                PolicyNumber = "123",
                GroupNumber = "123213",
                VisitDate = DateTime.UtcNow
            });
            serv.AddOutpatient(new Outpatient
            {
                FirstName = "Anna",
                LastName = "O.",
                MiddleInitial = "O.",
                Address = "3212 Kahel St., Sto. Domingo II, Pampanga",
                City = "Davao City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "lalalaala@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                DateOfContact = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                ContactPersonId = "PER-000001",
                ContactRelationship = "Brother",
                InsurancePhoneNumber = "+639495940509",
                InsuranceCompanyName = "AH OY",
                MedicalRecordNumber = "123123123123213",
                PolicyNumber = "123",
                GroupNumber = "123213",
                VisitDate = DateTime.UtcNow
            });
            serv.AddOutpatient(new Outpatient
            {
                FirstName = "Katriana",
                LastName = "B.",
                MiddleInitial = "B.",
                Address = "3212 Kahel St., Sto. Domingo II, Pampanga",
                City = "Davao City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "lalalaala@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                DateOfContact = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                ContactPersonId = "PER-000001",
                ContactRelationship = "Brother",
                InsurancePhoneNumber = "+639495940509",
                InsuranceCompanyName = "AH OY",
                MedicalRecordNumber = "123123123123213",
                PolicyNumber = "123",
                GroupNumber = "123213",
                VisitDate = DateTime.UtcNow
            });
            serv.AddOutpatient(new Outpatient
            {
                FirstName = "Dexie",
                LastName = "Badilles",
                MiddleInitial = ".",
                Address = "Sasa",
                City = "Davao City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "lalalaala@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                DateOfContact = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                ContactPersonId = "PER-000001",
                ContactRelationship = "Brother",
                InsurancePhoneNumber = "+639495940509",
                InsuranceCompanyName = "AH OY",
                MedicalRecordNumber = "123123123123213",
                PolicyNumber = "123",
                GroupNumber = "123213",
                VisitDate = DateTime.UtcNow
            });

        }
    }
}

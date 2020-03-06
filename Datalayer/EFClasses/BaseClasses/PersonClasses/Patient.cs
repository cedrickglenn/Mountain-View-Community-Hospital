﻿using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;

namespace Datalayer.EFClasses.BaseClasses.PersonClasses
{
    public class Patient : Person
    {
        public string PatientId { get; set; }
        public string ContactRelationship { get; set; }
        public string DateOfContact { get; set; }
        public string MedicalRecordNumber { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string PolicyNumber { get; set; }
        public string GroupNumber { get; set; }
        public string InsurancePhoneNumber { get; set; }
        public char PatientType { get; set; }

        public Person ContactPersonLink { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Diagnosis> Diagnoses { get; set; }
        public ICollection<Treatment> Treatments { get; set; }
        public ICollection<VitalRecord> VitalRecords { get; set; }
        public ICollection<PatientOrder> PatientOrders { get; set; }
        public string? ContactPersonId { get; set; }
    }
}

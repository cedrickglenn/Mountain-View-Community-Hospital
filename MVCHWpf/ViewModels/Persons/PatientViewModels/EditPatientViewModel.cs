using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using Microsoft.EntityFrameworkCore;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.Persons.PatientViewModels
{
    public class EditPatientViewModel
    {
        private PersonService _personService;
        private WardService _wardService;
        private BedService _bedService;
        private string _searchContactText;
        private string _searchSubscriberText;
        private string _searchWardText;
        private string _searchBedText;
        private VisitService _visitService;
        private PatientService _patientService;
        private CombinedPatientViewModel _originalModel;

        public EditPatientViewModel(CombinedPatientViewModel originalModel,
            CombinedPatientViewModel duplicateModel,
            PatientService patientService,
            PersonService personService,
            WardService wardService,
            BedService bedService,
            VisitService visitService)
        {
            AssociatedPatientModel = duplicateModel;
            _originalModel = originalModel;
            OriginalPatientModel = _originalModel.PatientModel;
            OriginalInpatientModel = _originalModel.InpatientModel;
            OriginalOutpatientModel = _originalModel.OutpatientModel;
            _patientService = patientService;
            _personService = personService;
            _wardService = wardService;
            _bedService = bedService;
            _visitService = visitService;
            ContactPersons = new ObservableCollection<Person>(_personService.GetPersons()
                .Where(c=>c.Discriminator == "Person").ToList());
            SubscriberPersons = new ObservableCollection<Person>(_personService.GetPersons()
                .Where(c=>c.Discriminator == "Person").ToList());
            Wards = new ObservableCollection<Ward>(_wardService.GetWards()
                .Include(c => c.FacilityLink));
            Beds = new ObservableCollection<Bed>(_bedService.GetBeds()
                .Include(c => c.WorkUnitLink));
            if (!AssociatedPatientModel.IsOutpatient)
            {
                if (AssociatedPatientModel.InpatientModel.BedId != null)
                {
                    SelectedBed = Beds.First(c => c.BedId == AssociatedPatientModel.InpatientModel.BedId);
                    OriginalBed = SelectedBed;
                }
                if (AssociatedPatientModel.InpatientModel.ContactPersonId != null)
                {
                    SelectedContactPerson = ContactPersons.First(c =>
                        c.PersonId == AssociatedPatientModel.InpatientModel.ContactPersonId);
                    OriginalContact = SelectedContactPerson;
                }
                if (AssociatedPatientModel.InpatientModel.SubscriberPersonId != null)
                {
                    SelectedSubscriber = SubscriberPersons.First(c =>
                        c.PersonId == AssociatedPatientModel.InpatientModel.SubscriberPersonId);
                    OriginalSubscriber = SelectedSubscriber;
                }
                SelectedWard = Wards.First(c => c.WardId == AssociatedPatientModel.InpatientModel.WardId);
                OriginalWard = SelectedWard;
                PatientModel = AssociatedPatientModel.PatientModel;
                InpatientModel = AssociatedPatientModel.InpatientModel;
            }
            else
            {
                if (AssociatedPatientModel.OutpatientModel.ContactPersonId != null)
                {
                    SelectedContactPerson = ContactPersons.First(c =>
                        c.PersonId == AssociatedPatientModel.OutpatientModel.ContactPersonId);
                    OriginalContact = SelectedContactPerson;
                }

                if (AssociatedPatientModel.OutpatientModel.SubscriberPersonId != null)
                {
                    SelectedSubscriber = SubscriberPersons.First(c =>
                        c.PersonId == AssociatedPatientModel.OutpatientModel.SubscriberPersonId);
                    OriginalSubscriber = SelectedSubscriber;
                }

                Visits = new ObservableCollection<Visit>(_visitService.GetVisits()
                    .Where(c=>c.OutpatientId == AssociatedPatientModel.OutpatientModel.PersonId));
                PatientModel = AssociatedPatientModel.PatientModel;
                OutpatientModel = AssociatedPatientModel.OutpatientModel;
            }
            
        }

        public Ward OriginalWard { get; set; }

        public Person OriginalSubscriber { get; set; }

        public Person OriginalContact { get; set; }

        public Bed OriginalBed { get; set; }

        public Outpatient OriginalOutpatientModel { get; set; }

        public Inpatient OriginalInpatientModel { get; set; }

        public Patient OriginalPatientModel { get; set; }

        public Patient PatientModel { get;}
        public Inpatient InpatientModel { get;}
        public Outpatient OutpatientModel { get;}
        public CombinedPatientViewModel AssociatedPatientModel { get; }
        public ObservableCollection<Visit> Visits { get; set; }
        public ObservableCollection<Person> ContactPersons { get; set; }
        public ObservableCollection<Person> SubscriberPersons { get; set; }
        public ObservableCollection<Ward> Wards { get; set; }
        public ObservableCollection<Bed> Beds { get; set; }
        public Person SelectedContactPerson { get; set; }
        public Person SelectedSubscriber { get; set; }
        public Ward SelectedWard { get; set; }
        public Bed SelectedBed { get; set; }

        public string SearchContactText
        {
            get => _searchContactText;
            set
            {
                _searchContactText = value;
                if (_searchContactText == null)
                {
                    _searchContactText = "";
                    SearchContactPerson(_searchContactText.Trim());
                }
                SearchContactPerson(_searchContactText.Trim());
            }
        }
        public string SearchSubscriberText
        {
            get => _searchSubscriberText;
            set
            {
                _searchSubscriberText = value;
                if (_searchSubscriberText == null)
                {
                    _searchSubscriberText = "";
                    SearchSubscriberPerson(_searchSubscriberText.Trim());
                }
                SearchSubscriberPerson(_searchSubscriberText.Trim());
            }
        }
       
        public string SearchBedText
        {
            get => _searchBedText;
            set
            {
                _searchBedText = value;
                if (_searchBedText == null)
                {
                    _searchBedText = "";
                    SearchBed(_searchBedText.Trim());
                }
                SearchBed(_searchBedText.Trim());

            }
        }
        public string SearchWardText
        {
            get => _searchWardText;
            set
            {
                _searchWardText = value;
                if (_searchWardText == null)
                {
                    _searchWardText = "";
                    SearchWard(_searchWardText.Trim());
                }
                SearchWard(_searchWardText.Trim());

            }
        }
        
        


        public void SearchContactPerson(string searchString)
        {
            searchString = searchString.Replace(".", string.Empty);
            var persons  = _personService.GetPersons()
                .Where(c => c.FirstName.Contains(searchString) ||
                            c.MiddleInitial.Contains(searchString) ||
                            c.LastName.Contains(searchString));
            ContactPersons.Clear();
            foreach (var person in persons)
            {
                ContactPersons.Add(person);
            }
        }
        public void SearchSubscriberPerson(string searchString)
        {
            searchString = searchString.Replace(".", string.Empty);
            var persons = _personService.GetPersons()
                .Where(c => c.FirstName.Contains(searchString)||
                            c.MiddleInitial.Contains(searchString) ||
                            c.LastName.Contains(searchString));
            SubscriberPersons.Clear();
            foreach (var person in persons)
            {
                SubscriberPersons.Add(person);
            }
        }
        public void SearchWard(string searchString)
        {
            searchString = searchString.Replace("—", string.Empty);
            var wards = _wardService.GetWards()
                .Include(c=>c.FacilityLink)
                .Where(c => c.Name.Contains(searchString) ||
                            c.FacilityLink.Name.Contains(searchString));
            Wards.Clear();
            foreach (var ward in wards)
            {
                Wards.Add(ward);
            }
        }
        public void SearchBed(string searchString)
        {
            searchString = searchString.Replace("—", string.Empty);
            var beds = _bedService.GetBeds()
                .Include(c=>c.WorkUnitLink)
                .Where(c => c.RoomNumber.Contains(searchString) ||
                            c.WorkUnitLink.Name.Contains(searchString));
            Beds.Clear();
            foreach (var bed in beds)
            {
                Beds.Add(bed);
            }
        }
        

        public string BuildMessageBoxContent(string patientType)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Edit the following?");
            sb.AppendLine();
            sb.AppendLine($"Name:    {OriginalPatientModel.FullName,-20} --> {PatientModel.FullName,20}");
            sb.AppendLine($"Birth Date:     {OriginalPatientModel.BirthDate:d} --> {PatientModel.BirthDate:d}");
            sb.AppendLine($"Home Address:     {OriginalPatientModel.Address,-10} --> {PatientModel.Address,10}");
            sb.AppendLine($"City:     {OriginalPatientModel.City,-10} --> {PatientModel.City,10}");
            sb.AppendLine($"State:     {OriginalPatientModel.State,-10} --> {PatientModel.State,10}");
            sb.AppendLine($"Zip:     {OriginalPatientModel.Zip,-10} --> {PatientModel.Zip,10}");
            sb.AppendLine($"Phone #:     {OriginalPatientModel.PhoneNumber ??="none",-10} --> {PatientModel.PhoneNumber ??= "none",10}");
            sb.AppendLine($"Email:     {OriginalPatientModel.Email ??="none",-10} --> {PatientModel.Email ??="none",10}");
            sb.AppendLine($"Medical Record Number:     {OriginalPatientModel.MedicalRecordNumber,-10} --> {PatientModel.MedicalRecordNumber,10}");
            sb.AppendLine($"Contact Date:     {OriginalPatientModel.DateOfContact:d} --> {PatientModel.DateOfContact:d}");
            if (OriginalContact != null)
                if (SelectedContactPerson != null)
                    sb.AppendLine($"Emergency Contact:     {OriginalContact.FullName,-10} --> {SelectedContactPerson.FullName,10}");
                else
                    sb.AppendLine($"Emergency Contact:     {OriginalContact.FullName,-10} --> {"none",10}");
            else 
            {
                if (SelectedContactPerson != null)
                    sb.AppendLine($"Emergency Contact:     {"none",-10} --> {SelectedContactPerson.FullName,10}");
                else
                    sb.AppendLine($"Emergency Contact:     {"none",-10} --> {"none",10}");
            }
            sb.AppendLine($"Contact Relationship:     {OriginalPatientModel.ContactRelationship ??="none",-10} --> {PatientModel.ContactRelationship ??="none",10}");
            if (OriginalSubscriber != null)
                if (SelectedSubscriber != null)
                    sb.AppendLine($"Insurance Subscriber:     {OriginalSubscriber.FullName,-10} --> {SelectedSubscriber.FullName,10}");
                else
                    sb.AppendLine($"Insurance Subscriber:     {OriginalSubscriber.FullName,-10} --> {"none",10}");
            else 
            {
                if (SelectedSubscriber != null)
                    sb.AppendLine($"Insurance Subscriber:     {"none",-10} --> {SelectedSubscriber.FullName,10}");
                else
                    sb.AppendLine($"Insurance Subscriber:     {"none",-10} --> {"none",10}");
            }
            sb.AppendLine($"Subscriber Relationship:     {OriginalPatientModel.SubscriberRelationship ??="none",-10} --> {PatientModel.SubscriberRelationship ??="none",10}");
            sb.AppendLine($"Insurance Company:    {OriginalPatientModel.InsuranceCompanyName ??="none",-10} --> {PatientModel.InsuranceCompanyName ??="none",10}");
            sb.AppendLine($"Policy #:     {OriginalPatientModel.PolicyNumber ??="none",-10} --> {PatientModel.PolicyNumber ??="none",10}");
            sb.AppendLine($"Group #:     {OriginalPatientModel.GroupNumber ??="none",-10} --> {PatientModel.GroupNumber ??="none",10}");
            sb.AppendLine($"Company Phone #:     {OriginalPatientModel.InsurancePhoneNumber ??="none",-10} --> {PatientModel.InsurancePhoneNumber ??="none",10}");
            if (patientType == "Inpatient")
            {
                sb.AppendLine($"Date Admitted:     {OriginalInpatientModel.DateAdmitted:d} --> {InpatientModel.DateAdmitted:d}");
                sb.AppendLine($"Date Discharged:     {OriginalInpatientModel.DischargeDate:d} --> {InpatientModel.DischargeDate:d}");
                sb.AppendLine($"Selected Ward:     {OriginalWard.NameAndFacility ,-10} --> {SelectedWard.NameAndFacility ,10}");
                if (OriginalBed != null)
                    if (SelectedBed != null)
                        sb.AppendLine($"Selected Bed:     {OriginalBed.RoomNumberAndWorkUnit,-10} --> {SelectedBed.RoomNumberAndWorkUnit,10}");
                    else
                        sb.AppendLine($"Selected Bed:     {OriginalBed.RoomNumberAndWorkUnit,-10} --> {"none",10}");
                else 
                {
                    if (SelectedBed != null)
                        sb.AppendLine($"Selected Bed:     {"none",-10} --> {SelectedBed.RoomNumberAndWorkUnit,10}");
                    else
                        sb.AppendLine($"Selected Bed:     {"none",-10} --> {"none",10}");
                }
            }
            return sb.ToString();
        }



        public bool SaveAndVerify(string patientType)
        {
            var response = MessageBox.Show(BuildMessageBoxContent(patientType),"Save Changes?",MessageBoxButton.OKCancel,MessageBoxImage.Warning,MessageBoxResult.OK);
            switch (response)
            {
                case MessageBoxResult.OK:
                    return true;
                case MessageBoxResult.Cancel:
                    return false;
                default: return false;
            }
        }


        public void Edit(string patientType)
        {
            if (patientType == "Inpatient")
            {
                var patientToAdd = new Inpatient
                {
                    PersonId =  PatientModel.PersonId,
                    FirstName = PatientModel.FirstName,
                    LastName = PatientModel.LastName,
                    MiddleInitial = PatientModel.MiddleInitial,
                    Address = PatientModel.Address,
                    City = PatientModel.City,
                    State = PatientModel.State,
                    Zip = PatientModel.Zip,
                    PhoneNumber = PatientModel.PhoneNumber,
                    Email = PatientModel.Email,
                    BirthDate = PatientModel.BirthDate,
                    MedicalRecordNumber = PatientModel.MedicalRecordNumber,
                    PolicyNumber = PatientModel.PolicyNumber,
                    InsuranceCompanyName = PatientModel.InsuranceCompanyName,
                    GroupNumber = PatientModel.GroupNumber,
                    InsurancePhoneNumber = PatientModel.InsurancePhoneNumber,
                    DateOfContact = PatientModel.DateOfContact,
                    DateAdmitted = InpatientModel.DateAdmitted,
                    DischargeDate = InpatientModel.DischargeDate,
                    WardId = SelectedWard.WardId,
                    Discriminator = PatientModel.Discriminator
                };
                if (SelectedBed != null) patientToAdd.BedId = SelectedBed.BedId;
                if (SelectedSubscriber != null)
                {
                    patientToAdd.SubscriberPersonId = SelectedSubscriber.PersonId;
                    patientToAdd.SubscriberRelationship = PatientModel.SubscriberRelationship;
                    PatientModel.SubscriberPersonLink = SelectedSubscriber;
                }
                if (SelectedContactPerson != null)
                {
                    patientToAdd.ContactPersonId = SelectedContactPerson.PersonId;
                    patientToAdd.ContactRelationship = PatientModel.ContactRelationship;
                    PatientModel.ContactPersonLink = SelectedContactPerson;
                }
                _patientService.UpdateInpatient(patientToAdd);
                AssociatedPatientModel.PatientModel = PatientModel;
                AssociatedPatientModel.InpatientModel = InpatientModel;
            }
            if (patientType == "Outpatient")
            {
                var patientToEdit = new Outpatient
                {
                    PersonId = PatientModel.PersonId,
                    FirstName = PatientModel.FirstName,
                    LastName = PatientModel.LastName,
                    MiddleInitial = PatientModel.MiddleInitial,
                    Address = PatientModel.Address,
                    City = PatientModel.City,
                    State = PatientModel.State,
                    Zip = PatientModel.Zip,
                    DateOfContact = PatientModel.DateOfContact,
                    PhoneNumber = PatientModel.PhoneNumber,
                    Email = PatientModel.Email,
                    BirthDate = PatientModel.BirthDate,
                    MedicalRecordNumber = PatientModel.MedicalRecordNumber,
                    PolicyNumber = PatientModel.PolicyNumber,
                    InsuranceCompanyName = PatientModel.InsuranceCompanyName,
                    GroupNumber = PatientModel.GroupNumber,
                    InsurancePhoneNumber = PatientModel.InsurancePhoneNumber,
                    Discriminator = PatientModel.Discriminator
                };
                if (SelectedSubscriber != null)
                {
                    patientToEdit.SubscriberPersonId = SelectedSubscriber.PersonId;
                    patientToEdit.SubscriberRelationship = PatientModel.SubscriberRelationship;
                    PatientModel.SubscriberPersonLink = SelectedSubscriber;
                    
                }
                if (SelectedContactPerson != null)
                {
                    patientToEdit.ContactPersonId = SelectedContactPerson.PersonId;
                    patientToEdit.ContactRelationship = PatientModel.ContactRelationship;
                    PatientModel.ContactPersonLink = SelectedContactPerson;
                }
                _patientService.UpdateOutpatient(patientToEdit);
                AssociatedPatientModel.PatientModel = PatientModel;
                AssociatedPatientModel.OutpatientModel = OutpatientModel;
            }
        }

        //public string Error { get; }

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        string result = null;
        //        if (columnName == "PatientModel")
        //        {
        //            if (string.IsNullOrWhiteSpace(PatientModel.FirstName))
        //                result = "Field is required.";
        //            if (!Regex.IsMatch(PatientModel.FirstName, "[a-zA-Z]"))
        //                result = "Field must only contain letters";
        //        }

        //        if (columnName == "PatientModel.MiddleInitial")
        //        {
        //            if (string.IsNullOrWhiteSpace(PatientModel.MiddleInitial))
        //                result = "Field is required";
        //            if (!Regex.IsMatch(PatientModel.MiddleInitial, "[a-zA-Z]") || PatientModel.MiddleInitial.Length > 1)
        //                result = "Field must only contain a letter";
        //        }
        //        if (columnName == "PatientModel.LastName")
        //        {
        //            if (string.IsNullOrWhiteSpace(PatientModel.LastName))
        //                result = "Field is required.";
        //            if (!Regex.IsMatch(PatientModel.LastName, "[a-zA-Z]"))
        //                result = "Field must only contain letters";
        //        }

        //        if (columnName == "PatientModel.Address")
        //            if (string.IsNullOrWhiteSpace(PatientModel.Address))
        //                result = "Field is required";
        //        if (columnName == "PatientModel.City")
        //        {
        //            if (string.IsNullOrWhiteSpace(PatientModel.City))
        //                result = "Field is required";
        //            if (!Regex.IsMatch(PatientModel.City, "[a-zA-Z]"))
        //                result = "Field must only contain letters";
        //        }

        //        if (columnName == "PatientModel.State")
        //        {
        //            if (string.IsNullOrWhiteSpace(PatientModel.State))
        //                result = "Field is required";
        //            if (!Regex.IsMatch(PatientModel.State, "[a-zA-Z]"))
        //                result = "Field must only contain letters";
        //        }

        //        if (columnName == "PatientModel.Zip")
        //            if (string.IsNullOrWhiteSpace(PatientModel.Zip))
        //                result = "Field is required";

        //        if (columnName == "PatientModel.BirthDate")
        //            if (PatientModel.BirthDate == DateTime.MinValue)
        //                result = "Field is required";

        //        if (columnName == "PatientModel.MedicalRecordNumber")
        //            if (string.IsNullOrWhiteSpace(PatientModel.MedicalRecordNumber))
        //                result = "Field is required";

        //        if (columnName == "PatientModel.ContactRelationship")
        //            if (SelectedContactPerson != null && string.IsNullOrWhiteSpace(PatientModel.ContactRelationship))
        //                result = "Field is required";

        //        if (columnName == "PatientModel.SubscriberRelationship")
        //            if (SelectedSubscriber != null && string.IsNullOrWhiteSpace(PatientModel.ContactRelationship))
        //                result = "Field is required";

        //        if (columnName == "SelectedWard")
        //            if (SelectedWard == null)
        //                result = "Field is required";

        //        if (columnName == "InpatientModel.DateAdmitted")
        //            if (InpatientModel.DateAdmitted == DateTime.MinValue)
        //                result = "Field is required";
        //        return result;
        //    }
        //}
        }


    }

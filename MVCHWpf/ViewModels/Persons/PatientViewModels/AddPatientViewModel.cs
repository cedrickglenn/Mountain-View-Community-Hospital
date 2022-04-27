using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using Microsoft.EntityFrameworkCore;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;
using Condition = Datalayer.EFClasses.BaseClasses.Condition;

namespace MVCHWpf.ViewModels.Persons.PatientViewModels
{
    public class AddPatientViewModel : ObservableObject
    {
        private PatientListViewModel _patientListViewModel;
        private PatientService _patientService;
        private PersonService _personService;
        private DiagnosisService _diagnosisService;
        private PhysicianService _physicianService;
        private EmployeeService _employeeService;
        private WardService _wardService;
        private BedService _bedService;
        private VitalRecordService _vitalRecordService;
        private ConditionService _conditionService;
        private string _searchContactText;
        private string _searchSubscriberText;
        private string _searchPhysicianText;
        private string _searchWardText;
        private string _searchBedText;
        private string _searchNurseText;
        private string _searchConditionText;

        public AddPatientViewModel(PatientListViewModel patientListViewModel, 
            PatientService patientService, 
            PersonService personService, 
            DiagnosisService diagnosisService, 
            PhysicianService physicianService, 
            EmployeeService employeeService, 
            WardService wardService, 
            BedService bedService,
            VitalRecordService vitalRecordService,
            ConditionService conditionService)
        {
            _patientListViewModel = patientListViewModel;
            _patientService = patientService;
            _personService = personService;
            _diagnosisService = diagnosisService;
            _physicianService = physicianService;
            _employeeService = employeeService;
            _wardService = wardService;
            _bedService = bedService;
            _vitalRecordService = vitalRecordService;
            _conditionService = conditionService;

            ContactPersons = new ObservableCollection<Person>(_personService.GetPersons()
                .Where(c =>c.Discriminator == "Person"));

            SubscriberPersons = new ObservableCollection<Person>(_personService.GetPersons()
                .Where(c =>c.Discriminator == "Person"));

            Nurses = new ObservableCollection<Nurse>(_employeeService.GetNurses());

            Physicians = new ObservableCollection<Physician>(_physicianService.GetPhysicians());

            Wards = new ObservableCollection<Ward>(_wardService.GetWards()
                .Include(c => c.FacilityLink));

            Beds = new ObservableCollection<Bed>(_bedService.GetBeds()
                .Include(c => c.WorkUnitLink));

            Conditions = new ObservableCollection<Condition>(_conditionService.GetConditions());
            PatientModel.BirthDate = DateTime.Now;
            PatientModel.DateOfContact = DateTime.Now;
            InpatientModel.DateAdmitted = DateTime.Now;
            InpatientModel.DischargeDate = DateTime.Now;

        }

        public ObservableCollection<Person> ContactPersons { get; set; }
        public ObservableCollection<Person> SubscriberPersons { get; set; }
        public ObservableCollection<Nurse> Nurses { get; set; }
        public ObservableCollection<Physician> Physicians { get; set; }
        public ObservableCollection<Ward> Wards { get; set; }
        public ObservableCollection<Bed> Beds { get; set; }
        public ObservableCollection<Condition> Conditions { get; set; }
        public Person SelectedContactPerson { get; set; }
        public Person SelectedSubscriber { get; set; }
        public Nurse SelectedNurse { get; set; }
        public Physician SelectedPhysician { get; set; }
        public Ward SelectedWard { get; set; }
        public Bed SelectedBed { get; set; }
        public Condition SelectedCondition { get; set; }

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
        public string SearchPhysicianText
        {
            get => _searchPhysicianText;
            set
            {
                _searchPhysicianText = value;
                if (_searchPhysicianText == null)
                {
                    _searchPhysicianText = "";
                    SearchPhysician(_searchPhysicianText.Trim());
                }
                SearchPhysician(_searchPhysicianText.Trim());
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
        public string SearchNurseText
        {
            get => _searchNurseText;
            set
            {
                _searchNurseText = value;
                if (_searchNurseText == null)
                {
                    _searchNurseText = "";
                    SearchNurse(_searchNurseText.Trim());
                }
                else SearchNurse(_searchNurseText.Trim());

            }
        }
        public string SearchConditionText
        {
            get => _searchConditionText;
            set
            {
                _searchConditionText = value;
                if (_searchConditionText == null)
                {
                    _searchConditionText = "";
                    SearchCondition(_searchConditionText.Trim());
                }
                SearchCondition(_searchConditionText.Trim());
            }
        }

        #region Properties
        public Patient PatientModel { get; set; } = new Patient();
        public Inpatient InpatientModel { get; set; } = new Inpatient();
        public Outpatient OutpatientModel { get; set; } = new Outpatient();
        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        //public string MiddleInitial { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }

        //public string State { get; set; }

        //public string Zip { get; set; }

        //public DateTime BirthDate { get; set; } = DateTime.Now;

        //public string PhoneNumber { get; set; }

        //public string Email { get; set; }

        //public string ContactRelationship { get; set; } 
        
        //public string SubscriberRelationship { get; set; }

        //public DateTime? DateOfContact { get; set; }
        //public DateTime DateAdmitted { get; set; } = DateTime.Now;
        //public DateTime? DischargeDate { get; set; }

        //public string MedicalRecordNumber { get; set; }

        //public string InsuranceCompanyName { get; set; }

        //public string PolicyNumber { get; set; }

        //public string GroupNumber { get; set; }

        //public string InsurancePhoneNumber { get; set; }

        #endregion

        #region Vital Sign Properties

        public string Height { get; set; }
        public string Weight { get; set; }
        public string BloodPressure { get; set; }
        public string Pulse { get; set; }
        public string Temperature { get; set; }
        public DateTime RecordDateTime { get; set; } = DateTime.Now;
        #endregion

        #region Other Properties

        public string Description { get; set; }
        public DateTime DiagnosisDateTime { get; set; } = DateTime.Now;

        #endregion


        public void Add(string patientType)
        {
            if (patientType == "Inpatient")
            {
                var patientToAdd = new Inpatient
                {
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
                    WardId = SelectedWard.WardId
                };
                if (SelectedBed != null) patientToAdd.BedId = SelectedBed.BedId;
                if (SelectedSubscriber != null)
                {
                    patientToAdd.SubscriberPersonId = SelectedSubscriber.PersonId;
                    patientToAdd.SubscriberRelationship = PatientModel.SubscriberRelationship;
                }
                if (SelectedContactPerson != null)
                {
                    patientToAdd.ContactPersonId = SelectedContactPerson.PersonId;
                    patientToAdd.ContactRelationship = PatientModel.ContactRelationship;
                }
                _patientService.AddInpatient(patientToAdd);
                AddVitalRecords(patientToAdd.PersonId);
                AddDiagnosis(patientToAdd.PersonId);
                _patientListViewModel.PatientList.Insert(0, new CombinedPatientViewModel(patientToAdd));
            }

            if (patientType == "Outpatient")
            {
                var patientToAdd = new Outpatient
                {
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
                    InsurancePhoneNumber = PatientModel.InsurancePhoneNumber
                };
                if (SelectedSubscriber != null)
                {
                    patientToAdd.SubscriberPersonId = SelectedSubscriber.PersonId;
                    patientToAdd.SubscriberRelationship = PatientModel.SubscriberRelationship;
                }
                if (SelectedContactPerson != null)
                {
                    patientToAdd.ContactPersonId = SelectedContactPerson.PersonId;
                    patientToAdd.ContactRelationship = PatientModel.ContactRelationship;
                }
                _patientService.AddOutpatient(patientToAdd);
                AddVitalRecords(patientToAdd.PersonId);
                AddDiagnosis(patientToAdd.PersonId);
                _patientListViewModel.PatientList.Insert(0, new CombinedPatientViewModel(patientToAdd));
                
            }

        }

        public bool CheckFirst()
        {
            if (string.IsNullOrWhiteSpace(PatientModel.FirstName) || string.IsNullOrWhiteSpace(PatientModel.LastName) ||
                string.IsNullOrWhiteSpace(PatientModel.MiddleInitial) || string.IsNullOrWhiteSpace(PatientModel.Address) ||
                string.IsNullOrWhiteSpace(PatientModel.City) || string.IsNullOrWhiteSpace(PatientModel.State) || string.IsNullOrWhiteSpace(PatientModel.Zip) || 
                PatientModel.BirthDate == null )
            {
                MessageBox.Show("Fill up required fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }


        public void AddDiagnosis(string patientId)
        {
            var diagnosis = new Diagnosis
            {
                Description = Description,
                DateTime = DiagnosisDateTime,
                PatientId = patientId,
                PhysicianId = SelectedPhysician.PersonId,
                ConditionId = SelectedCondition.ConditionId
            };
            _diagnosisService.AddDiagnosis(diagnosis);
        }

        public void AddVitalRecords(string patientId)
        {
            var height = new VitalRecord
            {
                Value =  $"{Height} cm",
                DateTime = RecordDateTime,
                NurseId = SelectedNurse.PersonId,
                PatientId = patientId,
                VitalId = "VTL-000001"
            };
            var weight = new VitalRecord
            {
                Value = $"{Weight} kgs",
                DateTime = RecordDateTime,
                NurseId = SelectedNurse.PersonId,
                PatientId = patientId,
                VitalId = "VTL-000002"
            };
            var bloodPressure = new VitalRecord
            {
                Value = $"{BloodPressure} mmHg",
                DateTime = RecordDateTime,
                NurseId = SelectedNurse.PersonId,
                PatientId = patientId,
                VitalId = "VTL-000003"
            }; var pulse = new VitalRecord
            {
                Value = $"{Pulse} bpm",
                DateTime = RecordDateTime,
                NurseId = SelectedNurse.PersonId,
                PatientId = patientId,
                VitalId = "VTL-000004"
            };
            var temperature = new VitalRecord
            {
                Value = $"{Temperature} C°",
                DateTime = RecordDateTime,
                NurseId = SelectedNurse.PersonId,
                PatientId = patientId,
                VitalId = "VTL-000005"
            };
            _vitalRecordService.AddVitalRecord(height);
            _vitalRecordService.AddVitalRecord(weight);
            _vitalRecordService.AddVitalRecord(bloodPressure);
            _vitalRecordService.AddVitalRecord(pulse);
            _vitalRecordService.AddVitalRecord(temperature);
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
        public void SearchPhysician(string searchString)
        {
            searchString = searchString.Replace(".", string.Empty);
            var physicians = _physicianService.GetPhysicians()
                .Where(c => c.FirstName.Contains(searchString) ||
                            c.MiddleInitial.Contains(searchString) ||
                            c.LastName.Contains(searchString));
            Physicians.Clear();
            foreach (var physician in physicians)
            {
                Physicians.Add(physician);
            }
        }
        public void SearchNurse(string searchString)
        {
            searchString = searchString.Replace(".", string.Empty);
            searchString = searchString.Replace(",", string.Empty);
            var nurses = _employeeService.GetNurses()
                .Where(c => c.FirstName.Contains(searchString) ||
                            c.MiddleInitial.Contains(searchString) ||
                            c.LastName.Contains(searchString) ||
                            c.Degree.Contains(searchString));
            Nurses.Clear();
            foreach (var nurse in nurses)
            {
                Nurses.Add(nurse);
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
        public void SearchCondition(string searchString)
        {
            var conditions = _conditionService.GetConditions()
                .Where(c => c.Name.Contains(searchString));
            Conditions.Clear();
            foreach (var condition in conditions)
            {
                Conditions.Add(condition);
            }
        }

    }
}

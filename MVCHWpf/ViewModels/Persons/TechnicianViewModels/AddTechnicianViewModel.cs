using System;
using System.Collections.ObjectModel;
using System.Windows;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.Persons.TechnicianViewModels
{
    public class AddTechnicianViewModel : ObservableObject
    {
        private TechnicianListViewModel _technicianListViewModel;
        private EmployeeService _employeeService;
        private EmployeeSpecialtyService _employeeSpecialtyService;
        private WardEmployeeService _wardEmployeeService;
        private UnitEmployeeService _unitEmployeeService;
        private SpecialtyService _specialtyService;
        private WardService _wardService;
        private WorkUnitService _workUnitService;


        public AddTechnicianViewModel(TechnicianListViewModel technicianListViewModel,
            EmployeeService employeeService,
            WardService wardService,
            WorkUnitService workUnitService,
            SpecialtyService specialtyService,
            EmployeeSpecialtyService employeeSpecialtyService,
            WardEmployeeService wardEmployeeService,
            UnitEmployeeService unitEmployeeService)
        {
            _technicianListViewModel = technicianListViewModel;
            _employeeService = employeeService;
            _wardService = wardService;
            _workUnitService = workUnitService;
            _employeeSpecialtyService = employeeSpecialtyService;
            _specialtyService = specialtyService;
            _wardEmployeeService = wardEmployeeService;
            _unitEmployeeService = unitEmployeeService;
            Specialties = new ObservableCollection<Specialty>(_specialtyService.GetSpecialties());
            Wards = new ObservableCollection<Ward>(_wardService.GetWards());
            WorkUnits= new ObservableCollection<WorkUnit>(_workUnitService.GetWorkUnits());
     
        }

        public ObservableCollection<Specialty> Specialties { get; set; }
        public ObservableCollection<Ward> Wards { get; set; }
        public ObservableCollection<WorkUnit> WorkUnits { get; set; }

        public ObservableCollection<Specialty> SelectedSpecialties { get; set; } = new ObservableCollection<Specialty>();
        public ObservableCollection<Ward> SelectedWards { get; set; } = new ObservableCollection<Ward>();
        public ObservableCollection<WorkUnit> SelectedUnits { get; set; } = new ObservableCollection<WorkUnit>();

        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string License { get; set; }
        public DateTime DateHired { get; set; } = DateTime.Now;


        #endregion

        public void Add()
        {
            var technicianToAdd = new Technician
            {
                FirstName = FirstName,
                LastName = LastName,
                MiddleInitial =  MiddleInitial,
                Address =  Address,
                City =  City,
                State =  State,
                Zip =  Zip,
                PhoneNumber =  PhoneNumber,
                Email =  Email,
                BirthDate =  BirthDate,
                DateHired = DateHired,
                License = License
            };
            _employeeService.AddTechnician(technicianToAdd);
            if (SelectedSpecialties != null) AddEmployeeSpecialty(technicianToAdd.PersonId);
            if (SelectedWards != null) AddWardEmployee(technicianToAdd.PersonId);
            if (SelectedUnits != null) AddUnitEmployee(technicianToAdd.PersonId);
            _technicianListViewModel.TechnicianList.Insert(0, new TechnicianViewModel(technicianToAdd));
        }

        public bool CheckFirst()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) ||
                string.IsNullOrWhiteSpace(MiddleInitial) || string.IsNullOrWhiteSpace(Address) ||
                string.IsNullOrWhiteSpace(City) || string.IsNullOrWhiteSpace(State) || string.IsNullOrWhiteSpace(Zip) || 
                BirthDate == null || SelectedSpecialties.Count == 0 || SelectedUnits.Count == 0||string.IsNullOrWhiteSpace(License)
                ||DateHired == null)
            {
                MessageBox.Show("Fill up required fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void AddEmployeeSpecialty(string personId)
        {
            foreach (var selectedSpecialty in SelectedSpecialties)
            {
                //DateAcquired only serves as certification
                var newEmployeeSpecialty = new EmployeeSpecialty
                {
                    SpecialtyId = selectedSpecialty.SpecialtyId,
                    EmployeeId = personId,
                    DateAcquired = DateTime.Now
                 };
                _employeeSpecialtyService.AddEmployeeSpecialty(newEmployeeSpecialty);
            }
            
        }

        private void AddWardEmployee(string personId)
        {
            foreach (var selectedWard in SelectedWards)
            {
                //Assumes that assigning physicians to their respective facilities are on the same date/time
                //as their registration to the system
                var newWardEmployee = new WardEmployee
                {
                    WardId = selectedWard.WardId,
                    EmployeeId = personId,
                    DateAssigned = DateTime.Now
                };
                _wardEmployeeService.AddWardEmployee(newWardEmployee);
            }
        }
        private void AddUnitEmployee(string personId)
        {
            foreach (var selectedUnit in SelectedUnits)
            {
                //Assumes that assigning physicians to their respective facilities are on the same date/time
                //as their registration to the system
                var newUnitEmployee = new UnitEmployee
                {
                    WorkUnitId = selectedUnit.WorkUnitId,
                    EmployeeId = personId,
                    DateAssigned = DateTime.Now
                };
                _unitEmployeeService.AddUnitEmployee(newUnitEmployee);
            }
        }
    }
    }

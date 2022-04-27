using System;
using System.Collections.ObjectModel;
using System.Windows;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using MVCHWpf.ViewModels.Persons.PhysicianViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.Persons.StaffViewModels
{
    public class AddStaffViewModel : ObservableObject
    {
        private StaffListViewModel _staffListViewModel;
        private EmployeeService _employeeService;
        private EmployeeSpecialtyService _employeeSpecialtyService;
        private WardEmployeeService _wardEmployeeService;
        private UnitEmployeeService _unitEmployeeService;
        private SpecialtyService _specialtyService;
        private WardService _wardService;
        private WorkUnitService _workUnitService;
        private JobClassService _jobClassService;


        public AddStaffViewModel(StaffListViewModel staffListViewModel,
            EmployeeService employeeService,
            WardService wardService,
            WorkUnitService workUnitService,
            SpecialtyService specialtyService,
            JobClassService jobClassService,
            EmployeeSpecialtyService employeeSpecialtyService,
            WardEmployeeService wardEmployeeService,
            UnitEmployeeService unitEmployeeService)
        {
            _staffListViewModel = staffListViewModel;
            _employeeService = employeeService;
            _wardService = wardService;
            _workUnitService = workUnitService;
            _employeeSpecialtyService = employeeSpecialtyService;
            _specialtyService = specialtyService;
            _wardEmployeeService = wardEmployeeService;
            _unitEmployeeService = unitEmployeeService;
            _jobClassService = jobClassService;

            Specialties = new ObservableCollection<Specialty>(_specialtyService.GetSpecialties());
            Wards = new ObservableCollection<Ward>(_wardService.GetWards());
            JobClasses = new ObservableCollection<JobClass>(_jobClassService.GetJobClasses());
            WorkUnits= new ObservableCollection<WorkUnit>(_workUnitService.GetWorkUnits());
     
        }

        public ObservableCollection<Specialty> Specialties { get; set; }
        public ObservableCollection<Ward> Wards { get; set; }
        public ObservableCollection<WorkUnit> WorkUnits { get; set; }
        public ObservableCollection<JobClass> JobClasses { get; set; }

        public ObservableCollection<Specialty> SelectedSpecialties { get; set; } = new ObservableCollection<Specialty>();
        public ObservableCollection<Ward> SelectedWards { get; set; } = new ObservableCollection<Ward>();
        public ObservableCollection<WorkUnit> SelectedUnits { get; set; } = new ObservableCollection<WorkUnit>();
        public JobClass SelectedJobClass { get; set; }


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
        public DateTime DateHired { get; set; } = DateTime.Now;


        #endregion

        public void Add()
        {
            var staffToAdd = new Staff
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
                JobClassId = SelectedJobClass.JobClassId
            };
            _employeeService.AddStaff(staffToAdd);
            if (SelectedSpecialties != null) AddEmployeeSpecialty(staffToAdd.PersonId);
            if (SelectedWards != null) AddWardEmployee(staffToAdd.PersonId);
            if (SelectedUnits.Count != null) AddUnitEmployee(staffToAdd.PersonId);
            _staffListViewModel.StaffList.Insert(0, new StaffViewModel(staffToAdd));
        }

        public bool CheckFirst()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) ||
                string.IsNullOrWhiteSpace(MiddleInitial) || string.IsNullOrWhiteSpace(Address) ||
                string.IsNullOrWhiteSpace(City) || string.IsNullOrWhiteSpace(State) || string.IsNullOrWhiteSpace(Zip) || 
                BirthDate == null || SelectedSpecialties.Count == 0)
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

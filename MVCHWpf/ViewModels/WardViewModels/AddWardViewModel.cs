using System;
using System.Collections.ObjectModel;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using MVCHWpf.ViewModels.WardViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.WardViewModels
{
    public class AddWardViewModel : ObservableObject
    {
        private WardListViewModel _wardListViewModel;
        private WardService _wardService;
        private FacilityService _facilityService;
        private PhysicianService _physicianService;
        private EmployeeService _employeeService;
        private WardEmployeeService _wardEmployeeService;

        public AddWardViewModel(WardListViewModel wardListViewModel,
            WardService wardService,
            FacilityService facilityService,
            EmployeeService employeeService,
            WardEmployeeService wardEmployeeService)
        {
            _wardListViewModel = wardListViewModel;
            _wardService = wardService;
            _facilityService = facilityService;
            _wardEmployeeService = wardEmployeeService;
            

            Employees = new ObservableCollection<Employee>(_employeeService.GetEmployees());
            Facilities = new ObservableCollection<Facility>(_facilityService.GetFacilities());
        }

        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Facility> Facilities { get; set; }
        public Facility SelectedFacility { get; set; }
        public ObservableCollection<Employee> SelectedEmployees { get; set; } = new ObservableCollection<Employee>();
   
       

        #region Properties

        public string Name { get; set; }

        #endregion

        public void Add()
        {
            var wardToAdd = new Ward
            {
                Name = Name,
                FacilityId = SelectedFacility.FacilityId
            };
            _wardService.AddWard(wardToAdd);
            if (SelectedEmployees != null) AddWardEmployees(wardToAdd.WardId);
            _wardListViewModel.WardList.Insert(0, new WardViewModel(wardToAdd));
        }

        private void AddWardEmployees(string wardId)
        {
            foreach (var employee in SelectedEmployees)
            {
                //DateAcquired only serves as certification
                var newWardEmployee = new WardEmployee
                {
                    EmployeeId = employee.PersonId,
                    WardId = wardId,
                    DateAssigned = DateTime.Now
                 };
                _wardEmployeeService.AddWardEmployee(newWardEmployee);
            }
            
        }

    }
    }

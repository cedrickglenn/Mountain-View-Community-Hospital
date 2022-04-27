using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using MVCHWpf.ViewModels.Persons.PatientViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.Persons.PhysicianViewModels
{
    public class AddPhysicianViewModel : ObservableObject
    {
        private PhysicianListViewModel _physicianListViewModel;
        private PhysicianService _physicianService;
        private PhysicianSpecialtyService _physicianSpecialtyService;
        private FacilityPhysicianService _facilityPhysicianService;
        private FacilityService _facilityService;
        private SpecialtyService _specialtyService;


        public AddPhysicianViewModel(PhysicianListViewModel physicianListViewModel,
            PhysicianService physicianService,
            FacilityService facilityService,
            SpecialtyService specialtyService,
            PhysicianSpecialtyService physicianSpecialtyService,
            FacilityPhysicianService facilityPhysicianService)
        {
            _physicianListViewModel = physicianListViewModel;
            _physicianService = physicianService;
            _facilityService = facilityService;
            _specialtyService = specialtyService;
            _physicianSpecialtyService = physicianSpecialtyService;
            _facilityPhysicianService = facilityPhysicianService;

            Specialties = new ObservableCollection<Specialty>(_specialtyService.GetSpecialties());
            Facilities = new ObservableCollection<Facility>(_facilityService.GetFacilities());
            SelectedSpecialties = new ObservableCollection<Specialty>();
            SelectedFacilities = new ObservableCollection<Facility>();
        }

        public ObservableCollection<Specialty> Specialties { get; set; }
        public ObservableCollection<Facility> Facilities { get; set; }

        public ObservableCollection<Specialty> SelectedSpecialties { get; set; }
        public ObservableCollection<Facility> SelectedFacilities { get; set; }

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
        public string PagerNumber { get; set; }
        public string DEANumber { get; set; }

        #endregion

        public void Add()
        {
            var physicianToAdd = new Physician
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
                PagerNumber = PagerNumber,
                DEANumber = DEANumber
            };
            _physicianService.AddPhysicians(physicianToAdd);
            AddFacilityPhysicians(physicianToAdd.PersonId);
            AddPhysicianSpecialty(physicianToAdd.PersonId);
            _physicianListViewModel.PhysicianList.Insert(0, new PhysicianViewModel(physicianToAdd));
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


        private void AddPhysicianSpecialty(string personId)
        {
            foreach (var selectedSpecialty in SelectedSpecialties)
            {
                //DateAcquired only serves as certification
                var newPhysicianSpecialty = new PhysicianSpecialty
                {
                    SpecialtyId = selectedSpecialty.SpecialtyId,
                    PhysicianId = personId,
                    DateAcquired = DateTime.Now
                };
                _physicianSpecialtyService.AddPhysicianSpecialty(newPhysicianSpecialty);
            }
        }

        private void AddFacilityPhysicians(string personId)
        {
            foreach (var selectedFacility in SelectedFacilities)
            {
                //Assumes that assigning physicians to their respective facilities are on the same date/time
                //as their registration to the system
                var newFacilityPhysician = new FacilityPhysician
                {
                    FacilityId = selectedFacility.FacilityId,
                    PhysicianId = personId,
                    DateAssigned = DateTime.Now
                };
                _facilityPhysicianService.AddFacilityPhysician(newFacilityPhysician);
            }
        }
    }
    }

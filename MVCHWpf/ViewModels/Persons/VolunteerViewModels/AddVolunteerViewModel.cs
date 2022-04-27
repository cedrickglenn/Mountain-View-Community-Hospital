using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using MVCHWpf.ViewModels.Persons.VolunteerViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;
using Syncfusion.Data.Extensions;

namespace MVCHWpf.ViewModels.Persons.VolunteerViewModels
{
    public class AddVolunteerViewModel : ObservableObject
    {
        private VolunteerListViewModel _volunteerListViewModel;
        private VolunteerService _volunteerService;
        private VolunteerSpecialtyService _volunteerSpecialtyService;
        private SpecialtyService _specialtyService;
        private WorkUnitService _workUnitService;
        private PersonService _personService;


        public AddVolunteerViewModel(VolunteerListViewModel volunteerListViewModel,
            VolunteerService volunteerService,
            PersonService personService,
            WorkUnitService workUnitService,
            SpecialtyService specialtyService,
            VolunteerSpecialtyService volunteerSpecialtyService)
        {
            _volunteerListViewModel = volunteerListViewModel;
            _volunteerService = volunteerService;
            _workUnitService = workUnitService;
            _personService = personService;
            _volunteerSpecialtyService = volunteerSpecialtyService;
            _specialtyService = specialtyService;

            Supervisors = new ObservableCollection<Person>(_personService.GetPersons()
                .Where(c => c.Discriminator == "Physician" ||
                            c.Discriminator == "Nurse" ||
                            c.Discriminator == "Staff" ||
                            c.Discriminator == "Technician"));
            Specialties = new ObservableCollection<Specialty>(_specialtyService.GetSpecialties());
            WorkUnits= new ObservableCollection<WorkUnit>(_workUnitService.GetWorkUnits());
            Hours = new ObservableCollection<int>(new List<int>()
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24});

        }

        public ObservableCollection<int> Hours { get; set; }
        public ObservableCollection<Person> Supervisors { get; set; }
        public ObservableCollection<Specialty> Specialties { get; set; }
        public ObservableCollection<WorkUnit> WorkUnits { get; set; }

        public ObservableCollection<Specialty> SelectedSpecialties { get; set; } = new ObservableCollection<Specialty>();
        public Person SelectedSupervisor { get; set; } 
        public WorkUnit SelectedWorkUnit { get; set; }
       

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
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public int HoursWorked { get; set; }


        #endregion

        public void Add()
        {
            var volunteerToAdd = new Volunteer
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
                StartDate = StartDate,
                EndDate = EndDate,
                HoursWorked = HoursWorked
            };
            if (SelectedSupervisor != null) volunteerToAdd.SupervisorId = SelectedSupervisor.PersonId;
            if (SelectedWorkUnit != null) volunteerToAdd.WorkUnitId = SelectedWorkUnit.WorkUnitId;
            _volunteerService.AddVolunteer(volunteerToAdd);
            if (SelectedSpecialties != null) AddVolunteerSpecialty(volunteerToAdd.PersonId);
            _volunteerListViewModel.VolunteerList.Insert(0, new VolunteerViewModel(volunteerToAdd));
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

        private void AddVolunteerSpecialty(string personId)
        {
            foreach (var selectedSpecialty in SelectedSpecialties)
            {
                //DateAcquired only serves as certification
                var newVolunteerSpecialty = new VolunteerSpecialty
                {
                    SpecialtyId = selectedSpecialty.SpecialtyId,
                    VolunteerId = personId,
                    DateAcquired = DateTime.Now
                 };
                _volunteerSpecialtyService.AddVolunteerSpecialty(newVolunteerSpecialty);
            }
            
        }

    }
    }

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.FacilityViewModels
{
    public class AddFacilityViewModel : ObservableObject
    {
        private FacilityListViewModel _facilityListViewModel;
        private FacilityService _facilityService;
        private PhysicianService _physicianService;
        private FacilityPhysicianService _facilityPhysicianService;


        public AddFacilityViewModel(FacilityListViewModel facilityListViewModel,
            FacilityService facilityService,
            PhysicianService physicianService,
            FacilityPhysicianService facilityPhysicianService)
        {
            _facilityListViewModel = facilityListViewModel;
            _facilityService = facilityService;
            _physicianService = physicianService;
            _facilityPhysicianService = facilityPhysicianService;

            Physicians = new ObservableCollection<Physician>(_physicianService.GetPhysicians());


        }

        public ObservableCollection<Physician> Physicians { get; set; }
        public ObservableCollection<Physician> SelectedPhysicians { get; set; } = new ObservableCollection<Physician>();
   
       

        #region Properties

        public string Name { get; set; }

        #endregion

        public void Add()
        {
            var facilityToAdd = new Facility
            {
                Name = Name
            };
            _facilityService.AddFacility(facilityToAdd);
            if (SelectedPhysicians != null) AddFacilityPhysician(facilityToAdd.FacilityId);
            _facilityListViewModel.FacilityList.Insert(0, new FacilityViewModel(facilityToAdd));
        }

        private void AddFacilityPhysician(string personId)
        {
            foreach (var selectedPhysician in SelectedPhysicians)
            {
                //DateAcquired only serves as certification
                var newFacilityPhysician = new FacilityPhysician
                {
                    PhysicianId = selectedPhysician.PersonId,
                    FacilityId = personId,
                    DateAssigned = DateTime.Now
                 };
                _facilityPhysicianService.AddFacilityPhysician(newFacilityPhysician);
            }
            
        }

    }
    }

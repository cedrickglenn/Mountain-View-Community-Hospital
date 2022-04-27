using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MVCHWpf.ViewModels.Persons.VolunteerViewModels;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.FacilityViewModels
{
    public class FacilityListViewModel
    {
        private FacilityService _facilityService;
        
        public ObservableCollection<FacilityViewModel> FacilityList { get; set; }

        public FacilityListViewModel(FacilityService facilityService)
        {
            _facilityService = facilityService;

            FacilityList = new ObservableCollection<FacilityViewModel>(_facilityService
                .GetFacilities()
                .Select(c => new FacilityViewModel(c)));
        }
    }
}

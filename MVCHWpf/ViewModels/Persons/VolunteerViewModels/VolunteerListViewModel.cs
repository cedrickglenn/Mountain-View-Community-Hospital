using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MVCHWpf.ViewModels.Persons.VolunteerViewModels;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.Persons.VolunteerViewModels
{
    public class VolunteerListViewModel
    {
        private VolunteerService _volunteerService;
        
        public ObservableCollection<VolunteerViewModel> VolunteerList { get; set; }

        public VolunteerListViewModel(VolunteerService volunteerService)
        {
            _volunteerService = volunteerService;

            VolunteerList = new ObservableCollection<VolunteerViewModel>(_volunteerService
                .GetVolunteers()
                .Include(c=>c.SupervisorLink)
                .Include(c=>c.WorkUnitLink)
                .Select(c => new VolunteerViewModel(c)));
        }
    }
}

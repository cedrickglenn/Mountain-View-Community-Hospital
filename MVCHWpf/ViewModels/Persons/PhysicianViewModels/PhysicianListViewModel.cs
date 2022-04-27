using System.Collections.ObjectModel;
using System.Linq;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.Persons.PhysicianViewModels
{
    public class PhysicianListViewModel
    {
        private PhysicianService _physicianService;
        private string _searchText;
        


        public ObservableCollection<PhysicianViewModel> PhysicianList { get; set; }

        public PhysicianListViewModel(PhysicianService physicianService)
        {
            _physicianService = physicianService;

            PhysicianList = new ObservableCollection<PhysicianViewModel>(_physicianService
                .GetPhysicians()
                .Select(c => new PhysicianViewModel(c)));
        }
    }
}

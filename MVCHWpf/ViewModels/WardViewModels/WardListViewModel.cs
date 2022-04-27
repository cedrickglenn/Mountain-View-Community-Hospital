using System.Collections.ObjectModel;
using System.Linq;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.WardViewModels
{
    public class WardListViewModel
    {
        private WardService _wardService;
        
        public ObservableCollection<WardViewModel> WardList { get; set; }

        public WardListViewModel(WardService wardService)
        {
            _wardService = wardService;

            WardList = new ObservableCollection<WardViewModel>(_wardService
                .GetWards()
                .Select(c => new WardViewModel(c)));
        }
    }
}

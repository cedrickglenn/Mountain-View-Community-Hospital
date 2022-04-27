using System.Collections.ObjectModel;
using System.Linq;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.Persons.TechnicianViewModels
{
    public class TechnicianListViewModel
    {
        private EmployeeService _employeeService;
        
        public ObservableCollection<TechnicianViewModel> TechnicianList { get; set; }

        public TechnicianListViewModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;

            TechnicianList = new ObservableCollection<TechnicianViewModel>(_employeeService
                .GetTechnicians()
                .Select(c => new TechnicianViewModel(c)));
        }
    }
}

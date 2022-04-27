using System.Collections.ObjectModel;
using System.Linq;
using MVCHWpf.ViewModels.Persons.NurseViewModels;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.Persons.NurseViewModels
{
    public class NurseListViewModel
    {
        private EmployeeService _employeeService;
        
        public ObservableCollection<NurseViewModel> NurseList { get; set; }

        public NurseListViewModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;

            NurseList = new ObservableCollection<NurseViewModel>(_employeeService
                .GetNurses()
                .Select(c => new NurseViewModel(c)));
        }
    }
}

using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MVCHWpf.ViewModels.Persons.PhysicianViewModels;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.Persons.StaffViewModels
{
    public class StaffListViewModel
    {
        private EmployeeService _employeeService;
        
        public ObservableCollection<StaffViewModel> StaffList { get; set; }

        public StaffListViewModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;

            StaffList = new ObservableCollection<StaffViewModel>(_employeeService
                .GetStaff()
                .Include(c=>c.JobClassLink)
                .Select(c => new StaffViewModel(c)));
        }
    }
}

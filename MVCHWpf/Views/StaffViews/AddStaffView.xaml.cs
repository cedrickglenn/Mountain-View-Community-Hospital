using System;
using System.Windows;
using MVCHWpf.ViewModels.Persons.PatientViewModels;
using MVCHWpf.ViewModels.Persons.StaffViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.StaffViews
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddStaffView : Window
    {
        private AddStaffViewModel _toAddStaff;

        public AddStaffView()
        {
            InitializeComponent();

        }

        public AddStaffView(StaffListViewModel staffListViewModel, 
            EmployeeService employeeService,
            WardService wardService,
            WorkUnitService workUnitService,
            SpecialtyService specialtyService,
            JobClassService jobClassService,
            EmployeeSpecialtyService employeeSpecialtyService,
            WardEmployeeService wardEmployeeService,
            UnitEmployeeService unitEmployeeService)
        {
            _toAddStaff = new AddStaffViewModel(staffListViewModel,
                employeeService,
                wardService,
                workUnitService,
                specialtyService,
                jobClassService,
                employeeSpecialtyService,
                wardEmployeeService,
                unitEmployeeService);
            DataContext = _toAddStaff;
            InitializeComponent();
        }

        
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_toAddStaff.CheckFirst())
            {
                _toAddStaff.Add();
                Close();
            }
        }


    }
}

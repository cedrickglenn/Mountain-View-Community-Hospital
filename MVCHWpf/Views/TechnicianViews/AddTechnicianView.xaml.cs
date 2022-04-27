using System;
using System.Windows;
using MVCHWpf.ViewModels.Persons.TechnicianViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.TechnicianViews
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddTechnicianView : Window
    {
        private AddTechnicianViewModel _toAddTechnician;
        public AddTechnicianView()
        {
            InitializeComponent();

        }

        public AddTechnicianView(TechnicianListViewModel technicianListViewModel, 
            EmployeeService employeeService,
            WardService wardService,
            WorkUnitService workUnitService,
            SpecialtyService specialtyService,
            EmployeeSpecialtyService employeeSpecialtyService,
            WardEmployeeService wardEmployeeService,
            UnitEmployeeService unitEmployeeService)
        {
            _toAddTechnician = new AddTechnicianViewModel(technicianListViewModel, 
                employeeService,
                wardService,
                workUnitService,
                specialtyService,
                employeeSpecialtyService,
                wardEmployeeService,
                unitEmployeeService);
            DataContext = _toAddTechnician;
            InitializeComponent();
        }

  
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_toAddTechnician.CheckFirst())
            {
                _toAddTechnician.Add();
                Close();
            }
        }


    }
}

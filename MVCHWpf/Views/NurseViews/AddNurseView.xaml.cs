using System;
using System.Windows;
using MVCHWpf.ViewModels.Persons.NurseViewModels;
using MVCHWpf.ViewModels.Persons.NurseViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.NurseViews
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddNurseView : Window
    {
        private AddNurseViewModel _toAddNurse;
        private string _nurseDegree = "RN";
        public AddNurseView()
        {
            InitializeComponent();

        }

        public AddNurseView(NurseListViewModel nurseListViewModel,
            EmployeeService employeeService,
            WardService wardService,
            WorkUnitService workUnitService,
            SpecialtyService specialtyService,
            EmployeeSpecialtyService employeeSpecialtyService,
            WardEmployeeService wardEmployeeService,
            UnitEmployeeService unitEmployeeService)
        {
            _toAddNurse = new AddNurseViewModel(nurseListViewModel,
                employeeService,
                wardService,
                workUnitService,
                specialtyService,
                employeeSpecialtyService,
                wardEmployeeService,
                unitEmployeeService);
            DataContext = _toAddNurse;
            InitializeComponent();

            //default
            RnSelectButton.IsChecked = true;
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_toAddNurse.CheckFirst())
            {
                _toAddNurse.Add(_nurseDegree);
                Close();
            }
            
           
        }


        private void RnSelectButton_Click(object sender, RoutedEventArgs e)
        {
            LpnSelectButton.IsChecked = false;
            RnSelectButton.IsChecked = true;
            _nurseDegree = "RN";
        }

        private void LpNSelectButton_Click(object sender, RoutedEventArgs e)
        {
            LpnSelectButton.IsChecked = true;
            RnSelectButton.IsChecked = false;
            _nurseDegree = "LPN";
        }
    }
}

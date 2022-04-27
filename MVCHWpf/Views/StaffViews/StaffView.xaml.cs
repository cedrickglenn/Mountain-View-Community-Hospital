using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Datalayer.EFClasses;
using MVCHWpf.ViewModels.Persons.PhysicianViewModels;
using MVCHWpf.ViewModels.Persons.StaffViewModels;
using MVCHWpf.Views.PhysicianViews;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.StaffViews
{
    /// <summary>
    /// Interaction logic for StaffView.xaml
    /// </summary>
    public partial class StaffView : UserControl
    {
        private StaffListViewModel _staffListViewModel;
        private SpecialtyService _specialtyService;
        private EmployeeService _employeeService;
        private WardService _wardService;
        private WorkUnitService _workUnitService;
        private WardEmployeeService _wardEmployeeService;
        private UnitEmployeeService _unitEmployeeService;
        private EmployeeSpecialtyService _employeeSpecialtyService;
        private JobClassService _jobClassService;


        public StaffView()
        {
            InitializeComponent();
            _employeeService = new EmployeeService(new MVCHContext());
            _staffListViewModel = new StaffListViewModel(_employeeService);
            _specialtyService = new SpecialtyService(new MVCHContext());
            _employeeSpecialtyService = new EmployeeSpecialtyService(new MVCHContext());
            _wardService = new WardService(new MVCHContext());
            _workUnitService = new WorkUnitService(new MVCHContext());
            _wardEmployeeService = new WardEmployeeService(new MVCHContext());
            _unitEmployeeService = new UnitEmployeeService(new MVCHContext());
            _jobClassService = new JobClassService(new MVCHContext());
            DataContext = _staffListViewModel;
        }


        private void AddStaffButton_Onclick(object sender, RoutedEventArgs e)
        {
            var addStaffView = new AddStaffView(_staffListViewModel,
                _employeeService,
                _wardService,
                _workUnitService,
                _specialtyService,
                _jobClassService,
                _employeeSpecialtyService,
                _wardEmployeeService,
                _unitEmployeeService);

            addStaffView.Show();

        }


        private void StaffGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (StaffViewModel)StaffGrid.SelectedItem;
            if (row == null)
            {
                e.Handled = true;
                return;
            }
        }


        private void SearchStaffBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            StaffGrid.SearchHelper.AllowFiltering = true;
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                StaffGrid.SearchHelper.Search(SearchStaffBox.Text);
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void SearchStaffBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            StaffGrid.SearchHelper.AllowFiltering = true;
            StaffGrid.SearchHelper.Search(SearchStaffBox.Text);
            e.Handled = true;
        }
    }
}

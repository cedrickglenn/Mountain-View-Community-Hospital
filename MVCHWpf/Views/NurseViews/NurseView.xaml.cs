using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Datalayer.EFClasses;
using MVCHWpf.ViewModels.Persons.NurseViewModels;
using MVCHWpf.Views.NurseViews;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.NurseViews
{
    /// <summary>
    /// Interaction logic for NurseView.xaml
    /// </summary>
    public partial class NurseView : UserControl
    {
        private NurseListViewModel _nurseListViewModel;
        private SpecialtyService _specialtyService;
        private EmployeeService _employeeService;
        private WardService _wardService;
        private WorkUnitService _workUnitService;
        private WardEmployeeService _wardEmployeeService;
        private UnitEmployeeService _unitEmployeeService;
        private EmployeeSpecialtyService _employeeSpecialtyService;
        private JobClassService _jobClassService;


        public NurseView()
        {
            InitializeComponent();
            _employeeService = new EmployeeService(new MVCHContext());
            _nurseListViewModel = new NurseListViewModel(_employeeService);
            _specialtyService = new SpecialtyService(new MVCHContext());
            _employeeSpecialtyService = new EmployeeSpecialtyService(new MVCHContext());
            _wardService = new WardService(new MVCHContext());
            _workUnitService = new WorkUnitService(new MVCHContext());
            _wardEmployeeService = new WardEmployeeService(new MVCHContext());
            _unitEmployeeService = new UnitEmployeeService(new MVCHContext());
            _jobClassService = new JobClassService(new MVCHContext());
            DataContext = _nurseListViewModel;
        }


        private void AddNurseButton_Onclick(object sender, RoutedEventArgs e)
        {
            var addNurseView = new AddNurseView(_nurseListViewModel,
                _employeeService,
                _wardService,
                _workUnitService,
                _specialtyService,
                _employeeSpecialtyService,
                _wardEmployeeService,
                _unitEmployeeService);

            addNurseView.Show();

        }


        private void NurseGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (NurseViewModel)NurseGrid.SelectedItem;
            if (row == null)
            {
                e.Handled = true;
                return;
            }
        }


        private void SearchNurseBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            NurseGrid.SearchHelper.AllowFiltering = true;
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                NurseGrid.SearchHelper.Search(SearchNurseBox.Text);
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void SearchNurseBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NurseGrid.SearchHelper.AllowFiltering = true;
            NurseGrid.SearchHelper.Search(SearchNurseBox.Text);
            e.Handled = true;
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Datalayer.EFClasses;
using MVCHWpf.ViewModels.Persons.TechnicianViewModels;
using MVCHWpf.Views.TechnicianViews;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.TechnicianViews
{
    /// <summary>
    /// Interaction logic for TechnicianView.xaml
    /// </summary>
    public partial class TechnicianView : UserControl
    {
        private TechnicianListViewModel _technicianListViewModel;
        private SpecialtyService _specialtyService;
        private EmployeeService _employeeService;
        private WardService _wardService;
        private WorkUnitService _workUnitService;
        private WardEmployeeService _wardEmployeeService;
        private UnitEmployeeService _unitEmployeeService;
        private EmployeeSpecialtyService _employeeSpecialtyService;
        private JobClassService _jobClassService;


        public TechnicianView()
        {
            InitializeComponent();
            _employeeService = new EmployeeService(new MVCHContext());
            _technicianListViewModel = new TechnicianListViewModel(_employeeService);
            _specialtyService = new SpecialtyService(new MVCHContext());
            _employeeSpecialtyService = new EmployeeSpecialtyService(new MVCHContext());
            _wardService = new WardService(new MVCHContext());
            _workUnitService = new WorkUnitService(new MVCHContext());
            _wardEmployeeService = new WardEmployeeService(new MVCHContext());
            _unitEmployeeService = new UnitEmployeeService(new MVCHContext());
            _jobClassService = new JobClassService(new MVCHContext());
            DataContext = _technicianListViewModel;
        }


        private void AddTechnicianButton_Onclick(object sender, RoutedEventArgs e)
        {
            var addTechnicianView = new AddTechnicianView(_technicianListViewModel,
                _employeeService,
                _wardService,
                _workUnitService,
                _specialtyService,
                _employeeSpecialtyService,
                _wardEmployeeService,
                _unitEmployeeService);

            addTechnicianView.Show();

        }


        private void TechnicianGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (TechnicianViewModel)TechnicianGrid.SelectedItem;
            if (row == null)
            {
                e.Handled = true;
                return;
            }
        }


        private void SearchTechnicianBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            TechnicianGrid.SearchHelper.AllowFiltering = true;
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                TechnicianGrid.SearchHelper.Search(SearchTechnicianBox.Text);
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void SearchTechnicianBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TechnicianGrid.SearchHelper.AllowFiltering = true;
            TechnicianGrid.SearchHelper.Search(SearchTechnicianBox.Text);
            e.Handled = true;
        }
    }
}

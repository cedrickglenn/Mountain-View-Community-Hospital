using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Datalayer.EFClasses;
using MVCHWpf.ViewModels.WardViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.WardViews
{
    /// <summary>
    /// Interaction logic for WardView.xaml
    /// </summary>
    public partial class WardView : UserControl
    {
        private WardListViewModel _wardListViewModel;
        private WardService _wardService;
        private PhysicianService _physicianService;
        private FacilityService _facilityService;
        private EmployeeService _employeeService;
        private WardEmployeeService _wardEmployeeService;


        public WardView()
        {
            InitializeComponent();
            _wardService = new WardService(new MVCHContext());
            _wardListViewModel = new WardListViewModel(_wardService);
            _physicianService = new PhysicianService(new MVCHContext());
            _facilityService = new FacilityService(new MVCHContext());
            _employeeService = new EmployeeService(new MVCHContext());
            _wardEmployeeService =new WardEmployeeService(new MVCHContext());
            DataContext = _wardListViewModel;
        }


        private void AddWardButton_Onclick(object sender, RoutedEventArgs e)
        {
            var addWardView = new AddWardView(_wardListViewModel,
                _wardService,
                _facilityService,
                _employeeService,
                _wardEmployeeService);
           

            addWardView.Show();

        }


        private void SearchWardBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            WardGrid.SearchHelper.AllowFiltering = true;
            WardGrid.SearchHelper.Search(SearchWardBox.Text);
        }

        private void Ward_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var row = (WardViewModel)WardGrid.SelectedItem;
            if (row == null)
            {
                e.Handled = true;
                return;
            }
        }
    }
}

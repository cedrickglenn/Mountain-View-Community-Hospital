using System.Windows;
using MVCHWpf.ViewModels.WardViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.WardViews
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddWardView : Window
    {
        private AddWardViewModel _toAddWard;
     
        public AddWardView()
        {
            InitializeComponent();
        }

        public AddWardView(WardListViewModel wardListViewModel,
            WardService wardService,
            FacilityService facilityService,
            EmployeeService employeeService,
            WardEmployeeService wardEmployeeService)
        {
            _toAddWard = new AddWardViewModel(wardListViewModel,
                wardService,
                facilityService,
                employeeService,
                wardEmployeeService);
            DataContext = _toAddWard;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _toAddWard.Add();
            Close();
        }



    }
}

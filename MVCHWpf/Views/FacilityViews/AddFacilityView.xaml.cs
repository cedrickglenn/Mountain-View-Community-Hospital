using System.Windows;
using MVCHWpf.ViewModels.FacilityViewModels;
using MVCHWpf.ViewModels.Persons.PatientViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.FacilityViews
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddFacilityView : Window
    {
        private AddFacilityViewModel _toAddFacility;
     
        public AddFacilityView()
        {
            InitializeComponent();
        }

        public AddFacilityView(FacilityListViewModel facilityListViewModel,
            FacilityService facilityService,
            PhysicianService physicianService,
            FacilityPhysicianService facilityPhysicianService)
        {
            _toAddFacility = new AddFacilityViewModel(facilityListViewModel,
                facilityService,
                physicianService,
                facilityPhysicianService);
            DataContext = _toAddFacility;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _toAddFacility.Add();
            Close();
        }


    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Datalayer.EFClasses;
using MVCHWpf.ViewModels.FacilityViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.FacilityViews
{
    /// <summary>
    /// Interaction logic for FacilityGridView.xaml
    /// </summary>
    public partial class FacilityGridView : UserControl
    {
        private FacilityListViewModel _facilityListViewModel;
        private FacilityService _facilityService;
        private PhysicianService _physicianService;
        private FacilityPhysicianService _facilityPhysicianService;

        public FacilityGridView()
        {
            InitializeComponent();
            _facilityService = new FacilityService(new MVCHContext());
            _facilityListViewModel = new FacilityListViewModel(_facilityService);
            _physicianService = new PhysicianService(new MVCHContext());
            _facilityPhysicianService = new FacilityPhysicianService(new MVCHContext());
      
           
            DataContext = _facilityListViewModel;
        }


        private void AddFacilityButton_Onclick(object sender, RoutedEventArgs e)
        {
            var addFacilityGridView = new AddFacilityView(_facilityListViewModel,
                _facilityService,
                _physicianService,
                _facilityPhysicianService);

            addFacilityGridView.Show();

        }


        private void FacilityGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (FacilityViewModel)FacilityGrid.SelectedItem;
            if (row == null)
            {
                e.Handled = true;
                return;
            }
        }


        private void SearchFacilityBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            FacilityGrid.SearchHelper.AllowFiltering = true;
            FacilityGrid.SearchHelper.Search(SearchFacilityBox.Text);
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Datalayer.EFClasses;
using MVCHWpf.ViewModels;
using MVCHWpf.ViewModels.Persons;
using MVCHWpf.ViewModels.Persons.PhysicianViewModels;
using MVCHWpf.Views.PatientViews;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.PhysicianViews
{
    /// <summary>
    /// Interaction logic for PhysicianView.xaml
    /// </summary>
    public partial class PhysicianView : UserControl
    {
        private PhysicianListViewModel _physicianListViewModel;
        private PhysicianService _physicianService;
        private SpecialtyService _specialtyService;
        private FacilityService _facilityService;
        private PhysicianSpecialtyService _physicianSpecialtyService;
        private FacilityPhysicianService _facilityPhysicianService;


        public PhysicianView()
        {
            InitializeComponent();
            _physicianService = new PhysicianService(new MVCHContext());
            _physicianListViewModel = new PhysicianListViewModel(_physicianService);
            _specialtyService = new SpecialtyService(new MVCHContext());
            _facilityService = new FacilityService(new MVCHContext());
            _physicianSpecialtyService = new PhysicianSpecialtyService(new MVCHContext());
            _facilityPhysicianService = new FacilityPhysicianService(new MVCHContext());
            DataContext = _physicianListViewModel;
        }


        private void AddPhysicianButton_Onclick(object sender, RoutedEventArgs e)
        {
            var addPhysiciantView = new AddPhysicianView(_physicianListViewModel,
                _physicianService,
                _physicianSpecialtyService,
                _specialtyService,
                _facilityService,
                _facilityPhysicianService);

            addPhysiciantView.Show();

        }


        private void PhysicianGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (PhysicianViewModel)PhysicianGrid.SelectedItem;
            if (row == null)
            {
                e.Handled = true;
                return;
            }
        }

        private void SearchPhysicianBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            PhysicianGrid.SearchHelper.AllowFiltering = true;
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                PhysicianGrid.SearchHelper.Search(SearchPhysicianBox.Text);
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void SearchPhysicianBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            PhysicianGrid.SearchHelper.AllowFiltering = true;
            PhysicianGrid.SearchHelper.Search(SearchPhysicianBox.Text);
            e.Handled = true;
        }
    }
}

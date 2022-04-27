using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Datalayer.EFClasses;
using MVCHWpf.ViewModels.Persons.VolunteerViewModels;
using MVCHWpf.Views.VolunteerViews;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.VolunteerViews
{
    /// <summary>
    /// Interaction logic for VolunteerView.xaml
    /// </summary>
    public partial class VolunteerView : UserControl
    {
        private VolunteerListViewModel _volunteerListViewModel;
        private SpecialtyService _specialtyService;
        private VolunteerService _volunteerService;
        private WorkUnitService _workUnitService;
        private VolunteerSpecialtyService _volunteerSpecialtyService;
        private PersonService _personService;

        public VolunteerView()
        {
            InitializeComponent();
            _volunteerService = new VolunteerService(new MVCHContext());
            _volunteerListViewModel = new VolunteerListViewModel(_volunteerService);
            _specialtyService = new SpecialtyService(new MVCHContext());
            _volunteerSpecialtyService = new VolunteerSpecialtyService(new MVCHContext());
            _workUnitService = new WorkUnitService(new MVCHContext());
            _personService = new PersonService(new MVCHContext());
            DataContext = _volunteerListViewModel;
        }


        private void AddVolunteerButton_Onclick(object sender, RoutedEventArgs e)
        {
            var addVolunteerView = new AddVolunteerView(_volunteerListViewModel,
                _volunteerService,
                _personService,
                _workUnitService,
                _specialtyService,
                _volunteerSpecialtyService);

            addVolunteerView.Show();

        }


        private void VolunteerGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (VolunteerViewModel)VolunteerGrid.SelectedItem;
            if (row == null)
            {
                e.Handled = true;
                return;
            }
        }


        private void SearchVolunteerBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            VolunteerGrid.SearchHelper.AllowFiltering = true;
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                VolunteerGrid.SearchHelper.Search(SearchVolunteerBox.Text);
             
            }
          
        }

        private void SearchVolunteerBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            VolunteerGrid.SearchHelper.AllowFiltering = true;
            VolunteerGrid.SearchHelper.Search(SearchVolunteerBox.Text);
            
        }
    }
}

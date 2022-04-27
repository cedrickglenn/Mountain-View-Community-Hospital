using System;
using System.Windows;
using MVCHWpf.ViewModels.Persons.PatientViewModels;
using MVCHWpf.ViewModels.Persons.VolunteerViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.VolunteerViews
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddVolunteerView : Window
    {
        private AddVolunteerViewModel _toAddVolunteer;

        public AddVolunteerView()
        {
            InitializeComponent();

        }

        public AddVolunteerView(VolunteerListViewModel volunteerListViewModel, 
            VolunteerService volunteerService,
            PersonService personService, 
            WorkUnitService workUnitService,
            SpecialtyService specialtyService,
            VolunteerSpecialtyService volunteerSpecialtyService)
        {
            _toAddVolunteer = new AddVolunteerViewModel(volunteerListViewModel, 
                volunteerService, 
                personService,
                workUnitService,
                specialtyService,
                volunteerSpecialtyService);
            DataContext = _toAddVolunteer;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_toAddVolunteer.CheckFirst())
            {
                _toAddVolunteer.Add();
                Close();
            }
        }


    }
}

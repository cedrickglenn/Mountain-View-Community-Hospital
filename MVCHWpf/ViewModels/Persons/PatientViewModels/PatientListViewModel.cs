using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using MVCHWpf.Views.PatientViews;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.Persons.PatientViewModels
{
    public class PatientListViewModel
    {
        private PatientService _patientService;
        private CombinedPatientViewModel _selectedPatient;
        private string _searchText;
        public CombinedPatientViewModel SelectedPatient
        {
            get => _selectedPatient;
            set { _selectedPatient = value; }
        }
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchPatient(_searchText);
            }
        }

        private void SearchPatient(string searchString)
        {
            PatientList.Clear();
            var inpatients = _patientService.GetInpatients()
                .Where(c => c.FirstName.Contains(searchString) ||
                                   c.LastName.Contains(searchString) ||
                                    c.MiddleInitial.Contains(searchString) ||
                                    c.Address.Contains(searchString) ||
                                    c.City.Contains(searchString) ||
                                    c.State.Contains(searchString));
            var outpatients = _patientService.GetOutpatients()
                .Where(c => c.FirstName.Contains(searchString) ||
                            c.LastName.Contains(searchString) ||
                            c.MiddleInitial.Contains(searchString) ||
                            c.Address.Contains(searchString) ||
                            c.City.Contains(searchString) ||
                            c.State.Contains(searchString));
            foreach (var patient in inpatients)
            {
                var patientModel = new CombinedPatientViewModel(patient);
                PatientList.Add(patientModel);
            }
            foreach (var patient in outpatients)
            {
                var patientModel = new CombinedPatientViewModel(patient);
                PatientList.Add(patientModel);
            }
        }

        public ObservableCollection<CombinedPatientViewModel> PatientList { get; set; }
        public PatientListViewModel(PatientService patientService)
        {
            _patientService = patientService;

            // get all inPatients first
            var inPatients = _patientService.GetInpatients().ToList();
            var outPatients = _patientService.GetOutpatients().ToList();
            PatientList = new ObservableCollection<CombinedPatientViewModel>();
            foreach (var item in inPatients)
            {
                PatientList.Add(new CombinedPatientViewModel(item));
            }
            foreach (var item in outPatients)
            {
                PatientList.Add(new CombinedPatientViewModel(item));
            }
        }
       

    }
}

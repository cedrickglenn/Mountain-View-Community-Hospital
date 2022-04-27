using System.Collections.ObjectModel;
using System.Linq;
using Servicelayer.AssociativeClassService;

namespace MVCHWpf.ViewModels.DiagnosisViewModels
{
    public class DiagnosisListViewModel
    {
        private DiagnosisViewModel _selectedDiagnosis;
        private string _searchText;
        private DiagnosisService _diagnosisService;
        private string _patientId;

        public DiagnosisViewModel SelectedDiagnosis
        {
            get => _selectedDiagnosis;
            set { _selectedDiagnosis = value; }
        }
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchDiagnosis(_searchText);
            }
        }

        private void SearchDiagnosis(string searchString)
        {
            DiagnosisList.Clear();

            var diagnoses = _diagnosisService.GetDiagnoses()
                .Where(c => (c.ConditionLink.Name.Contains(searchString) ||
                            c.Description.Contains(searchString) ||
                            c.PhysicianLink.FirstName.Contains(searchString) ||
                            c.PhysicianLink.LastName.Contains(searchString)) &&
                            c.PatientId == _patientId).ToList();
            foreach (var diagnosis in diagnoses)
            {
                var diagnosisModel = new DiagnosisViewModel(diagnosis);
                DiagnosisList.Add(diagnosisModel);
            }
        }

        public ObservableCollection<DiagnosisViewModel> DiagnosisList { get; set; }
        public DiagnosisListViewModel(DiagnosisService diagnosisService,string patientId)
        {
            _diagnosisService = diagnosisService;
            _patientId = patientId;
            var diagnoses = _diagnosisService.GetDiagnoses()
                .Where(c=>c.PatientId == patientId).ToList();
            DiagnosisList = new ObservableCollection<DiagnosisViewModel>();
            foreach (var item in diagnoses)
            {
                DiagnosisList.Add(new DiagnosisViewModel(item));
            }
            
        }
       

    }
}

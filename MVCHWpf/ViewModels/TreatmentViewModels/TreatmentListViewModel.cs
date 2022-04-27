using System.Collections.ObjectModel;
using System.Linq;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.TreatmentViewModels
{
    public class TreatmentListViewModel
    {
        private TreatmentViewModel _selectedTreatment;
        private string _searchText;
        private TreatmentService _treatmentService;
        private string _patientId;

        public TreatmentViewModel SelectedTreatment
        {
            get => _selectedTreatment;
            set { _selectedTreatment = value; }
        }
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchTreatment(_searchText);
            }
        }

        private void SearchTreatment(string searchString)
        {
            TreatmentList.Clear();

            var treatments = _treatmentService.GetTreatments()
                .Where(c => (c.ProcedureLink.Name.Contains(searchString) ||
                            c.Description.Contains(searchString) ||
                            c.PhysicianLink.FirstName.Contains(searchString) ||
                            c.PhysicianLink.LastName.Contains(searchString)) &&
                            c.PatientId == _patientId).ToList();
            foreach (var treatment in treatments)
            {
                var treatmentModel = new TreatmentViewModel(treatment);
                TreatmentList.Add(treatmentModel);
            }
        }

        public ObservableCollection<TreatmentViewModel> TreatmentList { get; set; }
        public TreatmentListViewModel(TreatmentService treatmentService,string patientId)
        {
            _treatmentService = treatmentService;
            _patientId = patientId;
            var treatments = _treatmentService.GetTreatments()
                .Where(c=>c.PatientId == patientId).ToList();
            TreatmentList = new ObservableCollection<TreatmentViewModel>();
            foreach (var item in treatments)
            {
                TreatmentList.Add(new TreatmentViewModel(item));
            }
            
        }
       

    }
}

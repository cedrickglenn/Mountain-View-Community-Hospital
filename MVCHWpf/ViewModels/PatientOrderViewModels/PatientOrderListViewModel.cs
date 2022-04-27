using System.Collections.ObjectModel;
using System.Linq;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.ViewModels.PatientOrderViewModels
{
    public class PatientOrderListViewModel
    {
      
        private PatientOrderService _patientOrderService;

        private string _patientId;
        private PatientOrderViewModel _selectedPatientOrder;

        public PatientOrderViewModel SelectedPatientOrder
        {
            get => _selectedPatientOrder;
            set { _selectedPatientOrder = value; }
        }

        public ObservableCollection<PatientOrderViewModel> PatientOrderList { get; set; }
        public PatientOrderListViewModel(PatientOrderService patientOrderService ,string patientId)
        {
            _patientOrderService = patientOrderService;
            _patientId = patientId;
            var orders = _patientOrderService.GetPatientOrders()
                .Where(c=>c.PatientId == patientId).ToList();
            PatientOrderList = new ObservableCollection<PatientOrderViewModel>();
            foreach (var item in orders)
            {
                PatientOrderList.Add(new PatientOrderViewModel(item));
            }
            
        }
       

    }
}

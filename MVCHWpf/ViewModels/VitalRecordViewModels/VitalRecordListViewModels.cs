using System.Collections.ObjectModel;
using System.Linq;
using MVCHWpf.ViewModels.VitalRecordViewModels;
using Servicelayer.AssociativeClassService;

namespace MVCHWpf.ViewModels.VitalRecordViewModels
{
    public class VitalRecordListViewModel
    {
        private VitalRecordViewModel _selectedHeight;
        private VitalRecordService _vitalRecordService;
        private string _patientId;
        private VitalRecordViewModel _selectedTemperature;
        private VitalRecordViewModel _selectedPulse;
        private VitalRecordViewModel _selectedWeight;
        private VitalRecordViewModel _selectedBloodPressure;

        public VitalRecordViewModel SelectedHeight
        {
            get => _selectedHeight;
            set { _selectedHeight = value; }
        }
        public VitalRecordViewModel SelectedWeight
        {
            get => _selectedWeight;
            set { _selectedWeight = value; }
        }
        public VitalRecordViewModel SelectedBloodPressure
        {
            get => _selectedBloodPressure;
            set { _selectedBloodPressure = value; }
        }
        public VitalRecordViewModel SelectedPulse
        {
            get => _selectedPulse;
            set { _selectedPulse = value; }
        }
        public VitalRecordViewModel SelectedTemperature
        {
            get => _selectedTemperature;
            set { _selectedTemperature = value; }
        }
        
        public ObservableCollection<VitalRecordViewModel> HeightList { get; set; }
        public ObservableCollection<VitalRecordViewModel> WeightList { get; set; }
        public ObservableCollection<VitalRecordViewModel> BloodPressureList { get; set; }
        public ObservableCollection<VitalRecordViewModel> PulseList { get; set; }
        public ObservableCollection<VitalRecordViewModel> TemperatureList { get; set; }
        public VitalRecordListViewModel(VitalRecordService vitalRecordService,string patientId)
        {
            _vitalRecordService = vitalRecordService;
            _patientId = patientId;
            var heightRecords = _vitalRecordService.GetVitalRecords()
                .Where(c=>c.PatientId == patientId && c.VitalId == "VTL-000001").ToList();
            var weightRecords = _vitalRecordService.GetVitalRecords()
                .Where(c=>c.PatientId == patientId && c.VitalId == "VTL-000002").ToList();
            var bloodPressureRecords = _vitalRecordService.GetVitalRecords()
                .Where(c=>c.PatientId == patientId && c.VitalId == "VTL-000003").ToList();
            var pulseRecords = _vitalRecordService.GetVitalRecords()
                .Where(c=>c.PatientId == patientId && c.VitalId == "VTL-000004").ToList();
            var temperatureRecords = _vitalRecordService.GetVitalRecords()
                .Where(c=>c.PatientId == patientId && c.VitalId == "VTL-000005").ToList();
            HeightList = new ObservableCollection<VitalRecordViewModel>();
            WeightList = new ObservableCollection<VitalRecordViewModel>();
            BloodPressureList = new ObservableCollection<VitalRecordViewModel>();
            PulseList = new ObservableCollection<VitalRecordViewModel>();
            TemperatureList = new ObservableCollection<VitalRecordViewModel>();
            foreach (var item in heightRecords)
            {
                HeightList.Add(new VitalRecordViewModel(item));
            }
            foreach (var item in weightRecords)
            {
                WeightList.Add(new VitalRecordViewModel(item));
            }
            foreach (var item in bloodPressureRecords)
            {
                BloodPressureList.Add(new VitalRecordViewModel(item));
            }
            foreach (var item in pulseRecords)
            {
                PulseList.Add(new VitalRecordViewModel(item));
            }
            foreach (var item in temperatureRecords)
            {
                TemperatureList.Add(new VitalRecordViewModel(item));
            }
            
            
        }
       

    }
}

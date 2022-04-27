using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MVCHWpf.ViewModels.VitalRecordViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.VitalRecordViews
{
    /// <summary>
    /// Interaction logic for VitalRecordView.xaml
    /// </summary>
    public partial class VitalRecordView : UserControl
    {
        private VitalRecordService _vitalRecordService;

        public VitalRecordView()
        {
            InitializeComponent();
        }

        public VitalRecordView(VitalRecordService vitalRecordService, string patientId, EmployeeService nurseService)
        {
            InitializeComponent();
            _vitalRecordService = vitalRecordService;
            var vitalRecordListViewModel = new VitalRecordListViewModel(_vitalRecordService,patientId);
            DataContext = vitalRecordListViewModel;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void VitalRecordGrid_OnMouseDoubleClickGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void HeightGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void WeightGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BpGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PulseGrid_OnMouseDoubleClickGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TemperatureGrid_OnMouseDoubleClickGrid_OnMouseDoubleClickGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddBloodPressureButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddPulseButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddTemperatureButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddHeightButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddWeightButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

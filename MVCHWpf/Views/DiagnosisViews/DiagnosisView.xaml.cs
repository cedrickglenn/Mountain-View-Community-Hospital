using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MVCHWpf.ViewModels.DiagnosisViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.DiagnosisViews
{
    /// <summary>
    /// Interaction logic for DiagnosisView.xaml
    /// </summary>
    public partial class DiagnosisView : UserControl
    {
        private DiagnosisService _diagnosisService;

        public DiagnosisView()
        {
            InitializeComponent();
        }

        public DiagnosisView(DiagnosisService diagnosisService, string patientId, ConditionService conditionService, PhysicianService physicianService)
        {
            InitializeComponent();
            _diagnosisService = diagnosisService;
            var diagnosisListViewModel = new DiagnosisListViewModel(_diagnosisService,patientId);
            DataContext = diagnosisListViewModel;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DiagnosisGrid_OnMouseDoubleClickGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}

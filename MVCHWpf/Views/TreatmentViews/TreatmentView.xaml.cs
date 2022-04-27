using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MVCHWpf.ViewModels.Persons.PatientViewModels;
using MVCHWpf.ViewModels.TreatmentViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.TreatmentViews
{
    /// <summary>
    /// Interaction logic for TreatmentView.xaml
    /// </summary>
    public partial class TreatmentView : UserControl
    {
        private TreatmentService _treatmentService;

        public TreatmentView()
        {
            InitializeComponent();
        }

        public TreatmentView(TreatmentService treatmentService, string patientId, ProcedureService procedureService, PhysicianService physicianService)
        {
            InitializeComponent();
            _treatmentService = treatmentService;
            var treatmentListViewModel = new TreatmentListViewModel(_treatmentService,patientId);
            DataContext = treatmentListViewModel;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TreatmentGrid_OnMouseDoubleClickGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}

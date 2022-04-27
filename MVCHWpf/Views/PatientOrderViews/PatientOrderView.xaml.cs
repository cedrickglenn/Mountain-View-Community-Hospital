using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MVCHWpf.ViewModels.PatientOrderViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.PatientOrderViews
{
    /// <summary>
    /// Interaction logic for PatientOrderView.xaml
    /// </summary>
    public partial class PatientOrderView : UserControl
    {
        private PatientOrderService _patientOrderService;

        public PatientOrderView()
        {
            InitializeComponent();
        }

        public PatientOrderView(PatientOrderService patientOrderService, string patientId, OrderItemService orderItemService)
        {
            InitializeComponent();
            _patientOrderService = patientOrderService;
            var patientOrderListViewModel = new PatientOrderListViewModel(_patientOrderService,patientId);
            DataContext = patientOrderListViewModel;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PatientOrderGrid_OnMouseDoubleClickGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void AddPatientOrderButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

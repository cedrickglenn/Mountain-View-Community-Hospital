using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Datalayer.EFClasses.AssociativeClasses;
using MVCHWpf.ViewModels.OrderViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.OrderViews
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        private OrderServiceLayer _orderServiceLayer;

        public OrderView()
        {
            InitializeComponent();
        }

        public OrderView(OrderServiceLayer orderServiceLayer, string patientId, OrderServiceService orderServiceService, PhysicianService physicianService)
        {
            InitializeComponent();
            _orderServiceLayer = orderServiceLayer;
            var orderListViewModel = new OrderListViewModel(_orderServiceLayer,patientId);
            DataContext = orderListViewModel;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OrderGrid_OnMouseDoubleClickGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void AddOrderButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

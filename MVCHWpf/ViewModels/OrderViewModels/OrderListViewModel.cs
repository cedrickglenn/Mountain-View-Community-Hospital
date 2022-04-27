using System.Collections.ObjectModel;
using System.Linq;
using Servicelayer.AssociativeClassService;

namespace MVCHWpf.ViewModels.OrderViewModels
{
    public class OrderListViewModel
    {
        private OrderViewModel _selectedOrder;
        private string _searchText;
        private OrderServiceLayer _orderServiceLayer;
        private string _patientId;

        public OrderViewModel SelectedOrder
        {
            get => _selectedOrder;
            set { _selectedOrder = value; }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchOrder(_searchText);
            }
        }

        private void SearchOrder(string searchString)
        {
            OrderList.Clear();
            var orders = _orderServiceLayer.GetOrders()
                .Where(c => (c.Instructions.Contains(searchString) ||
                            c.OrderId.Contains(searchString) ||
                            c.PhysicianLink.FirstName.Contains(searchString) ||
                            c.PhysicianLink.LastName.Contains(searchString)) &&
                            c.PatientId == _patientId).ToList();
            foreach (var order in orders)
            {
                var orderModel = new OrderViewModel(order);
                OrderList.Add(orderModel);
            }
        }

        public ObservableCollection<OrderViewModel> OrderList { get; set; }
        public OrderListViewModel(OrderServiceLayer orderServiceLayer ,string patientId)
        {
            _orderServiceLayer = orderServiceLayer;
            _patientId = patientId;
            var orders = _orderServiceLayer.GetOrders()
                .Where(c=>c.PatientId == patientId).ToList();
            OrderList = new ObservableCollection<OrderViewModel>();
            foreach (var item in orders)
            {
                OrderList.Add(new OrderViewModel(item));
            }
            
        }
       

    }
}

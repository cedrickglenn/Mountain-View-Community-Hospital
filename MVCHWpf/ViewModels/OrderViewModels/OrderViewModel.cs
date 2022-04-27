using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.AssociativeClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.OrderViewModels
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _orderId;
        private string _instructions;
        private DateTime _dateTime;
        private string _physicianName;

        #endregion

        #region Properties


        public string OrderId
        {
            get => _orderId;
            set
            {
                _orderId = value;
                OnPropertyChanged(nameof(OrderId));
            }
        }
        
        public string Instructions
        {
            get => _instructions;
            set
            {
                _instructions = value;
                OnPropertyChanged(nameof(Instructions));
            }
        }
        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                OnPropertyChanged(nameof(DateTime));
            }
        }
        public string PhysicianName
        {
            get => _physicianName;
            set
            {
                _physicianName = value;
                OnPropertyChanged(nameof(PhysicianName));
            }
        }
        
        public string PhysicianId { get; set; }
        public string PatientId { get; set; }
        

        #endregion
        #region PropertyHandler
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public OrderViewModel(Order order)
        {
            OrderId = order.OrderId;
            Instructions = order.Instructions;
            DateTime = order.DateTime;
            PatientId = order.PatientId;
            PhysicianId = order.PhysicianId;
            PhysicianName = order.PhysicianLink.FullName;
        }

        public OrderViewModel()
        {

        }

    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using MVCHWpf.Annotations;
using Servicelayer.AssociativeClassService;

namespace MVCHWpf.ViewModels.PatientOrderViewModels
{
    public class PatientOrderViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _orderId;
        private DateTime _dateTime;
        private decimal _totalCost;

        #endregion

        #region Properties


        public string PatientOrderId
        {
            get => _orderId;
            set
            {
                _orderId = value;
                OnPropertyChanged(nameof(PatientOrderId));
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
        public decimal TotalCost 
        {
            get => _totalCost;
            set
            {
                _totalCost = value;
                OnPropertyChanged(nameof(TotalCost));
            }
        }


        #endregion
        #region PropertyHandler
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public PatientOrderViewModel(PatientOrder patientOrder)
        {
            PatientOrderId = patientOrder.PatientOrderId;
            DateTime = patientOrder.DateTime;
            TotalCost = patientOrder.TotalCost;
        }



        public PatientOrderViewModel()
        {

        }

    }
}

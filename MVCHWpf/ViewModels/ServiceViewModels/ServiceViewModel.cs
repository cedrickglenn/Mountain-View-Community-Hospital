using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.BaseClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.ServiceViewModels
{
    public class ServiceViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _serviceId;
        private string _name;

        #endregion
        #region Properties

        public string ServiceId
        {
            get { return _serviceId; }
            set
            {
                _serviceId = value;
                OnPropertyChanged(nameof(ServiceId));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
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

        public ServiceViewModel(Service service)
        {
            ServiceId = service.ServiceId;
            Name = service.Name;
        }

       

        public ServiceViewModel()
        {

        }

    }
}

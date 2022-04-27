using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.BaseClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.VendorViewModels
{
    public class VendorViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _vendorId;
        private string _name;
        #endregion
        #region Properties

        public string VendorId
        {
            get => _vendorId;
            set
            {
                _vendorId = value;
                OnPropertyChanged(nameof(VendorId));
            }
        }

        public string Name
        {
            get => _name;
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

        public VendorViewModel(Vendor vendor)
        {
            VendorId = vendor.VendorId;
            Name = vendor.Name;
        }

        public VendorViewModel()
        {

        }

    }
}

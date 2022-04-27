using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.BaseClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.WardViewModels
{
    public class WardViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _wardId;
        private string _name;
        private string _facility;

        #endregion

        #region Properties


        public string WardId
        {
            get => _wardId;
            set
            {
                _wardId = value;
                OnPropertyChanged(nameof(WardId));
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

        public string Facility
        {
            get => _facility;
            set
            {
                _facility = value; 
                OnPropertyChanged(nameof(Facility));
            }
        }

        public string FacilityId { get; set; }

        #endregion
        #region PropertyHandler
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public WardViewModel(Ward ward)
        {
            WardId = ward.WardId;
            Name = ward.Name;
            Facility = ward.FacilityLink.Name;
            FacilityId = ward.FacilityId;
        }

        public WardViewModel()
        {

        }

    }
}

using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.BaseClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.FacilityViewModels
{
    public class FacilityViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _facilityId;
        private string _name;

        #endregion

        #region Properties


        public string FacilityId
        {
            get => _facilityId;
            set
            {
                _facilityId = value;
                OnPropertyChanged(nameof(FacilityId));
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

        public FacilityViewModel(Facility facility)
        {
            FacilityId = facility.FacilityId;
            Name = facility.Name;
        }

        public FacilityViewModel()
        {

        }

    }
}

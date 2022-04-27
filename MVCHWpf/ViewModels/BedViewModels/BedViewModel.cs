using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.BaseClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.BedViewModels
{
    public class BedViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _bedId;
        private string _roomNumber;
        private string _workUnit;
        private string _workUnitId;

        #endregion

        #region Properties


        public string BedId
        {
            get => _bedId;
            set
            {
                _bedId = value;
                OnPropertyChanged(nameof(BedId));
            }
        }

        public string RoomNumber
        {
            get => _roomNumber;
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        public string WorkUnit
        {
            get => _workUnit;
            set
            {
                _workUnit = value; 
                OnPropertyChanged(nameof(WorkUnit));
            }
        }

        public string WorkUnitId
        {
            get => _workUnitId;
            set
            {
                _workUnitId = value;
                OnPropertyChanged(nameof(WorkUnitId));
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

        public BedViewModel(Bed bed)
        {
            BedId = bed.BedId;
            RoomNumber = bed.RoomNumber;
            WorkUnit = bed.WorkUnitLink.Name;
            WorkUnitId = bed.WorkUnitId;
        }

        public BedViewModel()
        {

        }

    }
}

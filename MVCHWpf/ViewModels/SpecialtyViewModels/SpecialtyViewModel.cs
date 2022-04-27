using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Datalayer.EFClasses.BaseClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.SpecialtyViewModels
{
    public class SpecialtyViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _specialtyId;
        private string _name;
        private string _description;

        #endregion

        #region Properties


        public string SpecialtyId
        {
            get => _specialtyId;
            set
            {
                _specialtyId = value;
                OnPropertyChanged(nameof(SpecialtyId));
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

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
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

        public SpecialtyViewModel(Specialty specialty)
        {
            SpecialtyId = SpecialtyId;
            Name = specialty.Name;
            Description = specialty.Description;
        }

      
        public SpecialtyViewModel()
        {

        }

    }
}

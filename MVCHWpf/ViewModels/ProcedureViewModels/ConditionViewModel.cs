using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.BaseClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.ProcedureViewModels
{
    public class ProcedureViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _procedureId;
        private string _name;

        #endregion

        #region Properties


        public string ProcedureId
        {
            get => _procedureId;
            set
            {
                _procedureId = value;
                OnPropertyChanged(nameof(ProcedureId));
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

        public ProcedureViewModel(Procedure procedure)
        {
            ProcedureId = ProcedureId;
            Name = procedure.Name;
        }

        public ProcedureViewModel()
        {

        }

    }
}

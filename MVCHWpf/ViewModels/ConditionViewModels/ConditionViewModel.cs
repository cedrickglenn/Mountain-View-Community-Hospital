using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.BaseClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.ConditionViewModels
{
    public class ConditionViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _conditionId;
        private string _name;

        #endregion

        #region Properties


        public string ConditionId
        {
            get => _conditionId;
            set
            {
                _conditionId = value;
                OnPropertyChanged(nameof(ConditionId));
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

        public ConditionViewModel(Condition condition)
        {
            ConditionId = ConditionId;
            Name = condition.Name;
        }

        public ConditionViewModel()
        {

        }

    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.AssociativeClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.VitalRecordViewModels
{
    public class VitalRecordViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _vitalRecordId;
        private string _description;
        private DateTime _dateTime;
        private string _nurseName;
        private string _value;

        #endregion

        #region Properties


        public string VitalRecordId
        {
            get => _vitalRecordId;
            set
            {
                _vitalRecordId = value;
                OnPropertyChanged(nameof(VitalRecordId));
            }
        }
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
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
        public string NurseName
        {
            get => _nurseName;
            set
            {
                _nurseName = value;
                OnPropertyChanged(nameof(NurseName));
            }
        }
        
        public string NurseId { get; set; }
        public string VitalId { get; set; }
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

        public VitalRecordViewModel(VitalRecord vitalRecord)
        {
            VitalRecordId = vitalRecord.VitalRecordId;
            VitalId = vitalRecord.VitalId;
            Value = vitalRecord.Value;
            DateTime = vitalRecord.DateTime;
            PatientId = vitalRecord.PatientId;
            NurseId = vitalRecord.NurseId;
            NurseName = vitalRecord.NurseLink.FullName;
            
        }

        public VitalRecordViewModel()
        {

        }

    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.AssociativeClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.DiagnosisViewModels
{
    public class DiagnosisViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _diagnosisId;
        private string _description;
        private DateTime _dateTime;
        private string _physicianName;
        private string _condition;

        #endregion

        #region Properties


        public string DiagnosisId
        {
            get => _diagnosisId;
            set
            {
                _diagnosisId = value;
                OnPropertyChanged(nameof(DiagnosisId));
            }
        }
        public string Condition
        {
            get => _condition;
            set
            {
                _condition = value;
                OnPropertyChanged(nameof(Condition));
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
        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                OnPropertyChanged(nameof(DateTime));
            }
        }
        public string PhysicianName
        {
            get => _physicianName;
            set
            {
                _physicianName = value;
                OnPropertyChanged(nameof(PhysicianName));
            }
        }
        
        public string PhysicianId { get; set; }
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

        public DiagnosisViewModel(Diagnosis diagnosis)
        {
            DiagnosisId = diagnosis.DiagnosisId;
            Condition = diagnosis.ConditionLink.Name;
            Description = diagnosis.Description;
            DateTime = diagnosis.DateTime;
            PatientId = diagnosis.PatientId;
            PhysicianId = diagnosis.PhysicianId;
            PhysicianName = diagnosis.PhysicianLink.FullName;
        }

        public DiagnosisViewModel()
        {

        }

    }
}

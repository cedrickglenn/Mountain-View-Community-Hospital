using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.TreatmentViewModels
{
    public class TreatmentViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _treatmentId;
        private string _description;
        private DateTime _dateTime;
        private string _physicianName;
        private string _procedure;

        #endregion

        #region Properties


        public string TreatmentId
        {
            get => _treatmentId;
            set
            {
                _treatmentId = value;
                OnPropertyChanged(nameof(TreatmentId));
            }
        }
        public string Procedure
        {
            get => _procedure;
            set
            {
                _procedure = value;
                OnPropertyChanged(nameof(Procedure));
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

        public TreatmentViewModel(Treatment treatment)
        {
            TreatmentId = treatment.TreatmentId;
            Procedure = treatment.ProcedureLink.Name;
            Description = treatment.Description;
            DateTime = treatment.DateTime;
            PatientId = treatment.PatientId;
            PhysicianId = treatment.PhysicianId;
            PhysicianName = treatment.PhysicianLink.FullName;
            
        }

        public TreatmentViewModel()
        {

        }

    }
}

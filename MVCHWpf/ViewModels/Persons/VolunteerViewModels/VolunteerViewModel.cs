using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.Persons.VolunteerViewModels
{
    public class VolunteerViewModel: INotifyPropertyChanged
    {
        #region Fields
        private string _volunteerId;
        private DateTime _birthDate;
        private string _phoneNumber;
        private string _email;
        private string _address;
        private int? _hoursWorked;
        private DateTime? _endDate;
        private DateTime _startDate;
        private string _workUnitName;
        private string _supervisorName;
        private string _fullName;

        #endregion
        #region Properties

        public string FullName 
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }



        public string VolunteerId
        {
            get { return _volunteerId; }
            set
            {
                _volunteerId = value;
                OnPropertyChanged(nameof(VolunteerId));
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));

            }
        }


        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));

            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));

            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));

            }
        }
        public int? HoursWorked
        {
            get { return _hoursWorked; }
            set
            {
                _hoursWorked = value;
                OnPropertyChanged(nameof(HoursWorked));
            }
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value; 
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public string WorkUnitName
        {
            get => _workUnitName;
            set
            {
                _workUnitName = value; 
                OnPropertyChanged(nameof(WorkUnitName));
            }
        }

        public string SupervisorName
        {
            get => _supervisorName;
            set
            {
                _supervisorName = value;
                OnPropertyChanged(nameof(SupervisorName));
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

        public VolunteerViewModel(Volunteer volunteer)
        {
            FullName = volunteer.FullName;
            VolunteerId = volunteer.PersonId;
            Address = volunteer.FullAddressWithZip;
            BirthDate = volunteer.BirthDate;
            PhoneNumber = volunteer.PhoneNumber;
            Email = volunteer.Email;
            StartDate = volunteer.StartDate;
            EndDate = volunteer.EndDate;
            HoursWorked = volunteer.HoursWorked;
            if (volunteer.SupervisorId != null) SupervisorName = volunteer.SupervisorLink.FullName;
            if (volunteer.WorkUnitId != null) WorkUnitName = volunteer.WorkUnitLink.Name;
        }

       


        public VolunteerViewModel()
        {

        }

    }
}

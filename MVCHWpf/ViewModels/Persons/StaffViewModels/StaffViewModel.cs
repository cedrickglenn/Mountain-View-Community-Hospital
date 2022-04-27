using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.Persons.StaffViewModels
{
    public class StaffViewModel: ObservableObject
    {
        #region Fields
        private string _staffId;
        private string _firstName;
        private string _lastName;
        private string _middleInitial;
        private string _city;
        private string _state;
        private string _zip;
        private DateTime _birthDate;
        private string _phoneNumber;
        private string _email;
        private string _address;
        private DateTime _dateHired;
        private string _jobName;

        #endregion
        #region Properties

        public string FullName => GetFullName();

        private string GetFullName()
        {
            return $"{FirstName} {MiddleInitial} {LastName}";
        }

        public string StaffId
        {
            get => _staffId;
            set
            {
                _staffId = value;
                OnPropertyChanged(nameof(StaffId));
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));

            }
        }

        public string MiddleInitial
        {
            get => _middleInitial;
            set
            {
                _middleInitial = value;
                OnPropertyChanged(nameof(MiddleInitial));

            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));

            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));

            }
        }

        public string State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged(nameof(State));

            }
        }

        public string Zip
        {
            get => _zip;
            set
            {
                _zip = value;
                OnPropertyChanged(nameof(Zip));

            }
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));

            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));

            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));

            }
        }

        public DateTime DateHired
        {
            get => _dateHired;
            set
            {
                _dateHired = value;
                OnPropertyChanged(nameof(DateHired));
            }
        }
        public string JobName
        {
            get => _jobName;
            set
            {
                _jobName = value;
                OnPropertyChanged(nameof(JobName));

            }
        }



        #endregion
        
        public StaffViewModel(Staff staff)
        {
            FirstName = staff.FirstName;
            StaffId = staff.PersonId;
            LastName = staff.LastName;
            Address = staff.Address;
            MiddleInitial = staff.MiddleInitial;
            City = staff.City;
            State = staff.State;
            Zip = staff.Zip;
            BirthDate = staff.BirthDate;
            PhoneNumber = staff.PhoneNumber;
            Email = staff.Email;
            DateHired = staff.DateHired;
            JobName = staff.JobClassLink.Name;
        }

        public StaffViewModel()
        {

        }

    }
}

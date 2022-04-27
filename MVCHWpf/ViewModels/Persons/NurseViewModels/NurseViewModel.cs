using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.Persons.NurseViewModels
{
    public class NurseViewModel
    {
        #region Fields
        private string _nurseId;
        private string _firstName;
        private string _lastName;
        private string _middleInitial;
        private string _city;
        private string _state;
        private string _zip;
        private DateTime _birthDate;
        private string _phoneNumber;
        private string _email;
        private string _contactPersonId;
        private string _contactRelationship;
        private DateTime? _dateOfContact;
        private string _medicalRecordNumber;
        private string _insuranceCompanyName;
        private string _policyNumber;
        private string _groupNumber;
        private string _insurancePhoneNumber;
        private string _address;
        private string _subscriberRelationship;
        private DateTime _dateHired;
        private string _degree;
        private string _license;

        #endregion
        #region Properties

        public string FullName => GetFullName();

        private string GetFullName()
        {
            return $"{FirstName} {MiddleInitial} {LastName}";
        }

        public string NurseId
        {
            get => _nurseId;
            set
            {
                _nurseId = value;
                OnPropertyChanged(nameof(NurseId));
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

        public string Degree
        {
            get => _degree;
            set
            {
                _degree = value;
                OnPropertyChanged(nameof(Degree));
            }
        }

        public string License
        {
            get => _license;
            set
            {
                _license = value;
                OnPropertyChanged(nameof(License));
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

        public NurseViewModel(Nurse nurse)
        {
            FirstName = nurse.FirstName;
            NurseId = nurse.PersonId;
            LastName = nurse.LastName;
            Address = nurse.Address;
            MiddleInitial = nurse.MiddleInitial;
            City = nurse.City;
            State = nurse.State;
            Zip = nurse.Zip;
            BirthDate = nurse.BirthDate;
            PhoneNumber = nurse.PhoneNumber;
            Email = nurse.Email;
            DateHired = nurse.DateHired;
            Degree = nurse.Degree;
            License = nurse.License;
        }

        public NurseViewModel()
        {

        }

    }
}

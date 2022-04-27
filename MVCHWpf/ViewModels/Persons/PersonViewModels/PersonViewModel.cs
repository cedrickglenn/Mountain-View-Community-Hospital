using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.Persons.PersonViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _personId;
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

        #endregion
        #region Properties

        public string FullName => GetFullName();

        private string GetFullName()
        {
            return $"{FirstName} {MiddleInitial} {LastName}";
        }

        public string PersonId
        {
            get => _personId;
            set
            {
                _personId = value;
                OnPropertyChanged(nameof(PersonId));
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


        #endregion
        #region PropertyHandler
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public PersonViewModel(Person person)
        {
            FirstName = person.FirstName;
            PersonId = person.PersonId;
            LastName = person.LastName;
            Address = person.Address;
            MiddleInitial = person.MiddleInitial;
            City = person.City;
            State = person.State;
            Zip = person.Zip;
            BirthDate = person.BirthDate;
            PhoneNumber = person.PhoneNumber;
            Email = person.Email;
        }

        public PersonViewModel()
        {

        }

    }
}

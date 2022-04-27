using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using MVCHWpf.Annotations;
using MVCHWpf.Views.PatientViews;

namespace MVCHWpf.ViewModels.Persons.PatientViewModels
{
    
    // A better implementation for combined InPatient and Outpatient
    public class CombinedPatientViewModel : ObservableObject
    {
        private Outpatient _outpatientModel;
        private Inpatient _inpatientModel;
        private Patient _patientModel;
        public bool IsOutpatient => OutpatientModel != null;

        public CombinedPatientViewModel(Inpatient inpatient)
        {
            PatientModel = inpatient;
            InpatientModel = inpatient;
        }

        public CombinedPatientViewModel(Outpatient outpatient)
        {
            // note that OutPatient IS also an InPatient, so this should be ok.
            // since the details of outpatient are also contain in InPatient,
            // the bindings in the UI is not affected, e.g.
            // {Binding Path=InPatientModel.FirstName}
            // will return the first name of the patient,
            // regardless if it is an inpatient or outpatient
            PatientModel = outpatient;
            OutpatientModel = outpatient;
           
        }

        public Patient PatientModel 
        {
            get { return _patientModel; }
            set
            {
                _patientModel = value;
                OnPropertyChanged(nameof(PatientModel));
            }
        }
        public Outpatient OutpatientModel
        {
            get { return _outpatientModel; }
            set
            {
                _outpatientModel = value;
                OnPropertyChanged(nameof(OutpatientModel));
            }
        }

        public Inpatient InpatientModel
        {
            get { return _inpatientModel; }
            set
            {
                _inpatientModel = value;
                OnPropertyChanged(nameof(InpatientModel));
            }
        }


    }


    // Abandon, use the class CombinedPatientViewModel instead

    //public class PatientViewModel : INotifyPropertyChanged
    //{
    //    #region Fields
    //    private string _patientId;
    //    private string _firstName;
    //    private string _lastName;
    //    private string _middleInitial;
    //    private string _city;
    //    private string _state;
    //    private string _zip;
    //    private DateTime _birthDate;
    //    private string _phoneNumber;
    //    private string _email;
    //    private string _contactPersonId;
    //    private string _contactRelationship;
    //    private DateTime? _dateOfContact;
    //    private string _medicalRecordNumber;
    //    private string _insuranceCompanyName;
    //    private string _policyNumber;
    //    private string _groupNumber;
    //    private string _insurancePhoneNumber;
    //    private string _address;
    //    private string _subscriberRelationship;
    //    private string _subscriberPerson;
    //    private string _subscriberPersonId;
    //    private string _contactPerson;
    //    private string _patientType;
    //    private DateTime? _dischargeDate;
    //    private DateTime _dateAdmitted;
    //    private string _bedId;
    //    private string _roomNumber;
    //    private string _wardId;
    //    private string _wardName;

    //    #endregion
    //    #region Properties
    //    public string FullName => GetFullName();
    //    private string GetFullName()
    //    {
    //        return $"{FirstName} {MiddleInitial} {LastName}";
    //    }
    //    public string PatientId
    //    {
    //        get => _patientId;
    //        set
    //        {
    //            _patientId = value; 
    //            OnPropertyChanged(nameof(PatientId));
    //        }
    //    }
    //    public string FirstName
    //    {
    //        get => _firstName;
    //        set
    //        {
    //            _firstName = value;
    //            OnPropertyChanged(nameof(FirstName));
    //        }
    //    }
    //    public string LastName
    //    {
    //        get => _lastName;
    //        set
    //        {
    //            _lastName = value;
    //            OnPropertyChanged(nameof(LastName));

    //        }
    //    }
    //    public string MiddleInitial
    //    {
    //        get => _middleInitial;
    //        set
    //        {
    //            _middleInitial = value;
    //            OnPropertyChanged(nameof(MiddleInitial));

    //        }
    //    }
    //    public string Address
    //    {
    //        get => _address;
    //        set
    //        {
    //            _address = value;
    //            OnPropertyChanged(nameof(Address));

    //        }
    //    }
    //    public string City
    //    {
    //        get => _city;
    //        set
    //        {
    //            _city = value;
    //            OnPropertyChanged(nameof(City));

    //        }
    //    }
    //    public string State
    //    {
    //        get => _state;
    //        set
    //        {
    //            _state = value;
    //            OnPropertyChanged(nameof(State));

    //        }
    //    }
    //    public string Zip
    //    {
    //        get => _zip;
    //        set
    //        {
    //            _zip = value;
    //            OnPropertyChanged(nameof(Zip));

    //        }
    //    }
    //    public DateTime BirthDate
    //    {
    //        get => _birthDate;
    //        set
    //        {
    //            _birthDate = value;
    //            OnPropertyChanged(nameof(BirthDate));

    //        }
    //    }
    //    public string PhoneNumber
    //    {
    //        get => _phoneNumber;
    //        set
    //        {
    //            _phoneNumber = value;
    //            OnPropertyChanged(nameof(PhoneNumber));

    //        }
    //    }
    //    public string Email
    //    {
    //        get => _email;
    //        set
    //        {
    //            _email = value;
    //            OnPropertyChanged(nameof(Email));

    //        }
    //    }
    //    public string ContactPersonId
    //    {
    //        get => _contactPersonId;
    //        set
    //        {
    //            _contactPersonId = value;
    //            OnPropertyChanged(nameof(ContactPersonId));

    //        }
    //    }
    //    public string SubscriberPersonId
    //    {
    //        get => _subscriberPersonId;
    //        set
    //        {
    //            _subscriberPersonId = value;
    //            OnPropertyChanged(nameof(SubscriberPersonId));

    //        }
    //    }
    //    public string SubscriberPerson
    //    {
    //        get => _subscriberPerson;
    //        set
    //        {
    //            _subscriberPerson = value;
    //            OnPropertyChanged(nameof(SubscriberPerson));

    //        }
    //    }
    //    public string ContactPerson
    //    {
    //        get => _contactPerson;
    //        set
    //        { 
    //            _contactPerson = value;
    //            OnPropertyChanged(nameof(ContactPerson));
    //        }
    //    }
    //    public string ContactRelationship
    //    {
    //        get => _contactRelationship;
    //        set
    //        {
    //            _contactRelationship = value;
    //            OnPropertyChanged(nameof(ContactRelationship));

    //        }
    //    }
    //    public string SubscriberRelationship
    //    {
    //        get => _subscriberRelationship;
    //        set
    //        {  _subscriberRelationship = value;
    //            OnPropertyChanged(nameof(SubscriberRelationship));

    //        }
    //    }
    //    public DateTime? DateOfContact
    //    {
    //        get => _dateOfContact;
    //        set
    //        {
    //            _dateOfContact = value;
    //            OnPropertyChanged(nameof(DateOfContact));

    //        }
    //    }
    //    public string MedicalRecordNumber
    //    {
    //        get => _medicalRecordNumber;
    //        set
    //        {
    //            _medicalRecordNumber = value;
    //            OnPropertyChanged(nameof(MedicalRecordNumber));

    //        }
    //    }
    //    public string InsuranceCompanyName
    //    {
    //        get => _insuranceCompanyName;
    //        set
    //        {
    //            _insuranceCompanyName = value;
    //            OnPropertyChanged(nameof(InsuranceCompanyName));

    //        }
    //    } 
    //    public string PolicyNumber
    //    {
    //        get => _policyNumber;
    //        set
    //        {
    //            _policyNumber = value;
    //            OnPropertyChanged(nameof(PolicyNumber));

    //        }
    //    }
    //    public string GroupNumber
    //    {
    //        get => _groupNumber;
    //        set
    //        {
    //            _groupNumber = value;
    //            OnPropertyChanged(nameof(GroupNumber));

    //        }
    //    }
    //    public string InsurancePhoneNumber
    //    {
    //        get => _insurancePhoneNumber;
    //        set
    //        {
    //            _insurancePhoneNumber = value;
    //            OnPropertyChanged(nameof(InsurancePhoneNumber));

    //        }
    //    }
    //    public string PatientType
    //    {
    //        get => _patientType;
    //        set
    //        {
    //            _patientType = value;
    //            OnPropertyChanged(nameof(PatientType));

    //        }
    //    }
    //    public string BedId
    //    {
    //        get => _bedId;
    //        set
    //        {
    //            _bedId = value;
    //            OnPropertyChanged(nameof(BedId));

    //        }
    //    }
    //    public string RoomNumber
    //    {
    //        get => _roomNumber;
    //        set
    //        {
    //            _roomNumber = value;
    //            OnPropertyChanged(nameof(RoomNumber));

    //        }
    //    }
    //    public string WardId
    //    {
    //        get => _wardId;
    //        set
    //        {
    //            _wardId = value;
    //            OnPropertyChanged(nameof(WardId));

    //        }
    //    }
    //    public string WardName
    //    {
    //        get => _wardName;
    //        set
    //        {
    //            _wardName = value;
    //            OnPropertyChanged(nameof(WardName));

    //        }
    //    }

    //    public DateTime DateAdmitted
    //    {
    //        get => _dateAdmitted;
    //        set
    //        {
    //            _dateAdmitted = value;
    //            OnPropertyChanged(nameof(DateAdmitted));

    //        }
    //    }
    //    public DateTime? DischargeDate
    //    {
    //        get => _dischargeDate;
    //        set
    //        {
    //            _dischargeDate = value;
    //            OnPropertyChanged(nameof(DischargeDate));

    //        }
    //    }
    //    #endregion
    //    #region PropertyHandler
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    [NotifyPropertyChangedInvocator]
    //    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //    #endregion


    //    // Use this property to bind to the UI
    //    // e.g. If you want to display the FirstName use
    //    // {Binding Path=Model.FirstName}
    //    // therefore, there is no need to add redundant properties for each member of InPatient
    //    // if some properties in the Model are changed:
    //    // call RaisePropertyChanged(nameof(Model)) to refresh the UI for the updates
    //    public InPatient Model
    //    {
    //        get { return _model; }
    //        set
    //        {
    //            _model = value;
    //            RaisePropertyChanged(nameof(Model))
    //         }
    //    }

    //    public PatientViewModel(Inpatient inpatient)
    //    {
    //        PatientId = inpatient.PersonId;
    //        FirstName = inpatient.FirstName;
    //        LastName = inpatient.LastName;
    //        Address = inpatient.Address;
    //        MiddleInitial = inpatient.MiddleInitial;
    //        City = inpatient.City;
    //        State =inpatient.State;
    //        Zip = inpatient.Zip;
    //        BirthDate = inpatient.BirthDate;
    //        PhoneNumber = inpatient.PhoneNumber;
    //        Email = inpatient.Email;
    //        DateOfContact = inpatient.DateOfContact;
    //        MedicalRecordNumber = inpatient.MedicalRecordNumber;
    //        InsuranceCompanyName = inpatient.InsuranceCompanyName;
    //        PolicyNumber = inpatient.PolicyNumber;
    //        GroupNumber = inpatient.GroupNumber;
    //        InsurancePhoneNumber = inpatient.InsurancePhoneNumber;
    //        PatientType = inpatient.Discriminator;
    //        if (inpatient.ContactPersonId == null)
    //        {
    //            ContactPersonId = "N/A";
    //            ContactRelationship = "N/A";
    //            ContactPerson = "N/A";
    //        }
    //        else
    //        {
    //            ContactPersonId = inpatient.ContactPersonId;
    //            ContactRelationship = inpatient.ContactRelationship;
    //            ContactPerson = inpatient.ContactPersonLink.FullName;
    //        }
    //        if (inpatient.SubscriberPersonId == null)
    //        {
    //            SubscriberPersonId = "N/A";
    //            SubscriberRelationship = "N/A";
    //            SubscriberPerson = "N/A";
    //        }
    //        else
    //        {
    //            SubscriberPersonId = inpatient.SubscriberPersonId;
    //            SubscriberRelationship = inpatient.SubscriberRelationship;
    //            SubscriberPerson = inpatient.SubscriberPersonLink.FullName;
    //        }
    //        if(inpatient.BedId == null)
    //        {
    //            BedId = "N/A";
    //            RoomNumber = "N/A";
    //        }
    //        else if(inpatient.BedId != null)
    //        {
    //            BedId = inpatient.BedId;
    //            RoomNumber = inpatient.BedLink.RoomNumber;
    //        }
    //        WardName = inpatient.WardLink.Name;
    //        WardId = inpatient.WardId;
    //        DischargeDate = inpatient.DischargeDate;
    //        DateAdmitted = inpatient.DateAdmitted;
    //    }
    //    public PatientViewModel(Outpatient outpatient)
    //    {
    //        PatientId = outpatient.PersonId;
    //        FirstName = outpatient.FirstName;
    //        LastName = outpatient.LastName;
    //        Address = outpatient.Address;
    //        MiddleInitial = outpatient.MiddleInitial;
    //        City = outpatient.City;
    //        State =outpatient.State;
    //        Zip = outpatient.Zip;
    //        BirthDate = outpatient.BirthDate;
    //        PhoneNumber = outpatient.PhoneNumber;
    //        Email = outpatient.Email;
    //        DateOfContact = outpatient.DateOfContact;
    //        MedicalRecordNumber = outpatient.MedicalRecordNumber;
    //        InsuranceCompanyName = outpatient.InsuranceCompanyName;
    //        PolicyNumber = outpatient.PolicyNumber;
    //        GroupNumber = outpatient.GroupNumber;
    //        InsurancePhoneNumber = outpatient.InsurancePhoneNumber;
    //        PatientType = outpatient.Discriminator;
    //        if (outpatient.ContactPersonId == null)
    //        {
    //            ContactPersonId = "N/A";
    //            ContactRelationship = "N/A";
    //            ContactPerson = "N/A";
    //        }
    //        else 
    //        {
    //            ContactPersonId = outpatient.ContactPersonId;
    //            ContactRelationship = outpatient.ContactRelationship;
    //            ContactPerson = outpatient.ContactPersonLink.FullName;
    //        }
    //        if (outpatient.SubscriberPersonId == null)
    //        {
    //            SubscriberPersonId = "N/A";
    //            SubscriberRelationship = "N/A";
    //            SubscriberPerson = "N/A";
    //        }
    //        else
    //        {
    //            SubscriberPersonId = outpatient.SubscriberPersonId;
    //            SubscriberRelationship = outpatient.SubscriberRelationship;
    //            SubscriberPerson = outpatient.SubscriberPersonLink.FullName;
    //        }
    //    }
    //    public PatientViewModel()
    //    {
            
    //    }

       
    //}
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MVCHWpf.ViewModels.Persons.PatientViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.PersonViews
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddPersonView : Window
    {
        //private AddPatientViewModel _toAddPatient;
        //private string _patientType;
        //public AddPersonView()
        //{
        //    InitializeComponent();

        //}

        //public AddPersonView(PatientListViewModel patientListViewModel, 
        //    PatientService patientService, 
        //    DiagnosisService diagnosisService, 
        //    PersonService personService,
        //    EmployeeService employeeService,
        //    WardService wardService,
        //    BedService bedService,
        //    PhysicianService physicianService,
        //    VitalRecordService vitalRecordService,
        //    ConditionService conditionService)
        //{
        //    _toAddPatient = new AddPatientViewModel(patientListViewModel, 
        //        patientService, 
        //        personService, 
        //        diagnosisService, 
        //        physicianService, 
        //        employeeService, 
        //        wardService,
        //        bedService,
        //        vitalRecordService,
        //        conditionService);
        //    DataContext = _toAddPatient;
        //    InitializeComponent();
        //}

        //private void AddPersonButton_Onclick(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void CancelButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Close();
        //}

        //private void SaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    _toAddPatient.Add(_patientType);
        //    Close();
        //}


    }
}

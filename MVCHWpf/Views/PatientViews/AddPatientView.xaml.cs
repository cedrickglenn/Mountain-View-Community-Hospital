using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using MVCHWpf.ViewModels;
using MVCHWpf.ViewModels.Persons.PatientViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.PatientViews
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddPatientView : Window
    {
        private AddPatientViewModel _toAddPatient;
        private string _patientType;
        public AddPatientView()
        {
            InitializeComponent();

        }

        public AddPatientView(PatientListViewModel patientListViewModel, 
            PatientService patientService, 
            DiagnosisService diagnosisService, 
            PersonService personService,
            EmployeeService employeeService,
            WardService wardService,
            BedService bedService,
            PhysicianService physicianService,
            VitalRecordService vitalRecordService,
            ConditionService conditionService)
        {
            _toAddPatient = new AddPatientViewModel(patientListViewModel, 
                patientService, 
                personService, 
                diagnosisService, 
                physicianService, 
                employeeService, 
                wardService,
                bedService,
                vitalRecordService,
                conditionService);
            DataContext = _toAddPatient;
            InitializeComponent();
            InsuranceCheckBox.IsChecked = true;
        }

        private void AddPersonButton_Onclick(object sender, RoutedEventArgs e)
        {
        }

        private void InsuranceCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            InsuranceGrid.Visibility = Visibility.Visible;
        }

        private void InsuranceCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            InsuranceGrid.Visibility = Visibility.Collapsed;
        }


        private void InpatientSelectButton_Click(object sender, RoutedEventArgs e)
        {
            OutpatientSelectButton.IsChecked = false;
            InpatientGrid.Visibility = Visibility.Visible;
            _patientType = "Inpatient";


        }

        private void OutpatientSelectButton_Click(object sender, RoutedEventArgs e)
        {
            InpatientSelectButton.IsChecked = false;
            InpatientGrid.Visibility = Visibility.Collapsed;
            _patientType = "Outpatient";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_patientType == "Inpatient")
            {
                if (WardBox.SelectedItem != null)
                {
                    if (_toAddPatient.CheckFirst())
                    {
                        _toAddPatient.Add(_patientType);
                        Close();
                    }
                }
                else MessageBox.Show("Fill up required fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (_patientType == "Outpatient")
            {
                if (_toAddPatient.CheckFirst())
                {
                    _toAddPatient.Add(_patientType);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Fill up required fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
            
        }


        private void ContactComboBox_OnTextInput(object sender, TextCompositionEventArgs textCompositionEventArgs)
        {
            ContactComboBox.IsDropDownOpen = true;
            var be = ContactComboBox.GetBindingExpression(ComboBox.TextProperty);
            be.UpdateSource();
        }


        private void PhysicianComboBox_OnTextInput(object sender, TextCompositionEventArgs textCompositionEventArgs)
        {
            PhysicianComboBox.IsDropDownOpen = true;
            var be = PhysicianComboBox.GetBindingExpression(ComboBox.TextProperty);
            be.UpdateSource();
        }

        private void NurseComboBox_OnTextInput(object sender, TextCompositionEventArgs textCompositionEventArgs)
        {
            NurseComboBox.IsDropDownOpen = true;
            var be = NurseComboBox.GetBindingExpression(ComboBox.TextProperty);
            be.UpdateSource();
        }
        private void NurseComboBox_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                NurseComboBox.IsDropDownOpen = true;
                var be = NurseComboBox.GetBindingExpression(ComboBox.TextProperty);
                be.UpdateSource();
            }
            if (e.Key == Key.Up && NurseComboBox.IsDropDownOpen)
            {
                if (NurseComboBox.SelectedIndex != -1)
                {
                    NurseComboBox.SelectedIndex = NurseComboBox.SelectedIndex - 1;
                    if (NurseComboBox.SelectedIndex == -1)
                    {
                        var be = NurseComboBox.GetBindingExpression(ComboBox.TextProperty);
                        be.UpdateSource();
                    }
                }
            }
            if (e.Key == Key.Down && NurseComboBox.IsDropDownOpen)
                if (NurseComboBox.SelectedIndex < NurseComboBox.Items.Count)
                    NurseComboBox.SelectedIndex = NurseComboBox.SelectedIndex + 1;

        }
        private void SubscriberBox_OnTextInput(object sender, TextCompositionEventArgs textCompositionEventArgs)
        {
            SubscriberBox.IsDropDownOpen = true;
            var be = SubscriberBox.GetBindingExpression(ComboBox.TextProperty);
            be.UpdateSource();
        }

        private void WardBox_OnTextInput(object sender, TextCompositionEventArgs textCompositionEventArgs)
        {
            WardBox.IsDropDownOpen = true;
            var be = WardBox.GetBindingExpression(ComboBox.TextProperty);
            be.UpdateSource();
        }

        private void BedBox_OnTextInput(object sender, TextCompositionEventArgs textCompositionEventArgs)
        {
            BedBox.IsDropDownOpen = true;
            var be = BedBox.GetBindingExpression(ComboBox.TextProperty);
            be.UpdateSource();
        }

        private void ConditionBox_OnTextInput(object sender, TextCompositionEventArgs textCompositionEventArgs)
        {
            ConditionBox.IsDropDownOpen = true;
            var be = ConditionBox.GetBindingExpression(ComboBox.TextProperty);
            be.UpdateSource();
        }

       

        private void PhysicianComboBox_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                PhysicianComboBox.IsDropDownOpen = true;
                var be = PhysicianComboBox.GetBindingExpression(ComboBox.TextProperty);
                be.UpdateSource();
            }
            if(e.Key == Key.Up && PhysicianComboBox.IsDropDownOpen)
            {
                if (PhysicianComboBox.SelectedIndex != -1)
                {
                    PhysicianComboBox.SelectedIndex = PhysicianComboBox.SelectedIndex - 1;
                    if (PhysicianComboBox.SelectedIndex == -1)
                    {
                        var be = PhysicianComboBox.GetBindingExpression(ComboBox.TextProperty);
                        be.UpdateSource();
                    }
                }
            }
            if (e.Key == Key.Down && PhysicianComboBox.IsDropDownOpen)
                if (PhysicianComboBox.SelectedIndex < PhysicianComboBox.Items.Count)
                    PhysicianComboBox.SelectedIndex = PhysicianComboBox.SelectedIndex + 1;
        }

        private void ContactComboBox_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                ContactComboBox.IsDropDownOpen = true;
                var be = ContactComboBox.GetBindingExpression(ComboBox.TextProperty);
                be.UpdateSource();
            }

            if (e.Key == Key.Up && ContactComboBox.IsDropDownOpen)
            {
                if (ContactComboBox.SelectedIndex != -1)
                {
                    ContactComboBox.SelectedIndex = ContactComboBox.SelectedIndex - 1;
                    if (ContactComboBox.SelectedIndex == -1)
                    {
                        var be = ContactComboBox.GetBindingExpression(ComboBox.TextProperty);
                        be.UpdateSource();
                    }
                }
            }
            if (e.Key == Key.Down && ContactComboBox.IsDropDownOpen)
                if (ContactComboBox.SelectedIndex < ContactComboBox.Items.Count)
                    ContactComboBox.SelectedIndex = ContactComboBox.SelectedIndex + 1;
        }

        private void SubscriberBox_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                SubscriberBox.IsDropDownOpen = true;
                var be = SubscriberBox.GetBindingExpression(ComboBox.TextProperty);
                be.UpdateSource();
            }
            if (e.Key == Key.Up && SubscriberBox.IsDropDownOpen)
            {
                if (SubscriberBox.SelectedIndex != -1)
                {
                    SubscriberBox.SelectedIndex = SubscriberBox.SelectedIndex - 1;
                    if (SubscriberBox.SelectedIndex == -1)
                    {
                        var be = SubscriberBox.GetBindingExpression(ComboBox.TextProperty);
                        be.UpdateSource();
                    }
                }
            }
            if (e.Key == Key.Down && SubscriberBox.IsDropDownOpen)
                if (SubscriberBox.SelectedIndex < SubscriberBox.Items.Count)
                    SubscriberBox.SelectedIndex = SubscriberBox.SelectedIndex + 1;
        }

        private void WardBox_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                WardBox.IsDropDownOpen = true;
                var be = WardBox.GetBindingExpression(ComboBox.TextProperty);
                be.UpdateSource();
            }
            if (e.Key == Key.Up && WardBox.IsDropDownOpen)
            {
                if (WardBox.SelectedIndex != -1)
                {
                    WardBox.SelectedIndex = WardBox.SelectedIndex - 1;
                    if (WardBox.SelectedIndex == -1)
                    {
                        var be = WardBox.GetBindingExpression(ComboBox.TextProperty);
                        be.UpdateSource();
                    }
                }
            }
            if (e.Key == Key.Down && WardBox.IsDropDownOpen)
                if (WardBox.SelectedIndex < WardBox.Items.Count)
                    WardBox.SelectedIndex = WardBox.SelectedIndex + 1;
        }

        private void BedBox_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                BedBox.IsDropDownOpen = true;
                var be = BedBox.GetBindingExpression(ComboBox.TextProperty);
                be.UpdateSource();
            }
            if (e.Key == Key.Up && BedBox.IsDropDownOpen)
            {
                if (BedBox.SelectedIndex != -1)
                {
                    BedBox.SelectedIndex = BedBox.SelectedIndex - 1;
                    if (BedBox.SelectedIndex == -1)
                    {
                        var be = BedBox.GetBindingExpression(ComboBox.TextProperty);
                        be.UpdateSource();
                    }
                }
            }
            if (e.Key == Key.Down && BedBox.IsDropDownOpen)
                if (BedBox.SelectedIndex < BedBox.Items.Count)
                    BedBox.SelectedIndex = BedBox.SelectedIndex + 1;

        }

        private void ConditionBox_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                ConditionBox.IsDropDownOpen = true;
                var be = ConditionBox.GetBindingExpression(ComboBox.TextProperty);
                be.UpdateSource();
            }
            if (e.Key == Key.Up && ConditionBox.IsDropDownOpen)
            {
                if (ConditionBox.SelectedIndex != -1)
                {
                    ConditionBox.SelectedIndex = ConditionBox.SelectedIndex - 1;
                    if (ConditionBox.SelectedIndex == -1)
                    {
                        var be = ConditionBox.GetBindingExpression(ComboBox.TextProperty);
                        be.UpdateSource();
                    }
                }
            }
            if (e.Key == Key.Down && ConditionBox.IsDropDownOpen)
                if (ConditionBox.SelectedIndex < ConditionBox.Items.Count)
                    ConditionBox.SelectedIndex = ConditionBox.SelectedIndex + 1;
        }
    }
}

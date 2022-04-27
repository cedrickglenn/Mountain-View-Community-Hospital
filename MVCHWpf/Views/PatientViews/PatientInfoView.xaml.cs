using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MVCHWpf.ViewModels;
using MVCHWpf.ViewModels.Persons;
using MVCHWpf.ViewModels.Persons.PatientViewModels;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.PatientViews
{
    /// <summary>
    /// Interaction logic for PatientInfoView.xaml
    /// </summary>
    public partial class PatientInfoView : UserControl
    {
        private EditPatientViewModel _toEditPatient;
        private CombinedPatientViewModel _editPatient;
        private PersonService _personService;
        private WardService _wardService;
        private BedService _bedService;
        private VisitService _visitService;
        private string _patientType;
        private PatientService _patientService;
        private CombinedPatientViewModel _originalModel;

        public PatientInfoView()
        {
            InitializeComponent();
        }


        public PatientInfoView(CombinedPatientViewModel originalModel,
            CombinedPatientViewModel editPatient,
            PatientService patientService,
            PersonService personService,
            WardService wardService, 
            BedService bedService,
            VisitService visitService)
        {    
            InitializeComponent();
            _originalModel = originalModel;
            _editPatient = editPatient;
            _patientService = patientService;
            _personService = personService;
            _wardService = wardService;
            _bedService = bedService;
            _visitService = visitService;
            _toEditPatient = new EditPatientViewModel(_originalModel,_editPatient,_patientService,_personService,_wardService,_bedService,_visitService);
            DataContext = _toEditPatient;
            MakeAllEditableFieldsReadOnly();
            SetupWindow();
        }
        private void StartEdit()
        {
            FirstNameBox.IsReadOnly = false;
            MiddleInitialBox.IsReadOnly = false;
            LastNameBox.IsReadOnly = false;
            AddressBox.IsReadOnly = false;
            CityBox.IsReadOnly = false;
            ZipBox.IsReadOnly = false;
            StateBox.IsReadOnly = false;
            EmailBox.IsReadOnly = false;
            PhoneBox.IsReadOnly = false;
            MRNBox.IsReadOnly = false;
            CompanyBox.IsReadOnly = false;
            ContactRelationshipBox.IsReadOnly = false;
            SubscriberRelationshipBox.IsReadOnly = false;
            PolicyBox.IsReadOnly = false;
            GroupBox.IsReadOnly = false;
            InsurancePhoneBox.IsReadOnly = false;
            SubscriberBox.IsEnabled = true;
            DateOfContactBox.IsEnabled = true;
            BirthDateBox.IsEnabled = true;
            ContactComboBox.IsEnabled = true;
            DateAdmittedBox.IsEnabled = true;
            DischargeDateBox.IsEnabled = true;
            WardBox.IsEnabled = true;
            BedBox.IsEnabled = true;
            MakeRelevantFieldsVisible();
        }
        private void MakeRelevantFieldsVisible()
        {
            InpatientSelectButton.IsEnabled = true;
            OutpatientSelectButton.IsEnabled = true;
            if (_toEditPatient.PatientModel.Discriminator == "Inpatient")
            {
                InpatientSelectButton.IsChecked = true;
                OutpatientSelectButton.IsChecked = false;
                InpatientGrid.Visibility = Visibility.Visible;
                OutpatientGrid.Visibility = Visibility.Collapsed;
                _patientType = "Inpatient";
            }
            if (_toEditPatient.PatientModel.Discriminator == "Outpatient")
            {
                InpatientSelectButton.IsChecked = false;
                OutpatientSelectButton.IsChecked = true;
                OutpatientGrid.Visibility = Visibility.Visible;
                InpatientGrid.Visibility = Visibility.Collapsed;
                _patientType = "Outpatient";
            }
            if (_toEditPatient.PatientModel.SubscriberPersonId != null)
            {
                InsuranceCheckBox.IsChecked = true;
                InsuranceGrid.Visibility = Visibility.Visible;
            }
            else if (_toEditPatient.PatientModel.SubscriberPersonId == null)
            {
                InsuranceCheckBox.IsChecked = false;
                InsuranceGrid.Visibility = Visibility.Collapsed;
            }
            ContactRelationshipLabel.Visibility = Visibility.Visible;
            ContactRelationshipBox.Visibility = Visibility.Visible;
            InsuranceCheckBox.Visibility = Visibility.Visible;
            AddPersonButton.Visibility = Visibility.Visible;
            AddSubscriberButton.Visibility = Visibility.Visible;
            SaveCancelGrid.Visibility = Visibility.Visible;
        }

        private void MakeAllEditableFieldsReadOnly()
        {
            FirstNameBox.IsReadOnly = true;
            MiddleInitialBox.IsReadOnly = true;
            LastNameBox.IsReadOnly = true;
            AddressBox.IsReadOnly = true;
            CityBox.IsReadOnly = true;
            ZipBox.IsReadOnly = true;
            StateBox.IsReadOnly = true;
            EmailBox.IsReadOnly = true;
            PhoneBox.IsReadOnly = true;
            MRNBox.IsReadOnly = true;
            CompanyBox.IsReadOnly = true;
            ContactRelationshipBox.IsReadOnly = true;
            SubscriberRelationshipBox.IsReadOnly = true;
            PolicyBox.IsReadOnly = true;
            GroupBox.IsReadOnly = true;
            InsurancePhoneBox.IsReadOnly = true;
            SubscriberBox.IsEnabled = false;
            DateOfContactBox.IsEnabled = false;
            BirthDateBox.IsEnabled = false;
            ContactComboBox.IsEnabled = false;
            DateAdmittedBox.IsEnabled = false;
            DischargeDateBox.IsEnabled = false;
            WardBox.IsEnabled = false;
            BedBox.IsEnabled = false;
        }
        private void SetupWindow()
        {
            if (_toEditPatient.PatientModel.Discriminator == "Inpatient")
            {
                InpatientSelectButton.IsChecked = true;
                OutpatientSelectButton.IsChecked = false;
                InpatientSelectButton.IsEnabled = false;
                OutpatientSelectButton.IsEnabled = false;
                InpatientGrid.Visibility = Visibility.Visible;
                OutpatientGrid.Visibility = Visibility.Collapsed;
            }
            if (_toEditPatient.PatientModel.Discriminator == "Outpatient")
            {
                InpatientSelectButton.IsEnabled = false;
                OutpatientSelectButton.IsEnabled = false;
                OutpatientSelectButton.IsChecked = true;
                InpatientSelectButton.IsChecked = false;
                InpatientGrid.Visibility = Visibility.Collapsed;
                OutpatientGrid.Visibility = Visibility.Visible;
            }
            if (_toEditPatient.PatientModel.SubscriberPersonId == null)
            {
                InsuranceGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                InsuranceGrid.Visibility = Visibility.Visible;
            }
            if (_toEditPatient.PatientModel.ContactPersonId == null)
            {
                ContactRelationshipLabel.Visibility = Visibility.Collapsed;
                ContactRelationshipBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                ContactRelationshipLabel.Visibility = Visibility.Visible;
                ContactRelationshipBox.Visibility = Visibility.Visible;
            }
            InsuranceCheckBox.Visibility = Visibility.Collapsed;
            AddPersonButton.Visibility = Visibility.Collapsed;
            AddSubscriberButton.Visibility = Visibility.Collapsed;
            SaveCancelGrid.Visibility = Visibility.Collapsed;
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            StartEdit();
        }

        private void InsuranceCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            InsuranceGrid.Visibility = Visibility.Visible;
        }

        private void InsuranceCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            InsuranceGrid.Visibility = Visibility.Collapsed;
        }

        private void AddPersonButton_Onclick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SubscriberBox_OnTextInput(object sender, TextCompositionEventArgs e)
        {
            SubscriberBox.IsDropDownOpen = true;
            var be = SubscriberBox.GetBindingExpression(ComboBox.TextProperty);
            be.UpdateSource();
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

        private void ContactComboBox_OnTextInput(object sender, TextCompositionEventArgs e)
        {
            ContactComboBox.IsDropDownOpen = true;
            var be = ContactComboBox.GetBindingExpression(ComboBox.TextProperty);
            be.UpdateSource();
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

        private void WardBox_OnTextInput(object sender, TextCompositionEventArgs e)
        {
            WardBox.IsDropDownOpen = true;
            var be = WardBox.GetBindingExpression(ComboBox.TextProperty);
            be.UpdateSource();
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

        private void BedBox_OnTextInput(object sender, TextCompositionEventArgs e)
        {
            BedBox.IsDropDownOpen = true;
            var be = BedBox.GetBindingExpression(ComboBox.TextProperty);
            be.UpdateSource();
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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EditPatientViewModel(_originalModel,_editPatient,_patientService, _personService,_wardService,_bedService,_visitService);
            MakeAllEditableFieldsReadOnly();
            SetupWindow();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_toEditPatient.SaveAndVerify(_patientType))
            {
                _toEditPatient.Edit(_patientType);
                _originalModel.PatientModel = _toEditPatient.PatientModel;
                _originalModel.InpatientModel = _toEditPatient.InpatientModel;
                _originalModel.OutpatientModel = _toEditPatient.OutpatientModel;
                MakeAllEditableFieldsReadOnly();
                SetupWindow();
            }
            
        }

        private void VisitGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid)sender,
                e.OriginalSource as DependencyObject) as DataGridRow;
            if (row == null)
            {
                e.Handled = true;
                return;
            }
            
        }

        private void AddVisitButton_Onclick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

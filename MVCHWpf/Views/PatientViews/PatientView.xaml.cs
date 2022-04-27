using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Datalayer.EFClasses;
using MVCHWpf.ViewModels;
using MVCHWpf.ViewModels.Persons;
using MVCHWpf.ViewModels.Persons.PatientViewModels;
using MVCHWpf.Views.PatientViews;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;
using Syncfusion.UI.Xaml.Grid;

namespace MVCHWpf.Views.PatientViews
{
    /// <summary>
    /// Interaction logic for PatientView.xaml
    /// </summary>
    public partial class PatientView : UserControl
    {
        private PatientListViewModel _patientListViewModel;
        private PatientService _patientService;
        private DiagnosisService _diagnosisService;
        private PersonService _personService;
        private EmployeeService _employeeService;
        private WardService _wardService;
        private BedService _bedService;
        private PhysicianService _physicianService;
        private VitalRecordService _vitalRecordService;
        private ConditionService _conditionService;
        private VisitService _visitService;
        private TreatmentService _treatmentService;
        private ProcedureService _procedureService;
        private OrderServiceLayer _orderServiceLayer;
        private OrderServiceService _orderServiceService;
        private PatientOrderService _patientOrderService;
        private OrderItemService _orderItemService;

        public PatientView()
        {
            _patientService = new PatientService(new MVCHContext());
            _patientListViewModel = new PatientListViewModel(_patientService);
            _diagnosisService = new DiagnosisService(new MVCHContext());
            _personService = new PersonService(new MVCHContext());
            _employeeService = new EmployeeService(new MVCHContext());
            _wardService = new WardService(new MVCHContext());
            _bedService = new BedService(new MVCHContext());
            _physicianService = new PhysicianService(new MVCHContext());
            _vitalRecordService = new VitalRecordService(new MVCHContext());
            _conditionService = new ConditionService(new MVCHContext());
            _visitService = new VisitService(new MVCHContext());
            _treatmentService = new TreatmentService(new MVCHContext());
            _procedureService = new ProcedureService(new MVCHContext());
            _orderServiceLayer = new OrderServiceLayer(new MVCHContext());
            _orderServiceService = new OrderServiceService(new MVCHContext());
            _patientOrderService = new PatientOrderService(new MVCHContext());
            _orderItemService = new OrderItemService(new MVCHContext());
            DataContext = _patientListViewModel;
            InitializeComponent();
        }


        private void AddPatientButton_Onclick(object sender, RoutedEventArgs e)
        {
            var addPatientView = new AddPatientView(_patientListViewModel,
                _patientService,
                _diagnosisService,
                _personService,
                _employeeService,
                _wardService,
                _bedService,    
                _physicianService,
                _vitalRecordService,
                _conditionService);
            addPatientView.Show();

        }


        private void PatientGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedPatient = (CombinedPatientViewModel)PatientGrid.SelectedItem;
            if (selectedPatient == null)
            {
                e.Handled = true;
                return;
            }
            
            // --- code from here
            // for convenience, create a CreateCopy() method in the InPatient class
            if (!selectedPatient.IsOutpatient)
            {
                var patientDuplicate = new CombinedPatientViewModel(selectedPatient.InpatientModel.CreateCopy(selectedPatient.InpatientModel));
                // TODO: create EditPatientVm
                // make sure to add method SavedEdit() to inform this object that you saved
                // your changes during edit
                var editPatientView = new EditPatientView(selectedPatient,
                    patientDuplicate,
                    _patientService,
                    _personService,
                    _wardService,
                    _bedService,
                    _visitService,
                    _treatmentService,
                    _procedureService,
                    _physicianService,
                    _diagnosisService,
                    _conditionService,
                    _vitalRecordService,
                    _employeeService,
                    _orderServiceLayer,
                    _orderServiceService,
                    _patientOrderService,
                    _orderItemService);
                editPatientView.Show();
            }
            else
            {
                var patientDuplicate = new CombinedPatientViewModel(selectedPatient.OutpatientModel.CreateCopy(selectedPatient.OutpatientModel));
                // TODO: create EditPatientVm
                // make sure to add method SavedEdit() to inform this object that you saved
                // your changes during edit
                var editPatientView = new EditPatientView(selectedPatient,
                    patientDuplicate,
                    _patientService,
                    _personService,
                    _wardService,
                    _bedService,
                    _visitService,
                    _treatmentService,
                    _procedureService,
                    _physicianService,
                    _diagnosisService,
                    _conditionService,
                    _vitalRecordService,
                    _employeeService,
                    _orderServiceLayer,
                    _orderServiceService,
                    _patientOrderService,
                    _orderItemService);
                editPatientView.Show();
            }
            
            // assuming you display another window
           
            // replace the associated model to the edited model
            // remember the model to be edited was a COPY
            //if (editPatientVm.SavedEdit())
            //    InpatientModel = patientToEdit;
        }

        // --- to here may be placed in the PatientListViewModel instead
        private void SearchPatientBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            PatientGrid.SearchHelper.AllowFiltering = true;
            if (e.Key == Key.Back || e.Key == Key.Space)
            {
                PatientGrid.SearchHelper.Search(SearchPatientBox.Text);
            }
        }

        private void SearchPatientBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            PatientGrid.SearchHelper.AllowFiltering = true;
            PatientGrid.SearchHelper.Search(SearchPatientBox.Text);
        }
    }
    }

using System;
using System.Collections.Generic;
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
using MVCHWpf.ViewModels.Persons;
using MVCHWpf.ViewModels.Persons.PatientViewModels;
using MVCHWpf.Views.DiagnosisViews;
using MVCHWpf.Views.OrderViews;
using MVCHWpf.Views.PatientOrderViews;
using MVCHWpf.Views.TreatmentViews;
using MVCHWpf.Views.VitalRecordViews;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.PatientViews
{
/// <summary>
/// Interaction logic for EditPatientView.xaml
/// </summary>
public partial class EditPatientView : Window
{
    public EditPatientView()
    {
        InitializeComponent();
    }

    

    public EditPatientView(CombinedPatientViewModel originalModel,
        CombinedPatientViewModel patientModel,
        PatientService patientService,
        PersonService personService,
        WardService wardService,
        BedService bedService,
        VisitService visitService,
        TreatmentService treatmentService,
        ProcedureService procedureService,
        PhysicianService physicianService,
        DiagnosisService diagnosisService,
        ConditionService conditionService,
        VitalRecordService vitalRecordService,
        EmployeeService nurseService,
        OrderServiceLayer orderServiceLayer,
        OrderServiceService orderServiceService,
        PatientOrderService patientOrderService,
        OrderItemService orderItemService)
    {
        InitializeComponent();
        InfoTab.Content = new PatientInfoView(originalModel,patientModel, patientService, personService , wardService,
            bedService, visitService);
        TreatmentTab.Content = new TreatmentView(treatmentService,originalModel.PatientModel.PersonId,procedureService,physicianService);
        DiagnosisTab.Content = new DiagnosisView(diagnosisService, originalModel.PatientModel.PersonId,
            conditionService, physicianService);
        VitalRecordTab.Content =
            new VitalRecordView(vitalRecordService, originalModel.PatientModel.PersonId, nurseService);
        OrderTab.Content = new OrderView(orderServiceLayer, originalModel.PatientModel.PersonId, orderServiceService,
            physicianService);
        PatientOrderTab.Content = new PatientOrderView(patientOrderService, originalModel.PatientModel.PersonId, orderItemService);
    }

    
}
}

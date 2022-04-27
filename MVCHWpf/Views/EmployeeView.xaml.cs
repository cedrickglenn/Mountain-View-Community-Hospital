using System.Windows;
using System.Windows.Controls;
using MVCHWpf.Views.NurseViews;
using MVCHWpf.Views.StaffViews;
using MVCHWpf.Views.TechnicianViews;

namespace MVCHWpf.Views
{
/// <summary>
/// Interaction logic for EditPatientView.xaml
/// </summary>
public partial class EmployeeView : UserControl
{
    public EmployeeView()
    {
        InitializeComponent();
        StaffTab.Content = new StaffView();
        TechnicianTab.Content = new TechnicianView();
        NurseTab.Content = new NurseView();
    }

}
}

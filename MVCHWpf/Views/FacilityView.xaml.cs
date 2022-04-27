using System.Windows;
using System.Windows.Controls;
using MVCHWpf.Views.FacilityViews;
using MVCHWpf.Views.NurseViews;
using MVCHWpf.Views.StaffViews;
using MVCHWpf.Views.TechnicianViews;
namespace MVCHWpf.Views
{
/// <summary>
/// Interaction logic for EditPatientView.xaml
/// </summary>
public partial class FacilityView : UserControl
{
    public FacilityView()
    {
        InitializeComponent();
        FacilityTab.Content = new FacilityGridView();
    }

}
}

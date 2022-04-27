using System.Windows;
using System.Windows.Input;
using Datalayer.EFClasses;

namespace MVCHWpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        private void ButtonPopUpLogout_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonCloseMenu_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }


        private void PhysicianButton_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CollapseOtherViews();
            PhysicianGridView.Visibility = Visibility.Visible;
        }

        private void PatientButton_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CollapseOtherViews();
            PatientGridView.Visibility = Visibility.Visible;
        }

        private void HomeButton_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CollapseOtherViews();
        }

        private void CollapseOtherViews()
        {
            EmployeeGridView.Visibility = Visibility.Collapsed;
            PatientGridView.Visibility = Visibility.Collapsed;
            PhysicianGridView.Visibility = Visibility.Collapsed;
            VolunteerGridView.Visibility = Visibility.Collapsed;
            FacilityGridView.Visibility = Visibility.Collapsed;
        }

        private void EmployeeButton_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CollapseOtherViews();
            EmployeeGridView.Visibility = Visibility.Visible;
        }

        private void VolunteerButton_OnMouseLeftButtonUpButton_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CollapseOtherViews();
            VolunteerGridView.Visibility = Visibility.Visible;
        }

        private void FacilityButton_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CollapseOtherViews();
            FacilityGridView.Visibility = Visibility.Visible;
        }
    }
}

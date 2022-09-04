using ModulesCal;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Time_Management_App.Classes;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for Capture.xaml
    /// </summary>
    public partial class Capture : Page
    {
        private int NumOfWeeks;
        public Capture()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                NumOfWeeks = int.Parse(txtNumOfWeeks.Text);
                DateTime StartDate = DateTime.Parse(dateStart.Text);
                Enable();
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter your details!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnCapture_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Constructors
            DashboardClass dashboardClass = DashboardClass.Instant;
            SelfStudy selfStudy = new SelfStudy();
            Modules modules = new Modules();
            // Gets the data from the user
            try
            {
                string code = txtCode.Text;
                string name = txtName.Text;
                int hoursPerWeek = int.Parse(txtHours.Text);
                int credits = int.Parse(txtCredits.Text);
                modules.Code = code;
                modules.Name = name;
                modules.HoursPerWeek = hoursPerWeek;
                modules.Credits = credits;
                modules.SelfStudyHours = selfStudy.CalSelfStudyHours(credits, hoursPerWeek, NumOfWeeks);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter your module details!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Adds the capture class to the modules list
            dashboardClass.setModules(modules);
            // Clears the textboxes so that new modules can be added
            txtCode.Clear();
            txtName.Clear();
            txtHours.Clear();
            txtCredits.Clear();
        }

        private void NumOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Only allows the user to enter numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Enable()
        {
            txtCode.IsEnabled = true;
            txtName.IsEnabled = true;
            txtCredits.IsEnabled = true;
            txtHours.IsEnabled = true;
            btnCapture.IsEnabled = true;

            txtNumOfWeeks.IsEnabled = false;
            dateStart.IsEnabled = false;
            btnEnter.IsEnabled = false;

        }
    }
}

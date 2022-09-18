using System;
using System.Diagnostics;
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
        private DashboardClass dashboardClass;

        private Student student;

        public Capture(DashboardClass dashboardClass, Student student)
        {
            InitializeComponent();
            this.dashboardClass = dashboardClass;
            this.student = student;
        }

        private void btnCapture_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            try
            {
                // Gets the data from the user
                CaptureClass captureClass = new CaptureClass(txtCode.Text, txtName.Text, int.Parse(txtHours.Text), int.Parse(txtCredits.Text), 1);
                captureClass.CaptureData(student.NumOfWeeks, dashboardClass);
                clearTxtBox();
            }

            catch (Exception)
            {
                MessageBox.Show("Please enter your module details!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void NumOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Only allows the user to enter numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnGetModuleCodes_Click(object sender, RoutedEventArgs e)
        {
            // Link to the varsity college website with all available modules
            Process.Start(new ProcessStartInfo("https://www.varsitycollege.co.za/programmes/full-time") { UseShellExecute = true });
        }

        private void clearTxtBox()
        {
            // Clears the text boxes so that new modules can be added and sets the cursors focus to the code text box
            txtCode.Clear();
            txtName.Clear();
            txtHours.Clear();
            txtCredits.Clear();
            txtCode.Focus();
        }
    }
}

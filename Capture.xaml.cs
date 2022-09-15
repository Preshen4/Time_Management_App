using ModulesCal;
using System;
using System.Diagnostics;
using System.Linq;
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

        public Capture()
        {
            InitializeComponent();
        }

        public Capture(DashboardClass dashboardClass, Student student)
        {
            InitializeComponent();
            this.dashboardClass = dashboardClass;
            this.student = student;
        }

        private void btnCapture_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Constructors
            SelfStudy selfStudy = new SelfStudy();
            Modules modules = new Modules();

            try
            {
                // Gets the data from the user
                string code = txtCode.Text;
                string name = txtName.Text;
                int hoursPerWeek = int.Parse(txtHours.Text);
                int credits = int.Parse(txtCredits.Text);
                if (!CheckIfCodeExsits(code))
                {
                    modules.Code = code;
                    modules.Name = name;
                    modules.HoursPerWeek = hoursPerWeek;
                    modules.Credits = credits;
                    modules.SelfStudyHours = selfStudy.CalSelfStudyHours(credits, hoursPerWeek, student.NumOfWeeks);
                    modules.RemainingHours = modules.SelfStudyHours;
                    // Adds the capture class to the modules list
                    dashboardClass.setModules(modules);
                }
                else
                    clearTxtBox();


            }

            catch (Exception)
            {
                MessageBox.Show("Please enter your module details!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                clearTxtBox();
            }
        }
        private void NumOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Only allows the user to enter numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool CheckIfCodeExsits(string code)
        {
            foreach (var item in dashboardClass.getModules().Where(x => x.Code == code))
            {
                MessageBox.Show("You already entered the details for this module!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            return false;
        }

        private void btnGetModuleCodes_Click(object sender, RoutedEventArgs e)
        {
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

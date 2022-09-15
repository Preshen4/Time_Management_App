using ModulesCal;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Time_Management_App.Classes;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for Studied.xaml
    /// </summary>
    public partial class Studied : Page
    {
        private DashboardClass dashboardClass;
        public Studied(DashboardClass dashboardClass)
        {
            InitializeComponent();

            // Adds all the module codes into the combo box
            foreach (var item in dashboardClass.getModules().Select(x => x.Code))
            {
                cmbModules.Items.Add(item);
            }

            this.dashboardClass = dashboardClass;
        }
        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            // Constructor of the SelfStudy Class in the Class Library
            SelfStudy selfStudy = new SelfStudy();
            string moduleCode = "";

            try
            {

                // Gets the selected module code 
                moduleCode = cmbModules.SelectedItem.ToString();

                // Gets users data
                DateTime date = DateTime.Parse(dateStudied.Text);
                int hours = int.Parse(txtHours.Text);

                // LINQ used to update the remaining hours in the list
                foreach (var item in dashboardClass.getModules().Where(x => x.Code == moduleCode))
                {
                    item.RemainingHours = item.SelfStudyHours - hours;
                }

                MessageBox.Show($"Your remaining hours for {moduleCode} is now updated! You can view it on your Dashboard",
                    "Completed", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            catch (Exception)
            {
                MessageBox.Show("Please enter your study details!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                txtHours.Clear();
            }

        }

        private void txtHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}

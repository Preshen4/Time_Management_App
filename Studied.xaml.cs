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
        private Student student;
        public Studied(DashboardClass dashboardClass, Student student)
        {
            InitializeComponent();

            // Adds all the module codes into the combo box
            foreach (var item in dashboardClass.getModules().Select(x => x.Code))
            {
                cmbModules.Items.Add(item);
            }

            this.dashboardClass = dashboardClass;
            this.student = student;
        }
        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StudiedClass studiedClass = new StudiedClass(cmbModules.SelectedItem.ToString(), int.Parse(txtHours.Text));
                studiedClass.UpdateRemainingHours(dashboardClass, student);
            }

            catch (Exception)
            {
                MessageBox.Show("Please enter your study details!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void txtHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}

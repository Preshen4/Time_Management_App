using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Time_Management_App.Classes;
using TimeManagementLib.Models;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for Studied.xaml
    /// </summary>
    public partial class Studied : Page
    {

        public Studied()
        {
            InitializeComponent();

            StudiedClass studiedClass = new StudiedClass();
            IList<StudentModule>? modules = studiedClass.GetModuleCodes();
            if (modules != null)
            {
                // Add each code to the combo box
                foreach (var code in modules)
                {
                    cmbModules.Items.Add(code.Code);
                }
            }
            else
            {
                MessageBox.Show("No modules found. Please add a module", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            // Checks if the module code is empty
            if (cmbModules.SelectedItem == null)
            {
                MessageBox.Show("Please select a module code!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Ask the user to confirm the capture
            MessageBoxResult result = MessageBox.Show("Are you sure you want to capture this study session?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            string moduleCode = cmbModules.SelectedItem.ToString()!;
            DateTime date = DateTime.Parse(dateStudied.Text);
            int hours = int.Parse(txtHours.Text);

            StudiedClass studiedClass = new StudiedClass();
            new Thread(() => studiedClass.Study(moduleCode!, hours)).Start();

            MessageBox.Show($"Your remaining hours for {moduleCode} is now updated! You can view it on your Dashboard",
                "Completed", MessageBoxButton.OK, MessageBoxImage.Information);

            txtHours.Clear();
        }

        private void txtHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}

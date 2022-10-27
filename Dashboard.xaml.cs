using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Time_Management_App.Classes;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private readonly DashboardClass dashboardClass = new DashboardClass();
        public Dashboard()
        {
            InitializeComponent();

            // Displays the relevant data on the dashboard
            modulesDataGrid.ItemsSource = dashboardClass.GetModules();
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Gets the selected module code from the datagrid
            try
            {
                var module = modulesDataGrid.SelectedItem.GetType().GetProperty("Code")?.GetValue(modulesDataGrid.SelectedItem, null)?.ToString();
                new Thread(() => Delete(module!)).Start();
                Thread.Sleep(2000);
                modulesDataGrid.ItemsSource = null;
                modulesDataGrid.ItemsSource = dashboardClass.GetModules();
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a module to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnMostHours_Click(object sender, RoutedEventArgs e)
        {
            new Thread(() => MostHours()).Start();
        }

        private void btnMostCredits_Click(object sender, RoutedEventArgs e)
        {
            new Thread(() => MostCredits()).Start();
        }

        private void MostHours()
        {
            MessageBox.Show(dashboardClass.MostHours(), "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MostCredits()
        {
            MessageBox.Show(dashboardClass.MostCredits(), "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Delete(string moduleCode)
        {
            if (dashboardClass.DeleteModule(moduleCode))
            {
                MessageBox.Show("Module deleted successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            MessageBox.Show("Module not deleted", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

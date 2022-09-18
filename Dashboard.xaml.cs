using ModulesCal;
using System.Linq;
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
        private DashboardClass dashboardClass;
        public Dashboard(DashboardClass dashboardClass)
        {
            InitializeComponent();

            // sets the modules data into the datagrid for the user to view
            modulesDataGrid.ItemsSource = from item in dashboardClass.getModules() select item;
            this.dashboardClass = dashboardClass;
        }


        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Gets the selected row
            Modules selectedRow = (Modules)modulesDataGrid.SelectedItem;

            // Removes the selected row from the list
            dashboardClass.getModules().Remove(selectedRow);

            // Refreshes the datagrid
            modulesDataGrid.ItemsSource = null;
            modulesDataGrid.ItemsSource = dashboardClass.getModules();
        }

        private void btnMostHours_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (var item in dashboardClass.getModules().Where(x => x.RemainingHours == dashboardClass.getModules().Max(y => y.RemainingHours)))
            {
                // Displays the module with the most remaining hours
                MessageBox.Show($"The module with the most hours of self studying remaining is : {item.Code} with {item.RemainingHours} hours left");
            }
        }

        private void btnMostCredits_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in dashboardClass.getModules().Where(x => x.Credits == dashboardClass.getModules().Max(y => y.Credits)))
            {
                // Displays the module with the most credits
                MessageBox.Show($"The module with the most credits is : {item.Code} with {item.Credits} credits");
            }
        }
    }
}

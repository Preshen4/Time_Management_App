using ModulesCal;
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
            modulesDataGrid.ItemsSource = dashboardClass.getModules();
            this.dashboardClass = dashboardClass;
        }


        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Gets the selected row
            Modules selectedRow = (Modules)modulesDataGrid.SelectedItem;

            // Removes the selected row
            dashboardClass.getModules().Remove(selectedRow);

            // Refreshes the datagrid
            modulesDataGrid.ItemsSource = null;
            modulesDataGrid.ItemsSource = dashboardClass.getModules();
        }
    }
}

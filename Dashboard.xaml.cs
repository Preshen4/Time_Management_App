using System.Windows.Controls;
using Time_Management_App.Classes;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private DashboardClass dashboardClass = DashboardClass.Instant;
        public Dashboard()
        {
            InitializeComponent();
            // sets the modules data into the datagrid for the user to view
            modulesDataGrid.ItemsSource = dashboardClass.getModules();
        }

    }
}

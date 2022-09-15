using System.Windows.Controls;
using Time_Management_App.Classes;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard(DashboardClass dashboardClass)
        {
            InitializeComponent();

            // sets the modules data into the datagrid for the user to view
            modulesDataGrid.ItemsSource = dashboardClass.getModules();
        }
        public Dashboard()
        {
            InitializeComponent();
        }

    }
}

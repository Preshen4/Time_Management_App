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
            modulesDataGrid.ItemsSource = dashboardClass.getModules();
        }

    }
}

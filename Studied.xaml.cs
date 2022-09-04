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
        private DashboardClass dashboardClass = DashboardClass.Instant;
        public Studied()
        {
            InitializeComponent();
            foreach (var item in dashboardClass.getModules())
            {
                cmbModules.Items.Add(item.Code);
            }
        }
        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}

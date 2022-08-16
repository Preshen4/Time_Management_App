using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for Capture.xaml
    /// </summary>
    public partial class Capture : Page
    {
        public Capture()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void btnCapture_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void NumOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

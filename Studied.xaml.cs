using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

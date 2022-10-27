using System.Windows;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Shell.Content = new Login();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Shows the selected page and makes the search bar at the very top of the form disappear
        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            Shell.Content = new Dashboard();
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            Shell.Content = new Capture();
        }

        private void btnStudy_Click(object sender, RoutedEventArgs e)
        {
            Shell.Content = new Studied();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (Shell.Content.ToString()!.Equals("Time_Management_App.Login"))
            {
                Shell.Content = new SignUp();
                txtSignUp.Text = "Login";
            }
            else
            {
                Shell.Content = new Login();
                txtSignUp.Text = "SignUp";
            }
        }
    }
}

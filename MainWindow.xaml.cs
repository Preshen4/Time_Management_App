using System.Windows;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Code Attribution 
        // 1) 
        // Use of the App.config file
        // Author : Cale 
        // Used to store values that are used throughout the application
        // 2) 
        // EF Core - Database First Migrations
        // Author : Cale
        // Showed the migration step and the basic of how to use it
        // 3) 
        // Fluent Validation - Validation Rules 
        // Author : Time Corey
        // Link : https://youtu.be/Zh1ccvTFzs8
        // Classes stored in the Validation folder
        // 4)
        // The use of ! and ? in removing null warnings
        // Author : Rijwan Ansari
        // Link : https://www.c-sharpcorner.com/article/solution-non-nullable-property-must-contain-a-non-null-value-in-net-6/
        // This is used throughout the whole application


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

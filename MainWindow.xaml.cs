using Microsoft.EntityFrameworkCore;
using System.Windows;
using TimeManagementLib.Models;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Code Attribution 
        // 1) 
        // EF Core - Database First Migrations
        // Author : Cale
        // Showed the migration step and the basic of how to use it
        // 2) 
        // Fluent Validation - Validation Rules 
        // Author : Time Corey
        // Link : https://youtu.be/Zh1ccvTFzs8
        // Classes stored in the Validation folder
        // 3)
        // The use of ! and ? in removing null warnings
        // Author : Rijwan Ansari
        // Link : https://www.c-sharpcorner.com/article/solution-non-nullable-property-must-contain-a-non-null-value-in-net-6/
        // This is used throughout the whole application
        // 4)
        // Multi threading
        // Author : JaredPar
        // Link : https://stackoverflow.com/questions/1195896/threadstart-with-parameters
        // This is used throughout the whole application. It is used so that the application doesn't stop while doing a task in the background.

        public MainWindow()
        {
            InitializeComponent();
            TimeManagementAppContext context = new TimeManagementAppContext();
            context.Students.Load();
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

using System;
using System.Windows;
using Time_Management_App.Classes;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Student student = new Student();

        public DashboardClass dashboardClass = new DashboardClass();
        public MainWindow(Student student)
        {
            InitializeComponent();
            Shell.Content = new Dashboard();
            this.student = student;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Shows the selected page and makes the search bar at the very top of the form disappear
        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            Shell.Content = new Dashboard(dashboardClass);
            GC.Collect();
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            Shell.Content = new Capture(dashboardClass, student);
        }

        private void btnStudy_Click(object sender, RoutedEventArgs e)
        {
            Shell.Content = new Studied(dashboardClass);
            GC.Collect();
        }

    }
}

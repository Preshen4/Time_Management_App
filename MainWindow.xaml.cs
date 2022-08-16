using System.Windows;
using System.Windows.Input;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsMax = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMax)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1600;
                    this.Height = 800;

                    IsMax = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMax = true;
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            Shell.Content = new Dashboard();
            MakeSearchVisible(Visibility.Visible);
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            Shell.Content = new Capture();
            MakeSearchVisible(Visibility.Hidden);
        }

        private void btnStudy_Click(object sender, RoutedEventArgs e)
        {
            Shell.Content = new Studied();
            MakeSearchVisible(Visibility.Hidden);
        }
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MakeSearchVisible(Visibility visibility)
        {
            txtSearch.Visibility = visibility;
            txtbSearch.Visibility = visibility;
            iSearch.Visibility = visibility;
        }

    }
}

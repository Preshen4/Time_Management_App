using System.Windows;

namespace Time_Management_App.Classes
{
    public class LoginUser
    {
        public void LogedIn()
        {
            // Code Attribution 
            // Link: https://stackoverflow.com/questions/47133506/how-to-hide-show-buttons-in-wpf-pages
            // Author: Mustaga Demir

            // Start
            MainWindow wnd = (MainWindow)Application.Current.MainWindow;
            wnd.btnCapture.Visibility = Visibility.Visible;
            wnd.btnDashboard.Visibility = Visibility.Visible;
            wnd.btnStudy.Visibility = Visibility.Visible;
            wnd.btnSignUp.Visibility = Visibility.Collapsed;
            wnd.Shell.Content = new Dashboard();
            // End
        }
    }
}

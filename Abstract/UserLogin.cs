using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using TimeManagementLib.Models;

namespace Time_Management_App.Abstract
{
    public abstract class UserLogin
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

        // Hashes the password
        public string HashPassword(string password)
        {
            // Code Attribution 
            // Link: https://www.c-sharpcorner.com/article/hashing-passwords-in-net-core-with-tips/
            // Author : Afzaal Ahmad Zeeshan

            // Start
            try
            {
                using (var sha256 = SHA256.Create())
                {
                    // Send a sample text to hash.  
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    // Get the hashed string.
                    return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
            // End
        }

        // Checks if the student exists in the database
        public bool StudentExists(string studentID)
        {
            try
            {
                TimeManagementAppContext context = new TimeManagementAppContext();
                if (context.Students.Find(studentID) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}

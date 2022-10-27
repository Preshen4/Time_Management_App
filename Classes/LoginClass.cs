using System;
using System.Configuration;
using System.Windows;
using Time_Management_App.Abstract;
using TimeManagementLib.Models;

namespace Time_Management_App.Classes
{
    public class LoginClass : UserLogin
    {
        // Check if the password is correct
        public bool PasswordMatches(string studentID, string password)
        {
            try
            {
                TimeManagementAppContext context = new TimeManagementAppContext();

                if (context.Students.Find(studentID)?.Password == HashPassword(password))
                {
                    ConfigurationManager.AppSettings["StudentName"] = studentID;
                    ConfigurationManager.AppSettings["NumOfWeeks"] = context.Students.Find(studentID)?.NumberOfWeeks.ToString();
                    LogedIn();
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

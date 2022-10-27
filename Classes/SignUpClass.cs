using System;
using System.Windows;
using Time_Management_App.Abstract;
using TimeManagementLib.Models;

namespace Time_Management_App.Classes
{
    public class SignUpClass : UserLogin
    {
        public bool PasswordsMatch(string password1, string password2)
        {
            if (password1.Equals(password2))
            {
                return true;
            }
            return false;
        }

        public void AddUser(Student student)
        {
            try
            {
                TimeManagementAppContext context = new TimeManagementAppContext();
                student.Password = HashPassword(student.Password!);
                // Add the student to the database
                context.Students.Add(student);
                context.SaveChanges();
                MessageBox.Show("Account created successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

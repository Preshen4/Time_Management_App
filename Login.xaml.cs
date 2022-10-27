using FluentValidation.Results;
using System.Windows;
using System.Windows.Controls;
using Time_Management_App.Classes;
using Time_Management_App.Interfaces;
using Time_Management_App.Validators;
using TimeManagementLib.Models;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page, IErrorDisaplaying
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ClearErrors();

            // Set the values for the student details
            Student studentLogin = new Student
            {
                StudentId = txtUsername.Text,
                Password = txtPassword.Password.ToString()
            };

            // Validate the student details
            LoginValidator validation = new LoginValidator();
            var validationResult = validation.Validate(studentLogin);

            // If the details are valid
            if (validationResult.IsValid)
            {
                LoginClass loginClass = new LoginClass();
                TimeManagementAppContext context = new TimeManagementAppContext();
                // Check if the student exists
                if (loginClass.StudentExists(studentLogin.StudentId) && loginClass.PasswordMatches(studentLogin.StudentId, studentLogin.Password))
                {
                    loginClass.LogedIn();
                }
                else
                {
                    // Display an error message
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // If the details are not valid
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    DisplayErrors(failure.PropertyName, failure.ErrorMessage);
                }
            }
        }

        // Displays the errors
        public void DisplayErrors(string name, string error)
        {
            switch (name)
            {
                case "StudentID":
                    txtUsername.Background = System.Windows.Media.Brushes.Red;
                    txtUsername.ToolTip = error;
                    break;
                case "Password":
                    txtPassword.Background = System.Windows.Media.Brushes.Red;
                    txtPassword.ToolTip = error;
                    break;
                default:
                    break;
            }
        }

        // Clears the errors and set the tooltips
        public void ClearErrors()
        {
            txtUsername.Background = System.Windows.Media.Brushes.White;
            txtUsername.ToolTip = "Enter your Student Number";

            txtPassword.Background = System.Windows.Media.Brushes.White;
            txtPassword.ToolTip = "Enter your Password";
        }
    }
}

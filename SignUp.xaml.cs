using FluentValidation.Results;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Time_Management_App.Classes;
using Time_Management_App.Interfaces;
using Time_Management_App.Validators;
using TimeManagementLib.Models;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page, IErrorDisaplaying
    {
        public SignUp()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            ClearErrors();

            // Checks if the txtCredits and txtHours are empty
            if (txtNumOfWeeks.Text == "")
            {
                DisplayErrors("NumberOfWeeks", "Please enter a value for number of weeks");
                return;
            }
            else if (dateStart.Text == "")
            {
                DisplayErrors("StartDate", "Please enter a value for start date");
                return;
            }

            Student studentSignUp = new Student
            {
                StudentId = txtStudentNumber.Text,
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Password = txtPassword.Password.ToString(),
                NumberOfWeeks = Convert.ToInt32(txtNumOfWeeks.Text),
                StartDate = Convert.ToDateTime(dateStart.Text)
            };

            SignUpClass signUpClass = new SignUpClass();

            if (!signUpClass.PasswordsMatch(studentSignUp.Password, txtConfirmPassword.Password.ToString()))
            {
                DisplayErrors("ConfirmPassword", "Passwords don't match");
                return;
            }

            SignUpValidator validation = new SignUpValidator();
            var validationResult = validation.Validate(studentSignUp);

            // If the details are valid
            if (validationResult.IsValid)
            {
                // If the student is not created
                if (!signUpClass.StudentExists(studentSignUp.StudentId))
                {
                    new Thread(() => signUpClass.AddUser(studentSignUp)).Start();

                    // Navigate to the main page
                    signUpClass.LogedIn();
                    return;
                }

                MessageBox.Show("Account is already created. Please login", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                Clears();

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

        // Only allows the user to enter numbers
        private void NumOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Only allows the user to enter numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // Clears the text boxes and date picker
        private void Clears()
        {
            txtStudentNumber.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtSurname.Clear();
            txtName.Clear();
            txtNumOfWeeks.Clear();
            dateStart.SelectedDate = null;
        }

        // Displays the relative error
        public void DisplayErrors(string name, string error)
        {
            switch (name)
            {
                case "StudentId":
                    txtStudentNumber.Background = System.Windows.Media.Brushes.Red;
                    txtStudentNumber.ToolTip = error;
                    break;
                case "Password":
                    txtPassword.Background = System.Windows.Media.Brushes.Red;
                    txtPassword.ToolTip = error;
                    break;
                case "ConfirmPassword":
                    txtConfirmPassword.Background = System.Windows.Media.Brushes.Red;
                    txtConfirmPassword.ToolTip = error;
                    break;
                case "Name":
                    txtName.Background = System.Windows.Media.Brushes.Red;
                    txtName.ToolTip = error;
                    break;
                case "Surname":
                    txtSurname.Background = System.Windows.Media.Brushes.Red;
                    txtSurname.ToolTip = error;
                    break;
                case "NumberOfWeeks":
                    txtNumOfWeeks.Background = System.Windows.Media.Brushes.Red;
                    txtNumOfWeeks.ToolTip = error;
                    break;
                case "StartDate":
                    dateStart.Background = System.Windows.Media.Brushes.Red;
                    dateStart.ToolTip = error;
                    break;
                default:
                    break;
            }
        }

        // Clears the errors and sets the new tool tips 
        public void ClearErrors()
        {

            txtStudentNumber.Background = System.Windows.Media.Brushes.White;
            txtStudentNumber.ToolTip = "Enter your Student Number";

            txtPassword.Background = System.Windows.Media.Brushes.White;
            txtPassword.ToolTip = "Enter your Password";

            txtNumOfWeeks.Background = System.Windows.Media.Brushes.White;
            txtNumOfWeeks.ToolTip = "Enter your Number of Weeks";

            txtName.Background = System.Windows.Media.Brushes.White;
            txtName.ToolTip = "Enter your First Name";

            txtName.Background = System.Windows.Media.Brushes.White;
            txtName.ToolTip = "Enter your Surname";

            txtConfirmPassword.Background = System.Windows.Media.Brushes.White;
            txtConfirmPassword.ToolTip = "Confirm your Password";

            dateStart.Background = System.Windows.Media.Brushes.White;
            dateStart.ToolTip = "Enter your Start Date";
        }
    }
}

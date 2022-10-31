using FluentValidation.Results;
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
    /// Interaction logic for Capture.xaml
    /// </summary>

    public partial class Capture : Page, IErrorDisaplaying
    {
        public Capture()
        {
            InitializeComponent();
        }

        [System.Obsolete]
        private void btnCapture_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ClearErrors();

            // Checks if the txtCredits and txtHours are empty
            if (txtCredits.Text == "")
            {
                DisplayErrors("Credits", "Please enter a value for credits");
                return;
            }
            else if (txtHours.Text == "")
            {
                DisplayErrors("Hours", "Please enter a value for hours");
                return;
            }

            // Creates the module object
            Module module = new Module
            {
                Code = txtCode.Text,
                Name = txtName.Text,
                Credits = int.Parse(txtCredits.Text),
                HoursPerWeek = int.Parse(txtHours.Text)
            };

            // Checks if the user input is valid
            StudentModuleValidator validation = new StudentModuleValidator();
            var validationResult = validation.Validate(module);

            // If the input is valid
            if (validationResult.IsValid)
            {
                CaptureClass captureClass = new CaptureClass();

                // Checks if the module already exists
                if (captureClass.CheckIfCodeExists(module.Code))
                {
                    new Thread(() => captureClass.AddOldModule(module)).Start();
                    Clears();
                    ClearErrors();
                    return;
                }
                // Checks if the module is linked to the student
                else if (captureClass.CheckIfStudentHasCode(module.Code))
                {
                    MessageBox.Show("You already captured this module", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                Clears();
                ClearErrors();
                // Adds the new module to the user
                new Thread(() => captureClass.AddNewModule(module)).Start();
            }
            else
            {
                // Displays the errors of the user inputs
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    DisplayErrors(failure.PropertyName, failure.ErrorMessage);
                }
            }

        }
        private void NumOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Only allows the user to enter numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // Clears the textboxes so that new modules can be added
        private void Clears()
        {
            txtCode.Clear();
            txtName.Clear();
            txtHours.Clear();
            txtCredits.Clear();
        }

        // Clears any previous errors from the form
        public void ClearErrors()
        {
            txtCode.Background = System.Windows.Media.Brushes.White;
            txtCode.ToolTip = "Enter your Module Code";

            txtName.Background = System.Windows.Media.Brushes.White;
            txtName.ToolTip = "Enter your Module Name";

            txtCredits.Background = System.Windows.Media.Brushes.White;
            txtCredits.ToolTip = "Enter your Module Credit Score";

            txtHours.Background = System.Windows.Media.Brushes.White;
            txtHours.ToolTip = "Enter your Module Hours Per Week";
        }

        // Displays the errors
        // Github copilot supplied the code :  System.Windows.Media.Brushes.Red
        public void DisplayErrors(string propertyName, string errorMessage)
        {

            switch (propertyName)
            {
                case "Code":
                    txtCode.Background = System.Windows.Media.Brushes.Red;
                    txtCode.ToolTip = errorMessage;
                    break;
                case "Name":
                    txtName.Background = System.Windows.Media.Brushes.Red;
                    txtName.ToolTip = errorMessage;
                    break;
                case "Credits":
                    txtCredits.Background = System.Windows.Media.Brushes.Red;
                    txtCredits.ToolTip = errorMessage;
                    break;
                case "Hours":
                    txtHours.Background = System.Windows.Media.Brushes.Red;
                    txtHours.ToolTip = errorMessage;
                    break;
            }
        }
    }
}

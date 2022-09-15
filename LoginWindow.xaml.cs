using System;
using System.Text.RegularExpressions;
using System.Windows;
using Time_Management_App.Classes;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            try
            {
                // Gets the users data
                student.NumOfWeeks = int.Parse(txtNumOfWeeks.Text);
                student.StartDate = DateTime.Parse(dateStart.Text);
                // Closes this form and shows the Main form of the application
                this.Hide();
                MainWindow main = new MainWindow(student);
                main.ShowDialog();
                this.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Please enter your details!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void NumOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Only allows the user to enter numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}

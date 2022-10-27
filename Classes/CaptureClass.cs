using System;
using System.Configuration;
using System.Linq;
using System.Windows;
using TimeManagementLib.Models;

namespace Time_Management_App.Classes
{
    public class CaptureClass
    {
        // Method to add a module to the Modules and StudentModules tables in the database
        public void AddNewModule(Module module)
        {
            try
            {
                StudentModule studentModule = CreateStudentModule(module);
                TimeManagementAppContext context = new TimeManagementAppContext();

                context.Modules.Add(module);
                context.SaveChanges();

                context.StudentModules.Add(studentModule);
                context.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        // Method to create a StudentModule object
        private StudentModule CreateStudentModule(Module module)
        {
            StudentModule studentModule = new StudentModule();
            studentModule.StudentId = ConfigurationManager.AppSettings["StudentName"]!;
            studentModule.Code = module.Code;
            studentModule.SelfStudyHours = studentModule.CalSelfStudyHours(int.Parse(ConfigurationManager.AppSettings["NumOfWeeks"]!), module.Credits, module.HoursPerWeek);
            studentModule.RemainingHours = studentModule.SelfStudyHours;
            studentModule.Week = 1;

            return studentModule;
        }

        // Method to add a module to the Modules table in the database
        public void AddOldModule(Module module)
        {
            try
            {
                StudentModule studentModule = CreateStudentModule(module);
                TimeManagementAppContext context = new TimeManagementAppContext();
                context.StudentModules.Add(studentModule);
                context.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to check if the module code already exists in the database
        public bool CheckIfCodeExists(string code)
        {
            TimeManagementAppContext context = new TimeManagementAppContext();

            if (context.Modules.Find(code) != null)
            {
                return true;
            }

            return false;
        }

        // Method to check if the module code already exists for the student in the database
        public bool CheckIfStudentHasCode(string code)
        {
            try
            {
                TimeManagementAppContext context = new TimeManagementAppContext();

                if (context.StudentModules.
                    Where(x => x.StudentId == ConfigurationManager.AppSettings["StudentName"]
                    && x.Code == code).FirstOrDefault() != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}

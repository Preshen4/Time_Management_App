using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;
using TimeManagementLib.Models;

namespace Time_Management_App.Classes
{
    public class StudiedClass
    {
        public IList<StudentModule>? GetModuleCodes()
        {
            try
            {
                TimeManagementAppContext context = new TimeManagementAppContext();
                return context.StudentModules.Where(x => x.StudentId == ConfigurationManager.AppSettings["StudentName"]).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void Study(string code, int hours)
        {
            try
            {
                // Updates the remaining hours in the database
                TimeManagementAppContext context = new TimeManagementAppContext();
                var module = context.StudentModules.Where(x => x.StudentId == ConfigurationManager.AppSettings["StudentName"] && x.Code == code).FirstOrDefault()!;
                // Checks if the week is equal to the number of weeks of the student table
                if (module.Week == int.Parse(ConfigurationManager.AppSettings["NumOfWeeks"]!))
                {
                    MessageBox.Show("You have completed all the weeks for this module!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                module.RemainingHours -= hours;
                context.SaveChanges();

                // Updates the remaining weeks in the database if the remaining hours is 0
                if (module.RemainingHours <= 0)
                {
                    module.Week += 1;
                    module.RemainingHours = module.SelfStudyHours;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

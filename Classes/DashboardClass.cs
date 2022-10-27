using System;
using System.Configuration;
using System.Linq;
using System.Windows;
using TimeManagementLib.Models;

namespace Time_Management_App.Classes
{
    public class DashboardClass
    {
        //Method to get the most self study hours for a module
        public string MostHours()
        {
            try
            {
                TimeManagementAppContext context = new TimeManagementAppContext();
                // Gets the module name and Remaining hours of the module with the most remaining time left
                var mostHours = context.StudentModules.
                    Where(x => x.StudentId == ConfigurationManager.AppSettings["StudentName"]).
                    OrderByDescending(x => x.RemainingHours).
                    Select(x => new { x.Code, x.RemainingHours }).
                    FirstOrDefault();
                return $"The module with the most hours of self studying remaining is : {mostHours?.Code} with {mostHours?.RemainingHours} hours left";
            }
            catch (Exception)
            {
                return "An error occurred";
            }
        }

        //Method to get the most credits for a module
        public string MostCredits()
        {
            try
            {
                TimeManagementAppContext context = new TimeManagementAppContext();
                // Gets the module name and credits of the module with the most credits
                var mostCredits = context.StudentModules.
                    Where(x => x.StudentId == ConfigurationManager.AppSettings["StudentName"]).
                    OrderByDescending(x => x.CodeNavigation.Credits).
                    Select(x => new { x.Code, x.CodeNavigation.Credits }).
                    FirstOrDefault();
                return $"The module with the most credits remaining is : {mostCredits?.Code} with {mostCredits?.Credits} credits left";
            }
            catch (Exception)
            {
                return "An error occurred";
            }
        }

        // Method to delete a module from the database
        public bool DeleteModule(string module)
        {
            TimeManagementAppContext context = new TimeManagementAppContext();
            // Deletes the module from the database         
            try
            {
                context.StudentModules.Remove(context.StudentModules.Where(x => x.StudentId == ConfigurationManager.AppSettings["StudentName"]! && x.Code == module).FirstOrDefault()!);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        // Code Attribution 
        // Link: https://www.geeksforgeeks.org/c-sharp-anonymous-types/ 
        // Author : Ankita_Saini 
        // Code : dynamic          
        // Code Attribution 

        // Method to return the modules of the user
        public dynamic? GetModules()
        {
            try
            {
                TimeManagementAppContext context = new TimeManagementAppContext();
                // Gets the modules for the current student
                var modules = context.StudentModules.
                    Where(x => x.StudentId == ConfigurationManager.AppSettings["StudentName"]).
                    Select(x => new { x.Code, x.CodeNavigation.Name, x.CodeNavigation.Credits, x.SelfStudyHours, x.RemainingHours, x.Week }).
                    ToList();

                return modules;
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}

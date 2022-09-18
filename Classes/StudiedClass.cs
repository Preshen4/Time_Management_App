using System.Linq;
using System.Windows;

namespace Time_Management_App.Classes
{
    public class StudiedClass
    {
        public string ModuleCode { get; set; }
        public int Hours { get; set; }
        public StudiedClass()
        {

        }

        public StudiedClass(string moduleCode, int hours)
        {
            ModuleCode = moduleCode;
            Hours = hours;
        }

        ~StudiedClass()
        {

        }

        public void UpdateRemainingHours(DashboardClass dashboardClass, Student student)
        {

            // LINQ used to update the remaining hours in the list
            foreach (var item in dashboardClass.getModules().Where(x => x.Code == ModuleCode))
            {
                item.RemainingHours -= Hours;

                // Checks if the remaining hours is less than 0
                if (item.RemainingHours <= 0)
                {
                    // resets the remaining hours and adds a week to the module
                    item.RemainingHours = item.SelfStudyHours;
                    item.Week++;
                    MessageBox.Show($"Your remaining hours for {ModuleCode} is now updated! You can view it on your Dashboard",
                        "Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                // Checks if the number of weeks studied is equal to the number of weeks in the semester
                if (item.Week == student.NumOfWeeks)
                {
                    item.RemainingHours = 0;
                    MessageBox.Show("You have completed all the weeks for this module!", "Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }



        }

    }

}

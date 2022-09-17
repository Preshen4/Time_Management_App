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

        public void UpdateRemainingHours(DashboardClass dashboardClass)
        {
            // LINQ used to update the remaining hours in the list
            foreach (var item in dashboardClass.getModules().Where(x => x.Code == ModuleCode))
            {
                item.RemainingHours = item.SelfStudyHours - Hours;
            }

            MessageBox.Show($"Your remaining hours for {ModuleCode} is now updated! You can view it on your Dashboard",
                "Completed", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }

}

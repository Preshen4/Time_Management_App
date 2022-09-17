using ModulesCal;
using System.Linq;
using System.Windows;

namespace Time_Management_App.Classes
{
    public class CaptureClass
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int HoursPerWeek { get; set; }
        public int Credits { get; set; }


        public CaptureClass()
        {

        }

        public CaptureClass(string code, string name, int hoursPerWeek, int credits)
        {
            Code = code;
            Name = name;
            HoursPerWeek = hoursPerWeek;
            Credits = credits;
        }

        ~CaptureClass()
        {

        }

        public void CaptureData(int NumOfWeeks, DashboardClass dashboardClass)
        {
            // Constructors
            SelfStudy selfStudy = new SelfStudy();
            Modules modules = new Modules();

            if (!CheckIfCodeExsits(Code, dashboardClass))
            {
                modules.Code = Code;
                modules.Name = Name;
                modules.HoursPerWeek = HoursPerWeek;
                modules.Credits = Credits;
                modules.SelfStudyHours = selfStudy.CalSelfStudyHours(Credits, HoursPerWeek, NumOfWeeks);
                modules.RemainingHours = modules.SelfStudyHours;
                // Adds the capture class to the modules list
                dashboardClass.setModules(modules);
            }
        }

        private bool CheckIfCodeExsits(string code, DashboardClass dashboardClass)
        {
            foreach (var item in dashboardClass.getModules().Where(x => x.Code == code))
            {
                MessageBox.Show("You already entered the details for this module!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            return false;
        }

    }
}

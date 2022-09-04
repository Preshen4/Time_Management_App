using System.Collections.Generic;

namespace Time_Management_App.Classes
{
    public class DashboardClass
    {
        public static DashboardClass Instant { get; } = new DashboardClass(); // Instant of the Dashboard class so that the objects stored in the List are saved and can be used in different classes
        public List<ModulesCal.Modules> Modules { get; set; } = new List<ModulesCal.Modules>();
        public List<ModulesCal.Modules> getModules()
        {
            return Modules;
        }
        public void setModules(ModulesCal.Modules obj)
        {
            Modules.Add(obj);
        }
    }
}

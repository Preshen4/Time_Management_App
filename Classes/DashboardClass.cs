using System.Collections.Generic;

namespace Time_Management_App.Classes
{
    public class DashboardClass
    {
        // Instant of the Dashboard class used so the List can be accessed in any class without lossing its values
        public static DashboardClass Instant { get; } = new DashboardClass();
        // List of the object Modules 
        private List<ModulesCal.Modules> Modules = new List<ModulesCal.Modules>();
        // Returns all of the modules as a List
        public List<ModulesCal.Modules> getModules()
        {
            return Modules;
        }
        // Adds another module into the list
        public void setModules(ModulesCal.Modules obj)
        {
            Modules.Add(obj);
        }
    }
}

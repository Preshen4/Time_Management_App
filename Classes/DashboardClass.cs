using System.Collections.Generic;

namespace Time_Management_App.Classes
{
    public class DashboardClass
    {
        public DashboardClass()
        {

        }

        ~DashboardClass()
        {

        }

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

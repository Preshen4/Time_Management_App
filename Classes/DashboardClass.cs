using ModulesCal;
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
        private List<Modules> Modules = new List<Modules>();

        // Returns all of the modules as a List
        public List<Modules> getModules()
        {
            return Modules;
        }

        // Adds another module into the list
        public void setModules(Modules obj)
        {
            Modules.Add(obj);
        }

    }
}

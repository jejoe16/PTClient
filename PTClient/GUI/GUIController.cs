using PTClient.GUI.Map;
using PTClient.Logic.LogicController;
using PTClient.SimPositionProgram.BoatGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PTClient.GUI
{
    class GUIController
    {
        private static GUIController GUIcontroller = null;
        private IMap map = new MapControl();
        private IController controller = Controller.GetController();
        public GUIController()
        {

        }

        public static object Executors { get; private set; }

        public static GUIController GetController()
        {
            if(GUIcontroller == null)
            {
                GUIcontroller = new GUIController();
            }

            return GUIcontroller;
        }

        public void generateMap() 
        {
            List<String> TurbineNames = controller.GetTurbineNames();
            foreach(String Name in TurbineNames)
            {
                map.AddTurbineMarker(Name, controller.GetTurbineLatitude(Name), controller.GetTurbineLongitude(Name));
            }
        }

        
        

    }
}

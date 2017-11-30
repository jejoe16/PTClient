using PTClient.GUI.Map;
using PTClient.Logic.LogicController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.GUI
{
    class GUIController
    {
        private static GUIController GUIcontroller = null;
        private IController controller = Controller.GetController();
        public GUIController()
        {

        }

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
            IMap map = new MapControl();
            foreach(String Name in TurbineNames)
            {
                map.AddTurbineMarker(Name, controller.GetTurbineLatitude(Name), controller.GetTurbineLongitude(Name));
            }
        }

        

    }
}

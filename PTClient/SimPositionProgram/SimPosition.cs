using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleTrackingC.SimPosition
{
    class SimPosition : ISimPosition
    {
        private GuiSimPos gui = new GuiSimPos();

        public void OpenSimPositionGUI()
        {
            gui.Show();
        }

        public double GetLat()
        {
            return gui.Lat;
        }

        public double GetLon()
        {
            return gui.Lon;
        }


    }
}

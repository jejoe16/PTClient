using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.SimPosition
{
    interface ISimPosition
    {
        double GetLat();

        double GetLon();

        void OpenSimPositionGUI();
    }
}

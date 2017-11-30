using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.GUI.Map
{
    interface IMap
    {
        void AddTurbineMarker(String Name, double Latitude, double Longitude);

    }
}

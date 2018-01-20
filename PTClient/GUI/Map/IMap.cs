using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.GUI.Map
{
    interface IMap
    {
        /// <summary>
        /// Adds a turbine to the list of turbine markesrs
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Latitude"></param>
        /// <param name="Longitude"></param>
        void AddTurbineMarker(String Name, double Latitude, double Longitude);
        /// <summary>
        /// For generating the list with GMapMarkers.
        /// </summary>
        /// <returns> returns a list with all added turbine markers</returns>
        List<GMap.NET.WindowsForms.GMapMarker> DrawMarkers();

    }
}

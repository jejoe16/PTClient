using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.SimPosition
{
    interface ISimPosition
    {
        /// <summary>
        /// Gets the latitude
        /// </summary>
        /// <returns></returns>
        double GetLat();

        /// <summary>
        /// Gets the Longitude
        /// </summary>
        /// <returns></returns>
        double GetLon();

        /// <summary>
        /// Opens a windows with the position simulator
        /// </summary>
        void OpenSimPositionGUI();
    }
}

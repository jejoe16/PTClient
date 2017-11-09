using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleTrackingC.Position
{
    interface ITurbinePosition
    {
      

        /// <summary>
        /// This method adds a turbine to the wind turbine park
        /// </summary>
        /// <param name="name">name of the wind turbine ex. A1</param>
        /// <param name="latitude">latitude position</param>
        /// <param name="longitude">longitude position</param>
        void AddTurbine(string name, long latitude, long longitude);

        /// <summary>
        /// This method returns the nearst turbine to the vessel ex A1 if that is within a radius 200m of the vessel
        /// </summary>
        /// <returns>return the turbine name ex. A1, if no turbine is within radius, a null is returned</returns>
        string GetNearWindTurbine();

        /// <summary>
        /// returns a list of all turbines from the server
        /// </summary>
        /// <returns>ArrayList with instance of turbines</returns>
        List<WindTurbine> GetTurbineList();

        /// <summary>
        /// Method to show the location debugger
        /// </summary>
        void ShowPosDebugger();
    }
}

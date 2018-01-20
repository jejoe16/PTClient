using System;
using System.Collections.Generic;
using PTClient.SharedResources;

namespace PTClient.Logic.Position
{
    interface ITurbinePosition
    {
      

        /// <summary>
        /// This method adds a turbine to the wind turbine park
        /// </summary>
        /// <param name="name">name of the wind turbine ex. A1</param>
        /// <param name="latitude">latitude position</param>
        /// <param name="longitude">longitude position</param>
        void AddTurbines(List<TurbineItem> turbines);

        /// <summary>
        /// This method returns the nearst turbine to the vessel ex A1 if that is within a radius 200m of the vessel
        /// </summary>
        /// <returns>return the turbine name ex. A1, if no turbine is within radius, a null is returned</returns>
        string GetNearWindTurbine(Double latitude, Double longitude);

        /// <summary>
        /// returns a list of all turbines from the server
        /// </summary>
        /// <returns>ArrayList with instance of turbines</returns>
        List<TurbineItem> GetTurbineList();
        /// <summary>
        /// returns all turbine names in a list
        /// </summary>
        /// <returns></returns>
        List<String> GetTurbineNames();
        /// <summary>
        /// gets a single turbine longitude
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        double GetTurbineLongitude(String Name);
        /// <summary>
        /// get a single turbine latitude
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        double GetTurbineLatitude(String Name);
    }
}

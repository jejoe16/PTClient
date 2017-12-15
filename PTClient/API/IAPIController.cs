using System;
using System.Collections.Generic;
using PTClient.SharedResources;

namespace PTClient.API
{
    interface IAPIController
    {
        /// <summary>
        /// Returns a list of all the turbines in the wind farm defined in the database.
        /// </summary>
        /// <returns></returns>
        List<TurbineItem> getTurbines();
        /// <summary>
        /// Returns a list of all workers in the wind farm park with the current position 
        /// </summary>
        /// <returns></returns>
        List<WorkerItem> getWorkerListItem();
        /// <summary>
        /// Check if the 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        Boolean Login(String UserName, String PassWord);
        String GetUserPosition();
        Boolean CaptainCheck();
        Boolean UpdateUserPosition(String Username, String Password, String Position);
        void StateEmergency(string Username, string Password);
        List<TurbineItem> checkRoute(string username, string password, double boatlong, double boatlat);
    }
}

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
        /// Check if the username and password matches any entry on ther server
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns>returns true is it's a match, flase if not</returns>
        Boolean Login(String UserName, String PassWord);
        /// <summary>
        /// Ask for the current users position.
        /// </summary>
        /// <returns>return a string  of the position name</returns>
        String GetUserPosition();
        /// <summary>
        /// checks if the logged in user is a captain. boolean is returned depending on true or not
        /// </summary>
        /// <returns></returns>
        Boolean CaptainCheck();
        /// <summary>
        /// Updates the current users position on the server. used for check in and check out.
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Position"></param>
        /// <returns></returns>
        Boolean UpdateUserPosition(String Username, String Password, String Position);
        /// <summary>
        /// Set the server in an emergency state, allowing the genration of emergency routes.
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        void StateEmergency(string Username, string Password);
        /// <summary>
        /// returns a list with all the turbines in which there are technicians on. if the server is not in emergency state, the list returned will be empty. 
        /// the username and password is to verify it's a captain that is checking, and the boat position is to generate a starting point.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="boatlong"></param>
        /// <param name="boatlat"></param>
        /// <returns></returns>
        List<TurbineItem> checkRoute(string username, string password, double boatlong, double boatlat);
    }
}

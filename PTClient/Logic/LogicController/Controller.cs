using PTClient.API;
using PTClient.Logic.Login;
using PTClient.Logic.Position;
using System;
using System.Collections.Generic;
using PTClient.SharedResources;
using System.Net;
using PTClient.Logic.Emergency;

namespace PTClient.Logic.LogicController
{
    class Controller : IController
    {
        private ITurbinePosition turbines = null;
        private IAPIController api = null;
        private ISession session = null;
        
        private State state = new State();
        private EmergencyRoute emergencyRoute = new EmergencyRoute();

        public Controller()
        {
            turbines = new TurbinePosition();
        }


        /// <summary>
        /// downloads the list of turbines from the server and adds them to the client 
        /// </summary>
        private void DownloadTurbines()
        {
            turbines.AddTurbines(api.getTurbines());
        }

        /// <summary>
        /// returns the list with all the turbines
        /// </summary>
        /// <returns></returns>
        public List<TurbineItem> GetTurbines()
        {
            DownloadTurbines();
            return turbines.GetTurbineList();
        }

        /// <summary>
        /// returns the list of all technicians in the database
        /// </summary>
        /// <returns></returns>
        public List<WorkerItem> GetWorkerListItems()
        {
            api = APIController.GetAPIController();
            return api.getWorkerListItem();
        }

        /// <summary>
        /// returns the names of all the turbines in a list
        /// </summary>
        /// <returns></returns>
        public List<String> GetTurbineNames()
        {
            DownloadTurbines();
            return turbines.GetTurbineNames();
        }

        /// <summary>
        /// returns the longitude of a single turbine depending on the name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public double GetTurbineLongitude(String Name)
        {
            return turbines.GetTurbineLongitude(Name);
        }
         
        /// <summary>
        /// returns the latitude of a single turbine depending on the name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public double GetTurbineLatitude(String Name)
        {
            return turbines.GetTurbineLatitude(Name);
        }

        /// <summary>
        /// creates a new login session with the username, password, and other relevant information about the user
        /// captain, position.
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        public void NewSession(String Username, String Password)
        {
            api = APIController.GetAPIController();
            Boolean logincheck = api.Login(Username, Password);
            Boolean Captain = api.CaptainCheck();
            session = new Session();
            session.createUser(Username, Password, Captain);
        }

        /// <summary>
        /// checks if the user exists on the server through the API, returns true if they exist.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Boolean Login(String username, String password)
        {
            api = APIController.GetAPIController();
            Boolean logincheck = api.Login(username, password);
            Boolean Captain = api.CaptainCheck();
            session = new Session();
            session.createUser(username, password, Captain);
            return logincheck;
        }

        /// <summary>
        /// cllears the session
        /// </summary>
        public void Logout()
        {
            session = null;
        }

        /// <summary>
        /// sets the users position in the database depending on the proximity to the nearest turbine.
        /// if no turine is within valid boarding range, returns false.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public Boolean CheckIn(Double latitude, Double longitude)
        {
            if (session.LoggedIn().Equals(false) || session == null)
            {
                return false;
            }
            else
            {
                String wt = turbines.GetNearWindTurbine(latitude, longitude);
                if (wt != null)
                {
                    api.UpdateUserPosition(session.GetUserName(), session.GetPassword(), wt);
                    session.SetUserPosition(wt);
                } else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// sets the users position to Harbor/Vessel, checkin them out of the turbine they are working on
        /// </summary>
        /// <returns></returns>
        public Boolean CheckOut()
        {
            if (session.LoggedIn().Equals(false) || session == null)
            {
                return false;
            }
            else
            {
                api.UpdateUserPosition(session.GetUserName(), session.GetPassword(), "Harbor/Vessel");
                session.SetUserPosition("null");
            }
            return true;
        }

        /// <summary>
        /// checks if the current person who are logged in is a captain
        /// </summary>
        /// <returns></returns>
        public bool CaptainCheck()
        {
            return session.GetCaptain();
        }

        /// <summary>
        /// checks if there are conenction to the api on the server
        /// </summary>
        /// <returns></returns>
        public bool CheckConnection()
        {
            try
            {
                WebClient client = new WebClient();
                client.DownloadData("http://192.168.43.251:12230");
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// sets the servers state to emergency,  routes can be generated
        /// </summary>
        /// <returns></returns>
        public bool CallEmergency()
        {
            state.Emergency = true;
            api.StateEmergency(session.GetUserName(), session.GetPassword());

            return state.Emergency;
        }

        /// <summary>
        /// returns a list with positions of critical turbines with workers on it, if the server is in emergency state
        /// </summary>
        /// <returns></returns>
        public List<Point> GetRoute()
        {
            return emergencyRoute.GetPickUpPoints();
        }

   

        public Boolean CheckState()
        {
            return state.Emergency;
        }

        public Boolean ExistRouteapi(double latitude, double longitude)
        {
            //checker om der fra apiet har en route, og hvis der bliver returneret en liste med en længde går videre.

            List<TurbineItem> turbineList = api.checkRoute(session.GetUserName(), session.GetPassword(), longitude, latitude);
                if (turbineList.ToArray().Length > 0)
                {
                    emergencyRoute.SetRoute(turbineList);
                    return true;
                }
                else
                {
                    return false;
                }
            
        }
    }
}
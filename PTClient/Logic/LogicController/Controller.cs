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

        public List<TurbineItem> GetTurbines()
        {
            DownloadTurbines();
            return turbines.GetTurbineList();
        }

        public List<WorkerItem> GetWorkerListItems()
        {
            api = APIController.GetAPIController();
            return api.getWorkerListItem();
        }

        public List<String> GetTurbineNames()
        {
            DownloadTurbines();
            return turbines.GetTurbineNames();
        }

        public double GetTurbineLongitude(String Name)
        {
            return turbines.GetTurbineLongitude(Name);
        }

        public double GetTurbineLatitude(String Name)
        {
            return turbines.GetTurbineLatitude(Name);
        }

        public void NewSession(String Username, String Password)
        {
            api = APIController.GetAPIController();
            Boolean logincheck = api.Login(Username, Password);
            Boolean Captain = api.CaptainCheck();
            session = new Session();
            session.createUser(Username, Password, Captain);
        }

        public Boolean Login(String username, String password)
        {
            api = APIController.GetAPIController();
            Boolean logincheck = api.Login(username, password);
            Boolean Captain = api.CaptainCheck();
            session = new Session();
            session.createUser(username, password, Captain);
            return logincheck;
        }

        public void Logout()
        {
            session = null;
        }

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

        public bool CaptainCheck()
        {
            return session.GetCaptain();
        }

        public bool CheckConnection()
        {
            try
            {
                WebClient client = new WebClient();
                client.DownloadData("http://35.187.75.150:12230");
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool CallEmergency()
        {
            state.Emergency = true;
            api.StateEmergency(session.GetUserName(), session.GetPassword());

            return state.Emergency;
        }

        public List<Point> GetRoute()
        {
            return emergencyRoute.GetPickUpPoints();
        }

        public void SetEmergency()
        {
            state.Emergency = true;
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
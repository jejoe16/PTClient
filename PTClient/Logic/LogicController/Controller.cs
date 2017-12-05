using PTClient.API;
using PTClient.GUI;
using PTClient.GUI.Map;
using PTClient.Logic.Login;
using PTClient.Logic.Position;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTClient.SharedResources;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using PTClient.Logic.Emergency;

namespace PTClient.Logic.LogicController
{
    class Controller : IController
    {
        private ITurbinePosition turbines = null;
        private static Controller controller = null;
        private IAPIController api = null;
        private ISession session = null;
        private State state = new State();
        //private Boolean emerChecker = false;
        private EmergencyRoute emergencyRoute = new EmergencyRoute();

        public Controller()
        {
            turbines = new TurbinePosition();
        }

        public static Controller GetController()
        {
            if (controller == null)
            {
                controller = new Controller();
            }

            return controller;
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

        public Boolean Login(String username, String password)
        {
            api = APIController.GetAPIController();
            Boolean Check = api.Login(username, password);

            session = new Session();
            if (Check.Equals(true))
            {
                Boolean Captain = api.CaptainCheck();
                
                session.createUser(username, password, Captain);
                //String position = api.GetUserPosition();
                //session.SetUserPosition(position);
            }

            return session.LoggedIn();
        }

        public void Logout()
        {
            session = null;
        }
        public Boolean CheckIn(String currentPos)
        {
            if (session.LoggedIn().Equals(false) || session == null)
            {
                return false;
            }
            else
            {
                api.UpdateUserPosition(session.GetUserName(), session.GetPassword(), currentPos);
                session.SetUserPosition(currentPos);
            }
            return true;
        }
        public Boolean CheckOut(String currentPos)
        {
            if (session.LoggedIn().Equals(false) || session == null)
            {
                return false;
            }
            else
            {
                api.UpdateUserPosition(session.GetUserName(), session.GetPassword(), currentPos);
                session.SetUserPosition(currentPos);
            }
            return true;
        }


        public bool CaptainCheck()
        {
            return session.GetCaptain();
        }

        public bool CheckConnection()
        {
            Ping ping = new Ping();
            PingReply pingReply = ping.Send(new IPAddress(new byte[] { 35, 187, 75, 150 }), 1000);
            if (pingReply.Status == IPStatus.Success)
            {
                return true;
            }
            return false;
        }

        public bool CallEmergency()
        {
            state.Emergency = true;
            api.StateEmergency(session.GetUserName(), session.GetPassword());

            return state.Emergency;
        }
        public List<Emergency.Point> GetRoute()
        {
            return emergencyRoute.getPickUpPoints();
        }
        public void setEmergency()
        {
            state.Emergency = true;
        }

        //public void CheckEmergency()
        //{
        //    if (emerChecker == false)
        //    {
        //        new Thread(() =>
        //        {
        //            Thread.CurrentThread.IsBackground = true;
        //            while (true)
        //            {
        //                VesselPosition currentVesselPosition = new VesselPosition();
        //                if (api.checkRoute(Controller.GetController().session.GetUserName(), Controller.GetController().session.GetPassword(), currentVesselPosition.GetLatitude(), currentVesselPosition.GetLongitude()).Count > 1)
        //                {
        //                    emergencyRoute.setRoute(api.checkRoute(Controller.GetController().session.GetUserName(), Controller.GetController().session.GetPassword(), currentVesselPosition.GetLatitude(), currentVesselPosition.GetLongitude()));
        //                    Controller.GetController().setEmergency();
        //                    break;
        //                }
        //                else if (api.checkRoute(Controller.GetController().session.GetUserName(), Controller.GetController().session.GetPassword(), currentVesselPosition.GetLatitude(), currentVesselPosition.GetLongitude()).Count < 1)
        //                {
        //                    Thread.Sleep(1000);
        //                }
        //            }
        //        }).Start();
        //        emerChecker = true;
        //    }



        //}
        public Boolean CheckState()
        {
            return state.Emergency;
        }
        public Boolean ExistRouteapi(double lat, double longi)
        {
            //checker om der fra apiet har en route, og hvis der bliver returneret en liste med en længde går videre.

            List<TurbineItem> turbineList = api.checkRoute(session.GetUserName(), session.GetPassword(), longi, lat);
            if (turbineList.ToArray().Length == null) {
                if (turbineList.ToArray().Length > 0)
                {
                    emergencyRoute.setRoute(turbineList);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
            
        }
    }
}

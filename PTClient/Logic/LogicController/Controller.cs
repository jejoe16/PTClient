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

namespace PTClient.Logic.LogicController
{
    class Controller : IController
    {
        private ITurbinePosition turbines = null;
        private IAPIController api = null;
        private ISession session = null;

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
    }
}

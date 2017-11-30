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

namespace PTClient.Logic.LogicController
{
    class Controller : IController
    {
        private ITurbinePosition turbines = null;
        private static Controller controller = null;
        private IAPIController api = null;
        private ISession session = null;

        public Controller()
        {
            api = PTClient.API.APIController.GetAPIController();
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
            Boolean Check = api.Login(username, password);

            Session session = new Session();
            if (Check.Equals(true))
            {
                Boolean Captain = api.CaptainCheck();
                session.createUser(username, password, Captain);
                String position = api.GetUserPosition();
                session.SetUserPosition(position);
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
    }
}

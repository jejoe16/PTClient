﻿using PTClient.API;
using PTClient.Logic.Login;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Logic.LogicController
{
    class Controller : IController
    {
        private Position.ITurbinePosition turbines = new Position.TurbinePosition();
        private static Controller controller = null;
        private IAPIController api = null;
        private ISession session = null;
        public Controller()
        {
            api = PTClient.API.APIController.GetAPIController();
            DownloadTurbines();
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
        public void DownloadTurbines()
        {
            var latitude = api.GetTurbinesLatitude();
            var longitude = api.GetTurbinesLongitude();
            var name = api.GetTurbinesName();

            for (int i = 0; i < name.Count; i++)
            {
                turbines.AddTurbine(name[i], (long)latitude[i], (long)longitude[i]);
            }
        }

        public List<String> GetWindTurbineList()
        {
            var turbinelist = turbines.GetTurbineName();
            return turbinelist;
        }

        public long GetTurbineLongitude(String Name)
        {
            return turbines.GetTurbineLongitude(Name);
        }
         
        public long GetTurbineLatitude(String Name)
        {
            return turbines.GetTurbineLatitude(Name);
        }

        public Boolean Login(String username, String password)
        {
            Boolean Check = api.Login(username, password);
            if (Check.Equals(true))
            {
                Boolean Captain = api.CaptainCheck();
                session = new Session(username, password, Captain);
                String position = api.GetUserPosition();
                long UserLongitude = turbines.GetTurbineLongitude(position);
                long UserLatitude = turbines.GetTurbineLatitude(position);
                session.SetUserPosition(UserLatitude, UserLongitude);
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
            } else
            {
                api.UpdateUserPosition(session.GetUserName(), session.GetPassword(), currentPos);
                long UserLongitude = turbines.GetTurbineLongitude(currentPos);
                long UserLatitude = turbines.GetTurbineLatitude(currentPos);
                session.SetUserPosition(UserLatitude, UserLongitude);
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
                long UserLongitude = turbines.GetTurbineLongitude(currentPos);
                long UserLatitude = turbines.GetTurbineLatitude(currentPos);
                session.SetUserPosition(UserLatitude, UserLongitude);
            }
            return true;
        }

        public bool CaptainCheck()
        {
            return session.GetCaptain();
        }
    }
}

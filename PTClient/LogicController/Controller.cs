using PTClient.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.LogicController
{
    class Controller
    {
        private Position.ITurbinePosition turbines = new Position.TurbinePosition();
        private Map.IMap map = new Map.MapControl();
        private static Controller controller = null;
        private IAPIController api = null;
        private Workers.User currentUser;
        public Controller()
        {
            api = PTClient.API.APIController.GetAPIController();
            DownloadTurbines();
            SetWindTurbineMarkers();
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
            var latitude = api.GetTurbinesLatitude();
            var longitude = api.GetTurbinesLongitude();
            var name = api.GetTurbinesName();

            for (int i = 0; i < name.Count; i++)
            {
                turbines.AddTurbine(name[i], (long)latitude[i], (long)longitude[i]);
            }
        }

        private void SetWindTurbineMarkers()
        {
            var turbinelist = turbines.GetTurbineList();
            map.SetTurbineMarkers(turbinelist);
        }

        private Boolean  Login(String username, String password)
        {
            Boolean check = api.Login(username, password);
            if (check == true)
            {
                var Position = api.GetUserPosition();
                Boolean IsCaptain = (Boolean)api.CaptainCheck();
                currentUser = new Workers.User(IsCaptain, Position, username, password);
            }
            return check;
        }
    }
}

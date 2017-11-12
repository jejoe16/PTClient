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

        public Workers.User Login(String username, String password)
        {

            //var apiInstance = new DefaultApi();
            //InlineResponse200 uResult = apiInstance.GetUserUsernamePasswordGet(username, password);
            //var Position = uResult.Position;
            //Boolean IsCaptain = (Boolean)uResult.IsCaptain;
            //currentUser = new Workers.User(IsCaptain, Position);
            //return currentUser;
            currentUser = new Workers.User(false, "der", "123", "Hello");
            return currentUser;
        }
        public Workers.User Logout()
        {
            currentUser = null;
            return currentUser;
        }
        public Boolean TryCheckIn(String currentPoss)
        {
            //  return Check.Check1.getInstance().CheckIn(currentUser, currentPoss);
            return true;
        }
        public Boolean TryCheckOut(String currentPoss)
        {
            //  return Check.Check1.getInstance().CheckOut(currentUser, currentPoss);
            return true;
        }
    }
}

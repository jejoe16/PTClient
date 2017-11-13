using PTClient.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Logic.LogicController
{
    class Controller
    {
        private Position.ITurbinePosition turbines = new Position.TurbinePosition();
        private static Controller controller = null;
        private IAPIController api = null;
        private Login.User currentUser;
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

        public void Login(String username, String password)
        {

            //var apiInstance = new DefaultApi();
            //InlineResponse200 uResult = apiInstance.GetUserUsernamePasswordGet(username, password);
            //var Position = uResult.Position;
            //Boolean IsCaptain = (Boolean)uResult.IsCaptain;
            //currentUser = new Workers.User(IsCaptain, Position);
            //return currentUser;
            currentUser = new Login.User(false, "der", "123", "Hello");
        }
        public void Logout()
        {
            currentUser = null;
        }
        public Boolean TryCheckIn(String currentPoss)
        {
            return true;
        }
        public Boolean TryCheckOut(String currentPoss)
        {
            return true;
        }
    }
}

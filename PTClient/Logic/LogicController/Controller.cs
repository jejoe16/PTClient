using PTClient.API;
using PTClient.Logic.Login;
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
            
            
            
        }
        public void Logout()
        {
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

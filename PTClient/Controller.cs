using IO.Swagger.Api;
using IO.Swagger.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient
{
   public sealed class Controller
    {
        private static Controller instance = null;
        private Position.ITurbinePosition turbines = new Position.TurbinePosition();
        private Map.IMap map = new Map.MapControl();
        private Workers.User currentUser;

        /// <summary>
        /// Singleton method to get the current instance. 
        /// </summary>
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }

        /// <summary>
        /// init the code, called when program start.
        /// </summary>
        public void Init()
        {
            DownloadTurbines();
            SetWindTurbineMarkers();
        }

        /// <summary>
        /// downloads the list of turbines from the server and adds them to the client 
        /// </summary>
        private void DownloadTurbines()
        {
            var apiInstance = new DefaultApi();
            InlineResponse2001 result = apiInstance.TurbineGet();
            

            //List<long> latitude = new List<long>();
            //List<long> longitude = new List<long>();
            //List<String> name = new List<String>();

            //name.Add("A1");
            //latitude.Add(56572061873);
            //longitude.Add(11309738159);


            var latitude = result.Latitude;
            var longitude = result.Longitude;
            var name = result.Name;

            for (int i = 0; i < name.Count; i++)
            {
                turbines.AddTurbine(name[i], (long)latitude[i], (long)longitude[i]);
            }
        }

        /// <summary>
        /// set the turbines on the graphics map
        /// </summary>
        private void SetWindTurbineMarkers()
        {
            var turbinelist = turbines.GetTurbineList();
            map.SetTurbineMarkers(turbinelist);
        }

        /// <summary>
        /// Used to get the user 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Workers.User Login(String username, String password)
        {

            //var apiInstance = new DefaultApi();
            //InlineResponse200 uResult = apiInstance.GetUserUsernamePasswordGet(username, password);
            //var Position = uResult.Position;
            //Boolean IsCaptain = (Boolean)uResult.IsCaptain;
            //currentUser = new Workers.User(IsCaptain, Position);
            //return currentUser;
            currentUser = new Workers.User(false, "der");
            return currentUser;
        }
        public Workers.User Logout()
        {
            currentUser = null;
            return currentUser;
        }
        public Boolean TryCheckIn(String currentPoss)
        {
            return Check.Check.getInstance().CheckIn(currentUser, currentPoss);
        }
        public Boolean TryCheckOut(String currentPoss)
        {
            return Check.Check.getInstance().CheckOut(currentUser, currentPoss);
        }
        }
    }

using PTClient.IO.Swagger.Api;
using PTClient.IO.Swagger.Model;
using System;
using System.Collections.Generic;
using PTClient.SharedResources;


namespace PTClient.API
{
    class APIController : IAPIController
    {   
        private static APIController apicontroller = null;
        private DefaultApi api = null;
        private InlineResponse200 response200 = null;
        private InlineResponse201 response201 = null;
        private InlineResponse203 response203 = null;
        private InlineResponse204 response204 = null;
        private InlineResponse2021 response2021 = null;
        private InlineResponse2022 response2022 = null;

        APIController()
        {
            api = new DefaultApi();
        }

        public static APIController GetAPIController()
        {
            if (apicontroller == null)
            {
                apicontroller = new APIController();
            }
            return apicontroller;
           
        }

        public Boolean CaptainCheck()
        {
            return (Boolean)response201.IsCaptain;
        }

        public List<TurbineItem> getTurbines()
        {
            response2022 = api.TurbineGet();
            return response2022.Turbines;
        }

       public List<WorkerItem> getWorkerListItem()
        {
            response2021 = api.GetAllWorkersGet();
            return response2021.Workers;
        }

        public String GetUserPosition()
        {
            return response200.Position;
        }

        public Boolean Login(string Username, string Password)
        {
            response201 = api.LoginUsernamePasswordGet(Username, Password);
            if (response201.Confirm == false)
            {
                return false;
            }
            else
                return true;
            {

            }
        }

        public Boolean UpdateUserPosition(string Username, string Password, string Position)
        {
            
            response203 = api.UpdateLocationUsernamePasswordPositionGet(Username, Password, Position);

            return (bool)response203.Message;

        }

        public List<TurbineItem> checkRoute(string username, string password, double boatlong, double boatlat)
        {
            response204 = api.GetRouteUsernamePasswordBoatLatitudeBoatLongitudeGet(username, password, boatlat, boatlong);

            return response204.Routemarker;
        }

        public void StateEmergency(string Username, string Password)
        {
            api.EmergencyUsernamePasswordPost(Username, Password);
        }
    }
}

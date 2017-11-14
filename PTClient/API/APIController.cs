using PTClient.IO.Swagger.Api;
using PTClient.IO.Swagger.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.API
{
    class APIController : IAPIController
    {   
        private static APIController apicontroller = null;
        private DefaultApi api = null;
        private InlineResponse200 response200 = null;
        private InlineResponse2001 response2001 = null;

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
            return (Boolean)response200.IsCaptain;
        }

        public List<String> GetTurbinesName()
        {
            if (response2001 == null)
            {
                response2001 = api.TurbineGet();
            }

            return response2001.Name;
        }

        public List<int?> GetTurbinesLongitude()
        {
            if (response2001 == null)
            {
                response2001 = api.TurbineGet();
            }

            return response2001.Longitude;
        }

        public List<int?> GetTurbinesLatitude()
        {
            if (response2001 == null)
            {
                response2001 = api.TurbineGet();
            }

            return response2001.Latitude;
        }


        public String GetUserPosition()
        {
            return response200.Position;
        }

        public Boolean Login(string Username, string Password)
        {
            response200 = api.GetUserUsernamePasswordGet(Username, Password);
            if (response200.Position == null)
            {
                return false;
            }
            else
                return true;
            {

            }
        }

        public string UpdateUserPosition(string Username, string Password, string Position)
        {
            throw new NotImplementedException();
        }
    }
}

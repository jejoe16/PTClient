using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleTrackingC.Persistence.API
{
    interface IAPIController
    {
        List<String> GetTurbinesName();
        List<int?> GetTurbinesLongitude();
        List<int?> GetTurbinesLatitude();
        Boolean Login(String UserName, String PassWord);
        String GetUserPosition();
        bool? CaptainCheck();
    }
}

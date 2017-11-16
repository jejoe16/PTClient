using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Logic.LogicController
{
    interface IController
    {
        void DownloadTurbines();
        List<String> GetWindTurbineList();
        long GetTurbineLongitude(String Name);
        long GetTurbineLatitude(String Name);
        Boolean Login(String username, String password);
        void Logout();
        Boolean CheckIn(String currentPos);
        Boolean CheckOut(String currentPoss);
        Boolean CaptainCheck();

    }
}

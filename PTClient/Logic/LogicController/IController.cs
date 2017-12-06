using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTClient.SharedResources;
using PTClient.Logic.Emergency;

namespace PTClient.Logic.LogicController
{
    interface IController
    {
        double GetTurbineLongitude(String Name);
        double GetTurbineLatitude(String Name);
        List<String> GetTurbineNames();
        Boolean Login(String username, String password);
        void Logout();
        Boolean CheckIn(String currentPos);
        Boolean CheckOut(String currentPoss);
        Boolean CaptainCheck();
        List<TurbineItem> GetTurbines();
        Boolean CheckConnection();
        List<WorkerItem> GetWorkerListItems();
        Boolean ExistRouteapi(double lat, double longi);
        Boolean CheckState();
        void SetEmergency();
        List<Point> GetRoute();
        bool CallEmergency();

    }
}

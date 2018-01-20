using System;
using System.Collections.Generic;
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
        Boolean CheckIn(Double latitude, Double longitude);
        Boolean CheckOut();
        Boolean CaptainCheck();
        List<TurbineItem> GetTurbines();
        Boolean CheckConnection();
        void NewSession(String Username, String Password);
        List<WorkerItem> GetWorkerListItems();
        Boolean ExistRouteapi(double lat, double longi);
        Boolean CheckState();
        List<Point> GetRoute();
        bool CallEmergency();

    }
}

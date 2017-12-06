using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTClient.SharedResources;

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

    }
}

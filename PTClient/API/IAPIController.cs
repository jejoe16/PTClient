using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTClient.SharedResources;

namespace PTClient.API
{
    interface IAPIController
    {
        List<TurbineItem> getTurbines();

        List<WorkerItem> getWorkerListItem();
        Boolean Login(String UserName, String PassWord);
        String GetUserPosition();
        Boolean CaptainCheck();
        Boolean UpdateUserPosition(String Username, String Password, String Position);
        void StateEmergency(string Username, string Password);
        List<TurbineItem> checkRoute(string username, string password, double boatlong, double boatlat);
    }
}

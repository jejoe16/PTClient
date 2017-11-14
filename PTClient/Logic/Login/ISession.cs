using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Logic.Login
{
    interface ISession
    {
        String GetUserName();
        void SetUserName(String username);
        String GetPassword();
        void SetPassWord(String password);
        String GetUptime();
        void ClearSession();
        void SetCaptain(bool capt);
        bool GetCaptain();
        bool LoggedIn();
        void SetUserPosition(long latitude, long longitude);
        long GetUserLongtitude();
        long GetUserLatitude();
    }
}

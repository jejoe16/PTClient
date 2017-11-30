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
        void ClearSession();
        void SetCaptain(bool capt);
        bool GetCaptain();
        bool LoggedIn();
        void SetUserPosition(String position);
        void createUser(string Username, string Password, bool Captain);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Logic.Login
{
    class Session : ISession
    {

        private User currentUser;


        public Session(string Username, string Password, bool Captain)
        {
            currentUser = new User(Captain, Password, Username);
        }

        public void ClearSession()
        {
            currentUser = null;
        }

        public bool GetCaptain()
        {
            return currentUser.Captain;
        }

        public string GetPassword()
        {
            return currentUser.Password;
        }

        public string GetUptime()
        {
            throw new NotImplementedException();
        }

        public long GetUserLatitude()
        {
            throw new NotImplementedException();
        }

        public long GetUserLongtitude()
        {
            throw new NotImplementedException();
        }

        public string GetUserName()
        {
            return currentUser.Username;
        }

        public bool LoggedIn()
        {
            if (currentUser == null)
            {
                return false;
            }
            return true;
        }

        public void SetCaptain(bool capt)
        {
            currentUser.Captain = capt;
        }

        public void SetPassWord(string password)
        {
            currentUser.Password = password;
        }

        public void SetUserName(string username)
        {
            currentUser.Username = username;
        }

        public void SetUserPosition(long latitude, long longtitude)
        {
            throw new NotImplementedException();
        }
    }
}

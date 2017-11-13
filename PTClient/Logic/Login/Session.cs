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
            throw new NotImplementedException();
        }

        public bool GetCaptain()
        {
            throw new NotImplementedException();
        }

        public string GetPassword()
        {
            throw new NotImplementedException();
        }

        public string GetUptime()
        {
            throw new NotImplementedException();
        }

        public string GetUserName()
        {
            throw new NotImplementedException();
        }

        public void SetCaptain(bool capt)
        {
            throw new NotImplementedException();
        }

        public void SetPassWord(string password)
        {
            throw new NotImplementedException();
        }

        public void SetUserName(string username)
        {
            currentUser.Username.
        }

        
    }
}

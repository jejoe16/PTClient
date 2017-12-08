using System;

namespace PTClient.Logic.Login
{
    class Session : ISession
    {

        private User currentUser = null;

        public Session()
        {

        }
        public void createUser(string Username, string Password, bool Captain)
        {
            String User = Username;
            currentUser = new User(Captain, Username, Password);
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


        public string GetUserName()
        {
            String User = currentUser.Username;
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

        public void SetUserPosition(String position)
        {
            currentUser.Position = position;
        }
    }
}

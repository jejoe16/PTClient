using System;

namespace PTClient.Logic.Login
{
    public class User
    {
        private Boolean captain  = false;
        public Boolean Captain { get { return this.captain; } set { this.captain = value; } }

        private String username;
        public String Username { get { return this.username; } set { this.username = value; } }

        private String password;
        public String Password { get { return this.password; } set { this.password = value; } }

        private String position;
        public String Position { get { return this.position; } set { this.position = value; } }


        public User(Boolean capt, String user, String pw)
        {
            this.captain = capt;
            this.username = user;
            this.password = pw;
        }

    }
}
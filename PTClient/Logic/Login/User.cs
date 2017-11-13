using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Logic.Login
{
    public class User
    {
        private Boolean captain;
        public Boolean Captain { get { return this.captain; } set { this.captain = value; } }
        private String username;
        public String Username { get { return this.username; } set { this.username = value; } }
        private String password;
        public String Password { get { return this.password; } set { this.password = value; } }


        public User(Boolean capt, String username, String pw)
        {
            captain = capt;
            username = Username;
            password = pw;
        }
        // indicates wheter or not this specific user should go down with his ship



    }
}
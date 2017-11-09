using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Workers
{
    public class User
    {
        private Boolean Captain { get; set; }
        private String Position { get; set; }
        private String Username { get; set; }
        private String Password { get; set; }


        public User(Boolean capt, String pos, String username, String pw)
        {
            Captain = capt;
            Position = pos;
            Username = Username;
            Password = pw;
        }
        // indicates wheter or not this specific user should go down with his ship



    }
}
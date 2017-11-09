using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleTrackingC.Workers
{
    public class User
    {
        public User(Boolean capt, String pos, String username, String pw)
        {
            captain = capt;
            Position = pos;
            Username = Username;
            Password = pw;
        }
        // indicates wheter or not this specific user should go down with his ship
        private Boolean captain { get; set; }
        private String Position { get; set; }
        private String Username { get; set; }
        private String Password { get; set; }

        public bool Captain { get => captain; }

       
    }
}
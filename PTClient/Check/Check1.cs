using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Check
{
    public class Check1 : ICheck
    {
        /*
         * takes a user and alters their possition if possible, else return false.
         * */
        public bool CheckIn(Workers.User user, String poss)
        {
            if (poss != null)
            {
                //Setting the current users location to the turbine which the user's been dropped off
                user.SetPossition(poss);
                return true;
            }
            else
            {
                // was unable to set the users location to a turbine
                return false;
            }

        }
        /*
         * Places the user on the vessel or harbor, not on turbine.
        **/

        public bool CheckOut(Workers.User user, String poss)
        {
            if (poss.ToLower().Equals("vessel"))
            {
                //on check out the user will be on the vessel
                user.SetPossition("vessel");
                return true;
            }
            else if (poss.ToLower().Equals("harbor"))
            {
                // on check out the user will be in the harbor  
                user.SetPossition("harbor");
                return true;
            }
            else
            {
                // it's not possible to check out right now
                return false;
            }
        }
    }
}

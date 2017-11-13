using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Logic.Login
{
    interface ILogin
    {
        Boolean Login(String username, String password);

    }
}

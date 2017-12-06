using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.SharedResources
{
    class WorkerItem
    {
        public WorkerItem(string userName, string location)
        {
            UserName = userName;
            Location = location;
        }

        public String UserName { get; }
        public String Location {get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Logic.Emergency
{
    class State
    {
        private Boolean emergency = false;
        public Boolean Emergency { get { return this.emergency; } set { this.emergency = value; } }
    }
}

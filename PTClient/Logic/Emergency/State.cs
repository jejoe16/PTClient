using System;

namespace PTClient.Logic.Emergency
{
    class State
    {
        private Boolean emergency = false;
        public Boolean Emergency { get { return this.emergency; } set { this.emergency = value; } }
    }
}

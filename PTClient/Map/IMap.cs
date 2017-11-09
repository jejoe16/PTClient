using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Map
{
    interface IMap
    {
        void SetTurbineMarkers(List<Position.WindTurbine> turbineList);

    }
}

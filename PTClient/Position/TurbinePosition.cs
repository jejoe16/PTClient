using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleTrackingC.Position
{
    class TurbinePosition : ITurbinePosition
    {
        private int radius = 100;
        private List<WindTurbine> windturbines = new List<WindTurbine>();
        private VesselPosition vessel = new VesselPosition();

        public void ShowPosDebugger()
        {
            vessel.ShowDebugger();
        }

        public void AddTurbine(string name, long latitude,long longitude)
        {
            WindTurbine wt;
            windturbines.Add(wt = new WindTurbine(name,latitude, longitude));
        }

        public string GetNearWindTurbine()
        {
            foreach (WindTurbine wts in windturbines)
            {
                double lat = vessel.GetLatitude(); // vessel lat 
                double lon = vessel.GetLongitude(); // vessel long
                double result = (Math.Pow((lat - wts.GetLatitude), 2) + Math.Pow((lon - wts.GetLongitude), 2));

                if (result <= Math.Pow(radius, 2))
                {
                    return wts.GetName;
                }
            }
            return null;
        }

        public List<WindTurbine> GetTurbineList()
        {
            return windturbines;
        }

       

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Logic.Position
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

        public List<String> GetTurbineName()
        {
            List<String> TurbineNames = new List<String>();
            foreach (WindTurbine wt in windturbines)
            {
                TurbineNames.Add(wt.GetName);
            }
            return TurbineNames;
        }

        public long GetTurbineLatitude(String Name)
        {
            long Latitude = 0;
            foreach (WindTurbine wt in windturbines)
            {
                if (wt.GetName.Equals(Name))
                {
                    Latitude = wt.GetLatitude;
                }
            }
            return Latitude;
        }

        public long GetTurbineLongitude(String Name)
        {
            long Longitude = 0;
            foreach (WindTurbine wt in windturbines)
            {
                if (wt.GetName.Equals(Name))
                {
                    Longitude = wt.GetLongitude;
                }
            }
            return Longitude;
        }




    }
}

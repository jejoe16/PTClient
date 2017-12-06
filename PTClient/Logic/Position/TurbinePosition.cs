using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTClient.SharedResources;

namespace PTClient.Logic.Position
{
    class TurbinePosition : ITurbinePosition
    {
        private int radius = 100;
        private List<TurbineItem> windturbines = new List<TurbineItem>();
        private VesselPosition vessel = new VesselPosition();

        public void ShowPosDebugger()
        {
            vessel.ShowDebugger();
        }

        

        public void AddTurbines(List<TurbineItem> turbines)
        {
            windturbines = turbines;
        }

        public string GetNearWindTurbine(Double latitude, Double longitude)
        {
            foreach (TurbineItem wts in windturbines)
            {
           
                double result = (Math.Pow((latitude - (double)wts.Latitude), 2) + Math.Pow((longitude - (double)wts.Longitude), 2));

                if (result <= Math.Pow(radius, 2))
                {
                    return wts.Name;
                }
            }
            return null;
        }

        public List<TurbineItem> GetTurbineList()
        {
            return windturbines;
        }

        

        public List<String> GetTurbineNames()
        {
            List<String> TurbineNames = new List<String>();
            foreach (TurbineItem wt in windturbines)
            {
                TurbineNames.Add(wt.Name);
            }
            return TurbineNames;
        }

        public double GetTurbineLatitude(String Name)
        {
            double Latitude = 0;
            foreach (TurbineItem wt in windturbines)
            {
                if (wt.Name.Equals(Name))
                {
                    Latitude = (double)wt.Latitude;
                }
            }
            return Latitude;
        }

        public double GetTurbineLongitude(String Name)
        {
            double Longitude = 0;
            foreach (TurbineItem wt in windturbines)
            {
                if (wt.Name.Equals(Name))
                {
                    Longitude = (double)wt.Longitude;
                }
            }
            return Longitude;
        }




    }
}

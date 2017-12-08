using System;
using System.Collections.Generic;
using PTClient.SharedResources;


namespace PTClient.Logic.Position
{
    class TurbinePosition : ITurbinePosition
    {
        private double MinDistance = 0.5;
        private List<TurbineItem> windturbines = new List<TurbineItem>();
        private DistanceCalc DistanceCalculator = new DistanceCalc();


        public void AddTurbines(List<TurbineItem> turbines)
        {
            windturbines = turbines;
        }

        public string GetNearWindTurbine(Double latitude, Double longitude)
        {

            foreach (TurbineItem wts in windturbines)
            {
                
                double distance = DistanceCalculator.Distance(latitude, longitude, (double)wts.Latitude, (double)wts.Longitude);

                if (distance <= MinDistance)
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

using System;

namespace PTClient.Logic.Position
{
    class DistanceCalc
    {

        public double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(DegToRad(lat1)) * Math.Sin(DegToRad(lat2)) + Math.Cos(DegToRad(lat1)) * Math.Cos(DegToRad(lat2)) * Math.Cos(DegToRad(theta));
            dist = Math.Acos(dist);
            dist = RadToDeg(dist);
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344;
            return (dist);
        }

        private double DegToRad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private double RadToDeg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}

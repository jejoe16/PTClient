using PTClient.SharedResources;
using System.Collections.Generic;

namespace PTClient.Logic.Emergency
{
    class EmergencyRoute
    {
        private List<TurbineItem> route = new List<TurbineItem>();

        public void SetRoute(List<TurbineItem> route)
        {
            this.route = route;
        }

        public List<Point> GetPickUpPoints()
        {
            List<Point> pickUpPoints = new List<Point>();
            foreach (var Turbineitem in route)
            {
                pickUpPoints.Add(new Point(latitude: Turbineitem.Latitude.Value, longitude: Turbineitem.Longitude.Value));
            }
            return pickUpPoints;
        }
    }
}

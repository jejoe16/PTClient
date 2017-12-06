using PTClient.SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Logic.Emergency
{
    class EmergencyRoute
    {
        private List<TurbineItem> route = new List<TurbineItem>();


        public void setRoute(List<TurbineItem> route)
        {
            this.route = route;
        }

        public List<Point> getPickUpPoints()
        {
            List<Point> pickUpPoints = new List<Point>();
            foreach (var Turbineitem in route)
            {
                pickUpPoints.Add(new Point(lattitude: Turbineitem.Latitude.Value, longtitude: Turbineitem.Longitude.Value));
            }
            return pickUpPoints;
        }
    }
}

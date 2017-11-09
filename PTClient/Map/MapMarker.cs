using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleTrackingC.Map
{
    abstract class MapMarker
    {
        private string name;
        private long latitude;
        private long longitude;

        public MapMarker(string name, long latitude, long longitude)
        {
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public string Name { get => name; }
        public long Latitude { get => latitude; }
        public long Longitude { get => longitude; }
    }
}

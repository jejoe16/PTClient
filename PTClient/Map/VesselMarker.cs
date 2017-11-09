using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleTrackingC.Map
{
    class VesselMarker : MapMarker
    {
        private Bitmap image = PeopleTrackingC.Properties.Resources.vessel;

        public VesselMarker(string name, long latitude, long longitude) : base(name, latitude, longitude)
        {
        }

        public Bitmap Image { get => image; }
    }
}

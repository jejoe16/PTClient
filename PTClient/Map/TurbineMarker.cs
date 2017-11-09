using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleTrackingC.Map
{
    class TurbineMarker : MapMarker
    {
        private Bitmap image = PeopleTrackingC.Properties.Resources.wind;

        public TurbineMarker(string name, long latitude, long longitude) : base(name, latitude, longitude)
        {
        }

        public Bitmap Image { get => image; }
    }
}

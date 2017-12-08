using System.Drawing;

namespace PTClient.GUI.Map
{
    class VesselMarker : MapMarker
    {
        private Bitmap image = PTClient.Properties.Resources.vessel;

        public VesselMarker(string name, double latitude, double longitude) : base(name, latitude, longitude)
        {

        }

        public Bitmap Image { get => image; }
    }
}
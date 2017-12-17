using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PTClient.GUI.Map
{
    class MapControl : IMap
    {
        private static List<Object> markers = new List<Object>();
        private ReaderWriterLock rwl = new ReaderWriterLock();

        public void AddTurbineMarker(String Name, double Latitude, double Longitude)
        {
            rwl.AcquireWriterLock(10000);
            try
            {
                markers.Add(new TurbineMarker(Name, Latitude, Longitude));
            }
            finally
            {
                rwl.ReleaseWriterLock();
            }
        }
        

        public List<GMap.NET.WindowsForms.GMapMarker> DrawMarkers()
        {
            rwl.AcquireWriterLock(10000);

            try
            {
                List<GMap.NET.WindowsForms.GMapMarker> markerListDrawing = new List<GMap.NET.WindowsForms.GMapMarker>();


                foreach (TurbineMarker obj in markers)
                {
                    Bitmap Image = new Bitmap(obj.Image);
                    Bitmap resized = new Bitmap(Image, new Size(30, 40));

                    double lat = obj.Latitude;
                    double lon = obj.Longitude;

                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, lon), new Bitmap(resized));
                    markerListDrawing.Add(marker);
                }

                return markerListDrawing;
            } finally
            {
                rwl.ReleaseWriterLock();
            }

        }

        
    }
}

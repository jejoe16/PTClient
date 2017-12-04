using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.GUI.Map
{
    class MapControl : IMap
    {
        private static List<Object> markers = new List<Object>();
      

        public void AddTurbineMarker(String Name, double Latitude, double Longitude)
        {
            markers.Add(new TurbineMarker(Name, Latitude, Longitude));
        }
        

        public List<GMap.NET.WindowsForms.GMapMarker> DrawMarkers()
        {
            List<GMap.NET.WindowsForms.GMapMarker> markerListDrawing = new List<GMap.NET.WindowsForms.GMapMarker>();


            foreach (TurbineMarker obj in markers)
            {
                Bitmap Image = new Bitmap(obj.Image);
                Bitmap resized = new Bitmap(Image, new Size(20, 40));

                double lat = obj.Latitude;
                double lon = obj.Longitude;

                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat,lon), new Bitmap(resized));
                markerListDrawing.Add(marker);
            }



            //foreach (VesselMarker obj in markers)
            //{
            //    Bitmap Image = new Bitmap(obj.Image);
            //    Bitmap resized = new Bitmap(Image, new Size(20, 40));
            //    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(obj.Latitude, obj.Longitude), new Bitmap(resized));
            //    markerListDrawing.Add(marker);
            //}
            return markerListDrawing;

        }
        private double ConvertStoD(string s)
        {
            StringBuilder sb = new StringBuilder(s);
            sb.Insert(2,",");
            return double.Parse(sb.ToString());
        }
    }
}

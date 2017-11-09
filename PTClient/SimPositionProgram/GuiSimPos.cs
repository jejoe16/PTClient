using GMap.NET;
using GMap.NET.WindowsForms;
using PeopleTrackingC.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeopleTrackingC.SimPosition
{
    public partial class GuiSimPos : Form
    {
        public GuiSimPos()
        {
            InitializeComponent();
        }

        private double lat = 0;
        private double lon = 0;

        public double Lat { get => lat; }
        public double Lon { get => lon; }

        private void OnLoad(object sender, EventArgs e)
        {
            gMapSim.MapProvider = GMap.NET.MapProviders.OpenStreet4UMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapSim.SetPositionByKeywords("anholt");
            gMapSim.MinZoom = 0;
            gMapSim.MaxZoom = 50;
            gMapSim.Zoom = 10;
            Setmarkers();
        }

        /// <summary>
        /// Set wind turbines on the map + rings around each wind turbine to see the checkin limit
        /// </summary>
        private void Setmarkers()
        {
            MapControl mapc = new MapControl();

            GMap.NET.WindowsForms.GMapOverlay markersOverlay = new GMapOverlay("markersSim");

            gMapSim.Overlays.Add(markersOverlay);

            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            int Points = 50;
            double radius = 0.005;
            double point = Math.PI * 2 / Points;


            foreach (GMap.NET.WindowsForms.GMapMarker mark in mapc.DrawMarkers())
            {
                markersOverlay.Markers.Add(mark);

                List<PointLatLng> pointsList = new List<PointLatLng>();

                for (int i = 0; i < Points; i++)
                {
                    double theta = point * i;
                    double latitudePoint = mark.Position.Lat + Math.Cos(theta) * radius;
                    double longitudePoint = mark.Position.Lng + Math.Sin(theta) * radius;

                    PointLatLng latlongPoint = new PointLatLng(latitudePoint, longitudePoint);

                    pointsList.Add(latlongPoint);

                }

                GMapPolygon circles = new GMapPolygon(pointsList, "pol");
                polyOverlay.Polygons.Add(circles);

            }

            gMapSim.Overlays.Add(polyOverlay);
            gMapSim.Update();

        }

        private void SetPosition_Click(object sender, EventArgs e)
        {
            lat = gMapSim.Position.Lat;
            lon = gMapSim.Position.Lng;
            latLabel.Text = String.Concat(lat);
            longLabel.Text = String.Concat(lon);
        }
    }
}

using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PTClient.GUI.Map
{
    public partial class CaptainScreen : Form
    {
        GUIController controller = GUIController.GetController();
        public CaptainScreen()
        {
            controller.generateMap();
            InitializeComponent();
        }

        private void Onload(object sender, EventArgs e)
        {

            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;


            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.SetPositionByKeywords("anholt");
            gmap.MinZoom = 0;
            gmap.MaxZoom = 50;
            gmap.Zoom = 10;
            SetMarkers();
        }

        private void SetMarkers()
        {

            if (Logic.LogicController.Controller.GetController().CheckState())
            {
                List<Logic.Emergency.Point> PickUpPoints = Logic.LogicController.Controller.GetController().GetRoute();
                GMapOverlay routes = new GMapOverlay("routes");
                List<PointLatLng> points = new List<PointLatLng>();
                foreach (var Point in PickUpPoints)
                {
                    points.Add(new PointLatLng(Point.getLatt(), Point.getLong()));
                }
                GMapRoute route = new GMapRoute(points, "Emergency route");
                route.Stroke = new Pen(Color.Red, 3);
                routes.Routes.Add(route);
                gmap.Overlays.Add(routes);
            }else
            {
GMap.NET.WindowsForms.GMapOverlay markersOverlay = new GMapOverlay("markers");

            gmap.Overlays.Add(markersOverlay);

            MapControl mapc = new MapControl();

            foreach (GMap.NET.WindowsForms.GMapMarker mark in mapc.DrawMarkers())
            {
                markersOverlay.Markers.Add(mark);
            }
            }
            
            
            
        }

        private void buttonCheckin_Click(object sender, EventArgs e)
        {
            Logic.LogicController.Controller.GetController().CheckIn("mangler i capt gui");
        }

        private void buttonCheckout_Click(object sender, EventArgs e)
        {
            Logic.LogicController.Controller.GetController().CheckOut("Mangler i capt gui");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logic.LogicController.Controller.GetController().Logout();
            this.Close();
        }

        private void gmap_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logic.LogicController.Controller.GetController().CallEmergency();
            
        }

        private void setRoute(List<Logic.Emergency.Point> PickUpPoints)
        {
            SetMarkers();
        }
    }
}

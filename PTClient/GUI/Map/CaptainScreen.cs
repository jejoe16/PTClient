using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using PTClient.Logic.Position;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PTClient.SimPositionProgram.BoatGenerator;
using PTClient.Logic.LogicController;

namespace PTClient.GUI.Map
{
    public partial class CaptainScreen : Form
    {
        GUIController controller = GUIController.GetController();
        BoatPosition boat;
        Boolean boatStatus = true;
        GMapOverlay vesselOverlay = new GMapOverlay("vesselmarkers");
        private Controller logicController = Controller.GetController();

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
            boat = BoatPosition.GetBoatPosition();
            ThreadStart route = new ThreadStart(SetRouteThread);
            Thread RouteThread = new Thread(route);
            RouteThread.Start();
        }

        private void SetMarkers()
        {
            
            GMap.NET.WindowsForms.GMapOverlay markersOverlay = new GMapOverlay("turbinemarkers");

            gmap.Overlays.Add(markersOverlay);
            gmap.Overlays.Add(vesselOverlay);

            MapControl mapc = new MapControl();

            foreach (GMap.NET.WindowsForms.GMapMarker mark in mapc.DrawMarkers())
            {
                markersOverlay.Markers.Add(mark);
            }
            
        }

        public static void SetVesselMarker()
        {

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

        private void start_Click(object sender, EventArgs e)
        {
            EngineStartButton.Enabled = false;
            EngineStopButton.Enabled = true;
            ThreadPool.QueueUserWorkItem(BoatThreadCallBack);
        }

        private void stop_Click(object sender, EventArgs e)
        {
            boatStatus = false;
            EngineStartButton.Enabled = true;
            EngineStopButton.Enabled = false;
        }

        private void BoatThreadCallBack(Object ThreadContext)
        {
            boatStatus = true;
            
            while (boatStatus)
            {
                boat.generateNewPosition();
                gmap.Invoke(new Action(() => vesselOverlay.Clear()));
                VesselMarker vessel = new VesselMarker("Boat1", boat.GetNextLatitude(), boat.GetNextLongtitude());
                Bitmap Image = new Bitmap(vessel.Image);
                Bitmap resized = new Bitmap(Image, new Size(30, 50));
                Bitmap rotated = controller.rotateImage(resized, boat.getDirection());
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(vessel.Latitude, vessel.Longitude), new Bitmap(rotated));
                gmap.Invoke(new Action(() => vesselOverlay.Markers.Add(marker)));
                Thread.Sleep(2000);
            }
            
        }
        private void SetRouteThread()
        {        
            while (true)
            {            
                if (logicController.ExistRouteapi(boat.GetNextLatitude(),boat.GetNextLongtitude()))
                {
                    logicController.setEmergency();
                    logicController.GetRoute();

                    break;
                }
                else if (!logicController.ExistRouteapi(boat.GetNextLatitude(), boat.GetNextLongtitude()))
                {
                    Thread.Sleep(1000);
                }
            }
                    
            if (logicController.CheckState())
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            logicController.setEmergency();
        }
    }

    
}

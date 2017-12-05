using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using PTClient.SimPositionProgram.BoatGenerator;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PTClient.GUI.Map
{
    public partial class CaptainScreen : Form
    {
        GUIController controller = GUIController.GetController();
        BoatPosition boat = new BoatPosition();
        Boolean boatStatus = true;
        GMapOverlay vesselOverlay = new GMapOverlay("vesselmarkers");

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

        
    }

    
}

using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using PTClient.SimPositionProgram.BoatGenerator;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PTClient.SharedResources;

namespace PTClient.GUI.Map
{
    public partial class CaptainScreen : Form
    {
        private GUIController controller = GUIController.GetController();
        private BoatPosition boat = new BoatPosition();
        private Boolean boatStatus = true;
        private GMapOverlay vesselOverlay = new GMapOverlay("vesselmarkers");
        private volatile int Dir;

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
            boatStatus = false;
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
                boat.GenerateRandomPosition();
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

        private void DirectionThreadCallBack(Object ThreadContext)
        {
            boatStatus = true;
            while (boatStatus)
            {
                boat.GoDirection(Dir);
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

        private void pictureBoxDir_Click(object sender, EventArgs e)
        {
            boatStatus = false;
            EngineStopButton.Enabled = true;
            PictureBox box = sender as PictureBox; 
            if(box.Name == pictureNorth.Name)
            {
                Dir = (int)Direction.North;
                ThreadPool.QueueUserWorkItem(DirectionThreadCallBack);
            }
            else if (box.Name == pictureNorthEast.Name)
            {
                Dir = (int)Direction.NorthEast;
                ThreadPool.QueueUserWorkItem(DirectionThreadCallBack);
            }
            else if (box.Name == pictureEast.Name)
            {
                Dir = (int)Direction.East;
                ThreadPool.QueueUserWorkItem(DirectionThreadCallBack);
            }
            else if (box.Name == pictureSouthEast.Name)
            {
                Dir = (int)Direction.SouthEast;
                ThreadPool.QueueUserWorkItem(DirectionThreadCallBack);
            }
            else if (box.Name == pictureSouth.Name)
            {
                Dir = (int)Direction.South;
                ThreadPool.QueueUserWorkItem(DirectionThreadCallBack);
            }
            else if (box.Name == pictureSouthWest.Name)
            {
                Dir = (int)Direction.SouthWest;
                ThreadPool.QueueUserWorkItem(DirectionThreadCallBack);
            }
            else if (box.Name == pictureWest.Name)
            {
                Dir = (int)Direction.West;
                ThreadPool.QueueUserWorkItem(DirectionThreadCallBack);
            }
            else if (box.Name == pictureNorthWest.Name)
            {
                Dir = (int)Direction.NorthWest;
                ThreadPool.QueueUserWorkItem(DirectionThreadCallBack);
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            boatStatus = false;
            EngineStopButton.Enabled = false;
        }
    }

    
}

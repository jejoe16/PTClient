using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using PTClient.SimPositionProgram.BoatGenerator;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PTClient.SharedResources;
using PTClient.Logic.LogicController;

namespace PTClient.GUI.Map
{
    public partial class CaptainScreen : Form
    {
        private GUIController controller = new GUIController();
        private BoatPosition boat = new BoatPosition();
        private Boolean boatStatus = true;
        private GMapOverlay vesselOverlay = new GMapOverlay("vesselmarkers");
        private volatile int Dir;
        private Thread thread;
        private IController LogicController;

        public CaptainScreen(String Username, String Password)
        {
            LogicController = controller.GetLogicController();
            LogicController.NewSession(Username, Password);
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


        private void Logout_Click(object sender, EventArgs e)
        {
            LogicController.Logout();
            thread.Abort();
            this.Close();
        }

        private void start_Click(object sender, EventArgs e)
        {
            boatStatus = false;
            if (thread != null)
            {
                thread.Join();
            }
            EngineStartButton.Enabled = false;
            EngineStopButton.Enabled = true;
            Thread.Sleep(2000);
            thread = new Thread(new ThreadStart(BoatThreadCallBack));
            thread.Start();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            boatStatus = false;
            thread.Join();
            EngineStartButton.Enabled = true;
            EngineStopButton.Enabled = false;
        }

        private void BoatThreadCallBack()
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

        private void DirectionThreadCallBack()
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
            if (thread != null)
            {
                thread.Abort();
            }
            
            ThreadStart start;
            EngineStopButton.Enabled = true;
            
            PictureBox box = sender as PictureBox; 
            if(box.Name == pictureNorth.Name)
            {
                Dir = (int)Direction.North;
                start = new ThreadStart(DirectionThreadCallBack);
            }
            else if (box.Name == pictureNorthEast.Name)
            {
                Dir = (int)Direction.NorthEast;
                start = new ThreadStart(DirectionThreadCallBack);
            }
            else if (box.Name == pictureEast.Name)
            {
                Dir = (int)Direction.East;
                start = new ThreadStart(DirectionThreadCallBack);
            }
            else if (box.Name == pictureSouthEast.Name)
            {
                Dir = (int)Direction.SouthEast;
                start = new ThreadStart(DirectionThreadCallBack);
            }
            else if (box.Name == pictureSouth.Name)
            {
                Dir = (int)Direction.South;
                start = new ThreadStart(DirectionThreadCallBack);
            }
            else if (box.Name == pictureSouthWest.Name)
            {
                Dir = (int)Direction.SouthWest;
                start = new ThreadStart(DirectionThreadCallBack);
            }
            else if (box.Name == pictureWest.Name)
            {
                Dir = (int)Direction.West;
                start = new ThreadStart(DirectionThreadCallBack);
            }
            else
            {
                Dir = (int)Direction.NorthWest;
                start = new ThreadStart(DirectionThreadCallBack);
            }

            thread = new Thread(start);
            thread.Start();
        }

     

        private void CaptainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
        }
    }

    
}

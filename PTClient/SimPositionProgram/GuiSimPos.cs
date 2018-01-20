using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using PTClient.GUI;
using PTClient.GUI.Map;
using PTClient.Logic.LogicController;
using PTClient.SharedResources;
using PTClient.SimPositionProgram.BoatGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTClient.SimPosition
{
    public partial class GuiSimPos : Form
    {

        private GUIController controller = new GUIController();
        private IBoatPosition Boat = BoatPosition.GetBoatPosition();
        private Boolean boatStatus = true;
        private GMapOverlay vesselOverlay = new GMapOverlay("vesselmarkers");
        private volatile int Dir;
        private Thread thread;
        private IController LogicController;

        public GuiSimPos()
        {
            LogicController = controller.GetLogicController();
            InitializeComponent();
        }



        private void OnLoad(object sender, EventArgs e)
        {
            gMapSim.MapProvider = GMap.NET.MapProviders.OpenStreet4UMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapSim.Overlays.Add(vesselOverlay);
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
            Boat.SetPosition(gMapSim.Position.Lat, gMapSim.Position.Lng);
            latLabel.Text = String.Concat(Boat.GetNextLatitude());
            longLabel.Text = String.Concat(Boat.GetNextLongitude());
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
        /// <summary>
        /// moves the boat in a random direction, until stopped
        /// </summary>
        private void BoatThreadCallBack()
        {
            boatStatus = true;

            while (boatStatus)
            {
                Boat.GenerateRandomPosition();
                AddNewBoatMarker();
                Thread.Sleep(1500);
            }

        }
        /// <summary>
        /// make the vessel go in a specific direction
        /// </summary>
        private void DirectionThreadCallBack()
        {
            boatStatus = true;
            while (boatStatus)
            {
                Boat.GoDirection(Dir);
                AddNewBoatMarker();
                Thread.Sleep(1500);
            }
        }

        /// <summary>
        /// show the vessels position on the map in simposition
        /// </summary>
        private void AddNewBoatMarker()
        {
            gMapSim.Invoke(new Action(() => vesselOverlay.Clear()));
            VesselMarker vessel = new VesselMarker("Boat1", Boat.GetNextLatitude(), Boat.GetNextLongitude());
            Bitmap Image = new Bitmap(vessel.Image);
            Bitmap resized = new Bitmap(Image, new Size(30, 50));
            Bitmap rotated = controller.rotateImage(resized, Boat.getDirection());
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(vessel.Latitude, vessel.Longitude), new Bitmap(rotated));
            gMapSim.Invoke(new Action(() => vesselOverlay.Markers.Add(marker)));
            latLabel.Invoke(new Action(() => latLabel.Text = String.Concat(Boat.GetNextLatitude())));
            longLabel.Invoke(new Action(() => longLabel.Text = String.Concat(Boat.GetNextLongitude())));
        }

        /// <summary>
        /// goes in a direction dependin on the button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (box.Name == pictureNorth.Name)
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

        /// <summary>
        /// stop threads on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimPos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
            }
        }
    }
}

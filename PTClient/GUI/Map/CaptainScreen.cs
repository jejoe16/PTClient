using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using PTClient.SimPositionProgram.BoatGenerator;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PTClient.SharedResources;
using System.Collections.Generic;
using PTClient.Logic.LogicController;
using PTClient.SimPosition;

namespace PTClient.GUI.Map
{
    public partial class CaptainScreen : Form
    {
        private GUIController controller = new GUIController();
        private IBoatPosition boat = BoatPosition.GetBoatPosition();
        private Boolean boatStatus = true;
        private GMapOverlay vesselOverlay = new GMapOverlay("vesselmarkers");
        private GMapOverlay routes = new GMapOverlay("routes");
        private Thread BoatThread;
        private Thread RouteThread;
        private Thread workerThread;
        private ReaderWriterLock rwl = new ReaderWriterLock();
        private IController LogicController;

        public CaptainScreen(String Username, String Password)
        {
            LogicController = controller.GetLogicController();
            LogicController.NewSession(Username, Password);
            boat = BoatPosition.GetBoatPosition();
            controller.generateMap();
            InitializeComponent();
            
        }

        /// <summary>
        /// Loads the map, and sets the turbine markers.
        /// starts 3 threads:
        /// first keep the work list updated
        /// second checks for a new route
        /// Last controls the boat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Onload(object sender, EventArgs e)
        {
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.SetPositionByKeywords("anholt");
            gmap.MinZoom = 0;
            gmap.MaxZoom = 50;
            gmap.Zoom = 10;
            SetMarkers();

            ThreadStart worker = new ThreadStart(UpdateWorkerList);
            workerThread = new Thread(worker);
            workerThread.Start();

            
            ThreadStart route = new ThreadStart(SetRouteThread);
            RouteThread = new Thread(route);
            RouteThread.Start();

            ThreadStart boatstarter = new ThreadStart(BoatThreadCallBack);
            BoatThread = new Thread(boatstarter);
            BoatThread.Start();



        }

        /// <summary>
        /// places markers on the map based on the list returned from map control
        /// </summary>
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

        /// <summary>
        /// logs the captain out, stops allr unning thread relevant to this window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logout_Click(object sender, EventArgs e)
        {

            LogicController.Logout();
            if (RouteThread != null)
            {
                RouteThread.Abort();
                workerThread.Abort();
                BoatThread.Abort();
            }
            this.Close();
        }

        /// <summary>
        /// draws the boat on the map, facing it in the correct direction.
        /// </summary>
        private void BoatThreadCallBack()
        {
            boatStatus = true;
            while (boatStatus)
            {
                gmap.Invoke(new Action(() => vesselOverlay.Clear()));
                VesselMarker vessel = new VesselMarker("Boat1", boat.GetNextLatitude(), boat.GetNextLongitude());
                Bitmap Image = new Bitmap(vessel.Image);
                Bitmap resized = new Bitmap(Image, new Size(30, 50));
                Bitmap rotated = controller.rotateImage(resized, boat.getDirection());
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(vessel.Latitude, vessel.Longitude), new Bitmap(rotated));
                gmap.Invoke(new Action(() => vesselOverlay.Markers.Add(marker)));
                Thread.Sleep(1500);
            }
        }


        /// <summary>
        /// opens a new window with all sim position features, in a new thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimPosBot_Click(object sender, EventArgs e)
        {
            ThreadStart starter = new ThreadStart(BootSimScreen);
            Thread thread = new Thread(starter);
            thread.Start();
        }


        /// <summary>
        /// opens a new sim position window
        /// </summary>
        private void BootSimScreen()
        {
            GuiSimPos sim = new GuiSimPos();
            sim.ShowDialog();
        }

        /// <summary>
        /// makes sure all threads are closed before window closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (RouteThread != null)
            {
                RouteThread.Abort();
                workerThread.Abort();
                BoatThread.Abort();
            }
        }

        
        /// <summary>
        /// updates work list from the database on the server
        /// </summary>
        private void UpdateWorkerList()
        {
            while (true)
            {
                List<WorkerItem> list = LogicController.GetWorkerListItems();
                gmap.Invoke(new Action(() => WorkerLocations.Items.Clear()));
                foreach (WorkerItem workerItem in list)
                {
                    ListViewItem item = new ListViewItem(workerItem.Name);
                    item.SubItems.Add(workerItem.Position);

                    gmap.Invoke(new Action(() => WorkerLocations.Items.Add(item)));
                }
                Thread.Sleep(5000);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            LogicController.CallEmergency();
        }

        /// <summary>
        /// ask the server for a new route. if the server is in an emergency state, will a route to the critical positions be drawn
        /// </summary>
        private void SetRouteThread()
        {
            List<Logic.Emergency.Point> PickUpPoints = new List<Logic.Emergency.Point>();
            while (true)
            {
                if (LogicController.ExistRouteapi(boat.GetNextLatitude(), boat.GetNextLongitude()))
                {

                    PickUpPoints = LogicController.GetRoute();
                    
                    break;
                }
                else if (!LogicController.ExistRouteapi(boat.GetNextLatitude(), boat.GetNextLongitude()))
                {
                    Thread.Sleep(2000);
                }
               
            } if (LogicController.CheckState())

                {
                gmap.Overlays.Add(routes);
                gmap.RoutesEnabled = true;
               
                List<PointLatLng> points = new List<PointLatLng>();
                    foreach (var Point in PickUpPoints)
                    {
                        points.Add(new PointLatLng(Point.getLat(), Point.getLong()));
                    }
                    GMapRoute route = new GMapRoute(points, "Emergency route");
                    route.Stroke = new Pen(Color.Red, 3);
                    routes.Routes.Add(route);
                    gmap.Overlays.Add(routes);
                }
        }


    }
}

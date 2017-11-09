using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PeopleTrackingC.Map
{
    public partial class Overview : Form
    {

        public Overview()
        {
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
            GMap.NET.WindowsForms.GMapOverlay markersOverlay = new GMapOverlay("markers");

            gmap.Overlays.Add(markersOverlay);

            MapControl mapc = new MapControl();

            foreach (GMap.NET.WindowsForms.GMapMarker mark in mapc.DrawMarkers())
            {
                markersOverlay.Markers.Add(mark);
            }
            
        }

        private void buttonCheckin_Click(object sender, EventArgs e)
        {

        }

        private void buttonCheckout_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

        }
    }
}

using PeopleTrackingC.SimPosition;

namespace PeopleTrackingC.Position
{
    /// <summary>
    /// class that returns the vessels position
    /// </summary>
    class VesselPosition
    {
        private ISimPosition simulator;

        public VesselPosition()
        {
            simulator = new SimPosition.SimPosition();
        }

        public void ShowDebugger()
        {
            simulator.OpenSimPositionGUI();
        }

        public double GetLatitude()
        {
            return simulator.GetLat();
        }
        public double GetLongitude()
        {
            return simulator.GetLon();
        }
    }
}

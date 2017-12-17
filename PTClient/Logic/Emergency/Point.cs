namespace PTClient.Logic.Emergency
{
    class Point
    {
        private double latitude;
        private double longitude;

        public Point(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
        public double getLat()
        {
            return latitude;
        }
        public double getLong()
        {
            return longitude;
        }
    }
}

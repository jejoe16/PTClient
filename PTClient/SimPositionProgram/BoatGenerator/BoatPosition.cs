using System;
using PTClient.SharedResources;
using System.Threading;

namespace PTClient.SimPositionProgram.BoatGenerator
{
    class BoatPosition:IBoatPosition
    {
        private double currentLatitude = 56.588423;
        private double currentLongitude = 11.277545;
        private Direction[] NextDir = new Direction[] {Direction.East, Direction.NorthEast, Direction.SouthEast};
        private float ImageDirection = 0;
        private static BoatPosition BoatPos;
        private ReaderWriterLock boat_lock = new ReaderWriterLock();



        public static BoatPosition GetBoatPosition()

        {
            if (BoatPos == null)
            {
                BoatPos = new BoatPosition();
            } 
            return BoatPos;
        }

        public void GenerateRandomPosition()
        {
            try
            {
                boat_lock.AcquireWriterLock(10000);
                Random rand = new Random();
                int Dir = (int)NextDir[rand.Next(NextDir.Length)];

                Boolean Valid = Move(Dir);

                if (Valid.Equals(false))
                {
                    GenerateRandomPosition();
                }
            } finally {
                boat_lock.ReleaseWriterLock();
            }
        }

        public Boolean GoDirection(int Direction)
        {
            try
            {
                boat_lock.AcquireWriterLock(10000);

                Boolean Valid = Move(Direction);

                if (Valid.Equals(false))
                {
                    return false;
                }
                return true;
            }
            finally
            {
                boat_lock.ReleaseWriterLock();
            }
        }

        private Boolean Move(int Dir)
        {
            Boolean Valid = false;
            switch (Dir)
            {
                case (int)Direction.North:
                    Valid = CalculatePosition(100, 0);
                    ImageDirection = 0;
                    NextDir = new Direction[] { Direction.NorthWest, Direction.North, Direction.NorthEast };
                    break;
                case (int)Direction.NorthEast:
                    Valid = CalculatePosition(100, 100);
                    ImageDirection = 45;
                    NextDir = new Direction[] { Direction.North, Direction.NorthEast, Direction.East };
                    break;
                case (int)Direction.East:
                    Valid = CalculatePosition(0, 100);
                    ImageDirection = 90;
                    NextDir = new Direction[] { Direction.NorthEast, Direction.East, Direction.SouthEast };
                    break;
                case (int)Direction.SouthEast:
                    Valid = CalculatePosition(-100, 100);
                    ImageDirection = 135;
                    NextDir = new Direction[] { Direction.East, Direction.SouthEast, Direction.South };
                    break;
                case (int)Direction.South:
                    Valid = CalculatePosition(-100, 0);
                    ImageDirection = 180;
                    NextDir = new Direction[] { Direction.SouthEast, Direction.South, Direction.SouthWest };
                    break;
                case (int)Direction.SouthWest:
                    Valid = CalculatePosition(-100, -100);
                    ImageDirection = 225;
                    NextDir = new Direction[] { Direction.South, Direction.SouthWest, Direction.West };
                    break;
                case (int)Direction.West:
                    Valid = CalculatePosition(0, -100);
                    ImageDirection = 270;
                    NextDir = new Direction[] { Direction.SouthWest, Direction.West, Direction.NorthWest };
                    break;
                case (int)Direction.NorthWest:
                    Valid = CalculatePosition(100, -100);
                    ImageDirection = 315;
                    NextDir = new Direction[] { Direction.West, Direction.NorthWest, Direction.North };
                    break;
                default:
                    Valid = CalculatePosition(0, 0);
                    NextDir = new Direction[] { Direction.North, Direction.NorthEast, Direction.NorthWest };
                    break;
            }
            return Valid;
        }

        private Boolean CalculatePosition(int north, int east)
        {
            //Earth’s radius, sphere
            var R = 6378137;

            //offsets in meters (negative for south and west)
            var dn = north;
            var de = east;

            //Coordinate offsets in radians
            double dLat = (double)dn / R;
            double dLon = (de / (R * Math.Cos(Math.PI * currentLatitude / 180)));

            //OffsetPosition, decimal degrees
            var newLatitude = currentLatitude + (dLat * 180 / Math.PI);
            var newLongitude = currentLongitude + (dLon * 180 / Math.PI);

            Boolean Validation = ValidatePosition(newLongitude, newLatitude) ;

            if (Validation.Equals(false))
            {
                return false;
            }
            else
            {
                currentLatitude = newLatitude;
                currentLongitude = newLongitude;
                return true;
            }
        }

        private Boolean ValidatePosition(double Longitude, double Latitude)
        {
            MapPolygon map = new MapPolygon();
            
            if(map.WithinMapBounds(Latitude, Longitude).Equals(false)){
                return false;
            }

            return true;
        }


        public double GetNextLongitude()
        {
            try
            {
                boat_lock.AcquireReaderLock(10000);
                return currentLongitude;
            } finally {
                boat_lock.ReleaseReaderLock();
            }
            
        }

        public double GetNextLatitude()
        {
            try
            {
                boat_lock.AcquireReaderLock(10000);
                return currentLatitude;
            } finally
            {
                boat_lock.ReleaseReaderLock();
            }
            
        }

        public float getDirection()
        {
            try
            {
                boat_lock.AcquireReaderLock(10000);
                return ImageDirection;
            }
            finally
            {
                boat_lock.ReleaseReaderLock();
            }
        }

        public void SetPosition(double Latitude, double Longitude)
        {
            try
            {
                boat_lock.AcquireWriterLock(10000);
                currentLatitude = Latitude;
                currentLongitude = Longitude;

            }
            finally
            {
                boat_lock.ReleaseWriterLock();
            }
            
        }
    }

}

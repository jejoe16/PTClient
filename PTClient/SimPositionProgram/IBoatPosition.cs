using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.SimPositionProgram.BoatGenerator
{
    interface IBoatPosition
    {
        Boolean GoDirection(int Direction);
        void GenerateRandomPosition();
        double GetNextLongitude();
        double GetNextLatitude();
        float getDirection();
        void SetPosition(Double Latitude, Double Longitude);
        
    }
}

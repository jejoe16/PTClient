﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.GUI.Map
{
    abstract class MapMarker
    {
        private string name;
        private double latitude;
        private double longitude;

        /// <summary>
        /// Marker used to draw items on the map
        /// </summary>
        /// <param name="name"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public MapMarker(string name, double latitude, double longitude)
        {
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
        }
       
        public string Name { get => name; }
        public double Latitude { get => latitude; }
        public double Longitude { get => longitude; }
    }
}

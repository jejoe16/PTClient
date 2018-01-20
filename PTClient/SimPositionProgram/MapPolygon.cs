using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;

namespace PTClient.SimPositionProgram
{
    class MapPolygon
    {
        GMapPolygon polygon;
        /// <summary>
        /// defined limits of the park, can be changed
        /// </summary>
        public MapPolygon()
        {
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(56.714065, 11.5046203));
            points.Add(new PointLatLng(56.761192, 11.394791));
            points.Add(new PointLatLng(56.591175, 10.958746));
            points.Add(new PointLatLng(56.378816, 11.238010));
            points.Add(new PointLatLng(56.548438, 11.722233));
            points.Add(new PointLatLng(56.714065, 11.5046203));
            polygon = new GMapPolygon(points, "Anholt");
        }

        /// <summary>
        /// checks if the vessel is winthin the maps bounds
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public Boolean WithinMapBounds(double latitude, double longitude)
        {
            PointLatLng point = new PointLatLng(latitude, longitude);
            if (polygon.IsInside(point))
            {
                return true;
            }
            return false;
        }


    }
}

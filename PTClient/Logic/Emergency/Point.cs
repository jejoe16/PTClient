﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClient.Logic.Emergency
{
    class Point
    {
        private double lattitude;
        private double longtitude;

        public Point(double lattitude, double longtitude)
        {
            this.lattitude = lattitude;
            this.longtitude = longtitude;
        }
        public double getLatt()
        {
            return lattitude;
        }
        public double getLong()
        {
            return longtitude;
        }
    }
}

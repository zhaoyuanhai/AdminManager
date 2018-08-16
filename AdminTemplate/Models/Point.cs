﻿using AdminTemplate.TypeConvert;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AdminTemplate.Models
{
    [TypeConverter(typeof(PointTypeConverter))]
    public class Point
    {
        public Point() { }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public static object Parse(string point)
        {
            string[] split = point.Split(',');
            if (split.Length != 2)
            {
                throw new FormatException("Invalid point expression.");
            }
            double x;
            double y;
            if (!double.TryParse(split[0], out x) ||
                !double.TryParse(split[1], out y))
            {
                throw new FormatException("Invalid point expression.");
            }
            return new Point(x, y);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StellarAnalysis
{
    struct PointVector
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public int Magnitude
        {
            get
            {
                return (int)Math.Sqrt((double)(X * X + Y * Y));
            }
        }

        public PointVector(int x, int y)
            : this()
        {
            X = x;
            Y = y;
        }

        public PointVector(Point point)
            : this(point.X, point.Y)
        {
        }

        public static PointVector operator +(PointVector a, PointVector b)
        {
            return new PointVector(a.X + b.X, a.Y + b.Y);
        }

        public static PointVector operator -(PointVector a, PointVector b)
        {
            return new PointVector(a.X - b.X, a.Y - b.Y);
        }

        public static PointVector operator *(PointVector a, int b)
        {
            return new PointVector(a.X * b, a.Y * b);
        }

        public static PointVector operator *(int a, PointVector b)
        {
            return b * a;
        }
    }
}

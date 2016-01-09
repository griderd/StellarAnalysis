using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCLib
{
    public class SkyVector
    {
        public HourAngle RA { get; private set; }
        public Angle DE { get; private set; }

        public SkyVector(HourAngle ra, Angle de)
        {
            RA = ra;
            DE = de;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", RA.ToString(), DE.ToString());
        }

        public static SkyVector operator +(SkyVector a, SkyVector b)
        {
            return new SkyVector(a.RA + b.RA, a.DE + b.DE);
        }

        public static SkyVector operator -(SkyVector a, SkyVector b)
        {
            return new SkyVector(a.RA - b.RA, a.DE - b.DE);
        }

        public static SkyVector operator *(SkyVector a, Angle b)
        {
            return new SkyVector(a.RA * b, a.DE * b);
        }

        public static SkyVector operator *(SkyVector a, double b)
        {
            return new SkyVector(a.RA * b, a.DE * b);
        }
    }
}

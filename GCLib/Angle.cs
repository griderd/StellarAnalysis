using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCLib
{
    public struct Angle
    {
        public const char DEGREE_SYMBOL = '°';

        int degrees, minutes;
        double seconds;

        public int Degrees { get { return degrees; } }
        public int Minutes { get { return minutes; } }
        public double Seconds { get { return seconds; } }

        public double Fractional { get; private set; }

        public Angle(double degreesFractional)
            : this()
        {
            this.degrees = (int)Math.Truncate(degreesFractional);
            this.minutes = (int)Math.Truncate((degreesFractional % 1.0f) * 60);
            this.seconds = (((degreesFractional % 1.0f) * 60.0f) % 1.0f) * 60.0f;

            Normalize();

            Fractional = ((double)Degrees) + (((double)Minutes) / 60) + (((double)Seconds) / 3600);
        }

        public Angle(int degrees, int minutes, double seconds)
            : this()
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.seconds = seconds;

            Normalize();

            Fractional = ((double)Degrees) + (((double)Minutes) / 60) + (((double)Seconds) / 3600);
        }

        void Normalize()
        {
            NormalizeSeconds();
            NormalizeMinutes();
            NormalizeDegrees();
        }

        void NormalizeSeconds()
        {
            while (seconds > 60.0f)
            {
                seconds = seconds - 60.0f;
                minutes = minutes + 1;
            }
            //while (seconds < 0.0f)
            //{
            //    seconds = seconds + 60.0f;
            //    minutes = minutes - 1;
            //}
        }

        void NormalizeMinutes()
        {
            while (minutes > 60)
            {
                minutes = minutes - 60;
                degrees = degrees + 1;
            }
            //while (minutes < 0)
            //{
            //    minutes = minutes + 60;
            //    degrees = degrees - 1;
            //}
        }

        void NormalizeDegrees()
        {
            while (degrees >= 360)
            {
                degrees = degrees - 360;
            }
            while (degrees <= -360)
            {
                degrees = degrees + 360;
            }
        }

        public static Angle operator +(Angle a, Angle b)
        {
            return new Angle(a.Fractional + b.Fractional);
        }

        public static Angle operator -(Angle a, Angle b)
        {
            return new Angle(a.Fractional - b.Fractional);
        }

        public static Angle operator *(Angle a, Angle b)
        {
            return new Angle(a.Fractional * b.Fractional);
        }

        public static Angle operator *(Angle a, double b)
        {
            return new Angle(a.Fractional * b);
        }

        public static Angle operator /(Angle a, Angle b)
        {
            return new Angle(a.Fractional / b.Fractional);
        }

        public static Angle operator /(Angle a, double b)
        {
            return new Angle(a.Fractional / b);
        }

        public static implicit operator Angle(double val)
        {
            return new Angle(val);
        }

        public override string ToString()
        {
            return string.Format("{0:+##0;-##0;+0}{1} {2}' {3:F3}\"", Degrees, DEGREE_SYMBOL, Minutes, Seconds);
        }
    }
}

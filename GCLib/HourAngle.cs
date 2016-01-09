using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCLib
{
    public struct HourAngle
    {
        int hours;
        int minutes;
        double seconds;

        Angle properAngle;

        public int Hours { get { return hours; } }
        public int Minutes { get { return minutes; } }
        public double Seconds { get { return seconds; } }

        public Angle Degrees { get { return properAngle; } }

        public HourAngle(int hours, int minutes, double seconds)
            : this()
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;

            Normalize();

            properAngle = new Angle(hours * 15, minutes * 15, seconds * 15.0f);
        }

        public HourAngle(Angle angle)
        {
            properAngle = angle;
            hours = angle.Degrees / 15;
            minutes = (int)Math.Truncate(((angle.Fractional / 15.0f) % 1.0f) * 60.0f);
            seconds = ((((angle.Fractional / 15.0f) % 1.0f) * 60.0f) % 1.0f) * 60.0f;

            Normalize();
        }

        void Normalize()
        {
            NormalizeSeconds();
            NormalizeMinutes();
            NormalizeHours();
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
                hours = hours + 1;
            }
            //while (minutes < 0)
            //{
            //    minutes = minutes + 60;
            //    hours = hours - 1;
            //}
        }

        void NormalizeHours()
        {
            while (hours >= 24)
            {
                hours = hours - 24;
            }
            while (hours < 0)
            {
                hours = hours + 24;
            }
        }

        public static HourAngle operator +(HourAngle a, HourAngle b)
        {
            return new HourAngle(a.Degrees + b.Degrees);
        }

        public static HourAngle operator -(HourAngle a, HourAngle b)
        {
            return new HourAngle(a.Degrees - b.Degrees);
        }

        public static HourAngle operator *(HourAngle a, HourAngle b)
        {
            return new HourAngle(a.Degrees * b.Degrees);
        }

        public static HourAngle operator *(HourAngle a, double b)
        {
            return new HourAngle(a.Degrees * b);
        }

        public static HourAngle operator /(HourAngle a, HourAngle b)
        {
            return new HourAngle(a.Degrees / b.Degrees);
        }

        public static HourAngle operator /(HourAngle a, double b)
        {
            return new HourAngle(a.Degrees / b);
        }

        public static implicit operator HourAngle(double val)
        {
            return new HourAngle(val);
        }

        public static implicit operator HourAngle(Angle val)
        {
            return new HourAngle(val);
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2:F2}", Hours, Minutes, Seconds);
        }
    }
}

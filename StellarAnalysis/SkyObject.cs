using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AForge.Imaging;
using GCLib;

namespace StellarAnalysis
{
    public class SkyObject
    {
        public string Name { get; set; }
        public SkyVector Position { get; set; }

        CatalogEntry entry;
        public CatalogEntry CatEntry
        {
            get
            {
                return entry;
            }
            set
            {
                entry = value;
                if (entry == null)
                {
                    Position = new SkyVector(new HourAngle(), new Angle());
                }
                else
                {
                    Position = entry.Position;
                    Name = entry.ToString();
                }
            }
        }

        public Blob ObjectBlob { get; private set; }

        public Point Location
        {
            get
            {
                int x = ObjectBlob.Rectangle.X + (ObjectBlob.Rectangle.Width / 2);
                int y = ObjectBlob.Rectangle.Y + (ObjectBlob.Rectangle.Height / 2);

                return new Point(x, y);
            }
        }

        public SkyObject(CatalogEntry entry, Blob blob)
        {
            CatEntry = entry;
            ObjectBlob = blob;
            Name = CatEntry.Name;
            Position = CatEntry.Position;
        }

        public SkyObject(Blob blob)
        {
            CatEntry = null;
            ObjectBlob = blob;
            Name = "";
            Position = new SkyVector(new HourAngle(), new Angle());
        }

        public SkyObject(string name, SkyVector position, Blob blob)
        {
            Name = name;
            Position = position;
            ObjectBlob = blob;
        }

        public SkyObject(SkyVector position, Blob blob)
        {
            Position = position;
            ObjectBlob = blob;
        }

        public override string ToString()
        {
            if ((Name == "") & (Position.DE.Fractional == 0.0f) & (Position.RA.Degrees.Fractional == 0.0f))
                return "Unidentified Anomaly";
            else if (Name == "")
                return string.Format("Unidentified Anomaly ({0})", Position.ToString());
            else if (CatEntry == null)
                return string.Format("{0} ({1})", Name, Position.ToString());
            else
                return CatEntry.ToString();
        }
    }
}

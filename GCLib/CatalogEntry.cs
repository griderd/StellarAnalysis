using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCLib
{
    public class CatalogEntry
    {
        /// <summary>
        /// Name of the object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Alternate name of the object.
        /// </summary>
        public string AltName { get; set; }

        /// <summary>
        /// The Smithsonian Astrophysical Observatory Star Catalog
        /// </summary>
        public string SAO { get; set; }

        /// <summary>
        /// The Grider Catalog.
        /// </summary>
        public string GC { get; set; }

        /// <summary>
        /// Position in the sky.
        /// </summary>
        public SkyVector Position { get; set; }

        public CatalogEntry(string name, string altName, string saoNum, string gcNum, SkyVector position)
        {
            Name = name;
            AltName = altName;
            SAO = saoNum;
            GC = gcNum;
            Position = position;
        }

        public bool IsNearPosition(SkyVector position, SkyVector error)
        {
            double ra = position.RA.Degrees.Fractional;
            double de = position.DE.Fractional;

            double localRa = Position.RA.Degrees.Fractional;
            double localDe = Position.DE.Fractional;
            
            double raError = error.RA.Degrees.Fractional;
            double deError = error.DE.Fractional;

            double raDiff = Math.Abs(ra - localRa);
            double deDiff = Math.Abs(de - localDe);

            bool result = (raDiff <= raError) & (deDiff <= deError);
            return result;
        }

        public override string ToString()
        {
            if (Name != "")
                return string.Format("{0} (GC {1})", Name, GC);
            else if (AltName != "")
                return string.Format("{0} (GC {1})", AltName, GC);
            else if (SAO != "")
                return string.Format("GC {0} (SAO {1})", GC, SAO);
            else
                return string.Format("GC {0}", GC);
        }
    }
}

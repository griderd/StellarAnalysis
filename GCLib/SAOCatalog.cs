using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GCLib
{
    public class SAOCatalog
    {
        string[] sao;
        double[] ra, de, mag;

        public SAOCatalog(string dataPath)
        {
            if (!File.Exists(dataPath))
                throw new FileNotFoundException();

            List<string> temp = new List<string>(File.ReadAllLines(dataPath));
            temp.RemoveAt(0);
            string[] lines = temp.ToArray();

            sao = new string[lines.Length];
            ra = new double[lines.Length];
            de = new double[lines.Length];
            mag = new double[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');

                sao[i] = parts[0];
                if (!double.TryParse(parts[1], out ra[i]))
                    throw new FormatException("RA on cannot be parsed on line " + (i + 1).ToString());
                if (!double.TryParse(parts[2], out de[i]))
                    throw new FormatException("RE on cannot be parsed on line " + (i + 1).ToString());
                if ((parts[4] != "") && (!double.TryParse(parts[4], out mag[i])))
                    throw new FormatException("Magnitude on cannot be parsed on line " + (i + 1).ToString());
            }
        }

        public bool Lookup(string saoNum, out SAOEntry entry)
        {
            for (int i = 0; i < sao.Length; i++)
            {
                if (sao[i] == saoNum)
                {
                    entry = new SAOEntry(sao[i], ra[i], de[i], mag[i]);
                    return true;
                }
            }
            entry = new SAOEntry();
            return false;
        }

        public bool GetStarAtPosition(double ra, double de, double raError, double deError, out SAOEntry entry)
        {
            for (int i = 0; i < this.ra.Length; i++)
            {
                if ((Math.Abs(ra - this.ra[i]) <= raError) && (Math.Abs(de - this.de[i]) <= deError))
                {
                    entry = new SAOEntry(sao[i], this.ra[i], this.de[i], mag[i]);
                    return true;
                }
            }
            entry = new SAOEntry(); 
            return false;
        }

        public bool GetStarAtPosition(HourAngle ra, Angle de, double raError, double deError, out SAOEntry entry)
        {
            return GetStarAtPosition(ra.Degrees, de.Degrees, raError, deError, out entry);
        }

        public bool GetStarAtPosition(SkyVector position, double raError, double deError, out SAOEntry entry)
        {
            return GetStarAtPosition(position.RA, position.DE, raError, deError, out entry);
        }
    }
}

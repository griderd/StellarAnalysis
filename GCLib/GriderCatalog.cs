using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GCLib
{
    public class GriderCatalog
    {
        Dictionary<string, CatalogEntry> entries;

        public CatalogEntry this[string index]
        {
            get
            {
                if (entries.ContainsKey(index))
                    return entries[index];
                else
                    return null;
            }
        }

        public GriderCatalog(string filePath)
        {
            entries = new Dictionary<string, CatalogEntry>();

            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string name, altName, sao, gc;
                double ra, de, mag;

                string[] parts = lines[i].Split(',');

                if (parts.Length < 7)
                    throw new FormatException();
                
                name = parts[0];
                altName = parts[1];
                sao = parts[2];
                gc = parts[3];
                if (gc == "")
                    throw new FormatException();

                if (!double.TryParse(parts[4], out ra))
                    throw new FormatException();
                if (!double.TryParse(parts[5], out de))
                    throw new FormatException();
                if (!double.TryParse(parts[6], out mag))
                    throw new FormatException();

                entries.Add(gc, new CatalogEntry(name, altName, sao, gc, new SkyVector(ra, de)));
            }
        }

        public bool Lookup(string gcNum, out CatalogEntry entry)
        {
            entry = null;
            if (entries.ContainsKey(gcNum))
                entry = entries[gcNum];
            return entry != null;
        }

        public bool GetStarByName(string name, out CatalogEntry entry)
        {
            CatalogEntry[] entries = this.entries.Values.ToArray();

            for (int i = 0; i < entries.Length; i++)
            {
                if ((entries[i].Name == name) | (entries[i].AltName == name))
                {
                    entry = entries[i];
                    return true;
                }
            }
            entry = null;
            return false;
        }

        public bool GetStarAtPosition(double ra, double de, double raError, double deError, out CatalogEntry entry)
        {
            CatalogEntry[] entries = this.entries.Values.ToArray();

            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i].IsNearPosition(new SkyVector(ra, de), new SkyVector(raError, deError)))
                {
                    entry = entries[i];
                    return true;
                }
            }
            entry = null;
            return false;
        }

        public bool GetStarAtPosition(HourAngle ra, Angle de, double raError, double deError, out CatalogEntry entry)
        {
            return GetStarAtPosition(ra.Degrees.Fractional, de.Fractional, raError, deError, out entry);
        }

        public bool GetStarAtPosition(SkyVector position, double raError, double deError, out CatalogEntry entry)
        {
            return GetStarAtPosition(position.RA, position.DE, raError, deError, out entry);
        }

        public void AddEntry(CatalogEntry entry)
        {
            if (entries.ContainsKey(entry.GC))
                throw new ArgumentException("Grider Catalog entry with that number already exists.");

            entries.Add(entry.GC, entry);
        }

        public void SaveCatalog(string path)
        {
            List<string> lines = new List<string>();

            lines.Add("Name,Alt Name,SAO,GC,RA Angle,DE Angle,Magnitude");

            CatalogEntry[] entries = this.entries.Values.ToArray();

            for (int i = 0; i < entries.Length; i++)
            {
                CatalogEntry e = entries[i];

                lines.Add(string.Format("{0},{1},{2},{3},{4:F8},{5:F8},{6:F2}",
                                        e.Name,
                                        e.AltName,
                                        e.SAO,
                                        e.GC,
                                        e.Position.RA.Degrees.Fractional,
                                        e.Position.DE.Fractional,
                                        0.0f));
            }

            File.WriteAllLines(path, lines.ToArray(), Encoding.UTF8);
        }
    }
}

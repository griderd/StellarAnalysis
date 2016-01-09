using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCLib
{
    public struct SAOEntry
    {
        public string SAO { get; private set; }
        public HourAngle RA { get; private set; }
        public Angle DE { get; private set; }
        public double VMAG { get; private set; }

        public SAOEntry(string sao, double ra, double de, double vmag)
            : this()
        {
            SAO = sao;
            RA = new HourAngle(ra);
            DE = new Angle(de);
            VMAG = vmag;
        }
    }
}

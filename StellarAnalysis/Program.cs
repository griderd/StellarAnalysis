using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GCLib;

namespace StellarAnalysis
{
    static class Program
    {
        public static GriderCatalog GC;
        public static SAOCatalog SAO;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GC = new GriderCatalog("Grider Catalog.csv");
            SAO = new SAOCatalog("SAO Catalog.csv");

            Application.Run(new frmMain());
        }
    }
}

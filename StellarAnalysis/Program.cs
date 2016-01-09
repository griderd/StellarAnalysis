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

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            GC = new GriderCatalog("Grider Catalog.csv");
            SAO = new SAOCatalog("SAO Catalog.csv");

            Application.Run(new frmMain());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(((Exception)e.ExceptionObject).Message, "Unhandled UI Exception");
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Unhandled Thread Exception");
        }
    }
}

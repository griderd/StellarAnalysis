using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GCLib;

namespace StellarAnalysis
{
    public partial class frmIdentity : Form
    {
        SkyObject entry;
        public SkyObject Entry
        {
            get
            {
                return entry;
            }
            set
            {
                entry = value;
                if (value == null)
                {
                    lblAltName.Text = "";
                    lblDE.Text = "";
                    lblGC.Text = "";
                    lblMagnitude.Text = "";
                    lblName.Text = "";
                    lblRA.Text = "";
                    lblSAO.Text = "";
                    gbCatalogEntry.Text = "Anomaly";
                }
                else
                {
                    if (entry.CatEntry != null)
                    {
                        lblAltName.Text = entry.CatEntry.AltName;
                        lblGC.Text = "GC " + entry.CatEntry.GC;
                        if (entry.CatEntry.SAO != "")
                            lblSAO.Text = "SAO " + entry.CatEntry.SAO;
                        else
                            lblSAO.Text = "";
                    }
                    
                    lblRA.Text = "RA: " + entry.Position.RA.ToString();
                    lblDE.Text = "DE: " + entry.Position.DE.ToString();
                    
                    
                    lblMagnitude.Text = "";
                    lblName.Text = entry.Name;
                    gbCatalogEntry.Text = entry.ToString();
                }
            }
        }

        public frmIdentity()
        {
            InitializeComponent();
        }

        private void frmIdentity_Load(object sender, EventArgs e)
        {

        }
    }
}

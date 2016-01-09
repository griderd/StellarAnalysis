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
    public partial class frmIdentify : Form
    {
        CatalogEntry entry;
        public CatalogEntry Entry
        {
            get
            {
                return entry;
            }
            private set
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
                    gbCatalogEntry.Text = "NO RESULT!";
                }
                else
                {
                    lblAltName.Text = entry.AltName;
                    lblRA.Text = "RA: " + entry.Position.RA.ToString();
                    lblDE.Text = "DE: " + entry.Position.DE.ToString();
                    lblGC.Text = "GC " + entry.GC;
                    lblSAO.Text = "SAO " + entry.SAO;
                    lblMagnitude.Text = "";
                    lblName.Text = entry.Name;
                    gbCatalogEntry.Text = entry.ToString();
                }
            }
        }


        public frmIdentify()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CatalogEntry entry;
            if ((txtName.Text != "") & (Program.GC.GetStarByName(txtName.Text, out entry)))
                Entry = entry;
            else if (txtGC.Text != "")
                Entry = Program.GC[txtGC.Text];
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void frmIdentify_Load(object sender, EventArgs e)
        {
            lblAltName.Text = "";
            lblDE.Text = "";
            lblGC.Text = "";
            lblMagnitude.Text = "";
            lblName.Text = "";
            lblRA.Text = "";
            lblSAO.Text = "";
            gbCatalogEntry.Text = "NO RESULT!";
        }

        private void lblRA_Click(object sender, EventArgs e)
        {

        }
    }
}

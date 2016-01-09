using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GCLib;
using AForge.Imaging;

namespace StellarAnalysis
{
    public partial class frmAddIdentity : Form
    {
        public SkyObject Obj { get; private set; }

        public frmAddIdentity()
        {
            InitializeComponent();
        }

        public frmAddIdentity(SkyObject obj)
        {
            InitializeComponent();
            Obj = obj;
        }

        private void frmAddIdentity_Load(object sender, EventArgs e)
        {
            lblRA.Text = "RA: " + Obj.Position.RA.ToString();
            lblDE.Text = "DE: " + Obj.Position.DE.ToString();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            int temp;
            SAOEntry temp2;

            if (txtName.Text == "")
            {
                MessageBox.Show("The Name field is required.");
                return;
            }

            Obj.Name = txtName.Text;

            if (chkAddToCatalog.Checked)
            {
                if (txtGC.Text == "")
                {
                    MessageBox.Show("The GC Number field is required.");
                    return;
                }
                if (txtGC.Text.Length != 3)
                {
                    MessageBox.Show("The GC Number must be 3 digits long.");
                    return;
                }
                if (!int.TryParse(txtGC.Text, out temp))
                {
                    MessageBox.Show("The GC Number field must contain only digits.");
                    return;
                }

                if ((txtSAO.Text != "") && (!Program.SAO.Lookup(txtSAO.Text, out temp2)))
                {
                    MessageBox.Show("The SAO field does not contain a valid SAO number.");
                    return;
                }

                CatalogEntry entry = new CatalogEntry(txtName.Text, txtAltName.Text, txtSAO.Text, txtGC.Text, Obj.Position);
                Obj.CatEntry = entry;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging;
using AForge.Imaging.Filters;
using GCLib;

namespace StellarAnalysis
{
    public partial class frmMain : Form
    {
        StarfieldImage image;

        frmIdentity identity;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            identity = new frmIdentity();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try { image.Dispose(); }
                catch { }
                image = new StarfieldImage(dlgOpenFile.FileName);

                lstObjects.Items.Clear();
                lstFilters.Items.Clear();

                imageToolStripMenuItem.Enabled = true;
                analysisToolStripMenuItem.Enabled = true;
                picImage.Image = image.DisplayImage;
            }
        }

        void UpdateDisplay()
        {
            UpdateImage();
            UpdateLists();
        }

        void UpdateImage()
        {
            if (image == null)
                return;

            image.UpdateDisplay();
            picImage.Image = image.DisplayImage;
        }

        void UpdateLists()
        {
            lstFilters.Items.Clear();
            lstObjects.Items.Clear();

            for (int i = 0; i < image.Filters.Length; i++)
            {
                lstFilters.Items.Add(image.Filters[i].GetType().Name);
            }
            for (int i = 0; i < image.Objects.Length; i++)
            {
                lstObjects.Items.Add(image.Objects[i].ToString());
            }
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image == null)
                return;

            image.AddInvertFilter();
            UpdateDisplay();
        }

        private void rMYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.AddGrayscaleRMY();
            UpdateDisplay();
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGrayscale dlg = new frmGrayscale(ref image.image.display);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                image.AddGrayscaleFilter(dlg.Cr, dlg.Cg, dlg.Cb);
                UpdateDisplay();
            }
        }

        private void bT709ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.AddGrayscaleBT709();
            UpdateDisplay();
        }

        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.AddGrayscaleY();
            UpdateDisplay();
        }

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((image.image.PixelFormat != System.Drawing.Imaging.PixelFormat.Format16bppGrayScale) &
                (image.image.PixelFormat != System.Drawing.Imaging.PixelFormat.Format8bppIndexed))
            {
                MessageBox.Show("The image must be grayscale to have a threshold filter.");
                return;
            }

            frmThreshold dlg = new frmThreshold(ref image.image.display);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                image.AddThresholdFilter(dlg.ThresholdValue);
                UpdateDisplay();
            }
        }

        private void oneClickSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int blobSize = (int)(((double)image.image.Width) * (20.0f / 5465.0f));

            image.ClearFilters();
            image.AddGrayscaleY();
            image.AddThresholdFilter(127);
            image.AddGrayscaleToRBGFilter();
            image.AddBlobsFilter(blobSize, blobSize, 500, 500, true);
            UpdateDisplay();
        }

        private void blobCounterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.CountBlobs();
            UpdateDisplay();
        }

        private void grayscaleToRGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.AddGrayscaleToRBGFilter();
            UpdateDisplay();
        }

        private void blobFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBlobsFilter dlg = new frmBlobsFilter(ref image.image.display);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                image.AddBlobsFilter(dlg.MinWidth, dlg.MinHeight, dlg.MaxWidth, dlg.MaxHeight, dlg.CoupledFiltering);
                UpdateDisplay();
            }
        }

        private void lstObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            image.SelectObject(lstObjects.SelectedIndex);
            UpdateImage();
        }

        private void autoIdentifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkyObject[] unidentified;

            if (image.AutoIdentify(out unidentified))
            {
                UpdateDisplay();
                for (int i = 0; i < unidentified.Length; i++)
                {
                    MessageBox.Show("Unidentified object located at: " + unidentified[i].Position.ToString());
                }
            }
            else
            {
                MessageBox.Show("At least two objects must be identified to automatically identify other objects.");
            }
        }

        private void lstObjects_DoubleClick(object sender, EventArgs e)
        {
            if (lstObjects.SelectedIndex < 0)
                return;

            int index = lstObjects.SelectedIndex;

            if ((image.Objects[lstObjects.SelectedIndex].Position.DE.Fractional == 0.0f) & 
                (image.Objects[lstObjects.SelectedIndex].Position.RA.Degrees.Fractional == 0.0f))
            {
                frmIdentify identify = new frmIdentify();
                if (identify.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    image.Objects[lstObjects.SelectedIndex].CatEntry = identify.Entry;
                    lstObjects.Items[lstObjects.SelectedIndex] = image.Objects[lstObjects.SelectedIndex];
                }
            }
            else if (image.Objects[lstObjects.SelectedIndex].Name == "")
            {
                frmAddIdentity identify = new frmAddIdentity(image.Objects[lstObjects.SelectedIndex]);
                if (identify.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    image.Objects[lstObjects.SelectedIndex] = identify.Obj;
                    lstObjects.Items[lstObjects.SelectedIndex] = image.Objects[lstObjects.SelectedIndex];
                }
            }
            else
            {
                identity.Show();
                identity.Entry = image.Objects[lstObjects.SelectedIndex];
            }

            UpdateLists();
            lstObjects.SelectedIndex = index;
        }

        private void autoRotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will automatically rotate the image so that polar north is at the top. However, current identifications will be lost. Continue?", "Stellar Analysis", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            if (!image.AutoRotate())
            {
                MessageBox.Show("At least two objects must be identified to rotate the image.");
                return;
            }

            UpdateDisplay();
        }
    }
}

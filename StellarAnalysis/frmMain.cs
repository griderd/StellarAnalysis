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
        List<IFilter> filters;
        List<SkyObject> objects;

        frmIdentity identity;

        ImageManager image, overlay;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            filters = new List<IFilter>();
            objects = new List<SkyObject>();

            identity = new frmIdentity();
        }

        void AddFilter(IFilter filter)
        {
            filters.Add(filter);
            UpdateDisplay();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filters.Clear();
                objects.Clear();
                lstObjects.Items.Clear();
                lstFilters.Items.Clear();

                image = new ImageManager(dlgOpenFile.FileName);

                imageToolStripMenuItem.Enabled = true;
                analysisToolStripMenuItem.Enabled = true;
                picImage.Image = image.DisplayImage;
            }
        }

        void UpdateDisplay()
        {
            if (image == null)
                return;

            lstFilters.Items.Clear();

            image.Unlock();

            UnmanagedImage temp = image.workingImage.Clone();
            for (int i = 0; i < filters.Count; i++)
            {
                temp = filters[i].Apply(image.workingImage);
                image.workingImage.Dispose();
                image.workingImage = temp.Clone();
                temp.Dispose();
                lstFilters.Items.Add(filters[i].GetType().Name);
            }

            picImage.Image = image.Lock();
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image == null)
                return;

            AddFilter(new Invert());
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void rMYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFilter(new Grayscale(Grayscale.CommonAlgorithms.RMY.RedCoefficient,
                                    Grayscale.CommonAlgorithms.RMY.GreenCoefficient,
                                    Grayscale.CommonAlgorithms.RMY.BlueCoefficient));
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGrayscale dlg = new frmGrayscale(ref image.display);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AddFilter(new Grayscale(dlg.Cr, dlg.Cg, dlg.Cb));
            }
        }

        private void bT709ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFilter(new Grayscale(Grayscale.CommonAlgorithms.BT709.RedCoefficient,
                                    Grayscale.CommonAlgorithms.BT709.GreenCoefficient,
                                    Grayscale.CommonAlgorithms.BT709.BlueCoefficient));
        }

        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFilter(new Grayscale(Grayscale.CommonAlgorithms.Y.RedCoefficient,
                                    Grayscale.CommonAlgorithms.Y.GreenCoefficient,
                                    Grayscale.CommonAlgorithms.Y.BlueCoefficient));
        }

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((image.PixelFormat != System.Drawing.Imaging.PixelFormat.Format16bppGrayScale) &
                (image.PixelFormat != System.Drawing.Imaging.PixelFormat.Format8bppIndexed))
            {
                MessageBox.Show("The image must be grayscale to have a threshold filter.");
                return;
            }

            frmThreshold dlg = new frmThreshold(ref image.display);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AddFilter(new Threshold(dlg.ThresholdValue));
            }
        }

        private void oneClickSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int blobSize = (int)(((double)image.Width) * (20.0f / 5465.0f));

            filters.Clear();
            AddFilter(new Grayscale(Grayscale.CommonAlgorithms.Y.RedCoefficient,
                                    Grayscale.CommonAlgorithms.Y.GreenCoefficient,
                                    Grayscale.CommonAlgorithms.Y.BlueCoefficient));
            AddFilter(new Threshold(127));
            AddFilter(new GrayscaleToRGB());
            AddFilter(new BlobsFiltering(blobSize, blobSize, 500, 500, true));
        }

        private void blobCounterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBlobCounter();
        }

        private void AddBlobCounter()
        {
            BlobCounter blobs = new BlobCounter();
            blobs.FilterBlobs = true;

            // Blob size for automatic should be set approimately 0.36% of the width of the image.
            blobs.MinHeight = blobs.MinWidth = (int)(((double)image.Width) * (20.0f / 5465.0f));

            image.Unlock();
            blobs.ProcessImage(image.DisplayImage);

            overlay = new ImageManager(image.Width, image.Height, Color.Black, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            overlay.Unlock();

            Blob[] objs = blobs.GetObjects(image.DisplayImage, false);
            image.Lock();

            for (int i = 0; i < objs.Length; i++)
            {
                SkyObject o = new SkyObject(objs[i]);
                objects.Add(o);
                lstObjects.Items.Add(o);
            }

            BuildOverlay();
        }

        /// <summary>
        /// Builds the selection overlay. The calling function should ensure that there 
        /// is no Add layer already in place containing this overlay.
        /// </summary>
        private void BuildOverlay()
        {
            if (overlay != null)
                overlay.Dispose();

            overlay = new ImageManager(image.Width, image.Height, Color.Black, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            overlay.Unlock();

            int thickness = (int)(((double)image.Width) * (10.0f / 5465.0f));

            for (int i = 0; i < objects.Count; i++)
            {
                Rectangle r = objects[i].ObjectBlob.Rectangle;
                Drawing.Rectangle(overlay.workingImage, r, Color.Red);
                for (int j = 1; j < thickness; j++)
                {
                    r = new Rectangle(r.X - 1, r.Y - 1, r.Width + 2, r.Height + 2);
                    Drawing.Rectangle(overlay.workingImage, r, Color.Red);
                }
            }

            AddFilter(new Add(overlay.Lock()));
            overlay.CopyDisplayToBacking();
        }

        private void grayscaleToRGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFilter(new GrayscaleToRGB());
        }

        private void blobFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBlobsFilter dlg = new frmBlobsFilter(ref image.display);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AddFilter(new BlobsFiltering(dlg.MinWidth, dlg.MinHeight, dlg.MaxWidth, dlg.MaxHeight, dlg.CoupledFiltering));
            }
        }

        private void lstObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstObjects.SelectedIndex < 0)
                return;
            if (overlay == null)
                return;

            int thickness = (int)(((double)image.Width) * (10.0f / 5465.0f));

            overlay.Unlock();

            Rectangle r = objects[lstObjects.SelectedIndex].ObjectBlob.Rectangle;

            for (int j = 1; j < thickness; j++)
            {
                r = new Rectangle(r.X - 1, r.Y - 1, r.Width + 2, r.Height + 2);
                Drawing.Rectangle(overlay.workingImage, r, Color.Blue);
            }
            overlay.Lock();

            UpdateSelectOverlay();
        }

        void UpdateSelectOverlay()
        {
            for (int i = 0; i < filters.Count; i++)
            {
                if (filters[i].GetType() == typeof(Add))
                {
                    filters.RemoveAt(i);
                    AddFilter(new Add(overlay.DisplayImage));
                }
            }

        }

        private void autoIdentifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkyObject a, b;
            a = b = null;

            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].CatEntry != null)
                {
                    if (a == null)
                        a = objects[i];
                    else if (b == null)
                        b = objects[i];
                    else
                        break;
                }
            }

            if (b == null)
            {
                MessageBox.Show("At least two objects must be identified to automatically identify the others.");
                return;
            }

            PointVector pA = new PointVector(a.Location);
            PointVector pB = new PointVector(b.Location);
            PointVector pDiff = pA - pB;

            SkyVector sA = a.CatEntry.Position;
            SkyVector sB = b.CatEntry.Position;
            SkyVector sDiff = sA - sB;

            double xScaleLength = sDiff.RA.Degrees.Fractional / pDiff.X;
            double yScaleLength = sDiff.DE.Fractional / pDiff.Y;

            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].CatEntry != null)
                    continue;

                PointVector pObj = new PointVector(objects[i].Location);
                PointVector pObjDiff = pA - pObj;

                double xScaleDiff = xScaleLength * pObjDiff.X;
                double yScaleDiff = yScaleLength * pObjDiff.Y;
                SkyVector scaleDiff = new SkyVector(new HourAngle(xScaleDiff), yScaleDiff);

                SkyVector objPos = sA - scaleDiff;

                // Try to find star in catalog
                CatalogEntry entry;
                if (Program.GC.GetStarAtPosition(objPos, 0.025f, 0.025f, out entry))
                {
                    objects[i].CatEntry = entry;
                    lstObjects.Items[i] = objects[i];
                }
                else
                {
                    MessageBox.Show("Unidentified object found at: " + objPos.ToString());
                    objects[i].Position = objPos;
                }


            }
        }

        private void lstObjects_DoubleClick(object sender, EventArgs e)
        {
            if (lstObjects.SelectedIndex < 0)
                return;

            if ((objects[lstObjects.SelectedIndex].Position.DE.Fractional == 0.0f) & 
                (objects[lstObjects.SelectedIndex].Position.RA.Degrees.Fractional == 0.0f))
            {
                frmIdentify identify = new frmIdentify();
                if (identify.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    objects[lstObjects.SelectedIndex].CatEntry = identify.Entry;
                    lstObjects.Items[lstObjects.SelectedIndex] = objects[lstObjects.SelectedIndex];
                }
            }
            else if (objects[lstObjects.SelectedIndex].Name == "")
            {
                frmAddIdentity identify = new frmAddIdentity(objects[lstObjects.SelectedIndex]);
                if (identify.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    objects[lstObjects.SelectedIndex] = identify.Obj;
                    lstObjects.Items[lstObjects.SelectedIndex] = objects[lstObjects.SelectedIndex];
                }
            }
            else
            {
                identity.Show();
                identity.Entry = objects[lstObjects.SelectedIndex];
            }
        }

        private void autoRotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will automatically rotate the image so that polar north is at the top. However, star assignments will be lost. Continue?", "Stellar Analysis", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;


            SkyObject a, b;
            a = b = null;

            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].CatEntry != null)
                {
                    if (a == null)
                        a = objects[i];
                    else if (b == null)
                        b = objects[i];
                    else
                        break;
                }
            }

            if (b == null)
            {
                MessageBox.Show("At least two objects must be identified to automatically identify the others.");
                return;
            }

            PointVector pA = new PointVector(a.Location);
            PointVector pB = new PointVector(b.Location);
            PointVector pDiff = pA - pB;

            SkyVector sA = a.CatEntry.Position;
            SkyVector sB = b.CatEntry.Position;
            SkyVector sDiff = sA - sB;

            double pointAngle = RadiansToDegrees(Math.Atan2((double)pDiff.Y, (double)pDiff.X));
            double posAngle = RadiansToDegrees(Math.Atan(sDiff.DE.Fractional / sDiff.RA.Degrees.Fractional));

            double rotation = pointAngle - posAngle;

            for (int i = 0; i < filters.Count; i++)
            {
                if (filters[i] is Add)
                {
                    filters.RemoveAt(i);
                }
            }

            // We're using a bicubic rotation instead of a bilinear rotation
            // Bicubic is more precise, but it does take a bit longer and is
            // more memory intensive. However, Bilinear has a habit of dropping
            // enough detail for the blob counter to use.
            AddFilter(new RotateBicubic(rotation, true));
            objects.Clear();
            lstObjects.Items.Clear();

            AddBlobCounter();
        }

        double RadiansToDegrees(double radians)
        {
            double result = (180.0f / Math.PI) * radians;
            return result;
        }

        
    }
}

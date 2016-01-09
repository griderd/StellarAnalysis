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

namespace StellarAnalysis
{
    public partial class frmCustomFilter : Form
    {
        protected ImageManager image;

        protected IFilter filter;

        public frmCustomFilter()
        {
            InitializeComponent();
        }

        public frmCustomFilter(ref Bitmap img)
        {
            InitializeComponent();
            image = new ImageManager(img);
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void frmCustomFilter_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                UpdateFilter();
                UpdateDisplay();
            }
        }

        protected virtual void UpdateFilter()
        {
            throw new NotImplementedException();
        }

        protected void UpdateDisplay()
        {
            UpdateFilter();

            image.Unlock();
            UnmanagedImage temp = filter.Apply(image.workingImage);
            image.workingImage = temp.Clone();
            temp.Dispose();
            picPreview.Image = image.Lock();
        }
    }
}

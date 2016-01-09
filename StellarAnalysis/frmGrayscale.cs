using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace StellarAnalysis
{
    public partial class frmGrayscale : StellarAnalysis.frmCustomFilter
    {
        public double Cr { get; private set; }
        public double Cg { get; private set; }
        public double Cb { get; private set; }

        public frmGrayscale(ref Bitmap img)
            : base(ref img)
        {
            InitializeComponent();
            Cr = Cg = Cb = 0.5f;
        }

        protected override void UpdateFilter()
        {
            filter = new Grayscale(Cr, Cg, Cb);
        }

        private void tbCr_Scroll(object sender, EventArgs e)
        {
            Cr = ((double)tbCr.Value) / 100.0f;
            lblCr.Text = Cr.ToString();
            UpdateDisplay();
        }

        private void tbCg_Scroll(object sender, EventArgs e)
        {
            Cg = ((double)tbCg.Value) / 100.0f;
            lblCg.Text = Cg.ToString();
            UpdateDisplay();
        }

        private void tbCb_Scroll(object sender, EventArgs e)
        {
            Cb = ((double)tbCb.Value) / 100.0f;
            lblCb.Text = Cb.ToString();
            UpdateDisplay();
        }

        private void frmGrayscale_Load(object sender, EventArgs e)
        {
            Cr = Cg = Cb = 0.5f;
            UpdateDisplay();
        }
    }
}

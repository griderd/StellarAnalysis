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
    public partial class frmBlobsFilter : StellarAnalysis.frmCustomFilter
    {
        public int MinWidth { get; private set; }
        public int MinHeight { get; private set; }
        public int MaxWidth { get; private set; }
        public int MaxHeight { get; private set; }
        public bool CoupledFiltering { get; private set; }

        public frmBlobsFilter(ref Bitmap img)
            : base(ref img)
        {
            InitializeComponent();
        }

        protected override void UpdateFilter()
        {
            filter = new BlobsFiltering(MinWidth, MinHeight, MaxWidth, MaxHeight, CoupledFiltering);
        }

        private void tbMinWidth_Scroll(object sender, EventArgs e)
        {
            MinWidth = tbMinWidth.Value;
            lblMinWidth.Text = MinWidth.ToString();
            btnUpdate.Enabled = true;
        }

        private void chkCoupledFiltering_CheckedChanged(object sender, EventArgs e)
        {
            CoupledFiltering = chkCoupledFiltering.Checked;
            UpdateDisplay();
        }

        private void tbMinHeight_Scroll(object sender, EventArgs e)
        {
            MinHeight = tbMinHeight.Value;
            lblMinHeight.Text = MinHeight.ToString();
            btnUpdate.Enabled = true;
        }

        private void tbMaxWidth_Scroll(object sender, EventArgs e)
        {
            MaxWidth = tbMaxWidth.Value;
            lblMaxWidth.Text = MaxWidth.ToString();
            btnUpdate.Enabled = true;
        }

        private void tbMaxHeight_Scroll(object sender, EventArgs e)
        {
            MaxHeight = tbMaxHeight.Value;
            lblMaxHeight.Text = MaxHeight.ToString();
            btnUpdate.Enabled = true;
        }

        private void frmBlobsFilter_Load(object sender, EventArgs e)
        {
            MinWidth = MinHeight = tbMinHeight.Value = tbMinWidth.Value = 20;
            MaxWidth = MaxHeight = tbMaxHeight.Value = tbMaxWidth.Value = 500;

            lblMinWidth.Text = MinWidth.ToString();
            lblMaxHeight.Text = MaxHeight.ToString();
            lblMinHeight.Text = MinHeight.ToString();
            lblMaxWidth.Text = MaxWidth.ToString();

            UpdateDisplay();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateDisplay();
            btnUpdate.Enabled = false;
        }
    }
}

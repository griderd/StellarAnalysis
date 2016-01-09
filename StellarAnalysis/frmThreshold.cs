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
    public partial class frmThreshold : StellarAnalysis.frmCustomFilter
    {
        public int ThresholdValue { get; private set; }

        public frmThreshold(ref Bitmap img)
            : base(ref img)
        {
            InitializeComponent();
            ThresholdValue = 127;
        }

        private void lblValue_Click(object sender, EventArgs e)
        {

        }

        private void tbValue_Scroll(object sender, EventArgs e)
        {
            lblValue.Text = tbValue.Value.ToString();
            ThresholdValue = tbValue.Value;
            UpdateDisplay();
        }

        protected override void UpdateFilter()
        {
            filter = new Threshold(ThresholdValue);
        }

        private void frmThreshold_Load(object sender, EventArgs e)
        {
            ThresholdValue = 127;
            UpdateDisplay();
        }
    }
}

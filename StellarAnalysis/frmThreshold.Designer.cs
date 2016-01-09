namespace StellarAnalysis
{
    partial class frmThreshold
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblValue = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbValue)).BeginInit();
            this.SuspendLayout();
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(110, 44);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(25, 13);
            this.lblValue.TabIndex = 20;
            this.lblValue.Text = "127";
            this.lblValue.Click += new System.EventHandler(this.lblValue_Click);
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(47, 12);
            this.tbValue.Maximum = 255;
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(149, 45);
            this.tbValue.TabIndex = 19;
            this.tbValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbValue.Value = 127;
            this.tbValue.Scroll += new System.EventHandler(this.tbValue_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Value";
            // 
            // frmThreshold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(572, 314);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.label1);
            this.Name = "frmThreshold";
            this.Text = "Threshold";
            this.Load += new System.EventHandler(this.frmThreshold_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbValue, 0);
            this.Controls.SetChildIndex(this.lblValue, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tbValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TrackBar tbValue;
        private System.Windows.Forms.Label label1;
    }
}

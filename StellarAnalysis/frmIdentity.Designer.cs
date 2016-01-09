namespace StellarAnalysis
{
    partial class frmIdentity
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
            this.gbCatalogEntry = new System.Windows.Forms.GroupBox();
            this.lblMagnitude = new System.Windows.Forms.Label();
            this.lblDE = new System.Windows.Forms.Label();
            this.lblRA = new System.Windows.Forms.Label();
            this.lblSAO = new System.Windows.Forms.Label();
            this.lblGC = new System.Windows.Forms.Label();
            this.lblAltName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gbCatalogEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCatalogEntry
            // 
            this.gbCatalogEntry.Controls.Add(this.lblMagnitude);
            this.gbCatalogEntry.Controls.Add(this.lblDE);
            this.gbCatalogEntry.Controls.Add(this.lblRA);
            this.gbCatalogEntry.Controls.Add(this.lblSAO);
            this.gbCatalogEntry.Controls.Add(this.lblGC);
            this.gbCatalogEntry.Controls.Add(this.lblAltName);
            this.gbCatalogEntry.Controls.Add(this.lblName);
            this.gbCatalogEntry.Location = new System.Drawing.Point(12, 12);
            this.gbCatalogEntry.Name = "gbCatalogEntry";
            this.gbCatalogEntry.Size = new System.Drawing.Size(182, 160);
            this.gbCatalogEntry.TabIndex = 6;
            this.gbCatalogEntry.TabStop = false;
            this.gbCatalogEntry.Text = "groupBox1";
            // 
            // lblMagnitude
            // 
            this.lblMagnitude.AutoSize = true;
            this.lblMagnitude.Location = new System.Drawing.Point(9, 132);
            this.lblMagnitude.Name = "lblMagnitude";
            this.lblMagnitude.Size = new System.Drawing.Size(57, 13);
            this.lblMagnitude.TabIndex = 6;
            this.lblMagnitude.Text = "Magnitude";
            // 
            // lblDE
            // 
            this.lblDE.AutoSize = true;
            this.lblDE.Location = new System.Drawing.Point(9, 107);
            this.lblDE.Name = "lblDE";
            this.lblDE.Size = new System.Drawing.Size(22, 13);
            this.lblDE.TabIndex = 5;
            this.lblDE.Text = "DE";
            // 
            // lblRA
            // 
            this.lblRA.AutoSize = true;
            this.lblRA.Location = new System.Drawing.Point(9, 94);
            this.lblRA.Name = "lblRA";
            this.lblRA.Size = new System.Drawing.Size(22, 13);
            this.lblRA.TabIndex = 4;
            this.lblRA.Text = "RA";
            // 
            // lblSAO
            // 
            this.lblSAO.AutoSize = true;
            this.lblSAO.Location = new System.Drawing.Point(9, 71);
            this.lblSAO.Name = "lblSAO";
            this.lblSAO.Size = new System.Drawing.Size(29, 13);
            this.lblSAO.TabIndex = 3;
            this.lblSAO.Text = "SAO";
            // 
            // lblGC
            // 
            this.lblGC.AutoSize = true;
            this.lblGC.Location = new System.Drawing.Point(9, 58);
            this.lblGC.Name = "lblGC";
            this.lblGC.Size = new System.Drawing.Size(22, 13);
            this.lblGC.TabIndex = 2;
            this.lblGC.Text = "GC";
            // 
            // lblAltName
            // 
            this.lblAltName.AutoSize = true;
            this.lblAltName.Location = new System.Drawing.Point(9, 34);
            this.lblAltName.Name = "lblAltName";
            this.lblAltName.Size = new System.Drawing.Size(83, 13);
            this.lblAltName.TabIndex = 1;
            this.lblAltName.Text = "Alternate Name:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // frmIdentity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 189);
            this.Controls.Add(this.gbCatalogEntry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIdentity";
            this.Text = "Identity";
            this.Load += new System.EventHandler(this.frmIdentity_Load);
            this.gbCatalogEntry.ResumeLayout(false);
            this.gbCatalogEntry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCatalogEntry;
        private System.Windows.Forms.Label lblMagnitude;
        private System.Windows.Forms.Label lblDE;
        private System.Windows.Forms.Label lblRA;
        private System.Windows.Forms.Label lblSAO;
        private System.Windows.Forms.Label lblGC;
        private System.Windows.Forms.Label lblAltName;
        private System.Windows.Forms.Label lblName;
    }
}
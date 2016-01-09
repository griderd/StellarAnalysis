namespace StellarAnalysis
{
    partial class frmIdentify
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGC = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbCatalogEntry = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAltName = new System.Windows.Forms.Label();
            this.lblGC = new System.Windows.Forms.Label();
            this.lblSAO = new System.Windows.Forms.Label();
            this.lblRA = new System.Windows.Forms.Label();
            this.lblDE = new System.Windows.Forms.Label();
            this.lblMagnitude = new System.Windows.Forms.Label();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbCatalogEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(56, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(137, 20);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Grider Catalog Number:";
            // 
            // txtGC
            // 
            this.txtGC.Location = new System.Drawing.Point(135, 32);
            this.txtGC.Name = "txtGC";
            this.txtGC.Size = new System.Drawing.Size(58, 20);
            this.txtGC.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(103, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 30);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.gbCatalogEntry.Location = new System.Drawing.Point(12, 97);
            this.gbCatalogEntry.Name = "gbCatalogEntry";
            this.gbCatalogEntry.Size = new System.Drawing.Size(182, 160);
            this.gbCatalogEntry.TabIndex = 5;
            this.gbCatalogEntry.TabStop = false;
            this.gbCatalogEntry.Text = "groupBox1";
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
            // lblAltName
            // 
            this.lblAltName.AutoSize = true;
            this.lblAltName.Location = new System.Drawing.Point(9, 34);
            this.lblAltName.Name = "lblAltName";
            this.lblAltName.Size = new System.Drawing.Size(83, 13);
            this.lblAltName.TabIndex = 1;
            this.lblAltName.Text = "Alternate Name:";
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
            // lblSAO
            // 
            this.lblSAO.AutoSize = true;
            this.lblSAO.Location = new System.Drawing.Point(9, 71);
            this.lblSAO.Name = "lblSAO";
            this.lblSAO.Size = new System.Drawing.Size(29, 13);
            this.lblSAO.TabIndex = 3;
            this.lblSAO.Text = "SAO";
            // 
            // lblRA
            // 
            this.lblRA.AutoSize = true;
            this.lblRA.Location = new System.Drawing.Point(9, 94);
            this.lblRA.Name = "lblRA";
            this.lblRA.Size = new System.Drawing.Size(22, 13);
            this.lblRA.TabIndex = 4;
            this.lblRA.Text = "RA";
            this.lblRA.Click += new System.EventHandler(this.lblRA_Click);
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
            // lblMagnitude
            // 
            this.lblMagnitude.AutoSize = true;
            this.lblMagnitude.Location = new System.Drawing.Point(9, 132);
            this.lblMagnitude.Name = "lblMagnitude";
            this.lblMagnitude.Size = new System.Drawing.Size(57, 13);
            this.lblMagnitude.TabIndex = 6;
            this.lblMagnitude.Text = "Magnitude";
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(12, 263);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(90, 32);
            this.btnAssign.TabIndex = 6;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(104, 263);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmIdentify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 307);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.gbCatalogEntry);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtGC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmIdentify";
            this.Text = "Identify";
            this.Load += new System.EventHandler(this.frmIdentify_Load);
            this.gbCatalogEntry.ResumeLayout(false);
            this.gbCatalogEntry.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGC;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbCatalogEntry;
        private System.Windows.Forms.Label lblMagnitude;
        private System.Windows.Forms.Label lblDE;
        private System.Windows.Forms.Label lblRA;
        private System.Windows.Forms.Label lblSAO;
        private System.Windows.Forms.Label lblGC;
        private System.Windows.Forms.Label lblAltName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnCancel;
    }
}
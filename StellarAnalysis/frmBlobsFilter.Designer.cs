namespace StellarAnalysis
{
    partial class frmBlobsFilter
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
            this.lblMinWidth = new System.Windows.Forms.Label();
            this.tbMinWidth = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMinHeight = new System.Windows.Forms.Label();
            this.tbMinHeight = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMaxWidth = new System.Windows.Forms.Label();
            this.tbMaxWidth = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMaxHeight = new System.Windows.Forms.Label();
            this.tbMaxHeight = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.chkCoupledFiltering = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(274, 8);
            this.picPreview.Size = new System.Drawing.Size(746, 486);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(96, 464);
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(10, 464);
            // 
            // lblMinWidth
            // 
            this.lblMinWidth.AutoSize = true;
            this.lblMinWidth.Location = new System.Drawing.Point(151, 40);
            this.lblMinWidth.Name = "lblMinWidth";
            this.lblMinWidth.Size = new System.Drawing.Size(25, 13);
            this.lblMinWidth.TabIndex = 23;
            this.lblMinWidth.Text = "127";
            // 
            // tbMinWidth
            // 
            this.tbMinWidth.Location = new System.Drawing.Point(68, 8);
            this.tbMinWidth.Maximum = 500;
            this.tbMinWidth.Name = "tbMinWidth";
            this.tbMinWidth.Size = new System.Drawing.Size(194, 45);
            this.tbMinWidth.TabIndex = 22;
            this.tbMinWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbMinWidth.Value = 20;
            this.tbMinWidth.Scroll += new System.EventHandler(this.tbMinWidth_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Min Width";
            // 
            // lblMinHeight
            // 
            this.lblMinHeight.AutoSize = true;
            this.lblMinHeight.Location = new System.Drawing.Point(151, 91);
            this.lblMinHeight.Name = "lblMinHeight";
            this.lblMinHeight.Size = new System.Drawing.Size(25, 13);
            this.lblMinHeight.TabIndex = 26;
            this.lblMinHeight.Text = "127";
            // 
            // tbMinHeight
            // 
            this.tbMinHeight.Location = new System.Drawing.Point(68, 59);
            this.tbMinHeight.Maximum = 500;
            this.tbMinHeight.Name = "tbMinHeight";
            this.tbMinHeight.Size = new System.Drawing.Size(194, 45);
            this.tbMinHeight.TabIndex = 25;
            this.tbMinHeight.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbMinHeight.Value = 20;
            this.tbMinHeight.Scroll += new System.EventHandler(this.tbMinHeight_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Min Height";
            // 
            // lblMaxWidth
            // 
            this.lblMaxWidth.AutoSize = true;
            this.lblMaxWidth.Location = new System.Drawing.Point(151, 142);
            this.lblMaxWidth.Name = "lblMaxWidth";
            this.lblMaxWidth.Size = new System.Drawing.Size(25, 13);
            this.lblMaxWidth.TabIndex = 29;
            this.lblMaxWidth.Text = "127";
            // 
            // tbMaxWidth
            // 
            this.tbMaxWidth.Location = new System.Drawing.Point(68, 110);
            this.tbMaxWidth.Maximum = 500;
            this.tbMaxWidth.Name = "tbMaxWidth";
            this.tbMaxWidth.Size = new System.Drawing.Size(194, 45);
            this.tbMaxWidth.TabIndex = 28;
            this.tbMaxWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbMaxWidth.Scroll += new System.EventHandler(this.tbMaxWidth_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Max Width";
            // 
            // lblMaxHeight
            // 
            this.lblMaxHeight.AutoSize = true;
            this.lblMaxHeight.Location = new System.Drawing.Point(151, 193);
            this.lblMaxHeight.Name = "lblMaxHeight";
            this.lblMaxHeight.Size = new System.Drawing.Size(25, 13);
            this.lblMaxHeight.TabIndex = 32;
            this.lblMaxHeight.Text = "127";
            // 
            // tbMaxHeight
            // 
            this.tbMaxHeight.Location = new System.Drawing.Point(68, 161);
            this.tbMaxHeight.Maximum = 500;
            this.tbMaxHeight.Name = "tbMaxHeight";
            this.tbMaxHeight.Size = new System.Drawing.Size(194, 45);
            this.tbMaxHeight.TabIndex = 31;
            this.tbMaxHeight.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbMaxHeight.Scroll += new System.EventHandler(this.tbMaxHeight_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Max Height";
            // 
            // chkCoupledFiltering
            // 
            this.chkCoupledFiltering.AutoSize = true;
            this.chkCoupledFiltering.Checked = true;
            this.chkCoupledFiltering.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCoupledFiltering.Location = new System.Drawing.Point(12, 226);
            this.chkCoupledFiltering.Name = "chkCoupledFiltering";
            this.chkCoupledFiltering.Size = new System.Drawing.Size(104, 17);
            this.chkCoupledFiltering.TabIndex = 33;
            this.chkCoupledFiltering.Text = "Coupled Filtering";
            this.chkCoupledFiltering.UseVisualStyleBackColor = true;
            this.chkCoupledFiltering.CheckedChanged += new System.EventHandler(this.chkCoupledFiltering_CheckedChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(182, 226);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 44);
            this.btnUpdate.TabIndex = 34;
            this.btnUpdate.Text = "Update Preview";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmBlobsFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1032, 506);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.chkCoupledFiltering);
            this.Controls.Add(this.lblMaxHeight);
            this.Controls.Add(this.tbMaxHeight);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblMaxWidth);
            this.Controls.Add(this.tbMaxWidth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMinHeight);
            this.Controls.Add(this.tbMinHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMinWidth);
            this.Controls.Add(this.tbMinWidth);
            this.Controls.Add(this.label1);
            this.Name = "frmBlobsFilter";
            this.Text = "Blobs Filter";
            this.Load += new System.EventHandler(this.frmBlobsFilter_Load);
            this.Controls.SetChildIndex(this.btnOkay, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.picPreview, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbMinWidth, 0);
            this.Controls.SetChildIndex(this.lblMinWidth, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbMinHeight, 0);
            this.Controls.SetChildIndex(this.lblMinHeight, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.tbMaxWidth, 0);
            this.Controls.SetChildIndex(this.lblMaxWidth, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.tbMaxHeight, 0);
            this.Controls.SetChildIndex(this.lblMaxHeight, 0);
            this.Controls.SetChildIndex(this.chkCoupledFiltering, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMinWidth;
        private System.Windows.Forms.TrackBar tbMinWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMinHeight;
        private System.Windows.Forms.TrackBar tbMinHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMaxWidth;
        private System.Windows.Forms.TrackBar tbMaxWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMaxHeight;
        private System.Windows.Forms.TrackBar tbMaxHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkCoupledFiltering;
        private System.Windows.Forms.Button btnUpdate;
    }
}

namespace StellarAnalysis
{
    partial class frmGrayscale
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
            this.lblCb = new System.Windows.Forms.Label();
            this.tbCb = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCg = new System.Windows.Forms.Label();
            this.tbCg = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCr = new System.Windows.Forms.Label();
            this.tbCr = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbCb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCr)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCb
            // 
            this.lblCb.AutoSize = true;
            this.lblCb.Location = new System.Drawing.Point(100, 146);
            this.lblCb.Name = "lblCb";
            this.lblCb.Size = new System.Drawing.Size(28, 13);
            this.lblCb.TabIndex = 23;
            this.lblCb.Text = "0.50";
            // 
            // tbCb
            // 
            this.tbCb.Location = new System.Drawing.Point(33, 114);
            this.tbCb.Maximum = 100;
            this.tbCb.Name = "tbCb";
            this.tbCb.Size = new System.Drawing.Size(163, 45);
            this.tbCb.TabIndex = 22;
            this.tbCb.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbCb.Value = 50;
            this.tbCb.Scroll += new System.EventHandler(this.tbCb_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Cb";
            // 
            // lblCg
            // 
            this.lblCg.AutoSize = true;
            this.lblCg.Location = new System.Drawing.Point(100, 95);
            this.lblCg.Name = "lblCg";
            this.lblCg.Size = new System.Drawing.Size(28, 13);
            this.lblCg.TabIndex = 20;
            this.lblCg.Text = "0.50";
            // 
            // tbCg
            // 
            this.tbCg.Location = new System.Drawing.Point(33, 63);
            this.tbCg.Maximum = 100;
            this.tbCg.Name = "tbCg";
            this.tbCg.Size = new System.Drawing.Size(163, 45);
            this.tbCg.TabIndex = 19;
            this.tbCg.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbCg.Value = 50;
            this.tbCg.Scroll += new System.EventHandler(this.tbCg_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Cg";
            // 
            // lblCr
            // 
            this.lblCr.AutoSize = true;
            this.lblCr.Location = new System.Drawing.Point(100, 44);
            this.lblCr.Name = "lblCr";
            this.lblCr.Size = new System.Drawing.Size(28, 13);
            this.lblCr.TabIndex = 17;
            this.lblCr.Text = "0.50";
            // 
            // tbCr
            // 
            this.tbCr.Location = new System.Drawing.Point(33, 12);
            this.tbCr.Maximum = 100;
            this.tbCr.Name = "tbCr";
            this.tbCr.Size = new System.Drawing.Size(163, 45);
            this.tbCr.TabIndex = 16;
            this.tbCr.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbCr.Value = 50;
            this.tbCr.Scroll += new System.EventHandler(this.tbCr_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Cr";
            // 
            // frmGrayscale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(568, 316);
            this.Controls.Add(this.lblCb);
            this.Controls.Add(this.tbCb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCg);
            this.Controls.Add(this.tbCg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCr);
            this.Controls.Add(this.tbCr);
            this.Controls.Add(this.label1);
            this.Name = "frmGrayscale";
            this.Text = "Grayscale";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbCr, 0);
            this.Controls.SetChildIndex(this.lblCr, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbCg, 0);
            this.Controls.SetChildIndex(this.lblCg, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.tbCb, 0);
            this.Controls.SetChildIndex(this.lblCb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tbCb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCb;
        private System.Windows.Forms.TrackBar tbCb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCg;
        private System.Windows.Forms.TrackBar tbCg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCr;
        private System.Windows.Forms.TrackBar tbCr;
        private System.Windows.Forms.Label label1;
    }
}

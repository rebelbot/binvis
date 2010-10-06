namespace binviz_0._1 {
    partial class FrmRGBPlot {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.scrFocus = new System.Windows.Forms.HScrollBar();
            this.lblWidth = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSynch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // scrFocus
            // 
            this.scrFocus.Location = new System.Drawing.Point(0, 483);
            this.scrFocus.Name = "scrFocus";
            this.scrFocus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scrFocus.Size = new System.Drawing.Size(640, 24);
            this.scrFocus.TabIndex = 2;
            this.scrFocus.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrFocus_Scroll);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.BackColor = System.Drawing.Color.Black;
            this.lblWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblWidth.Location = new System.Drawing.Point(-4, 456);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(20, 24);
            this.lblWidth.TabIndex = 3;
            this.lblWidth.Text = "0";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(551, 525);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(39, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "flip";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnSynch
            // 
            this.btnSynch.Location = new System.Drawing.Point(330, 521);
            this.btnSynch.Name = "btnSynch";
            this.btnSynch.Size = new System.Drawing.Size(183, 23);
            this.btnSynch.TabIndex = 8;
            this.btnSynch.Text = "synch playback to this window";
            this.btnSynch.UseVisualStyleBackColor = true;
            this.btnSynch.Click += new System.EventHandler(this.btnSynch_Click);
            // 
            // FrmRGBPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 554);
            this.Controls.Add(this.btnSynch);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.scrFocus);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmRGBPlot";
            this.Text = "RGB Plot";
            this.Load += new System.EventHandler(this.FrmRGBPlot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.HScrollBar scrFocus;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnSynch;
    }
}
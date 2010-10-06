namespace binviz_0._1 {
    partial class FrmNavigator {
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
            this.components = new System.ComponentModel.Container();
            this.scrNavigator = new System.Windows.Forms.HScrollBar();
            this.lblLow = new System.Windows.Forms.Label();
            this.lblHigh = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tmrNav = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // scrNavigator
            // 
            this.scrNavigator.Location = new System.Drawing.Point(-1, 58);
            this.scrNavigator.Name = "scrNavigator";
            this.scrNavigator.Size = new System.Drawing.Size(286, 18);
            this.scrNavigator.TabIndex = 0;
            this.scrNavigator.ValueChanged += new System.EventHandler(this.scrNavigator_ValueChanged);
            // 
            // lblLow
            // 
            this.lblLow.AutoSize = true;
            this.lblLow.BackColor = System.Drawing.Color.Transparent;
            this.lblLow.Location = new System.Drawing.Point(2, 0);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(13, 13);
            this.lblLow.TabIndex = 1;
            this.lblLow.Text = "0";
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.BackColor = System.Drawing.Color.Gray;
            this.lblHigh.Location = new System.Drawing.Point(237, 0);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(15, 13);
            this.lblHigh.TabIndex = 2;
            this.lblHigh.Text = "N";
            this.lblHigh.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.BackColor = System.Drawing.Color.Black;
            this.lblCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrent.ForeColor = System.Drawing.Color.Lime;
            this.lblCurrent.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCurrent.Location = new System.Drawing.Point(106, 21);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(179, 37);
            this.lblCurrent.TabIndex = 3;
            this.lblCurrent.Text = "000000000";
            this.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(91, 78);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(80, 30);
            this.btnPlay.TabIndex = 5;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(5, 78);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 30);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tmrNav
            // 
            this.tmrNav.Interval = 1;
            this.tmrNav.Tick += new System.EventHandler(this.tmrNav_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 46);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // FrmNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(292, 112);
            this.ControlBox = false;
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.lblHigh);
            this.Controls.Add(this.lblLow);
            this.Controls.Add(this.scrNavigator);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "FrmNavigator";
            this.Text = "Navigator";
            this.Load += new System.EventHandler(this.FrmNavigator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar scrNavigator;
        private System.Windows.Forms.Label lblLow;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer tmrNav;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
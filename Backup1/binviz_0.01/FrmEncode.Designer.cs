namespace binviz_0._1 {
    partial class FrmEncode {
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
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnASCII = new System.Windows.Forms.Button();
            this.btnFrequency = new System.Windows.Forms.Button();
            this.btnInvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNormal
            // 
            this.btnNormal.Location = new System.Drawing.Point(3, 2);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(102, 63);
            this.btnNormal.TabIndex = 0;
            this.btnNormal.Text = "Normal";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnASCII
            // 
            this.btnASCII.Location = new System.Drawing.Point(3, 71);
            this.btnASCII.Name = "btnASCII";
            this.btnASCII.Size = new System.Drawing.Size(102, 64);
            this.btnASCII.TabIndex = 1;
            this.btnASCII.Text = "ASCII";
            this.btnASCII.UseVisualStyleBackColor = true;
            this.btnASCII.Click += new System.EventHandler(this.btnASCII_Click);
            // 
            // btnFrequency
            // 
            this.btnFrequency.Location = new System.Drawing.Point(3, 141);
            this.btnFrequency.Name = "btnFrequency";
            this.btnFrequency.Size = new System.Drawing.Size(100, 64);
            this.btnFrequency.TabIndex = 2;
            this.btnFrequency.Text = "Frequency";
            this.btnFrequency.UseVisualStyleBackColor = true;
            this.btnFrequency.Click += new System.EventHandler(this.btnFrequency_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.Location = new System.Drawing.Point(3, 213);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(100, 64);
            this.btnInvert.TabIndex = 3;
            this.btnInvert.Text = "Invert";
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // FrmEncode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(107, 283);
            this.Controls.Add(this.btnInvert);
            this.Controls.Add(this.btnFrequency);
            this.Controls.Add(this.btnASCII);
            this.Controls.Add(this.btnNormal);
            this.Location = new System.Drawing.Point(0, 200);
            this.Name = "FrmEncode";
            this.Text = "Encode";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnASCII;
        private System.Windows.Forms.Button btnFrequency;
        private System.Windows.Forms.Button btnInvert;
    }
}
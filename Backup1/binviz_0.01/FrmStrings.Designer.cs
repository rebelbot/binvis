namespace binviz_0._1 {
    partial class FrmStrings {
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
            this.bwString = new System.ComponentModel.BackgroundWorker();
            this.lstStrings = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // bwString
            // 
            this.bwString.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwString_DoWork);
            this.bwString.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwString_RunWorkerCompleted);
            // 
            // lstStrings
            // 
            this.lstStrings.FormattingEnabled = true;
            this.lstStrings.Location = new System.Drawing.Point(5, 4);
            this.lstStrings.Name = "lstStrings";
            this.lstStrings.Size = new System.Drawing.Size(301, 433);
            this.lstStrings.TabIndex = 1;
            this.lstStrings.SelectedIndexChanged += new System.EventHandler(this.lstStrings_SelectedIndexChanged);
            this.lstStrings.DoubleClick += new System.EventHandler(this.lstStrings_DoubleClick);
            // 
            // FrmStrings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 463);
            this.Controls.Add(this.lstStrings);
            this.Name = "FrmStrings";
            this.Text = "Strings";
            this.Load += new System.EventHandler(this.FrmStrings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bwString;
        private System.Windows.Forms.ListBox lstStrings;
    }
}
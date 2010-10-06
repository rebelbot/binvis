namespace binviz_0._1
{
    partial class FrmMemoryMap
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
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstBoxLocations = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Location = new System.Drawing.Point(115, 271);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(176, 49);
            this.btnAddFilter.TabIndex = 1;
            this.btnAddFilter.Text = "Add Marker";
            this.btnAddFilter.UseVisualStyleBackColor = true;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(0, 271);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 49);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete Marker";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstBoxLocations
            // 
            this.lstBoxLocations.FormattingEnabled = true;
            this.lstBoxLocations.Location = new System.Drawing.Point(0, 0);
            this.lstBoxLocations.Name = "lstBoxLocations";
            this.lstBoxLocations.Size = new System.Drawing.Size(291, 264);
            this.lstBoxLocations.TabIndex = 6;
            this.lstBoxLocations.SelectedIndexChanged += new System.EventHandler(this.lstBoxLocations_SelectedIndexChanged);
            this.lstBoxLocations.DoubleClick += new System.EventHandler(this.lstBoxLocations_DoubleClick);
            // 
            // FrmMemoryMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 330);
            this.Controls.Add(this.lstBoxLocations);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddFilter);
            this.Name = "FrmMemoryMap";
            this.Text = "Memory Map";
            this.Load += new System.EventHandler(this.FrmMemoryMap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lstBoxLocations;
    }
}
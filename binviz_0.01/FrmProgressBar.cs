// This form is designed to be a generic progress bar class
// that can used throughout the program

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1 {
    public partial class FrmProgressBar : Form {
        public FrmProgressBar() {
            InitializeComponent();
            
        }

        //override form
        public FrmProgressBar(string label)
        {
            InitializeComponent();
            this.Text = label;
        }

        private void FrmProgressBar_Load(object sender, EventArgs e) {
            
        }

        public void Start(int start, int stop) {
            this.progressBar1.Minimum = start;
            this.progressBar1.Maximum = stop;
            this.progressBar1.Value = start;
        }

        public void Update(int updateValue) {
            this.progressBar1.Value = updateValue;
        }

        
    }
}
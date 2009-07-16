using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1 {
    public partial class FrmStats : Form {
        public FrmStats() {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         //Graphics g = e.Graphics;
            //using Pen p = new Pen(Color.Blue);
            //g.
           // e.Graphics.FillEllipse(Brushes.Yellow,0,0,150,150);
            Pen p = new Pen(Color.Blue);
            for (int i = 0; i <= 255; i++) {
                e.Graphics.DrawLine(Pens.Blue, i, 0, i, 150);
            }

           
        }
       
        private void FrmStats_Load(object sender, EventArgs e) {
            
        }

        
        }
    }

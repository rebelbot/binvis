using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;


namespace binviz_0._1 {
    public partial class FrmPresence : Form {
        public FrmPresence() {
            InitializeComponent();
        }

        private void FrmPresence_Load(object sender, EventArgs e) {

        }

        public void Plot(ref byte[] fileBufferArray, int fileSize, int offset) {
            int columns = pictureBox1.Width;
            int rows = pictureBox1.Height;
            byte currentByte;
            int currentColumn;
            int location = offset;

            Bitmap b = new Bitmap(columns, rows, PixelFormat.Format24bppRgb);
            BitmapData bmd = b.LockBits(new Rectangle(0, 0, columns, rows), ImageLockMode.ReadWrite, b.PixelFormat);

            unsafe {
                for (int j = 0; j < rows; j++) {
                    byte* row = (byte*)bmd.Scan0 + (j * bmd.Stride);
                  for (int i = 0; i<640; i++) {
                      if (location < fileSize) {
                          currentByte = fileBufferArray[location];
                          row[currentByte * 3 + 1] = 255; //green
                          location++;
                      }

                  }                    
                }
                
                b.UnlockBits(bmd);
                pictureBox1.Image = b;
            }//unsafe

        }
    }
}
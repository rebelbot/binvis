using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging; //needed for PixelFormat
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1 {
    public partial class frmAttractor : Form {
        public frmAttractor() {
            InitializeComponent();
        }

        //Attractor

        public void Plot(ref byte[] fileBufferArray, int fileSize, int offset) {
            int rows = pictureBox1.Height;
            int columns = pictureBox1.Width;
            const int WINDOWSIZE = 5000; // running window of the number of bytes to be considered
            int currentWindow;

            //int position = offset;
            byte currentByte;

            //determine the size of the window to be considered, taking into account the end of the array
            if (fileSize > WINDOWSIZE) {
                currentWindow = WINDOWSIZE;
            } else {
                currentWindow = fileSize - 1;
            }

            if ((currentWindow+offset)>fileSize){
                currentWindow = fileSize - offset - 1;
            }
            

            Bitmap b = new Bitmap(columns, rows, PixelFormat.Format24bppRgb);
            BitmapData bmd = b.LockBits(new Rectangle(0, 0, columns, rows), ImageLockMode.ReadWrite, b.PixelFormat); //PixelFormat.Format24bppRgb

            //unsafe code required to access direct image memory
            unsafe {

                for (int i = offset; i < (currentWindow + offset); i++) {
                    //plot(x,y);
                    int x = fileBufferArray[i];
                    int y = fileBufferArray[i + 1]; 
                    
                    byte* row = (byte*)bmd.Scan0 + (y * bmd.Stride);
                    row[x * 3 + 1] = 255; //+1 is to make the pixel green
                }
                
                b.UnlockBits(bmd);
                pictureBox1.Image = b;
            } //unsafe
        } 


        private void pictureBox1_Click(object sender, EventArgs e) {

        } 
    }
}
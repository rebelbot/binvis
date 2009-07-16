using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1
{
    public partial class FrmBytePlot : Form
    {
        private int globalOffset;
        private int globalFileSize;
        private int globalColumns;
        private FrmMain globalFrmMain;

        public FrmBytePlot()
        {
            InitializeComponent();
        }

        private void FrmBitPlot_Load(object sender, EventArgs e)
        {
         

        }

        public void Plot(ref byte[] fileBufferArray, int fileSize, float[] frequency, int offset, FrmEncode frmEncode, FrmMain frmMain) {
            int columns = pictureBox1.Width;
            int rows = pictureBox1.Height;
            int position = offset;
            byte currentByte;
            globalFrmMain = frmMain;
            globalOffset = offset;
            globalFileSize = fileSize;
            globalColumns = columns;

            Bitmap b = new Bitmap(columns, rows, PixelFormat.Format24bppRgb);
            BitmapData bmd = b.LockBits(new Rectangle(0, 0, columns, rows), ImageLockMode.ReadWrite, b.PixelFormat); //PixelFormat.Format24bppRgb
       
            // The unsafe code block is necessary to operate directly on the image
            // memory vs. setpixel.  About 250-300x faster
            unsafe {
                for (int j = 0; j < rows; j++) {
                    byte* row = (byte*)bmd.Scan0 + (j * bmd.Stride); 
                    
                    for (int i = 0; i < columns; i++) {
                        currentByte = 0;
                        if (position < fileSize) {
                            currentByte = fileBufferArray[j * columns + i + offset];
                            position++;

                            //color coding
                            if (FrmEncode.colorMode == 0) { //normal
                                row[i * 3 + 1] = currentByte;
                            } else if (FrmEncode.colorMode == 1) {//ASCII
                                if ((currentByte >= 32) && (currentByte <= 127)) {
                                    row[i * 3] = 255; //blue
                                } else {
                                    row[i * 3] = 32; //gray
                                    row[i * 3 + 1] = 32;
                                    row[i * 3 + 2] = 32;                                    
                                }

                            } else if (FrmEncode.colorMode == 2) {//Frequency
                                if (frequency[currentByte]>.375){
                                  row[i * 3+2] = 255; //red
                                } 
                                if (frequency[currentByte] <.01) {
                                  row[i * 3] = 255; //blue
                                }

                                if ((frequency[currentByte] >= .01)&&(frequency[currentByte]<=.375))
                                 {
                                    row[i * 3] = 64; //gray
                                    row[i * 3 + 1] = 64;
                                    row[i * 3 + 2] = 64;   
                                }
                            }


                            if (FrmEncode.invert == 1) {
                                row[i * 3] = (byte)(255 - row[i * 3]);
                                row[i * 3 + 1] = (byte)(255 - row[i * 3+1]);
                                row[i * 3 + 2] = (byte)(255 - row[i * 3+2]); 
                            }
                        }                                            
                    }
                }                
                b.UnlockBits(bmd);
                pictureBox1.Image = b;
             
               // Invert(b);
            } //unsafe
    
        }
                   
        public int lineWidth() {
            return(pictureBox1.Width);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            int location = (e.Y * globalColumns + e.X + globalOffset);
           if (location<globalFileSize) toolTip1.SetToolTip(this.pictureBox1, location.ToString());
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            int location = (e.Y * globalColumns + e.X + globalOffset);
            globalFrmMain.redrawText(location);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

       
    }
}
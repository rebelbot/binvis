// This visualization is an implementation of the dot plot technique
// presented in <need paper citation> and, later using binaries, the
// esteemed Dan Kaminsky.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1 {
    public partial class FrmDotPlot : Form {
        public FrmDotPlot() {
            InitializeComponent();
        }

        // public plot method is called to update the display
        // most often from FrmNavigator
        public void Plot(ref byte[] fileBufferArray, int fileSize, int offset) {
            int columns, rows;
            int position = offset;
            byte currentByte;

            if (fileSize > 500) //500 is just an arbitrary max dimension, for now
            {
                columns = 500;
                rows = 500;
            } else {
                columns = fileSize;
                rows = fileSize;
            }

            Bitmap b = new Bitmap(columns, rows, PixelFormat.Format24bppRgb);
            BitmapData bmd = b.LockBits(new Rectangle(0, 0, columns, rows), ImageLockMode.ReadWrite, b.PixelFormat); //PixelFormat.Format24bppRgb

            //unsafe code required to access direct image memory
            unsafe {
                for (int j = 0; j < rows; j++) {
                    byte* row = (byte*)bmd.Scan0 + (j * bmd.Stride);
                    for (int i = 0; i < columns; i++) {
                        if ((i + offset) <= fileBufferArray.Length) {
                            if ((fileBufferArray[i + offset] == fileBufferArray[j + offset])) {
                                row[i * 3 + 1] = (byte)(((float)fileBufferArray[i + offset] * 0.75) + 64);
                            }
                        } else {
                            break;
                        }
                    }
                }
                b.UnlockBits(bmd);
                pictureBox1.Image = b;
            } //unsafe
        }

        private void FrmDotPlot_Load(object sender, EventArgs e) {

        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }
            
        }
    }

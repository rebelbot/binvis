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
    public partial class FrmBitPlot : Form
    {
        public FrmBitPlot()
        {
            InitializeComponent();
        }

        internal void Plot(ref byte[] fileBufferArray, int fileSize, int offset)
        {
            int columns = pictureBox1.Width;
            int rows = pictureBox1.Height;
            int position = offset;
            byte currentByte;
            //globalFrmMain = frmMain;
            //globalOffset = offset;
            //globalFileSize = fileSize;
            //globalColumns = columns;

            Bitmap b = new Bitmap(columns, rows, PixelFormat.Format24bppRgb);
            BitmapData bmd = b.LockBits(new Rectangle(0, 0, columns, rows), ImageLockMode.ReadWrite, b.PixelFormat); //PixelFormat.Format24bppRgb

            // The unsafe code block is necessary to operate directly on the image
            // memory vs. setpixel.  About 250-300x faster
            unsafe
            {
                currentByte = fileBufferArray[position];
                for (int j = 0; j < rows; j++)
                {
                    byte* row = (byte*)bmd.Scan0 + (j * bmd.Stride);
                                        
                    for (int i = 0; i < columns; i++)
                    {
                        if (position < fileSize)
                        {
                            //currentByte = fileBufferArray[position];
                            if (currentByte >= 128) //bit 8
                            {
                                row[i * 3 + 1] = 255; //bright green
                                currentByte -= 128; 
                            }
                            else if (currentByte >= 64){ //bit 7
                                row[i * 3 + 1] = 255; //bright green
                                currentByte -= 64;
                            }
                            else if (currentByte >= 32) //bit 6
                            {
                                row[i * 3 + 1] = 255; //bright green
                                currentByte -= 32;
                            }
                            else if (currentByte >= 16) // bit 5
                            {
                                row[i * 3 + 1] = 255; //bright green
                                currentByte -= 16;
                            }
                            else if (currentByte >= 8) // bit 4
                            {
                                row[i * 3 + 1] = 255; //bright green
                                currentByte -= 8;
                            }
                            else if (currentByte >= 4) // bit 3
                            {
                                row[i * 3 + 1] = 255; //bright green
                                currentByte -= 4;
                            }
                            else if (currentByte >= 2) //bit 2
                            {
                                row[i * 3 + 1] = 255; //bright green
                                currentByte -= 2;
                            }
                            else if (currentByte >= 1) // bit 1
                            {
                                row[i * 3 + 1] = 255; //bright green
                                currentByte -= 1;
                            }
                            else
                            {
                                if (position < fileSize-1)
                                {
                                    position++;
                                    currentByte = fileBufferArray[position];
                                }
                            }
                            

                            
                        }
                    }
                }
                b.UnlockBits(bmd);
                pictureBox1.Image = b;

            } //unsafe
    
        }
    }
}
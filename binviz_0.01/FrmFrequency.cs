using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1 {
    public partial class FrmFrequency : Form {
        public FrmFrequency() {
            InitializeComponent();
        }

        //takes a value and returns a scaled value
        //private int Scale(int originalValue, int originalMaxValue) {
        //    int newMaxValue = 0; //  this.pnlFreq.Height;
        //    int scaledValue = ((originalValue / originalMaxValue) * newMaxValue);
        //    return (scaledValue);
        //}

        public void PlotHistogramWindow(ref byte[] fileBufferArray, int fileSize, int offset) {
            int columns = pictureBox1.Width;
            int rows = pictureBox1.Height;
            int position = offset;
            byte currentByte;
            int[] windowByteCount = new int[256];
            float[] windowFrequency = new float[256];
            const int WINDOWSIZE = 5000;

            //initialize byte count array
            //for (int a = 0; a < 256; a++) windowByteCount[a] = 0;
            
            //count the number of each byte type and place in windowByteCount[]
            for (int i = offset; i < (offset+WINDOWSIZE); i++)
            {
                if (fileSize <= (i + offset)) break; //reached end of file
                windowByteCount[fileBufferArray[i]]++;
            }

            // find the most frequent occurence
            int maxOccurence = -1;
            for (int j = 0; j < 256; j++)
            {
                if (maxOccurence < windowByteCount[j]) maxOccurence = windowByteCount[j];
            }
            Console.WriteLine(maxOccurence);
            //calculate normalized frequency from 0 to 1
            for (int j = 0; j <= 255; j++)
            {
            //    windowFrequency[j] = (float)windowByteCount[j] / WINDOWSIZE; //dividing int by int is integer division, must cast to float
                windowFrequency[j] = (float)windowByteCount[j] / maxOccurence; 
            //    //Console.WriteLine(windowFrequency[j]);
            }

            
            
            
            Bitmap b = new Bitmap(columns, rows, PixelFormat.Format24bppRgb);
            BitmapData bmd = b.LockBits(new Rectangle(0, 0, columns, rows), ImageLockMode.ReadWrite, b.PixelFormat); //PixelFormat.Format24bppRgb
            int y2 = pictureBox1.Height;
            //float scale = (float)y2 / maxFreq;
            //Console.WriteLine(scale);

            // The unsafe code block is necessary to operate directly on the image
            // memory vs. setpixel.  About 250-300x faster

            unsafe{
              byte* pixelRow;
              for (int k = 0; k < 256; k++)
              {
                  //Random r = new Random();
                  
                  //windowFrequency[k] = 
                  int y1;

                  if (maxOccurence > 0)
                  {
                      y1 = (int)(y2 * (1.0 - (windowFrequency[k])));
                  }
                  else
                  {
                      y1 = 0;
                  }
                  //int y1 = (int)(y2-(scale *windowFrequency[k]));
                  
                for (int l = y2; l > y1; l--)
                  //for (int l = pictureBox1.Height; l > (pictureBox1.Height * .5); l--)
                  {
                      //byte* pixelPointer = (byte*)(bmd.Scan0 + (l * bmd.Stride) + (k * 3 + 1);
                 
                    pixelRow = (byte*)bmd.Scan0 + (l * bmd.Stride);
                    try
                    {
                        pixelRow[k * 3 + 1] = 255;
                    }
                    catch (Exception)
                    {
                        for (int zz = 0; zz < 256; zz++)
                        {
                            Console.WriteLine(zz + " " + y1 + " " + y2 + " " +windowFrequency[zz]+ " maxoccurence = " +maxOccurence);
                        }
                    }
                   // catch (AccessViolationException)
                   // {
                        // do nothing
                   // }
                   // catch (System.Runtime.InteropServices.SEHException)
                    //{
                        // do nothing
                    //}
                      //Console.WriteLine("pixel ");
                    //PlotPixel(k, l);
                  }//row            
              }//column
              b.UnlockBits(bmd);
              //b.RotateFlip(RotateFlipType.Rotate90FlipNone);
              pictureBox1.Image = b;
            }//unsafe            
        }

        //public void Plot(float[] frequency) {
           // for (int i = 0; i < 256; i++) {
             //   PlotHistogram(frequency[i],i);
           // }
        //}


        // internal static void
        public void initFrequency(ref int[] byteCount, ref float[] frequency)
        {
            for (int i = 0; i <= 255; i++) {
                frequency[i] = 0;
                byteCount[i] = 0;            
            }
        }

        // internal static void
        public void calcFrequency(int fileLength, ref int[] byteCount, ref byte[] fileBufferArray, ref float[] frequency, FrmMain frmMainHandle)
        {
            FrmProgressBar fpb = new FrmProgressBar("calculating byte frequency...");
            //Console.WriteLine(this.ParentForm.ToString());
            
            fpb.MdiParent = frmMainHandle;
            fpb.Start(0, fileLength);
            fpb.Show();

                for (int i = 0; i < fileLength; i++) {
                    byteCount[fileBufferArray[i]]++;
                    if (i % 10000 == 0)
                    {
                        fpb.Update(i);
                        Application.DoEvents();
                    }
                }
                for (int j = 0; j <= 255; j++) {
                    frequency[j] = (float)byteCount[j] / fileLength; //dividing int by int is integer division, must cast to float
                    //Console.WriteLine(j + " " + byteCount[j]+ " " + fileLength + " " + frequency[j]);
                }
            fpb.Hide();
        }

 
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(this.pictureBox1, e.X.ToString());
        }
    }
    
}
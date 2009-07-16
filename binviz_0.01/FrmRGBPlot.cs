using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1 {
    public partial class FrmRGBPlot : Form {
        private int globalOffset;
        private int globalFileSize;
        //private Bitmap globalBitMap;
        //private int globalColumns;
        private FrmNavigator globalFrmNavigator;
        private byte[] globalFileBufferArray;
        
        private int step = 0;
        
        public FrmRGBPlot() {
            InitializeComponent();
            scrFocus.Maximum = pictureBox1.Width;
            scrFocus.Value = pictureBox1.Width;
        }

        public FrmRGBPlot(FrmNavigator navigatorHandle)
        {
            InitializeComponent();
            scrFocus.Maximum = pictureBox1.Width;
            scrFocus.Value = pictureBox1.Width;
            globalFrmNavigator = navigatorHandle;
        }

        private void scrFocus_Scroll(object sender, ScrollEventArgs e) {
            lblWidth.Text = scrFocus.Value.ToString();
            Plot(ref globalFileBufferArray, globalFileSize, globalOffset);
        }
        public void Plot(ref byte[] fileBufferArray, int fileSize, int offset) {
            int columns = pictureBox1.Width;
            int rows = pictureBox1.Height;
            int position = offset;
            byte currentByte;
            //globalFrmMain = frmMain;
            globalOffset = offset;
            globalFileSize = fileSize;
            globalFileBufferArray = fileBufferArray;
            //globalColumns = columns;

            if (step == 0) {
            Bitmap b = new Bitmap(columns, rows, PixelFormat.Format24bppRgb);
            //globalBitMap = b;
            BitmapData bmd = b.LockBits(new Rectangle(0, 0, columns, rows), ImageLockMode.ReadWrite, b.PixelFormat); //PixelFormat.Format24bppRgb
            
            
            // The unsafe code block is necessary to operate directly on the image
            // memory vs. setpixel.  About 250-300x faster
            //Console.WriteLine("plot");
                unsafe {
                    for (int j = 0; j < rows; j++) {
                        byte* row = (byte*)bmd.Scan0 + (j * bmd.Stride);

                        for (int i = 0; i < columns; i++) {
                            currentByte = 0;
                            //if (i > (columns - this.scrFocus.Value)) break; //could this be moved to the row loop to speed things up?
                            if (i > this.scrFocus.Value) break;
                            if (position < (fileSize - 2)) {
                                currentByte =
                                row[i * 3 + 2] = fileBufferArray[position]; //red
                                position++;
                                row[i * 3 + 1] = fileBufferArray[position]; //green
                                position++;
                                row[i * 3] = fileBufferArray[position]; //blue
                                position++;
                            }
                        }
                    }
                    b.UnlockBits(bmd);
                    if (checkBox1.Checked) b.RotateFlip(RotateFlipType.Rotate180FlipX);
                    pictureBox1.Image = b;
                    step++;
                    // Invert(b);
                } //unsafe
            } else { //step
                if (step == 2) {
                    step = 0;
                } else {
                    step++;
                }
                //Console.WriteLine("skip");
            }
        }

        public int lineWidth() {
            return (pictureBox1.Width);
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void FrmRGBPlot_Load(object sender, EventArgs e) {
            //scrFocus.Maximum = 640;// pictureBox1.Width;
            //scrFocus.Value = pictureBox1.Width;
            lblWidth.Text = pictureBox1.Width.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {

        }

        //changes system level playback width to prevent skew
        private void btnSynch_Click(object sender, EventArgs e)
        {
           if (globalFrmNavigator != null)
            {
                globalFrmNavigator.Synchronize(scrFocus.Value+1);           
            }
        }

       

        //private void btnFinePlus_Click(object sender, EventArgs e)
        //{
        //    if (scrFocus.Value < scrFocus.Maximum)
        //    {
        //        scrFocus.Value++;
        //        lblWidth.Text = scrFocus.Value.ToString();
        //        Plot(ref globalFileBufferArray, globalFileSize, globalOffset);
        //    }
        //}

        //private void btnFineMinus_Click(object sender, EventArgs e)
        //{
        //    if (scrFocus.Value > scrFocus.Minimum)
        //    {
        //        scrFocus.Value--;
        //        lblWidth.Text = scrFocus.Value.ToString();
        //        Plot(ref globalFileBufferArray, globalFileSize, globalOffset);
        //    }
        //}

      

       
    }
}
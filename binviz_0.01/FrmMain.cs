using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1
{
    public partial class FrmMain : Form
    {   
        byte[] fileBufferArray;  //contains the full, raw contents of the file to be studied
        int[] byteCount = new int[256]; //contains raw count of each byte across entire file
        public float[] frequency = new float[256]; //contains frequency of each byte across entire file
        
        int fileLength;
       
        // Class-wide declarations of analysis forms
        FrmEncode globalFrmEncode;
        FrmFrequency globalFrmFrequency = new FrmFrequency(); 
        FrmByteCloud globalFrmByteCloud;
        public FrmNavigator globalFrmNavigator; //public used to control playback synch
        FrmBytePlot globalFrmbytePlot;
        FrmRGBPlot globalFrmRGBPlot;
        FrmDotPlot globalFrmDotPlot;
        FrmPresence globalFrmPresence;
        FrmText globalFrmText;
        frmAttractor globalFrmAttractor;
        FrmMemoryMap globalFrmMemoryMap;
        FrmBitPlot globalFrmBitPlot;
        ProcessMemory processMemory = new ProcessMemory();
        
        //default constructor
        public FrmMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true; //turn the form into the parent MDI form
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FrmFrequency.initFrequency(ref byteCount, ref frequency);
            this.globalFrmFrequency.initFrequency(ref byteCount, ref frequency);
            globalFrmNavigator = new FrmNavigator(this);
            
        }

        //exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //text visualization
        private void hexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmText frmText = new FrmText();
            globalFrmText = frmText;
            frmText.MdiParent = this;
            if (fileLength > 0) frmText.Plot(ref fileBufferArray, fileLength,0);
            frmText.Show();
            
        }

        //open file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BytesRead = 0;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            
            if (ofd.FileName != "")
            {
                FileStream fs = File.OpenRead(ofd.FileName);
                BinaryReader br = new BinaryReader(fs);
                
                fileLength = (int)fs.Length; // This limits the maximum file size to ~2GB due to maxint
                fileBufferArray = new byte[fileLength];
                FrmProgressBar fpb = new FrmProgressBar("loading file...");
                fpb.MdiParent = this;
                fpb.Start(0, fileLength);
                fpb.Show();
                while (BytesRead < fileLength) {
                  fileBufferArray[BytesRead] = br.ReadByte();
                  if (BytesRead % 10000 == 0) {
                      fpb.Update(BytesRead);
                      Application.DoEvents();
                  }
                  BytesRead++;                  
                }
                fpb.Close();
                br.Close();
                this.Text = "BinVis " + ofd.FileName;
                
                //FrmFrequency.calcFrequency(fileLength, ref byteCount, ref fileBufferArray, ref frequency);
                this.globalFrmFrequency.calcFrequency(fileLength, ref byteCount, ref fileBufferArray, ref frequency, this);
                processMemory.Process(fileLength, ref fileBufferArray);
                globalFrmNavigator.init(fileLength, ref fileBufferArray);
                globalFrmNavigator.MdiParent = this;
                globalFrmNavigator.Show();
                
            }
        }

        //dynamic redrawing
        public void Redraw(int offset) {
            if (fileLength > 0){
                if (globalFrmbytePlot != null) globalFrmbytePlot.Plot(ref fileBufferArray, fileLength, frequency, offset, globalFrmEncode, this);
                if (globalFrmDotPlot != null) globalFrmDotPlot.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmPresence != null) globalFrmPresence.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmRGBPlot != null) globalFrmRGBPlot.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmBitPlot != null) globalFrmBitPlot.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmAttractor !=null) globalFrmAttractor.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmFrequency != null) globalFrmFrequency.PlotHistogramWindow(ref fileBufferArray, fileLength, offset);
                //globalFrmNavigator.setPosition(offset);
            }
        }

        //dynamic redrawing
        public void JumpAndRedraw(int offset)
        {
            if (fileLength > 0)
            {
                if (globalFrmbytePlot != null) globalFrmbytePlot.Plot(ref fileBufferArray, fileLength, frequency, offset, globalFrmEncode, this);
                if (globalFrmDotPlot != null) globalFrmDotPlot.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmPresence != null) globalFrmPresence.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmRGBPlot != null) globalFrmRGBPlot.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmBitPlot != null) globalFrmBitPlot.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmAttractor != null) globalFrmAttractor.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmFrequency != null) globalFrmFrequency.PlotHistogramWindow(ref fileBufferArray, fileLength, offset);
                globalFrmNavigator.setPosition(offset);
            }
        }
        //static detail redrawing
        public void redrawText(int offset) {
            if (fileLength > 0) {
                if (globalFrmText != null) globalFrmText.Plot(ref fileBufferArray, fileLength, offset);
                //globalFrmNavigator.setPosition(offset);
            }
        }

        //RGB plot visualization
        private void rGBPlotToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmRGBPlot frmRGBPlot = new FrmRGBPlot(globalFrmNavigator);
            globalFrmRGBPlot = frmRGBPlot;
            frmRGBPlot.MdiParent = this;
            if (fileLength > 0) frmRGBPlot.Plot(ref fileBufferArray, fileLength,0);
            frmRGBPlot.Show();      
        }
                
        //statistics display
        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmStats frmStats = new FrmStats();
            frmStats.MdiParent = this;
            //if (fileLength > 0) frmStats.Plot(ref fileBufferArray, fileLength);
            frmStats.Show();
        }

        //dotplot visualization
        private void dotPlotToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmDotPlot frmDotPlot = new FrmDotPlot();
            this.globalFrmDotPlot = frmDotPlot;
            frmDotPlot.MdiParent = this;
            if (fileLength > 0) frmDotPlot.Plot(ref fileBufferArray, fileLength, 0);
            frmDotPlot.Show();           
        }

        //strings visualization
        private void stringsToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmStrings frmStrings = new FrmStrings(this);
            frmStrings.MdiParent = this;
            int lengthThreshold = 5;
            frmStrings.Calc(fileLength, ref fileBufferArray, lengthThreshold);
            frmStrings.Show();
        }

        //text cloud visualization
        private void textCloudToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmByteCloud frmByteCloud = new FrmByteCloud();
            globalFrmByteCloud = frmByteCloud;
            frmByteCloud.MdiParent = this;
            frmByteCloud.plot(frequency);
            frmByteCloud.Show();
        }

        //frequency
        private void frequencyToolStripMenuItem_Click(object sender, EventArgs e) {
            //FrmFrequency frmFrequency = new FrmFrequency();
            //globalFrmFrequency = frmFrequency;
            //frmFrequency.MdiParent = this;
            globalFrmFrequency.MdiParent = this;
            if (fileLength > 0) globalFrmFrequency.PlotHistogramWindow(ref fileBufferArray, fileLength, 0);
            globalFrmFrequency.Show();            
        }

        //Color coding
        private void colorCodingToolStripMenuItem_Click(object sender, EventArgs e) {
            if (globalFrmEncode == null) {
                globalFrmEncode = new FrmEncode();
                globalFrmEncode.MdiParent = this;
                globalFrmEncode.Show();
            }
        }

        //byte presence
        private void bytePresenceToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmPresence frmPresence = new FrmPresence();
            this.globalFrmPresence = frmPresence;
            frmPresence.MdiParent = this;
            if (fileLength>0) frmPresence.Plot(ref fileBufferArray, fileLength, 0);
            frmPresence.Show();           
        }

        //memory map
        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMemoryMap frmMemoryMap = new FrmMemoryMap();
            this.globalFrmMemoryMap = frmMemoryMap;
            frmMemoryMap.MdiParent = this;
            frmMemoryMap.init(fileLength,this);
            frmMemoryMap.Show();
        }

        //bit plot
        private void bitPlotToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBitPlot frmBitPlot = new FrmBitPlot();
            globalFrmBitPlot = frmBitPlot;
            frmBitPlot.MdiParent = this;
            if (fileLength > 0) frmBitPlot.Plot(ref fileBufferArray, fileLength, 0);
            frmBitPlot.Show();  
        }

        //byte plot
        private void bitPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBytePlot frmbytePlot = new FrmBytePlot();
            globalFrmbytePlot = frmbytePlot;
            frmbytePlot.MdiParent = this;
            if (fileLength > 0) frmbytePlot.Plot(ref fileBufferArray, fileLength, frequency, 0, globalFrmEncode, this);
            frmbytePlot.Show();
        }
        //attractor view
        private void attractorToolStripMenuItem_Click(object sender, EventArgs e) {
            frmAttractor frmAttractor = new frmAttractor();
            globalFrmAttractor = frmAttractor;
            frmAttractor.MdiParent = this;
            if (fileLength > 0) frmAttractor.Plot(ref fileBufferArray, fileLength, 0);
            frmAttractor.Show();
        }

      }
}
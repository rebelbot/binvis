using System;
using System.IO;
using System.Windows.Forms;

namespace binviz_0._1
{
    public partial class FrmMain : Form
    {
        private readonly FrmFrequency globalFrmFrequency = new FrmFrequency();
        private readonly ProcessMemory processMemory = new ProcessMemory();
        private int[] byteCount = new int[256]; //contains raw count of each byte across entire file
        private byte[] fileBufferArray; //contains the full, raw contents of the file to be studied

        private int fileLength;
        public float[] frequency = new float[256]; //contains frequency of each byte across entire file
        private frmAttractor globalFrmAttractor;
        private FrmBitPlot globalFrmBitPlot;

        // Class-wide declarations of analysis forms
        private FrmByteCloud globalFrmByteCloud;
        private FrmBytePlot globalFrmbytePlot;
        private FrmDotPlot globalFrmDotPlot;
        private FrmEncode globalFrmEncode;
        private FrmMemoryMap globalFrmMemoryMap;
        public FrmNavigator globalFrmNavigator; //public used to control playback synch
        private FrmPresence globalFrmPresence;
        private FrmRGBPlot globalFrmRGBPlot;
        private FrmText globalFrmText;

        //default constructor
        public FrmMain()
        {
            InitializeComponent();
            IsMdiContainer = true; //turn the form into the parent MDI form
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FrmFrequency.initFrequency(ref byteCount, ref frequency);
            globalFrmFrequency.initFrequency(ref byteCount, ref frequency);
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
            var frmText = new FrmText();
            globalFrmText = frmText;
            frmText.MdiParent = this;
            if (fileLength > 0) frmText.Plot(ref fileBufferArray, fileLength, 0);
            frmText.Show();
        }

        //open file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BytesRead = 0;
            var ofd = new OpenFileDialog();
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                FileStream fs = File.OpenRead(ofd.FileName);
                var br = new BinaryReader(fs);

                fileLength = (int) fs.Length; // This limits the maximum file size to ~2GB due to maxint
                fileBufferArray = new byte[fileLength];
                var fpb = new FrmProgressBar("loading file...");
                fpb.MdiParent = this;
                fpb.Start(0, fileLength);
                fpb.Show();
                while (BytesRead < fileLength)
                {
                    fileBufferArray[BytesRead] = br.ReadByte();
                    if (BytesRead%10000 == 0)
                    {
                        fpb.Update(BytesRead);
                        Application.DoEvents();
                    }
                    BytesRead++;
                }
                fpb.Close();
                br.Close();
                Text = "BinVis " + ofd.FileName;

                //FrmFrequency.calcFrequency(fileLength, ref byteCount, ref fileBufferArray, ref frequency);
                globalFrmFrequency.calcFrequency(fileLength, ref byteCount, ref fileBufferArray, ref frequency, this);
                processMemory.Process(fileLength, ref fileBufferArray);
                globalFrmNavigator.init(fileLength, ref fileBufferArray);
                globalFrmNavigator.MdiParent = this;
                globalFrmNavigator.Show();
            }
        }

        //dynamic redrawing
        public void Redraw(int offset)
        {
            if (fileLength > 0)
            {
                if (globalFrmbytePlot != null)
                    globalFrmbytePlot.Plot(ref fileBufferArray, fileLength, frequency, offset, globalFrmEncode, this);
                if (globalFrmDotPlot != null) globalFrmDotPlot.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmPresence != null) globalFrmPresence.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmRGBPlot != null) globalFrmRGBPlot.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmBitPlot != null) globalFrmBitPlot.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmAttractor != null) globalFrmAttractor.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmFrequency != null)
                    globalFrmFrequency.PlotHistogramWindow(ref fileBufferArray, fileLength, offset);
                //globalFrmNavigator.setPosition(offset);
            }
        }

        //dynamic redrawing
        public void JumpAndRedraw(int offset)
        {
            if (fileLength > 0)
            {
                if (globalFrmbytePlot != null)
                    globalFrmbytePlot.Plot(ref fileBufferArray, fileLength, frequency, offset, globalFrmEncode, this);
                if (globalFrmDotPlot != null) globalFrmDotPlot.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmPresence != null) globalFrmPresence.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmRGBPlot != null) globalFrmRGBPlot.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmBitPlot != null) globalFrmBitPlot.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmAttractor != null) globalFrmAttractor.Plot(ref fileBufferArray, fileLength, offset);
                if (globalFrmFrequency != null)
                    globalFrmFrequency.PlotHistogramWindow(ref fileBufferArray, fileLength, offset);
                globalFrmNavigator.setPosition(offset);
            }
        }

        //static detail redrawing
        public void redrawText(int offset)
        {
            if (fileLength > 0)
            {
                if (globalFrmText != null) globalFrmText.Plot(ref fileBufferArray, fileLength, offset);
                //globalFrmNavigator.setPosition(offset);
            }
        }

        //RGB plot visualization
        private void rGBPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmRGBPlot = new FrmRGBPlot(globalFrmNavigator);
            globalFrmRGBPlot = frmRGBPlot;
            frmRGBPlot.MdiParent = this;
            if (fileLength > 0) frmRGBPlot.Plot(ref fileBufferArray, fileLength, 0);
            frmRGBPlot.Show();
        }

        //statistics display
        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmStats = new FrmStats();
            frmStats.MdiParent = this;
            //if (fileLength > 0) frmStats.Plot(ref fileBufferArray, fileLength);
            frmStats.Show();
        }

        //dotplot visualization
        private void dotPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmDotPlot = new FrmDotPlot();
            globalFrmDotPlot = frmDotPlot;
            frmDotPlot.MdiParent = this;
            if (fileLength > 0) frmDotPlot.Plot(ref fileBufferArray, fileLength, 0);
            frmDotPlot.Show();
        }

        //strings visualization
        private void stringsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmStrings = new FrmStrings(this);
            frmStrings.MdiParent = this;
            int lengthThreshold = 5;
            frmStrings.Calc(fileLength, ref fileBufferArray, lengthThreshold);
            frmStrings.Show();
        }

        //text cloud visualization
        private void textCloudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmByteCloud = new FrmByteCloud();
            globalFrmByteCloud = frmByteCloud;
            frmByteCloud.MdiParent = this;
            frmByteCloud.plot(frequency);
            frmByteCloud.Show();
        }

        //frequency
        private void frequencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmFrequency frmFrequency = new FrmFrequency();
            //globalFrmFrequency = frmFrequency;
            //frmFrequency.MdiParent = this;
            globalFrmFrequency.MdiParent = this;
            if (fileLength > 0) globalFrmFrequency.PlotHistogramWindow(ref fileBufferArray, fileLength, 0);
            globalFrmFrequency.Show();
        }

        //Color coding
        private void colorCodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (globalFrmEncode == null)
            {
                globalFrmEncode = new FrmEncode();
                globalFrmEncode.MdiParent = this;
                globalFrmEncode.Show();
            }
        }

        //byte presence
        private void bytePresenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmPresence = new FrmPresence();
            globalFrmPresence = frmPresence;
            frmPresence.MdiParent = this;
            if (fileLength > 0) frmPresence.Plot(ref fileBufferArray, fileLength, 0);
            frmPresence.Show();
        }

        //memory map
        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmMemoryMap = new FrmMemoryMap();
            globalFrmMemoryMap = frmMemoryMap;
            frmMemoryMap.MdiParent = this;
            frmMemoryMap.init(fileLength, this);
            frmMemoryMap.Show();
        }

        //bit plot
        private void bitPlotToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmBitPlot = new FrmBitPlot();
            globalFrmBitPlot = frmBitPlot;
            frmBitPlot.MdiParent = this;
            if (fileLength > 0) frmBitPlot.Plot(ref fileBufferArray, fileLength, 0);
            frmBitPlot.Show();
        }

        //byte plot
        private void bitPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmbytePlot = new FrmBytePlot();
            globalFrmbytePlot = frmbytePlot;
            frmbytePlot.MdiParent = this;
            if (fileLength > 0) frmbytePlot.Plot(ref fileBufferArray, fileLength, frequency, 0, globalFrmEncode, this);
            frmbytePlot.Show();
        }

        //attractor view
        private void attractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAttractor = new frmAttractor();
            globalFrmAttractor = frmAttractor;
            frmAttractor.MdiParent = this;
            if (fileLength > 0) frmAttractor.Plot(ref fileBufferArray, fileLength, 0);
            frmAttractor.Show();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1 {
    public partial class FrmStrings : Form {
        int gFileLength;
        byte[] gFileBufferArray;
        const int MAXSTRINGS = 100000;
        string[] gStringArray = new string[MAXSTRINGS]; //maxes out at 100,000 strings
        int[] gStringLocations = new int[MAXSTRINGS]; // holds locations of strings
        int gLengthThreshhold;
        int gStringsMatched = 0;
        FrmMain gFrmMain;

        public FrmStrings() {
            InitializeComponent();
        }

        public FrmStrings(FrmMain frmMain)
        {
            InitializeComponent();
            gFrmMain = frmMain;
        }

        private void FrmStrings_Load(object sender, EventArgs e) {

        }

        public void Calc(int fileLength, ref byte[] fileBufferArray, int lengthThreshold){
            this.Text = "Currently calculating strings...";
            gFileLength = fileLength;
            gFileBufferArray = fileBufferArray;
            gLengthThreshhold = lengthThreshold;
            //txtBoxStrings.Text = "foo";
            bwString.RunWorkerAsync();
        
        }

        private void txtBoxStrings_TextChanged(object sender, EventArgs e) {

        }

        private void bwString_DoWork(object sender, DoWorkEventArgs e)
        {
            int runTotal = 0;
            
            string currentString = "";

            for (int i = 0; i < gFileLength; i++)
            {
                //if () this.bwString.ReportProgress();
                
                if ((gFileBufferArray[i] >= 32) && (gFileBufferArray[i] <= 127))
                {//char matched
                    currentString += (char)gFileBufferArray[i];
                    runTotal++;
                }
                else if (runTotal >= gLengthThreshhold)
                {//no match, but run is long enough
                    //return fileBufferArray[i-runTotal to i]
                    int offset = i - runTotal;
                    runTotal = 0;

                    //this.txtBoxStrings.Text += "<" + offset + ">\t" + currentString + "\r\n";
                    //lstStrings.Items.Add("<" + offset + ">\t" + currentString + "\r\n");
                    if (gStringsMatched < (MAXSTRINGS - 2))
                    {
                        gStringArray[gStringsMatched] = "<" + offset + ">\t" + currentString + "\r\n";
                        gStringLocations[gStringsMatched] = offset;
                        gStringsMatched++;
                        currentString = "";
                    } else {//out of space 
                        //gStringArray[gStringsMatched] = "more than " + MAXSTRINGS.ToString() + "found.  Stopping search";
                        break;
                    }

                }

                else
                { //no match, run too short
                    runTotal = 0;
                    currentString = "";
                }
                
            }
            

        }

        private void lstStrings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bwString_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (gStringsMatched > 0)
            {
                for (int i = 0; i < gStringsMatched; i++)
                {
                    lstStrings.Items.Add(gStringArray[i]);
                }
                this.Text = "Strings (" +gStringsMatched.ToString() +") found";
            } else {
             //no strings matched
               // lstStrings.Items.Add("no strings matched...");
                this.Text = "Strings (0 strings found)";
            }
        }

        private void lstStrings_DoubleClick(object sender, EventArgs e)
        {
            if (lstStrings.SelectedIndex != null)
            {
               if (gFrmMain != null)
                {
                    gFrmMain.redrawText(gStringLocations[lstStrings.SelectedIndex]);
                    gFrmMain.JumpAndRedraw(gStringLocations[lstStrings.SelectedIndex]);
                }
            }
        }
    }
}
// FrmNavigation provides a centralized point for all navigation
// by acting as a primary navigation interface and updating visualization windows

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1 {
    public partial class FrmNavigator : Form {
        const int DEFAULTPLAYBACKWIDTH =640;
        FrmMain handle;
        int playbackWidth = DEFAULTPLAYBACKWIDTH;
        int playbackMultiplier = 3;

        //allows a view to set playback width to prevent skew
        public void Synchronize(int synchWidth){
            playbackWidth = synchWidth;
        }

        // allows a view to change playback to default width
        public void SynchronizeReset(){
            playbackWidth = DEFAULTPLAYBACKWIDTH;
        }

        public FrmNavigator() {
            InitializeComponent();
        }

        //overide constructor in order to accept argument
        public FrmNavigator(FrmMain callingHandle)
        {
            InitializeComponent(); 
            handle = callingHandle;
        }

        public void init(int highValue, ref byte[] fileBufferArray) {
            this.scrNavigator.Maximum = highValue;
            this.scrNavigator.Minimum = 0;
            this.lblHigh.Text = highValue.ToString();
            this.lblLow.Text = "0";
            this.lblCurrent.Text = "0";
        }

        public void setPosition(int currentLocation) {
            this.scrNavigator.Value = currentLocation;
            this.lblCurrent.Text = currentLocation.ToString();
        }
        private void FrmNavigator_Load(object sender, EventArgs e) {

        }

       // public void init(FrmMain callingHandle) {
       //     handle = callingHandle;
       // }

        private void scrNavigator_ValueChanged(object sender, EventArgs e) {
            this.lblCurrent.Text = scrNavigator.Value.ToString();
            handle.Redraw(scrNavigator.Value); //provides active scroll, but could be computationally intensive 
        }


        
        private void btnStop_Click(object sender, EventArgs e) {
          tmrNav.Stop();
        }

        private void tmrNav_Tick(object sender, EventArgs e) {
            int playbackInterval = playbackWidth * playbackMultiplier;
            if (scrNavigator.Value + playbackInterval <= scrNavigator.Maximum) {
                scrNavigator.Value += playbackInterval;
                handle.Redraw(scrNavigator.Value); //go back to main form and redraw all visualization
            } else {
                btnStop_Click(sender, e);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e) {
            tmrNav.Start();
            
            
        }



    }
}
    

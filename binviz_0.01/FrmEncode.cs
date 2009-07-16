using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1 {
    public partial class FrmEncode : Form {

        //String byteSequence = new String();

        public static int colorMode = 0;
        public static int invert = 0;

        public FrmEncode() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        


        //Normal Encoding
        public Color EncodeNormal(byte currentByte) {
            return Color.FromArgb(currentByte, currentByte, currentByte);
            
        }

        //ASCII Encoding
        public Color EncodeASCII(byte currentByte) {
            if ((currentByte < 32) || (currentByte > 127)) {
                return Color.Gray;
            } else{
                return Color.Blue;
            }
                return Color.FromArgb(0, currentByte, 0);
        }
        
        //Strings Encoding
        public Color EncodeStrings(byte currentByte) {
            return Color.Bisque;
        }

        //Frequency Encoding
        public Color EncodeFrequency(byte currentByte, float[] frequency) {
            if (frequency[currentByte] > 0.003) {
                return Color.Red; //hot
            } else {
                return Color.Blue; //cold
            }             
        }

        private void btnNormal_Click(object sender, EventArgs e) {
            colorMode = 0;
        }

        private void btnASCII_Click(object sender, EventArgs e) {
            colorMode = 1;
        }

        private void btnFrequency_Click(object sender, EventArgs e) {
            colorMode = 2;
        }

        private void btnInvert_Click(object sender, EventArgs e) {
            if (invert == 0) {
                invert = 1;
            } else {
                invert = 0;
            }
        }


       
    }
}
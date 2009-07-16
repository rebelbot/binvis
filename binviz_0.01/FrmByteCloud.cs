using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1 {
    public partial class FrmByteCloud : Form {
        public FrmByteCloud() {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {

        }

        public void plot(float[] frequency) {
            richTextBox1.Text = "";
            float[] freqThreshold = new float[8];
            int[] fontSize = new int[256];
            float[] sortedFrequency = new float[256];
            string tempString = "";

			
			

            for (int i = 0; i < 256; i++) {
                sortedFrequency[i] = frequency[i];
            }
            Array.Sort(sortedFrequency);
            
            //bucket the frequencies into eight buckets
            int index = 31;
            for (int f = 0; f < 8; f++) {
                freqThreshold[f] = sortedFrequency[index];
                index += 32;
            }

            //assign a reasonable font size for each of the eight buckets
            for (int s = 0; s < 256; s++) {
                for (int t = 7; t >=0; t--) {
                    if (frequency[s] < freqThreshold[t]) fontSize[s] = (t+1) * 4;
                }
            }
           
            for (int i=0; i < 256; i++) {
                if ((frequency[i] > 0)&&(fontSize[i]>0)) { //skip zero frequency
                    richTextBox1.SelectionFont = new Font("Courier", fontSize[i], FontStyle.Bold);
                    richTextBox1.SelectionColor = System.Drawing.Color.Green;
                    tempString = String.Format("{0:X2}", i) + " "; //convert to hex
                    Console.WriteLine(tempString + " ");
                    this.richTextBox1.SelectedText = tempString;
                    
                }
            }
        }

        private void FrmByteCloud_Load(object sender, EventArgs e) {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1
{
    public partial class FrmAddFilter : Form
    {
        FrmMemoryMap gParentHandle;
        int gFileSize;

        public FrmAddFilter()
        {
            InitializeComponent();
        }
        public void init(FrmMemoryMap parentHandle, int fileSize)
        {
          gParentHandle = parentHandle;
          gFileSize = fileSize;
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int mystart = int.Parse(textBox1.Text);
            int mystop = int.Parse(textBox2.Text);
            string note = textBox3.Text;

            //if ((mystop >= mystart) && (mystart >= 0) && (mystop <= gFileSize)) //check if values are within bounds
            if ((mystart >= 0) && (mystart <= gFileSize)) //check if values are within bounds
            {
                gParentHandle.addFilter(mystart, mystop, note);
                this.Close();
            }
            else //values were out of range
            {
                MessageBox.Show("Please check your start and stop values"); //inform/annoy the user
            }
            
        }

        private void FrmAddFilter_Load(object sender, EventArgs e)
        {

        }

        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1
{
    public partial class FrmText : Form
    {
        public FrmText()
        {
            InitializeComponent();
        }

        private void frmText_Load(object sender, EventArgs e)
        {
            Font f = new Font("Courier", 20);
            Console.WriteLine("Height " + f.Height.ToString());
            
        }

        private void frmText_Resize(object sender, EventArgs e)
        {

        }

        public void Plot(ref byte[] fileBufferArray, int fileSize, int offset)
        {
            Console.WriteLine("Text Font Height " + txtBox1.Font.GetHeight());
            Console.WriteLine("Text Box Height " + txtBox1.Height);
            String textData = "";
            this.txtBox1.Text = "";
            float totalHeight = 0;
            int position = offset;

            int hexColumns = 8;
            
            Console.WriteLine("offset = " + offset);
            
                while((totalHeight + txtBox1.Font.GetHeight()) < txtBox1.Height){
                {
                    textData += String.Format("{0:X8}", position) + "  ";
                    for (int column = 0; column < hexColumns; column++)
                    {
                        textData += String.Format("{0:X2}", fileBufferArray[position]) + " ";
                        if (position<fileSize) position++;
                    }

                    position -= hexColumns;
                    for (int column = 0; column < (hexColumns); column++)
                    {
                        if ((fileBufferArray[position] >= 32) && (fileBufferArray[position] <= 127))
                        {
                            textData += (char)fileBufferArray[position];
                        }
                        else
                        {
                            textData += ".";
                        }
                        position++;
                    }
                    
                    
                    textData += "\r\n";
                    totalHeight += txtBox1.Font.GetHeight();                    
                }
                }
                txtBox1.Text = textData;
                txtBox1.SelectionStart= txtBox1.Text.Length; //prevents text from being selected 
            
        }

        private void txtBox1_TextChanged(object sender, EventArgs e) {

        }

        
       
    }
}
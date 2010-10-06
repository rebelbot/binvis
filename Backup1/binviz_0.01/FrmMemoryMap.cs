using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace binviz_0._1
{
    public partial class FrmMemoryMap : Form
    {
       private int gFileSize;
       private FrmMain gFrmMain; //handle to the main form
        
       private struct MapMarker{
            public int start, stop;
            public string note;

            public void set(int localstart, int localstop, string localnote)
            {
                start = localstart;
                stop = localstop;
                note = localnote;
            }

            public string getLabel()
            {
                //return start.ToString() + "-" + stop + ":" + note + "\r\n";
                return start.ToString() + ": " + note + "\r\n";
            }
        }
        private static MapMarker[] mapMarker = new MapMarker[1000]; //max number of entries is 1000
        private static int numNotes = 0;

        public FrmMemoryMap()
        {
            InitializeComponent();
        }


        //Sorts the array of MapMarker by the starting value
        private void SortMapMarkers(){
            MapMarker tempMapMarker = new MapMarker();
            for (int i = 0; i <= numNotes; i++)
            {
                for (int j = 0; j < numNotes; j++)
                {
                    if (mapMarker[j].start > mapMarker[j + 1].start)
                    {
                        //swap
                        tempMapMarker = mapMarker[j];
                        mapMarker[j] = mapMarker[j + 1];
                        mapMarker[j + 1] = tempMapMarker;
                    }
                }
            }
        }



        // setup an empty memory map, this should be called once
        public void init(int filesize, FrmMain formMainHandle)
        {
            lstBoxLocations.Items.Add("0 \t<start of file>");
            mapMarker[numNotes].set(0, 0, "<start of file>");
            numNotes++;
            lstBoxLocations.Items.Add(filesize.ToString()+"\t<start of file>");
            mapMarker[numNotes].set(filesize, filesize, "<end of file>");
            numNotes++;
            updateDisplay();
            gFrmMain = formMainHandle;
            gFileSize = filesize;
        }

        private void addRecord(int startPosition, int stopPosition, string analystNote)
        {
            mapMarker[numNotes].set(startPosition, stopPosition, analystNote);
            SortMapMarkers();
            numNotes++;
        }

        

        // clears the list of filters and redraws
        // I used .Add, but .Insert might prove better
        private void updateDisplay()
        {
            lstBoxLocations.Items.Clear(); //empty the list of filters 
            for (int i = 0; i < numNotes; i++)
            {
                lstBoxLocations.Items.Add(mapMarker[i].getLabel());
            }
        }

        // Called from the add filter form
        // used to new filter to array of filters
        // note that the add filter form checks that start and stop values are 
        // within allowable ranges
        public void addFilter(int mystart, int mystop, string mynote)
        {
            addRecord(mystart, mystop, mynote);
            updateDisplay();            
        }

        //remove a filter
        private void deleteFilter(int location)
        {
            mapMarker[location].set(gFileSize+1,gFileSize+1, "deleted"); //add record
            SortMapMarkers(); //sort records, record to deleted will be at position numNotes;
            numNotes--; //decrease numNotes, effectively removing the record
            //updateDisplay(); //refresh display
        }
        
        // Calls the add filter form which prompts the user to enter a filter's values
        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            FrmAddFilter frmAddFilter = new FrmAddFilter();
            frmAddFilter.MdiParent = this.ParentForm;
            frmAddFilter.init(this,gFileSize);
            frmAddFilter.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstBoxLocations.SelectedIndex >= 0)
            {
                deleteFilter(lstBoxLocations.SelectedIndex); 
                lstBoxLocations.Items.RemoveAt(lstBoxLocations.SelectedIndex); //check is to prevent deletion with zero items 
                updateDisplay();        
            }
        }

        //private void chkListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    if (lstBoxLocations.SelectedIndex != null)
        //    {
        //        if (gFrmMain != null)
        //        {
        //            gFrmMain.redrawText(mapMarker[lstBoxLocations.SelectedIndex].start);
        //            gFrmMain.JumpAndRedraw(mapMarker[lstBoxLocations.SelectedIndex].start); 
        //        }
        //    }
        //}

        private void FrmMemoryMap_Load(object sender, EventArgs e)
        {
            
        }

        private void lstBoxLocations_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstBoxLocations_DoubleClick(object sender, EventArgs e)
        {
            if (lstBoxLocations.SelectedIndex != null)
            {
                if (gFrmMain != null)
                {
                    Console.WriteLine("bingo "+lstBoxLocations.SelectedIndex.ToString());
                    gFrmMain.redrawText(mapMarker[lstBoxLocations.SelectedIndex].start);
                    gFrmMain.JumpAndRedraw(mapMarker[lstBoxLocations.SelectedIndex].start);
                }
            }
            else
            {
                Console.WriteLine("null selected index");
            }
        }

        
                             
    }
}
//    chkListBox.SetItemChecked(1, true);
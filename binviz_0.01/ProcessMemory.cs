using System;
using System.Collections.Generic;
using System.Text;

namespace binviz_0._1
{
    class ProcessMemory
    {
        int textLocation = 0;
        int textLength = 0;
        int textRun = 0;

        internal void Process(int fileLength, ref byte[] fileBufferArray)
        {

            for (int i=0; i<fileLength; i++){
            CalcText(i, ref fileBufferArray);
            //CalcSame();
            }

        }

        private void CalcText(int location, ref byte[]  fileBufferArray){

            if (((fileBufferArray[location] >= 65) && (fileBufferArray[location] <= 90)) ||
                ((fileBufferArray[location] >= 97) && (fileBufferArray[location] <= 122)))
            {
                if (textRun < 10)
                {
                    textRun++;
                }
                textLength++;
            }
            {
                textRun--;
            }
        }
    }
}

namespace binviz_0._1
{
    internal class ProcessMemory
    {
        private int textLength;
        private int textLocation;
        private int textRun;

        internal void Process(int fileLength, ref byte[] fileBufferArray)
        {
            for (int i = 0; i < fileLength; i++)
            {
                CalcText(i, ref fileBufferArray);
                //CalcSame();
            }
        }

        private void CalcText(int location, ref byte[] fileBufferArray)
        {
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
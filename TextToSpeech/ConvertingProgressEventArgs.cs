using System;

namespace TextToSpeech
{
    public class СonvertingProgressEventArgs : EventArgs
    {
        public int ConvertedSlices { get; set; }
        public int SlicesCount { get; set; }

        public СonvertingProgressEventArgs(int convertedSlices, int slicesCount)
        {
            ConvertedSlices = convertedSlices;
            SlicesCount = slicesCount;
        }        
    }
}

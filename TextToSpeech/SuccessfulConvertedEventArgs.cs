using System;

namespace TextToSpeech
{
    public class SuccessfulConvertedEventArgs : EventArgs
    {
        public byte[] Result { get; set; }

        public SuccessfulConvertedEventArgs(byte[] speech)
        {
            Result = speech;
        }
    }
}

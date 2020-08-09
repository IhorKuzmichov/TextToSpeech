using System;

namespace TextToSpeech
{
    public class ConvertingErrorEventArgs : EventArgs
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }

        public ConvertingErrorEventArgs(Exception exception)
        {            
            Exception = exception;
            Message = exception.Message;
        }
    }
}

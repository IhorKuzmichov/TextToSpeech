using NAudio.Wave;
using System;
using System.IO;

namespace TextToSpeech
{
    static class AudioConcatenateHelper
    {
        public static byte[] ConcatenateWav(byte[][] input)
        {
            WaveFileWriter waveFileWriter = null;
            var outputStream = new MemoryStream();

            try
            {
                foreach (var source in input)
                {
                    using (var reader = new WaveFileReader(new MemoryStream(source)))
                    {
                        if (waveFileWriter == null)
                        {
                            // first time in create new Writer
                            waveFileWriter = new WaveFileWriter(outputStream, reader.WaveFormat);
                        }
                        else if (!reader.WaveFormat.Equals(waveFileWriter.WaveFormat))
                        {
                            throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
                        }

                        byte[] buffer = new byte[1024];
                        int read = reader.Read(buffer, 0, buffer.Length);

                        while (read > 0)
                        {
                            waveFileWriter.Write(buffer, 0, read);
                            read = reader.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
            finally
            {
                if (waveFileWriter != null)
                {
                    waveFileWriter.Dispose();
                }
            }

            return outputStream.ToArray();
        }

        public static byte[] ConcatenateMp3(byte[][] input)
        {
            var outputStream = new MemoryStream();

            foreach (var sources in input)
            {
                var reader = new Mp3FileReader(new MemoryStream(sources));

                if ((outputStream.Position == 0) && (reader.Id3v2Tag != null))
                {
                    outputStream.Write(reader.Id3v2Tag.RawData, 0, reader.Id3v2Tag.RawData.Length);
                }

                Mp3Frame frame;

                while ((frame = reader.ReadNextFrame()) != null)
                {
                    outputStream.Write(frame.RawData, 0, frame.RawData.Length);
                }
            }

            return outputStream.ToArray();
        }
    }
}

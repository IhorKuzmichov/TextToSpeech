using System;
using System.Linq;
using System.IO;
using System.Net;
using NAudio.Wave;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TextToSpeech
{
    public class TextToSpeechConverter
    {
        #region private_fields
        private const int maxSliceLength = 500;

        private TextToSpeechConverterSettings settings;
        #endregion

        #region public_fields
        public const string Pause = " - ";
        public const string NewLine = "\n";
                
        public TextToSpeechConverterSettings Settings
        {
            get
            {
                return settings;
            }

            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(settings));

                settings = value;
            }
        }
        #endregion

        #region events
        public event EventHandler<СonvertingProgressEventArgs> OnProgress = null;
        public event EventHandler<ConvertingErrorEventArgs> OnError = null;
        public event EventHandler<SuccessfulConvertedEventArgs> OnSuccessfulConverted = null;
        #endregion

        #region constructors
        public TextToSpeechConverter(TextToSpeechConverterSettings settings)
        {
            Settings = settings;
        }

        public TextToSpeechConverter() : this(new TextToSpeechConverterSettings())
        {            
        }

        #endregion

        #region private_methods
        private string[] SplitTextOnSlices(string escapedText, int maxSliceLength)
        {
            if (escapedText.Length <= maxSliceLength + 1)
                return new string[] { escapedText };

            var firstSlice = escapedText.Substring(0, maxSliceLength + 1);

            var firstSliceSeparators = firstSlice
                .Select((symbol, index) => (symbol, index))
                .Where((symbol) =>
                    symbol.index <= maxSliceLength &&
                    (char.IsPunctuation(symbol.symbol) || char.IsSeparator(symbol.symbol))
                );

            if (firstSliceSeparators.Count() > 0)
            {
                var firstSlicePunctuation = firstSliceSeparators
                    .Where(symbol => char.IsPunctuation(symbol.symbol));

                var firstSliceSentenceEndSymbols = firstSlicePunctuation
                    .Where(symbol => char.ToString(symbol.symbol).IndexOfAny(new char[] { '.', '!', '?' }) >= 0);

                int lastSeparatorIndex;

                if (firstSlicePunctuation.Count() > 0)
                    lastSeparatorIndex = firstSlicePunctuation.Last().index;
                else if (firstSlicePunctuation.Count() > 0)
                    lastSeparatorIndex = firstSlicePunctuation.Last().index;
                else
                    lastSeparatorIndex = firstSliceSeparators.Last().index;

                return new string[] { firstSlice.Substring(0, lastSeparatorIndex) }
                    .Concat(SplitTextOnSlices(escapedText.Substring(lastSeparatorIndex + 1), maxSliceLength))
                    .ToArray();
            }
            else
            {
                return new string[] { firstSlice.Substring(0, maxSliceLength) }
                    .Concat(SplitTextOnSlices(escapedText.Substring(maxSliceLength), maxSliceLength))
                    .ToArray();
            }
        }

        private string GenerateUrl(string text, TextToSpeechConverterSettings settings)
        {            
            string speedUriString       = settings.Speed.ToString().Replace(",", ".");
            string emotionUriString     = settings.Emotion.ToString().ToLower();
            string speakerUriString     = settings.Speaker.ToString().ToLower();
            string audioFormatUriString = settings.AudioFormat.ToString().ToLower();
            string languageUriString;

            switch (settings.Language)
            {
                case Languages.Ru: languageUriString = "ru-RU"; break;
                case Languages.En: languageUriString = "en-US"; break;
                case Languages.Ua: languageUriString = "uk-UA"; break;
                case Languages.Tr: languageUriString = "tr-TR"; break;
                default: throw new ArgumentException(nameof(settings.Language));
            }

            var url = "https://apihost.ru/php/app.php?" +
                $"&text={Uri.EscapeDataString(text)}" +
                $"&speed={speedUriString}" +
                $"&lang={languageUriString}" +
                $"&emotion={emotionUriString}" +
                $"&speaker={speakerUriString}" +
                $"&format={audioFormatUriString}";

            return url;
        }

        private async Task<byte[]> ShortTextToSpeechAsync(string text, TextToSpeechConverterSettings settings)
        {
            var uri = new Uri(GenerateUrl(text, settings));

            using (var webClient = new WebClient())
            {
                return await webClient.DownloadDataTaskAsync(uri);
            }
        }

        private async Task<byte[]> TextToSpeechAsync(string[] textSlices, TextToSpeechConverterSettings settings)
        {
            var speeches = new List<byte[]>(textSlices.Length);

            for (int i = 0; i < textSlices.Length; i++)
            {
                byte[] data;

                try
                {
                    data = await ShortTextToSpeechAsync(textSlices[i], settings);
                }
                catch (Exception exception)
                {
                    OnError?.Invoke(this, new ConvertingErrorEventArgs(exception));
                    return null;
                }

                speeches.Add(data);

                OnProgress?.Invoke(this, new СonvertingProgressEventArgs(i + 1, textSlices.Length));
            }

            if (settings.AudioFormat == AudioFormats.Wav)
                return AudioConcatenateHelper.ConcatenateWav(speeches.ToArray());
            else if (settings.AudioFormat == AudioFormats.Mp3)
                return AudioConcatenateHelper.ConcatenateMp3(speeches.ToArray());
            else
                throw new ArgumentException(nameof(settings.AudioFormat));
        }
        #endregion

        #region public_methods
        public byte[] TextToSpeech(string text)
        {
            return TextToSpeechAsync(text).Result;
        }

        public async Task<byte[]> TextToSpeechAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException(nameof(text));

            var textSlices = SplitTextOnSlices(text, maxSliceLength);
            var speech = await TextToSpeechAsync(textSlices, Settings);

            if (speech != null)
                OnSuccessfulConverted?.Invoke(this, new SuccessfulConvertedEventArgs(speech));

            return speech;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextToSpeech
{
    public class TextToSpeechConverterSettings
    {
        private float speed;

        public float Speed
        {
            get
            {
                return speed;
            }

            set
            {
                if (speed < 0)
                    throw new ArgumentOutOfRangeException(nameof(speed));

                speed = value;
            }
        }
        public Languages Language { get; set; }
        public Emotions Emotion { get; set; }
        public Speakers Speaker { get; set; }
        public AudioFormats AudioFormat { get; set; }

        public TextToSpeechConverterSettings()
        {
            Speed       = 1;
            Language    = Languages.Ru;
            Emotion     = Emotions.Neutral;
            Speaker     = Speakers.Ermilov;
            AudioFormat = AudioFormats.Mp3;
        }
    }
}

using System;
using System.IO;
using System.Windows.Forms;
using TextToSpeech;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            VoicesList.SelectedIndex = 0;
            EmotionsList.SelectedIndex = 0;
            LanguagesList.SelectedIndex = 0;
            AudioFormatsList.SelectedIndex = 0;
        }


        private string GetSpeechSaveFilepath()
        {
            var filename = FilenameWithoutExtensionText.Text + AudioFormatsList.Text;
            return Path.Combine(FolderPathText.Text, filename);
        }


        private async void SaveButton_Click(object sender, EventArgs e)
        {
            var filepath = GetSpeechSaveFilepath();
            var filename = Path.GetFileName(filepath);

            if (filename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0 || string.IsNullOrEmpty(filename))
            {
                MessageBox.Show("Некорректное имя файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (File.Exists(filepath))
            {
                var dialogText = "Файл по данному пути существует и будет заменён на новый";
                var dialogResult = MessageBox.Show(dialogText, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dialogResult != DialogResult.OK)
                    return;
            }

            SaveButton.Enabled = false;
            ConvertingProgressBar.Enabled = true;

            var textToSpeech = TextToSpeech.Text
                .Replace(Environment.NewLine, TextToSpeechConverter.NewLine)
                .Replace("  ", " ");

            var converterSettings = new TextToSpeechConverterSettings()
            {
                Speed = (float)VoiceSpeed.Value,
                Speaker = (Speakers)VoicesList.SelectedIndex,
                Emotion = (Emotions)EmotionsList.SelectedIndex,
                Language = (Languages)LanguagesList.SelectedIndex,
                AudioFormat = (AudioFormats)AudioFormatsList.SelectedIndex,
            };
            var converter = new TextToSpeechConverter(converterSettings);
            converter.OnProgress += TextToSpeechConverter_OnProgress;
            converter.OnError += TextToSpeechConverter_OnError;
            converter.OnSuccessfulConverted += TextToSpeechConverter_OnSuccessfulConverted;

            try
            {
                var file = File.OpenWrite(filepath);
                file.Close();                                
            }
            catch (Exception)
            {
                MessageBox.Show("По данному пути не удастся сохранить файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                await converter.TextToSpeechAsync(textToSpeech);

                ConvertingProgressBar.Value = ConvertingProgressBar.Minimum;
                SaveButton.Enabled = true;
            }
        }

        private void FolderDialogButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
                FolderPathText.Text = dialog.SelectedPath;
        }


        private void TextToSpeechConverter_OnProgress(object sender, СonvertingProgressEventArgs args)
        {
            double step = ConvertingProgressBar.Maximum / args.SlicesCount;

            if (args.ConvertedSlices == args.SlicesCount)
                ConvertingProgressBar.Value = ConvertingProgressBar.Maximum;
            else
                ConvertingProgressBar.Value = (int)(args.ConvertedSlices * step);
        }

        private void TextToSpeechConverter_OnError(object sender, ConvertingErrorEventArgs args)
        {
            if (HelpClass.IsConnectedToInternet() == false)
                MessageBox.Show("Нет подключения к интернету", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("При преобразовании произошла неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TextToSpeechConverter_OnSuccessfulConverted(object sender, SuccessfulConvertedEventArgs args)
        {
            try
            {
                File.WriteAllBytes(GetSpeechSaveFilepath(), args.Result);
                MessageBox.Show("Текст успешно преобразован и сохранён", "Готово");
            }
            catch (Exception exception)
            {
                MessageBox.Show("При сохранении произошла неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextToSpeech = new System.Windows.Forms.TextBox();
            this.FolderPathText = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.VoiceSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VoicesList = new System.Windows.Forms.ComboBox();
            this.EmotionsList = new System.Windows.Forms.ComboBox();
            this.LanguagesList = new System.Windows.Forms.ComboBox();
            this.AudioFormatsList = new System.Windows.Forms.ComboBox();
            this.FolderDialogButton = new System.Windows.Forms.Button();
            this.FilenameWithoutExtensionText = new System.Windows.Forms.TextBox();
            this.ConvertingProgressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // TextToSpeech
            // 
            this.TextToSpeech.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextToSpeech.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TextToSpeech.Location = new System.Drawing.Point(12, 100);
            this.TextToSpeech.Multiline = true;
            this.TextToSpeech.Name = "TextToSpeech";
            this.TextToSpeech.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextToSpeech.Size = new System.Drawing.Size(776, 338);
            this.TextToSpeech.TabIndex = 0;
            this.TextToSpeech.Text = "Текст";
            // 
            // FolderPathText
            // 
            this.FolderPathText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderPathText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.FolderPathText.Location = new System.Drawing.Point(12, 12);
            this.FolderPathText.Name = "FolderPathText";
            this.FolderPathText.ReadOnly = true;
            this.FolderPathText.Size = new System.Drawing.Size(332, 36);
            this.FolderPathText.TabIndex = 1;
            this.FolderPathText.Text = "C:\\Users\\User\\Downloads";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SaveButton.Location = new System.Drawing.Point(650, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(138, 36);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // VoiceSpeed
            // 
            this.VoiceSpeed.DecimalPlaces = 1;
            this.VoiceSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.VoiceSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.VoiceSpeed.Location = new System.Drawing.Point(119, 59);
            this.VoiceSpeed.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.VoiceSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.VoiceSpeed.Name = "VoiceSpeed";
            this.VoiceSpeed.Size = new System.Drawing.Size(59, 30);
            this.VoiceSpeed.TabIndex = 3;
            this.VoiceSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(7, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Скорость:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(194, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Голос:";
            // 
            // VoicesList
            // 
            this.VoicesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VoicesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.VoicesList.FormattingEnabled = true;
            this.VoicesList.Items.AddRange(new object[] {
            "Ermilov",
            "Silaerkan",
            "Anton_Samokhvalov",
            "Tanya",
            "Smoky",
            "Zombie",
            "Oksana",
            "Jane",
            "Omazh",
            "Kolya",
            "Kostya",
            "Nastya",
            "Sasha",
            "Nick",
            "Erkanyavas",
            "Zhenya",
            "Tatyana_Abramova",
            "Voicesearch",
            "Alyss",
            "Ermil_With_Tuning",
            "Robot",
            "Dude",
            "Levitan"});
            this.VoicesList.Location = new System.Drawing.Point(274, 58);
            this.VoicesList.Name = "VoicesList";
            this.VoicesList.Size = new System.Drawing.Size(210, 33);
            this.VoicesList.TabIndex = 6;
            // 
            // EmotionsList
            // 
            this.EmotionsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmotionsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.EmotionsList.FormattingEnabled = true;
            this.EmotionsList.Items.AddRange(new object[] {
            "Нейтральный",
            "Добрый",
            "Злой"});
            this.EmotionsList.Location = new System.Drawing.Point(490, 58);
            this.EmotionsList.Name = "EmotionsList";
            this.EmotionsList.Size = new System.Drawing.Size(154, 33);
            this.EmotionsList.TabIndex = 8;
            // 
            // LanguagesList
            // 
            this.LanguagesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguagesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LanguagesList.FormattingEnabled = true;
            this.LanguagesList.Items.AddRange(new object[] {
            "Русский",
            "Английский",
            "Украинский",
            "Турецкий"});
            this.LanguagesList.Location = new System.Drawing.Point(650, 58);
            this.LanguagesList.Name = "LanguagesList";
            this.LanguagesList.Size = new System.Drawing.Size(138, 33);
            this.LanguagesList.TabIndex = 9;
            // 
            // AudioFormatsList
            // 
            this.AudioFormatsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioFormatsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AudioFormatsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AudioFormatsList.FormattingEnabled = true;
            this.AudioFormatsList.Items.AddRange(new object[] {
            ".mp3",
            ".wav"});
            this.AudioFormatsList.Location = new System.Drawing.Point(557, 14);
            this.AudioFormatsList.Name = "AudioFormatsList";
            this.AudioFormatsList.Size = new System.Drawing.Size(87, 33);
            this.AudioFormatsList.TabIndex = 10;
            // 
            // FolderDialogButton
            // 
            this.FolderDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.FolderDialogButton.Location = new System.Drawing.Point(350, 12);
            this.FolderDialogButton.Name = "FolderDialogButton";
            this.FolderDialogButton.Size = new System.Drawing.Size(44, 36);
            this.FolderDialogButton.TabIndex = 11;
            this.FolderDialogButton.Text = "...";
            this.FolderDialogButton.UseVisualStyleBackColor = true;
            this.FolderDialogButton.Click += new System.EventHandler(this.FolderDialogButton_Click);
            // 
            // FilenameWithoutExtensionText
            // 
            this.FilenameWithoutExtensionText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FilenameWithoutExtensionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.FilenameWithoutExtensionText.Location = new System.Drawing.Point(400, 12);
            this.FilenameWithoutExtensionText.Name = "FilenameWithoutExtensionText";
            this.FilenameWithoutExtensionText.Size = new System.Drawing.Size(151, 36);
            this.FilenameWithoutExtensionText.TabIndex = 12;
            this.FilenameWithoutExtensionText.Text = "voice";
            // 
            // ConvertingProgressBar
            // 
            this.ConvertingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConvertingProgressBar.Enabled = false;
            this.ConvertingProgressBar.Location = new System.Drawing.Point(165, 444);
            this.ConvertingProgressBar.Maximum = 10000;
            this.ConvertingProgressBar.Name = "ConvertingProgressBar";
            this.ConvertingProgressBar.Size = new System.Drawing.Size(623, 35);
            this.ConvertingProgressBar.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(12, 447);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Обработка:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 491);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConvertingProgressBar);
            this.Controls.Add(this.FilenameWithoutExtensionText);
            this.Controls.Add(this.FolderDialogButton);
            this.Controls.Add(this.AudioFormatsList);
            this.Controls.Add(this.LanguagesList);
            this.Controls.Add(this.EmotionsList);
            this.Controls.Add(this.VoicesList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VoiceSpeed);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.FolderPathText);
            this.Controls.Add(this.TextToSpeech);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.MinimumSize = new System.Drawing.Size(818, 538);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Озвучка текста";
            ((System.ComponentModel.ISupportInitialize)(this.VoiceSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextToSpeech;
        private System.Windows.Forms.TextBox FolderPathText;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.NumericUpDown VoiceSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox VoicesList;
        private System.Windows.Forms.ComboBox EmotionsList;
        private System.Windows.Forms.ComboBox LanguagesList;
        private System.Windows.Forms.ComboBox AudioFormatsList;
        private System.Windows.Forms.Button FolderDialogButton;
        private System.Windows.Forms.TextBox FilenameWithoutExtensionText;
        private System.Windows.Forms.ProgressBar ConvertingProgressBar;
        private System.Windows.Forms.Label label3;
    }
}


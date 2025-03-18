using DarkUI.Controls;

namespace NfhSpritesConverter
{
    partial class MainConverterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainConverterForm));
            listBoxResults = new System.Windows.Forms.ListBox();
            textBoxFolderPathPng = new DarkTextBox();
            buttonConvertPngToTga = new DarkButton();
            buttonConvertTgaToPng = new DarkButton();
            textBoxFolderPathTga = new DarkTextBox();
            GOPNG = new DarkButton();
            GOTGA = new DarkButton();
            label1 = new DarkLabel();
            label2 = new DarkLabel();
            groupBox1 = new DarkGroupBox();
            Keep = new DarkRadioButton();
            Delete = new DarkRadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxResults
            // 
            listBoxResults.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listBoxResults.BackColor = System.Drawing.SystemColors.WindowFrame;
            listBoxResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listBoxResults.ForeColor = System.Drawing.SystemColors.Info;
            listBoxResults.FormattingEnabled = true;
            listBoxResults.Location = new System.Drawing.Point(500, 60);
            listBoxResults.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listBoxResults.Name = "listBoxResults";
            listBoxResults.Size = new System.Drawing.Size(578, 497);
            listBoxResults.TabIndex = 0;
            // 
            // textBoxFolderPathPng
            // 
            textBoxFolderPathPng.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
            textBoxFolderPathPng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBoxFolderPathPng.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            textBoxFolderPathPng.Location = new System.Drawing.Point(37, 82);
            textBoxFolderPathPng.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxFolderPathPng.Name = "textBoxFolderPathPng";
            textBoxFolderPathPng.Size = new System.Drawing.Size(344, 23);
            textBoxFolderPathPng.TabIndex = 1;
            // 
            // buttonConvertPngToTga
            // 
            buttonConvertPngToTga.Location = new System.Drawing.Point(37, 112);
            buttonConvertPngToTga.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonConvertPngToTga.Name = "buttonConvertPngToTga";
            buttonConvertPngToTga.Padding = new System.Windows.Forms.Padding(5);
            buttonConvertPngToTga.Size = new System.Drawing.Size(344, 61);
            buttonConvertPngToTga.TabIndex = 2;
            buttonConvertPngToTga.Text = "Convert To Tga";
            buttonConvertPngToTga.Click += buttonConvertPngToTga_Click;
            // 
            // buttonConvertTgaToPng
            // 
            buttonConvertTgaToPng.Location = new System.Drawing.Point(37, 330);
            buttonConvertTgaToPng.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonConvertTgaToPng.Name = "buttonConvertTgaToPng";
            buttonConvertTgaToPng.Padding = new System.Windows.Forms.Padding(5);
            buttonConvertTgaToPng.Size = new System.Drawing.Size(344, 61);
            buttonConvertTgaToPng.TabIndex = 4;
            buttonConvertTgaToPng.Text = "Convert To Png";
            buttonConvertTgaToPng.Click += buttonConvertTgaToPng_Click;
            // 
            // textBoxFolderPathTga
            // 
            textBoxFolderPathTga.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
            textBoxFolderPathTga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBoxFolderPathTga.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            textBoxFolderPathTga.Location = new System.Drawing.Point(37, 300);
            textBoxFolderPathTga.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxFolderPathTga.Name = "textBoxFolderPathTga";
            textBoxFolderPathTga.Size = new System.Drawing.Size(344, 23);
            textBoxFolderPathTga.TabIndex = 3;
            // 
            // GOPNG
            // 
            GOPNG.Location = new System.Drawing.Point(390, 298);
            GOPNG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            GOPNG.Name = "GOPNG";
            GOPNG.Padding = new System.Windows.Forms.Padding(5);
            GOPNG.Size = new System.Drawing.Size(88, 27);
            GOPNG.TabIndex = 5;
            GOPNG.Text = "Run";
            GOPNG.Click += GOPNG_Click;
            // 
            // GOTGA
            // 
            GOTGA.Location = new System.Drawing.Point(390, 78);
            GOTGA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            GOTGA.Name = "GOTGA";
            GOTGA.Padding = new System.Windows.Forms.Padding(5);
            GOTGA.Size = new System.Drawing.Size(88, 27);
            GOTGA.TabIndex = 6;
            GOTGA.Text = "Run";
            GOTGA.Click += GOTGA_Click;
            // 
            // label1
            // 
            label1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            label1.Location = new System.Drawing.Point(152, 58);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(113, 15);
            label1.TabIndex = 7;
            label1.Text = "Path to PNG images";
            // 
            // label2
            // 
            label2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            label2.Location = new System.Drawing.Point(152, 282);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(110, 15);
            label2.TabIndex = 8;
            label2.Text = "Path to TGA images";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Keep);
            groupBox1.Controls.Add(Delete);
            groupBox1.Location = new System.Drawing.Point(37, 398);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(154, 69);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // Keep
            // 
            Keep.AutoSize = true;
            Keep.Location = new System.Drawing.Point(7, 38);
            Keep.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Keep.Name = "Keep";
            Keep.Size = new System.Drawing.Size(122, 19);
            Keep.TabIndex = 1;
            Keep.TabStop = true;
            Keep.Text = "Keep Original Files";
            // 
            // Delete
            // 
            Delete.AutoSize = true;
            Delete.Checked = true;
            Delete.Location = new System.Drawing.Point(7, 12);
            Delete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Delete.Name = "Delete";
            Delete.Size = new System.Drawing.Size(129, 19);
            Delete.TabIndex = 0;
            Delete.TabStop = true;
            Delete.Text = "Delete Original Files";
            // 
            // MainConverterForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1176, 734);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(GOTGA);
            Controls.Add(GOPNG);
            Controls.Add(buttonConvertTgaToPng);
            Controls.Add(textBoxFolderPathTga);
            Controls.Add(buttonConvertPngToTga);
            Controls.Add(textBoxFolderPathPng);
            Controls.Add(listBoxResults);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MainConverterForm";
            Text = "NFH Sprites Converter v 2.4.8 | By VanyaB | Thanks mankey";
            TitleBarStyle = DarkTitleBarStyle.Standard;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox listBoxResults;
        private DarkUI.Controls.DarkButton darkButton1;
        private DarkUI.Controls.DarkTextBox darkTextBox1;
        private DarkUI.Controls.DarkGroupBox darkGroupBox1;
        private DarkUI.Controls.DarkButton buttonConvertPngToTga;
        private DarkUI.Controls.DarkButton buttonConvertTgaToPng;
        private DarkUI.Controls.DarkButton GOPNG;
        private DarkUI.Controls.DarkButton GOTGA;
        private DarkUI.Controls.DarkTextBox textBoxFolderPathPng;
        private DarkUI.Controls.DarkTextBox textBoxFolderPathTga;
        private DarkUI.Controls.DarkGroupBox groupBox1;
        private DarkUI.Controls.DarkRadioButton Delete;
        private DarkLabel label2;
        private DarkLabel label1;
        private DarkRadioButton Keep;
    }
}


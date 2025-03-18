namespace PngToTgaConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.textBoxFolderPathPng = new System.Windows.Forms.TextBox();
            this.buttonConvertPngToTga = new System.Windows.Forms.Button();
            this.buttonConvertTgaToPng = new System.Windows.Forms.Button();
            this.textBoxFolderPathTga = new System.Windows.Forms.TextBox();
            this.GOPNG = new System.Windows.Forms.Button();
            this.GOTGA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Keep = new System.Windows.Forms.RadioButton();
            this.Delete = new System.Windows.Forms.RadioButton();
            this.textBoxROffset = new System.Windows.Forms.TextBox();
            this.textBoxGOffset = new System.Windows.Forms.TextBox();
            this.textBoxBOffset = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.Location = new System.Drawing.Point(430, 50);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(338, 355);
            this.listBoxResults.TabIndex = 0;
            // 
            // textBoxFolderPathPng
            // 
            this.textBoxFolderPathPng.Location = new System.Drawing.Point(32, 71);
            this.textBoxFolderPathPng.Name = "textBoxFolderPathPng";
            this.textBoxFolderPathPng.Size = new System.Drawing.Size(295, 20);
            this.textBoxFolderPathPng.TabIndex = 1;
            // 
            // buttonConvertPngToTga
            // 
            this.buttonConvertPngToTga.Location = new System.Drawing.Point(32, 97);
            this.buttonConvertPngToTga.Name = "buttonConvertPngToTga";
            this.buttonConvertPngToTga.Size = new System.Drawing.Size(295, 53);
            this.buttonConvertPngToTga.TabIndex = 2;
            this.buttonConvertPngToTga.Text = "Convert To Tga";
            this.buttonConvertPngToTga.UseVisualStyleBackColor = true;
            this.buttonConvertPngToTga.Click += new System.EventHandler(this.buttonConvertPngToTga_Click_1);
            // 
            // buttonConvertTgaToPng
            // 
            this.buttonConvertTgaToPng.Location = new System.Drawing.Point(32, 286);
            this.buttonConvertTgaToPng.Name = "buttonConvertTgaToPng";
            this.buttonConvertTgaToPng.Size = new System.Drawing.Size(295, 53);
            this.buttonConvertTgaToPng.TabIndex = 4;
            this.buttonConvertTgaToPng.Text = "Convert To Png";
            this.buttonConvertTgaToPng.UseVisualStyleBackColor = true;
            this.buttonConvertTgaToPng.Click += new System.EventHandler(this.buttonConvertTgaToPng_Click_1);
            // 
            // textBoxFolderPathTga
            // 
            this.textBoxFolderPathTga.Location = new System.Drawing.Point(32, 260);
            this.textBoxFolderPathTga.Name = "textBoxFolderPathTga";
            this.textBoxFolderPathTga.Size = new System.Drawing.Size(295, 20);
            this.textBoxFolderPathTga.TabIndex = 3;
            // 
            // GOPNG
            // 
            this.GOPNG.Location = new System.Drawing.Point(334, 258);
            this.GOPNG.Name = "GOPNG";
            this.GOPNG.Size = new System.Drawing.Size(75, 23);
            this.GOPNG.TabIndex = 5;
            this.GOPNG.Text = "Run";
            this.GOPNG.UseVisualStyleBackColor = true;
            this.GOPNG.Click += new System.EventHandler(this.GOPNG_Click);
            // 
            // GOTGA
            // 
            this.GOTGA.Location = new System.Drawing.Point(334, 68);
            this.GOTGA.Name = "GOTGA";
            this.GOTGA.Size = new System.Drawing.Size(75, 23);
            this.GOTGA.TabIndex = 6;
            this.GOTGA.Text = "Run";
            this.GOTGA.UseVisualStyleBackColor = true;
            this.GOTGA.Click += new System.EventHandler(this.GOTGA_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Path to PNG images";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Path to TGA images";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Keep);
            this.groupBox1.Controls.Add(this.Delete);
            this.groupBox1.Location = new System.Drawing.Point(32, 345);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // Keep
            // 
            this.Keep.AutoSize = true;
            this.Keep.Location = new System.Drawing.Point(6, 33);
            this.Keep.Name = "Keep";
            this.Keep.Size = new System.Drawing.Size(112, 17);
            this.Keep.TabIndex = 1;
            this.Keep.TabStop = true;
            this.Keep.Text = "Keep Original Files";
            this.Keep.UseVisualStyleBackColor = true;
            // 
            // Delete
            // 
            this.Delete.AutoSize = true;
            this.Delete.Location = new System.Drawing.Point(6, 10);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(118, 17);
            this.Delete.TabIndex = 0;
            this.Delete.TabStop = true;
            this.Delete.Text = "Delete Original Files";
            this.Delete.UseVisualStyleBackColor = true;
            // 
            // textBoxROffset
            // 
            this.textBoxROffset.Location = new System.Drawing.Point(32, 187);
            this.textBoxROffset.Name = "textBoxROffset";
            this.textBoxROffset.Size = new System.Drawing.Size(84, 20);
            this.textBoxROffset.TabIndex = 9;
            // 
            // textBoxGOffset
            // 
            this.textBoxGOffset.Location = new System.Drawing.Point(138, 187);
            this.textBoxGOffset.Name = "textBoxGOffset";
            this.textBoxGOffset.Size = new System.Drawing.Size(84, 20);
            this.textBoxGOffset.TabIndex = 10;
            // 
            // textBoxBOffset
            // 
            this.textBoxBOffset.Location = new System.Drawing.Point(243, 187);
            this.textBoxBOffset.Name = "textBoxBOffset";
            this.textBoxBOffset.Size = new System.Drawing.Size(84, 20);
            this.textBoxBOffset.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxBOffset);
            this.Controls.Add(this.textBoxGOffset);
            this.Controls.Add(this.textBoxROffset);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GOTGA);
            this.Controls.Add(this.GOPNG);
            this.Controls.Add(this.buttonConvertTgaToPng);
            this.Controls.Add(this.textBoxFolderPathTga);
            this.Controls.Add(this.buttonConvertPngToTga);
            this.Controls.Add(this.textBoxFolderPathPng);
            this.Controls.Add(this.listBoxResults);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "NFH Sprites Converter v 1.0.1 By VanyaB";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.TextBox textBoxFolderPathPng;
        private System.Windows.Forms.Button buttonConvertPngToTga;
        private System.Windows.Forms.Button buttonConvertTgaToPng;
        private System.Windows.Forms.TextBox textBoxFolderPathTga;
        private System.Windows.Forms.Button GOPNG;
        private System.Windows.Forms.Button GOTGA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Delete;
        private System.Windows.Forms.RadioButton Keep;
        private System.Windows.Forms.TextBox textBoxROffset;
        private System.Windows.Forms.TextBox textBoxGOffset;
        private System.Windows.Forms.TextBox textBoxBOffset;
    }
}


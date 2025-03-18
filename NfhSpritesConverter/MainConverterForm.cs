using DarkUI.Forms;
using System;
using System.IO;
using System.Windows.Forms;

namespace NfhSpritesConverter
{
    public partial class MainConverterForm : DarkForm
    {

        /*
            Neighbors From Hell Sprites Converter
            Current Version: 2.4.8
            ----------------------------
            Originally created by: (? Unknown)
            Ported by: Vanya B (AKA NarkoLis, AKA UpDown LeftRight)
            ----------------------------
            This utility converts sprites from the game "Neighbors From Hell" into PNG and TGA formats,
            with support for palette encoding and decoding.

            Features:
            - Converts sprites to high-quality PNG and TGA formats.
            - Supports palette encoding and decoding for accurate color representation.

            You can use this tool for your projects for free, don't forget to credit Original author and Me.
        */
        public MainConverterForm()
        {
            InitializeComponent();

        }

        private void buttonConvertPngToTga_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Выберите папку с PNG-файлами";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = dialog.SelectedPath;
                    textBoxFolderPathPng.Text = selectedFolder;
                    ProcessDirectory(selectedFolder, ImageConverter.ConvertPngToTga);
                }
            }
        }

        private void buttonConvertTgaToPng_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Выберите папку с TGA-файлами";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = dialog.SelectedPath;
                    textBoxFolderPathTga.Text = selectedFolder;
                    ProcessDirectory(selectedFolder, ImageConverter.ConvertTgaToPng);
                }
            }
        }

        private void ProcessDirectory(string directory, Func<string, string> converter)
        {
            listBoxResults.Items.Clear();

            foreach (string file in Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories))
            {
                if (converter == ImageConverter.ConvertPngToTga && file.ToLower().EndsWith(".png") ||
                    converter == ImageConverter.ConvertTgaToPng && file.ToLower().EndsWith(".tga"))
                {
                    string result = converter(file);
                    listBoxResults.Items.Add(result);
                    if (Delete.Checked)
                    {
                        File.Delete(file);
                    }
                }
            }
        }

        private void GOTGA_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFolderPathPng.Text))
            {
                ProcessDirectory(textBoxFolderPathPng.Text, ImageConverter.ConvertPngToTga);
            }
        }

        private void GOPNG_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFolderPathTga.Text))
            {
                ProcessDirectory(textBoxFolderPathTga.Text, ImageConverter.ConvertTgaToPng);
            }
        }
    }
}

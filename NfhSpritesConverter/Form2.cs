using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PngToTgaConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonConvertPngToTga_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Выберите папку с PNG-файлами";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = dialog.SelectedPath;
                    textBoxFolderPathPng.Text = selectedFolder;
                    ProcessDirectory(selectedFolder, ConvertPngToTga);
                }
            }
        }

        private void buttonConvertTgaToPng_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Выберите папку с TGA-файлами";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = dialog.SelectedPath;
                    textBoxFolderPathTga.Text = selectedFolder;
                    ProcessDirectory(selectedFolder, ConvertTgaToPng);
                }
            }
        }

        private void ProcessDirectory(string directory, Func<string, string> converter)
        {
            listBoxResults.Items.Clear();

            foreach (string file in Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories))
            {
                if (converter == ConvertPngToTga && file.ToLower().EndsWith(".png") ||
                    converter == ConvertTgaToPng && file.ToLower().EndsWith(".tga"))
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

        private string ConvertPngToTga(string pngPath)
        {
            try
            {
                using (Bitmap img = new Bitmap(pngPath))
                {
                    int width = img.Width;
                    int height = img.Height;
                    bool hasAlpha = img.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb;

                    byte[] data = new byte[width * height * 2];
                    int index = 0;

                    // Получаем смещения RGB из текстовых полей
                    int rOffset = int.Parse(textBoxROffset.Text);
                    int gOffset = int.Parse(textBoxGOffset.Text);
                    int bOffset = int.Parse(textBoxBOffset.Text);

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color pixel = img.GetPixel(x, y);

                            if (hasAlpha)
                            {
                                int r = pixel.R + rOffset;
                                int g = pixel.G + gOffset;
                                int b = pixel.B + bOffset;
                                int a = pixel.A;

                                if (a == 0)
                                {
                                    r = g = b = 0;
                                }
                                else
                                {
                                    r = Math.Min(255, Math.Max(0, (int)Math.Round((r * 255.0) / a)));
                                    g = Math.Min(255, Math.Max(0, (int)Math.Round((g * 255.0) / a)));
                                    b = Math.Min(255, Math.Max(0, (int)Math.Round((b * 255.0) / a)));
                                }

                                int a4 = a / 17;
                                int r4 = r / 17;
                                int g4 = g / 17;
                                int b4 = b / 17;

                                data[index++] = (byte)((g4 << 4) | b4);
                                data[index++] = (byte)((a4 << 4) | r4);
                            }
                            else
                            {
                                int r = pixel.R + rOffset;
                                int g = pixel.G + gOffset;
                                int b = pixel.B + bOffset;

                                int r5 = (r >> 3) & 0x1F;
                                int g6 = (g >> 2) & 0x3F;
                                int b5 = (b >> 3) & 0x1F;

                                byte byte2 = (byte)((r5 << 3) | (g6 >> 3));
                                byte byte1 = (byte)(((g6 & 0x07) << 5) | b5);

                                data[index++] = byte1;
                                data[index++] = byte2;
                            }
                        }
                    }

                    byte flags = (byte)(0x20 | (hasAlpha ? 0x04 : 0x00));

                    byte[] header = new byte[18];
                    header[2] = 2;
                    header[12] = (byte)(width & 0xFF);
                    header[13] = (byte)((width >> 8) & 0xFF);
                    header[14] = (byte)(height & 0xFF);
                    header[15] = (byte)((height >> 8) & 0xFF);
                    header[16] = 16;
                    header[17] = flags;

                    string tgaPath = Path.ChangeExtension(pngPath, ".tga");
                    using (FileStream fs = new FileStream(tgaPath, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(header, 0, header.Length);
                        fs.Write(data, 0, data.Length);
                    }

                    return $"Конвертирован: {Path.GetFileName(pngPath)} -> {Path.GetFileName(tgaPath)}";
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка при конвертации {Path.GetFileName(pngPath)}: {ex.Message}";
            }
        }

        private string ConvertTgaToPng(string tgaPath)
        {
            try
            {
                using (FileStream fs = new FileStream(tgaPath, FileMode.Open, FileAccess.Read))
                {
                    fs.Seek(12, SeekOrigin.Begin);

                    int width = ReadShort(fs);
                    int height = ReadShort(fs);
                    int bpp = fs.ReadByte();
                    int flags = fs.ReadByte();

                    if (bpp != 16)
                    {
                        return $"Неподдерживаемый BPP: {bpp} в {Path.GetFileName(tgaPath)}";
                    }

                    bool hasAlpha = (flags & 4) != 0;
                    byte[] data = new byte[width * height * 2];
                    fs.Read(data, 0, data.Length);

                    // Получаем смещения RGB из текстовых полей
                    int rOffset = int.Parse(textBoxROffset.Text);
                    int gOffset = int.Parse(textBoxGOffset.Text);
                    int bOffset = int.Parse(textBoxBOffset.Text);

                    using (Bitmap img = new Bitmap(width, height))
                    {
                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                int index = (y * width + x) * 2;
                                byte byte1 = data[index];
                                byte byte2 = data[index + 1];

                                if (hasAlpha)
                                {
                                    int a = (byte2 & 0xF0) >> 4;
                                    int r = (byte2 & 0x0F);
                                    int g = (byte1 & 0xF0) >> 4;
                                    int b = (byte1 & 0x0F);

                                    a = (a << 4) | a;
                                    r = (r << 4) | r;
                                    g = (g << 4) | g;
                                    b = (b << 4) | b;

                                    if (a > 0)
                                    {
                                        r = Math.Min((r * a) / 255, 255);
                                        g = Math.Min((g * a) / 255, 255);
                                        b = Math.Min((b * a) / 255, 255);
                                    }
                                    else
                                    {
                                        r = g = b = 0;
                                    }

                                    // Применяем смещения RGB
                                    r = Math.Min(255, Math.Max(0, r - rOffset));
                                    g = Math.Min(255, Math.Max(0, g - gOffset));
                                    b = Math.Min(255, Math.Max(0, b - bOffset));

                                    img.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                                }
                                else
                                {
                                    int r = byte2 & 0xF8;
                                    if ((r & 0x08) != 0) r |= 0x07;

                                    int g = ((byte2 & 0x07) << 5) | ((byte1 & 0xE0) >> 3);
                                    if ((g & 0x08) != 0) g |= 0x07;

                                    int b = (byte1 & 0x1F) << 3;
                                    if ((b & 0x04) != 0) b |= 0x03;

                                    // Применяем смещения RGB
                                    r = Math.Min(255, Math.Max(0, r - rOffset));
                                    g = Math.Min(255, Math.Max(0, g - gOffset));
                                    b = Math.Min(255, Math.Max(0, b - bOffset));

                                    img.SetPixel(x, y, Color.FromArgb(r, g, b));
                                }
                            }
                        }

                        string pngPath = Path.ChangeExtension(tgaPath, ".png");
                        img.Save(pngPath, System.Drawing.Imaging.ImageFormat.Png);
                        return $"Конвертирован: {Path.GetFileName(tgaPath)} -> {Path.GetFileName(pngPath)}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка при конвертации {Path.GetFileName(tgaPath)}: {ex.Message}";
            }
        }

        private int ReadShort(FileStream fs)
        {
            byte[] buffer = new byte[2];
            fs.Read(buffer, 0, 2);
            return buffer[0] | (buffer[1] << 8);
        }

        private void GOTGA_Click(object sender, EventArgs e)
        {
            if (textBoxFolderPathPng.Text != "" && textBoxFolderPathPng.Text.Length > 0)
            {
                ProcessDirectory(textBoxFolderPathPng.Text, ConvertPngToTga);
            }
        }

        private void GOPNG_Click(object sender, EventArgs e)
        {
            if (textBoxFolderPathTga.Text != "" && textBoxFolderPathTga.Text.Length > 0)
            {
                ProcessDirectory(textBoxFolderPathTga.Text, ConvertTgaToPng);
            }
        }
    }
}
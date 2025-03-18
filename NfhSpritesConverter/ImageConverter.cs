using System;
using System.Drawing;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Color = System.Drawing.Color;
using Image = SixLabors.ImageSharp.Image;
using System.Text;

namespace NfhSpritesConverter
{
    public static class ImageConverter
    {
        // Метод для конвертации PNG изображения в TGA формат
        public static string ConvertPngToTga(string pngPath)
        {
            try
            {
                // Загрузка изображения из файла PNG
                using (Bitmap tempImg = new Bitmap(pngPath))
                using (Bitmap img = new Bitmap(tempImg.Width, tempImg.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                {
                    // Копирование изображения с учетом альфа-канала
                    using (Graphics g = Graphics.FromImage(img))
                    {
                        g.DrawImage(tempImg, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                    }

                    int width = img.Width;
                    int height = img.Height;

                    // Проверка наличия альфа-канала в изображении
                    bool hasAlpha = false;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            if (img.GetPixel(x, y).A < 255)
                            {
                                hasAlpha = true;
                                break;
                            }
                        }
                        if (hasAlpha) break;
                    }

                    // Создание заголовка TGA файла
                    byte[] header = new byte[18];
                    header[0] = 0;
                    header[1] = 0;
                    header[2] = 2;
                    for (int i = 3; i <= 7; i++) header[i] = 0;
                    header[8] = header[9] = header[10] = header[11] = 0;
                    Buffer.BlockCopy(BitConverter.GetBytes((short)width), 0, header, 12, 2);
                    Buffer.BlockCopy(BitConverter.GetBytes((short)height), 0, header, 14, 2);
                    header[16] = 16; // 16 бит на пиксель
                    header[17] = (byte)(0x20 | (hasAlpha ? 0x04 : 0x00)); // Флаги

                    byte[] pixelData = new byte[width * height * 2];
                    int dataIndex = 0;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color c = img.GetPixel(x, y);
                            if (c.A == 0)
                            {
                                pixelData[dataIndex++] = 0;
                                pixelData[dataIndex++] = 0;
                            }
                            else if (hasAlpha)
                            {
                                // Преобразование цвета с учетом альфа-канала
                                byte a = c.A;
                                byte r = (byte)((c.R * a + 254) / 255);
                                byte g = (byte)((c.G * a + 254) / 255);
                                byte b = (byte)((c.B * a + 254) / 255);

                                // Квантование до 4 бит
                                byte a4 = (byte)(a >> 4);
                                byte r4 = (byte)(r >> 4);
                                byte g4 = (byte)(g >> 4);
                                byte b4 = (byte)(b >> 4);

                                pixelData[dataIndex++] = (byte)((g4 << 4) | b4);
                                pixelData[dataIndex++] = (byte)((a4 << 4) | r4);
                            }
                            else
                            {
                                // Преобразование цвета без альфа-канала
                                byte r5 = (byte)(c.R >> 3);
                                byte g6 = (byte)(c.G >> 2);
                                byte b5 = (byte)(c.B >> 3);
                                byte upperG = (byte)(g6 >> 3);
                                byte lowerG = (byte)(g6 & 0x07);
                                pixelData[dataIndex++] = (byte)((lowerG << 5) | b5);
                                pixelData[dataIndex++] = (byte)((r5 << 3) | upperG);
                            }
                        }
                    }

                    // Сохранение TGA файла
                    string tgaPath = Path.ChangeExtension(pngPath, ".tga");

                    using (FileStream fs = new FileStream(tgaPath, FileMode.Create))
                    {
                        fs.Write(header, 0, header.Length);
                        fs.Write(pixelData, 0, pixelData.Length);

                        int bpp = 16;
                        long pixelDataSize = width * height * 2;
                        WriteTgaFooter(fs, width, height, bpp, pixelDataSize, hasAlpha);
                    }

                    return $"Конвертирован: {Path.GetFileName(pngPath)} -> {Path.GetFileName(tgaPath)}";
                }
            }
            catch (Exception e)
            {
                return $"Ошибка при конвертации {Path.GetFileName(pngPath)}: {e.Message}";
            }
        }

        // Метод для добавления футера в TGA файл
        private static void WriteTgaFooter(FileStream fs, int width, int height, int bpp, long pixelDataSize, bool hasAlpha)
        {
            /*
             Я писал эту ерунду 2 дня
                    █████████████████████████████████████████████████
                    ███████████████████████████▓▒▓███████████████████
                    ███████████████████████████▓░▓█████████▒▓████████
                    ███████████████████████████▓░▓███████▒░▒▓████████
                    ███████████████████████████▓░▓▓▒▓▓▓▓░░▓██████████
                    ██████████████████████▓▓▒▒▒▒▒▒▓▒▒▒▒▓░▓███████████
                    ██████████████████████▓▓▒▒▒▒░░▒▒▒▒▒▒░▓███████████
                    ████████████████████████████▓▒▒░░░▒▒▓████████████
                    ██████████████▓▓▓█████████████▓▒░▒▓██████████████
                    █████████▓█▒▒▒▒▒▒▓███████████▒░▒▓████████████████
                    ███████▓▒█  ░░▒▒▓▒▒░███████▒░▒▓██████████████████
                    ██████▓░░▓░░░▒██▓██░▓▒▓▓▓▓░▒▓████████████████████
                    █████▓▒░░▒░▓██▓░░░░░▒▒▒▒░▒▓██████████████████████
                    █████▒▒▒▒█░▒▒▒▒▒▒▒░░▒▒▓██████████████████████████
                    █████▓▒▒▒█▒▒██▓▒███▒▒▒▒▓█████████████████████████
                    ██████▓▒▒░███████████▓▓██████████████████████████
                    ███████▓▒▒▓▓░░▒██░▒▒▒▓███████████████████████████
                    █████████▓▒▒▒▒▒▒▒▒▒▓█████████████████████████████
                    █████████████████████████████████████████████████
             */

            // (!) Добавляет футер к TGA изображениям, как в оригинальной игре (не идеально)

            long imageDataEndOffset = 18 + pixelDataSize;

            int offset2 = (int)imageDataEndOffset;
            int offset1 = offset2 + 0x0C;

            byte[] footer = new byte[36];

            Buffer.BlockCopy(new byte[] { 0x01, 0x00, 0x00, 0x10 }, 0, footer, 0, 4);

            Buffer.BlockCopy(BitConverter.GetBytes(offset1), 0, footer, 4, 4);

            Buffer.BlockCopy(new byte[] { 0x10, 0x00, 0x00, 0x00, 0x00 }, 0, footer, 8, 5);

            byte[] pattern = hasAlpha
                ? new byte[] { 0xF0, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0xF0, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00 }
                : new byte[] { 0x00, 0x00, 0x00, 0x00, 0xF8, 0x00, 0x00, 0xE0, 0x07, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x00 };
            Buffer.BlockCopy(pattern, 0, footer, 13, 15);

            Buffer.BlockCopy(new byte[] { 0x00, 0x00, 0x00, 0x00 }, 0, footer, 28, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(offset2), 0, footer, 32, 4);

            fs.Write(footer, 0, 36);

            byte[] signature = Encoding.ASCII.GetBytes("TRUEVISION-XFILE.\0");
            fs.Write(signature, 0, signature.Length);
        }

        // Метод для конвертации TGA изображения в PNG формат
        public static string ConvertTgaToPng(string tgaPath)
        {
            try
            {
                using (FileStream fs = new FileStream(tgaPath, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    fs.Seek(12, SeekOrigin.Begin);

                    int width = reader.ReadUInt16();
                    int height = reader.ReadUInt16();
                    int bpp = reader.ReadByte();
                    int flags = reader.ReadByte();
                    bool hasAlpha = (flags & 0x04) != 0;
                    bool topLeft = (flags & 0x20) != 0;

                    int dataSize = width * height * (bpp / 8);
                    byte[] data = reader.ReadBytes(dataSize);

                    if (!topLeft)
                    {
                        int bytesPerRow = width * (bpp / 8);
                        byte[] flippedData = new byte[dataSize];
                        for (int y = 0; y < height; y++)
                        {
                            int srcY = height - 1 - y;
                            Array.Copy(data, srcY * bytesPerRow, flippedData, y * bytesPerRow, bytesPerRow);
                        }
                        data = flippedData;
                    }

                    using (var image = new Image<Rgba32>(width, height))
                    {
                        int index = 0;
                        image.ProcessPixelRows(accessor =>
                        {
                            for (int y = 0; y < accessor.Height; y++)
                            {
                                var row = accessor.GetRowSpan(y);
                                for (int x = 0; x < row.Length; x++)
                                {
                                    if (bpp == 16)
                                    {
                                        ushort pixelData = BitConverter.ToUInt16(data, index);
                                        index += 2;

                                        if (hasAlpha)
                                        {
                                            // Обработка RGBA4444
                                            int a4 = (pixelData >> 12) & 0x0F;
                                            int r4 = (pixelData >> 8) & 0x0F;
                                            int g4 = (pixelData >> 4) & 0x0F;
                                            int b4 = pixelData & 0x0F;

                                            byte a = (byte)(a4 * 17);
                                            byte rPremul = (byte)(r4 * 17);
                                            byte gPremul = (byte)(g4 * 17);
                                            byte bPremul = (byte)(b4 * 17);

                                            if (a == 0)
                                            {
                                                row[x] = new Rgba32(0, 0, 0, 0);
                                            }
                                            else
                                            {
                                                int originalR = (rPremul * 255 + a / 2) / a;
                                                int originalG = (gPremul * 255 + a / 2) / a;
                                                int originalB = (bPremul * 255 + a / 2) / a;

                                                originalR = Math.Clamp(originalR, 0, 255);
                                                originalG = Math.Clamp(originalG, 0, 255);
                                                originalB = Math.Clamp(originalB, 0, 255);

                                                row[x] = new Rgba32(
                                                    (byte)originalR,
                                                    (byte)originalG,
                                                    (byte)originalB,
                                                    a
                                                );
                                            }
                                        }
                                        else
                                        {
                                            // Обработка RGB565
                                            byte r5 = (byte)((pixelData >> 11) & 0x1F);
                                            byte g6 = (byte)((pixelData >> 5) & 0x3F);
                                            byte b5 = (byte)(pixelData & 0x1F);

                                            byte r = (byte)((r5 << 3) | (r5 >> 2));
                                            byte g = (byte)((g6 << 2) | (g6 >> 4));
                                            byte b = (byte)((b5 << 3) | (b5 >> 2));

                                            row[x] = new Rgba32(r, g, b, 255);
                                        }
                                    }
                                    else if (bpp == 24)
                                    {
                                        byte bVal = data[index++];
                                        byte gVal = data[index++];
                                        byte rVal = data[index++];
                                        row[x] = new Rgba32(rVal, gVal, bVal, 255);
                                    }
                                    else if (bpp == 32)
                                    {
                                        byte bVal = data[index++];
                                        byte gVal = data[index++];
                                        byte rVal = data[index++];
                                        byte aVal = data[index++];
                                        row[x] = new Rgba32(rVal, gVal, bVal, aVal);
                                    }
                                }
                            }
                        });

                        string pngPath = Path.ChangeExtension(tgaPath, ".png");
                        image.SaveAsPng(pngPath);
                        return $"Конвертирован: {Path.GetFileName(tgaPath)} -> {Path.GetFileName(pngPath)}";
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    // Альтернативный метод конвертации через ImageSharp
                    using (var image = Image.Load(tgaPath))
                    {
                        string pngPath = Path.ChangeExtension(tgaPath, ".png");
                        image.SaveAsPng(pngPath);
                        return $"Конвертирован через альтернативный метод: {Path.GetFileName(tgaPath)} -> {Path.GetFileName(pngPath)}";
                    }
                }
                catch (Exception ex2)
                {
                    return $"Ошибка: {Path.GetFileName(tgaPath)}: {ex.Message}\nАльтернативный метод: {ex2.Message}";
                }
            }
        }
    }
}

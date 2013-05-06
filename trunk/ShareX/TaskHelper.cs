#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (C) 2008-2013 ShareX Developers

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using HelpersLib;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace ShareX
{
    public static class TaskHelper
    {
        public static ImageData PrepareImage(Image img)
        {
            ImageData imageData = new ImageData();

            if (Program.Settings.ImageAutoResize)
            {
                img = ResizeImage(img, Program.Settings.ImageScaleType);
            }

            imageData.ImageStream = SaveImage(img, Program.Settings.ImageFormat);

            int sizeLimit = Program.Settings.ImageSizeLimit * 1000;
            if (Program.Settings.ImageFormat != Program.Settings.ImageFormat2 && sizeLimit > 0 && imageData.ImageStream.Length > sizeLimit)
            {
                imageData.ImageStream = SaveImage(img, Program.Settings.ImageFormat2);
                imageData.ImageFormat = Program.Settings.ImageFormat2;
            }
            else
            {
                imageData.ImageFormat = Program.Settings.ImageFormat;
            }

            return imageData;
        }

        private static Image ResizeImage(Image img, ImageScaleType scaleType)
        {
            float width = 0, height = 0;

            switch (scaleType)
            {
                case ImageScaleType.Percentage:
                    width = img.Width * (Program.Settings.ImageScalePercentageWidth / 100f);
                    height = img.Height * (Program.Settings.ImageScalePercentageHeight / 100f);
                    break;
                case ImageScaleType.Width:
                    width = Program.Settings.ImageScaleToWidth;
                    height = Program.Settings.ImageKeepAspectRatio ? img.Height * (width / img.Width) : img.Height;
                    break;
                case ImageScaleType.Height:
                    height = Program.Settings.ImageScaleToHeight;
                    width = Program.Settings.ImageKeepAspectRatio ? img.Width * (height / img.Height) : img.Width;
                    break;
                case ImageScaleType.Specific:
                    width = Program.Settings.ImageScaleSpecificWidth;
                    height = Program.Settings.ImageScaleSpecificHeight;
                    break;
            }

            if (width > 0 && height > 0)
            {
                return CaptureHelpers.ResizeImage(img, (int)width, (int)height, Program.Settings.ImageUseSmoothScaling);
            }

            return img;
        }

        private static MemoryStream SaveImage(Image img, EImageFormat imageFormat)
        {
            MemoryStream stream = new MemoryStream();

            switch (imageFormat)
            {
                case EImageFormat.PNG:
                    img.Save(stream, ImageFormat.Png);
                    break;
                case EImageFormat.JPEG:
                    img.SaveJPG(stream, Program.Settings.ImageJPEGQuality, true);
                    break;
                case EImageFormat.GIF:
                    img.SaveGIF(stream, Program.Settings.ImageGIFQuality);
                    break;
                case EImageFormat.BMP:
                    img.Save(stream, ImageFormat.Bmp);
                    break;
                case EImageFormat.TIFF:
                    img.Save(stream, ImageFormat.Tiff);
                    break;
            }

            return stream;
        }

        public static string GetFilename(string extension = "")
        {
            NameParser nameParser = new NameParser(NameParserType.FileName)
            {
                AutoIncrementNumber = Program.Settings.AutoIncrementNumber,
                MaxNameLength = 100
            };

            string filename = nameParser.Parse(Program.Settings.NameFormatPattern);

            if (!string.IsNullOrEmpty(extension))
            {
                filename += "." + extension.TrimStart('.');
            }

            Program.Settings.AutoIncrementNumber = nameParser.AutoIncrementNumber;

            return filename;
        }

        public static void ShowResultNotifications(string result)
        {
            if (!string.IsNullOrEmpty(result))
            {
                if (Program.Settings.TrayBalloonTipAfterUpload && Program.MainForm.niTray.Visible)
                {
                    Program.MainForm.niTray.Tag = result;
                    Program.MainForm.niTray.ShowBalloonTip(5000, "ShareX - Task completed", result, ToolTipIcon.Info);
                }

                if (Program.Settings.PlaySoundAfterUpload)
                {
                    SystemSounds.Exclamation.Play();
                }
            }
        }

        public static Image DrawShadow(Image img)
        {
            Point offsetChange;
            return GreenshotPlugin.Core.ImageHelper.CreateShadow(img, Program.Settings.ShadowDarkness, Program.Settings.ShadowSize,
                Program.Settings.ShadowOffset, out offsetChange, PixelFormat.Format32bppArgb);
        }
    }
}
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
using ImageEffectsLib;
using ScreenCapture;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace ShareX
{
    public static class TaskHelpers
    {
        private const int PropertyTagSoftwareUsed = 0x0131;

        public static ImageData PrepareImage(Image img, TaskSettings taskSettings)
        {
            ImageData imageData = new ImageData();
            imageData.ImageFormat = taskSettings.ImageSettings.ImageFormat;

            if (taskSettings.ImageSettings.ImageFormat == EImageFormat.JPEG)
            {
                ImageHelpers.FillImageBackground(img, Color.White);
            }

            ImageHelpers.AddMetadata(img, PropertyTagSoftwareUsed, Program.ApplicationName);

            imageData.ImageStream = SaveImage(img, taskSettings.ImageSettings.ImageFormat, taskSettings);

            int sizeLimit = taskSettings.ImageSettings.ImageSizeLimit * 1000;

            if (taskSettings.ImageSettings.ImageFormat != taskSettings.ImageSettings.ImageFormat2 && sizeLimit > 0 && imageData.ImageStream.Length > sizeLimit)
            {
                if (taskSettings.ImageSettings.ImageFormat2 == EImageFormat.JPEG)
                {
                    ImageHelpers.FillImageBackground(img, Color.White);
                }

                imageData.ImageStream = SaveImage(img, taskSettings.ImageSettings.ImageFormat2, taskSettings);
                imageData.ImageFormat = taskSettings.ImageSettings.ImageFormat2;
            }

            return imageData;
        }

        public static Image ResizeImage(Image img, TaskSettings taskSettings)
        {
            switch (taskSettings.ImageSettings.ImageScaleType)
            {
                case ImageScaleType.Percentage:
                    return ImageHelpers.ResizeImageByPercentage(img, taskSettings.ImageSettings.ImageScalePercentageWidth, taskSettings.ImageSettings.ImageScalePercentageHeight);
                case ImageScaleType.Specific:
                    return ImageHelpers.ResizeImage(img, taskSettings.ImageSettings.ImageScaleSpecificWidth, taskSettings.ImageSettings.ImageScaleSpecificHeight);
                case ImageScaleType.Width:
                    return ImageHelpers.ResizeImageByWidth(img, taskSettings.ImageSettings.ImageScaleToWidth, taskSettings.ImageSettings.ImageScaleToWidthKeepAspectRatio);
                case ImageScaleType.Height:
                    return ImageHelpers.ResizeImageByHeight(img, taskSettings.ImageSettings.ImageScaleToHeight, taskSettings.ImageSettings.ImageScaleToHeightKeepAspectRatio);
            }

            return img;
        }

        public static MemoryStream SaveImage(Image img, EImageFormat imageFormat, TaskSettings taskSettings)
        {
            MemoryStream stream = new MemoryStream();

            switch (imageFormat)
            {
                case EImageFormat.PNG:
                    img.Save(stream, ImageFormat.Png);
                    break;
                case EImageFormat.JPEG:
                    img.SaveJPG(stream, taskSettings.ImageSettings.ImageJPEGQuality);
                    break;
                case EImageFormat.GIF:
                    img.SaveGIF(stream, taskSettings.ImageSettings.ImageGIFQuality);
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

        public static string GetFilename(TaskSettings taskSettings, string extension = "")
        {
            NameParser nameParser = new NameParser(NameParserType.FileName)
            {
                AutoIncrementNumber = Program.Settings.NameParserAutoIncrementNumber,
                MaxNameLength = 100
            };

            string filename = nameParser.Parse(taskSettings.UploadSettings.NameFormatPattern);

            if (!string.IsNullOrEmpty(extension))
            {
                filename += "." + extension.TrimStart('.');
            }

            Program.Settings.NameParserAutoIncrementNumber = nameParser.AutoIncrementNumber;

            return filename;
        }

        public static string GetImageFilename(TaskSettings taskSettings, Image image)
        {
            string filename;

            NameParser nameParser = new NameParser(NameParserType.FileName);
            nameParser.MaxNameLength = 100;
            nameParser.Picture = image;
            nameParser.AutoIncrementNumber = Program.Settings.NameParserAutoIncrementNumber;

            ImageTag imageTag = image.Tag as ImageTag;

            if (imageTag != null)
            {
                nameParser.WindowText = imageTag.ActiveWindowTitle;
            }

            if (string.IsNullOrEmpty(nameParser.WindowText))
            {
                filename = nameParser.Parse(taskSettings.UploadSettings.NameFormatPattern) + ".bmp";
            }
            else
            {
                filename = nameParser.Parse(taskSettings.UploadSettings.NameFormatPatternActiveWindow) + ".bmp";
            }

            Program.Settings.NameParserAutoIncrementNumber = nameParser.AutoIncrementNumber;

            return filename;
        }

        public static void ShowResultNotifications(string result, TaskSettings taskSettings)
        {
            if (!taskSettings.AdvancedSettings.DisableNotifications)
            {
                if (taskSettings.GeneralSettings.TrayBalloonTipAfterUpload && Program.MainForm.niTray.Visible)
                {
                    Program.MainForm.niTray.Tag = result;
                    Program.MainForm.niTray.ShowBalloonTip(5000, "ShareX - Task completed", result, ToolTipIcon.Info);
                }

                if (taskSettings.GeneralSettings.PlaySoundAfterUpload)
                {
                    SystemSounds.Exclamation.Play();
                }
            }
        }

        public static Image AnnotateImage(Image img)
        {
            if (!Greenshot.IniFile.IniConfig.isInitialized)
            {
                Greenshot.IniFile.IniConfig.AllowSave = !Program.IsSandbox;
                Greenshot.IniFile.IniConfig.Init(Program.PersonalPath);
            }

            using (Image cloneImage = (Image)img.Clone())
            using (Greenshot.Plugin.ICapture capture = new GreenshotPlugin.Core.Capture() { Image = cloneImage })
            using (Greenshot.Drawing.Surface surface = new Greenshot.Drawing.Surface(capture))
            using (Greenshot.ImageEditorForm editor = new Greenshot.ImageEditorForm(surface, true))
            {
                editor.ClipboardCopyRequested += x => Program.MainForm.InvokeSafe(() => ClipboardHelpers.CopyImage(x));
                editor.ImageUploadRequested += x => Program.MainForm.InvokeSafe(() => UploadManager.RunImageTask(x));

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    Image result = editor.GetImageForExport();
                    img.Dispose();
                    return result;
                }
            }

            return img;
        }

        public static Image AddImageEffects(Image img)
        {
            using (ImageEffectsForm imageEffectsForm = new ImageEffectsForm(img))
            {
                if (imageEffectsForm.ShowDialog() == DialogResult.OK)
                {
                    Image result = imageEffectsForm.ExportImage();
                    img.Dispose();
                    return result;
                }
            }

            return img;
        }

        public static Image DrawShadow(TaskSettings taskSettings, Image img)
        {
            Point offsetChange;
            return GreenshotPlugin.Core.ImageHelper.CreateShadow(img, taskSettings.ImageSettings.ShadowDarkness, taskSettings.ImageSettings.ShadowSize,
                taskSettings.ImageSettings.ShadowOffset, out offsetChange, PixelFormat.Format32bppArgb);
        }

        public static void AddDefaultExternalPrograms(TaskSettings taskSettings)
        {
            if (taskSettings.ExternalPrograms == null)
            {
                taskSettings.ExternalPrograms = new List<ExternalProgram>();
            }

            AddExternalProgramFromRegistry(taskSettings, "Paint", "mspaint.exe");
            AddExternalProgramFromRegistry(taskSettings, "Paint.NET", "PaintDotNet.exe");
            AddExternalProgramFromRegistry(taskSettings, "Adobe Photoshop", "Photoshop.exe");
            AddExternalProgramFromRegistry(taskSettings, "IrfanView", "i_view32.exe");
            AddExternalProgramFromRegistry(taskSettings, "XnView", "xnview.exe");
            AddExternalProgramFromFile(taskSettings, "OptiPNG", "optipng.exe");
        }

        private static void AddExternalProgramFromFile(TaskSettings taskSettings, string name, string filename, string args = "")
        {
            if (!taskSettings.ExternalPrograms.Exists(x => x.Name == name))
            {
                if (File.Exists(filename))
                {
                    DebugHelper.WriteLine("Found program: " + filename);

                    taskSettings.ExternalPrograms.Add(new ExternalProgram(name, filename, args));
                }
            }
        }

        private static void AddExternalProgramFromRegistry(TaskSettings taskSettings, string name, string filename)
        {
            if (!taskSettings.ExternalPrograms.Exists(x => x.Name == name))
            {
                ExternalProgram externalProgram = RegistryHelpers.FindProgram(name, filename);

                if (externalProgram != null)
                {
                    taskSettings.ExternalPrograms.Add(externalProgram);
                }
            }
        }

        public static bool SelectRegion(out Rectangle rect)
        {
            using (RectangleRegion surface = new RectangleRegion())
            {
                surface.AreaManager.WindowCaptureMode = true;
                surface.Prepare();
                surface.ShowDialog();

                if (surface.Result == SurfaceResult.Region)
                {
                    if (surface.AreaManager.IsCurrentAreaValid)
                    {
                        rect = CaptureHelpers.ClientToScreen(surface.AreaManager.CurrentArea);
                        return true;
                    }
                }
                else if (surface.Result == SurfaceResult.Fullscreen)
                {
                    rect = CaptureHelpers.GetScreenBounds();
                    return true;
                }
            }

            rect = Rectangle.Empty;
            return false;
        }
    }
}
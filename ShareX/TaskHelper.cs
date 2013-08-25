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
using ScreenCapture;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace ShareX
{
    public static class TaskHelper
    {
        private const int PropertyTagSoftwareUsed = 0x0131;

        public static ImageData PrepareImage(Image img, TaskSettings taskSettings)
        {
            ImageData imageData = new ImageData();

            if (taskSettings.ImageSettings.ImageAutoResize)
            {
                img = ResizeImage(taskSettings, img, taskSettings.ImageSettings.ImageScaleType);
            }

            imageData.ImageStream = SaveImage(taskSettings, img, taskSettings.ImageSettings.ImageFormat);

            int sizeLimit = taskSettings.ImageSettings.ImageSizeLimit * 1000;
            if (taskSettings.ImageSettings.ImageFormat != taskSettings.ImageSettings.ImageFormat2 && sizeLimit > 0 && imageData.ImageStream.Length > sizeLimit)
            {
                imageData.ImageStream = SaveImage(taskSettings, img, taskSettings.ImageSettings.ImageFormat2);
                imageData.ImageFormat = taskSettings.ImageSettings.ImageFormat2;
            }
            else
            {
                imageData.ImageFormat = taskSettings.ImageSettings.ImageFormat;
            }

            return imageData;
        }

        public static void PrepareFileImage(UploadTask task)
        {
            int sizeLimit = task.Info.TaskSettings.ImageSettings.ImageSizeLimit * 1000;

            if (sizeLimit > 0 && task.Data.Length > sizeLimit)
            {
                using (Stream stream = task.Data)
                using (Image img = Image.FromStream(stream))
                {
                    task.Data = SaveImage(task.Info.TaskSettings, img, task.Info.TaskSettings.ImageSettings.ImageFormat2);
                    task.Info.FileName = Path.ChangeExtension(task.Info.FileName, task.Info.TaskSettings.ImageSettings.ImageFormat2.GetDescription());
                }
            }
        }

        private static Image ResizeImage(TaskSettings taskSettings, Image img, ImageScaleType scaleType)
        {
            float width = 0, height = 0;

            switch (scaleType)
            {
                case ImageScaleType.Percentage:
                    width = img.Width * (taskSettings.ImageSettings.ImageScalePercentageWidth / 100f);
                    height = img.Height * (taskSettings.ImageSettings.ImageScalePercentageHeight / 100f);
                    break;
                case ImageScaleType.Width:
                    width = taskSettings.ImageSettings.ImageScaleToWidth;
                    height = taskSettings.ImageSettings.ImageKeepAspectRatio ? img.Height * (width / img.Width) : img.Height;
                    break;
                case ImageScaleType.Height:
                    height = taskSettings.ImageSettings.ImageScaleToHeight;
                    width = taskSettings.ImageSettings.ImageKeepAspectRatio ? img.Width * (height / img.Height) : img.Width;
                    break;
                case ImageScaleType.Specific:
                    width = taskSettings.ImageSettings.ImageScaleSpecificWidth;
                    height = taskSettings.ImageSettings.ImageScaleSpecificHeight;
                    break;
            }

            if (width > 0 && height > 0)
            {
                return CaptureHelpers.ResizeImage(img, (int)width, (int)height, taskSettings.ImageSettings.ImageUseSmoothScaling);
            }

            return img;
        }

        private static MemoryStream SaveImage(TaskSettings taskSettings, Image img, EImageFormat imageFormat)
        {
            CaptureHelpers.AddMetadata(img, PropertyTagSoftwareUsed, Program.ApplicationName);

            MemoryStream stream = new MemoryStream();

            switch (imageFormat)
            {
                case EImageFormat.PNG:
                    img.Save(stream, ImageFormat.Png);
                    break;
                case EImageFormat.JPEG:
                    img.SaveJPG(stream, taskSettings.ImageSettings.ImageJPEGQuality, true);
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
                AutoIncrementNumber = taskSettings.UploadSettings.AutoIncrementNumber,
                MaxNameLength = 100
            };

            string filename = nameParser.Parse(taskSettings.UploadSettings.NameFormatPattern);

            if (!string.IsNullOrEmpty(extension))
            {
                filename += "." + extension.TrimStart('.');
            }

            taskSettings.UploadSettings.AutoIncrementNumber = nameParser.AutoIncrementNumber;

            return filename;
        }

        public static string GetImageFilename(TaskSettings taskSettings, Image image)
        {
            string filename;

            NameParser nameParser = new NameParser(NameParserType.FileName);
            nameParser.MaxNameLength = 100;
            nameParser.Picture = image;
            nameParser.AutoIncrementNumber = taskSettings.UploadSettings.AutoIncrementNumber;

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

            taskSettings.UploadSettings.AutoIncrementNumber = nameParser.AutoIncrementNumber;

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
                editor.ClipboardCopyRequested += editor_ClipboardCopyRequested;
                editor.ImageUploadRequested += editor_ImageUploadRequested;

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    return editor.GetImageForExport();
                }
            }

            return img;
        }

        private static void editor_ClipboardCopyRequested(Image img)
        {
            Program.MainForm.InvokeSafe(() => ClipboardHelper.CopyImage(img));
        }

        private static void editor_ImageUploadRequested(Image img)
        {
            Program.MainForm.InvokeSafe(() => UploadManager.RunImageTask(img));
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
                ExternalProgram externalProgram = RegistryHelper.FindProgram(name, filename);

                if (externalProgram != null)
                {
                    taskSettings.ExternalPrograms.Add(externalProgram);
                }
            }
        }

        public static bool SelectRegion(TaskSettings taskSettings, out Rectangle rect)
        {
            using (RectangleRegion surface = new RectangleRegion())
            {
                surface.AreaManager.WindowCaptureMode = true;
                surface.Config = taskSettings.CaptureSettings.SurfaceOptions;
                surface.Config.AllowMoveResize = false;
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
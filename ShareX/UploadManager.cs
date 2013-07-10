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
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UploadersLib;
using UploadersLib.HelperClasses;

namespace ShareX
{
    public static class UploadManager
    {
        public static void UploadFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                if (File.Exists(filePath))
                {
                    UploadTask task = UploadTask.CreateFileUploaderTask(filePath);
                    TaskManager.Start(task);
                }
                else if (Directory.Exists(filePath))
                {
                    string[] files = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories);
                    UploadFile(files);
                }
            }
        }

        public static void UploadFile(string[] files)
        {
            if (files != null && files.Length > 0)
            {
                if (files.Length <= 10 || MessageBox.Show("Are you sure you want to upload " + files.Length + " files?",
                    "ShareX - Upload files", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (string file in files)
                    {
                        UploadFile(file);
                    }
                }
            }
        }

        public static void UploadFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (!string.IsNullOrEmpty(Program.Settings.FileUploadDefaultDirectory) && Directory.Exists(Program.Settings.FileUploadDefaultDirectory))
                {
                    ofd.InitialDirectory = Program.Settings.FileUploadDefaultDirectory;
                }
                else
                {
                    ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }

                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(ofd.FileName))
                    {
                        Program.Settings.FileUploadDefaultDirectory = Path.GetDirectoryName(ofd.FileName);
                    }

                    UploadFile(ofd.FileNames);
                }
            }
        }

        public static void ClipboardUpload()
        {
            if (Clipboard.ContainsImage())
            {
                Image img = Clipboard.GetImage();
                AfterCaptureTasks tasks;

                if (Program.Settings.ClipboardUploadUseAfterCaptureTasks)
                {
                    tasks = Program.Settings.AfterCaptureTasks.Remove(AfterCaptureTasks.CopyImageToClipboard);

                    if (Program.Settings.ClipboardUploadExcludeImageEffects)
                    {
                        tasks = tasks.Remove(AfterCaptureTasks.AddWatermark | AfterCaptureTasks.AddBorder | AfterCaptureTasks.AddShadow);
                    }
                }
                else
                {
                    tasks = AfterCaptureTasks.UploadImageToHost;
                }

                UploadManager.RunImageTask(img, tasks);
            }
            else if (Clipboard.ContainsFileDropList())
            {
                string[] files = Clipboard.GetFileDropList().Cast<string>().ToArray();
                UploadFile(files);
            }
            else if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();

                if (Program.Settings.ClipboardUploadAutoDetectURL && Helpers.IsValidURLRegex(text))
                {
                    ShortenURL(text.Trim());
                }
                else
                {
                    UploadText(text);
                }
            }
        }

        public static void ClipboardUploadWithContentViewer()
        {
            if (Program.Settings.ShowClipboardContentViewer)
            {
                using (ClipboardContentViewer ccv = new ClipboardContentViewer())
                {
                    if (ccv.ShowDialog() == DialogResult.OK && !ccv.IsClipboardEmpty)
                    {
                        UploadManager.ClipboardUpload();
                    }

                    Program.Settings.ShowClipboardContentViewer = !ccv.DontShowThisWindow;
                }
            }
            else
            {
                UploadManager.ClipboardUpload();
            }
        }

        public static void DragDropUpload(IDataObject data)
        {
            if (data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] files = data.GetData(DataFormats.FileDrop, false) as string[];
                UploadFile(files);
            }
            else if (data.GetDataPresent(DataFormats.Bitmap, false))
            {
                Image img = data.GetData(DataFormats.Bitmap, false) as Image;
                RunImageTask(img);
            }
            else if (data.GetDataPresent(DataFormats.Text, false))
            {
                string text = data.GetData(DataFormats.Text, false) as string;
                UploadText(text);
            }
        }

        public static void RunImageTask(Image img, AfterCaptureTasks imageJob = AfterCaptureTasks.UploadImageToHost)
        {
            if (img != null && imageJob != AfterCaptureTasks.None)
            {
                UploadTask task = UploadTask.CreateImageUploaderTask(img, imageJob);
                TaskManager.Start(task);
            }
        }

        public static void UploadImage(Image img, ImageDestination imageDestination)
        {
            if (img != null)
            {
                UploadTask task = UploadTask.CreateImageUploaderTask(img);
                task.Info.ImageDestination = imageDestination;
                TaskManager.Start(task);
            }
        }

        public static void UploadText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                UploadTask task = UploadTask.CreateTextUploaderTask(text);
                TaskManager.Start(task);
            }
        }

        public static void UploadImageStream(Stream stream, string filename)
        {
            if (stream != null && stream.Length > 0 && !string.IsNullOrEmpty(filename))
            {
                UploadTask task = UploadTask.CreateDataUploaderTask(EDataType.Image, stream, filename);
                TaskManager.Start(task);
            }
        }

        public static void ShortenURL(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                UploadTask task = UploadTask.CreateURLShortenerTask(url);
                TaskManager.Start(task);
            }
        }

        public static void UpdateProxySettings()
        {
            Uploader.ProxyInfo = Program.Settings.ProxySettings;
        }
    }
}
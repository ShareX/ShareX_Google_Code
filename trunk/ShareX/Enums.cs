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

using System;
using System.ComponentModel;

namespace ShareX
{
    public enum EImageFormat
    {
        [Description("png")]
        PNG,
        [Description("jpg")]
        JPEG,
        [Description("gif")]
        GIF,
        [Description("bmp")]
        BMP,
        [Description("tif")]
        TIFF
    }

    public enum TaskJob
    {
        DataUpload, FileUpload, ImageJob, TextUpload, ShortenURL
    }

    [Flags]
    public enum AfterCaptureTasks
    {
        None = 0,
        [Description("Add watermark")]
        AddWatermark = 1,
        [Description("Add border")]
        AddBorder = 1 << 1,
        [Description("Copy image to clipboard")]
        CopyImageToClipboard = 1 << 2,
        [Description("Print image")]
        SendImageToPrinter = 1 << 3,
        [Description("Save image to file")]
        SaveImageToFile = 1 << 4,
        [Description("Save image to file as...")]
        SaveImageToFileWithDialog = 1 << 5,
        [Description("Perform actions")]
        PerformActions = 1 << 6,
        [Description("Upload image to host")]
        UploadImageToHost = 1 << 7
    }

    [Flags]
    public enum AfterUploadTasks
    {
        None = 0,
        [Description("Use URL Shortener")]
        UseURLShortener = 1,
        [Description("Post URL to social networking service")]
        ShareURLToSocialNetworkingService = 1 << 1,
        [Description("Copy URL to clipboard")]
        CopyURLToClipboard = 1 << 2
    }

    public enum ImageScaleType
    {
        Percentage, Width, Height, Specific
    }

    public enum AfterCaptureFormResult
    {
        Continue, Cancel, Copy
    }
}
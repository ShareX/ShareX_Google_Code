#region License Information (GPL v3)

/*
    ShareX - A program that allows to you take screenshots and share any file type
    Copyright (C) 2012 ShareX Developers

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

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using HelpersLib;

namespace ShareX
{
    public static class ImageExtensions
    {
        public static MemoryStream SaveImage(this Image img, EImageFormat imageFormat)
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

        public static void SaveJPG(this Image img, Stream stream, int quality, bool fillBackground)
        {
            using (EncoderParameters encoderParameters = new EncoderParameters(1))
            {
                if (fillBackground)
                {
                    img = CaptureHelpers.FillImageBackground(img, Color.White);
                }

                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
                img.Save(stream, ImageFormat.Jpeg.GetCodecInfo(), encoderParameters);
            }
        }

        public static void SaveGIF(this Image img, Stream stream, GIFQuality quality)
        {
            if (quality == GIFQuality.Default)
            {
                img.Save(stream, ImageFormat.Gif);
            }
            else
            {
                Quantizer quantizer;
                switch (quality)
                {
                    case GIFQuality.Grayscale:
                        quantizer = new GrayscaleQuantizer();
                        break;
                    case GIFQuality.Bit4:
                        quantizer = new OctreeQuantizer(15, 4);
                        break;
                    case GIFQuality.Bit8:
                    default:
                        quantizer = new OctreeQuantizer(255, 4);
                        break;
                }

                using (Bitmap quantized = quantizer.Quantize(img))
                {
                    quantized.Save(stream, ImageFormat.Gif);
                }
            }
        }
    }
}
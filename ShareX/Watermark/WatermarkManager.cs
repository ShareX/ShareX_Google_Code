#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HelpersLib;

namespace ShareX
{
    public class WatermarkManager
    {
        public WatermarkConfig Config { get; private set; }

        public WatermarkManager(WatermarkConfig config)
        {
            Config = config;
        }

        protected static Point FindPosition(WatermarkPositionType positionType, int offset, Size img, Size img2, int add)
        {
            Point position;

            switch (positionType)
            {
                case WatermarkPositionType.TOP_LEFT:
                    position = new Point(offset, offset);
                    break;
                case WatermarkPositionType.TOP_RIGHT:
                    position = new Point(img.Width - img2.Width - offset - add, offset);
                    break;
                case WatermarkPositionType.BOTTOM_LEFT:
                    position = new Point(offset, img.Height - img2.Height - offset - add);
                    break;
                case WatermarkPositionType.BOTTOM_RIGHT:
                    position = new Point(img.Width - img2.Width - offset - add, img.Height - img2.Height - offset - add);
                    break;
                case WatermarkPositionType.CENTER:
                    position = new Point(img.Width / 2 - img2.Width / 2 - add, img.Height / 2 - img2.Height / 2 - add);
                    break;
                case WatermarkPositionType.LEFT:
                    position = new Point(offset, img.Height / 2 - img2.Height / 2 - add);
                    break;
                case WatermarkPositionType.TOP:
                    position = new Point(img.Width / 2 - img2.Width / 2 - add, offset);
                    break;
                case WatermarkPositionType.RIGHT:
                    position = new Point(img.Width - img2.Width - offset - add, img.Height / 2 - img2.Height / 2 - add);
                    break;
                case WatermarkPositionType.BOTTOM:
                    position = new Point(img.Width / 2 - img2.Width / 2 - add, img.Height - img2.Height - offset - add);
                    break;
                default:
                    position = Point.Empty;
                    break;
            }

            return position;
        }

        public static DialogResult ShowFontDialog(WatermarkConfig config)
        {
            DialogResult result = DialogResult.Cancel;

            try
            {
                FontDialog fDialog = new FontDialog
                {
                    ShowColor = true
                };

                try
                {
                    fDialog.Color = config.WatermarkFontArgb;
                    fDialog.Font = config.WatermarkFont;
                }
                catch (Exception err)
                {
                    DebugHelper.WriteException(err, "Error while initializing Font and Color");
                }

                result = fDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    config.WatermarkFont = fDialog.Font;
                    config.WatermarkFontArgb = fDialog.Color;
                }
            }
            catch (Exception ex)
            {
                DebugHelper.WriteException(ex, "Error while setting Watermark Font");
            }

            return result;
        }

        public Image ApplyWatermark(Image img)
        {
            NameParser parser = new NameParser(NameParserType.Text) { Picture = img };
            return ApplyWatermark(img, parser, Config.WatermarkMode);
        }

        public Image ApplyWatermark(Image img, NameParser parser, WatermarkType watermarkType)
        {
            switch (watermarkType)
            {
                default:
                case WatermarkType.NONE:
                    return img;
                case WatermarkType.TEXT:
                    return DrawWatermark(img, parser.Convert(Config.WatermarkText));
                case WatermarkType.IMAGE:
                    return DrawImageWatermark(img, Config.WatermarkImageLocation);
            }
        }

        private Image DrawImageWatermark(Image img, string imgPath)
        {
            Image img2 = null;

            try
            {
                if (img != null && !string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
                {
                    img2 = Image.FromFile(imgPath);

                    int offset = (int)Config.WatermarkOffset;
                    int width = (int)(Config.WatermarkImageScale / 100f * img2.Width);
                    int height = (int)(Config.WatermarkImageScale / 100f * img2.Height);

                    if (Config.WatermarkAutoHide && ((img.Width < width + offset) || (img.Height < height + offset)))
                    {
                        return img;
                    }

                    if (Config.WatermarkImageScale != 100)
                    {
                        img2 = CaptureHelpers.ResizeImage(img2, width, height);
                    }

                    Point imgPos = FindPosition(Config.WatermarkPositionMode, offset, img.Size, img2.Size, 0);

                    using (Graphics g = Graphics.FromImage(img))
                    {
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawImage(img2, imgPos);

                        /*if (Config.WatermarkAddReflection)
                        {
                            Bitmap bmp = AddReflection((Bitmap)img2, 50, 200);
                            g.DrawImage(bmp, new Rectangle(imgPos.X, imgPos.Y + img2.Height - 1, bmp.Width, bmp.Height));
                        }*/

                        if (Config.WatermarkUseBorder)
                        {
                            g.DrawRectangle(Pens.Black, new Rectangle(imgPos.X, imgPos.Y, img2.Width - 1, img2.Height - 1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugHelper.WriteException(ex, "Error while drawing image watermark");
            }
            finally
            {
                if (img2 != null) img2.Dispose();
            }

            return img;
        }

        private Image DrawWatermark(Image img, string drawText)
        {
            if (!string.IsNullOrEmpty(drawText))
            {
                if (Config.WatermarkFont.Size == 0)
                {
                    ShowFontDialog(Config);
                }

                Font font = null;
                Brush backgroundBrush = null;

                try
                {
                    int offset = (int)Config.WatermarkOffset;

                    font = Config.WatermarkFont;
                    Size textSize = TextRenderer.MeasureText(drawText, font);
                    Size labelSize = new Size(textSize.Width + 10, textSize.Height + 10);
                    Point labelPosition = FindPosition(Config.WatermarkPositionMode, offset, img.Size, new Size(textSize.Width + 10, textSize.Height + 10), 1);

                    if (Config.WatermarkAutoHide && ((img.Width < labelSize.Width + offset) || (img.Height < labelSize.Height + offset)))
                    {
                        return img;
                    }

                    Rectangle labelRectangle = new Rectangle(Point.Empty, labelSize);
                    int backTrans = (int)Config.WatermarkBackTrans;
                    int fontTrans = (int)Config.WatermarkFontTrans;
                    Color fontColor = Config.WatermarkFontArgb;

                    using (Bitmap bmp = new Bitmap(labelRectangle.Width + 1, labelRectangle.Height + 1))
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                        if (Config.WatermarkUseCustomGradient)
                        {
                            backgroundBrush = GradientMaker.CreateGradientBrush(labelRectangle.Size, Config.GradientMakerOptions.GetBrushDataActive());
                        }
                        else
                        {
                            backgroundBrush = new LinearGradientBrush(labelRectangle, Color.FromArgb(backTrans, Config.WatermarkGradient1Argb),
                                Color.FromArgb(backTrans, Config.WatermarkGradient2Argb), Config.WatermarkGradientType);
                        }

                        using (GraphicsPath gPath = new GraphicsPath())
                        using (Pen borderPen = new Pen(Color.FromArgb(backTrans, Config.WatermarkBorderArgb)))
                        {
                            gPath.AddRoundedRectangle(labelRectangle, (float)Config.WatermarkCornerRadius);
                            g.FillPath(backgroundBrush, gPath);
                            g.DrawPath(borderPen, gPath);
                        }

                        using (Brush textBrush = new SolidBrush(Color.FromArgb(fontTrans, fontColor)))
                        using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        {
                            g.DrawString(drawText, font, textBrush, bmp.Width / 2, bmp.Height / 2, sf);
                        }

                        using (Graphics gImg = Graphics.FromImage(img))
                        {
                            gImg.SmoothingMode = SmoothingMode.HighQuality;
                            gImg.DrawImage(bmp, labelPosition);

                            /*if (Config.WatermarkAddReflection)
                            {
                                Bitmap bmp2 = AddReflection(bmp, 50, 200);
                                gImg.DrawImage(bmp2, new Rectangle(labelPosition.X, labelPosition.Y + bmp.Height - 1, bmp2.Width, bmp2.Height));
                            }*/
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugHelper.WriteException(ex, "Error while drawing watermark");
                }
                finally
                {
                    if (font != null) font.Dispose();
                    if (backgroundBrush != null) backgroundBrush.Dispose();
                }
            }

            return img;
        }

        // TODO: Replace AddReflection

        /*public static Bitmap AddReflection(Image bmp, int percentage, int transparency)
        {
            return null;

            Bitmap b = new Bitmap(bmp);
            b.RotateFlip(RotateFlipType.RotateNoneFlipY);
            b = b.Clone(new Rectangle(0, 0, b.Width, (int)(b.Height * ((float)percentage / 100))), PixelFormat.Format32bppArgb);
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            byte alpha;
            int nOffset = bmData.Stride - b.Width * 4;
            transparency.Between(0, 255);

            unsafe
            {
                byte* p = (byte*)(void*)bmData.Scan0;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        alpha = (byte)(transparency - transparency * (y + 1) / b.Height);
                        if (p[3] > alpha) p[3] = alpha;
                        p += 4;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return b;
        }*/
    }
}
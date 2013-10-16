/*
 * Greenshot - a free and open source screenshot tool
 * Copyright (C) 2007-2013  Thomas Braun, Jens Klingen, Robin Krom
 *
 * For more information see: http://getgreenshot.org/
 * The Greenshot project is hosted on Sourceforge: http://sourceforge.net/projects/greenshot/
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 1 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Greenshot.Drawing.Fields;
using Greenshot.Helpers;
using Greenshot.Plugin.Drawing;
using GreenshotPlugin.Core;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Greenshot.Drawing.Filters
{
    [Serializable()]
    public class PixelizationFilter : AbstractFilter
    {
        public PixelizationFilter(DrawableContainer parent)
            : base(parent)
        {
            AddField(GetType(), FieldType.PIXEL_SIZE, 5);
        }

        public override void Apply(Graphics graphics, Bitmap applyBitmap, Rectangle rect, RenderMode renderMode)
        {
            int pixelSize = GetFieldValueAsInt(FieldType.PIXEL_SIZE);
            Rectangle applyRect = ImageHelper.CreateIntersectRectangle(applyBitmap.Size, rect, Invert);
            if (pixelSize <= 1 || rect.Width == 0 || rect.Height == 0)
            {
                // Nothing to do
                return;
            }

            using (IFastBitmap dest = FastBitmap.CreateCloneOf(applyBitmap, rect))
            {
                ImageHelper.Pixelate(applyBitmap, pixelSize, rect, dest);
                dest.DrawTo(graphics, rect.Location);
            }
        }
    }
}
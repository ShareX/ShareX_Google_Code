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

using System.ComponentModel;
using System.Drawing;

namespace ScreenCapture
{
    public class SurfaceOptions
    {
        [DefaultValue(true), Description("Show coordinate and size information.")]
        public bool ShowInfo { get; set; }

        [DefaultValue(true), Description("Show screen wide crosshair.")]
        public bool ShowCrosshair { get; set; }

        [DefaultValue(true), Description("Show magnifier.")]
        public bool ShowMagnifier { get; set; }

        [DefaultValue(false), Description("Draw border around the shape.")]
        public bool DrawBorder { get; set; }

        [DefaultValue(false), Description("Draw checkerboard pattern replacing transparent areas.")]
        public bool DrawChecker { get; set; }

        [DefaultValue(false), Description("Complete capture as soon as the mouse button is released, except when capturing polygon.")]
        public bool QuickCrop { get; set; }

        [DefaultValue(false), Description("You can use window capture mode in all rectangle type shapes.")]
        public bool ForceWindowCapture { get; set; }

        [DefaultValue(false), Description("If window capture mode enabled this setting will also allow to capture window controls.")]
        public bool IncludeControls { get; set; }

        [DefaultValue(1), Description("Number of pixels to move shape at each arrow key stroke.")]
        public int MinMoveSpeed { get; set; }

        [DefaultValue(5), Description("Number of pixels to move shape at each arrow key stroke while holding Ctrl key.")]
        public int MaxMoveSpeed { get; set; }

        [DefaultValue(false), Description("Fixed shape size.")]
        public bool IsFixedSize { get; set; }

        [DefaultValue(typeof(Size), "250, 250"), Description("Fixed shape size.")]
        public Size FixedSize { get; set; }

        public SurfaceOptions()
        {
            ShowCrosshair = true;
            ShowMagnifier = true;
            ShowInfo = true;

            DrawBorder = false;
            DrawChecker = false;
            QuickCrop = false;

            MinMoveSpeed = 1;
            MaxMoveSpeed = 5;

            IsFixedSize = false;
            FixedSize = new Size(250, 250);
        }
    }
}
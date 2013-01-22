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

using HelpersLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareX
{
    public class ScreenRegionManager : IDisposable
    {
        private ScreenRegionForm regionForm;

        public async void Start(Rectangle captureRectangle, int startDelay)
        {
            if (captureRectangle != CaptureHelpers.GetScreenBounds())
            {
                regionForm = new ScreenRegionForm(captureRectangle);
                regionForm.Show();
                await TaskEx.Delay(startDelay);
                regionForm.ChangeColor(Color.FromArgb(0, 255, 0));
            }
            else
            {
                await TaskEx.Delay(startDelay);
            }
        }

        public void Dispose()
        {
            if (regionForm != null)
            {
                if (regionForm.Visible)
                {
                    regionForm.Close();
                }

                regionForm.Dispose();
            }
        }
    }
}
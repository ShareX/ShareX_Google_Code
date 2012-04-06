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
using System.Text;
using HelpersLib;

namespace UpdateCheckerLib
{
    public class UpdateInfo
    {
        public Version ApplicationVersion { get; set; }
        public Version LatestVersion { get; set; }
        public string URL { get; set; }
        public DateTime Date { get; set; }
        public string Summary { get; set; }
        public ReleaseChannelType ReleaseChannel { get; private set; }
        public UpdateStatus Status { get; set; }

        public UpdateInfo(ReleaseChannelType channel)
        {
            ReleaseChannel = channel;
        }

        public bool IsUpdateRequired
        {
            get
            {
                return ApplicationVersion != null && LatestVersion != null && !string.IsNullOrEmpty(URL) &&
                    (Helpers.CheckVersion(LatestVersion, ApplicationVersion));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} is your current version", ApplicationVersion));
            sb.AppendLine(string.Format("{0} is the latest {1}", LatestVersion, ReleaseChannel.GetDescription()));
            sb.AppendLine(string.Format("{1} was last updated on {0}", Date.ToLongDateString(), ReleaseChannel.GetDescription()));
            return sb.ToString();
        }
    }
}
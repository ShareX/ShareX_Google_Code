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

using System.Collections.Generic;
using System.ComponentModel;

namespace UploadersLib.HelperClasses
{
    public class MediaWikiAccount
    {
        [Category("MediaWiki")]
        public string Name { get; set; }

        [Category("MediaWiki")]
        public string Url { get; set; }

        [Category("MediaWiki")]
        public string Username { get; set; }

        [Category("MediaWiki"), PasswordPropertyText(true)]
        public string Password { get; set; }

        public List<MediaWikiHistory> History = new List<MediaWikiHistory>();

        public MediaWikiAccount() { }

        public MediaWikiAccount(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
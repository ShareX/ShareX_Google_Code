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

namespace UploadersLib.HelperClasses
{
    public class ProxyInfo
    {
        [Category("Settings"), DefaultValue("")]
        public string UserName { get; set; }

        [Category("Settings"), PasswordPropertyText(true), DefaultValue("")]
        public string Password { get; set; }

        [Category("Settings"), DefaultValue("")]
        public string Host { get; set; }

        [Category("Settings"), DefaultValue(8080), Description("Port Number")]
        public int Port { get; set; }

        [Category("Settings")]
        public Proxy ProxyType { get; set; }

        public ProxyInfo()
        {
            ApplyDefaultValues(this);
        }

        public ProxyInfo(string username, string password, string host, int port)
        {
            this.UserName = username;
            this.Password = password;
            this.Host = host;
            this.Port = port;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}:{2} ({3})", this.UserName, this.Host, this.Port, this.ProxyType.ToString());
        }

        public string GetAddress()
        {
            return string.Format("{0}:{1}", this.Host, this.Port);
        }

        public static void ApplyDefaultValues(object self)
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(self))
            {
                DefaultValueAttribute attr = prop.Attributes[typeof(DefaultValueAttribute)] as DefaultValueAttribute;
                if (attr == null) continue;
                prop.SetValue(self, attr.Value);
            }
        }
    }
}
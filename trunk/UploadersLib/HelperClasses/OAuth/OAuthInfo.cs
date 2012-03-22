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
    public class OAuthInfo
    {
        public string Description { get; set; }

        [Browsable(false)]
        public string OAuthVersion { get; set; }

        [Browsable(false)]
        public string ConsumerKey { get; set; }

        [Browsable(false)]
        public string ConsumerSecret { get; set; }

        [Browsable(false)]
        public string AuthToken { get; set; }

        [Browsable(false)]
        public string AuthSecret { get; set; }

        [Description("Verification Code from the Authorization Page")]
        public string AuthVerifier { get; set; }

        [ReadOnly(true)]
        public string UserToken { get; set; }

        [ReadOnly(true)]
        public string UserSecret { get; set; }

        public OAuthInfo()
        {
            Description = "New Account";
            OAuthVersion = "1.0";
        }

        public OAuthInfo(string consumerKey, string consumerSecret)
            : this()
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
        }

        public OAuthInfo(string consumerKey, string consumerSecret, string userToken, string userSecret)
            : this(consumerKey, consumerSecret)
        {
            UserToken = userToken;
            UserSecret = userSecret;
        }

        public static bool CheckOAuth(OAuthInfo oauth)
        {
            return oauth != null && !string.IsNullOrEmpty(oauth.ConsumerKey) && !string.IsNullOrEmpty(oauth.ConsumerSecret) &&
                !string.IsNullOrEmpty(oauth.UserToken) && !string.IsNullOrEmpty(oauth.UserSecret);
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
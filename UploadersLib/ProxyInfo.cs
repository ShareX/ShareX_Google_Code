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

using HelpersLib;
using Starksoft.Net.Proxy;
using System;
using System.ComponentModel;
using System.Net;

namespace UploadersLib.HelperClasses
{
    public class ProxyInfo
    {
        [DefaultValue("")]
        public string UserName { get; set; }

        [DefaultValue(""), PasswordPropertyText(true)]
        public string Password { get; set; }

        [DefaultValue("")]
        public string Host { get; set; }

        [DefaultValue(8080)]
        public int Port { get; set; }

        [DefaultValue(Proxy.HTTP)]
        public Proxy ProxyType { get; set; }

        public ProxyInfo()
        {
            UserName = "";
            Password = "";
            Host = "";
            Port = 8080;
            ProxyType = Proxy.HTTP;
        }

        public ProxyInfo(string username, string password, string host, int port)
        {
            UserName = username;
            Password = password;
            Host = host;
            Port = port;
        }

        public string GetAddress()
        {
            return string.Format("{0}:{1}", Host, Port);
        }

        public void AutoFillProxy()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                UserName = Environment.UserName;
            }

            WebProxy proxy = Helpers.GetDefaultWebProxy();
            if (proxy != null && proxy.Address != null)
            {
                if (string.IsNullOrEmpty(Host))
                {
                    Host = proxy.Address.Host;
                }

                if (Port == 0)
                {
                    Port = proxy.Address.Port;
                }
            }
        }

        public bool IsValidProxy()
        {
            return !string.IsNullOrEmpty(Host) && Port > 0;
        }

        public IWebProxy GetWebProxy()
        {
            if (IsValidProxy())
            {
                NetworkCredential credentials = new NetworkCredential(UserName, Password);
                return new WebProxy(GetAddress(), true, null, credentials);
            }

            return null;
        }

        public IProxyClient GetProxyClient()
        {
            if (IsValidProxy())
            {
                Starksoft.Net.Proxy.ProxyType proxyType;

                switch (ProxyType)
                {
                    case Proxy.HTTP:
                        proxyType = Starksoft.Net.Proxy.ProxyType.Http;
                        break;
                    case Proxy.SOCKS4:
                        proxyType = Starksoft.Net.Proxy.ProxyType.Socks4;
                        break;
                    case Proxy.SOCKS4a:
                        proxyType = Starksoft.Net.Proxy.ProxyType.Socks4a;
                        break;
                    case Proxy.SOCKS5:
                        proxyType = Starksoft.Net.Proxy.ProxyType.Socks5;
                        break;
                    default:
                        proxyType = Starksoft.Net.Proxy.ProxyType.None;
                        break;
                }

                ProxyClientFactory proxy = new ProxyClientFactory();
                return proxy.CreateProxyClient(proxyType, Host, Port, UserName, Password);
            }

            return null;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}:{2} ({3})", UserName, Host, Port, ProxyType.ToString());
        }
    }
}
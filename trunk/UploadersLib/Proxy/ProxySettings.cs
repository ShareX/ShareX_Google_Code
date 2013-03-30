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

using Starksoft.Net.Proxy;
using System.Net;

namespace UploadersLib.HelperClasses
{
    public class ProxySettings
    {
        public EProxyConfigType ProxyConfig { get; private set; }

        public ProxyInfo ProxyActive { get; set; }

        public IWebProxy GetWebProxy
        {
            get
            {
                if (ProxyActive != null)
                {
                    string host = ProxyActive.Host;
                    NetworkCredential credentials = new NetworkCredential(ProxyActive.UserName, ProxyActive.Password);

                    if (!string.IsNullOrEmpty(host))
                    {
                        ProxyConfig = EProxyConfigType.ManualProxy;
                        return new WebProxy(ProxyActive.GetAddress(), true, null, credentials);
                    }
                    else
                    {
                        WebProxy systemProxy = HelpersLib.Helpers.GetDefaultWebProxy();
                        if (systemProxy.Address != null && !string.IsNullOrEmpty(systemProxy.Address.Authority))
                        {
                            ProxyConfig = EProxyConfigType.SystemProxy;
                            systemProxy.Credentials = credentials;
                            return systemProxy;
                        }
                    }
                }

                ProxyConfig = EProxyConfigType.NoProxy;
                return null;
            }
        }

        public IProxyClient GetProxyClient(ProxyInfo myProxyInfo)
        {
            if (ProxyConfig != EProxyConfigType.NoProxy && myProxyInfo != null)
            {
                ProxyType proxyType;

                switch (myProxyInfo.ProxyType)
                {
                    case Proxy.HTTP:
                        proxyType = ProxyType.Http;
                        break;

                    case Proxy.SOCKS4:
                        proxyType = ProxyType.Socks4;
                        break;

                    case Proxy.SOCKS4a:
                        proxyType = ProxyType.Socks4a;
                        break;

                    case Proxy.SOCKS5:
                        proxyType = ProxyType.Socks5;
                        break;

                    default:
                        proxyType = ProxyType.None;
                        break;
                }

                ProxyClientFactory proxy = new ProxyClientFactory();

                return proxy.CreateProxyClient(proxyType, myProxyInfo.Host, myProxyInfo.Port, myProxyInfo.UserName, myProxyInfo.Password);
            }

            return null;
        }

        public IProxyClient GetProxyClient()
        {
            if (ProxyActive != null)
            {
                return GetProxyClient(ProxyActive);
            }

            return null;
        }
    }
}
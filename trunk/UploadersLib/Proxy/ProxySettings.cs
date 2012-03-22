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
using System.Net;
using Starksoft.Net.Proxy;

namespace UploadersLib.HelperClasses
{
    public enum EProxyConfigType
    {
        [Description("No proxy")]
        NoProxy,
        [Description("Manual proxy configuration")]
        ManualProxy,
        [Description("Use system proxy settings")]
        SystemProxy
    }

    public class ProxySettings
    {
        public EProxyConfigType ProxyConfig { get; set; }

        public ProxyInfo ProxyActive { get; set; }

        public IWebProxy GetWebProxy
        {
            get
            {
                switch (ProxyConfig)
                {
                    case EProxyConfigType.ManualProxy:
                        if (ProxyActive != null)
                        {
                            NetworkCredential credential = new NetworkCredential(ProxyActive.UserName, ProxyActive.Password);
                            return new WebProxy(ProxyActive.GetAddress(), true, null, credential);
                        }
                        break;
                    case EProxyConfigType.SystemProxy:
                        return HttpWebRequest.DefaultWebProxy;
                }

                return null;
            }
        }

        public IProxyClient GetProxyClient(ProxyInfo myProxyInfo)
        {
            if (myProxyInfo != null)
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
            if (ProxyConfig != EProxyConfigType.NoProxy && ProxyActive != null)
            {
                return GetProxyClient(ProxyActive);
            }

            return null;
        }
    }
}
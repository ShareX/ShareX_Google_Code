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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CG.Web.MegaApiClient;
using UploadersLib.HelperClasses;

namespace UploadersLib.FileUploaders
{
    public sealed class Mega : FileUploader, IWebClient
    {
        private readonly MegaApiClient _megaClient;
        private readonly MegaApiClient.AuthInfos _authInfos;
        private readonly string _parentNodeId;

        public Mega()
            : this(null, null)
        {
        }

        public Mega(MegaApiClient.AuthInfos authInfos)
            : this(authInfos, null)
        {
        }

        public Mega(MegaApiClient.AuthInfos authInfos, string parentNodeId)
        {
            this._megaClient = new MegaApiClient(this);
            this._authInfos = authInfos;
            this._parentNodeId = parentNodeId;
        }

        public bool TryLogin()
        {
            try
            {
                this.Login();
                return true;
            }
            catch (ApiException)
            {
                return false;
            }
        }

        private void Login()
        {
            if (this._authInfos == null)
            {
                this._megaClient.LoginAnonymous();
            }
            else
            {
                this._megaClient.Login(this._authInfos);
            }
        }

        internal IEnumerable<DisplayNode> GetDisplayNodes()
        {
            IEnumerable<Node> nodes = this._megaClient.GetNodes().Where(n => n.Type == NodeType.Directory || n.Type == NodeType.Root).ToArray();
            List<DisplayNode> displayNodes = new List<DisplayNode>();

            foreach (Node node in nodes)
            {
                displayNodes.Add(new DisplayNode(node, nodes));
            }

            displayNodes.Sort((x, y) => string.Compare(x.DisplayName, y.DisplayName, StringComparison.CurrentCultureIgnoreCase));
            displayNodes.Insert(0, DisplayNode.EmptyNode);

            return displayNodes;
        }

        public Node GetParentNode()
        {
            if (this._authInfos == null || this._parentNodeId == null)
            {
                return this._megaClient.GetNodes().SingleOrDefault(n => n.Type == NodeType.Root);
            }
            else
            {
                return this._megaClient.GetNodes().SingleOrDefault(n => n.Id == this._parentNodeId);
            }
        }

        public override UploadResult Upload(Stream stream, string fileName)
        {
            this.Login();

            Node createdNode = this._megaClient.Upload(stream, fileName, this.GetParentNode());

            UploadResult res = new UploadResult();
            res.IsURLExpected = true;
            res.URL = this._megaClient.GetDownloadLink(createdNode).ToString();

            return res;
        }

        #region IWebClient

        public string PostRequestJson(Uri url, string jsonData)
        {
            return this.SendPostRequestJSON(url.ToString(), jsonData);
        }

        public string PostRequestRaw(Uri url, Stream dataStream)
        {
            return this.SendPostRequestStream(url.ToString(), dataStream, "application/octet-stream");
        }

        public Stream GetRequestRaw(Uri url)
        {
            throw new NotImplementedException();
        }

        #endregion

        internal class DisplayNode
        {
            public static readonly DisplayNode EmptyNode = new DisplayNode();

            private DisplayNode()
            {
                this.DisplayName = "[Select a folder]";
            }

            public DisplayNode(Node node, IEnumerable<Node> nodes)
            {
                this.Node = node;
                this.DisplayName = this.GenerateDisplayName(node, nodes);
            }

            public Node Node { get; private set; }

            public string DisplayName { get; private set; }

            private string GenerateDisplayName(Node node, IEnumerable<Node> nodes)
            {
                List<string> nodesTree = new List<string>();

                Node parent = node;
                do
                {
                    if (parent.Type == NodeType.Directory)
                    {
                        nodesTree.Add(parent.Name);
                    }
                    else
                    {
                        nodesTree.Add(parent.Type.ToString());
                    }

                    parent = nodes.FirstOrDefault(n => n.Id == parent.ParentId);
                }
                while (parent != null);

                nodesTree.Reverse();
                return string.Join(@"\", nodesTree.ToArray());
            }
        }
    }
}

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
using System.Collections.Generic;
using System.IO;
using System.Xml;
using HelpersLib;

namespace HistoryLib
{
    internal class XMLManager
    {
        private static object thisLock = new object();

        private string xmlPath;

        public XMLManager(string xmlFilePath)
        {
            xmlPath = xmlFilePath;
        }

        public List<HistoryItem> Load()
        {
            List<HistoryItem> historyItemList = new List<HistoryItem>();

            lock (thisLock)
            {
                if (!string.IsNullOrEmpty(xmlPath) && File.Exists(xmlPath))
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(xmlPath);

                    XmlNode rootNode = xml.ChildNodes[1];

                    if (rootNode.Name == "HistoryItems" && rootNode.ChildNodes != null && rootNode.ChildNodes.Count > 0)
                    {
                        historyItemList.AddRange(ParseHistoryItem(rootNode));
                    }
                }
            }

            return historyItemList;
        }

        public bool AddHistoryItem(HistoryItem historyItem)
        {
            if (!string.IsNullOrEmpty(xmlPath))
            {
                lock (thisLock)
                {
                    XmlDocument xml = new XmlDocument();

                    if (File.Exists(xmlPath))
                    {
                        xml.Load(xmlPath);
                    }

                    if (xml.ChildNodes.Count == 0)
                    {
                        xml.AppendChild(xml.CreateXmlDeclaration("1.0", "UTF-8", null));
                        xml.AppendElement("HistoryItems");
                    }

                    XmlNode rootNode = xml.ChildNodes[1];

                    if (rootNode.Name == "HistoryItems")
                    {
                        historyItem.ID = Helpers.GetRandomAlphanumeric(12);

                        XmlNode historyItemNode = rootNode.PrependElement("HistoryItem");

                        historyItemNode.AppendElement("ID", historyItem.ID);
                        historyItemNode.AppendElement("Filename", historyItem.Filename);
                        historyItemNode.AppendElement("Filepath", historyItem.Filepath);
                        historyItemNode.AppendElement("DateTimeUtc", historyItem.DateTimeUtc.ToString("o"));
                        historyItemNode.AppendElement("Type", historyItem.Type);
                        historyItemNode.AppendElement("Host", historyItem.Host);
                        historyItemNode.AppendElement("URL", historyItem.URL);
                        historyItemNode.AppendElement("ThumbnailURL", historyItem.ThumbnailURL);
                        historyItemNode.AppendElement("DeletionURL", historyItem.DeletionURL);
                        historyItemNode.AppendElement("ShortenedURL", historyItem.ShortenedURL);

                        xml.Save(xmlPath);

                        return true;
                    }
                }
            }

            return false;
        }

        public bool RemoveHistoryItem(HistoryItem historyItem)
        {
            lock (thisLock)
            {
                if (historyItem != null && !string.IsNullOrEmpty(historyItem.ID) && !string.IsNullOrEmpty(xmlPath) && File.Exists(xmlPath))
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(xmlPath);

                    XmlNode rootNode = xml.ChildNodes[1];

                    if (rootNode.Name == "HistoryItems" && rootNode.ChildNodes != null && rootNode.ChildNodes.Count > 0)
                    {
                        foreach (HistoryItem hi in ParseHistoryItem(rootNode))
                        {
                            if (hi.ID == historyItem.ID)
                            {
                                rootNode.RemoveChild(hi.Node);
                                xml.Save(xmlPath);
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private IEnumerable<HistoryItem> ParseHistoryItem(XmlNode rootNode)
        {
            foreach (XmlNode historyNode in rootNode.ChildNodes)
            {
                HistoryItem hi = new HistoryItem();

                foreach (XmlNode node in historyNode.ChildNodes)
                {
                    if (node == null || string.IsNullOrEmpty(node.InnerText)) continue;

                    switch (node.Name)
                    {
                        case "ID":
                            hi.ID = node.InnerText;
                            break;
                        case "Filename":
                            hi.Filename = node.InnerText;
                            break;
                        case "Filepath":
                            hi.Filepath = node.InnerText;
                            break;
                        case "DateTimeUtc":
                            hi.DateTimeUtc = DateTime.Parse(node.InnerText);
                            break;
                        case "Type":
                            hi.Type = node.InnerText;
                            break;
                        case "Host":
                            hi.Host = node.InnerText;
                            break;
                        case "URL":
                            hi.URL = node.InnerText;
                            break;
                        case "ThumbnailURL":
                            hi.ThumbnailURL = node.InnerText;
                            break;
                        case "DeletionURL":
                            hi.DeletionURL = node.InnerText;
                            break;
                        case "ShortenedURL":
                            hi.ShortenedURL = node.InnerText;
                            break;
                    }
                }

                hi.Node = historyNode;

                yield return hi;
            }
        }
    }
}
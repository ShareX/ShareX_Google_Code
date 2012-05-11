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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HelpersLib
{
    public enum SerializationType { Binary, Xml, Json }

    public static class SettingsHelper
    {
        public static bool Save(object obj, string filePath, SerializationType type, bool createBackup = true)
        {
            DebugHelper.WriteLine("Settings save started: " + filePath);

            bool isSuccess = false;

            try
            {
                lock (obj)
                {
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            Save(obj, ms, type);

                            if (createBackup && File.Exists(filePath))
                            {
                                File.Copy(filePath, filePath + ".bak", true);
                            }

                            isSuccess = ms.WriteToFile(filePath);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                DebugHelper.WriteException(e);
            }
            finally
            {
                string message;

                if (isSuccess)
                {
                    message = "Settings save successful";
                }
                else
                {
                    message = "Settings save failed";
                }

                DebugHelper.WriteLine(string.Format("{0}: {1}", message, filePath));
            }

            return isSuccess;
        }

        public static void Save(object obj, Stream stream, SerializationType type)
        {
            switch (type)
            {
                case SerializationType.Binary:
                    new BinaryFormatter().Serialize(stream, obj);
                    break;
                case SerializationType.Xml:
                    Type t = obj.GetType();
                    new XmlSerializer(t).Serialize(stream, obj);
                    break;
                case SerializationType.Json:
                    StreamWriter streamWriter = new StreamWriter(stream);
                    JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
                    jsonWriter.Formatting = Formatting.Indented;
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Converters.Add(new StringEnumConverter());
                    serializer.Serialize(jsonWriter, obj);
                    jsonWriter.Flush();
                    break;
            }
        }

        public static T Load<T>(string path, SerializationType type, bool checkBackup = true) where T : new()
        {
            if (!string.IsNullOrEmpty(path))
            {
                DebugHelper.WriteLine("Settings load started: " + path);

                try
                {
                    if (File.Exists(path))
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            if (fs.Length > 0)
                            {
                                T settings = Load<T>(fs, type);

                                DebugHelper.WriteLine("Settings load finished: " + path);

                                return settings;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    DebugHelper.WriteException(e, "Settings load failed");
                }
            }

            if (checkBackup)
            {
                return Load<T>(path + ".bak", type, false);
            }

            DebugHelper.WriteLine("Settings not found. Loading new instance.");

            return new T();
        }

        public static T Load<T>(Stream stream, SerializationType type)
        {
            T settings;

            switch (type)
            {
                case SerializationType.Binary:
                    settings = (T)new BinaryFormatter().Deserialize(stream);
                    break;
                default:
                case SerializationType.Xml:
                    settings = (T)new XmlSerializer(typeof(T)).Deserialize(stream);
                    break;
                case SerializationType.Json:
                    using (StreamReader streamReader = new StreamReader(stream))
                    using (JsonReader jsonReader = new JsonTextReader(streamReader))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Converters.Add(new StringEnumConverter());
                        serializer.Error += (sender, e) => e.ErrorContext.Handled = true;
                        settings = serializer.Deserialize<T>(jsonReader);
                    }
                    break;
            }

            return settings;
        }
    }
}
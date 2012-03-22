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
using System.Security.Permissions;

namespace SingleInstanceApplication
{
    /// <summary>
    /// Shared object for processes
    /// </summary>
    [Serializable]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    internal class InstanceProxy : MarshalByRefObject
    {
        /// <summary>
        /// Gets a value indicating whether this instance is first instance.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is first instance; otherwise, <c>false</c>.
        /// </value>
        public static bool IsFirstInstance { get; internal set; }

        /// <summary>
        /// Gets the command line args.
        /// </summary>
        /// <value>The command line args.</value>
        public static string[] CommandLineArgs { get; internal set; }

        /// <summary>
        /// Sets the command line args.
        /// </summary>
        /// <param name="isFirstInstance">if set to <c>true</c> [is first instance].</param>
        /// <param name="commandLineArgs">The command line args.</param>
        public void SetCommandLineArgs(bool isFirstInstance, string[] commandLineArgs)
        {
            IsFirstInstance = isFirstInstance;
            CommandLineArgs = commandLineArgs;
        }
    }

    /// <summary>
    ///
    /// </summary>
    public class InstanceCallbackEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceCallbackEventArgs"/> class.
        /// </summary>
        /// <param name="isFirstInstance">if set to <c>true</c> [is first instance].</param>
        /// <param name="commandLineArgs">The command line args.</param>
        internal InstanceCallbackEventArgs(bool isFirstInstance, string[] commandLineArgs)
        {
            IsFirstInstance = isFirstInstance;
            CommandLineArgs = commandLineArgs;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is first instance.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is first instance; otherwise, <c>false</c>.
        /// </value>
        public bool IsFirstInstance { get; private set; }

        /// <summary>
        /// Gets or sets the command line args.
        /// </summary>
        /// <value>The command line args.</value>
        public string[] CommandLineArgs { get; private set; }
    }
}
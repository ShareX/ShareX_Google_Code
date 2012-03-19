#region License Information (GPL v3)

/*
    ShareX - A program that allows to you take screenshots and share any file type
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
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Threading;
using System.Windows.Forms;

namespace SingleInstanceApplication
{
    /// <summary>
    /// Application Instance Manager
    /// </summary>
    public static class ApplicationInstanceManager
    {
        /// <summary>
        /// Creates the single instance.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public static bool CreateSingleInstance(string name, EventHandler<InstanceCallbackEventArgs> callback)
        {
            string eventName = string.Format("{0}-{1}", Environment.MachineName, name);

            InstanceProxy.IsFirstInstance = false;
            InstanceProxy.CommandLineArgs = Environment.GetCommandLineArgs();

            try
            {
                // try opening existing wait handle
                using (EventWaitHandle eventWaitHandle = EventWaitHandle.OpenExisting(eventName))
                {
                    // pass console arguments to shared object
                    UpdateRemoteObject(name);

                    // invoke (signal) wait handle on other process
                    if (eventWaitHandle != null) eventWaitHandle.Set();
                }

                // kill current process
                Environment.Exit(0);
            }
            catch
            {
                // got exception = handle wasn't created yet
                InstanceProxy.IsFirstInstance = true;

                // init handle
                using (EventWaitHandle eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, eventName))
                {
                    // register wait handle for this instance (process)
                    ThreadPool.RegisterWaitForSingleObject(eventWaitHandle, WaitOrTimerCallback, callback, Timeout.Infinite, false);
                }

                // register shared type (used to pass data between processes)
                RegisterRemoteType(name);
            }

            return InstanceProxy.IsFirstInstance;
        }

        public static bool CreateSingleInstance(EventHandler<InstanceCallbackEventArgs> callback)
        {
            return CreateSingleInstance(Application.ProductName, callback);
        }

        /// <summary>
        /// Updates the remote object.
        /// </summary>
        /// <param name="uri">The remote URI.</param>
        private static void UpdateRemoteObject(string uri)
        {
            // register net-pipe channel
            var clientChannel = new IpcClientChannel();
            ChannelServices.RegisterChannel(clientChannel, true);

            // get shared object from other process
            var proxy =
                Activator.GetObject(typeof(InstanceProxy),
                string.Format("ipc://{0}{1}/{1}", Environment.MachineName, uri)) as InstanceProxy;

            // pass current command line args to proxy
            if (proxy != null)
                proxy.SetCommandLineArgs(InstanceProxy.IsFirstInstance, InstanceProxy.CommandLineArgs);

            // close current client channel
            ChannelServices.UnregisterChannel(clientChannel);
        }

        /// <summary>
        /// Registers the remote type.
        /// </summary>
        /// <param name="uri">The URI.</param>
        private static void RegisterRemoteType(string uri)
        {
            // register remote channel (net-pipes)
            var serverChannel = new IpcServerChannel(Environment.MachineName + uri);
            ChannelServices.RegisterChannel(serverChannel, true);

            // register shared type
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(InstanceProxy), uri, WellKnownObjectMode.Singleton);

            // close channel, on process exit
            Process process = Process.GetCurrentProcess();
            process.Exited += delegate { ChannelServices.UnregisterChannel(serverChannel); };
        }

        /// <summary>
        /// Wait Or Timer Callback Handler
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="timedOut">if set to <c>true</c> [timed out].</param>
        private static void WaitOrTimerCallback(object state, bool timedOut)
        {
            // cast to event handler
            var callback = state as EventHandler<InstanceCallbackEventArgs>;
            if (callback == null) return;

            // invoke event handler on other process
            callback(state, new InstanceCallbackEventArgs(InstanceProxy.IsFirstInstance, InstanceProxy.CommandLineArgs));
        }
    }
}
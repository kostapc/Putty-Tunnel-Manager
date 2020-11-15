/**
 * Copyright (c) 2009, Joeri Bekker
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using JoeriBekker.PuttyTunnelManager.Forms;

namespace JoeriBekker.PuttyTunnelManager
{
    static class Program
    {
        public static Logging Log = new Logging();

        public static TrayIcon TrayIcon;

        private static Mutex mutex;

        private static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string exeName = fileInfo.Name;
            bool createdNew;

            mutex = new Mutex(true, "Global\\" + exeName, out createdNew);
            if (createdNew)
                mutex.ReleaseMutex();

            return !createdNew;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Log.WriteMessage("PTM starting");
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ErrosHandler);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (IsAlreadyRunning())
            {
                MessageBox.Show("An instance of " + Application.ProductName + " is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TrayIcon = new TrayIcon();

            Application.Run();
            TrayIcon = null;
        }

        static void ErrosHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Log.WriteError(args.ExceptionObject, "unhandled error from " + sender.ToString());
        }
    }

}

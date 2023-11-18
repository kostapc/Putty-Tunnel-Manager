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
using System.IO;
using Microsoft.Win32;

namespace JoeriBekker.PuttyTunnelManager
{
    class PuttyTunnelManagerSettings
    {
        private static PuttyTunnelManagerSettings instance = null;

        public static PuttyTunnelManagerSettings Instance()
        {
            if (PuttyTunnelManagerSettings.instance == null)
                PuttyTunnelManagerSettings.instance = new PuttyTunnelManagerSettings();

            return PuttyTunnelManagerSettings.instance;
        }

        public static string PTM_REGISTRY_KEYPATH_ROOT = @"Software\Joeri Bekker\PuTTY Tunnel Manager";
        public static string PTM_REGISTRY_KEYPATH_SESSIONS = PTM_REGISTRY_KEYPATH_ROOT + @"\Sessions";
        public static string PTM_REGISTRY_KEY_PLINK_LOCATION = @"PuttyLinkLocation";

        private PuttyTunnelManagerSettings()
        {
            Registry.CurrentUser.CreateSubKey(PTM_REGISTRY_KEYPATH_ROOT);

            if (!this.HasPlink)
            {
                string obviousPlinkPath = Path.Combine(Directory.GetCurrentDirectory(), "plink.exe");
                if (File.Exists(obviousPlinkPath))
                    this.PlinkLocation = obviousPlinkPath;
            }
        }

        public string PlinkLocation
        {
            get
            {
                RegistryKey ptmRootKey = Registry.CurrentUser.OpenSubKey(PTM_REGISTRY_KEYPATH_ROOT);
                return ptmRootKey.GetValue(PTM_REGISTRY_KEY_PLINK_LOCATION, "").ToString();
            }
            set
            {
                RegistryKey ptmRootKey = Registry.CurrentUser.OpenSubKey(PTM_REGISTRY_KEYPATH_ROOT, true);
                ptmRootKey.SetValue(PTM_REGISTRY_KEY_PLINK_LOCATION, value, RegistryValueKind.String);
            }
        }

        public bool HasPlink
        {
            get { return File.Exists(this.PlinkLocation); }
        }
    }
}

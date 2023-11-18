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
using Microsoft.Win32;

namespace JoeriBekker.PuttyTunnelManager
{
    class PuttySettings
    {
        public static string PUTTY_REGISTRY_KEYPATH_ROOT = @"Software\SimonTatham\PuTTY";
        public static string PUTTY_REGISTRY_KEYPATH_SESSIONS = PUTTY_REGISTRY_KEYPATH_ROOT + @"\Sessions";
        public static string PUTTY_REGISTRY_KEYPATH_SSH_HOST_KEYS = PUTTY_REGISTRY_KEYPATH_ROOT + @"\SshHostKeys";

        private static PuttySettings instance = null;

        public static PuttySettings Instance()
        {
            if (PuttySettings.instance == null)
                PuttySettings.instance = new PuttySettings();

            return PuttySettings.instance;
        }

        private PuttySettings()
        {
        }

        public string[] Sessions
        {
            get {
                try
                {
                    RegistryKey sessionsKey = Registry.CurrentUser.OpenSubKey(PUTTY_REGISTRY_KEYPATH_SESSIONS);
                    return sessionsKey.GetSubKeyNames();
                }
                catch (Exception)
                {
                    return new string[0];
                }
            }
        }

        public string[] SshHostKeys
        {
            get
            {
                try
                {
                    RegistryKey sshHostKeysKey = Registry.CurrentUser.OpenSubKey(PUTTY_REGISTRY_KEYPATH_SSH_HOST_KEYS);
                    return sshHostKeysKey.GetValueNames();
                }
                catch (Exception)
                {
                    return new string[0];
                }
            }
        }
    }
}

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
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using Microsoft.Win32;

namespace JoeriBekker.PuttyTunnelManager
{
    class Session
    {
        public static string PUTTY_REGISTRY_KEY_SESSION_HOSTNAME            = "HostName";
        public static string PUTTY_REGISTRY_KEY_SESSION_PORTFORWARDINGS     = "PortForwardings";
        public static string PUTTY_REGISTRY_KEY_SESSION_USERNAME            = "Username";
        public static string PUTTY_REGISTRY_KEY_SESSION_PORTNUMBER          = "PortNumber";
        public static string PUTTY_REGISTRY_KEY_SESSION_COMPRESSION         = "Compression";
        public static string PUTTY_REGISTRY_KEY_SESSION_LOCALPORTACCEPTALL  = "LocalPortAcceptAll";

        public static string PTM_REGISTRY_KEY_SESSION_PORTFORWARDINGS       = "PortForwardings";
        public static string PTM_REGISTRY_KEY_SESSION_USEPTMFORTUNNELS      = "UsePtmForTunnels";

        private string name;
        private string hostname;
        private string username;
        private int port;
        private bool compression;
        private bool localPortsAcceptAll;
        private List<Tunnel> tunnels;

        private bool usePtmForTunnels;
        private PuttyLink puttyLink;

        private bool resume;

        public static List<Session> OpenSessions = new List<Session>();

        public Session(string name, string hostname, int port)
        {
            this.name = name;
            this.hostname = hostname;
            this.username = "";
            this.port = port;
            this.compression = false;
            this.localPortsAcceptAll = false;
            this.tunnels = new List<Tunnel>();

            this.usePtmForTunnels = false;
            this.puttyLink = null;

            this.resume = false;

            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
        }

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Suspend && this.IsOpen)
            {
                this.resume = true;
                this.Close();
            }
            else if (e.Mode == PowerModes.Resume && this.resume)
            {
                this.resume = false;
                this.Open();
            }
        }

        public string PuttyKeyPath
        {
            get { return PuttySettings.PUTTY_REGISTRY_KEYPATH_SESSIONS + @"\" + Uri.EscapeUriString(this.name); }
        }

        public string PuttyTunnelManagerKeyPath
        {
            get { return PuttyTunnelManagerSettings.PTM_REGISTRY_KEYPATH_SESSIONS + @"\" + Uri.EscapeUriString(name); }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Hostname
        {
            get { return this.hostname; }
            set { this.hostname = value; }
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public int Port
        {
            get { return this.port; }
            set { this.port = value; }
        }

        public bool Compression
        {
            get { return this.compression; }
            set { this.compression = value; }
        }

        public bool LocalPortsAcceptAll
        {
            get { return this.localPortsAcceptAll; }
            set { this.localPortsAcceptAll = value; }
        }

        public bool UsePtmForTunnels
        {
            get { return this.usePtmForTunnels; }
            set { this.usePtmForTunnels = value; }
        }

        public List<Tunnel> Tunnels
        {
            get { return tunnels; }
        }

        public bool IsOpen
        {
            get { return (this.puttyLink != null && this.puttyLink.IsActive); }
        }

        public virtual void Close()
        {
            if (this.IsOpen)
                this.puttyLink.Stop();

            //if (OpenSessions.Contains(this))
            //    OpenSessions.Remove(this);

            this.puttyLink = null;
        }

        public virtual void Open()
        {
            if (this.IsOpen)
                throw new SessionAlreadyOpenException();

            // Rather then just checking our own tunnels, just go over TCP listeners.
            foreach (Tunnel tunnel in this.Tunnels)
            {
                IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                IPEndPoint[] ipEndPoints = ipGlobalProperties.GetActiveTcpListeners();

                foreach (IPEndPoint ipEndPoint in ipEndPoints)
                {
                    if (ipEndPoint.Port == tunnel.SourcePort)
                    {
                        throw new PortAlreadyInUseException(tunnel);
                    }
                }
            }

            this.puttyLink = new PuttyLink(this);
            Thread thread = new Thread(new ThreadStart(this.puttyLink.Start));
            thread.IsBackground = true;
            thread.Start();

            //OpenSessions.Add(this);
        }

        public virtual void Serialize()
        {
            RegistryKey puttySessionKey = Registry.CurrentUser.CreateSubKey(this.PuttyKeyPath);

            puttySessionKey.SetValue(PUTTY_REGISTRY_KEY_SESSION_HOSTNAME, this.hostname, RegistryValueKind.String);
            puttySessionKey.SetValue(PUTTY_REGISTRY_KEY_SESSION_PORTNUMBER, this.port, RegistryValueKind.DWord);
            puttySessionKey.SetValue(PUTTY_REGISTRY_KEY_SESSION_USERNAME, this.username, RegistryValueKind.String);
            puttySessionKey.SetValue(PUTTY_REGISTRY_KEY_SESSION_COMPRESSION, this.compression, RegistryValueKind.DWord);
            puttySessionKey.SetValue(PUTTY_REGISTRY_KEY_SESSION_LOCALPORTACCEPTALL, this.localPortsAcceptAll, RegistryValueKind.DWord);

            StringBuilder buffer = new StringBuilder();
            foreach (Tunnel tunnel in this.Tunnels)
            {
                buffer.Append(tunnel.Serialize());
            }

            if (this.usePtmForTunnels)
            {
                // Save Tunnel Manager specific settings
                RegistryKey ptmSessionKey = Registry.CurrentUser.CreateSubKey(this.PuttyTunnelManagerKeyPath);
                ptmSessionKey.SetValue(PTM_REGISTRY_KEY_SESSION_PORTFORWARDINGS, buffer.ToString(), RegistryValueKind.String);
                ptmSessionKey.SetValue(PTM_REGISTRY_KEY_SESSION_USEPTMFORTUNNELS, this.usePtmForTunnels, RegistryValueKind.DWord);
                ptmSessionKey.Close();
            }
            else
            {
                puttySessionKey.SetValue(PUTTY_REGISTRY_KEY_SESSION_PORTFORWARDINGS, buffer.ToString(), RegistryValueKind.String);
            }

            puttySessionKey.Close();
        }

        public static Session Load(string keyName)
        {
            string puttyKeyPath = PuttySettings.PUTTY_REGISTRY_KEYPATH_SESSIONS + @"\" + keyName;
            RegistryKey puttySessionKey = Registry.CurrentUser.OpenSubKey(puttyKeyPath);

            Session session = new Session(
                Uri.UnescapeDataString(keyName),
                puttySessionKey.GetValue(PUTTY_REGISTRY_KEY_SESSION_HOSTNAME, "").ToString(),
                Int32.Parse(puttySessionKey.GetValue(PUTTY_REGISTRY_KEY_SESSION_PORTNUMBER, "22").ToString())
            );

            session.Username = puttySessionKey.GetValue(PUTTY_REGISTRY_KEY_SESSION_USERNAME, "").ToString();
            session.Compression = puttySessionKey.GetValue(PUTTY_REGISTRY_KEY_SESSION_COMPRESSION, 0).Equals(1);
            session.LocalPortsAcceptAll = puttySessionKey.GetValue(PUTTY_REGISTRY_KEY_SESSION_LOCALPORTACCEPTALL, 0).Equals(1);

            string ptmKeyPath = PuttyTunnelManagerSettings.PTM_REGISTRY_KEYPATH_SESSIONS + @"\" + keyName;
            RegistryKey ptmSessionKey = Registry.CurrentUser.OpenSubKey(ptmKeyPath);

            // Load Tunnel Manager specific settings.
            if (ptmSessionKey != null)
            {
                session.UsePtmForTunnels = ptmSessionKey.GetValue(PTM_REGISTRY_KEY_SESSION_USEPTMFORTUNNELS, 0).Equals(1);
            }

            string[] portForwardingList;
            if (session.UsePtmForTunnels && ptmSessionKey != null)
            {
                portForwardingList = ptmSessionKey.GetValue(PTM_REGISTRY_KEY_SESSION_PORTFORWARDINGS, "").ToString().Split(',');
                ptmSessionKey.Close();
            }
            else
                portForwardingList = puttySessionKey.GetValue(PUTTY_REGISTRY_KEY_SESSION_PORTFORWARDINGS, "").ToString().Split(',');

            puttySessionKey.Close();

            foreach (string portForwarding in portForwardingList)
            {
                if (portForwarding.Length > 0)
                {
                    Tunnel t = Tunnel.Load(session, portForwarding);
                    session.Tunnels.Add(t);
                }
            }

            return session;
        }

        public virtual void Delete()
        {
            try
            {
                if (this.IsOpen)
                    this.Close();

                Registry.CurrentUser.DeleteSubKey(this.PuttyKeyPath);
                Registry.CurrentUser.DeleteSubKey(this.PuttyTunnelManagerKeyPath);
            }
            catch (Exception) { }
        }

        public virtual void RemovePuttyTunnels()
        {
            RegistryKey puttySessionKey = Registry.CurrentUser.OpenSubKey(this.PuttyKeyPath, true);
            puttySessionKey.SetValue(PUTTY_REGISTRY_KEY_SESSION_PORTFORWARDINGS, "", RegistryValueKind.String);
            puttySessionKey.Close();
        }

        public virtual void MergeBackPuttyTunnels()
        {
            try
            {
                Registry.CurrentUser.DeleteSubKey(this.PuttyTunnelManagerKeyPath);
            }
            catch (Exception) { }

            RegistryKey puttySessionKey = Registry.CurrentUser.OpenSubKey(this.PuttyKeyPath);
            string[] portForwardingList = puttySessionKey.GetValue(PUTTY_REGISTRY_KEY_SESSION_PORTFORWARDINGS, "").ToString().Split(',');
            puttySessionKey.Close();

            List<Tunnel> additionalTunnels = new List<Tunnel>();
            foreach (string portForwarding in portForwardingList)
            {
                if (portForwarding.Length > 0)
                {
                    Tunnel t1 = Tunnel.Load(this, portForwarding);

                    foreach (Tunnel t2 in this.tunnels)
                    {
                        if (!t1.Equals(t2))
                            additionalTunnels.Add(t1);
                    }
                }
            }

            foreach (Tunnel tunnel in additionalTunnels)
                this.tunnels.Add(tunnel);
        }
    }
}

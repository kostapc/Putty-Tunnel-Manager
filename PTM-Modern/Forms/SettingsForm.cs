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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JoeriBekker.PuttyTunnelManager.Forms
{
    public partial class SettingsForm : Form
    {
        private Session selectedSession;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            //Core.Instance().Refresh();  // problem if clear opened sessions on settings form show
            // need to analize and test it
            UpdateSessions();
            UpdateSettings();
        }

        public void UpdateSettings()
        {
            this.plinkLocation.Text = PuttyTunnelManagerSettings.Instance().PlinkLocation; // This calls PlinkLocation_TextChanged
        }

        public void UpdateSessions()
        {
            this.sessions.Items.Clear();

            foreach (Session session in Core.Instance().Sessions)
            {
                ListViewItem sessionViewItem = new ListViewItem(new string[] { session.Name, session.Tunnels.Count.ToString() });
                sessionViewItem.Tag = session;
                this.sessions.Items.Add(sessionViewItem);
            }
        }

        private void SwitchSession(object sender, EventArgs e)
        {
            this.selectedSession = null;

            bool hasSelectedSession = (this.sessions.SelectedItems.Count > 0);

            this.buttonAddLocalPort.Enabled = hasSelectedSession;
            this.buttonDeleteLocalPort.Enabled = hasSelectedSession;
            this.buttonAddRemotePort.Enabled = hasSelectedSession;
            this.buttonDeleteRemotePort.Enabled = hasSelectedSession;
            this.buttonAddDynamicPort.Enabled = hasSelectedSession;
            this.buttonDeleteDynamicPort.Enabled = hasSelectedSession;
            this.buttonDeleteSession.Enabled = hasSelectedSession;

            Session session;

            if (hasSelectedSession)
            {
                session = this.sessions.SelectedItems[0].Tag as Session;

                if (session == null)
                    return;

                this.selectedSession = session;
            }
            else
            {
                session = Core.EmptySession;
            }

            // General
            this.sessionName.Text = session.Name;
            this.storeTunnelsSeparate.Checked = session.UsePtmForTunnels;
            this.autoStartSession.Enabled = this.storeTunnelsSeparate.Checked;
            this.autoStartSession.Checked = session.AutoStart;
            // SSH
            this.hostname.Text = session.Hostname;
            this.port.Text = session.Port.ToString();
            this.username.Text = session.Username;
            this.compression.Checked = session.Compression;
            this.localPortsAcceptAll.Checked = session.LocalPortsAcceptAll;

            // Local, remote and dynamic ports
            this.localPorts.Items.Clear();
            this.remotePorts.Items.Clear();
            this.dynamicPorts.Items.Clear();
            foreach (Tunnel tunnel in session.Tunnels)
            {
                ListViewItem tunnelViewItem = new ListViewItem(new string[] { tunnel.SourcePort.ToString(), tunnel.Destination, tunnel.DestinationPort.ToString() });
                tunnelViewItem.Tag = tunnel;

                switch (tunnel.Type)
                {
                    case TunnelType.LOCAL:
                        this.localPorts.Items.Add(tunnelViewItem);
                        break;
                    case TunnelType.REMOTE:
                        this.remotePorts.Items.Add(tunnelViewItem);
                        break;
                    case TunnelType.DYNAMIC:
                        this.dynamicPorts.Items.Add(tunnelViewItem);
                        break;
                }
            }

        }

        private void buttonDownloadPlink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://the.earth.li/~sgtatham/putty/latest/w64/plink.exe");
        }

        private void buttonBrowseForPlink_Click(object sender, EventArgs e)
        {
            this.openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            if (DialogResult.OK == this.openFileDialog.ShowDialog(this))
            {
                PuttyTunnelManagerSettings.Instance().PlinkLocation = this.openFileDialog.FileName;
            }
            this.UpdateSettings();
        }

        private void PlinkLocation_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(this.plinkLocation.Text))
            {
                PuttyTunnelManagerSettings.Instance().PlinkLocation = this.plinkLocation.Text;

                buttonDownloadPlink.Enabled = false;
                buttonBrowseForPlink.Enabled = false;
                plinkLocation.BackColor = SystemColors.Window;
            }
            else
            {
                buttonDownloadPlink.Enabled = true;
                buttonBrowseForPlink.Enabled = true;
                plinkLocation.BackColor = Color.LightCoral;
            }
        }

        private void AddPortButtonHandler(object sender, EventArgs e)
        {
            ButtonBase button = sender as ButtonBase;
            AddTunnelForm addTunnelForm = new AddTunnelForm((TunnelType)button.Tag);
            if (addTunnelForm.ShowDialog(this) == DialogResult.OK)
            {
                if (this.selectedSession != null)
                {
                    this.selectedSession.Tunnels.Add(new Tunnel(this.selectedSession, addTunnelForm.SourcePort, addTunnelForm.Destination, addTunnelForm.DestinationPort, addTunnelForm.TunnelType));
                    this.selectedSession.Serialize();

                    this.SwitchSession(this, null);
                }
            }
        }

        private void DeletePortButtonHandler(object sender, EventArgs e)
        {
            ButtonBase button = sender as ButtonBase;
            Tunnel tunnel = null;

            switch ((TunnelType)button.Tag)
            {
                case TunnelType.LOCAL:
                    if (this.localPorts.SelectedItems.Count > 0)
                        tunnel = this.localPorts.SelectedItems[0].Tag as Tunnel;
                    break;
                case TunnelType.REMOTE:
                    if (this.remotePorts.SelectedItems.Count > 0)
                        tunnel = this.remotePorts.SelectedItems[0].Tag as Tunnel;
                    break;
                case TunnelType.DYNAMIC:
                    if (this.dynamicPorts.SelectedItems.Count > 0)
                        tunnel = this.dynamicPorts.SelectedItems[0].Tag as Tunnel;
                    break;
            }

            if (this.selectedSession != null)
            {
                this.selectedSession.Tunnels.Remove(tunnel);
                this.selectedSession.Serialize();

                this.SwitchSession(this, null);
            }
        }

        private void buttonAddSession_Click(object sender, EventArgs e)
        {
            AddSessionForm form = new AddSessionForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                new Session(form.SessionName, form.Hostname, form.Port).Serialize();

                Core.Instance().Refresh();
                this.UpdateSessions();
            }
        }

        private void buttonDeleteSession_Click(object sender, EventArgs e)
        {
            if (this.selectedSession != null)
            {
                if (MessageBox.Show(this, "Are you sure you want to delete " + this.selectedSession.Name + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.selectedSession.Delete();
                    this.sessions.SelectedItems.Clear();

                    SwitchSession(this, null);

                    Core.Instance().Refresh();
                    this.UpdateSessions();
                }
            }
        }

        private void storeTunnelsSeparate_Click(object sender, EventArgs e)
        {
            if (this.selectedSession != null)
            {
                if (!this.storeTunnelsSeparate.Checked)
                {
                    DialogResult result = MessageBox.Show("All tunnels in " + this.selectedSession.Name + " will be copied from PuTTY to " + Application.ProductName + ". Do you want to remove these tunnels from PuTTY afterwards?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            this.selectedSession.UsePtmForTunnels = true;
                            this.selectedSession.RemovePuttyTunnels();
                            break;
                        case DialogResult.No:
                            this.selectedSession.UsePtmForTunnels = true;
                            break;
                        case DialogResult.Cancel:
                            return;
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("All tunnels in " + this.selectedSession.Name + " will be removed from " + Application.ProductName + ". Do you want to copy all these tunnels from " + Application.ProductName + " to PuTTY first?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            this.selectedSession.UsePtmForTunnels = false;
                            this.selectedSession.MergeBackPuttyTunnels();
                            break;
                        case DialogResult.No:
                            this.selectedSession.UsePtmForTunnels = false;
                            break;
                        case DialogResult.Cancel:
                            return;
                    }
                }

                this.storeTunnelsSeparate.Checked = this.selectedSession.UsePtmForTunnels;
                //autoStartSession.Enabled = this.storeTunnelsSeparate.Checked;
                this.selectedSession.Serialize();

                this.SwitchSession(this, null);
            }
        }

        private void autoStartSession_Click(object sender, EventArgs e)
        {
            if (selectedSession != null)
            {
                this.selectedSession.AutoStart = this.autoStartSession.Checked;
            }
        }

        private void Field_Leave(object sender, EventArgs e)
        {
            if (this.selectedSession != null)
            {
                if (sender == this.hostname)
                    this.selectedSession.Hostname = this.hostname.Text;
                else if (sender == this.port)
                    this.selectedSession.Port = Int32.Parse(this.port.Text);
                else if (sender == this.username)
                    this.selectedSession.Username = this.username.Text;
                else if (sender == this.compression)
                    this.selectedSession.Compression = this.compression.Checked;
                else if (sender == this.localPortsAcceptAll)
                    this.selectedSession.LocalPortsAcceptAll = this.localPortsAcceptAll.Checked;
                else if (sender == this.sessionName)
                {
                    this.selectedSession.Name = this.sessionName.Text;
                    this.selectedSession.Serialize();

                    Core.Instance().Refresh();
                    this.UpdateSessions();

                    return;
                }

                this.selectedSession.Serialize();
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Field_Leave(this.ActiveControl, null);
        }

        private void storeTunnelsSeparate_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

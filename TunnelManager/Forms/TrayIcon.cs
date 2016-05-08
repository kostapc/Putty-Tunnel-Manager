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

namespace JoeriBekker.PuttyTunnelManager.Forms
{
    public partial class TrayIcon : Form
    {
        private SettingsForm settingsForm;
        private TipForm tipForm;
        private AboutForm aboutForm;

        public TrayIcon()
        {
            InitializeComponent();

            // If plink.exe is not found, show the settings.
            this.settingsForm = new SettingsForm();
            if (!PuttyTunnelManagerSettings.Instance().HasPlink)
            {
                this.notifyIcon.ShowBalloonTip(5, Application.ProductName, "Could not find plink.exe. Please locate it via the settings window.", ToolTipIcon.Info);
                settingsForm.ShowDialog();
            }

            this.tipForm = new TipForm();
            this.aboutForm = new AboutForm();
            MessageForm messageForm = new MessageForm();
            UserNotifications.init(
                messageForm
            );
            UserNotifications.Notify(
                "PTM", "starting..."
            );
            
        }

        public void UpdateSessions()
        {
            this.menuTunnels.Enabled = false;

            if (!PuttyTunnelManagerSettings.Instance().HasPlink)
                return;
            
            this.menuTunnels.DropDownItems.Clear();

            foreach (Session session in Core.Instance().Sessions)
            {
                List<Tunnel> tunnels = session.Tunnels;

                if (tunnels.Count > 0)
                {
                    this.menuTunnels.Enabled = true;

                    ToolStripMenuItem sessionItem = (ToolStripMenuItem)this.menuTunnels.DropDownItems.Add(session.Name);
                    sessionItem.Tag = session;
                    sessionItem.Click += new EventHandler(MenuSession_Click);

                    if (session.IsOpen)
                        sessionItem.Checked = true;
                }
            }
        }

        private void MenuSession_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem sessionItem = sender as ToolStripMenuItem;
            Session session = sessionItem.Tag as Session;

            if (session.IsOpen)
            {
                session.Close();
                sessionItem.Checked = false;
            }
            else
            {
                try
                {
                    session.Open();
                    sessionItem.Checked = true;
                }
                catch (SessionAlreadyOpenException)
                {
                    MessageBox.Show("Session already open.");
                }
                catch (PortAlreadyInUseException ex)
                {
                    MessageBox.Show("Cannot start " + ex.Tunnel.Session.Name + ". Port " + ex.Tunnel.SourcePort + " is already in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (PlinkNotFoundException)
                {
                    MessageBox.Show("Could not find plink.exe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            for (int i = Session.OpenSessions.Count - 1; i > -1; i--)
            {
                Session.OpenSessions[i].Close();
            }

            this.Dispose(true);
            Application.Exit();
        }

        private void MenuSettings_Click(object sender, EventArgs e)
        {
            if (!this.settingsForm.Visible)
                this.settingsForm.ShowDialog();
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!this.tipForm.Visible && Session.OpenSessions.Count > 0)
                {
                    this.tipForm.ShowDialog();
                    this.tipForm.Focus();
                }
            }
        }

        private void Menu_Opening(object sender, CancelEventArgs e)
        {
            this.UpdateSessions();
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            if (!this.aboutForm.Visible)
                this.aboutForm.ShowDialog();
        }
    }
}

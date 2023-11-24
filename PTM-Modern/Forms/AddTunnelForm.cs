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
    public partial class AddTunnelForm : Form
    {
        private TunnelType tunnelType;
        private int sourcePort;
        private int destinationPort;

        public AddTunnelForm(TunnelType tunnelType)
        {
            InitializeComponent();

            this.tunnelType = tunnelType;
            this.sourcePort = -1;
            this.destinationPort = -1;

            switch (tunnelType)
            {
                case TunnelType.LOCAL:
                    this.Text = "Add local port";
                    this.labelSourcePort.Text = "Local port:";
                    this.labelDestination.Text = "Remote host:";
                    this.labelDestinationPort.Text = "Remote port:";
                    break;
                case TunnelType.REMOTE:
                    this.Text = "Add remote port";
                    this.labelSourcePort.Text = "Remote port:";
                    this.labelDestination.Text = "Local host:";
                    this.labelDestinationPort.Text = "Local port:";
                    break;
                case TunnelType.DYNAMIC:
                    this.Text = "Add dynamic port";
                    this.labelSourcePort.Text = "Local port:";

                    this.labelDestination.Hide();
                    this.destinationTextBox.Hide();
                    this.labelDestinationPort.Hide();
                    this.destinationPortTextBox.Hide();
                    break;
            }
        }

        public int SourcePort
        {
            get { return this.sourcePort; }
        }

        public string Destination
        {
            get { return this.destinationTextBox.Text; }
        }

        public int DestinationPort
        {
            get { return this.destinationPort; }
        }

        public TunnelType TunnelType
        {
            get { return this.tunnelType; }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            if (tunnelType != TunnelType.REMOTE)
            {
                foreach (Tunnel tunnel in Core.Instance().Tunnels)
                {
                    if (tunnel.SourcePort == this.sourcePort)
                    {
                        if (DialogResult.No == MessageBox.Show(this, "Local port " + this.sourcePort + " is already used by " + tunnel.Session.Name + ". Are you sure you want to use this port?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            return;
                        }
                        else
                        {
                            break; // Just ask once.
                        }
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void sourcePortTextBox_Validating(object sender, CancelEventArgs e)
        {
            int port = FormUtils.ValidatePortTextBox(sender, e);

            if (!e.Cancel)
                this.sourcePort = port;
        }

        private void destinationPortTextBox_Validating(object sender, CancelEventArgs e)
        {
            int port = FormUtils.ValidatePortTextBox(sender, e);

            if (!e.Cancel)
                this.destinationPort = port;
        }
    }
}

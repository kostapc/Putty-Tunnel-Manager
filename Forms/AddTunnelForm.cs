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

        public AddTunnelForm(TunnelType tunnelType)
        {
            InitializeComponent();

            this.tunnelType = tunnelType;

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
                    this.destination.Hide();
                    this.labelDestinationPort.Hide();
                    this.destinationPort.Hide();
                    break;
            }
        }

        public int SourcePort
        {
            get { return Int32.Parse(this.sourcePort.Text); }
        }

        public string Destination
        {
            get { return this.destination.Text; }
        }

        public int DestinationPort
        {
            get
            {
                int port = 0;
                try
                {
                    port = Int32.Parse(this.destinationPort.Text);
                }
                catch (Exception)
                {
                    // Intentionally empty.
                }
                return port;
            }
        }

        public TunnelType TunnelType
        {
            get { return this.tunnelType; }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}

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
using System.Drawing;
using System.Windows.Forms;

namespace JoeriBekker.PuttyTunnelManager.Forms
{
    public partial class TipForm : InfoForm
    {

        private static readonly Font f = new Font("Courier New", 9);

        public TipForm()
        {
            InitializeComponent();

            UpdateLocation();
        }

        private void TipForm_Shown(object sender, EventArgs e)
        {
            this.UpdateSessions();
        }

        private void TipForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        // possible null pointer exception after resuming from hibernation
        private void ReinitInstance()
        {
            if (Session.OpenSessions == null)
            {                
                Core.Instance().Refresh();
            }

            foreach (Session session in Session.OpenSessions)
            {
                if (session.Tunnels == null)
                {
                    Core.Instance().Refresh();
                    break;
                }
            }
        }

        private void UpdateSessions()
        {
            this.SuspendLayout();
            this.Controls.Clear();            

            int y = 0;
            int maxWidth = 0;

            ReinitInstance();

            foreach (Session session in Session.OpenSessions)
            {
                y += 12;

                Label sessionLabel = new Label
                {
                    AutoSize = true,
                    Location = new Point(12, y),
                    Font = SystemFonts.StatusFont,
                    Text = session.Name
                };

                this.Controls.Add(sessionLabel);
                if (maxWidth < sessionLabel.Width + 12)
                {
                    maxWidth = sessionLabel.Width + 12;
                }

                y += 18;

                foreach (Tunnel tunnel in session.Tunnels)
                {
                    int x = 12;

                    Label sourcePortLabel = new Label
                    {
                        AutoSize = true,
                        Location = new Point(x, y),
                        ForeColor = SystemColors.ControlDarkDark,
                        Font = SystemFonts.StatusFont,
                        Text = tunnel.SourcePort.ToString()
                    };

                    this.Controls.Add(sourcePortLabel);
                    x += sourcePortLabel.Width + 2;

                    Label connectionLabel = new Label
                    {
                        AutoSize = true,
                        Location = new Point(x, y),
                        ForeColor = Color.ForestGreen,
                        Font = f,
                        Text = "=="
                    };

                    this.Controls.Add(connectionLabel);
                    x += connectionLabel.Width + 3;

                    Label tunnelLabel = new Label
                    {
                        Location = new Point(x, y),
                        ForeColor = SystemColors.ControlDarkDark,
                        Font = SystemFonts.StatusFont,
                        Text = tunnel.Destination + ":" + tunnel.DestinationPort.ToString(),
                        AutoSize = true
                    };

                    this.Controls.Add(tunnelLabel);

                    if (maxWidth < tunnelLabel.Width + x)
                        maxWidth = tunnelLabel.Width + x;

                    y += 16;
                }
            }

            this.Size = new Size(maxWidth + 12, y + 12);

            UpdateLocation();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

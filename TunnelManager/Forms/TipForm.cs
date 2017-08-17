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
        public TipForm()
        {
            InitializeComponent();

            updateLocation();
            /*
            this.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Right - this.Width,
                Screen.PrimaryScreen.WorkingArea.Bottom - this.Height);
            */
        }

        private void TipForm_Shown(object sender, EventArgs e)
        {
            this.UpdateSessions();
        }

        private void TipForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateSessions()
        {
            this.SuspendLayout();
            this.Controls.Clear();

            Font f = new Font("Courier New", 9);

            int y = 0;
            int maxWidth = 0;

            if(Session.OpenSessions==null)
            {
                Core.Instance().Refresh();
            }

            foreach (Session session in Session.OpenSessions)
            {
                y += 12;

                Label sessionLabel = new Label();
                sessionLabel.AutoSize = true;
                sessionLabel.Location = new Point(12, y);
                sessionLabel.Font = SystemFonts.StatusFont;
                sessionLabel.Text = session.Name;

                this.Controls.Add(sessionLabel);
                if (maxWidth < sessionLabel.Width + 12)
                    maxWidth = sessionLabel.Width + 12;

                y += 18;

                foreach (Tunnel tunnel in session.Tunnels)
                {
                    int x = 12;

                    Label sourcePortLabel = new Label();
                    sourcePortLabel.AutoSize = true;
                    sourcePortLabel.Location = new Point(x, y);
                    sourcePortLabel.ForeColor = SystemColors.ControlDarkDark;
                    sourcePortLabel.Font = SystemFonts.StatusFont;
                    sourcePortLabel.Text = tunnel.SourcePort.ToString();

                    this.Controls.Add(sourcePortLabel);
                    x += sourcePortLabel.Width + 2;

                    Label connectionLabel = new Label();
                    connectionLabel.AutoSize = true;
                    connectionLabel.Location = new Point(x, y);
                    connectionLabel.ForeColor = Color.ForestGreen;
                    connectionLabel.Font = f;
                    connectionLabel.Text = "==";

                    this.Controls.Add(connectionLabel);
                    x += connectionLabel.Width + 3;

                    Label tunnelLabel = new Label();
                    tunnelLabel.Location = new Point(x, y);
                    tunnelLabel.ForeColor = SystemColors.ControlDarkDark;
                    tunnelLabel.Font = SystemFonts.StatusFont;
                    tunnelLabel.Text = tunnel.Destination + ":" + tunnel.DestinationPort.ToString();
                    tunnelLabel.AutoSize = true;

                    this.Controls.Add(tunnelLabel);

                    if (maxWidth < tunnelLabel.Width + x)
                        maxWidth = tunnelLabel.Width + x;

                    y += 16;
                }
            }

            this.Size = new Size(maxWidth + 12, y + 12);

            updateLocation();
            /*
            this.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Right - this.Width,
                Screen.PrimaryScreen.WorkingArea.Bottom - this.Height);
            */
                

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

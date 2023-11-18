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
    public partial class AddSessionForm : Form
    {
        private int port;

        public AddSessionForm()
        {
            InitializeComponent();

            this.port = -1;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            foreach (Session session in Core.Instance().Sessions)
            {
                if (session.Name.Equals(this.SessionName))
                {
                    MessageBox.Show(this, "A session with this name already exists. Please choose another name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.sessionNameTexBox.Focus();

                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public string SessionName
        {
            get { return this.sessionNameTexBox.Text; }
        }

        public string Hostname
        {
            get { return this.hostnameTextBox.Text; }
        }

        public int Port
        {
            get { return port; }
        }

        private void portTextBox_Validating(object sender, CancelEventArgs e)
        {
            int port = FormUtils.ValidatePortTextBox(sender, e);

            if (!e.Cancel)
                this.port = port;
        }
    }
}

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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            this.about.Font = SystemFonts.MessageBoxFont;
            this.about.Text = Application.ProductName + " " 
                + Application.ProductVersion 
                + "\nCopyright © 2009, Joeri Bekker;" 
                + " 2020 KostaPC;"
                + "\nAll rights reserved.";
            this.Text = "About " + Application.ProductName;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonWebsite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/kostapc/Putty-Tunnel-Manager");
        }

    }
}

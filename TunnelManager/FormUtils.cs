using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace JoeriBekker.PuttyTunnelManager
{
    class FormUtils
    {
        internal static int ValidatePortTextBox(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            int result = -1;
            if (textBox == null || !textBox.Visible)
                return result;

            try
            {
                result = Int32.Parse(textBox.Text);
                if (result <= 0)
                    throw new FormatException("Value must be positive.");
                if (result >= 65536)
                    throw new FormatException("Value must be smaller than 65536.");

                textBox.BackColor = SystemColors.Window;
            }
            catch (FormatException)
            {
                textBox.BackColor = Color.LightCoral;
                textBox.Focus();

                e.Cancel = true;
            }

            return result;
        }
    }

    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            updateLocation();
        }

        public void updateLocation()
        {
            this.Location = calculateLocation();
        }

        private Point calculateLocation()
        {
            return new Point(
                Screen.PrimaryScreen.WorkingArea.Right - this.Width,
                Screen.PrimaryScreen.WorkingArea.Bottom - this.Height);
        }
        
    }
}

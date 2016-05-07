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
            TaskBarInfo taskBarInfo = new TaskBarInfo();
            Point theStartPoint = taskBarInfo.GetStartPoint(this.DisplayRectangle);
            return theStartPoint;
            /*
            return new Point(
                Screen.PrimaryScreen.WorkingArea.Right - this.Width,
                Screen.PrimaryScreen.WorkingArea.Bottom - this.Height);
            */
        }
        
    }

    public class TaskBarInfo
    {
        // http://stackoverflow.com/questions/3677182/taskbar-location

        public enum Location
        {
            Left,
            Right,
            Top,
            Bottom
        }

        public Location position { get; protected set; }
        public Rectangle rectangle { get; protected set; }

        public TaskBarInfo()
        {
            rectangle = GetTaskbarPosition();
            CalculatePosition();
        }

        public Point GetStartPoint(Rectangle rect)
        {
            Point point = new Point();
            int width = rect.Width;
            int height = rect.Height;
            switch(position)
            {
                case Location.Left:
                    point.X = rectangle.Width + 1;
                    point.Y = rectangle.Height - rect.Height - 1;
                    break;
                case Location.Bottom:
                    point.X = rectangle.Width - rect.Width - 1;
                    point.Y = rectangle.Y - rect.Height - 1;
                    break;
                case Location.Top:
                    point.X = rectangle.Width - rect.Width - 1;
                    point.Y = rectangle.Height + 1;
                    break;
                case Location.Right:
                    point.X = rectangle.X - rect.Width - 1;
                    point.Y = rectangle.Height - rect.Height - 1;
                    break;
            }

            return point;
        }

        private void CalculatePosition()
        {
            if (rectangle.X == rectangle.Y)
            {
                if (rectangle.Right < rectangle.Bottom)
                    position = Location.Left;
                if (rectangle.Right > rectangle.Bottom)
                    position = Location.Top;
            }
            if (rectangle.X > rectangle.Y)
                position = Location.Right;
            if (rectangle.X < rectangle.Y)
                position = Location.Bottom;
        }

        private static Rectangle GetTaskbarPosition()
        {
            var data = new APPBARDATA();
            data.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(data);
            IntPtr retval = SHAppBarMessage(ABM_GETTASKBARPOS, ref data);
            if (retval == IntPtr.Zero) throw new Win32Exception("Please re-install Windows");
            return new Rectangle(data.rc.left, data.rc.top,
                data.rc.right - data.rc.left, data.rc.bottom - data.rc.top);

        }

        // P/Invoke goo:
        private const int ABM_GETTASKBARPOS = 5;

        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        private static extern IntPtr SHAppBarMessage(int msg, ref APPBARDATA data);
        private struct APPBARDATA
        {
            public int cbSize;
            public IntPtr hWnd;
            public int uCallbackMessage;
            public int uEdge;
            public RECT rc;
            public IntPtr lParam;
        }
        private struct RECT
        {
            public int left, top, right, bottom;
        }
    }
}

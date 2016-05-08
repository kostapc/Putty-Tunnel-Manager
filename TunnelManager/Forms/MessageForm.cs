using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JoeriBekker.PuttyTunnelManager.Forms
{
    public partial class MessageForm : InfoForm, UserNotificator
    {

        private Thread hideWithPause = null;

        public MessageForm()
        {        
            InitializeComponent();
            updateLocation();
        }

        public void Notify(String title, String message)
        {
            SetStatus(title, message);
            
            if (hideWithPause == null)
            {
                
                hideWithPause = new Thread(() =>
                {
                    Thread.Sleep(500);
                    Hide();
                    hideWithPause = null;
                });
                hideWithPause.IsBackground = true;
                hideWithPause.Priority = ThreadPriority.Lowest;
                hideWithPause.Start();
                Show();
            }
        }

        delegate void SetTextCallback(String title, String text);
        delegate void FormHideCallback();
        delegate DialogResult FormShowCallback();

        
        public new void Hide()
        {
            SafeHide();
        }

        public new void Show()
        {
            SafeShow();
        }

        private void SafeShow()
        {
            if (this.InvokeRequired)
            {
                FormShowCallback d = new FormShowCallback(base.ShowDialog);
                this.Invoke(d);
            }
            else
            {
                base.ShowDialog();
            }
        }

        private void SafeHide()
        {
            if (this.InvokeRequired)
            {
                FormHideCallback d = new FormHideCallback(base.Close);
                this.Invoke(d);
            }
            else
            {
                base.Close();
            }
        }

        public void SetStatus(String title, String status)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.labelStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatus);
                this.Invoke(d, new object[] { title, status });
            }
            else
            {
                this.labelSession.Text = title;
                this.labelStatus.Text = status;
            }
        }

    }
}

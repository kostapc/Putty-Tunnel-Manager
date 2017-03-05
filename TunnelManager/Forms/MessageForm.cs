using System;
using System.Threading;
using System.Windows.Forms;

namespace JoeriBekker.PuttyTunnelManager.Forms
{
    public partial class MessageForm : InfoForm, UserNotificator
    {

        private Thread hideWithPause = null;
        private Thread formThread = null;

        public MessageForm()
        {        
            InitializeComponent();
            updateLocation();
            formThread = new Thread(formThreadRun);
            formThread.Start();
        }

        private void formThreadRun()
        {
            Application.Run(this);
        }

        public void Notify(String title, String message)
        {
            SetStatus(title, message);
            Show();
            SingleRunTimer hideTimer = new SingleRunTimer(() =>
            {
                Hide();
                hideWithPause = null;
            });
            hideTimer.StartTimer(1500);
        }

        // InvokeRequired required compares the thread ID of the
        // calling thread to the thread ID of the creating thread.
        // If these threads are different, it returns true.
        delegate void SetTextCallback(String title, String text);
        delegate void FormHideCallback();
        delegate void FormShowCallback();

        
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
                FormShowCallback d = new FormShowCallback(base.Show);
                this.Invoke(d);
            }
            else
            {
                base.Show();
            }
        }

        private void SafeHide()
        {
            if (this.InvokeRequired)
            {
                FormHideCallback d = new FormHideCallback(base.Hide);
                this.Invoke(d);
            }
            else
            {
                base.Hide();
            }
        }

        public void SetStatus(String title, String status)
        {
            if (this.labelStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatus);
                this.Invoke(d, new object[] { title, status });
            }
            else
            {
                this.labelSession.Text = title;
                this.labelStatus.Text = status;
                int w = labelSession.Width;
                if(w<labelStatus.Width)
                {
                    w = labelStatus.Width+25;
                }
                this.Width = w;
                updateLocation();
            }
        }

        public void stop()
        {
            Application.Exit();
        }

    }
}

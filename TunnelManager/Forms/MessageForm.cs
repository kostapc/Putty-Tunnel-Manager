using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JoeriBekker.PuttyTunnelManager.Forms
{
    public partial class MessageForm : InfoForm
    {
        private string sessionName;

        public MessageForm(string sessionName)
        {
            this.sessionName = sessionName;            
            InitializeComponent();
            this.labelSession.Text = sessionName;
        }

        delegate void SetTextCallback(string text);
        delegate void FormHideCallback();

        public new void Hide()
        {
            if (this.InvokeRequired)
            {
                FormHideCallback d = new FormHideCallback(Hide);
                this.Invoke(d);
            }
            else
            {
                base.Hide();
            }
        }

        public void SetStatus(string status)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.labelStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatus);
                this.Invoke(d, new object[] { status });
            }
            else
            {
                this.labelStatus.Text = status;
            }
        }

    }
}

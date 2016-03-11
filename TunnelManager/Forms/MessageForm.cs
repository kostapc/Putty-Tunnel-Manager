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
        
        public void SetStatus(string status)
        {
            this.labelStatus.Text = status;
        }

    }
}

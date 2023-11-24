namespace JoeriBekker.PuttyTunnelManager.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sessions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.sessionDetails = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.storeTunnelsSeparate = new System.Windows.Forms.CheckBox();
            this.autoStartSession = new System.Windows.Forms.CheckBox();
            this.sessionName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.localPortsAcceptAll = new System.Windows.Forms.CheckBox();
            this.compression = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.hostname = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.localPorts = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.remotePorts = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dynamicPorts = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDeleteSession = new System.Windows.Forms.Button();
            this.buttonAddSession = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDownloadPlink = new System.Windows.Forms.Button();
            this.buttonBrowseForPlink = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.plinkLocation = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonAddLocalPort = new System.Windows.Forms.Button();
            this.buttonDeleteLocalPort = new System.Windows.Forms.Button();
            this.buttonAddRemotePort = new System.Windows.Forms.Button();
            this.buttonDeleteRemotePort = new System.Windows.Forms.Button();
            this.buttonAddDynamicPort = new System.Windows.Forms.Button();
            this.buttonDeleteDynamicPort = new System.Windows.Forms.Button();
            this.sessionDetails.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sessions
            // 
            this.sessions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader11});
            this.sessions.FullRowSelect = true;
            this.sessions.HideSelection = false;
            this.sessions.Location = new System.Drawing.Point(6, 19);
            this.sessions.MultiSelect = false;
            this.sessions.Name = "sessions";
            this.sessions.Size = new System.Drawing.Size(387, 118);
            this.sessions.TabIndex = 0;
            this.sessions.UseCompatibleStateImageBehavior = false;
            this.sessions.View = System.Windows.Forms.View.Details;
            this.sessions.SelectedIndexChanged += new System.EventHandler(this.SwitchSession);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Session";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Tunnels";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Click on a session to display the details";
            // 
            // sessionDetails
            // 
            this.sessionDetails.Controls.Add(this.tabPage1);
            this.sessionDetails.Controls.Add(this.tabPage2);
            this.sessionDetails.Controls.Add(this.tabPage3);
            this.sessionDetails.Controls.Add(this.tabPage4);
            this.sessionDetails.Controls.Add(this.tabPage5);
            this.sessionDetails.Location = new System.Drawing.Point(6, 183);
            this.sessionDetails.Name = "sessionDetails";
            this.sessionDetails.SelectedIndex = 0;
            this.sessionDetails.Size = new System.Drawing.Size(388, 196);
            this.sessionDetails.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.storeTunnelsSeparate);
            this.tabPage1.Controls.Add(this.autoStartSession);
            this.tabPage1.Controls.Add(this.sessionName);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(380, 170);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // storeTunnelsSeparate
            // 
            this.storeTunnelsSeparate.AutoCheck = false;
            this.storeTunnelsSeparate.AutoSize = true;
            this.storeTunnelsSeparate.Location = new System.Drawing.Point(9, 39);
            this.storeTunnelsSeparate.Name = "storeTunnelsSeparate";
            this.storeTunnelsSeparate.Size = new System.Drawing.Size(238, 17);
            this.storeTunnelsSeparate.TabIndex = 1;
            this.storeTunnelsSeparate.Text = "Use PuTTY Tunnel Manager to store tunnels";
            this.storeTunnelsSeparate.UseVisualStyleBackColor = true;
            this.storeTunnelsSeparate.CheckedChanged += new System.EventHandler(this.storeTunnelsSeparate_CheckedChanged);
            this.storeTunnelsSeparate.Click += new System.EventHandler(this.storeTunnelsSeparate_Click);
            // 
            // autoStartSession
            // 
            this.autoStartSession.AutoSize = true;
            this.autoStartSession.Location = new System.Drawing.Point(9, 63);
            this.autoStartSession.Name = "autoStartSession";
            this.autoStartSession.Size = new System.Drawing.Size(178, 17);
            this.autoStartSession.TabIndex = 1;
            this.autoStartSession.Text = "Auto connect session on startup";
            this.autoStartSession.UseVisualStyleBackColor = true;
            this.autoStartSession.Click += new System.EventHandler(this.autoStartSession_Click);
            // 
            // sessionName
            // 
            this.sessionName.Location = new System.Drawing.Point(110, 9);
            this.sessionName.Name = "sessionName";
            this.sessionName.Size = new System.Drawing.Size(264, 20);
            this.sessionName.TabIndex = 0;
            this.sessionName.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Session name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.localPortsAcceptAll);
            this.tabPage2.Controls.Add(this.compression);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.port);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.hostname);
            this.tabPage2.Controls.Add(this.username);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(380, 170);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SSH";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // localPortsAcceptAll
            // 
            this.localPortsAcceptAll.AutoSize = true;
            this.localPortsAcceptAll.Location = new System.Drawing.Point(9, 141);
            this.localPortsAcceptAll.Name = "localPortsAcceptAll";
            this.localPortsAcceptAll.Size = new System.Drawing.Size(253, 17);
            this.localPortsAcceptAll.TabIndex = 4;
            this.localPortsAcceptAll.Text = "Local ports accept connections from other hosts";
            this.localPortsAcceptAll.UseVisualStyleBackColor = true;
            this.localPortsAcceptAll.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // compression
            // 
            this.compression.AutoSize = true;
            this.compression.Location = new System.Drawing.Point(9, 117);
            this.compression.Name = "compression";
            this.compression.Size = new System.Drawing.Size(121, 17);
            this.compression.TabIndex = 3;
            this.compression.Text = "Enable compression";
            this.compression.UseVisualStyleBackColor = true;
            this.compression.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Port:";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(79, 36);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(56, 20);
            this.port.TabIndex = 1;
            this.port.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Hostname:";
            // 
            // hostname
            // 
            this.hostname.Location = new System.Drawing.Point(79, 9);
            this.hostname.Name = "hostname";
            this.hostname.Size = new System.Drawing.Size(294, 20);
            this.hostname.TabIndex = 0;
            this.hostname.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(79, 62);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(136, 20);
            this.username.TabIndex = 2;
            this.username.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonAddLocalPort);
            this.tabPage3.Controls.Add(this.buttonDeleteLocalPort);
            this.tabPage3.Controls.Add(this.localPorts);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(380, 170);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Local ports";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // localPorts
            // 
            this.localPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localPorts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.localPorts.FullRowSelect = true;
            this.localPorts.Location = new System.Drawing.Point(6, 6);
            this.localPorts.Name = "localPorts";
            this.localPorts.Size = new System.Drawing.Size(368, 126);
            this.localPorts.TabIndex = 0;
            this.localPorts.UseCompatibleStateImageBehavior = false;
            this.localPorts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Local port";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Remote host";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Remote port";
            this.columnHeader4.Width = 70;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.buttonAddRemotePort);
            this.tabPage4.Controls.Add(this.buttonDeleteRemotePort);
            this.tabPage4.Controls.Add(this.remotePorts);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(380, 170);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Remote ports";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // remotePorts
            // 
            this.remotePorts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remotePorts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.remotePorts.FullRowSelect = true;
            this.remotePorts.Location = new System.Drawing.Point(6, 6);
            this.remotePorts.Name = "remotePorts";
            this.remotePorts.Size = new System.Drawing.Size(368, 126);
            this.remotePorts.TabIndex = 0;
            this.remotePorts.UseCompatibleStateImageBehavior = false;
            this.remotePorts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Remote port";
            this.columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Local host";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Local port";
            this.columnHeader7.Width = 70;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.buttonAddDynamicPort);
            this.tabPage5.Controls.Add(this.buttonDeleteDynamicPort);
            this.tabPage5.Controls.Add(this.dynamicPorts);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(380, 170);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Dynamic ports";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dynamicPorts
            // 
            this.dynamicPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dynamicPorts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8});
            this.dynamicPorts.FullRowSelect = true;
            this.dynamicPorts.Location = new System.Drawing.Point(6, 6);
            this.dynamicPorts.Name = "dynamicPorts";
            this.dynamicPorts.Size = new System.Drawing.Size(368, 126);
            this.dynamicPorts.TabIndex = 0;
            this.dynamicPorts.UseCompatibleStateImageBehavior = false;
            this.dynamicPorts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Local port";
            this.columnHeader8.Width = 340;
            // 
            // buttonDeleteSession
            // 
            this.buttonDeleteSession.Enabled = false;
            this.buttonDeleteSession.Location = new System.Drawing.Point(318, 143);
            this.buttonDeleteSession.Name = "buttonDeleteSession";
            this.buttonDeleteSession.Size = new System.Drawing.Size(75, 26);
            this.buttonDeleteSession.TabIndex = 2;
            this.buttonDeleteSession.Text = "Delete";
            this.buttonDeleteSession.UseVisualStyleBackColor = true;
            this.buttonDeleteSession.Click += new System.EventHandler(this.buttonDeleteSession_Click);
            // 
            // buttonAddSession
            // 
            this.buttonAddSession.Location = new System.Drawing.Point(237, 143);
            this.buttonAddSession.Name = "buttonAddSession";
            this.buttonAddSession.Size = new System.Drawing.Size(75, 26);
            this.buttonAddSession.TabIndex = 1;
            this.buttonAddSession.Text = "Add";
            this.buttonAddSession.UseVisualStyleBackColor = true;
            this.buttonAddSession.Click += new System.EventHandler(this.buttonAddSession_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDownloadPlink);
            this.groupBox1.Controls.Add(this.buttonBrowseForPlink);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.plinkLocation);
            this.groupBox1.Location = new System.Drawing.Point(12, 403);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PuTTY";
            // 
            // buttonDownloadPlink
            // 
            this.buttonDownloadPlink.Location = new System.Drawing.Point(236, 46);
            this.buttonDownloadPlink.Name = "buttonDownloadPlink";
            this.buttonDownloadPlink.Size = new System.Drawing.Size(75, 26);
            this.buttonDownloadPlink.TabIndex = 1;
            this.buttonDownloadPlink.Text = "Download";
            this.buttonDownloadPlink.UseVisualStyleBackColor = true;
            this.buttonDownloadPlink.Click += new System.EventHandler(this.buttonDownloadPlink_Click);
            // 
            // buttonBrowseForPlink
            // 
            this.buttonBrowseForPlink.Location = new System.Drawing.Point(317, 46);
            this.buttonBrowseForPlink.Name = "buttonBrowseForPlink";
            this.buttonBrowseForPlink.Size = new System.Drawing.Size(75, 26);
            this.buttonBrowseForPlink.TabIndex = 2;
            this.buttonBrowseForPlink.Text = "Browse...";
            this.buttonBrowseForPlink.UseVisualStyleBackColor = true;
            this.buttonBrowseForPlink.Click += new System.EventHandler(this.buttonBrowseForPlink_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Location of plink.exe:";
            // 
            // plinkLocation
            // 
            this.plinkLocation.Location = new System.Drawing.Point(133, 19);
            this.plinkLocation.Name = "plinkLocation";
            this.plinkLocation.Size = new System.Drawing.Size(260, 20);
            this.plinkLocation.TabIndex = 0;
            this.plinkLocation.TextChanged += new System.EventHandler(this.PlinkLocation_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sessions);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonAddSession);
            this.groupBox2.Controls.Add(this.sessionDetails);
            this.groupBox2.Controls.Add(this.buttonDeleteSession);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 385);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tunnels";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "plink.exe";
            this.openFileDialog.Filter = "PuTTY link|plink.exe";
            this.openFileDialog.Title = "Location of plink.exe";
            // 
            // buttonAddLocalPort
            // 
            this.buttonAddLocalPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddLocalPort.Enabled = false;
            this.buttonAddLocalPort.Location = new System.Drawing.Point(218, 138);
            this.buttonAddLocalPort.Name = "buttonAddLocalPort";
            this.buttonAddLocalPort.Size = new System.Drawing.Size(75, 26);
            this.buttonAddLocalPort.TabIndex = 1;
            this.buttonAddLocalPort.Tag = JoeriBekker.PuttyTunnelManager.TunnelType.LOCAL;
            this.buttonAddLocalPort.Text = "Add";
            this.buttonAddLocalPort.UseVisualStyleBackColor = true;
            this.buttonAddLocalPort.Click += new System.EventHandler(this.AddPortButtonHandler);
            // 
            // buttonDeleteLocalPort
            // 
            this.buttonDeleteLocalPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteLocalPort.Enabled = false;
            this.buttonDeleteLocalPort.Location = new System.Drawing.Point(299, 138);
            this.buttonDeleteLocalPort.Name = "buttonDeleteLocalPort";
            this.buttonDeleteLocalPort.Size = new System.Drawing.Size(75, 26);
            this.buttonDeleteLocalPort.TabIndex = 2;
            this.buttonDeleteLocalPort.Tag = JoeriBekker.PuttyTunnelManager.TunnelType.LOCAL;
            this.buttonDeleteLocalPort.Text = "Delete";
            this.buttonDeleteLocalPort.UseVisualStyleBackColor = true;
            this.buttonDeleteLocalPort.Click += new System.EventHandler(this.DeletePortButtonHandler);
            // 
            // buttonAddRemotePort
            // 
            this.buttonAddRemotePort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddRemotePort.Enabled = false;
            this.buttonAddRemotePort.Location = new System.Drawing.Point(218, 138);
            this.buttonAddRemotePort.Name = "buttonAddRemotePort";
            this.buttonAddRemotePort.Size = new System.Drawing.Size(75, 26);
            this.buttonAddRemotePort.TabIndex = 1;
            this.buttonAddRemotePort.Tag = JoeriBekker.PuttyTunnelManager.TunnelType.REMOTE;
            this.buttonAddRemotePort.Text = "Add";
            this.buttonAddRemotePort.UseVisualStyleBackColor = true;
            this.buttonAddRemotePort.Click += new System.EventHandler(this.AddPortButtonHandler);
            // 
            // buttonDeleteRemotePort
            // 
            this.buttonDeleteRemotePort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteRemotePort.Enabled = false;
            this.buttonDeleteRemotePort.Location = new System.Drawing.Point(299, 138);
            this.buttonDeleteRemotePort.Name = "buttonDeleteRemotePort";
            this.buttonDeleteRemotePort.Size = new System.Drawing.Size(75, 26);
            this.buttonDeleteRemotePort.TabIndex = 2;
            this.buttonDeleteRemotePort.Tag = JoeriBekker.PuttyTunnelManager.TunnelType.REMOTE;
            this.buttonDeleteRemotePort.Text = "Delete";
            this.buttonDeleteRemotePort.UseVisualStyleBackColor = true;
            this.buttonDeleteRemotePort.Click += new System.EventHandler(this.DeletePortButtonHandler);
            // 
            // buttonAddDynamicPort
            // 
            this.buttonAddDynamicPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddDynamicPort.Enabled = false;
            this.buttonAddDynamicPort.Location = new System.Drawing.Point(218, 138);
            this.buttonAddDynamicPort.Name = "buttonAddDynamicPort";
            this.buttonAddDynamicPort.Size = new System.Drawing.Size(75, 26);
            this.buttonAddDynamicPort.TabIndex = 1;
            this.buttonAddDynamicPort.Tag = JoeriBekker.PuttyTunnelManager.TunnelType.DYNAMIC;
            this.buttonAddDynamicPort.Text = "Add";
            this.buttonAddDynamicPort.UseVisualStyleBackColor = true;
            this.buttonAddDynamicPort.Click += new System.EventHandler(this.AddPortButtonHandler);
            // 
            // buttonDeleteDynamicPort
            // 
            this.buttonDeleteDynamicPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteDynamicPort.Enabled = false;
            this.buttonDeleteDynamicPort.Location = new System.Drawing.Point(299, 138);
            this.buttonDeleteDynamicPort.Name = "buttonDeleteDynamicPort";
            this.buttonDeleteDynamicPort.Size = new System.Drawing.Size(75, 26);
            this.buttonDeleteDynamicPort.TabIndex = 2;
            this.buttonDeleteDynamicPort.Tag = JoeriBekker.PuttyTunnelManager.TunnelType.DYNAMIC;
            this.buttonDeleteDynamicPort.Text = "Delete";
            this.buttonDeleteDynamicPort.UseVisualStyleBackColor = true;
            this.buttonDeleteDynamicPort.Click += new System.EventHandler(this.DeletePortButtonHandler);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 496);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.sessionDetails.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView sessions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl sessionDetails;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonDeleteSession;
        private System.Windows.Forms.Button buttonAddSession;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button buttonAddLocalPort;
        private System.Windows.Forms.Button buttonDeleteLocalPort;
        private System.Windows.Forms.ListView localPorts;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonDownloadPlink;
        private System.Windows.Forms.Button buttonBrowseForPlink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox plinkLocation;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox hostname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.TextBox sessionName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox localPortsAcceptAll;
        private System.Windows.Forms.CheckBox compression;
        private System.Windows.Forms.CheckBox storeTunnelsSeparate;
        private System.Windows.Forms.CheckBox autoStartSession;
        private System.Windows.Forms.Button buttonAddRemotePort;
        private System.Windows.Forms.Button buttonDeleteRemotePort;
        private System.Windows.Forms.ListView remotePorts;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button buttonAddDynamicPort;
        private System.Windows.Forms.Button buttonDeleteDynamicPort;
        private System.Windows.Forms.ListView dynamicPorts;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader11;
    }
}


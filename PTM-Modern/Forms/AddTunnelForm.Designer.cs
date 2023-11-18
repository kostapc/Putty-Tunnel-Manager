namespace JoeriBekker.PuttyTunnelManager.Forms
{
    partial class AddTunnelForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelDestinationPort = new System.Windows.Forms.Label();
            this.destinationPortTextBox = new System.Windows.Forms.TextBox();
            this.labelDestination = new System.Windows.Forms.Label();
            this.destinationTextBox = new System.Windows.Forms.TextBox();
            this.sourcePortTextBox = new System.Windows.Forms.TextBox();
            this.labelSourcePort = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelDestinationPort);
            this.groupBox1.Controls.Add(this.destinationPortTextBox);
            this.groupBox1.Controls.Add(this.labelDestination);
            this.groupBox1.Controls.Add(this.destinationTextBox);
            this.groupBox1.Controls.Add(this.sourcePortTextBox);
            this.groupBox1.Controls.Add(this.labelSourcePort);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // labelDestinationPort
            // 
            this.labelDestinationPort.AutoSize = true;
            this.labelDestinationPort.Location = new System.Drawing.Point(6, 68);
            this.labelDestinationPort.Name = "labelDestinationPort";
            this.labelDestinationPort.Size = new System.Drawing.Size(68, 13);
            this.labelDestinationPort.TabIndex = 5;
            this.labelDestinationPort.Text = "Remote port:";
            // 
            // destinationPortTextBox
            // 
            this.destinationPortTextBox.Location = new System.Drawing.Point(82, 65);
            this.destinationPortTextBox.Name = "destinationPortTextBox";
            this.destinationPortTextBox.Size = new System.Drawing.Size(56, 20);
            this.destinationPortTextBox.TabIndex = 2;
            this.destinationPortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.destinationPortTextBox_Validating);
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(6, 42);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(70, 13);
            this.labelDestination.TabIndex = 3;
            this.labelDestination.Text = "Remote host:";
            // 
            // destinationTextBox
            // 
            this.destinationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.destinationTextBox.Location = new System.Drawing.Point(82, 39);
            this.destinationTextBox.Name = "destinationTextBox";
            this.destinationTextBox.Size = new System.Drawing.Size(349, 20);
            this.destinationTextBox.TabIndex = 1;
            // 
            // sourcePortTextBox
            // 
            this.sourcePortTextBox.Location = new System.Drawing.Point(82, 13);
            this.sourcePortTextBox.Name = "sourcePortTextBox";
            this.sourcePortTextBox.Size = new System.Drawing.Size(56, 20);
            this.sourcePortTextBox.TabIndex = 0;
            this.sourcePortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.sourcePortTextBox_Validating);
            // 
            // labelSourcePort
            // 
            this.labelSourcePort.AutoSize = true;
            this.labelSourcePort.Location = new System.Drawing.Point(6, 16);
            this.labelSourcePort.Name = "labelSourcePort";
            this.labelSourcePort.Size = new System.Drawing.Size(57, 13);
            this.labelSourcePort.TabIndex = 0;
            this.labelSourcePort.Text = "Local port:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(374, 110);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 26);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(293, 110);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 26);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // AddTunnelForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(461, 146);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTunnelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add port";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox sourcePortTextBox;
        private System.Windows.Forms.Label labelSourcePort;
        private System.Windows.Forms.Label labelDestinationPort;
        private System.Windows.Forms.TextBox destinationPortTextBox;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.TextBox destinationTextBox;
    }
}
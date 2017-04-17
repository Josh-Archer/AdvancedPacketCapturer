namespace MyPacketCapturer
{
    partial class frmCapture
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
            this.components = new System.ComponentModel.Container();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.txtCapturedData = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendWindwoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMURFAttackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txtNumPackets = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGUID = new System.Windows.Forms.TextBox();
            this.chkBoxTCP = new System.Windows.Forms.CheckBox();
            this.chkBoxBroadcast = new System.Windows.Forms.CheckBox();
            this.chkBoxUDP = new System.Windows.Forms.CheckBox();
            this.chkBoxICMP = new System.Windows.Forms.CheckBox();
            this.chkBoxHost = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.aRPCachePoisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStop.Location = new System.Drawing.Point(206, 52);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(6);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(204, 63);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbDevices
            // 
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(114, 280);
            this.cmbDevices.Margin = new System.Windows.Forms.Padding(6);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(910, 33);
            this.cmbDevices.TabIndex = 1;
            this.cmbDevices.SelectedIndexChanged += new System.EventHandler(this.cmbDevices_SelectedIndexChanged);
            // 
            // txtCapturedData
            // 
            this.txtCapturedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapturedData.Location = new System.Drawing.Point(24, 433);
            this.txtCapturedData.Margin = new System.Windows.Forms.Padding(6);
            this.txtCapturedData.Multiline = true;
            this.txtCapturedData.Name = "txtCapturedData";
            this.txtCapturedData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCapturedData.Size = new System.Drawing.Size(1108, 1081);
            this.txtCapturedData.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.screenToolStripMenuItem,
            this.packetsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1160, 46);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 38);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(174, 38);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(174, 38);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // screenToolStripMenuItem
            // 
            this.screenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureToolStripMenuItem});
            this.screenToolStripMenuItem.Name = "screenToolStripMenuItem";
            this.screenToolStripMenuItem.Size = new System.Drawing.Size(99, 38);
            this.screenToolStripMenuItem.Text = "Screen";
            // 
            // captureToolStripMenuItem
            // 
            this.captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            this.captureToolStripMenuItem.Size = new System.Drawing.Size(169, 38);
            this.captureToolStripMenuItem.Text = "Clear";
            this.captureToolStripMenuItem.Click += new System.EventHandler(this.captureToolStripMenuItem_Click);
            // 
            // packetsToolStripMenuItem
            // 
            this.packetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendWindwoToolStripMenuItem,
            this.sMURFAttackToolStripMenuItem,
            this.aRPCachePoisonToolStripMenuItem});
            this.packetsToolStripMenuItem.Name = "packetsToolStripMenuItem";
            this.packetsToolStripMenuItem.Size = new System.Drawing.Size(105, 38);
            this.packetsToolStripMenuItem.Text = "Packets";
            // 
            // sendWindwoToolStripMenuItem
            // 
            this.sendWindwoToolStripMenuItem.Name = "sendWindwoToolStripMenuItem";
            this.sendWindwoToolStripMenuItem.Size = new System.Drawing.Size(306, 38);
            this.sendWindwoToolStripMenuItem.Text = "&Send Window";
            this.sendWindwoToolStripMenuItem.Click += new System.EventHandler(this.sendWindwoToolStripMenuItem_Click);
            // 
            // sMURFAttackToolStripMenuItem
            // 
            this.sMURFAttackToolStripMenuItem.Name = "sMURFAttackToolStripMenuItem";
            this.sMURFAttackToolStripMenuItem.Size = new System.Drawing.Size(306, 38);
            this.sMURFAttackToolStripMenuItem.Text = "SMURF Attack";
            this.sMURFAttackToolStripMenuItem.Click += new System.EventHandler(this.sMURFAttackToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtNumPackets
            // 
            this.txtNumPackets.Location = new System.Drawing.Point(844, 71);
            this.txtNumPackets.Margin = new System.Windows.Forms.Padding(6);
            this.txtNumPackets.Name = "txtNumPackets";
            this.txtNumPackets.ReadOnly = true;
            this.txtNumPackets.Size = new System.Drawing.Size(196, 31);
            this.txtNumPackets.TabIndex = 4;
            this.txtNumPackets.Text = "0";
            this.txtNumPackets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of Packets:";
            // 
            // txtGUID
            // 
            this.txtGUID.Location = new System.Drawing.Point(42, 344);
            this.txtGUID.Margin = new System.Windows.Forms.Padding(6);
            this.txtGUID.Name = "txtGUID";
            this.txtGUID.Size = new System.Drawing.Size(1052, 31);
            this.txtGUID.TabIndex = 6;
            // 
            // chkBoxTCP
            // 
            this.chkBoxTCP.AutoSize = true;
            this.chkBoxTCP.Location = new System.Drawing.Point(260, 164);
            this.chkBoxTCP.Name = "chkBoxTCP";
            this.chkBoxTCP.Size = new System.Drawing.Size(86, 29);
            this.chkBoxTCP.TabIndex = 7;
            this.chkBoxTCP.Text = "TCP";
            this.chkBoxTCP.UseVisualStyleBackColor = true;
            // 
            // chkBoxBroadcast
            // 
            this.chkBoxBroadcast.AutoSize = true;
            this.chkBoxBroadcast.Location = new System.Drawing.Point(260, 212);
            this.chkBoxBroadcast.Name = "chkBoxBroadcast";
            this.chkBoxBroadcast.Size = new System.Drawing.Size(141, 29);
            this.chkBoxBroadcast.TabIndex = 8;
            this.chkBoxBroadcast.Text = "Broadcast";
            this.chkBoxBroadcast.UseVisualStyleBackColor = true;
            // 
            // chkBoxUDP
            // 
            this.chkBoxUDP.AutoSize = true;
            this.chkBoxUDP.Location = new System.Drawing.Point(424, 163);
            this.chkBoxUDP.Name = "chkBoxUDP";
            this.chkBoxUDP.Size = new System.Drawing.Size(88, 29);
            this.chkBoxUDP.TabIndex = 9;
            this.chkBoxUDP.Text = "UDP";
            this.chkBoxUDP.UseVisualStyleBackColor = true;
            this.chkBoxUDP.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkBoxICMP
            // 
            this.chkBoxICMP.AutoSize = true;
            this.chkBoxICMP.Location = new System.Drawing.Point(424, 211);
            this.chkBoxICMP.Name = "chkBoxICMP";
            this.chkBoxICMP.Size = new System.Drawing.Size(96, 29);
            this.chkBoxICMP.TabIndex = 10;
            this.chkBoxICMP.Text = "ICMP";
            this.chkBoxICMP.UseVisualStyleBackColor = true;
            // 
            // chkBoxHost
            // 
            this.chkBoxHost.AutoSize = true;
            this.chkBoxHost.Location = new System.Drawing.Point(605, 184);
            this.chkBoxHost.Name = "chkBoxHost";
            this.chkBoxHost.Size = new System.Drawing.Size(94, 29);
            this.chkBoxHost.TabIndex = 11;
            this.chkBoxHost.Text = "Host:";
            this.chkBoxHost.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(695, 184);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 31);
            this.textBox1.TabIndex = 12;
            // 
            // aRPCachePoisonToolStripMenuItem
            // 
            this.aRPCachePoisonToolStripMenuItem.Name = "aRPCachePoisonToolStripMenuItem";
            this.aRPCachePoisonToolStripMenuItem.Size = new System.Drawing.Size(306, 38);
            this.aRPCachePoisonToolStripMenuItem.Text = "ARP Cache Poison";
            this.aRPCachePoisonToolStripMenuItem.Click += new System.EventHandler(this.aRPCachePoisonToolStripMenuItem_Click);
            // 
            // frmCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 1403);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chkBoxHost);
            this.Controls.Add(this.chkBoxICMP);
            this.Controls.Add(this.chkBoxUDP);
            this.Controls.Add(this.chkBoxBroadcast);
            this.Controls.Add(this.chkBoxTCP);
            this.Controls.Add(this.txtGUID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumPackets);
            this.Controls.Add(this.txtCapturedData);
            this.Controls.Add(this.cmbDevices);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmCapture";
            this.Text = "Packet Capture";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.TextBox txtCapturedData;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtNumPackets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem packetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendWindwoToolStripMenuItem;
        private System.Windows.Forms.TextBox txtGUID;
        private System.Windows.Forms.CheckBox chkBoxTCP;
        private System.Windows.Forms.CheckBox chkBoxBroadcast;
        private System.Windows.Forms.CheckBox chkBoxUDP;
        private System.Windows.Forms.CheckBox chkBoxICMP;
        private System.Windows.Forms.CheckBox chkBoxHost;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem sMURFAttackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aRPCachePoisonToolStripMenuItem;
    }
}


namespace ResumeXfer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.speedLabel = new System.Windows.Forms.Label();
            this.localFilePathTextBox = new System.Windows.Forms.TextBox();
            this.remoteFilePathTextBox = new System.Windows.Forms.TextBox();
            this.browseLocalFileButton = new System.Windows.Forms.Button();
            this.browseRemoteFolderButton = new System.Windows.Forms.Button();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.progressLabel = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLocalFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectRemoteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bufferSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_buffer_512 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_buffer_1024 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_buffer_2048 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_buffer_4096 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_buffer_8192 = new System.Windows.Forms.ToolStripMenuItem();
            this.maximumRetriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMI_retries_Infinity = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMI_retries_20 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMI_retries_50 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMI_retries_150 = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMI_retries_300 = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadCompletionNotificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uploadButton = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(12, 115);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(436, 32);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.BackColor = System.Drawing.Color.Transparent;
            this.speedLabel.Enabled = false;
            this.speedLabel.ForeColor = System.Drawing.Color.White;
            this.speedLabel.Location = new System.Drawing.Point(9, 150);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(81, 13);
            this.speedLabel.TabIndex = 2;
            this.speedLabel.Text = "Upload Speed: ";
            this.speedLabel.Visible = false;
            // 
            // localFilePathTextBox
            // 
            this.localFilePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.localFilePathTextBox.Location = new System.Drawing.Point(12, 66);
            this.localFilePathTextBox.Multiline = true;
            this.localFilePathTextBox.Name = "localFilePathTextBox";
            this.localFilePathTextBox.Size = new System.Drawing.Size(232, 32);
            this.localFilePathTextBox.TabIndex = 3;
            this.localFilePathTextBox.TextChanged += new System.EventHandler(this.localFilePathTextBox_TextChanged);
            // 
            // remoteFilePathTextBox
            // 
            this.remoteFilePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.remoteFilePathTextBox.Location = new System.Drawing.Point(309, 66);
            this.remoteFilePathTextBox.Multiline = true;
            this.remoteFilePathTextBox.Name = "remoteFilePathTextBox";
            this.remoteFilePathTextBox.Size = new System.Drawing.Size(232, 32);
            this.remoteFilePathTextBox.TabIndex = 4;
            this.remoteFilePathTextBox.TextChanged += new System.EventHandler(this.remoteFilePathTextBox_TextChanged);
            // 
            // browseLocalFileButton
            // 
            this.browseLocalFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(99)))));
            this.browseLocalFileButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.browseLocalFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseLocalFileButton.ForeColor = System.Drawing.Color.White;
            this.browseLocalFileButton.Location = new System.Drawing.Point(12, 21);
            this.browseLocalFileButton.Name = "browseLocalFileButton";
            this.browseLocalFileButton.Size = new System.Drawing.Size(154, 30);
            this.browseLocalFileButton.TabIndex = 5;
            this.browseLocalFileButton.Text = "Browse Local File";
            this.browseLocalFileButton.UseVisualStyleBackColor = false;
            this.browseLocalFileButton.Click += new System.EventHandler(this.BrowseLocalFileButton_Click);
            // 
            // browseRemoteFolderButton
            // 
            this.browseRemoteFolderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(99)))));
            this.browseRemoteFolderButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.browseRemoteFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseRemoteFolderButton.ForeColor = System.Drawing.Color.White;
            this.browseRemoteFolderButton.Location = new System.Drawing.Point(309, 21);
            this.browseRemoteFolderButton.Name = "browseRemoteFolderButton";
            this.browseRemoteFolderButton.Size = new System.Drawing.Size(161, 30);
            this.browseRemoteFolderButton.TabIndex = 6;
            this.browseRemoteFolderButton.Text = "Select Remote Folder";
            this.browseRemoteFolderButton.UseVisualStyleBackColor = false;
            this.browseRemoteFolderButton.Click += new System.EventHandler(this.BrowseRemoteFolderButton_Click);
            // 
            // rtbConsole
            // 
            this.rtbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbConsole.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtbConsole.ForeColor = System.Drawing.Color.White;
            this.rtbConsole.Location = new System.Drawing.Point(12, 190);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(529, 46);
            this.rtbConsole.TabIndex = 7;
            this.rtbConsole.Text = "";
            this.rtbConsole.Visible = false;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.BackColor = System.Drawing.Color.Transparent;
            this.progressLabel.Enabled = false;
            this.progressLabel.ForeColor = System.Drawing.Color.White;
            this.progressLabel.Location = new System.Drawing.Point(196, 150);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(48, 13);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "Progress";
            this.progressLabel.Visible = false;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.menuStrip1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMenu.Location = new System.Drawing.Point(60, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(497, 37);
            this.panelMenu.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem1,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(497, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLocalFileToolStripMenuItem,
            this.selectRemoteFolderToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openLocalFileToolStripMenuItem
            // 
            this.openLocalFileToolStripMenuItem.Name = "openLocalFileToolStripMenuItem";
            this.openLocalFileToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.openLocalFileToolStripMenuItem.Text = "Open Local File";
            this.openLocalFileToolStripMenuItem.Click += new System.EventHandler(this.BrowseLocalFileButton_Click);
            // 
            // selectRemoteFolderToolStripMenuItem
            // 
            this.selectRemoteFolderToolStripMenuItem.Name = "selectRemoteFolderToolStripMenuItem";
            this.selectRemoteFolderToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.selectRemoteFolderToolStripMenuItem.Text = "Select Remote Folder";
            this.selectRemoteFolderToolStripMenuItem.Click += new System.EventHandler(this.BrowseRemoteFolderButton_Click);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bufferSizeToolStripMenuItem,
            this.maximumRetriesToolStripMenuItem,
            this.uploadCompletionNotificationToolStripMenuItem});
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem1.Text = "Settings";
            // 
            // bufferSizeToolStripMenuItem
            // 
            this.bufferSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_buffer_512,
            this.TSMI_buffer_1024,
            this.TSMI_buffer_2048,
            this.TSMI_buffer_4096,
            this.TSMI_buffer_8192});
            this.bufferSizeToolStripMenuItem.Name = "bufferSizeToolStripMenuItem";
            this.bufferSizeToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.bufferSizeToolStripMenuItem.Text = "Buffer Size";
            // 
            // TSMI_buffer_512
            // 
            this.TSMI_buffer_512.Name = "TSMI_buffer_512";
            this.TSMI_buffer_512.Size = new System.Drawing.Size(109, 22);
            this.TSMI_buffer_512.Text = "512 KB";
            this.TSMI_buffer_512.Click += new System.EventHandler(this.bufferSizeToolStripMenuItem_Click);
            // 
            // TSMI_buffer_1024
            // 
            this.TSMI_buffer_1024.Checked = true;
            this.TSMI_buffer_1024.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI_buffer_1024.Name = "TSMI_buffer_1024";
            this.TSMI_buffer_1024.Size = new System.Drawing.Size(109, 22);
            this.TSMI_buffer_1024.Text = "1 MB";
            this.TSMI_buffer_1024.Click += new System.EventHandler(this.bufferSizeToolStripMenuItem_Click);
            // 
            // TSMI_buffer_2048
            // 
            this.TSMI_buffer_2048.Name = "TSMI_buffer_2048";
            this.TSMI_buffer_2048.Size = new System.Drawing.Size(109, 22);
            this.TSMI_buffer_2048.Text = "2 MB";
            this.TSMI_buffer_2048.Click += new System.EventHandler(this.bufferSizeToolStripMenuItem_Click);
            // 
            // TSMI_buffer_4096
            // 
            this.TSMI_buffer_4096.Name = "TSMI_buffer_4096";
            this.TSMI_buffer_4096.Size = new System.Drawing.Size(109, 22);
            this.TSMI_buffer_4096.Text = "4 MB";
            this.TSMI_buffer_4096.Click += new System.EventHandler(this.bufferSizeToolStripMenuItem_Click);
            // 
            // TSMI_buffer_8192
            // 
            this.TSMI_buffer_8192.Name = "TSMI_buffer_8192";
            this.TSMI_buffer_8192.Size = new System.Drawing.Size(109, 22);
            this.TSMI_buffer_8192.Text = "8 MB";
            this.TSMI_buffer_8192.Click += new System.EventHandler(this.bufferSizeToolStripMenuItem_Click);
            // 
            // maximumRetriesToolStripMenuItem
            // 
            this.maximumRetriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMI_retries_Infinity,
            this.tSMI_retries_20,
            this.tSMI_retries_50,
            this.tSMI_retries_150,
            this.tSMI_retries_300});
            this.maximumRetriesToolStripMenuItem.Name = "maximumRetriesToolStripMenuItem";
            this.maximumRetriesToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.maximumRetriesToolStripMenuItem.Text = "Maximum Retries";
            // 
            // tSMI_retries_Infinity
            // 
            this.tSMI_retries_Infinity.Checked = true;
            this.tSMI_retries_Infinity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tSMI_retries_Infinity.Name = "tSMI_retries_Infinity";
            this.tSMI_retries_Infinity.Size = new System.Drawing.Size(111, 22);
            this.tSMI_retries_Infinity.Text = "Infinity";
            this.tSMI_retries_Infinity.Click += new System.EventHandler(this.MaxRetrytoolStripMenuItem_Click);
            // 
            // tSMI_retries_20
            // 
            this.tSMI_retries_20.Name = "tSMI_retries_20";
            this.tSMI_retries_20.Size = new System.Drawing.Size(111, 22);
            this.tSMI_retries_20.Text = "20";
            this.tSMI_retries_20.Click += new System.EventHandler(this.MaxRetrytoolStripMenuItem_Click);
            // 
            // tSMI_retries_50
            // 
            this.tSMI_retries_50.Name = "tSMI_retries_50";
            this.tSMI_retries_50.Size = new System.Drawing.Size(111, 22);
            this.tSMI_retries_50.Text = "50";
            this.tSMI_retries_50.Click += new System.EventHandler(this.MaxRetrytoolStripMenuItem_Click);
            // 
            // tSMI_retries_150
            // 
            this.tSMI_retries_150.Name = "tSMI_retries_150";
            this.tSMI_retries_150.Size = new System.Drawing.Size(111, 22);
            this.tSMI_retries_150.Text = "150";
            this.tSMI_retries_150.Click += new System.EventHandler(this.MaxRetrytoolStripMenuItem_Click);
            // 
            // tSMI_retries_300
            // 
            this.tSMI_retries_300.Name = "tSMI_retries_300";
            this.tSMI_retries_300.Size = new System.Drawing.Size(111, 22);
            this.tSMI_retries_300.Text = "300";
            this.tSMI_retries_300.Click += new System.EventHandler(this.MaxRetrytoolStripMenuItem_Click);
            // 
            // uploadCompletionNotificationToolStripMenuItem
            // 
            this.uploadCompletionNotificationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledToolStripMenuItem,
            this.disabledToolStripMenuItem});
            this.uploadCompletionNotificationToolStripMenuItem.Name = "uploadCompletionNotificationToolStripMenuItem";
            this.uploadCompletionNotificationToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.uploadCompletionNotificationToolStripMenuItem.Text = "Upload completion notification";
            // 
            // enabledToolStripMenuItem
            // 
            this.enabledToolStripMenuItem.Name = "enabledToolStripMenuItem";
            this.enabledToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.enabledToolStripMenuItem.Text = "Enabled";
            this.enabledToolStripMenuItem.Click += new System.EventHandler(this.uploadCompletionNotificationToolStripMenuItem_Click);
            // 
            // disabledToolStripMenuItem
            // 
            this.disabledToolStripMenuItem.Checked = true;
            this.disabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disabledToolStripMenuItem.Name = "disabledToolStripMenuItem";
            this.disabledToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.disabledToolStripMenuItem.Text = "Disabled";
            this.disabledToolStripMenuItem.Click += new System.EventHandler(this.uploadCompletionNotificationToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consoleOutputToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // consoleOutputToolStripMenuItem
            // 
            this.consoleOutputToolStripMenuItem.Name = "consoleOutputToolStripMenuItem";
            this.consoleOutputToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.consoleOutputToolStripMenuItem.Text = "Show Console";
            this.consoleOutputToolStripMenuItem.Click += new System.EventHandler(this.consoleOutputToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // instructionsToolStripMenuItem1
            // 
            this.instructionsToolStripMenuItem1.Name = "instructionsToolStripMenuItem1";
            this.instructionsToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.instructionsToolStripMenuItem1.Text = "Instructions";
            this.instructionsToolStripMenuItem1.Click += new System.EventHandler(this.instructionsToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.cancelToolStripMenuItem.Text = "Close";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.panelMenu);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(557, 37);
            this.panelTop.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ResumeXfer.Properties.Resources.banner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // uploadButton
            // 
            this.uploadButton.AutoSize = true;
            this.uploadButton.BackgroundImage = global::ResumeXfer.Properties.Resources.Upload;
            this.uploadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.uploadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uploadButton.Enabled = false;
            this.uploadButton.FlatAppearance.BorderSize = 0;
            this.uploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.uploadButton.Location = new System.Drawing.Point(462, 118);
            this.uploadButton.Margin = new System.Windows.Forms.Padding(0);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(68, 45);
            this.uploadButton.TabIndex = 0;
            this.uploadButton.UseVisualStyleBackColor = false;
            this.uploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            this.uploadButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uploadButton_MouseDown);
            this.uploadButton.MouseEnter += new System.EventHandler(this.uploadButton_MouseEnter);
            this.uploadButton.MouseLeave += new System.EventHandler(this.uploadButton_MouseLeave);
            this.uploadButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uploadButton_MouseUp);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Transparent;
            this.panelContent.Controls.Add(this.uploadButton);
            this.panelContent.Controls.Add(this.progressBar1);
            this.panelContent.Controls.Add(this.speedLabel);
            this.panelContent.Controls.Add(this.browseLocalFileButton);
            this.panelContent.Controls.Add(this.browseRemoteFolderButton);
            this.panelContent.Controls.Add(this.rtbConsole);
            this.panelContent.Controls.Add(this.progressLabel);
            this.panelContent.Controls.Add(this.localFilePathTextBox);
            this.panelContent.Controls.Add(this.remoteFilePathTextBox);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 37);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(557, 248);
            this.panelContent.TabIndex = 12;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(557, 285);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 500);
            this.Name = "frmMain";
            this.Text = "ResumeXfer";
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.TextBox localFilePathTextBox;
        private System.Windows.Forms.TextBox remoteFilePathTextBox;
        private System.Windows.Forms.Button browseLocalFileButton;
        private System.Windows.Forms.Button browseRemoteFolderButton;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLocalFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectRemoteFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bufferSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maximumRetriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_buffer_512;
        private System.Windows.Forms.ToolStripMenuItem TSMI_buffer_1024;
        private System.Windows.Forms.ToolStripMenuItem TSMI_buffer_2048;
        private System.Windows.Forms.ToolStripMenuItem TSMI_buffer_4096;
        private System.Windows.Forms.ToolStripMenuItem TSMI_buffer_8192;
        private System.Windows.Forms.ToolStripMenuItem tSMI_retries_Infinity;
        private System.Windows.Forms.ToolStripMenuItem tSMI_retries_20;
        private System.Windows.Forms.ToolStripMenuItem tSMI_retries_50;
        private System.Windows.Forms.ToolStripMenuItem tSMI_retries_150;
        private System.Windows.Forms.ToolStripMenuItem tSMI_retries_300;
        private System.Windows.Forms.ToolStripMenuItem uploadCompletionNotificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem;
        private System.Windows.Forms.Panel panelContent;
    }
}


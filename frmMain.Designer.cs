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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.speedLabel = new System.Windows.Forms.Label();
            this.localFilePathTextBox = new System.Windows.Forms.TextBox();
            this.remoteFilePathTextBox = new System.Windows.Forms.TextBox();
            this.browseLocalFileButton = new System.Windows.Forms.Button();
            this.browseRemoteFolderButton = new System.Windows.Forms.Button();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.progressLabel = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLocalFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectRemoteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bufferSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mBToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mBToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.maximumRetriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uploadButton = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(11, 129);
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
            this.speedLabel.Location = new System.Drawing.Point(12, 172);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(81, 13);
            this.speedLabel.TabIndex = 2;
            this.speedLabel.Text = "Upload Speed: ";
            this.speedLabel.Visible = false;
            // 
            // localFilePathTextBox
            // 
            this.localFilePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.localFilePathTextBox.Location = new System.Drawing.Point(11, 84);
            this.localFilePathTextBox.Multiline = true;
            this.localFilePathTextBox.Name = "localFilePathTextBox";
            this.localFilePathTextBox.Size = new System.Drawing.Size(232, 32);
            this.localFilePathTextBox.TabIndex = 3;
            this.localFilePathTextBox.TextChanged += new System.EventHandler(this.localFilePathTextBox_TextChanged);
            // 
            // remoteFilePathTextBox
            // 
            this.remoteFilePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.remoteFilePathTextBox.Location = new System.Drawing.Point(309, 84);
            this.remoteFilePathTextBox.Multiline = true;
            this.remoteFilePathTextBox.Name = "remoteFilePathTextBox";
            this.remoteFilePathTextBox.Size = new System.Drawing.Size(232, 32);
            this.remoteFilePathTextBox.TabIndex = 4;
            this.remoteFilePathTextBox.TextChanged += new System.EventHandler(this.remoteFilePathTextBox_TextChanged);
            // 
            // browseLocalFileButton
            // 
            this.browseLocalFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(85)))), ((int)(((byte)(50)))));
            this.browseLocalFileButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.browseLocalFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseLocalFileButton.ForeColor = System.Drawing.Color.White;
            this.browseLocalFileButton.Location = new System.Drawing.Point(11, 43);
            this.browseLocalFileButton.Name = "browseLocalFileButton";
            this.browseLocalFileButton.Size = new System.Drawing.Size(154, 30);
            this.browseLocalFileButton.TabIndex = 5;
            this.browseLocalFileButton.Text = "Browse Local File";
            this.browseLocalFileButton.UseVisualStyleBackColor = false;
            this.browseLocalFileButton.Click += new System.EventHandler(this.BrowseLocalFileButton_Click);
            // 
            // browseRemoteFolderButton
            // 
            this.browseRemoteFolderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(85)))), ((int)(((byte)(50)))));
            this.browseRemoteFolderButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.browseRemoteFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseRemoteFolderButton.ForeColor = System.Drawing.Color.White;
            this.browseRemoteFolderButton.Location = new System.Drawing.Point(309, 43);
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
            this.rtbConsole.Location = new System.Drawing.Point(13, 202);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(532, 46);
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
            this.progressLabel.Location = new System.Drawing.Point(195, 172);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(48, 13);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "Progress";
            this.progressLabel.Visible = false;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.menuStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(557, 27);
            this.panelTop.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, -4);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(557, 31);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLocalFileToolStripMenuItem,
            this.selectRemoteFolderToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(29, 27);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openLocalFileToolStripMenuItem
            // 
            this.openLocalFileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.openLocalFileToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.openLocalFileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openLocalFileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openLocalFileToolStripMenuItem.Name = "openLocalFileToolStripMenuItem";
            this.openLocalFileToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.openLocalFileToolStripMenuItem.Size = new System.Drawing.Size(185, 20);
            this.openLocalFileToolStripMenuItem.Text = "Open Local File";
            this.openLocalFileToolStripMenuItem.Click += new System.EventHandler(this.BrowseLocalFileButton_Click);
            // 
            // selectRemoteFolderToolStripMenuItem
            // 
            this.selectRemoteFolderToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.selectRemoteFolderToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectRemoteFolderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.selectRemoteFolderToolStripMenuItem.Name = "selectRemoteFolderToolStripMenuItem";
            this.selectRemoteFolderToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.selectRemoteFolderToolStripMenuItem.Size = new System.Drawing.Size(185, 20);
            this.selectRemoteFolderToolStripMenuItem.Text = "Select Remote Folder";
            this.selectRemoteFolderToolStripMenuItem.Click += new System.EventHandler(this.BrowseRemoteFolderButton_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bufferSizeToolStripMenuItem,
            this.maximumRetriesToolStripMenuItem});
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 27);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // bufferSizeToolStripMenuItem
            // 
            this.bufferSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kBToolStripMenuItem,
            this.mBToolStripMenuItem,
            this.mBToolStripMenuItem1,
            this.mBToolStripMenuItem2,
            this.mBToolStripMenuItem3});
            this.bufferSizeToolStripMenuItem.Name = "bufferSizeToolStripMenuItem";
            this.bufferSizeToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.bufferSizeToolStripMenuItem.Text = "Buffer Size";
            this.bufferSizeToolStripMenuItem.DoubleClick += new System.EventHandler(this.bufferSizeToolStripMenuItem_DoubleClick);
            // 
            // kBToolStripMenuItem
            // 
            this.kBToolStripMenuItem.Name = "kBToolStripMenuItem";
            this.kBToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.kBToolStripMenuItem.Text = "512 KB";
            this.kBToolStripMenuItem.Click += new System.EventHandler(this.bufferSizeToolStripMenuItem_Click);
            // 
            // mBToolStripMenuItem
            // 
            this.mBToolStripMenuItem.Checked = true;
            this.mBToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mBToolStripMenuItem.Name = "mBToolStripMenuItem";
            this.mBToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.mBToolStripMenuItem.Text = "1 MB";
            this.mBToolStripMenuItem.Click += new System.EventHandler(this.bufferSizeToolStripMenuItem_Click);
            // 
            // mBToolStripMenuItem1
            // 
            this.mBToolStripMenuItem1.Name = "mBToolStripMenuItem1";
            this.mBToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.mBToolStripMenuItem1.Text = "2 MB";
            this.mBToolStripMenuItem1.Click += new System.EventHandler(this.bufferSizeToolStripMenuItem_Click);
            // 
            // mBToolStripMenuItem2
            // 
            this.mBToolStripMenuItem2.Name = "mBToolStripMenuItem2";
            this.mBToolStripMenuItem2.Size = new System.Drawing.Size(109, 22);
            this.mBToolStripMenuItem2.Text = "4 MB";
            this.mBToolStripMenuItem2.Click += new System.EventHandler(this.bufferSizeToolStripMenuItem_Click);
            // 
            // mBToolStripMenuItem3
            // 
            this.mBToolStripMenuItem3.Name = "mBToolStripMenuItem3";
            this.mBToolStripMenuItem3.Size = new System.Drawing.Size(109, 22);
            this.mBToolStripMenuItem3.Text = "8 MB";
            this.mBToolStripMenuItem3.Click += new System.EventHandler(this.bufferSizeToolStripMenuItem_Click);
            // 
            // maximumRetriesToolStripMenuItem
            // 
            this.maximumRetriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.maximumRetriesToolStripMenuItem.Name = "maximumRetriesToolStripMenuItem";
            this.maximumRetriesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.maximumRetriesToolStripMenuItem.Text = "Maximum Retries";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Checked = true;
            this.toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItem1.Text = "Infinity";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.MaxRetrytoolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItem2.Text = "20";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.MaxRetrytoolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItem3.Text = "50";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.MaxRetrytoolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItem4.Text = "150";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.MaxRetrytoolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItem5.Text = "300";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.MaxRetrytoolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consoleOutputToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 27);
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
            this.instructionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 27);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.instructionsToolStripMenuItem.Text = "Instructions";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.closeToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 27);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.BackgroundImage = global::ResumeXfer.Properties.Resources.Upload;
            this.uploadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uploadButton.Enabled = false;
            this.uploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.uploadButton.Location = new System.Drawing.Point(508, 128);
            this.uploadButton.Margin = new System.Windows.Forms.Padding(0);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(33, 33);
            this.uploadButton.TabIndex = 0;
            this.uploadButton.UseVisualStyleBackColor = false;
            this.uploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            this.uploadButton.MouseEnter += new System.EventHandler(this.uploadButton_MouseEnter);
            this.uploadButton.MouseLeave += new System.EventHandler(this.uploadButton_MouseLeave);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(557, 263);
            this.Controls.Add(this.remoteFilePathTextBox);
            this.Controls.Add(this.localFilePathTextBox);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.browseRemoteFolderButton);
            this.Controls.Add(this.browseLocalFileButton);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.uploadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 500);
            this.Name = "frmMain";
            this.Text = "Resume X fer";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLocalFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectRemoteFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bufferSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mBToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mBToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mBToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem maximumRetriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
    }
}


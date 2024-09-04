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
            this.uploadButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.speedLabel = new System.Windows.Forms.Label();
            this.localFilePathTextBox = new System.Windows.Forms.TextBox();
            this.remoteFilePathTextBox = new System.Windows.Forms.TextBox();
            this.browseLocalFileButton = new System.Windows.Forms.Button();
            this.browseRemoteFolderButton = new System.Windows.Forms.Button();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.progressLabel = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uploadButton
            // 
            this.uploadButton.Enabled = false;
            this.uploadButton.Location = new System.Drawing.Point(504, 88);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 0;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 117);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(567, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(9, 153);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(81, 13);
            this.speedLabel.TabIndex = 2;
            this.speedLabel.Text = "Upload Speed: ";
            // 
            // localFilePathTextBox
            // 
            this.localFilePathTextBox.Location = new System.Drawing.Point(12, 62);
            this.localFilePathTextBox.Name = "localFilePathTextBox";
            this.localFilePathTextBox.Size = new System.Drawing.Size(269, 20);
            this.localFilePathTextBox.TabIndex = 3;
            // 
            // remoteFilePathTextBox
            // 
            this.remoteFilePathTextBox.Location = new System.Drawing.Point(310, 62);
            this.remoteFilePathTextBox.Name = "remoteFilePathTextBox";
            this.remoteFilePathTextBox.Size = new System.Drawing.Size(269, 20);
            this.remoteFilePathTextBox.TabIndex = 4;
            // 
            // browseLocalFileButton
            // 
            this.browseLocalFileButton.Location = new System.Drawing.Point(12, 33);
            this.browseLocalFileButton.Name = "browseLocalFileButton";
            this.browseLocalFileButton.Size = new System.Drawing.Size(149, 23);
            this.browseLocalFileButton.TabIndex = 5;
            this.browseLocalFileButton.Text = "Browse Local File";
            this.browseLocalFileButton.UseVisualStyleBackColor = true;
            this.browseLocalFileButton.Click += new System.EventHandler(this.BrowseLocalFileButton_Click);
            // 
            // browseRemoteFolderButton
            // 
            this.browseRemoteFolderButton.Location = new System.Drawing.Point(310, 33);
            this.browseRemoteFolderButton.Name = "browseRemoteFolderButton";
            this.browseRemoteFolderButton.Size = new System.Drawing.Size(149, 23);
            this.browseRemoteFolderButton.TabIndex = 6;
            this.browseRemoteFolderButton.Text = "Browse Remote Folder";
            this.browseRemoteFolderButton.UseVisualStyleBackColor = true;
            this.browseRemoteFolderButton.Click += new System.EventHandler(this.BrowseRemoteFolderButton_Click);
            // 
            // rtbConsole
            // 
            this.rtbConsole.Location = new System.Drawing.Point(11, 169);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(567, 46);
            this.rtbConsole.TabIndex = 7;
            this.rtbConsole.Text = "";
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(307, 153);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(48, 13);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "Progress";
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 231);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(590, 25);
            this.toolStrip.TabIndex = 9;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(590, 27);
            this.panelTop.TabIndex = 10;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(590, 256);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.browseRemoteFolderButton);
            this.Controls.Add(this.browseLocalFileButton);
            this.Controls.Add(this.remoteFilePathTextBox);
            this.Controls.Add(this.localFilePathTextBox);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.uploadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(606, 287);
            this.Name = "frmMain";
            this.Text = "File Uploader With Resume";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panelTop;
    }
}


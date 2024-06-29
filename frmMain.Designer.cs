namespace UploaderWithResume
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
            this.SuspendLayout();
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(708, 77);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 0;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 145);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(776, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(256, 171);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(81, 13);
            this.speedLabel.TabIndex = 2;
            this.speedLabel.Text = "Upload Speed: ";
            // 
            // localFilePathTextBox
            // 
            this.localFilePathTextBox.Location = new System.Drawing.Point(12, 41);
            this.localFilePathTextBox.Name = "localFilePathTextBox";
            this.localFilePathTextBox.Size = new System.Drawing.Size(369, 20);
            this.localFilePathTextBox.TabIndex = 3;
            // 
            // remoteFilePathTextBox
            // 
            this.remoteFilePathTextBox.Location = new System.Drawing.Point(414, 41);
            this.remoteFilePathTextBox.Name = "remoteFilePathTextBox";
            this.remoteFilePathTextBox.Size = new System.Drawing.Size(369, 20);
            this.remoteFilePathTextBox.TabIndex = 4;
            // 
            // browseLocalFileButton
            // 
            this.browseLocalFileButton.Location = new System.Drawing.Point(12, 12);
            this.browseLocalFileButton.Name = "browseLocalFileButton";
            this.browseLocalFileButton.Size = new System.Drawing.Size(149, 23);
            this.browseLocalFileButton.TabIndex = 5;
            this.browseLocalFileButton.Text = "Browse Local File";
            this.browseLocalFileButton.UseVisualStyleBackColor = true;
            this.browseLocalFileButton.Click += new System.EventHandler(this.browseLocalFileButton_Click);
            // 
            // browseRemoteFolderButton
            // 
            this.browseRemoteFolderButton.Location = new System.Drawing.Point(414, 12);
            this.browseRemoteFolderButton.Name = "browseRemoteFolderButton";
            this.browseRemoteFolderButton.Size = new System.Drawing.Size(149, 23);
            this.browseRemoteFolderButton.TabIndex = 6;
            this.browseRemoteFolderButton.Text = "Browse Remote Folder";
            this.browseRemoteFolderButton.UseVisualStyleBackColor = true;
            this.browseRemoteFolderButton.Click += new System.EventHandler(this.browseRemoteFolderButton_Click);
            // 
            // rtbConsole
            // 
            this.rtbConsole.Location = new System.Drawing.Point(12, 207);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(776, 61);
            this.rtbConsole.TabIndex = 7;
            this.rtbConsole.Text = "";
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(438, 171);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(48, 13);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "Progress";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 280);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.browseRemoteFolderButton);
            this.Controls.Add(this.browseLocalFileButton);
            this.Controls.Add(this.remoteFilePathTextBox);
            this.Controls.Add(this.localFilePathTextBox);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.uploadButton);
            this.Name = "frmMain";
            this.Text = "File Uploader With Resume";
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
    }
}


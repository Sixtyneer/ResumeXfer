﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeXfer
{
    public partial class frmMain : Form
    {
        int buffersize = 1024 * 1024; //1 MB
        int retryCount = 0; 
        int maxRetries = -1; //Infinity retries
        private bool cancelRequested = false;
        private bool isPaused = false;
        private CancellationTokenSource cancellationTokenSource;

        public frmMain()
        {
            InitializeComponent();
            Coloring();
            menuStrip1.Renderer = new menuStripRender();
        }
        private void Coloring() 
        {
            panelTop.BackColor = BackColor;
            menuStrip1.BackColor = BackColor;

            // Set other properties (like text and font)
            browseLocalFileButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            browseRemoteFolderButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            // Add hover effect
            browseLocalFileButton.MouseEnter += (sender, e) => {
                browseLocalFileButton.BackColor = Color.FromArgb(50, 120, 70); // Lighter green on hover
                browseLocalFileButton.FlatAppearance.BorderColor = Color.FromArgb(70, 150, 90); // Lighter green border on hover
            };
            browseLocalFileButton.MouseLeave += (sender, e) => {
                browseLocalFileButton.BackColor = Color.FromArgb(34, 85, 50); // Revert back to original dark green color
                browseLocalFileButton.FlatAppearance.BorderColor = Color.FromArgb(40, 100, 60); // Revert back to original border color
            };
            browseRemoteFolderButton.MouseEnter += (sender, e) => {
                browseRemoteFolderButton.BackColor = Color.FromArgb(50, 120, 70); // Lighter green on hover
                browseRemoteFolderButton.FlatAppearance.BorderColor = Color.FromArgb(70, 150, 90); // Lighter green border on hover
            };
            browseRemoteFolderButton.MouseLeave += (sender, e) => {
                browseRemoteFolderButton.BackColor = Color.FromArgb(34, 85, 50); // Revert back to original dark green color
                browseRemoteFolderButton.FlatAppearance.BorderColor = Color.FromArgb(40, 100, 60); // Revert back to original border color
            };
        }
        private void BrowseLocalFileButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog()) 
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    localFilePathTextBox.Text = openFileDialog.FileName;
            ValidateUploadButton();
        }

        private void BrowseRemoteFolderButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    remoteFilePathTextBox.Text = folderBrowserDialog.SelectedPath;

            ValidateUploadButton();
        }
        string localFilePath = string.Empty;
        string remoteFolderPath = string.Empty;
        private string originalLocalFilePath = string.Empty; // Store the original file path for comparison
        private async void UploadButton_Click(object sender, EventArgs e)
        {
            toolTip1.Hide(this);

            localFilePath = localFilePathTextBox.Text;
            remoteFolderPath = remoteFilePathTextBox.Text;
            
            // If already uploading, handle pause/resume logic
            if (cancellationTokenSource != null && !isPaused)
            {
                // Pause the upload
                isPaused = true;
                cancellationTokenSource.Cancel();
                uploadButton.BackgroundImage = Image.FromFile("Upload.png"); // Change to resume button icon
                rtbConsole.Text = DateTime.Now + " Upload paused.";
                return;
            }

            // If resuming
            if (isPaused)
            {
                // Resume the upload
                isPaused = false;
                uploadButton.BackgroundImage = Image.FromFile("pause.png"); // Change to pause button icon
                rtbConsole.Text = DateTime.Now + " Resuming upload...";
                localFilePath = localFilePathTextBox.Text;
                remoteFolderPath = remoteFilePathTextBox.Text;

                if (ValidatePaths())
                {
                    string remoteFilePath = Path.Combine(remoteFolderPath, Path.GetFileName(localFilePath));
                    cancellationTokenSource = new CancellationTokenSource(); // Create a new token for resuming
                    await UploadFileWithResume(localFilePath, remoteFilePath, cancellationTokenSource.Token);
                }
                return;
            }
            
            // If starting the upload for the first time
            if (ValidatePaths())
            {
                originalLocalFilePath = localFilePathTextBox.Text; // Store the original path
                string remoteFilePath = Path.Combine(remoteFolderPath, Path.GetFileName(localFilePath));
                uploadButton.BackgroundImage = Image.FromFile("pause.png"); // Change to pause button icon
                cancellationTokenSource = new CancellationTokenSource(); // Create the cancellation token
                await UploadFileWithResume(localFilePath, remoteFilePath, cancellationTokenSource.Token);
            }
        }
        private void ValidateUploadButton() 
        {
            if (remoteFilePathTextBox.Text != string.Empty && localFilePathTextBox.Text != string.Empty)
                uploadButton.Enabled = true;
            else uploadButton.Enabled = false;
        }
        private bool ValidatePaths()
        {
            // Check if both paths are valid
            bool isLocalPathValid = IsValidLocalFilePath(localFilePathTextBox.Text);
            bool isRemotePathValid = IsValidRemoteFolderPath(remoteFilePathTextBox.Text);

            uploadButton.Enabled = isLocalPathValid && isRemotePathValid;

            if (!isLocalPathValid)
            {
                MessageBox.Show("The local file path is invalid or the file does not exist.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                uploadButton.Enabled = true;
                return false;
            }
            if (!isRemotePathValid)
            {
                MessageBox.Show("The remote folder path is invalid or the directory does not exist.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                uploadButton.Enabled = true;
                return false;
            }
            return true;
        }
        private bool IsValidLocalFilePath(string localFilePath)
        {
            return Path.IsPathRooted(localFilePath) && File.Exists(localFilePath);
        }
        private bool IsValidRemoteFolderPath(string remoteFolderPath)
        {
            return Path.IsPathRooted(remoteFolderPath) && Directory.Exists(remoteFolderPath);
        }
        private int maxUploadSpeed = 1024; // Maximum upload speed in KB/s (example: 1024 KB/s = 1 MB/s)
        private async Task UploadFileWithResume(string localFilePath, string remoteFilePath, CancellationToken cancellationToken)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(localFilePath);
                long fileLength = fileInfo.Length;
                long totalBytesUploaded = 0;

                if (File.Exists(remoteFilePath))
                {
                    totalBytesUploaded = new FileInfo(remoteFilePath).Length;
                }

                FileStream localStream = null;
                try
                {
                    localStream = new FileStream(localFilePath, FileMode.Open, FileAccess.Read);
                    localStream.Seek(totalBytesUploaded, SeekOrigin.Begin);

                    // 1MB buffer size
                    byte[] buffer = new byte[buffersize]; 
                    int bytesRead;
                    Stopwatch stopwatch = Stopwatch.StartNew();

                    ToggleUIControls(false);

                    while (totalBytesUploaded < fileLength)
                    {
                        // Check if the operation is canceled
                        if (cancellationToken.IsCancellationRequested)
                        {
                            rtbConsole.Text = DateTime.Now + $" Upload paused by user at {progressBar1.Value}% completion...";
                            break;
                        }

                        // Check if cancel was requested
                        if (cancelRequested)
                        {
                            rtbConsole.Text = $"{DateTime.Now} Upload canceled at {progressBar1.Value}% completion.";
                            break; // Exit the upload loop
                        }
                        try
                        {
                            bytesRead = await localStream.ReadAsync(buffer, 0, buffer.Length);
                            if (bytesRead == 0) break;

                            using (FileStream remoteStream = new FileStream(remoteFilePath, FileMode.Append, FileAccess.Write, FileShare.None))
                            {
                                await remoteStream.WriteAsync(buffer, 0, bytesRead);
                            }

                            totalBytesUploaded += bytesRead;

                            // Reset the retry counter when successful data transmission occurs
                            retryCount = 0;

                            // Calculate speed (in KB/s)
                            double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
                            double speedKilobytes = totalBytesUploaded / elapsedSeconds / 1024.0;

                            // Calculate kilobytes
                            double totalKilobytesUploaded = totalBytesUploaded / 1024.0;
                            double totalKilobytes = fileLength / 1024.0;

                            // Update progress bar and speed label
                            progressBar1.Invoke((Action)(() =>
                            {
                                progressBar1.Value = (int)(totalBytesUploaded / (double)fileLength * 100);
                            }));

                            speedLabel.Invoke((Action)(() =>
                            {
                                if (speedKilobytes < 15000) speedLabel.Text = $"Upload speed: {speedKilobytes:F2} KB/s";
                                if (speedKilobytes >= 15000 && speedKilobytes < 800000) speedLabel.Text = $"Upload speed: {speedKilobytes / 1024.0:F2} MB/s";
                                if (speedKilobytes >= 800000) speedLabel.Text = $"Upload speed: {speedKilobytes / 1048576.0:F2} GB/s";
                            }));

                            progressLabel.Invoke((Action)(() =>
                            {
                                if (speedKilobytes < 15000) progressLabel.Text = $"Progress: {totalKilobytesUploaded:F2} KB / {totalKilobytes:F2} KB uploaded | ({Math.Round(totalKilobytesUploaded / totalKilobytes, 3) * 100})%";
                                else if (speedKilobytes < 800000) speedLabel.Text = $"Progress: {totalKilobytesUploaded/1024.0:F2} MB / {totalKilobytes/1024.0:F2} MB uploaded | ({Math.Round(totalKilobytesUploaded / totalKilobytes, 3) * 100})%";
                                else speedLabel.Text = $"Progress: {totalKilobytesUploaded/1024.0:F2} MB / {totalKilobytes/ 1048576.0:F2} GB uploaded | ({Math.Round(totalKilobytesUploaded / totalKilobytes, 3) * 100})%";
                            }));

                        }
                        catch (IOException)
                        {
                            if (!(maxRetries == -1))
                            {
                                retryCount++;
                                if (retryCount >= maxRetries)
                                {
                                    MessageBox.Show($"Upload failed after {maxRetries} attempts..", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            }
                            
                            // Handle disconnection
                            rtbConsole.Text = DateTime.Now + " Connection lost. Retrying... " + (maxRetries == -1 ? "(IO Exception)" : $"({retryCount}/{maxRetries})");
                            await Task.Delay(5000); // Wait for 5 seconds before retrying

                            // Reopen the local file stream and seek to the current position
                            localStream?.Dispose();
                            localStream = new FileStream(localFilePath, FileMode.Open, FileAccess.Read);
                            localStream.Seek(totalBytesUploaded, SeekOrigin.Begin);
                        }
                    }
                }
                finally
                {
                    localStream?.Dispose();
                    retryCount = 0;
                }
                if (!cancelRequested && !cancellationToken.IsCancellationRequested) rtbConsole.Text = $"{DateTime.Now} Upload of {Path.GetFileName(localFilePath)} completed successfully.";
            }
            catch (Exception ex)
            {
                rtbConsole.Text = DateTime.Now + " Error: " + ex.Message;
            }
            finally
            {
                ToggleUIControls(true);
                uploadButton.BackgroundImage = Image.FromFile("upload.png"); // Reset button to default
                cancelRequested = false; // Reset cancel flag for future uploads
                cancellationTokenSource = null; // Reset after the task is completed
            }
        }

        private void ToggleUIControls(bool enabled)
        {
            progressBar1.Visible = !enabled;
            speedLabel.Visible = !enabled;
            progressLabel.Visible = !enabled;
            browseLocalFileButton.Enabled = enabled;
            browseRemoteFolderButton.Enabled = enabled;
            openLocalFileToolStripMenuItem.Enabled = enabled;
            selectRemoteFolderToolStripMenuItem.Enabled = enabled;
            localFilePathTextBox.Enabled = enabled;
            remoteFilePathTextBox.Enabled = enabled;
        }

        private void localFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateUploadButton();

            // If the file path is changed back to the original, allow resuming
            if (isPaused && localFilePathTextBox.Text == originalLocalFilePath)
            {
                // Do not reset the pause state, just maintain the pause icon
                rtbConsole.Text = DateTime.Now + " Resuming with the original file path.";
            }
            else
            {
                // If the file path is changed to something else, reset to upload icon
                if (isPaused)
                {
                    uploadButton.BackgroundImage = Image.FromFile("upload.png");
                    isPaused = false; // Reset pause state
                }
            }
        }

        private void remoteFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateUploadButton();

            // Reset to upload icon if changes are made while paused
            if (isPaused)
            {
                uploadButton.BackgroundImage = Image.FromFile("upload.png");
                isPaused = false; // Reset pause state
            }
        }

        // Constants to handle the dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        // Import necessary functions from user32.dll
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value > 0 && progressBar1.Value < 100) // If the upload is in progress
            {
                var res = MessageBox.Show("An upload is in progress. Are you sure you want to quit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    CancelUpload(); 
                    Close();
                }
                else rtbConsole.Text = "The upload continued";
            }
            else
            {
                Close(); // Close directly if no upload is happening
            }
        }

        private void CancelUpload()
        {
            cancelRequested = true;

            rtbConsole.Text = $"{DateTime.Now} Upload was canceled by the user at {progressBar1.Value}% completion.";
        }

        private void bufferSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null) // Check if upload is in progress
            {
                MessageBox.Show("You cannot change the buffer size while an upload is in progress.", "Buffer Size Change", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method without changing the buffer size
            }
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
            foreach (ToolStripMenuItem item in clickedItem.GetCurrentParent().Items)
            {
                if (item == clickedItem) 
                {
                    clickedItem.Checked = true;
                    switch (clickedItem.Text)
                    {
                        case "512 KB": buffersize = 512 * 1024; break;
                        case "2 MB": buffersize = 2 * 1024 * 1024; break;
                        case "4 MB": buffersize = 4 * 1024 * 1024; break;
                        case "8 MB": buffersize = 8 * 1024 * 1024; break;
                        default: buffersize = 1024 * 1024; break; //Default 1 MB
                    }
                    continue; 
                }
                item.Checked = false;
            }
        }

        private void consoleOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rtbConsole.Visible)
            {
                rtbConsole.Show();
                consoleOutputToolStripMenuItem.Text = "Hide Console";
            }
            else
            {
                rtbConsole.Hide(); 
                consoleOutputToolStripMenuItem.Text = "Show Console";
            }
        }
        private void bufferSizeToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {
            string buffer_tooltip_text = "Choose a buffer size:\n- Larger sizes (e.g., 4 MB, 8 MB) require a faster and more stable network.\n- Smaller sizes (e.g., 512 KB, 1 MB) are better for low-bandwidth or unstable connections.";
            toolTip1.Show(buffer_tooltip_text, this, PointToClient(MousePosition).X, PointToClient(MousePosition).Y);
        }

        private void uploadButton_MouseEnter(object sender, EventArgs e)
        {
            if (uploadButton.Enabled) toolTip1.Show("Start file upload", this, PointToClient(MousePosition).X, PointToClient(MousePosition).Y);
        }

        private void uploadButton_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void MaxRetrytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
            foreach (ToolStripMenuItem item in clickedItem.GetCurrentParent().Items)
            {
                if (item == clickedItem)
                {
                    clickedItem.Checked = true;
                    switch (clickedItem.Text)
                    {
                        case "20": maxRetries = 20; break;
                        case "50": maxRetries = 50; break;
                        case "150": maxRetries = 150; break;
                        case "300": maxRetries = 300;  break;
                        default: maxRetries = -1; break; //Default Infinity
                    }
                    continue;
                }
                item.Checked = false;
            }
        }
    }
}

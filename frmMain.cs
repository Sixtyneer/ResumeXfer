﻿using ResumeXfer.Forms;
using ResumeXfer.Helpers;
using ResumeXfer.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private readonly IDraggable _draggable;

        public frmMain()
        {
            InitializeComponent();
            Coloring();
            menuStrip1.Renderer = new menuStripRender();
            _draggable = new DraggableHelper();
            _draggable.MoveingForm(this); // Makes the form draggable
        }
        private void Coloring() 
        {
            panelMenu.BackColor = BackColor;
            menuStrip1.BackColor = BackColor;

            // Set other properties (like text and font)
            browseLocalFileButton.Font = new Font("Reem Kufi", 10F, FontStyle.Bold, GraphicsUnit.Point);
            browseRemoteFolderButton.Font = new Font("Reem Kufi", 10F, FontStyle.Bold, GraphicsUnit.Point);

            // Add hover effect
            browseLocalFileButton.MouseEnter += (sender, e) => {
                browseLocalFileButton.BackColor = Color.FromArgb(50, 120, 70); // Lighter green on hover
                browseLocalFileButton.FlatAppearance.BorderColor = Color.FromArgb(70, 150, 90); // Lighter green border on hover
            };
            browseLocalFileButton.MouseLeave += (sender, e) => {
                browseLocalFileButton.BackColor = Color.FromArgb(0, 191, 99); // Revert back to original dark green color
                browseLocalFileButton.FlatAppearance.BorderColor = Color.FromArgb(40, 100, 60); // Revert back to original border color
            };
            browseRemoteFolderButton.MouseEnter += (sender, e) => {
                browseRemoteFolderButton.BackColor = Color.FromArgb(50, 120, 70); // Lighter green on hover
                browseRemoteFolderButton.FlatAppearance.BorderColor = Color.FromArgb(70, 150, 90); // Lighter green border on hover
            };
            browseRemoteFolderButton.MouseLeave += (sender, e) => {
                browseRemoteFolderButton.BackColor = Color.FromArgb(0, 191, 99); // Revert back to original dark green color
                browseRemoteFolderButton.FlatAppearance.BorderColor = Color.FromArgb(40, 100, 60); // Revert back to original border color
            };
        }
        private void BrowseLocalFileButton_Click(object sender, EventArgs e)
        {
            using (var browseFileDialog = new frmBrowseFileDialog())
            {
                browseFileDialog.StartPosition = FormStartPosition.Manual;

                // Get the screen where the caller form is currently located
                Screen callerScreen = Screen.FromControl(this);

                int FormCenterX = Left + (Width / 2);
                int newFormWidth = 550;
                int newFormLeft = FormCenterX - (newFormWidth / 2);
                int newFormTop = Bottom;

                // Ensure the new form stays visible on the screen of the caller form
                int screenLeft = callerScreen.WorkingArea.Left;
                int screenWidth = callerScreen.WorkingArea.Width;

                if (newFormLeft < screenLeft) newFormLeft = screenLeft;
                if (newFormLeft + newFormWidth > screenLeft + screenWidth) newFormLeft = screenLeft + screenWidth - newFormWidth;

                browseFileDialog.Location = new Point(newFormLeft, newFormTop);

                if (browseFileDialog.ShowDialog() == DialogResult.OK)
                {
                    localFilePathTextBox.Text = browseFileDialog.SelectedFilePath;
                }
            }
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
            if (popupForm != null) popupForm.FadeOutPopup();

            localFilePath = localFilePathTextBox.Text;
            remoteFolderPath = remoteFilePathTextBox.Text;

            // If already uploading, handle pause/resume logic
            if (cancellationTokenSource != null && !isPaused)
            {
                Pause();
                return;
            }
            // If resuming
            if (isPaused)
            {
                Resume();
                return;
            }
            
            // If starting the upload for the first time
            if (ValidatePaths())
            {
                originalLocalFilePath = localFilePathTextBox.Text; // Store the original path
                string remoteFilePath = Path.Combine(remoteFolderPath, Path.GetFileName(localFilePath));
                uploadButton.BackgroundImage = Resources.Pause; // Change to pause button icon
                cancellationTokenSource = new CancellationTokenSource(); // Create the cancellation token
                await UploadFileWithResume(localFilePath, remoteFilePath, cancellationTokenSource.Token);
            }
        }
        private void Pause() // Pause the upload
        {
            isPaused = true;
            cancellationTokenSource.Cancel();
            uploadButton.BackgroundImage = Resources.Upload; // Change to resume button icon
            rtbConsole.Text = DateTime.Now + " Upload paused.";
        }
        
        private async void Resume() // Resume the upload
        {
            isPaused = false;
            uploadButton.BackgroundImage = Resources.Pause; // Change to pause button icon
            rtbConsole.Text = DateTime.Now + " Resuming upload.";
            localFilePath = localFilePathTextBox.Text;
            remoteFolderPath = remoteFilePathTextBox.Text;

            if (ValidatePaths())
            {
                string remoteFilePath = Path.Combine(remoteFolderPath, Path.GetFileName(localFilePath));
                cancellationTokenSource = new CancellationTokenSource(); // Create a new token for resuming
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
                frmNotification.ShowNotification("The local file path is invalid or the file does not exist.", "Invalid Path", false);
                uploadButton.Enabled = true;
                return false;
            }
            if (!isRemotePathValid)
            {
                frmNotification.ShowNotification("The remote folder path is invalid or the directory does not exist.", "Invalid Path", false);
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
                popupForm?.Hide();

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
                                if (speedKilobytes < 1024) speedLabel.Text = $"Upload speed: {speedKilobytes:F2} KB/s";
                                if (speedKilobytes >= 1024 && speedKilobytes < 1048576) speedLabel.Text = $"Upload speed: {speedKilobytes / 1024.0:F2} MB/s";
                                if (speedKilobytes >= 1048576) speedLabel.Text = $"Upload speed: {speedKilobytes / 1048576.0:F2} GB/s";
                            }));

                            progressLabel.Invoke((Action)(() =>
                            {
                                if (totalKilobytes < 15000) progressLabel.Text = $"Progress: {totalKilobytesUploaded} KB / {totalKilobytes} KB uploaded | ({Math.Round(totalKilobytesUploaded / totalKilobytes, 3) * 100})%";
                                if (totalKilobytes < 800000 && speedKilobytes >= 15000) progressLabel.Text = $"Progress: {totalKilobytesUploaded/1024.0:F2} MB / {totalKilobytes/1024.0:F2} MB uploaded | ({Math.Round(totalKilobytesUploaded / totalKilobytes, 3) * 100})%";
                                if (totalKilobytes >= 800000) progressLabel.Text = $"Progress: {totalKilobytesUploaded/1024.0:F2} MB / {totalKilobytes/ 1048576.0:F2} GB uploaded | ({Math.Round(totalKilobytesUploaded / totalKilobytes, 3) * 100})%";
                            }));

                        }
                        catch (IOException)
                        {
                            if (!(maxRetries == -1))
                            {
                                retryCount++;
                                if (retryCount >= maxRetries)
                                {
                                    frmNotification.ShowNotification($"Upload failed after {maxRetries} attempts..", "Upload Error", false);
                                    break;
                                }
                            }
                            
                            // Handle disconnection
                            rtbConsole.Text = DateTime.Now + " Connection lost. Retrying... (IO Exception)" + (maxRetries == -1 ? "" : $"({retryCount}/{maxRetries})");
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
                if (!cancelRequested && !cancellationToken.IsCancellationRequested)
                {
                    rtbConsole.Text = $"{DateTime.Now} Upload of {Path.GetFileName(localFilePath)} completed successfully.";
                    if (isNotificationEnabled) frmNotification.ShowNotification("Upload completed successfully.", "Information", false);
                }
            }
            catch (Exception ex)
            {
                rtbConsole.Text = DateTime.Now + " Error: " + ex.Message;
            }
            finally
            {
                ToggleUIControls(true);
                uploadButton.BackgroundImage = Resources.Upload; // Reset button to default
                cancelRequested = false; // Reset cancel flag for future uploads
                if (cancellationTokenSource != null) cancellationTokenSource = null; // Reset after the task is completed
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
                    uploadButton.BackgroundImage = Resources.Upload;
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
                uploadButton.BackgroundImage = Resources.Upload;
                isPaused = false; // Reset pause state
            }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value > 0 && progressBar1.Value < 100) // If the upload is in progress
            {
                if (!isPaused) Pause();
                var res = new frmNotification("An upload is in progress. Are you sure you want to quit?", "Confirm Exit", true).ShowDialog();
                if (res == DialogResult.Yes) Close();
            }
            else Close(); // Close directly if no upload is happening
        }
        private void bufferSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null) // Check if upload is in progress
            {
                frmNotification.ShowNotification("You cannot change the buffer size while an upload is in progress.", "Buffer Size Change", false);
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
                        case "1 KB": buffersize = 1024; break;
                        case "4 KB": buffersize = 4 * 1024; break;
                        case "8 KB": buffersize = 8 * 1024; break;
                        case "32 KB": buffersize = 32 * 1024; break;
                        case "128 KB": buffersize = 128 * 1024; break;
                        case "256 KB": buffersize = 256 * 1024; break;
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
        frmPopup popupForm = new frmPopup();
        private void uploadButton_MouseEnter(object sender, EventArgs e)
        {
            if (uploadButton.Enabled)
            {
                string message = (cancellationTokenSource != null && !isPaused)  ? "Pause file upload" : "Start file upload";

                popupForm.SetText(message);

                Point buttonPosition = uploadButton.PointToScreen(Point.Empty);
                popupForm.StartPosition = FormStartPosition.Manual;
                popupForm.Location = new Point(buttonPosition.X, buttonPosition.Y + uploadButton.Height);

                popupForm.FadeInPopup();
            }
        }

        private void uploadButton_MouseLeave(object sender, EventArgs e) => popupForm.FadeOutPopup();

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

        private void uploadButton_MouseDown(object sender, MouseEventArgs e)
        {
            // Move the button down and right by 2 pixels
            uploadButton.Location = new Point(uploadButton.Location.X + 2, uploadButton.Location.Y + 2);
        }

        private void uploadButton_MouseUp(object sender, MouseEventArgs e)
        {
            // Move the button down and right by 2 pixels
            uploadButton.Location = new Point(uploadButton.Location.X - 2, uploadButton.Location.Y - 2);
        }
        bool isNotificationEnabled = false;
        private void uploadCompletionNotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
            foreach (ToolStripMenuItem item in clickedItem.GetCurrentParent().Items)
            {
                if (item == clickedItem)
                {
                    clickedItem.Checked = true;
                    isNotificationEnabled = clickedItem.Text == "Enabled";
                }
                else item.Checked = false;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAboutBox().ShowAboutBox();
        }

        private void instructionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmInstructions().ShowInstructions();
        }
    }
}

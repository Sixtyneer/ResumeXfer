using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeXfer
{
    public partial class frmMain : Form
    {
        int buffersize = 1024 * 1024;
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
        

        private async void UploadButton_Click(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
            string localFilePath = localFilePathTextBox.Text;
            string remoteFolderPath = remoteFilePathTextBox.Text;

            if (ValidatePaths())
            {
                string remoteFilePath = Path.Combine(remoteFolderPath, Path.GetFileName(localFilePath));
                await UploadFileWithResume(localFilePath, remoteFilePath);
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

        private async Task UploadFileWithResume(string localFilePath, string remoteFilePath)
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

                    progressBar1.Visible = true;
                    speedLabel.Visible = true;
                    progressLabel.Visible = true;
                    browseLocalFileButton.Enabled = false;
                    browseRemoteFolderButton.Enabled = false;
                    uploadButton.Enabled = false;
                    localFilePathTextBox.Visible = true;
                    remoteFilePathTextBox.Visible = true;

                    while (totalBytesUploaded < fileLength)
                    {
                        try
                        {
                            bytesRead = await localStream.ReadAsync(buffer, 0, buffer.Length);
                            if (bytesRead == 0) break;

                            using (FileStream remoteStream = new FileStream(remoteFilePath, FileMode.Append, FileAccess.Write, FileShare.None))
                            {
                                await remoteStream.WriteAsync(buffer, 0, bytesRead);
                            }

                            totalBytesUploaded += bytesRead;

                            // Calculate speed (in KB/s)
                            double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
                            double speed = totalBytesUploaded / elapsedSeconds / 1024;

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
                                speedLabel.Text = $"{speed:F2} KB/s";
                            }));

                            progressLabel.Invoke((Action)(() =>
                            {
                                progressLabel.Text = $"{totalKilobytesUploaded:F2} KB / {totalKilobytes:F2} KB uploaded";
                            }));

                        }
                        catch (IOException)
                        {
                            // Handle disconnection
                            rtbConsole.Text = DateTime.Now + " Connection lost. Retrying... (IO Exception)";
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
                }
                rtbConsole.Text = DateTime.Now + " Upload completed successfully.";
            }
            catch (Exception ex)
            {
                rtbConsole.Text = DateTime.Now + " Error: " + ex.Message;
            }
            finally
            {
                progressBar1.Visible = false;
                speedLabel.Visible = false;
                progressLabel.Visible = false;
                browseLocalFileButton.Enabled = true;
                browseRemoteFolderButton.Enabled = true;
                uploadButton.Enabled = true;
                localFilePathTextBox.Visible = false;
                remoteFilePathTextBox.Visible = false;
            }
        }
        private void localFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateUploadButton();
        }

        private void remoteFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateUploadButton();
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
            //wip
            //Need to handle the uploading process when the user qiut the application!
            var res = MessageBox.Show("Are you sure want to Quit the application?", "Upload is in progress!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                MessageBox.Show("Ok, cool.");
            }
        }


        private void bufferSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void bufferSizeToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void bufferSizeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void bufferSizeToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {
            string buffer_tooltip_text = "Choose a buffer size:\n- Larger sizes (e.g., 4 MB, 8 MB) require a faster and more stable network.\n- Smaller sizes (e.g., 512 KB, 1 MB) are better for low-bandwidth or unstable connections.";
            toolTip1.Show(buffer_tooltip_text, this, PointToClient(MousePosition).X, PointToClient(MousePosition).Y);
        }

        private void uploadButton_MouseEnter(object sender, EventArgs e)
        {
            if (uploadButton.Enabled)
                toolTip1.Show("Click to start upload.", this, PointToClient(MousePosition).X, PointToClient(MousePosition).Y);
        }

        private void uploadButton_MouseLeave(object sender, EventArgs e)
        {
            if (uploadButton.Enabled)
                toolTip1.Hide(this);
        }
    }
}

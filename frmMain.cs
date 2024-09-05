using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeXfer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            // Populate the ComboBox with buffer size options in KB
            toolStripCB_buffersize.Items.AddRange(new object[] {
                "512 KB",
                "1 MB",
                "2 MB",
                "4 MB",
                "8 MB"
            });
            toolStripCB_buffersize.SelectedIndex = 1; // Default to "1 MB"
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
        private int GetBufferSize() 
        { 
            int bufferSize = 1024 * 1024; // Default 1MB;
            string selectedBufferSize = toolStripCB_buffersize.SelectedItem.ToString();

            switch (selectedBufferSize)
            {
                case "512 KB":
                    bufferSize = 512 * 1024;
                    break;
                case "1 MB":
                    bufferSize = 1024 * 1024;
                    break;
                case "2 MB":
                    bufferSize = 2 * 1024 * 1024;
                    break;
                case "4 MB":
                    bufferSize = 4 * 1024 * 1024;
                    break;
                case "8 MB":
                    bufferSize = 8 * 1024 * 1024;
                    break;
            }
            return bufferSize;
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
                    byte[] buffer = new byte[GetBufferSize()]; 
                    int bytesRead;
                    Stopwatch stopwatch = Stopwatch.StartNew();

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
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripCB_buffersize_MouseEnter(object sender, EventArgs e)
        {
            string buffer_tooltip_text = "Choose a buffer size:\n- Larger sizes (e.g., 4 MB, 8 MB) require a faster and more stable network.\n- Smaller sizes (e.g., 512 KB, 1 MB) are better for low-bandwidth or unstable connections.";
            toolTip1.Show(buffer_tooltip_text, this,PointToClient(MousePosition).X,PointToClient(MousePosition).Y);
        }

        private void toolStripCB_buffersize_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }
    }
}

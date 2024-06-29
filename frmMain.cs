using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UploaderWithResume
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void browseLocalFileButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog()) 
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    localFilePathTextBox.Text = openFileDialog.FileName;
        }

        private void browseRemoteFolderButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    remoteFilePathTextBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private async void uploadButton_Click(object sender, EventArgs e)
        {
            string localFilePath = localFilePathTextBox.Text;
            string remoteFolderPath = remoteFilePathTextBox.Text;
            string remoteFilePath = Path.Combine(remoteFolderPath, Path.GetFileName(localFilePath));

            await UploadFileWithResume(localFilePath, remoteFilePath);
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

                    byte[] buffer = new byte[1024 * 1024]; // 1MB chunk size
                    int bytesRead;
                    Stopwatch stopwatch = Stopwatch.StartNew();

                    while (totalBytesUploaded < fileLength)
                    {
                        try
                        {
                            bytesRead = await localStream.ReadAsync(buffer, 0, buffer.Length);
                            if (bytesRead == 0)
                                break;

                            using (FileStream remoteStream = new FileStream(remoteFilePath, FileMode.Append, FileAccess.Write, FileShare.None))
                            {
                                await remoteStream.WriteAsync(buffer, 0, bytesRead);
                            }

                            totalBytesUploaded += bytesRead;

                            // Calculate speed
                            double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
                            double speed = totalBytesUploaded / elapsedSeconds / 1024; // Speed in KB/s

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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeXfer.Forms
{
    public partial class frmInstructions : Form
    {
        public frmInstructions()
        {
            InitializeComponent();
            rtbContent.Text = "\nWelcome to the ResumeXfer guide! \n\n This application lets you upload files with resume capabilities, manage upload speeds, and monitor upload progress. \n * Follow the instructions below to learn how to use each feature. \n * Pick a step with the buttons on the left.";
        }

        private void buttonStep_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            labelHeader.Text = button.Text;
            string[] texts = new string[4];
            if (button.Name == "buttonStep1")
            {
                texts[0] = "1. Choose a Local File\n\n";
                texts[1] = " * Click the Browse Local File button to open a file explorer.\n * Select the file you want to upload. Once selected, the file path will appear in the Local File Path box.\n\n";
                texts[2] = "2. Choose a Remote Folder\n\n";
                texts[3] = " * Click the Select Remote Folder button to open a folder browser.\n * Select the destination folder on your remote storage. The folder path will appear in the Remote Folder Path box.";
            }
            else if (button.Name == "buttonStep2")
            {
                texts[0] = "1. Begin Upload\n\n";
                texts[1] = " * Once the file and folder paths are set, click Play (Upload) button.\n * During the upload, you’ll see progress, speed, and estimated time in the console.\n\n";
                texts[2] = "2. Pause & Resume\n\n";
                texts[3] = " * Pause: If you need to pause, click the upload button again. The button icon will switch to indicate the pause status.\n * Resume: Click the upload button again to resume.";
            }
            else if (button.Name == "buttonStep3")
            {
                texts[0] = "1. Progress Bar\n\n";
                texts[1] = " * The progress bar shows the percentage completion of the upload.\n\n";
                texts[2] = "2. Speed and Progress Labels\n\n";
                texts[3] = " * Track the upload speed and the total uploaded amount in real-time.\n * Speed units automatically adjust to KB/s, MB/s, or GB/s based on the upload rate.";
            }
            else if (button.Name == "buttonStep4")
            {
                texts[0] = "1. Buffer Size Adjustments\n\n";
                texts[1] = " * Access the Buffer Size option in the menu to set buffer sizes (e.g., 512 KB, 1 MB, 2 MB, etc.). This can help optimize upload performance for different network conditions.\n * Larger sizes (e.g., 4 MB, 8 MB) require a faster and more stable network.\n * Smaller sizes (e.g., 512 KB, 1 MB) are better for low-bandwidth or unstable connections.\n\n";
                texts[2] = "2. Toggle Console Output\n\n";
                texts[3] = " * Use the Console Output option to show or hide the console. This console displays detailed upload messages and status updates.";
            }
            else if (button.Name == "buttonStep5")
            {
                texts[0] = "Once the upload finishes\n\n";
                texts[1] = " * A completion message displays. Enable notifications in Settings if you'd like an on-screen alert when an upload completes.\n";
                texts[2] = " ";
                texts[3] = " ";
            }
            else if (button.Name == "buttonTips")
            {
                texts[0] = "1. Resuming Original File Path:\n\n";
                texts[1] = " * If you pause an upload and change the file path back to the original file, you can resume the upload without restarting.\n\n";
                texts[2] = "2. Connection Issues:\n\n";
                texts[3] = " * If an upload fails due to connection loss, the app automatically retries (infinite retries by default).\nExiting: If you attempt to exit while an upload is in progress, a confirmation message will appear. ";
            }

            rtbContent.Clear(); // Clear any previous text

            // Step title 1
            rtbContent.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
            rtbContent.AppendText(texts[0]);

            // Instruction text 1
            rtbContent.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
            rtbContent.SelectionColor = Color.DarkGray;
            rtbContent.AppendText(texts[1]);

            // Step title 2
            rtbContent.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
            rtbContent.AppendText(texts[2]);

            // Instruction text 2
            rtbContent.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
            rtbContent.SelectionColor = Color.DarkGray;
            rtbContent.AppendText(texts[3]);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        // Constants to handle the dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        // Import necessary functions from user32.dll
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Simple_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

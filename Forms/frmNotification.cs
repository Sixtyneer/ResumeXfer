using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ResumeXfer.Forms
{
    public partial class frmNotification : Form
    {
        bool buttons = true;
        public frmNotification(string message, string headermessage, bool _buttons)
        {
            InitializeComponent();
            rtbMessage.Text = message;
            lblHeader.Text = headermessage;
            buttons = _buttons;
            if (!buttons)
            {
                btnYes.Visible = false;
                btnNo.Visible = false;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
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
        private void panelMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        } 
    }
}

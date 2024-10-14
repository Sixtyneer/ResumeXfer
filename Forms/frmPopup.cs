using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeXfer.Forms
{
    public partial class frmPopup : Form
    {
        public frmPopup()
        {
            InitializeComponent();
            Opacity = 0;
        }
        public void SetText(string message) 
        {
            using (Graphics g = CreateGraphics())
            {
                // Measure the size of the text
                SizeF textSize = g.MeasureString(message, lblPopup.Font);

                // Add padding to the measured size to make the form larger than the text
                int paddingWidth = 20; // Add some padding around the text
                int paddingHeight = 10;

                // Resize the form based on the text size
                Width = (int)textSize.Width + paddingWidth;
                Height = (int)textSize.Height + paddingHeight;

                // Optionally adjust the label size to fit the form perfectly
                lblPopup.Width = Width - paddingWidth;
                lblPopup.Height = Height - paddingHeight;
            }
            lblPopup.Text = message;
        }

        private const double fadeStep = 0.05;

        private void fadeInTimer_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1) Opacity += fadeStep; // Increase opacity gradually
            else fadeInTimer.Stop(); // Stop the timer when fully visible
        }
        public void FadeInPopup()
        {
            Opacity = 0; // Reset opacity to 0 before showing
            Show(); // Display the form
            fadeInTimer.Start(); // Start the fade-in effect
        }
    }
}

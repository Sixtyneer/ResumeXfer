using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ResumeXfer.Helpers
{
    public class DraggableHelper : IDraggable
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // List of control types that should allow dragging
        private readonly Type[] _draggableTypes = { typeof(PictureBox), typeof(Panel), typeof(MenuStrip), typeof(Label), typeof(RichTextBox) };

        public void MoveingForm(Control control)
        {
            foreach (Control child in control.Controls)
            {
                if (IsControlDraggable(child))
                {
                    AttachDrag(child);
                }

                // Recursively call the method to handle any child controls of the current child
                if (child.HasChildren)
                {
                    MoveingForm(child);
                }
            }
        }

        public void AttachDrag(Control control)
        {
            // Attach MouseDown event to initiate dragging
            control.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Ensure the control's parent form is being dragged
                    ReleaseCapture();
                    SendMessage(control.FindForm().Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };
        }

        private bool IsControlDraggable(Control control)
        {
            // Check if the control is of a type that should allow dragging
            foreach (var type in _draggableTypes)
            {
                if (control.GetType() == type)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
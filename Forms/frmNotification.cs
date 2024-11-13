﻿using ResumeXfer.Helpers;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ResumeXfer.Forms
{
    public partial class frmNotification : Form
    {
        bool buttons = true;
        private readonly IDraggable _draggable;
        public frmNotification(string message, string headermessage, bool _buttons)
        {
            InitializeComponent();
            rtbMessage.Text = Environment.NewLine + message;
            rtbMessage.SelectAll();
            rtbMessage.SelectionAlignment = HorizontalAlignment.Center;
            lblHeader.Text = headermessage;
            buttons = _buttons;
            if (!buttons)
            {
                btnYes.Visible = false;
                btnNo.Visible = false;
            }
            _draggable = new DraggableHelper();
            _draggable.MoveingForm(this); // Makes the form draggable
        }

        // Static instance to track the currently open form
        private static frmNotification _openInstance;
        // Method to show the form, managing the static instance
        public static void ShowNotification(string message, string headermessage, bool buttons = true)
        {
            // Close and dispose of any currently open instance
            if (_openInstance != null)
            {
                _openInstance.Close();
                _openInstance.Dispose();
            }

            // Create and display a new instance
            _openInstance = new frmNotification(message, headermessage, buttons);
            _openInstance.Show();
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
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeXfer.Forms
{
    public partial class frmNotification : Form
    {
        public frmNotification(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

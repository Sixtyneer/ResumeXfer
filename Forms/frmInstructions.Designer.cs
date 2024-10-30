namespace ResumeXfer.Forms
{
    partial class frmInstructions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelFull = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.panelContentTop = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTips = new System.Windows.Forms.Button();
            this.buttonStep5 = new System.Windows.Forms.Button();
            this.buttonStep4 = new System.Windows.Forms.Button();
            this.buttonStep3 = new System.Windows.Forms.Button();
            this.buttonStep1 = new System.Windows.Forms.Button();
            this.buttonStep2 = new System.Windows.Forms.Button();
            this.panelFull.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelContentTop.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFull
            // 
            this.panelFull.BackColor = System.Drawing.Color.Transparent;
            this.panelFull.Controls.Add(this.panelContent);
            this.panelFull.Controls.Add(this.panelMenu);
            this.panelFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFull.Location = new System.Drawing.Point(0, 0);
            this.panelFull.Margin = new System.Windows.Forms.Padding(10);
            this.panelFull.Name = "panelFull";
            this.panelFull.Size = new System.Drawing.Size(696, 373);
            this.panelFull.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.rtbContent);
            this.panelContent.Controls.Add(this.panelContentTop);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(208, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(488, 373);
            this.panelContent.TabIndex = 1;
            // 
            // rtbContent
            // 
            this.rtbContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContent.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContent.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbContent.ForeColor = System.Drawing.Color.Transparent;
            this.rtbContent.Location = new System.Drawing.Point(0, 78);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.ReadOnly = true;
            this.rtbContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbContent.Size = new System.Drawing.Size(488, 295);
            this.rtbContent.TabIndex = 2;
            this.rtbContent.Text = "";
            this.rtbContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Simple_MouseDown);
            // 
            // panelContentTop
            // 
            this.panelContentTop.Controls.Add(this.buttonClose);
            this.panelContentTop.Controls.Add(this.labelHeader);
            this.panelContentTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContentTop.ForeColor = System.Drawing.Color.White;
            this.panelContentTop.Location = new System.Drawing.Point(0, 0);
            this.panelContentTop.Name = "panelContentTop";
            this.panelContentTop.Size = new System.Drawing.Size(488, 78);
            this.panelContentTop.TabIndex = 1;
            this.panelContentTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Simple_MouseDown);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(442, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(43, 22);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Source Sans Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(6, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(369, 27);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "User Guide for ResumeXfer Application";
            this.labelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Simple_MouseDown);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.tableLayoutPanel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(208, 373);
            this.panelMenu.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonTips, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonStep5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonStep4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonStep3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonStep1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonStep2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(208, 373);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonTips
            // 
            this.buttonTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.buttonTips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTips.FlatAppearance.BorderSize = 0;
            this.buttonTips.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTips.ForeColor = System.Drawing.Color.White;
            this.buttonTips.Location = new System.Drawing.Point(3, 313);
            this.buttonTips.Name = "buttonTips";
            this.buttonTips.Size = new System.Drawing.Size(202, 57);
            this.buttonTips.TabIndex = 5;
            this.buttonTips.Text = "Tips and Notes";
            this.buttonTips.UseVisualStyleBackColor = false;
            this.buttonTips.Click += new System.EventHandler(this.buttonStep_Click);
            // 
            // buttonStep5
            // 
            this.buttonStep5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.buttonStep5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStep5.FlatAppearance.BorderSize = 0;
            this.buttonStep5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStep5.ForeColor = System.Drawing.Color.White;
            this.buttonStep5.Location = new System.Drawing.Point(3, 251);
            this.buttonStep5.Name = "buttonStep5";
            this.buttonStep5.Size = new System.Drawing.Size(202, 56);
            this.buttonStep5.TabIndex = 4;
            this.buttonStep5.Text = "Step 5: Upload Completion";
            this.buttonStep5.UseVisualStyleBackColor = false;
            this.buttonStep5.Click += new System.EventHandler(this.buttonStep_Click);
            // 
            // buttonStep4
            // 
            this.buttonStep4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.buttonStep4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStep4.FlatAppearance.BorderSize = 0;
            this.buttonStep4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStep4.ForeColor = System.Drawing.Color.White;
            this.buttonStep4.Location = new System.Drawing.Point(3, 189);
            this.buttonStep4.Name = "buttonStep4";
            this.buttonStep4.Size = new System.Drawing.Size(202, 56);
            this.buttonStep4.TabIndex = 3;
            this.buttonStep4.Text = "Step 4: Additional Features";
            this.buttonStep4.UseVisualStyleBackColor = false;
            this.buttonStep4.Click += new System.EventHandler(this.buttonStep_Click);
            // 
            // buttonStep3
            // 
            this.buttonStep3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.buttonStep3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStep3.FlatAppearance.BorderSize = 0;
            this.buttonStep3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStep3.ForeColor = System.Drawing.Color.White;
            this.buttonStep3.Location = new System.Drawing.Point(3, 127);
            this.buttonStep3.Name = "buttonStep3";
            this.buttonStep3.Size = new System.Drawing.Size(202, 56);
            this.buttonStep3.TabIndex = 2;
            this.buttonStep3.Text = "Step 3: Monitoring the Upload";
            this.buttonStep3.UseVisualStyleBackColor = false;
            this.buttonStep3.Click += new System.EventHandler(this.buttonStep_Click);
            // 
            // buttonStep1
            // 
            this.buttonStep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.buttonStep1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStep1.FlatAppearance.BorderSize = 0;
            this.buttonStep1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStep1.ForeColor = System.Drawing.Color.White;
            this.buttonStep1.Location = new System.Drawing.Point(3, 3);
            this.buttonStep1.Name = "buttonStep1";
            this.buttonStep1.Size = new System.Drawing.Size(202, 56);
            this.buttonStep1.TabIndex = 0;
            this.buttonStep1.Text = "Step 1: Selecting Files and Folders";
            this.buttonStep1.UseVisualStyleBackColor = false;
            this.buttonStep1.Click += new System.EventHandler(this.buttonStep_Click);
            // 
            // buttonStep2
            // 
            this.buttonStep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.buttonStep2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStep2.FlatAppearance.BorderSize = 0;
            this.buttonStep2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStep2.ForeColor = System.Drawing.Color.White;
            this.buttonStep2.Location = new System.Drawing.Point(3, 65);
            this.buttonStep2.Name = "buttonStep2";
            this.buttonStep2.Size = new System.Drawing.Size(202, 56);
            this.buttonStep2.TabIndex = 1;
            this.buttonStep2.Text = "Step 2: Starting the Upload";
            this.buttonStep2.UseVisualStyleBackColor = false;
            this.buttonStep2.Click += new System.EventHandler(this.buttonStep_Click);
            // 
            // frmInstructions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(696, 373);
            this.Controls.Add(this.panelFull);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInstructions";
            this.Text = "frmInstructions";
            this.panelFull.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContentTop.ResumeLayout(false);
            this.panelContentTop.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFull;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonStep1;
        private System.Windows.Forms.Button buttonStep2;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Button buttonTips;
        private System.Windows.Forms.Button buttonStep5;
        private System.Windows.Forms.Button buttonStep4;
        private System.Windows.Forms.Button buttonStep3;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Panel panelContentTop;
        private System.Windows.Forms.Button buttonClose;
    }
}
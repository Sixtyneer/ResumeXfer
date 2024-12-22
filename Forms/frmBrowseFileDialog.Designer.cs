namespace ResumeXfer.Forms
{
    partial class frmBrowseFileDialog
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelTreeView = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panelListView = new System.Windows.Forms.Panel();
            this.FilelistView = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelFull.SuspendLayout();
            this.panelTreeView.SuspendLayout();
            this.panelListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFull
            // 
            this.panelFull.Controls.Add(this.button2);
            this.panelFull.Controls.Add(this.button1);
            this.panelFull.Controls.Add(this.panelTreeView);
            this.panelFull.Controls.Add(this.panelListView);
            this.panelFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFull.Location = new System.Drawing.Point(0, 0);
            this.panelFull.Name = "panelFull";
            this.panelFull.Size = new System.Drawing.Size(805, 450);
            this.panelFull.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(718, 418);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(637, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelTreeView
            // 
            this.panelTreeView.Controls.Add(this.treeView1);
            this.panelTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTreeView.Location = new System.Drawing.Point(0, 0);
            this.panelTreeView.Name = "panelTreeView";
            this.panelTreeView.Size = new System.Drawing.Size(168, 450);
            this.panelTreeView.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Reem Kufi", 9.75F);
            this.treeView1.ForeColor = System.Drawing.Color.White;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(202, 444);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // panelListView
            // 
            this.panelListView.AutoScroll = true;
            this.panelListView.Controls.Add(this.FilelistView);
            this.panelListView.Location = new System.Drawing.Point(211, 12);
            this.panelListView.Name = "panelListView";
            this.panelListView.Size = new System.Drawing.Size(550, 400);
            this.panelListView.TabIndex = 0;
            // 
            // FilelistView
            // 
            this.FilelistView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.FilelistView.AllowColumnReorder = true;
            this.FilelistView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FilelistView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FilelistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.FileSize,
            this.FileType});
            this.FilelistView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilelistView.Font = new System.Drawing.Font("Reem Kufi", 9.75F);
            this.FilelistView.ForeColor = System.Drawing.Color.White;
            this.FilelistView.FullRowSelect = true;
            this.FilelistView.HideSelection = false;
            this.FilelistView.HoverSelection = true;
            this.FilelistView.LabelWrap = false;
            this.FilelistView.Location = new System.Drawing.Point(0, 0);
            this.FilelistView.Margin = new System.Windows.Forms.Padding(0);
            this.FilelistView.MultiSelect = false;
            this.FilelistView.Name = "FilelistView";
            this.FilelistView.OwnerDraw = true;
            this.FilelistView.Size = new System.Drawing.Size(550, 400);
            this.FilelistView.TabIndex = 0;
            this.FilelistView.UseCompatibleStateImageBehavior = false;
            this.FilelistView.View = System.Windows.Forms.View.Details;
            this.FilelistView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.FilelistView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.FilelistView_ColumnWidthChanging);
            this.FilelistView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.FilelistView_DrawColumnHeader);
            this.FilelistView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.FilelistView_DrawSubItem);
            this.FilelistView.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.FilelistView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FilelistView_MouseMove);
            // 
            // FileName
            // 
            this.FileName.Text = "File Name";
            // 
            // FileSize
            // 
            this.FileSize.Text = "Size";
            // 
            // FileType
            // 
            this.FileType.Text = "Type";
            // 
            // frmBrowseFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(805, 450);
            this.Controls.Add(this.panelFull);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBrowseFileDialog";
            this.Text = "frmBrowseFileDialog";
            this.Load += new System.EventHandler(this.frmBrowseFileDialog_Load);
            this.panelFull.ResumeLayout(false);
            this.panelTreeView.ResumeLayout(false);
            this.panelListView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFull;
        private System.Windows.Forms.Panel panelTreeView;
        private System.Windows.Forms.Panel panelListView;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView FilelistView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader FileSize;
        private System.Windows.Forms.ColumnHeader FileType;
    }
}
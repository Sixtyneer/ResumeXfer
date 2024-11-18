using ResumeXfer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SortOrder = System.Windows.Forms.SortOrder;

namespace ResumeXfer.Forms
{
    public partial class frmBrowseFileDialog : Form
    {
        public string SelectedFilePath { get; private set; }
        private readonly IDraggable _draggable;
        private readonly int mega = (int)Math.Pow(1024, 2);
        private readonly int giga = (int)Math.Pow(1024, 3);
        private readonly long exa = (long)Math.Pow(1024, 4);
        public frmBrowseFileDialog()
        {
            InitializeComponent(); 
            _draggable = new DraggableHelper();
            _draggable.MoveingForm(this);
        }

        private void frmBrowseFileDialog_Load(object sender, EventArgs e)
        {
            TreeNode rootNode = null;
            foreach (var drive in DriveInfo.GetDrives().Where(d => d.IsReady))
            {
                rootNode = new TreeNode(drive.Name) { Tag = drive.Name };
                rootNode.Nodes.Add("...");
                treeView1.Nodes.Add(rootNode);
            }
            int totalWidth = FilelistView.ClientSize.Width;

            FilelistView.Columns[0].Width = (int)(totalWidth * 0.64); // 60% for the FileName column
            FilelistView.Columns[1].Width = (int)(totalWidth * 0.18); // 20% for the Size column
            FilelistView.Columns[2].Width = (int)(totalWidth * 0.18); // 20% for the Type column
            vScrollBar1.Width = 2;
            vScrollBar1.BackColor = Color.Gray;
            vScrollBar1.ForeColor = Color.Black;
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes.Count == 1)
            {
                e.Node.Nodes.Clear();
                string path = e.Node.Tag.ToString();
                try
                {
                    string[] dirs = Directory.GetDirectories(path);
                    foreach (var dir in dirs)
                    {
                        TreeNode node = new TreeNode(Path.GetFileName(dir)) { Tag = dir };
                        node.Nodes.Add("..."); 
                        e.Node.Nodes.Add(node);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    frmNotification.ShowNotification("Unauthorized Access", "Error", false);
                }
                catch(Exception ex) { frmNotification.ShowNotification(ex.Message, "Error", false); }
            }
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            FilelistView.Items.Clear();
            string path = e.Node.Tag.ToString();
            try
            {
                // Get files in the selected directory
                string[] files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    ListViewItem item = new ListViewItem(fi.Name);
                    item.SubItems.Add(CalculateFileSize(fi.Length));
                    item.SubItems.Add(fi.Extension);
                    item.Tag = fi.FullName;
                    FilelistView.Items.Add(item);
                }
            }
            catch (UnauthorizedAccessException)
            {
                frmNotification.ShowNotification("Unauthorized Access", "Error", false);
            }
            catch (Exception ex) { frmNotification.ShowNotification(ex.Message, "Error", false); }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FilelistView.SelectedItems.Count > 0)
            {
                SelectedFilePath = FilelistView.SelectedItems[0].Tag.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private string CalculateFileSize(double fileSize = 0.0) 
        {
            if (fileSize <= 1024)  
                return fileSize.ToString() + " B";
            if (fileSize <= mega)  
                return Math.Round(fileSize / 1024, 2).ToString() + " KB";
            if (fileSize <= giga)
                return Math.Round(fileSize / mega, 2).ToString() + " MB";
            if (fileSize <= exa)
                return Math.Round(fileSize / giga, 2).ToString() + " GB";
            else 
                return Math.Round(fileSize / exa, 2).ToString() + " EB";
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FilelistView.Items.Clear();
            string path = e.Node.Tag.ToString();
            try
            {
                string[] files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    ListViewItem item = new ListViewItem(fi.Name);
                    item.SubItems.Add(CalculateFileSize(fi.Length));
                    item.SubItems.Add(fi.Extension);
                    item.Tag = fi.FullName;
                    FilelistView.Items.Add(item);
                }
                
            }
            catch (UnauthorizedAccessException)
            {
                frmNotification.ShowNotification("Unauthorized Access", "Error", false);
            }
            catch (Exception ex) 
            {
                frmNotification.ShowNotification(ex.Message, "Error", false); 
            }
        }
       private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (FilelistView.SelectedItems.Count > 0)
            {
                SelectedFilePath = FilelistView.SelectedItems[0].Tag.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private SortOrder _sortOrder = SortOrder.Ascending;
        private int _sortColumn = -1;
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                // Determine whether the clicked column is already the column that is being sorted.
                if (e.Column == _sortColumn)
                {
                    // Toggle the sorting order
                    _sortOrder = _sortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    _sortColumn = e.Column;
                    _sortOrder = SortOrder.Ascending;
                }

                // Perform the sort with the new column and order.
                FilelistView.ListViewItemSorter = new ListViewColumnSorter(e.Column, _sortOrder);
                FilelistView.Sort();
            }
            catch (Exception ex)
            {
               frmNotification.ShowNotification(ex.Message, "Error", false);
            }
            
        }

        private void FilelistView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush headerBrush = new SolidBrush(Color.FromArgb(20, 20, 20)))
            {
                e.Graphics.FillRectangle(headerBrush, e.Bounds);

                TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.White, flags);
            }
            using (Pen borderPen = new Pen(Color.Gray, 2)) // Adjust color and thickness as needed
            {
                e.Graphics.DrawLine(borderPen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            }

            e.DrawDefault = false;
        }

        private void FilelistView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Set default background color
            Brush backgroundBrush = new SolidBrush(Color.FromArgb(20, 20, 20));
            Brush textBrush = Brushes.White;
            if (_hoveredItem == e.Item)
            {
                backgroundBrush = Brushes.Gray; // Lighter color for hover effect
            }
            // Draw the background
            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            e.Graphics.DrawString(e.SubItem.Text, e.Item.Font, textBrush, e.Bounds);
        }
        private ListViewItem _hoveredItem;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }
        private void FilelistView_MouseMove(object sender, MouseEventArgs e)
        {
            var item = FilelistView.GetItemAt(e.X, e.Y);

            // Redraw only when the hovered item changes
            if (_hoveredItem != item)
            {
                // Invalidate only the old and new hovered item to reduce flickering
                if (_hoveredItem != null)
                {
                    FilelistView.Invalidate(_hoveredItem.Bounds);
                }

                if (item != null)
                {
                    FilelistView.Invalidate(item.Bounds);
                }

                _hoveredItem = item;
            }
        }

        int remainingWidth = 0;
        private void FilelistView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
                e.Cancel = true;
                e.NewWidth = FilelistView.Columns[e.ColumnIndex].Width;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            panelListView.VerticalScroll.Value = vScrollBar1.Value;
            panelListView.PerformLayout();
        }
    }
}

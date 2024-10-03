using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeXfer
{
    internal class menuStripRender : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle itemRect = new Rectangle(Point.Empty, e.Item.Size);

            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), itemRect);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(20, 20, 20)), itemRect);
            }

            using (Pen borderPen = new Pen(Color.FromArgb(40, 40, 40)))
            {
                e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1));
            }
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(20, 20, 20)), e.AffectedBounds);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = Color.White;
            base.OnRenderItemText(e);
        }
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            Rectangle rect = new Rectangle(3, e.Item.ContentRectangle.Height / 2, e.Item.ContentRectangle.Width - 6, 1);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(20, 20, 20)), e.Item.Bounds);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), rect);
        }
    }
}

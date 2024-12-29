using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeXfer.Helpers
{
    public class ListViewColumnSorter : IComparer
    {
        private int col;
        private SortOrder order;

        public ListViewColumnSorter(int column, SortOrder sortOrder)
        {
            col = column;
            order = sortOrder;
        }

        public int Compare(object x, object y)
        {
            ListViewItem item1 = (ListViewItem)x;
            ListViewItem item2 = (ListViewItem)y;

            string value1 = item1.SubItems[col].Text;
            string value2 = item2.SubItems[col].Text;

            // Handle sorting by file size if the column index is 1 (assuming index 1 is file size)
            if (col == 1)
            {
                double size1 = ParseFileSize(value1);
                double size2 = ParseFileSize(value2);

                int result = size1.CompareTo(size2);
                return (order == SortOrder.Ascending) ? result : -result;
            }

            // Default string comparison for other columns
            int stringCompare = string.Compare(value1, value2);
            return (order == SortOrder.Ascending) ? stringCompare : -stringCompare;
        }

        private double ParseFileSize(string fileSizeString)
        {
            if (string.IsNullOrEmpty(fileSizeString))
                return 0;

            string[] parts = fileSizeString.Split(' ');
            if (parts.Length < 2)
                return 0;

            double value;
            if (!double.TryParse(parts[0], out value))
                return 0;

            switch (parts[1])
            {
                case "B":
                    return value;
                case "KB":
                    return value * 1024;
                case "MB":
                    return value * 1024 * 1024;
                case "GB":
                    return value * 1024 * 1024 * 1024;
                case "EB":
                    return value * 1024L * 1024L * 1024L * 1024L;
                default:
                    return 0;
            }
        }
    }
}

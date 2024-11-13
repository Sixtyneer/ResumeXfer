using ResumeXfer.Helpers;
using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ResumeXfer.Forms
{
    partial class frmAboutBox : Form
    {
        private readonly IDraggable _draggable;
        public frmAboutBox()
        {
            InitializeComponent();
            Text = string.Format("About {0}", AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = string.Format("Version {0}", AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;
            textBoxDescription.Text = AssemblyDescription;

            _draggable = new DraggableHelper();
            _draggable.MoveingForm(this); // Makes the form draggable
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e) => Close();

        frmPopup frmPopup = new frmPopup();
        private void textBoxDescription_DoubleClick(object sender, EventArgs e)
        {
            // Get the caret index at the click location
            int caretIndex = textBoxDescription.SelectionStart;

            // Determine the line number at the caret position
            int lineIndex = textBoxDescription.GetLineFromCharIndex(caretIndex);

            // Get the text of the specified line
            string lineText = textBoxDescription.Lines[lineIndex];
            if (lineText.Length != 0)
            {
                Clipboard.SetText(textBoxDescription.Text);

                frmPopup.SetText("Copied.");

                int posX = textBoxDescription.Left + 10;
                int posY = textBoxDescription.Bottom + 5;

                int popupWidth = frmPopup.Width;
                int popupHeight = frmPopup.Height;
                int formWidth = ClientSize.Width;
                int formHeight = ClientSize.Height;

                if (posX + popupWidth > formWidth)
                    posX = formWidth - popupWidth - 5; 

                if (posY + popupHeight > formHeight)
                    posY = textBoxDescription.Top - popupHeight - 5; 

                frmPopup.Location = new Point(Left + posX, Top + posY);

                frmPopup.FadeInPopup();
            }
        }

        private void textBoxDescription_MouseLeave(object sender, EventArgs e)
        {
            frmPopup.FadeOutPopup();
        }
    }
}

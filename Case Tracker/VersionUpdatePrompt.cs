#region

using System;
using System.Windows.Forms;

#endregion

namespace FogBugzCaseTracker
{
    public partial class VersionUpdatePrompt : Form
    {
        public VersionUpdatePrompt()
        {
            InitializeComponent();
        }

        public string WhatsNew
        {
            set { richWhatsNew.AppendText(value); }
        }

        public string CurrentVersion
        {
            set { lblCurrentVersion.Text = value; }
        }

        public string LatestVersion
        {
            set { lblNewVersion.Text = value; }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
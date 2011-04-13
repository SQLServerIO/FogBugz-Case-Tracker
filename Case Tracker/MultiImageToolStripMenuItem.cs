#region

using System.Drawing;
using System.Windows.Forms;

#endregion

namespace FogBugzCaseTracker
{
    public partial class MultiImageToolStripMenuItem : ToolStripMenuItem
    {
        public MultiImageToolStripMenuItem()
        {
            InitializeComponent();
        }

        public Image DisabledImage { get; set; }
        public Image EnabledImage { get; set; }

        public void Enable(bool value)
        {
            Image = value ? EnabledImage : DisabledImage;
            Enabled = value;
        }
    }
}
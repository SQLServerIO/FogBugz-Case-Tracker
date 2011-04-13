#region

using System.Drawing;
using System.Windows.Forms;

#endregion

namespace FogBugzCaseTracker
{
    public partial class MultiImageButton : Button
    {
        public MultiImageButton()
        {
            InitializeComponent();
        }

        public Image DisabledBackgroundImage { get; set; }
        public Image EnabledBackgroundImage { get; set; }

        public void Enable(bool value)
        {
            BackgroundImage = value ? EnabledBackgroundImage : DisabledBackgroundImage;
            Enabled = value;
        }
    }
}
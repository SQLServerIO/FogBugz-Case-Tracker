#region

using System;
using System.Windows.Forms;

#endregion

namespace FogBugzNet
{
    public partial class EstimateDialog : Form
    {
        public EstimateDialog()
        {
            InitializeComponent();
        }

        public String UserEstimate
        {
            get { return txtUserEstimate.Text; }
        }

        private void txtUserEstimate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter && txtUserEstimate.Text.Length != 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (e.KeyChar == (char) Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
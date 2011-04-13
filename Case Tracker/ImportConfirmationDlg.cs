#region

using System;
using System.Windows.Forms;
using FogBugzNet;

#endregion

namespace FogBugzCaseTracker
{
    public partial class ImportConfirmationDlg : Form
    {
        private readonly ImportAnalysis _analysis;

        public ImportConfirmationDlg(ImportAnalysis analysis)
        {
            _analysis = analysis;
            InitializeComponent();
        }

        private void DescribeChanges()
        {
            foreach (string s in _analysis.Describe())
            {
                lstChanges.Items.Add(s);
            }
        }

        private void ImportConfirmationDlg_Load(object sender, EventArgs e)
        {
            DescribeChanges();
        }
    }
}
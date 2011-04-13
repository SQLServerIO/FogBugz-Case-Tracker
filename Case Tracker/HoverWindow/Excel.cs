#region

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FogBugzNet;

#endregion

namespace FogBugzCaseTracker
{
    public partial class HoverWindow
    {
        private void ExportToExcel()
        {
            try
            {
                string tempTabSep = Path.GetTempPath() + "cases_" + (Guid.NewGuid()) + ".txt";
                // create a writer and open the file
                TextWriter tw = new StreamWriter(tempTabSep);

                for (int i = 1; i < dropCaseList.Items.Count; ++i)
                {
                    var c = (Case) dropCaseList.Items[i];
                    tw.WriteLine("({0:D}) {1}\t{2}h\t{3}", c.ID, c.Name, c.Estimate.TotalHours, c.AssignedTo);
                }

                tw.Close();
                Process.Start("excel.exe", "\"" + tempTabSep + "\"");
            }
            catch (Exception x)
            {
                MessageBox.Show(@"Sorry, couldn't launch Excel");
                Utils.LogError(x.ToString());
            }
        }
    }
}
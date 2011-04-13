#region

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using FogBugzNet;

#endregion

namespace FogBugzCaseTracker
{
    public partial class HoverWindow
    {
        private void ExportToFreeMind()
        {
            try
            {
                string tempTabSep = Path.GetTempPath() + "cases_" + (Guid.NewGuid()) + ".mm";
                // create a writer and open the file

                var ex = new Exporter(_fb, new Search(FormatSearch(), _cases));
                ex.CasesToMindMap().Save(tempTabSep);

                Process.Start("\"" + tempTabSep + "\"");
            }
            catch (Exception x)
            {
                MessageBox.Show(@"Sorry, couldn't launch Excel");
                Utils.LogError(x.ToString());
            }
        }

        private void DoImport()
        {
            XmlDocument doc = GetMindMapFromUser();
            if (doc == null)
                return;

            var imp = new Importer(doc, _fb);
            ImportAnalysis results = imp.Analyze();
            if (results.NothingToDo)
            {
                MessageBox.Show(@"No changes were detected. Nothing to import.", @"Import Mind Map",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dlg = new ImportConfirmationDlg(results);

            if (dlg.ShowDialog() == DialogResult.Yes)
            {
                foreach (Case c in results.CaseToNewParent.Keys)
                {
                    try
                    {
                        _fb.SetParent(c, results.CaseToNewParent[c].ID);
                    }
                    catch (Exception x)
                    {
                        Utils.LogError(x.ToString());
                    }
                }
            }
        }

        private static XmlDocument GetMindMapFromUser()
        {
            var d = new OpenFileDialog
                        {
                            CheckFileExists = true,
                            Multiselect = false,
                            Filter = @"FreeMind files (*.mm)|*.mm|All files (*.*)|*.*"
                        };

            if (d.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var doc = new XmlDocument();
                    doc.Load(d.FileName);
                    return doc;
                }
                catch (Exception x)
                {
                    Utils.LogError(x.ToString());
                }
            }

            return null;
        }
    }
}
#region

using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;
using FogBugzNet;

#endregion

namespace FogBugzCaseTracker
{
    public partial class HoverWindow
    {
        #region Delegates

        public delegate void OnCasesFetched(Case[] cases, Exception error);

        #endregion

        private Case[] _cases;

        private void updateCaseDropdown(Case[] cases)
        {
            _cases = cases;
            dropCaseList.Items.Clear();
            RepopulateCaseDropdown();
            UpdateStateAccordingToTracking();
        }

        private void updateCases(bool failSilently = false)
        {
            SetState(new StateUpdatingCases(this));
            Application.DoEvents();

            GetCasesAsync(FormatSearch(), delegate(Case[] cases, Exception error)
                                              {
                                                  try
                                                  {
                                                      if (error != null)
                                                          throw error;
                                                      updateCaseDropdown(cases);
                                                  }
                                                  catch (ECommandFailed e)
                                                  {
                                                      if (e.ErrorCode == (int) ECommandFailed.Code.InvalidSearch)
                                                      {
                                                          _narrowSearch =
                                                              ConfigurationManager.AppSettings["DefaultNarrowSearch"];
                                                          updateCases(failSilently);
                                                          if (!failSilently)
                                                              throw;
                                                      }
                                                  }
                                                  catch (Exception)
                                                  {
                                                      SetState(new StateRetryLogin(this));
                                                      if (!failSilently)
                                                          throw;
                                                  }
                                              });
        }


        private void RepopulateCaseDropdown()
        {
            dropCaseList.Items.Add("(nothing)");
            dropCaseList.Text = @"(nothing)";
            foreach (Case c in _cases)
            {
                Application.DoEvents();
                dropCaseList.Items.Add(c);
            }
        }

        public void GetCasesAsync(string search, OnCasesFetched OnDone)
        {
            var bw = new BackgroundWorker();
            bw.DoWork += delegate(object sender, DoWorkEventArgs args) { args.Result = _fb.GetCases(search); };
            bw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs args)
                                         {
                                             if (args.Error != null)
                                                 OnDone(null, args.Error);
                                             else
                                                 OnDone((Case[]) args.Result, null);
                                         };
            bw.RunWorkerAsync();
        }
    }
}
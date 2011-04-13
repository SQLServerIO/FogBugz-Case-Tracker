#region

using System;
using System.Diagnostics;
using System.Windows.Forms;
using FogBugzNet;
using Microsoft.Win32;

#endregion

namespace FogBugzCaseTracker
{
    public partial class HoverWindow
    {
        private Case _caseBeforePause;
        private object _currentState;
        private bool _switchToNothinUponClosing;
        private Case _trackedCase;

        private bool ClientTrackingCase
        {
            get { return TrackedCase != null; }
        }

        private Case TrackedCase
        {
            get { return _trackedCase; }

            set
            {
                if (value == null)
                {
                    _fb.StopWorking();
                    SetState(new StateLoggedIn(this));
                    return;
                }

                bool serverTrackInitiated = _fb.StartWorking(value.ID);

                if (!serverTrackInitiated)
                {
                    if (ObtainUserEstimate(value.ID))
                        serverTrackInitiated = _fb.StartWorking(value.ID);
                }

                if (serverTrackInitiated)
                {
                    _trackedCase = value;
                    SetState(new StateTrackingCase(this));
                }
                else
                {
                    _trackedCase = null;
                    SelectNothing();
                    SetState(new StateLoggedIn(this));
                }
            }
        }

        private void SelectNothing()
        {
            foreach (Object o in dropCaseList.Items)
                if (o.GetType() != typeof (Case))
                {
                    dropCaseList.SelectedItem = o;
                    break;
                }
        }

        private bool ObtainUserEstimate(int caseid)
        {
            var dlg = new EstimateDialog();
            dlg.Left = ((Left + Width/2) - dlg.Width/2);
            dlg.Top = Bottom + 5;
            DialogResult res = dlg.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                if (!_fb.SetEstimate(caseid, dlg.UserEstimate))
                {
                    Utils.ShowErrorMessage(
                        String.Format("Invalid estimate provided: '{0}'\nCurrent estimate was reset to 0 hours.",
                                      dlg.UserEstimate), "Invalid Estimate");
                    return false;
                }
                return true;
            }
            Process.Start(_fb.CaseEditURL(caseid));
            _trackedCase = null;

            // TODO: why is this tip not showing?
            trayIcon.ShowBalloonTip(3000, "FogBugz",
                                    "Sorry, I need a valid time estimate on that case.\nMeanwhile, you're working on \"nothing\"",
                                    ToolTipIcon.Info);
            return false;
        }

        private void UpdateStateAccordingToTracking()
        {
            // Handle also case where a case is being tracked on the server side, but not on the client
            if (ClientTrackingCase || _fb.CaseWorkedOnNow != 0)
            {
                if (!SelectWorkedOnCase())
                {
                    TrackedCase = null;
                    SetState(new StateLoggedIn(this));
                }
                else
                    SetState(new StateTrackingCase(this));
            }
            else
                SetState(new StateLoggedIn(this));
        }

        private int FindWorkedOnCaseIndexInDropDown()
        {
            for (int i = 1; i < dropCaseList.Items.Count; ++i)
            {
                if (((Case) dropCaseList.Items[i]).ID == _fb.CaseWorkedOnNow)
                {
                    return i;
                }
            }
            return -1;
        }

        private void SelectCase(int i)
        {
            dropCaseList.SelectedIndex = i;
            TrackedCase = ((Case) dropCaseList.Items[i]);
        }

        private bool SelectWorkedOnCase()
        {
            int i = FindWorkedOnCaseIndexInDropDown();
            if (i == -1)
                return false;
            SelectCase(i);
            return true;
        }

        private void UpdateTrackedItem()
        {
            try
            {
                // If the selected item is changed as part of the update process, 
                // don't count it as the user changing selection
                if (_currentState.GetType() == typeof (StateUpdatingCases))
                    return;
                TrackedCase = SelectedItemIsCase() ? (Case) dropCaseList.SelectedItem : null;
            }
            catch (InvalidCastException x)
            {
                Utils.LogError(x + "Selected item (index:{0}) is not a Case!", dropCaseList.SelectedIndex);
            }
        }

        private bool SelectedItemIsCase()
        {
            return dropCaseList.SelectedItem.GetType() == typeof (Case);
        }

        //added to stop work when workstation is locked
        private void SysEventsCheck(object sender, SessionSwitchEventArgs e)
        {
            MessageBox.Show(@"Locked");

            if (!(_autosleep))
            {
                _caseBeforePause = TrackedCase;
                TrackedCase = null;
                SetState(new StatePaused(this));
                switch (e.Reason)
                {
                    case SessionSwitchReason.SessionLock:
                        _caseBeforePause = TrackedCase;
                        TrackedCase = null;
                        SetState(new StatePaused(this));
                        break;
                    case SessionSwitchReason.SessionUnlock:
                        TrackedCase = _caseBeforePause;
                        SetState(new StateTrackingCase(this));
                        break;
                }
            }
        }

        private void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode != PowerModes.Suspend) return;
            _caseBeforePause = TrackedCase;
            TrackedCase = null;
            SetState(new StatePaused(this));
        }
    }
}
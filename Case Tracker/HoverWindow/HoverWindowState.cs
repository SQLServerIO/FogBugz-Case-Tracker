﻿#region

using System;
using FogBugzNet;

#endregion

namespace FogBugzCaseTracker
{
    public partial class HoverWindow
    {
        private void SetState(object state)
        {
            Utils.Trace("Entering state: " + state.GetType());
            _currentState = state;
            Refresh();
        }

        #region Nested type: StateLoggedIn

        private class StateLoggedIn : StateLoggingIn
        {
            public StateLoggedIn(HoverWindow frm)
                : base(frm)
            {
                frm.dropCaseList.Enabled = true;
                frm.btnFilter.Enable(true);
                frm.btnRefresh.Enable(true);
                frm.btnNewCase.Enable(true);
                frm.timerUpdateCases.Enabled = true;
                frm.btnMain.Enabled = true;
                frm.btnExportFreeMind.Enable(true);
                frm.btnExportExcel.Enable(true);
                frm.busyPicture.Visible = false;
            }
        } ;

        #endregion

        #region Nested type: StateLoggedOff

        private class StateLoggedOff
        {
            public StateLoggedOff(HoverWindow frm)
            {
                frm.btnMain.Enabled = true;
                frm.dropCaseList.Text = @"(please login)";
                frm.dropCaseList.Enabled = false;
                frm.btnFilter.Enable(false);
                frm.btnRefresh.Enable(false);
                frm.btnNewCase.Enable(false);
                frm.btnNewSubcase.Enable(false);
                frm.btnResolve.Enable(false);
                frm.btnViewCase.Enable(false);
                frm.btnResolveClose.Enable(false);
                frm.timerUpdateCases.Enabled = false;
                frm.btnExportFreeMind.Enable(false);
                frm.btnExportExcel.Enable(false);
                frm.busyPicture.Visible = false;
                frm.btnPause.Enable(false);
                frm.pnlPaused.Visible = false;
            }
        } ;

        #endregion

        #region Nested type: StateLoggingIn

        private class StateLoggingIn : StateLoggedOff
        {
            public StateLoggingIn(HoverWindow frm)
                : base(frm)
            {
                frm.btnMain.Enabled = true;
                frm.timerRetryLogin.Enabled = false;
                frm.busyPicture.Visible = true;
            }
        } ;

        #endregion

        #region Nested type: StatePaused

        private class StatePaused : StateTrackingCase
        {
            public StatePaused(HoverWindow frm)
                : base(frm)
            {
                frm.btnResolve.Enable(false);

                frm.btnViewCase.Enable(false);
                frm.btnResolveClose.Enable(false);
                frm.tooltipCurrentCase.SetToolTip(frm.dropCaseList,
                                                  String.Format("[PAUSED] Working on: {0} (elapsed time: {1})",
                                                                frm.dropCaseList.Text,
                                                                ((Case) frm.dropCaseList.SelectedItem).ElapsedTime_h_m));
                frm.timerUpdateCases.Enabled = false;
                frm.busyPicture.Visible = false;
                frm.btnPause.Enable(false);
                frm.pnlPaused.Visible = true;
                frm.pnlPaused.Top = 1;
                frm.pnlPaused.Left = 1;
                frm.pnlPaused.Width = frm.Width - 2;
                frm.pnlPaused.Height = frm.Height - 2;
                frm.btnNewCase.Enable(false);
                frm.btnExportExcel.Enable(false);
                frm.btnExportFreeMind.Enable(false);
                frm.btnImportFreeMind.Enable(false);
                frm.btnNewSubcase.Enable(false);
            }
        } ;

        #endregion

        #region Nested type: StateRetryLogin

        private class StateRetryLogin : StateLoggedOff
        {
            public StateRetryLogin(HoverWindow frm)
                : base(frm)
            {
                frm.dropCaseList.Text = @"(FogBugz server disconnection)";
                frm.timerRetryLogin.Enabled = true;
            }
        } ;

        #endregion

        #region Nested type: StateTrackingCase

        private class StateTrackingCase : StateLoggedIn
        {
            public StateTrackingCase(HoverWindow frm)
                : base(frm)
            {
                frm.btnResolve.Enable(true);

                frm.btnViewCase.Enable(true);
                frm.btnResolveClose.Enable(true);

                frm.tooltipCurrentCase.SetToolTip(frm.dropCaseList,
                                                  String.Format("Working on: {0} (elapsed time: {1})",
                                                                frm.dropCaseList.Text,
                                                                ((Case) frm.dropCaseList.SelectedItem).ElapsedTime_h_m));
                frm.timerUpdateCases.Enabled = true;
                frm.busyPicture.Visible = false;
                frm.btnPause.Enable(true);
                frm.btnNewSubcase.Enable(true);
            }
        } ;

        #endregion

        #region Nested type: StateUpdatingCases

        private class StateUpdatingCases : StateLoggedOff
        {
            public StateUpdatingCases(HoverWindow frm)
                : base(frm)
            {
                frm.dropCaseList.Text = @"(Updating cases...)";
                frm.btnMain.Enabled = false;
                frm.timerUpdateCases.Enabled = false;
                frm.dropCaseList.Enabled = false;
                frm.timerRetryLogin.Enabled = false;
                frm.busyPicture.Visible = true;
            }
        } ;

        #endregion
    }
}
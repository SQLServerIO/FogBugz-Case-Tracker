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

        public delegate void OnLogon(bool succeeded);

        #endregion

        private string _password;
        private string _server;
        private string _username;
        private bool _autosleep;

        private static LogonResultInfo DoLogonScreen(string initialUser, string initialPassword, string initialServer)
        {
            var ret = new LogonResultInfo();

            var f = new LoginForm {Password = initialPassword, Email = initialUser, Server = initialServer};


            if (f.ShowDialog() == DialogResult.Cancel)
                ret.UserChoice = DialogResult.Cancel;
            else
            {
                ret.UserChoice = DialogResult.OK;
                ret.User = f.Email;
                ret.Password = f.Password;
                ret.Server = f.Server;
            }
            return ret;
        }

        private void loginWithPrompt(bool forceNewCreds = false)
        {
            try
            {
                SetState(new StateLoggingIn(this));
                if (forceNewCreds || _password.Length == 0 || _username.Length == 0 || _server.Length == 0 ||
                    _server == ConfigurationManager.AppSettings["ExampleServerURL"])
                {
                    if (_server.Length == 0)
                    {
                        string url = ConfigurationManager.AppSettings["FogBugzBaseURL"] ?? "";
                        _server = (url.Length > 0) ? url : ConfigurationManager.AppSettings["ExampleServerURL"];
                    }

                    LogonResultInfo info = DoLogonScreen(_username, _password, _server);
                    if (info.UserChoice != DialogResult.Cancel)
                    {
                        _username = info.User;
                        _password = info.Password;
                        _server = info.Server;
                    }
                }

                _fb = new FogBugz(_server);

                LogonAsync(_username, _password, delegate(bool succeeded)
                                                     {
                                                         if (succeeded)
                                                         {
                                                             saveSettings();
                                                             updateCases();
                                                         }
                                                         else
                                                         {
                                                             _password = "";
                                                             SetState(new StateLoggedOff(this));
                                                             MessageBox.Show(@"Login failed", @"FogBugz",
                                                                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                         }
                                                     });
            }
            catch (Exception)
            {
                SetState(new StateLoggedOff(this));
                throw;
            }
        }

        public void LogonAsync(string email, string password, OnLogon OnDone)
        {
            var bw = new BackgroundWorker();
            bw.DoWork += delegate(object sender, DoWorkEventArgs args) { args.Result = _fb.Logon(email, password); };
            bw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs args)
                                         {
                                             if (args.Error != null)
                                             {
                                                 Utils.LogError("Error during login: {0}", args.Error.ToString());
                                                 OnDone(false);
                                             }
                                             else
                                                 OnDone((bool) args.Result);
                                         };
            bw.RunWorkerAsync();
        }

        private void RetryLogin()
        {
            Utils.Trace("Retrying login...");
            LogonAsync(_username, _password, delegate(bool success)
                                                 {
                                                     if (success)
                                                         updateCases(true);
                                                     else
                                                         SetState(new StateRetryLogin(this));
                                                 });
        }

        #region Nested type: LogonResultInfo

        public struct LogonResultInfo
        {
            public string Password;
            public string Server;
            public String User;
            public DialogResult UserChoice;
        } ;

        #endregion
    }
}
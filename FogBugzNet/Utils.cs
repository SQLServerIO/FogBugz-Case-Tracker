#region

using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

#endregion

namespace FogBugzNet
{
    public class Utils
    {
        private static readonly byte[] Entropy = new byte[] {0x23, 0x10, 0x19, 0x79, 0x18, 0x89, 0x04};

        public static void ShowErrorMessage(string error, string title)
        {
            MessageBox.Show(error, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowErrorMessage(string error)
        {
            ShowErrorMessage(error, "Error Encountered");
        }

        // Only ASCII text. Based on example here: http://blogs.msdn.com/shawnfa/archive/2004/05/05/126825.aspx
        public static byte[] EncryptCurrentUser(String text)
        {
            if (text.Length == 0)
                throw new Exception("Cannot encrypt empty string");

            byte[] buffer = Encoding.ASCII.GetBytes(text);

            return ProtectedData.Protect(buffer, Entropy, DataProtectionScope.CurrentUser);
        }

        public static string DecryptCurrentUser(byte[] buffer)
        {
            byte[] unprotectedBytes = ProtectedData.Unprotect(buffer, Entropy, DataProtectionScope.CurrentUser);

            return Encoding.ASCII.GetString(unprotectedBytes);
        }

        public static void LogError(string msg, params object[] args)
        {
            string l = String.Format(msg, args);
            try
            {
                Trace(l);
                if (!EventLog.SourceExists("CaseTracker"))
                    EventLog.CreateEventSource("CaseTracker", "Application");
                var log = new EventLog("Application") {Source = "CaseTracker"};
                log.WriteEntry(l, EventLogEntryType.Error);
            }
            catch (Exception e)
            {
                // Not much we can do in this case... 
                MessageBox.Show(e.Message);
            }
        }

        public static void Trace(string msg, params object[] args)
        {
            string l = String.Format(msg, args);
            System.Diagnostics.Trace.WriteLine(l);
        }
    }
}
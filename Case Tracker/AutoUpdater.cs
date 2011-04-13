#region

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using FogBugzNet;

#endregion

namespace FogBugzCaseTracker
{
    public class AutoUpdater
    {
        private readonly TimeSpan _interval;
        private readonly string _url;
        private readonly FileVersionInfo _versionInfo;
        private XmlElement _latest;
        private string _setup;

        public AutoUpdater(string url, TimeSpan interval)
        {
            _url = url;
            _interval = interval;

            Assembly assembly = Assembly.GetExecutingAssembly();
            _versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
        }

        private string setupCacheDir
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                       "\\VisionMap\\CaseTracker";
            }
        }

        private bool IsLatestNewerThanMe()
        {
            String[] partsTheir = _latest.SelectSingleNode("Version").InnerText.Split(new[] {'.'});
            String[] partsMine = _versionInfo.ProductVersion.Split(new[] {'.'});

            for (int i = 0; i < 4; ++i)
            {
                if (int.Parse(partsTheir[i]) > int.Parse(partsMine[i]))
                    return true;
                if (int.Parse(partsTheir[i]) < int.Parse(partsMine[i]))
                    return false;
            }
            return false;
        }

        public void Run()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += delegate
                             {
                                 try
                                 {
                                     while (true)
                                     {
                                         FindNewerReleases(GetLatestVersionXml());
                                         Thread.Sleep(_interval);
                                     }
                                 }
                                 catch (Exception e)
                                 {
                                     Utils.LogError("Error while checking for updates: {0}", e.ToString());
                                 }
                             };
            bw.RunWorkerAsync();
        }

        private XmlDocument GetLatestVersionXml()
        {
            string latestVersionXml = HttpUtils.httpGet(_url);
            var doc = new XmlDocument();
            doc.LoadXml(latestVersionXml);
            return doc;
        }

        private void VerifyMd5(string filename, string expectedHash)
        {
            var md5 = new MD5CryptoServiceProvider();

            var sb = new StringBuilder();
            byte[] actualHash = md5.ComputeHash(new FileStream(filename, FileMode.Open, FileAccess.Read));
            foreach (Byte b in actualHash)
                sb.Append(String.Format("{0,2:X}", b));
            string actualHashStr = sb.ToString();
            if (actualHashStr != expectedHash)
            {
                File.Delete(filename);
                throw new Exception(String.Format("Bad hash of downloaded version.\nExpected: {0}\n  Actual: {1}",
                                                  expectedHash, actualHashStr));
            }
        }

        private string DownloadLatestVersion()
        {
            String remoteURL = _latest.SelectSingleNode("URL").InnerText;

            string remoteFileName = Path.GetFileName(remoteURL);

            if (!Directory.Exists(setupCacheDir))
                Directory.CreateDirectory(setupCacheDir);

            string localFilePath = setupCacheDir + "\\" + remoteFileName;

            if (!File.Exists(localFilePath))
            {
                Utils.Trace("Downloading latest version from {0} to {1}", remoteURL, localFilePath);
                HttpUtils.httpGetBinary(remoteURL, localFilePath);
                VerifyMd5(localFilePath, _latest.SelectSingleNode("MD5").InnerText);
            }

            return localFilePath;
        }

        private void SuggestUpdate()
        {
            var dlg = new VersionUpdatePrompt();

            dlg.WhatsNew = _latest.SelectSingleNode("Notes").InnerText;
            dlg.LatestVersion = _latest.SelectSingleNode("Version").InnerText;
            dlg.CurrentVersion = _versionInfo.ProductVersion;

            if (dlg.ShowDialog() == DialogResult.Yes)
                DoUpdate();
        }

        private void DoUpdate()
        {
            Process.Start(_setup, "/SILENT");
        }

        private void FindNewerReleases(XmlDocument doc)
        {
            _latest = (XmlElement) doc.SelectNodes("//Release").Item(0);

            if (IsLatestNewerThanMe())
            {
                _setup = DownloadLatestVersion();
                SuggestUpdate();
            }
        }
    }
}
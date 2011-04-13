#region
using System;
using System.Collections.Generic;
using Microsoft.Win32;
#endregion



namespace FogBugzCaseTracker
{
    public class SearchHistory
    {
        private readonly int _maxSize;
        private RegistryKey _key;

        public SearchHistory(int howLong)
        {
            _maxSize = howLong;
            History = new List<string>();
        }

        public List<string> History { get; set; }

        public void Load()
        {
            History.Clear();
            _key = Registry.CurrentUser.OpenSubKey("Software\\VisionMap\\CaseTracker\\SearchHistory");
            try
            {
                if (_key == null)
                {
                    _key = Registry.CurrentUser.OpenSubKey("Software\\VisionMap\\CaseTracker");
                    if (_key != null)
                        History.Add((String) _key.GetValue("NarrowSearch", ""));
                            // To support transition from before search history was implemented
                    return;
                }

                for (int i = 0; i < _maxSize; ++i)
                {
                    string filter = (string) _key.GetValue(i.ToString(), "") ?? "";
                    if (filter != "")
                        History.Add(filter);
                }
            }
            finally
            {
                if (_key != null)
                    _key.Close();
            }
        }

        public void Save()
        {
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree("Software\\VisionMap\\CaseTracker\\SearchHistory");
            }
            catch (Exception)
            {
            }
            _key = Registry.CurrentUser.CreateSubKey("Software\\VisionMap\\CaseTracker\\SearchHistory");

            try
            {
                for (int i = 0; i < History.Count; ++i)
                    _key.SetValue(i.ToString(), History[i]);
            }
            finally
            {
                if (_key != null)
                    _key.Close();
            }
        }

        public void PushSearch(string filter)
        {
            if (filter == "")
                return;

            History.RemoveAll(delegate(string val) { return val == filter; });

            History.Insert(0, filter);
            if (History.Count > _maxSize)
                History.RemoveRange(_maxSize, History.Count - _maxSize);
        }
    }
}
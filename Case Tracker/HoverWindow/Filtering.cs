#region

using System;
using System.Windows.Forms;

#endregion

namespace FogBugzCaseTracker
{
    public partial class HoverWindow
    {
        private readonly String _baseSearch;
        private SearchHistory _history;
        private bool _ignoreBaseSearch;
        private bool _includeNoEstimate = true;

        private String _narrowSearch
        {
            get { return _history.History.Count > 0 ? _history.History[0] : ""; }
            set { _history.PushSearch(value); }
        }


        private string FormatSearch()
        {
            string search = _narrowSearch;
            if (!_ignoreBaseSearch)
                return search + " " + _baseSearch;

            if (!_includeNoEstimate)
                return search + " -CurrentEstimate:\"0\"";

            return search;
        }

        private void ShowFilterDialog()
        {
            var f = new FilterDialog(_history)
                        {
                            fb = _fb,
                            dad = this,
                            UserSearch = _narrowSearch,
                            BaseSearch = _baseSearch,
                            IncludeNoEstimate = _includeNoEstimate,
                            IgnoreBaseSearch = _ignoreBaseSearch
                        };
            if (f.ShowDialog() != DialogResult.OK) return;
            _narrowSearch = f.UserSearch;
            _ignoreBaseSearch = f.IgnoreBaseSearch;
            _includeNoEstimate = f.IncludeNoEstimate;
            if (f.Cases != null)
                updateCaseDropdown(f.Cases);
            else
                updateCases();
            _history.Save();
        }
    }
}
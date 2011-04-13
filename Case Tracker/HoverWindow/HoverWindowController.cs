#region

using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using FogBugzNet;
using Microsoft.Win32;

#endregion

namespace FogBugzCaseTracker
{
    public partial class HoverWindow
    {
        //commenting out autoupdater since we are now running our own codebase.
        //private AutoUpdater _autoUpdate;

        private int _dragDistance;
        private bool _dragging;
        private FogBugz _fb;
        private int _gripStartX;
        private int _mouseDownX;

        private int _mouseDownY;
        private bool _resizing;
        private DateTime _startDragTime;

        private readonly PowerModeChangedEventHandler _powerMode;
        private readonly SessionSwitchEventHandler _sseh;

        public HoverWindow()
        {
            //detect lock event and save state or restore state
            _sseh = new SessionSwitchEventHandler(SysEventsCheck);
            SystemEvents.SessionSwitch += _sseh;

            //detect sleep mode and save state
            _powerMode = new PowerModeChangedEventHandler(OnPowerModeChanged);
            SystemEvents.PowerModeChanged += _powerMode;

            InitializeComponent();

            _baseSearch = ConfigurationManager.AppSettings["BaseSearch"];
            _ignoreBaseSearch = bool.Parse(ConfigurationManager.AppSettings["IgnoreBaseSearch"]);
            //_autoUpdate = new AutoUpdater(ConfigurationManager.AppSettings["AutoUpdateURL"],new TimeSpan(int.Parse(ConfigurationManager.AppSettings["VersionUpdateCheckIntervalHours"]), 0, 0));

            loadSettings();

            //_autoUpdate.Run();
        }

        private void startDragging(MouseEventArgs e)
        {
            _startDragTime = DateTime.Now;

            _dragDistance = 0;
            _mouseDownX = e.X;
            _mouseDownY = e.Y;
            _dragging = true;
        }

/*
        private bool atScreenEdge(Point p)
        {
            return (p.X <= 0) || (p.Y <= 0);

        }
*/

        private void moveWindow(Point p)
        {
            var screen = Screen.PrimaryScreen.WorkingArea;
            if (Screen.AllScreens.Length == 1)
            {
                if (p.X < 5)
                    p.X = 0;
                if (p.X + Width > screen.Width - 5)
                    p.X = screen.Width - Width;
            }
            if (p.Y < 5)
                p.Y = 0;
            if (p.Y + Height > screen.Height - 5)
                p.Y = screen.Height - Height;

            Location = p;
        }

        private void dragWindow(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var p = new Point();
                // Measure drag distance
                _dragDistance +=
                    (int) Math.Sqrt((e.X - _mouseDownX)*(e.X - _mouseDownX) + (e.Y - _mouseDownY)*(e.Y - _mouseDownY));

                // Measure drag speed
                long ticks = DateTime.Now.Subtract(_startDragTime).Milliseconds;
                if (ticks > 0)
                {
                    double speed = (double) _dragDistance/ticks;

                    // Not doing anything with the drag speed for now
                    // Might use it to implement mouse gestures
                }
                _dragDistance = 0;
                _startDragTime = DateTime.Now;


                p.X = Location.X + (e.X - _mouseDownX);
                p.Y = Location.Y + (e.Y - _mouseDownY);
                moveWindow(p);
            }
        }

        private void MoveWindowToCenter()
        {
            var p = new Point
                        {
                            X = (Screen.PrimaryScreen.WorkingArea.Width - Width)/2,
                            Y = 0
                        };
            Location = p;
        }

        private void ResizeWidth()
        {
            Width += Cursor.Position.X - _gripStartX;
            _gripStartX = Cursor.Position.X;
        }

        private void CloseApplication()
        {
            try
            {
                if (_switchToNothinUponClosing)
                    _fb.StopWorking();
                saveSettings();

                //release the handles watching for console lock and computer sleep/hybernate
                SystemEvents.SessionSwitch -= _sseh;
                SystemEvents.PowerModeChanged -= _powerMode;
            }
            catch (Exception x)
            {
                Utils.LogError(x.ToString());
            }
        }
    }

    // class HoverWindow
}
// ns FogBugzCaseTracker
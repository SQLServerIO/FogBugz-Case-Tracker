namespace FogBugzCaseTracker
{
    partial class HoverWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HoverWindow));
            this.timerUpdateCases = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCurrentCase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCurrentFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tooltipCurrentCase = new System.Windows.Forms.ToolTip(this.components);
            this.dropCaseList = new System.Windows.Forms.ComboBox();
            this.lblWorkingOn = new System.Windows.Forms.Label();
            this.timerRetryLogin = new System.Windows.Forms.Timer(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pnlPaused = new System.Windows.Forms.Panel();
            this.lblImBack = new System.Windows.Forms.Label();
            this.busyPicture = new System.Windows.Forms.PictureBox();
            this.extensionGrip = new System.Windows.Forms.PictureBox();
            this.btnMain = new System.Windows.Forms.Button();
            this.backgroundPic = new System.Windows.Forms.PictureBox();
            this.KeepLoggingTimeChk = new System.Windows.Forms.CheckBox();
            this.btnPause = new FogBugzCaseTracker.MultiImageButton();
            this.btnFilter = new FogBugzCaseTracker.MultiImageButton();
            this.menuNew = new FogBugzCaseTracker.MultiImageToolStripMenuItem();
            this.btnNewCase = new FogBugzCaseTracker.MultiImageToolStripMenuItem();
            this.btnNewSubcase = new FogBugzCaseTracker.MultiImageToolStripMenuItem();
            this.btnViewCase = new FogBugzCaseTracker.MultiImageToolStripMenuItem();
            this.btnResolveClose = new FogBugzCaseTracker.MultiImageToolStripMenuItem();
            this.btnResolve = new FogBugzCaseTracker.MultiImageToolStripMenuItem();
            this.btnExportFreeMind = new FogBugzCaseTracker.MultiImageToolStripMenuItem();
            this.btnImportFreeMind = new FogBugzCaseTracker.MultiImageToolStripMenuItem();
            this.btnExportExcel = new FogBugzCaseTracker.MultiImageToolStripMenuItem();
            this.btnConfigure = new FogBugzCaseTracker.MultiImageToolStripMenuItem();
            this.btnShowHide = new FogBugzCaseTracker.MultiImageToolStripMenuItem();
            this.btnRefresh = new FogBugzCaseTracker.MultiImageButton();
            this.menuMain.SuspendLayout();
            this.pnlPaused.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busyPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extensionGrip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPic)).BeginInit();
            this.SuspendLayout();
            // 
            // timerUpdateCases
            // 
            this.timerUpdateCases.Enabled = true;
            this.timerUpdateCases.Interval = 600000;
            this.timerUpdateCases.Tick += new System.EventHandler(this.updateCasesTimer_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "Right-click: menu\r\nLeft-click: show/hide";
            this.trayIcon.BalloonTipTitle = "Case Tracker";
            this.trayIcon.ContextMenuStrip = this.menuMain;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "FogBugz";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            this.trayIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseUp);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuCurrentCase,
            this.menuCurrentFilter,
            this.btnConfigure,
            this.toolStripSeparator1,
            this.btnShowHide,
            this.btnExit});
            this.menuMain.Name = "contextMenuStrip1";
            this.menuMain.Size = new System.Drawing.Size(150, 142);
            this.menuMain.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            this.menuMain.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // menuCurrentCase
            // 
            this.menuCurrentCase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewCase,
            this.btnResolveClose,
            this.btnResolve});
            this.menuCurrentCase.Image = global::FogBugzCaseTracker.Properties.Resources.icon;
            this.menuCurrentCase.Name = "menuCurrentCase";
            this.menuCurrentCase.Size = new System.Drawing.Size(149, 22);
            this.menuCurrentCase.Text = "Current Case";
            // 
            // menuCurrentFilter
            // 
            this.menuCurrentFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportFreeMind,
            this.btnImportFreeMind,
            this.btnExportExcel});
            this.menuCurrentFilter.Image = global::FogBugzCaseTracker.Properties.Resources.filter1;
            this.menuCurrentFilter.Name = "menuCurrentFilter";
            this.menuCurrentFilter.Size = new System.Drawing.Size(149, 22);
            this.menuCurrentFilter.Text = "Current Filter";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(149, 22);
            this.btnExit.Text = "&Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dropCaseList
            // 
            this.dropCaseList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dropCaseList.DisplayMember = "LongDescription";
            this.dropCaseList.DropDownHeight = 500;
            this.dropCaseList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropCaseList.DropDownWidth = 400;
            this.dropCaseList.FormattingEnabled = true;
            this.dropCaseList.IntegralHeight = false;
            this.dropCaseList.Location = new System.Drawing.Point(62, 3);
            this.dropCaseList.MaxDropDownItems = 100;
            this.dropCaseList.Name = "dropCaseList";
            this.dropCaseList.Size = new System.Drawing.Size(369, 21);
            this.dropCaseList.Sorted = true;
            this.dropCaseList.TabIndex = 11;
            this.dropCaseList.ValueMember = "id";
            this.dropCaseList.DropDown += new System.EventHandler(this.listCases_DropDown);
            this.dropCaseList.SelectedIndexChanged += new System.EventHandler(this.listCases_SelectedIndexChanged);
            this.dropCaseList.DropDownClosed += new System.EventHandler(this.listCases_DropDownClosed);
            // 
            // lblWorkingOn
            // 
            this.lblWorkingOn.AutoSize = true;
            this.lblWorkingOn.Location = new System.Drawing.Point(25, 6);
            this.lblWorkingOn.Name = "lblWorkingOn";
            this.lblWorkingOn.Size = new System.Drawing.Size(38, 13);
            this.lblWorkingOn.TabIndex = 12;
            this.lblWorkingOn.Text = "I\'m on:";
            this.lblWorkingOn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblWorkingOn_MouseDown);
            this.lblWorkingOn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblWorkingOn_MouseMove);
            this.lblWorkingOn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // timerRetryLogin
            // 
            this.timerRetryLogin.Tick += new System.EventHandler(this.timerRetryLogin_Tick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "pause_enabled");
            this.imageList.Images.SetKeyName(1, "pause_disabled");
            this.imageList.Images.SetKeyName(2, "freemind_disabled.png");
            this.imageList.Images.SetKeyName(3, "excel.png");
            this.imageList.Images.SetKeyName(4, "excel_disabled.png");
            this.imageList.Images.SetKeyName(5, "firefox_16.png");
            this.imageList.Images.SetKeyName(6, "firefox_16_disabled.png");
            this.imageList.Images.SetKeyName(7, "freemind.png");
            this.imageList.Images.SetKeyName(8, "icon.bmp");
            this.imageList.Images.SetKeyName(9, "icon_disabled.bmp");
            this.imageList.Images.SetKeyName(10, "key.gif");
            this.imageList.Images.SetKeyName(11, "key_disabled.gif");
            this.imageList.Images.SetKeyName(12, "new_case.png");
            this.imageList.Images.SetKeyName(13, "new_case_disabled.png");
            this.imageList.Images.SetKeyName(14, "filter.png");
            this.imageList.Images.SetKeyName(15, "filter_disabled.png");
            this.imageList.Images.SetKeyName(16, "refresh_disabled.gif");
            this.imageList.Images.SetKeyName(17, "refresh.gif");
            this.imageList.Images.SetKeyName(18, "check_icon_disabled.gif");
            this.imageList.Images.SetKeyName(19, "check_icon.gif");
            this.imageList.Images.SetKeyName(20, "fat_check.png");
            this.imageList.Images.SetKeyName(21, "fat_check_disabled.png");
            // 
            // pnlPaused
            // 
            this.pnlPaused.Controls.Add(this.lblImBack);
            this.pnlPaused.Location = new System.Drawing.Point(106, 6);
            this.pnlPaused.Name = "pnlPaused";
            this.pnlPaused.Size = new System.Drawing.Size(203, 17);
            this.pnlPaused.TabIndex = 19;
            this.pnlPaused.Visible = false;
            // 
            // lblImBack
            // 
            this.lblImBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblImBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImBack.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblImBack.Location = new System.Drawing.Point(3, 1);
            this.lblImBack.Name = "lblImBack";
            this.lblImBack.Size = new System.Drawing.Size(197, 16);
            this.lblImBack.TabIndex = 0;
            this.lblImBack.Text = "I\'m Back";
            this.lblImBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblImBack.Click += new System.EventHandler(this.lblImBack_Click);
            // 
            // busyPicture
            // 
            this.busyPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.busyPicture.Image = global::FogBugzCaseTracker.Properties.Resources.busy;
            this.busyPicture.ImageLocation = "";
            this.busyPicture.Location = new System.Drawing.Point(3, 3);
            this.busyPicture.Name = "busyPicture";
            this.busyPicture.Size = new System.Drawing.Size(22, 20);
            this.busyPicture.TabIndex = 17;
            this.busyPicture.TabStop = false;
            this.busyPicture.Visible = false;
            // 
            // extensionGrip
            // 
            this.extensionGrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.extensionGrip.BackgroundImage = global::FogBugzCaseTracker.Properties.Resources.ellipsis_vertical;
            this.extensionGrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.extensionGrip.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.extensionGrip.Location = new System.Drawing.Point(534, 1);
            this.extensionGrip.Name = "extensionGrip";
            this.extensionGrip.Size = new System.Drawing.Size(8, 24);
            this.extensionGrip.TabIndex = 15;
            this.extensionGrip.TabStop = false;
            this.extensionGrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grip_MouseDown);
            this.extensionGrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grip_MouseMove);
            this.extensionGrip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grip_MouseUp);
            // 
            // btnMain
            // 
            this.btnMain.BackgroundImage = global::FogBugzCaseTracker.Properties.Resources.icon;
            this.btnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMain.ContextMenuStrip = this.menuMain;
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Location = new System.Drawing.Point(2, 3);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(22, 20);
            this.btnMain.TabIndex = 9;
            this.btnMain.TabStop = false;
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // backgroundPic
            // 
            this.backgroundPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundPic.Location = new System.Drawing.Point(0, 0);
            this.backgroundPic.Name = "backgroundPic";
            this.backgroundPic.Size = new System.Drawing.Size(543, 26);
            this.backgroundPic.TabIndex = 16;
            this.backgroundPic.TabStop = false;
            this.backgroundPic.Click += new System.EventHandler(this.backgroundPic_Click);
            this.backgroundPic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.backgroundPic_MouseDown);
            this.backgroundPic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.backgroundPic_MouseMove);
            this.backgroundPic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.backgroundPic_MouseUp);
            // 
            // KeepLoggingTimeChk
            // 
            this.KeepLoggingTimeChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KeepLoggingTimeChk.Location = new System.Drawing.Point(518, 7);
            this.KeepLoggingTimeChk.Name = "KeepLoggingTimeChk";
            this.KeepLoggingTimeChk.Size = new System.Drawing.Size(15, 14);
            this.KeepLoggingTimeChk.TabIndex = 20;
            this.KeepLoggingTimeChk.UseVisualStyleBackColor = false;
            this.KeepLoggingTimeChk.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPause.BackgroundImage = global::FogBugzCaseTracker.Properties.Resources.pause;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPause.DisabledBackgroundImage = global::FogBugzCaseTracker.Properties.Resources.pause_disabled;
            this.btnPause.EnabledBackgroundImage = global::FogBugzCaseTracker.Properties.Resources.pause;
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Location = new System.Drawing.Point(440, 3);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(22, 20);
            this.btnPause.TabIndex = 18;
            this.btnPause.TabStop = false;
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFilter.BackgroundImage = global::FogBugzCaseTracker.Properties.Resources.filter;
            this.btnFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFilter.DisabledBackgroundImage = global::FogBugzCaseTracker.Properties.Resources.filter_disabled;
            this.btnFilter.EnabledBackgroundImage = global::FogBugzCaseTracker.Properties.Resources.filter1;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Location = new System.Drawing.Point(466, 3);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(22, 20);
            this.btnFilter.TabIndex = 13;
            this.btnFilter.TabStop = false;
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click_1);
            // 
            // menuNew
            // 
            this.menuNew.DisabledImage = global::FogBugzCaseTracker.Properties.Resources.new_case_disabled;
            this.menuNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewCase,
            this.btnNewSubcase});
            this.menuNew.EnabledImage = global::FogBugzCaseTracker.Properties.Resources.new_case;
            this.menuNew.Image = global::FogBugzCaseTracker.Properties.Resources.new_case;
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(149, 22);
            this.menuNew.Text = "New";
            // 
            // btnNewCase
            // 
            this.btnNewCase.DisabledImage = global::FogBugzCaseTracker.Properties.Resources.new_case_disabled;
            this.btnNewCase.EnabledImage = global::FogBugzCaseTracker.Properties.Resources.new_case;
            this.btnNewCase.Image = global::FogBugzCaseTracker.Properties.Resources.new_case;
            this.btnNewCase.Name = "btnNewCase";
            this.btnNewCase.Size = new System.Drawing.Size(190, 22);
            this.btnNewCase.Text = "Case";
            this.btnNewCase.Click += new System.EventHandler(this.btnNewCase_Click);
            // 
            // btnNewSubcase
            // 
            this.btnNewSubcase.DisabledImage = global::FogBugzCaseTracker.Properties.Resources.new_case_disabled;
            this.btnNewSubcase.EnabledImage = global::FogBugzCaseTracker.Properties.Resources.new_case;
            this.btnNewSubcase.Image = global::FogBugzCaseTracker.Properties.Resources.new_case;
            this.btnNewSubcase.Name = "btnNewSubcase";
            this.btnNewSubcase.Size = new System.Drawing.Size(190, 22);
            this.btnNewSubcase.Text = "Sub-Case (of current)";
            this.btnNewSubcase.Click += new System.EventHandler(this.btnNewSubcase_Click);
            // 
            // btnViewCase
            // 
            this.btnViewCase.DisabledImage = global::FogBugzCaseTracker.Properties.Resources.firefox_16_disabled;
            this.btnViewCase.EnabledImage = global::FogBugzCaseTracker.Properties.Resources.firefox_16;
            this.btnViewCase.Image = global::FogBugzCaseTracker.Properties.Resources.firefox_16;
            this.btnViewCase.Name = "btnViewCase";
            this.btnViewCase.Size = new System.Drawing.Size(207, 22);
            this.btnViewCase.Text = "&View in Browser";
            this.btnViewCase.Click += new System.EventHandler(this.btnViewCase_Click);
            // 
            // btnResolveClose
            // 
            this.btnResolveClose.DisabledImage = global::FogBugzCaseTracker.Properties.Resources.fat_check_disabled;
            this.btnResolveClose.EnabledImage = global::FogBugzCaseTracker.Properties.Resources.fat_check;
            this.btnResolveClose.Image = global::FogBugzCaseTracker.Properties.Resources.fat_check;
            this.btnResolveClose.Name = "btnResolveClose";
            this.btnResolveClose.Size = new System.Drawing.Size(207, 22);
            this.btnResolveClose.Text = "Resolve && &Close this case";
            this.btnResolveClose.Click += new System.EventHandler(this.btnResolveClose_Click);
            // 
            // btnResolve
            // 
            this.btnResolve.DisabledImage = global::FogBugzCaseTracker.Properties.Resources.check_icon_disabled;
            this.btnResolve.EnabledImage = global::FogBugzCaseTracker.Properties.Resources.check_icon;
            this.btnResolve.Image = global::FogBugzCaseTracker.Properties.Resources.check_icon;
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(207, 22);
            this.btnResolve.Text = "&Resolve this case";
            this.btnResolve.Click += new System.EventHandler(this.btnResolve_Click);
            // 
            // btnExportFreeMind
            // 
            this.btnExportFreeMind.DisabledImage = null;
            this.btnExportFreeMind.EnabledImage = global::FogBugzCaseTracker.Properties.Resources.freemind;
            this.btnExportFreeMind.Image = global::FogBugzCaseTracker.Properties.Resources.freemind;
            this.btnExportFreeMind.Name = "btnExportFreeMind";
            this.btnExportFreeMind.Size = new System.Drawing.Size(189, 22);
            this.btnExportFreeMind.Text = "Export to &FreeMind";
            this.btnExportFreeMind.Click += new System.EventHandler(this.btnExportFreeMind_Click);
            // 
            // btnImportFreeMind
            // 
            this.btnImportFreeMind.DisabledImage = null;
            this.btnImportFreeMind.EnabledImage = global::FogBugzCaseTracker.Properties.Resources.freemind;
            this.btnImportFreeMind.Image = global::FogBugzCaseTracker.Properties.Resources.freemind;
            this.btnImportFreeMind.Name = "btnImportFreeMind";
            this.btnImportFreeMind.Size = new System.Drawing.Size(189, 22);
            this.btnImportFreeMind.Text = "Import from FreeMind";
            this.btnImportFreeMind.Visible = false;
            this.btnImportFreeMind.Click += new System.EventHandler(this.btnImportFreeMind_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.DisabledImage = global::FogBugzCaseTracker.Properties.Resources.excel_disabled;
            this.btnExportExcel.EnabledImage = global::FogBugzCaseTracker.Properties.Resources.excel1;
            this.btnExportExcel.Image = global::FogBugzCaseTracker.Properties.Resources.excel;
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(189, 22);
            this.btnExportExcel.Text = "Export to Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnConfigure
            // 
            this.btnConfigure.DisabledImage = global::FogBugzCaseTracker.Properties.Resources.key_disabled;
            this.btnConfigure.EnabledImage = global::FogBugzCaseTracker.Properties.Resources.key;
            this.btnConfigure.Image = global::FogBugzCaseTracker.Properties.Resources.key;
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(149, 22);
            this.btnConfigure.Text = "&Switch user";
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // btnShowHide
            // 
            this.btnShowHide.DisabledImage = null;
            this.btnShowHide.EnabledImage = null;
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(149, 22);
            this.btnShowHide.Text = "&Hide";
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRefresh.BackgroundImage = global::FogBugzCaseTracker.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.DisabledBackgroundImage = global::FogBugzCaseTracker.Properties.Resources.refresh_disabled;
            this.btnRefresh.EnabledBackgroundImage = global::FogBugzCaseTracker.Properties.Resources.refresh;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(492, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(22, 20);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // HoverWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(543, 26);
            this.ControlBox = false;
            this.Controls.Add(this.pnlPaused);
            this.Controls.Add(this.KeepLoggingTimeChk);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.busyPicture);
            this.Controls.Add(this.extensionGrip);
            this.Controls.Add(this.dropCaseList);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.lblWorkingOn);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.backgroundPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2000, 26);
            this.MinimumSize = new System.Drawing.Size(224, 26);
            this.Name = "HoverWindow";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Case Tracker";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HoverWindow_FormClosed);
            this.Load += new System.EventHandler(this.HoverWindow_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HoverWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HoverWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HoverWindow_MouseUp);
            this.menuMain.ResumeLayout(false);
            this.pnlPaused.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.busyPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extensionGrip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerUpdateCases;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private MultiImageToolStripMenuItem btnConfigure;
        private System.Windows.Forms.ToolTip tooltipCurrentCase;
        private MultiImageToolStripMenuItem btnShowHide;
        private MultiImageButton btnFilter;
        private System.Windows.Forms.ComboBox dropCaseList;
        private System.Windows.Forms.Label lblWorkingOn;
        //private  System.Windows.Forms.Button btnRefresh;
        private MultiImageButton btnRefresh;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.PictureBox extensionGrip;
        private System.Windows.Forms.PictureBox backgroundPic;
        private System.Windows.Forms.Timer timerRetryLogin;
        private System.Windows.Forms.PictureBox busyPicture;
        private MultiImageButton btnPause;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel pnlPaused;
        private System.Windows.Forms.Label lblImBack;
        private MultiImageToolStripMenuItem menuNew;
        private MultiImageToolStripMenuItem btnNewCase;
        private MultiImageToolStripMenuItem btnNewSubcase;
        private System.Windows.Forms.ToolStripMenuItem menuCurrentCase;
        private MultiImageToolStripMenuItem btnViewCase;
        private MultiImageToolStripMenuItem btnResolveClose;
        private MultiImageToolStripMenuItem btnResolve;
        private System.Windows.Forms.ToolStripMenuItem menuCurrentFilter;
        private MultiImageToolStripMenuItem btnExportFreeMind;
        private MultiImageToolStripMenuItem btnImportFreeMind;
        private MultiImageToolStripMenuItem btnExportExcel;
        private System.Windows.Forms.CheckBox KeepLoggingTimeChk;
    }
}
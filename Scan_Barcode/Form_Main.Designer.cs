namespace Scan_Barcode
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStartScan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStopScan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUnlock = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCameraDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemScanType = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemOutputConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStatust = new System.Windows.Forms.Button();
            this.labelListBoxSelectionIndex = new System.Windows.Forms.Label();
            this.textBoxDataShow = new System.Windows.Forms.TextBox();
            this.buttonDeleteBacodeRegion = new System.Windows.Forms.Button();
            this.buttonEditBacodeRegion = new System.Windows.Forms.Button();
            this.buttonAddBacodeRegion = new System.Windows.Forms.Button();
            this.listBoxSelectionBacodeRegion = new System.Windows.Forms.ListBox();
            this.labelLicenseKeyStatus = new System.Windows.Forms.Label();
            this.videoSourcePlayer_2 = new AForge.Controls.VideoSourcePlayer();
            this.videoSourcePlayer_1 = new AForge.Controls.VideoSourcePlayer();
            this.timerScan = new System.Windows.Forms.Timer(this.components);
            this.buttonStartScanForOutputTextFileType = new System.Windows.Forms.Button();
            this.timerAutoStop = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.ToolStripMenuItemSetup,
            this.toolStripMenuItemAbout});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(438, 24);
            this.menuStrip.TabIndex = 37;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemStartScan,
            this.toolStripMenuItemStopScan,
            this.toolStripMenuItemUnlock,
            this.toolStripMenuItemExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItemFile.Text = "&File";
            // 
            // toolStripMenuItemStartScan
            // 
            this.toolStripMenuItemStartScan.Name = "toolStripMenuItemStartScan";
            this.toolStripMenuItemStartScan.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemStartScan.Text = "&Start scan";
            this.toolStripMenuItemStartScan.Click += new System.EventHandler(this.toolStripMenuItemStartScan_Click);
            // 
            // toolStripMenuItemStopScan
            // 
            this.toolStripMenuItemStopScan.Name = "toolStripMenuItemStopScan";
            this.toolStripMenuItemStopScan.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemStopScan.Text = "S&top scan";
            this.toolStripMenuItemStopScan.Click += new System.EventHandler(this.toolStripMenuItemStopScan_Click);
            // 
            // toolStripMenuItemUnlock
            // 
            this.toolStripMenuItemUnlock.Name = "toolStripMenuItemUnlock";
            this.toolStripMenuItemUnlock.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemUnlock.Text = "Unlock";
            this.toolStripMenuItemUnlock.Click += new System.EventHandler(this.toolStripMenuItemUnlock_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemExit.Text = "&Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // ToolStripMenuItemSetup
            // 
            this.ToolStripMenuItemSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCameraDevice,
            this.toolStripMenuItemScanType,
            this.ToolStripMenuItemOutputConfig});
            this.ToolStripMenuItemSetup.Name = "ToolStripMenuItemSetup";
            this.ToolStripMenuItemSetup.Size = new System.Drawing.Size(49, 20);
            this.ToolStripMenuItemSetup.Text = "&Setup";
            // 
            // toolStripMenuItemCameraDevice
            // 
            this.toolStripMenuItemCameraDevice.Name = "toolStripMenuItemCameraDevice";
            this.toolStripMenuItemCameraDevice.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemCameraDevice.Text = "Camera &device";
            this.toolStripMenuItemCameraDevice.Click += new System.EventHandler(this.toolStripMenuItemCameraDevice_Click);
            // 
            // toolStripMenuItemScanType
            // 
            this.toolStripMenuItemScanType.Name = "toolStripMenuItemScanType";
            this.toolStripMenuItemScanType.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemScanType.Text = "Scan &type";
            this.toolStripMenuItemScanType.Click += new System.EventHandler(this.scanTypeToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemOutputConfig
            // 
            this.ToolStripMenuItemOutputConfig.Name = "ToolStripMenuItemOutputConfig";
            this.ToolStripMenuItemOutputConfig.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemOutputConfig.Text = "Output &config";
            this.ToolStripMenuItemOutputConfig.Click += new System.EventHandler(this.ToolStripMenuItemOutputConfig_Click);
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(52, 20);
            this.toolStripMenuItemAbout.Text = "&About";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // buttonStatust
            // 
            this.buttonStatust.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStatust.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonStatust.Location = new System.Drawing.Point(232, 338);
            this.buttonStatust.Name = "buttonStatust";
            this.buttonStatust.Size = new System.Drawing.Size(202, 33);
            this.buttonStatust.TabIndex = 58;
            this.buttonStatust.UseVisualStyleBackColor = true;
            // 
            // labelListBoxSelectionIndex
            // 
            this.labelListBoxSelectionIndex.AutoSize = true;
            this.labelListBoxSelectionIndex.Location = new System.Drawing.Point(3, 293);
            this.labelListBoxSelectionIndex.Name = "labelListBoxSelectionIndex";
            this.labelListBoxSelectionIndex.Size = new System.Drawing.Size(13, 39);
            this.labelListBoxSelectionIndex.TabIndex = 57;
            this.labelListBoxSelectionIndex.Text = "1\r\n2\r\n3\r\n";
            // 
            // textBoxDataShow
            // 
            this.textBoxDataShow.Enabled = false;
            this.textBoxDataShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDataShow.Location = new System.Drawing.Point(233, 292);
            this.textBoxDataShow.MaxLength = 100;
            this.textBoxDataShow.Multiline = true;
            this.textBoxDataShow.Name = "textBoxDataShow";
            this.textBoxDataShow.ReadOnly = true;
            this.textBoxDataShow.Size = new System.Drawing.Size(200, 43);
            this.textBoxDataShow.TabIndex = 56;
            // 
            // buttonDeleteBacodeRegion
            // 
            this.buttonDeleteBacodeRegion.Enabled = false;
            this.buttonDeleteBacodeRegion.Location = new System.Drawing.Point(158, 338);
            this.buttonDeleteBacodeRegion.Name = "buttonDeleteBacodeRegion";
            this.buttonDeleteBacodeRegion.Size = new System.Drawing.Size(70, 33);
            this.buttonDeleteBacodeRegion.TabIndex = 55;
            this.buttonDeleteBacodeRegion.Text = "Delete";
            this.buttonDeleteBacodeRegion.UseVisualStyleBackColor = true;
            this.buttonDeleteBacodeRegion.Click += new System.EventHandler(this.buttonDeleteBacodeRegion_Click);
            // 
            // buttonEditBacodeRegion
            // 
            this.buttonEditBacodeRegion.Enabled = false;
            this.buttonEditBacodeRegion.Location = new System.Drawing.Point(87, 338);
            this.buttonEditBacodeRegion.Name = "buttonEditBacodeRegion";
            this.buttonEditBacodeRegion.Size = new System.Drawing.Size(70, 33);
            this.buttonEditBacodeRegion.TabIndex = 54;
            this.buttonEditBacodeRegion.Text = "Edit";
            this.buttonEditBacodeRegion.UseVisualStyleBackColor = true;
            this.buttonEditBacodeRegion.Click += new System.EventHandler(this.buttonEditBacodeRegion_Click);
            // 
            // buttonAddBacodeRegion
            // 
            this.buttonAddBacodeRegion.Enabled = false;
            this.buttonAddBacodeRegion.Location = new System.Drawing.Point(16, 338);
            this.buttonAddBacodeRegion.Name = "buttonAddBacodeRegion";
            this.buttonAddBacodeRegion.Size = new System.Drawing.Size(70, 33);
            this.buttonAddBacodeRegion.TabIndex = 53;
            this.buttonAddBacodeRegion.Text = "Add";
            this.buttonAddBacodeRegion.UseVisualStyleBackColor = true;
            this.buttonAddBacodeRegion.Click += new System.EventHandler(this.buttonAddBacodeRegion_Click);
            // 
            // listBoxSelectionBacodeRegion
            // 
            this.listBoxSelectionBacodeRegion.FormattingEnabled = true;
            this.listBoxSelectionBacodeRegion.Location = new System.Drawing.Point(17, 292);
            this.listBoxSelectionBacodeRegion.Name = "listBoxSelectionBacodeRegion";
            this.listBoxSelectionBacodeRegion.Size = new System.Drawing.Size(210, 43);
            this.listBoxSelectionBacodeRegion.TabIndex = 52;
            // 
            // labelLicenseKeyStatus
            // 
            this.labelLicenseKeyStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLicenseKeyStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLicenseKeyStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelLicenseKeyStatus.Location = new System.Drawing.Point(143, 7);
            this.labelLicenseKeyStatus.Name = "labelLicenseKeyStatus";
            this.labelLicenseKeyStatus.Size = new System.Drawing.Size(291, 13);
            this.labelLicenseKeyStatus.TabIndex = 59;
            this.labelLicenseKeyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // videoSourcePlayer_2
            // 
            this.videoSourcePlayer_2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.videoSourcePlayer_2.Location = new System.Drawing.Point(5, 24);
            this.videoSourcePlayer_2.Name = "videoSourcePlayer_2";
            this.videoSourcePlayer_2.Size = new System.Drawing.Size(428, 266);
            this.videoSourcePlayer_2.TabIndex = 39;
            this.videoSourcePlayer_2.Text = "videoSourcePlayer_2";
            this.videoSourcePlayer_2.VideoSource = null;
            this.videoSourcePlayer_2.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer_2_NewFrame);
            this.videoSourcePlayer_2.Paint += new System.Windows.Forms.PaintEventHandler(this.videoSourcePlayer_X_Paint);
            this.videoSourcePlayer_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_X_MouseDown);
            this.videoSourcePlayer_2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_X_MouseMove);
            this.videoSourcePlayer_2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_X_MouseUp);
            // 
            // videoSourcePlayer_1
            // 
            this.videoSourcePlayer_1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.videoSourcePlayer_1.Location = new System.Drawing.Point(5, 24);
            this.videoSourcePlayer_1.Name = "videoSourcePlayer_1";
            this.videoSourcePlayer_1.Size = new System.Drawing.Size(428, 266);
            this.videoSourcePlayer_1.TabIndex = 38;
            this.videoSourcePlayer_1.Text = "videoSourcePlayer_1";
            this.videoSourcePlayer_1.VideoSource = null;
            this.videoSourcePlayer_1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer_1_NewFrame);
            this.videoSourcePlayer_1.Paint += new System.Windows.Forms.PaintEventHandler(this.videoSourcePlayer_X_Paint);
            this.videoSourcePlayer_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_X_MouseDown);
            this.videoSourcePlayer_1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_X_MouseMove);
            this.videoSourcePlayer_1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_X_MouseUp);
            // 
            // timerScan
            // 
            this.timerScan.Interval = 300;
            this.timerScan.Tick += new System.EventHandler(this.timerScan_Tick);
            // 
            // buttonStartScanForOutputTextFileType
            // 
            this.buttonStartScanForOutputTextFileType.Location = new System.Drawing.Point(5, 24);
            this.buttonStartScanForOutputTextFileType.Name = "buttonStartScanForOutputTextFileType";
            this.buttonStartScanForOutputTextFileType.Size = new System.Drawing.Size(90, 23);
            this.buttonStartScanForOutputTextFileType.TabIndex = 60;
            this.buttonStartScanForOutputTextFileType.Text = "START_SCAN";
            this.buttonStartScanForOutputTextFileType.UseVisualStyleBackColor = true;
            this.buttonStartScanForOutputTextFileType.Click += new System.EventHandler(this.toolStripMenuItemStartScan_Click);
            // 
            // timerAutoStop
            // 
            this.timerAutoStop.Interval = 30000;
            this.timerAutoStop.Tick += new System.EventHandler(this.timerAutoStop_Tick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 374);
            this.Controls.Add(this.labelLicenseKeyStatus);
            this.Controls.Add(this.buttonStatust);
            this.Controls.Add(this.labelListBoxSelectionIndex);
            this.Controls.Add(this.textBoxDataShow);
            this.Controls.Add(this.buttonDeleteBacodeRegion);
            this.Controls.Add(this.buttonEditBacodeRegion);
            this.Controls.Add(this.buttonAddBacodeRegion);
            this.Controls.Add(this.listBoxSelectionBacodeRegion);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.videoSourcePlayer_1);
            this.Controls.Add(this.videoSourcePlayer_2);
            this.Controls.Add(this.buttonStartScanForOutputTextFileType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan_Barcode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStartScan;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStopScan;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetup;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCameraDevice;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOutputConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.Label labelLicenseKeyStatus;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer_2;
        private System.Windows.Forms.Button buttonStatust;
        private System.Windows.Forms.Label labelListBoxSelectionIndex;
        private System.Windows.Forms.TextBox textBoxDataShow;
        private System.Windows.Forms.Button buttonDeleteBacodeRegion;
        private System.Windows.Forms.Button buttonEditBacodeRegion;
        private System.Windows.Forms.Button buttonAddBacodeRegion;
        private System.Windows.Forms.ListBox listBoxSelectionBacodeRegion;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer_1;
        private System.Windows.Forms.Timer timerScan;
        private System.Windows.Forms.Button buttonStartScanForOutputTextFileType;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScanType;
        private System.Windows.Forms.Timer timerAutoStop;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUnlock;
    }
}


namespace Scan_Barcode_Dual
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
            this.timerScan_1 = new System.Windows.Forms.Timer(this.components);
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
            this.listBoxSelectionBacodeRegion_1 = new System.Windows.Forms.ListBox();
            this.buttonROIBacodeRegion_1 = new System.Windows.Forms.Button();
            this.textBoxDataShow_1 = new System.Windows.Forms.TextBox();
            this.labelListBoxSelectionIndex_1 = new System.Windows.Forms.Label();
            this.labelListBoxSelectionIndex_2 = new System.Windows.Forms.Label();
            this.textBoxDataShow_2 = new System.Windows.Forms.TextBox();
            this.buttonROIBacodeRegion_2 = new System.Windows.Forms.Button();
            this.listBoxSelectionBacodeRegion_2 = new System.Windows.Forms.ListBox();
            this.timerScan_2 = new System.Windows.Forms.Timer(this.components);
            this.buttonStatust_1 = new System.Windows.Forms.Button();
            this.buttonStatust_2 = new System.Windows.Forms.Button();
            this.videoSourcePlayer_1 = new AForge.Controls.VideoSourcePlayer();
            this.videoSourcePlayer_2 = new AForge.Controls.VideoSourcePlayer();
            this.buttonStartScanForOutputTextFileType = new System.Windows.Forms.Button();
            this.labelLicenseKeyStatus = new System.Windows.Forms.Label();
            this.timerAutoStop = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerScan_1
            // 
            this.timerScan_1.Interval = 300;
            this.timerScan_1.Tick += new System.EventHandler(this.timerScan_1_Tick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.ToolStripMenuItemSetup,
            this.toolStripMenuItemAbout});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(872, 24);
            this.menuStrip.TabIndex = 36;
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
            this.toolStripMenuItemStartScan.Size = new System.Drawing.Size(125, 22);
            this.toolStripMenuItemStartScan.Text = "&Start scan";
            this.toolStripMenuItemStartScan.Click += new System.EventHandler(this.toolStripMenuItemStartScan_Click);
            // 
            // toolStripMenuItemStopScan
            // 
            this.toolStripMenuItemStopScan.Name = "toolStripMenuItemStopScan";
            this.toolStripMenuItemStopScan.Size = new System.Drawing.Size(125, 22);
            this.toolStripMenuItemStopScan.Text = "S&top scan";
            this.toolStripMenuItemStopScan.Click += new System.EventHandler(this.toolStripMenuItemStopScan_Click);
            // 
            // toolStripMenuItemUnlock
            // 
            this.toolStripMenuItemUnlock.Name = "toolStripMenuItemUnlock";
            this.toolStripMenuItemUnlock.Size = new System.Drawing.Size(125, 22);
            this.toolStripMenuItemUnlock.Text = "Unlock";
            this.toolStripMenuItemUnlock.Click += new System.EventHandler(this.toolStripMenuItemUnlock_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(125, 22);
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
            this.toolStripMenuItemScanType.Click += new System.EventHandler(this.toolStripMenuItemScanType_Click);
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
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click_1);
            // 
            // listBoxSelectionBacodeRegion_1
            // 
            this.listBoxSelectionBacodeRegion_1.FormattingEnabled = true;
            this.listBoxSelectionBacodeRegion_1.Location = new System.Drawing.Point(23, 293);
            this.listBoxSelectionBacodeRegion_1.Name = "listBoxSelectionBacodeRegion_1";
            this.listBoxSelectionBacodeRegion_1.Size = new System.Drawing.Size(199, 43);
            this.listBoxSelectionBacodeRegion_1.TabIndex = 39;
            // 
            // buttonROIBacodeRegion_1
            // 
            this.buttonROIBacodeRegion_1.Enabled = false;
            this.buttonROIBacodeRegion_1.Location = new System.Drawing.Point(23, 339);
            this.buttonROIBacodeRegion_1.Name = "buttonROIBacodeRegion_1";
            this.buttonROIBacodeRegion_1.Size = new System.Drawing.Size(199, 31);
            this.buttonROIBacodeRegion_1.TabIndex = 42;
            this.buttonROIBacodeRegion_1.Text = "ROI";
            this.buttonROIBacodeRegion_1.UseVisualStyleBackColor = true;
            this.buttonROIBacodeRegion_1.Click += new System.EventHandler(this.buttonROI_1_Click);
            // 
            // textBoxDataShow_1
            // 
            this.textBoxDataShow_1.Location = new System.Drawing.Point(233, 293);
            this.textBoxDataShow_1.MaxLength = 100;
            this.textBoxDataShow_1.Multiline = true;
            this.textBoxDataShow_1.Name = "textBoxDataShow_1";
            this.textBoxDataShow_1.ReadOnly = true;
            this.textBoxDataShow_1.Size = new System.Drawing.Size(199, 43);
            this.textBoxDataShow_1.TabIndex = 44;
            // 
            // labelListBoxSelectionIndex_1
            // 
            this.labelListBoxSelectionIndex_1.AutoSize = true;
            this.labelListBoxSelectionIndex_1.Location = new System.Drawing.Point(0, 295);
            this.labelListBoxSelectionIndex_1.Name = "labelListBoxSelectionIndex_1";
            this.labelListBoxSelectionIndex_1.Size = new System.Drawing.Size(22, 26);
            this.labelListBoxSelectionIndex_1.TabIndex = 50;
            this.labelListBoxSelectionIndex_1.Text = "SN\r\nLo";
            // 
            // labelListBoxSelectionIndex_2
            // 
            this.labelListBoxSelectionIndex_2.AutoSize = true;
            this.labelListBoxSelectionIndex_2.Location = new System.Drawing.Point(436, 295);
            this.labelListBoxSelectionIndex_2.Name = "labelListBoxSelectionIndex_2";
            this.labelListBoxSelectionIndex_2.Size = new System.Drawing.Size(22, 13);
            this.labelListBoxSelectionIndex_2.TabIndex = 72;
            this.labelListBoxSelectionIndex_2.Text = "SN";
            // 
            // textBoxDataShow_2
            // 
            this.textBoxDataShow_2.Location = new System.Drawing.Point(669, 293);
            this.textBoxDataShow_2.MaxLength = 100;
            this.textBoxDataShow_2.Multiline = true;
            this.textBoxDataShow_2.Name = "textBoxDataShow_2";
            this.textBoxDataShow_2.ReadOnly = true;
            this.textBoxDataShow_2.Size = new System.Drawing.Size(199, 43);
            this.textBoxDataShow_2.TabIndex = 68;
            // 
            // buttonROIBacodeRegion_2
            // 
            this.buttonROIBacodeRegion_2.Enabled = false;
            this.buttonROIBacodeRegion_2.Location = new System.Drawing.Point(459, 339);
            this.buttonROIBacodeRegion_2.Name = "buttonROIBacodeRegion_2";
            this.buttonROIBacodeRegion_2.Size = new System.Drawing.Size(199, 31);
            this.buttonROIBacodeRegion_2.TabIndex = 66;
            this.buttonROIBacodeRegion_2.Text = "ROI";
            this.buttonROIBacodeRegion_2.UseVisualStyleBackColor = true;
            this.buttonROIBacodeRegion_2.Click += new System.EventHandler(this.buttonROI_2_Click);
            // 
            // listBoxSelectionBacodeRegion_2
            // 
            this.listBoxSelectionBacodeRegion_2.FormattingEnabled = true;
            this.listBoxSelectionBacodeRegion_2.Location = new System.Drawing.Point(459, 293);
            this.listBoxSelectionBacodeRegion_2.Name = "listBoxSelectionBacodeRegion_2";
            this.listBoxSelectionBacodeRegion_2.Size = new System.Drawing.Size(199, 43);
            this.listBoxSelectionBacodeRegion_2.TabIndex = 64;
            // 
            // timerScan_2
            // 
            this.timerScan_2.Interval = 300;
            this.timerScan_2.Tick += new System.EventHandler(this.timerScan_2_Tick);
            // 
            // buttonStatust_1
            // 
            this.buttonStatust_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStatust_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonStatust_1.Location = new System.Drawing.Point(233, 339);
            this.buttonStatust_1.Name = "buttonStatust_1";
            this.buttonStatust_1.Size = new System.Drawing.Size(199, 31);
            this.buttonStatust_1.TabIndex = 73;
            this.buttonStatust_1.Text = "Scaning";
            this.buttonStatust_1.UseVisualStyleBackColor = true;
            // 
            // buttonStatust_2
            // 
            this.buttonStatust_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStatust_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonStatust_2.Location = new System.Drawing.Point(669, 339);
            this.buttonStatust_2.Name = "buttonStatust_2";
            this.buttonStatust_2.Size = new System.Drawing.Size(199, 31);
            this.buttonStatust_2.TabIndex = 74;
            this.buttonStatust_2.Text = "Scaning";
            this.buttonStatust_2.UseVisualStyleBackColor = true;
            // 
            // videoSourcePlayer_1
            // 
            this.videoSourcePlayer_1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer_1.Location = new System.Drawing.Point(4, 24);
            this.videoSourcePlayer_1.Name = "videoSourcePlayer_1";
            this.videoSourcePlayer_1.Size = new System.Drawing.Size(428, 266);
            this.videoSourcePlayer_1.TabIndex = 75;
            this.videoSourcePlayer_1.Text = "videoSourcePlayer_1";
            this.videoSourcePlayer_1.VideoSource = null;
            this.videoSourcePlayer_1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer_1_NewFrame);
            this.videoSourcePlayer_1.Paint += new System.Windows.Forms.PaintEventHandler(this.videoSourcePlayer_1_Paint);
            this.videoSourcePlayer_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_1_MouseDown);
            this.videoSourcePlayer_1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_1_MouseMove);
            this.videoSourcePlayer_1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_1_MouseUp);
            // 
            // videoSourcePlayer_2
            // 
            this.videoSourcePlayer_2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer_2.Location = new System.Drawing.Point(440, 24);
            this.videoSourcePlayer_2.Name = "videoSourcePlayer_2";
            this.videoSourcePlayer_2.Size = new System.Drawing.Size(428, 266);
            this.videoSourcePlayer_2.TabIndex = 76;
            this.videoSourcePlayer_2.Text = "videoSourcePlayer_2";
            this.videoSourcePlayer_2.VideoSource = null;
            this.videoSourcePlayer_2.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer_2_NewFrame);
            this.videoSourcePlayer_2.Paint += new System.Windows.Forms.PaintEventHandler(this.videoSourcePlayer_2_Paint);
            this.videoSourcePlayer_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_2_MouseDown);
            this.videoSourcePlayer_2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_2_MouseMove);
            this.videoSourcePlayer_2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer_2_MouseUp);
            // 
            // buttonStartScanForOutputTextFileType
            // 
            this.buttonStartScanForOutputTextFileType.Location = new System.Drawing.Point(12, 27);
            this.buttonStartScanForOutputTextFileType.Name = "buttonStartScanForOutputTextFileType";
            this.buttonStartScanForOutputTextFileType.Size = new System.Drawing.Size(62, 33);
            this.buttonStartScanForOutputTextFileType.TabIndex = 77;
            this.buttonStartScanForOutputTextFileType.Text = "START_SCAN";
            this.buttonStartScanForOutputTextFileType.UseVisualStyleBackColor = true;
            this.buttonStartScanForOutputTextFileType.Click += new System.EventHandler(this.toolStripMenuItemStartScan_Click);
            // 
            // labelLicenseKeyStatus
            // 
            this.labelLicenseKeyStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLicenseKeyStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLicenseKeyStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelLicenseKeyStatus.Location = new System.Drawing.Point(440, 6);
            this.labelLicenseKeyStatus.Name = "labelLicenseKeyStatus";
            this.labelLicenseKeyStatus.Size = new System.Drawing.Size(428, 15);
            this.labelLicenseKeyStatus.TabIndex = 78;
            this.labelLicenseKeyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.ClientSize = new System.Drawing.Size(872, 373);
            this.Controls.Add(this.videoSourcePlayer_1);
            this.Controls.Add(this.labelLicenseKeyStatus);
            this.Controls.Add(this.videoSourcePlayer_2);
            this.Controls.Add(this.buttonStatust_2);
            this.Controls.Add(this.buttonStatust_1);
            this.Controls.Add(this.labelListBoxSelectionIndex_2);
            this.Controls.Add(this.labelListBoxSelectionIndex_1);
            this.Controls.Add(this.textBoxDataShow_2);
            this.Controls.Add(this.buttonROIBacodeRegion_2);
            this.Controls.Add(this.textBoxDataShow_1);
            this.Controls.Add(this.listBoxSelectionBacodeRegion_2);
            this.Controls.Add(this.buttonROIBacodeRegion_1);
            this.Controls.Add(this.listBoxSelectionBacodeRegion_1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.buttonStartScanForOutputTextFileType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan_Barcode_Dual";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerScan_1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ListBox listBoxSelectionBacodeRegion_1;
        private System.Windows.Forms.Button buttonROIBacodeRegion_1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.TextBox textBoxDataShow_1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStartScan;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStopScan;
        private System.Windows.Forms.Label labelListBoxSelectionIndex_1;
        private System.Windows.Forms.Label labelListBoxSelectionIndex_2;
        private System.Windows.Forms.TextBox textBoxDataShow_2;
        private System.Windows.Forms.Button buttonROIBacodeRegion_2;
        private System.Windows.Forms.ListBox listBoxSelectionBacodeRegion_2;
        private System.Windows.Forms.Timer timerScan_2;
        private System.Windows.Forms.Button buttonStatust_1;
        private System.Windows.Forms.Button buttonStatust_2;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer_1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer_2;
        private System.Windows.Forms.Button buttonStartScanForOutputTextFileType;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUnlock;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetup;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCameraDevice;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScanType;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOutputConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.Label labelLicenseKeyStatus;
        private System.Windows.Forms.Timer timerAutoStop;
    }
}


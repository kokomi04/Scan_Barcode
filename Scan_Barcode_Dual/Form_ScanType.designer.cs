namespace Scan_Barcode_Dual
{
    partial class Form_ScanType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ScanType));
            this.groupBoxScanModules = new System.Windows.Forms.GroupBox();
            this.radioButtonBacodeLib = new System.Windows.Forms.RadioButton();
            this.radioButtonDynamsoft = new System.Windows.Forms.RadioButton();
            this.radioButtonZxing = new System.Windows.Forms.RadioButton();
            this.groupBoxAutoStopCamera = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoStopAfter30s = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoStopAfterScanFinished = new System.Windows.Forms.CheckBox();
            this.groupBoxDataFormat = new System.Windows.Forms.GroupBox();
            this.labelDescribe = new System.Windows.Forms.Label();
            this.checkBoxAutoSearchBacode = new System.Windows.Forms.CheckBox();
            this.groupBoxScanModules.SuspendLayout();
            this.groupBoxAutoStopCamera.SuspendLayout();
            this.groupBoxDataFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxScanModules
            // 
            this.groupBoxScanModules.Controls.Add(this.radioButtonBacodeLib);
            this.groupBoxScanModules.Controls.Add(this.radioButtonDynamsoft);
            this.groupBoxScanModules.Controls.Add(this.radioButtonZxing);
            this.groupBoxScanModules.Location = new System.Drawing.Point(5, -1);
            this.groupBoxScanModules.Name = "groupBoxScanModules";
            this.groupBoxScanModules.Size = new System.Drawing.Size(104, 75);
            this.groupBoxScanModules.TabIndex = 0;
            this.groupBoxScanModules.TabStop = false;
            this.groupBoxScanModules.Text = "Scan modules";
            // 
            // radioButtonBacodeLib
            // 
            this.radioButtonBacodeLib.AutoSize = true;
            this.radioButtonBacodeLib.Location = new System.Drawing.Point(6, 53);
            this.radioButtonBacodeLib.Name = "radioButtonBacodeLib";
            this.radioButtonBacodeLib.Size = new System.Drawing.Size(76, 17);
            this.radioButtonBacodeLib.TabIndex = 2;
            this.radioButtonBacodeLib.Text = "BacodeLib";
            this.radioButtonBacodeLib.UseVisualStyleBackColor = true;
            this.radioButtonBacodeLib.CheckedChanged += new System.EventHandler(this.radioButtonScanModules_CheckedChanged);
            // 
            // radioButtonDynamsoft
            // 
            this.radioButtonDynamsoft.AutoSize = true;
            this.radioButtonDynamsoft.Location = new System.Drawing.Point(6, 34);
            this.radioButtonDynamsoft.Name = "radioButtonDynamsoft";
            this.radioButtonDynamsoft.Size = new System.Drawing.Size(75, 17);
            this.radioButtonDynamsoft.TabIndex = 1;
            this.radioButtonDynamsoft.Text = "Dynamsoft";
            this.radioButtonDynamsoft.UseVisualStyleBackColor = true;
            this.radioButtonDynamsoft.CheckedChanged += new System.EventHandler(this.radioButtonScanModules_CheckedChanged);
            // 
            // radioButtonZxing
            // 
            this.radioButtonZxing.AutoSize = true;
            this.radioButtonZxing.Location = new System.Drawing.Point(6, 15);
            this.radioButtonZxing.Name = "radioButtonZxing";
            this.radioButtonZxing.Size = new System.Drawing.Size(51, 17);
            this.radioButtonZxing.TabIndex = 0;
            this.radioButtonZxing.Text = "Zxing";
            this.radioButtonZxing.UseVisualStyleBackColor = true;
            this.radioButtonZxing.CheckedChanged += new System.EventHandler(this.radioButtonScanModules_CheckedChanged);
            // 
            // groupBoxAutoStopCamera
            // 
            this.groupBoxAutoStopCamera.Controls.Add(this.checkBoxAutoStopAfter30s);
            this.groupBoxAutoStopCamera.Controls.Add(this.checkBoxAutoStopAfterScanFinished);
            this.groupBoxAutoStopCamera.Location = new System.Drawing.Point(118, -1);
            this.groupBoxAutoStopCamera.Name = "groupBoxAutoStopCamera";
            this.groupBoxAutoStopCamera.Size = new System.Drawing.Size(176, 75);
            this.groupBoxAutoStopCamera.TabIndex = 1;
            this.groupBoxAutoStopCamera.TabStop = false;
            this.groupBoxAutoStopCamera.Text = "Auto stop camrea";
            // 
            // checkBoxAutoStopAfter30s
            // 
            this.checkBoxAutoStopAfter30s.AutoSize = true;
            this.checkBoxAutoStopAfter30s.Checked = true;
            this.checkBoxAutoStopAfter30s.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoStopAfter30s.Location = new System.Drawing.Point(6, 46);
            this.checkBoxAutoStopAfter30s.Name = "checkBoxAutoStopAfter30s";
            this.checkBoxAutoStopAfter30s.Size = new System.Drawing.Size(115, 17);
            this.checkBoxAutoStopAfter30s.TabIndex = 1;
            this.checkBoxAutoStopAfter30s.Text = "Auto stop after 30s";
            this.checkBoxAutoStopAfter30s.UseVisualStyleBackColor = true;
            this.checkBoxAutoStopAfter30s.Click += new System.EventHandler(this.checkBoxAutoStopAfter30s_Click);
            // 
            // checkBoxAutoStopAfterScanFinished
            // 
            this.checkBoxAutoStopAfterScanFinished.AutoSize = true;
            this.checkBoxAutoStopAfterScanFinished.Checked = true;
            this.checkBoxAutoStopAfterScanFinished.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoStopAfterScanFinished.Location = new System.Drawing.Point(6, 22);
            this.checkBoxAutoStopAfterScanFinished.Name = "checkBoxAutoStopAfterScanFinished";
            this.checkBoxAutoStopAfterScanFinished.Size = new System.Drawing.Size(160, 17);
            this.checkBoxAutoStopAfterScanFinished.TabIndex = 0;
            this.checkBoxAutoStopAfterScanFinished.Text = "Auto stop after scan finished";
            this.checkBoxAutoStopAfterScanFinished.UseVisualStyleBackColor = true;
            this.checkBoxAutoStopAfterScanFinished.Click += new System.EventHandler(this.checkBoxAutoStopAfterScanFinished_Click);
            // 
            // groupBoxDataFormat
            // 
            this.groupBoxDataFormat.Controls.Add(this.labelDescribe);
            this.groupBoxDataFormat.Controls.Add(this.checkBoxAutoSearchBacode);
            this.groupBoxDataFormat.Location = new System.Drawing.Point(5, 73);
            this.groupBoxDataFormat.Name = "groupBoxDataFormat";
            this.groupBoxDataFormat.Size = new System.Drawing.Size(289, 90);
            this.groupBoxDataFormat.TabIndex = 2;
            this.groupBoxDataFormat.TabStop = false;
            this.groupBoxDataFormat.Text = "Auto search bacode";
            // 
            // labelDescribe
            // 
            this.labelDescribe.AutoSize = true;
            this.labelDescribe.ForeColor = System.Drawing.Color.Red;
            this.labelDescribe.Location = new System.Drawing.Point(24, 35);
            this.labelDescribe.Name = "labelDescribe";
            this.labelDescribe.Size = new System.Drawing.Size(242, 52);
            this.labelDescribe.TabIndex = 7;
            this.labelDescribe.Text = "If you checked \"Auto search bacode\"\r\nThen program only read the first bacode in t" +
    "he list.\r\nThe must be setup check bacode and using\r\nDynamsoft or BarcodeLib scan" +
    " module.\r\n";
            // 
            // checkBoxAutoSearchBacode
            // 
            this.checkBoxAutoSearchBacode.AutoSize = true;
            this.checkBoxAutoSearchBacode.Location = new System.Drawing.Point(8, 20);
            this.checkBoxAutoSearchBacode.Name = "checkBoxAutoSearchBacode";
            this.checkBoxAutoSearchBacode.Size = new System.Drawing.Size(122, 17);
            this.checkBoxAutoSearchBacode.TabIndex = 0;
            this.checkBoxAutoSearchBacode.Text = "Auto search bacode";
            this.checkBoxAutoSearchBacode.UseVisualStyleBackColor = true;
            this.checkBoxAutoSearchBacode.Click += new System.EventHandler(this.checkBoxAutoSearchBacode_Click);
            // 
            // Form_ScanType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 166);
            this.Controls.Add(this.groupBoxDataFormat);
            this.Controls.Add(this.groupBoxAutoStopCamera);
            this.Controls.Add(this.groupBoxScanModules);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ScanType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan type";
            this.Load += new System.EventHandler(this.Form_ScanType_Load);
            this.groupBoxScanModules.ResumeLayout(false);
            this.groupBoxScanModules.PerformLayout();
            this.groupBoxAutoStopCamera.ResumeLayout(false);
            this.groupBoxAutoStopCamera.PerformLayout();
            this.groupBoxDataFormat.ResumeLayout(false);
            this.groupBoxDataFormat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxScanModules;
        private System.Windows.Forms.RadioButton radioButtonBacodeLib;
        private System.Windows.Forms.RadioButton radioButtonDynamsoft;
        private System.Windows.Forms.RadioButton radioButtonZxing;
        private System.Windows.Forms.GroupBox groupBoxAutoStopCamera;
        private System.Windows.Forms.CheckBox checkBoxAutoStopAfterScanFinished;
        private System.Windows.Forms.CheckBox checkBoxAutoStopAfter30s;
        private System.Windows.Forms.GroupBox groupBoxDataFormat;
        private System.Windows.Forms.Label labelDescribe;
        private System.Windows.Forms.CheckBox checkBoxAutoSearchBacode;
    }
}
namespace Scan_Barcode_Dual
{
    partial class Form_CameraDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CameraDevice));
            this.labelCamera_2 = new System.Windows.Forms.Label();
            this.labelCamera_1 = new System.Windows.Forms.Label();
            this.comboBoxCamera_2 = new System.Windows.Forms.ComboBox();
            this.comboBoxCamera_1 = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCamera_2
            // 
            this.labelCamera_2.AutoSize = true;
            this.labelCamera_2.Location = new System.Drawing.Point(7, 35);
            this.labelCamera_2.Name = "labelCamera_2";
            this.labelCamera_2.Size = new System.Drawing.Size(52, 13);
            this.labelCamera_2.TabIndex = 18;
            this.labelCamera_2.Text = "Camera 2";
            // 
            // labelCamera_1
            // 
            this.labelCamera_1.AutoSize = true;
            this.labelCamera_1.Location = new System.Drawing.Point(7, 11);
            this.labelCamera_1.Name = "labelCamera_1";
            this.labelCamera_1.Size = new System.Drawing.Size(52, 13);
            this.labelCamera_1.TabIndex = 17;
            this.labelCamera_1.Text = "Camera 1";
            // 
            // comboBoxCamera_2
            // 
            this.comboBoxCamera_2.FormattingEnabled = true;
            this.comboBoxCamera_2.Location = new System.Drawing.Point(65, 32);
            this.comboBoxCamera_2.Name = "comboBoxCamera_2";
            this.comboBoxCamera_2.Size = new System.Drawing.Size(160, 21);
            this.comboBoxCamera_2.TabIndex = 16;
            // 
            // comboBoxCamera_1
            // 
            this.comboBoxCamera_1.FormattingEnabled = true;
            this.comboBoxCamera_1.Location = new System.Drawing.Point(65, 8);
            this.comboBoxCamera_1.Name = "comboBoxCamera_1";
            this.comboBoxCamera_1.Size = new System.Drawing.Size(160, 21);
            this.comboBoxCamera_1.TabIndex = 13;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(231, 32);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(63, 23);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(231, 7);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(63, 23);
            this.buttonRefresh.TabIndex = 14;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.Form_CameraDevice_Load);
            // 
            // Form_CameraDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 62);
            this.Controls.Add(this.labelCamera_2);
            this.Controls.Add(this.labelCamera_1);
            this.Controls.Add(this.comboBoxCamera_2);
            this.Controls.Add(this.comboBoxCamera_1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_CameraDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camera device";
            this.Load += new System.EventHandler(this.Form_CameraDevice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCamera_2;
        private System.Windows.Forms.Label labelCamera_1;
        private System.Windows.Forms.ComboBox comboBoxCamera_2;
        private System.Windows.Forms.ComboBox comboBoxCamera_1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonRefresh;
    }
}
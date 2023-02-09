namespace Scan_Barcode
{
    partial class Form_OutputConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_OutputConfig));
            this.groupBoxOutputType = new System.Windows.Forms.GroupBox();
            this.labelOutputParameter = new System.Windows.Forms.Label();
            this.buttonOutputTypeApply = new System.Windows.Forms.Button();
            this.textBoxOutputParameter = new System.Windows.Forms.TextBox();
            this.radioButton_UDPServer = new System.Windows.Forms.RadioButton();
            this.radioButton_TCPServer = new System.Windows.Forms.RadioButton();
            this.radioButton_TextFile = new System.Windows.Forms.RadioButton();
            this.groupBoxDataFormat = new System.Windows.Forms.GroupBox();
            this.labelDescribe = new System.Windows.Forms.Label();
            this.checkBoxRemoveNoBarcode = new System.Windows.Forms.CheckBox();
            this.groupBoxOutputType.SuspendLayout();
            this.groupBoxDataFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxOutputType
            // 
            this.groupBoxOutputType.Controls.Add(this.labelOutputParameter);
            this.groupBoxOutputType.Controls.Add(this.buttonOutputTypeApply);
            this.groupBoxOutputType.Controls.Add(this.textBoxOutputParameter);
            this.groupBoxOutputType.Controls.Add(this.radioButton_UDPServer);
            this.groupBoxOutputType.Controls.Add(this.radioButton_TCPServer);
            this.groupBoxOutputType.Controls.Add(this.radioButton_TextFile);
            this.groupBoxOutputType.Location = new System.Drawing.Point(4, -2);
            this.groupBoxOutputType.Name = "groupBoxOutputType";
            this.groupBoxOutputType.Size = new System.Drawing.Size(267, 69);
            this.groupBoxOutputType.TabIndex = 0;
            this.groupBoxOutputType.TabStop = false;
            this.groupBoxOutputType.Text = "Output type";
            // 
            // labelOutputParameter
            // 
            this.labelOutputParameter.AutoSize = true;
            this.labelOutputParameter.Location = new System.Drawing.Point(5, 44);
            this.labelOutputParameter.Name = "labelOutputParameter";
            this.labelOutputParameter.Size = new System.Drawing.Size(52, 13);
            this.labelOutputParameter.TabIndex = 5;
            this.labelOutputParameter.Text = "File name";
            // 
            // buttonOutputTypeApply
            // 
            this.buttonOutputTypeApply.Location = new System.Drawing.Point(213, 39);
            this.buttonOutputTypeApply.Name = "buttonOutputTypeApply";
            this.buttonOutputTypeApply.Size = new System.Drawing.Size(48, 23);
            this.buttonOutputTypeApply.TabIndex = 4;
            this.buttonOutputTypeApply.Text = "Apply";
            this.buttonOutputTypeApply.UseVisualStyleBackColor = true;
            this.buttonOutputTypeApply.Click += new System.EventHandler(this.buttonOutputTypeApply_Click);
            // 
            // textBoxOutputParameter
            // 
            this.textBoxOutputParameter.Location = new System.Drawing.Point(69, 41);
            this.textBoxOutputParameter.Name = "textBoxOutputParameter";
            this.textBoxOutputParameter.Size = new System.Drawing.Size(138, 20);
            this.textBoxOutputParameter.TabIndex = 3;
            // 
            // radioButton_UDPServer
            // 
            this.radioButton_UDPServer.AutoSize = true;
            this.radioButton_UDPServer.Location = new System.Drawing.Point(178, 16);
            this.radioButton_UDPServer.Name = "radioButton_UDPServer";
            this.radioButton_UDPServer.Size = new System.Drawing.Size(80, 17);
            this.radioButton_UDPServer.TabIndex = 2;
            this.radioButton_UDPServer.Text = "UDP server";
            this.radioButton_UDPServer.UseVisualStyleBackColor = true;
            this.radioButton_UDPServer.Visible = false;
            this.radioButton_UDPServer.Click += new System.EventHandler(this.radioButton_TextFile_Click);
            // 
            // radioButton_TCPServer
            // 
            this.radioButton_TCPServer.AutoSize = true;
            this.radioButton_TCPServer.Location = new System.Drawing.Point(85, 16);
            this.radioButton_TCPServer.Name = "radioButton_TCPServer";
            this.radioButton_TCPServer.Size = new System.Drawing.Size(78, 17);
            this.radioButton_TCPServer.TabIndex = 1;
            this.radioButton_TCPServer.Text = "TCP server";
            this.radioButton_TCPServer.UseVisualStyleBackColor = true;
            this.radioButton_TCPServer.Visible = false;
            this.radioButton_TCPServer.Click += new System.EventHandler(this.radioButton_TextFile_Click);
            // 
            // radioButton_TextFile
            // 
            this.radioButton_TextFile.AutoSize = true;
            this.radioButton_TextFile.Checked = true;
            this.radioButton_TextFile.Location = new System.Drawing.Point(8, 16);
            this.radioButton_TextFile.Name = "radioButton_TextFile";
            this.radioButton_TextFile.Size = new System.Drawing.Size(62, 17);
            this.radioButton_TextFile.TabIndex = 0;
            this.radioButton_TextFile.TabStop = true;
            this.radioButton_TextFile.Text = "Text file";
            this.radioButton_TextFile.UseVisualStyleBackColor = true;
            this.radioButton_TextFile.Click += new System.EventHandler(this.radioButton_TextFile_Click);
            // 
            // groupBoxDataFormat
            // 
            this.groupBoxDataFormat.Controls.Add(this.labelDescribe);
            this.groupBoxDataFormat.Controls.Add(this.checkBoxRemoveNoBarcode);
            this.groupBoxDataFormat.Location = new System.Drawing.Point(4, 66);
            this.groupBoxDataFormat.Name = "groupBoxDataFormat";
            this.groupBoxDataFormat.Size = new System.Drawing.Size(267, 73);
            this.groupBoxDataFormat.TabIndex = 1;
            this.groupBoxDataFormat.TabStop = false;
            this.groupBoxDataFormat.Text = "Data format";
            // 
            // labelDescribe
            // 
            this.labelDescribe.AutoSize = true;
            this.labelDescribe.ForeColor = System.Drawing.Color.Red;
            this.labelDescribe.Location = new System.Drawing.Point(24, 40);
            this.labelDescribe.Name = "labelDescribe";
            this.labelDescribe.Size = new System.Drawing.Size(201, 26);
            this.labelDescribe.TabIndex = 7;
            this.labelDescribe.Text = "If you checked \"Remove no barcode\" \r\nThen only read the first bacode in the list!" +
    "";
            // 
            // checkBoxRemoveNoBarcode
            // 
            this.checkBoxRemoveNoBarcode.AutoSize = true;
            this.checkBoxRemoveNoBarcode.Location = new System.Drawing.Point(8, 20);
            this.checkBoxRemoveNoBarcode.Name = "checkBoxRemoveNoBarcode";
            this.checkBoxRemoveNoBarcode.Size = new System.Drawing.Size(123, 17);
            this.checkBoxRemoveNoBarcode.TabIndex = 0;
            this.checkBoxRemoveNoBarcode.Text = "Remove no barcode";
            this.checkBoxRemoveNoBarcode.UseVisualStyleBackColor = true;
            this.checkBoxRemoveNoBarcode.CheckedChanged += new System.EventHandler(this.checkBoxRemoveNoBarcode_CheckedChanged);
            // 
            // Form_OutputConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 143);
            this.Controls.Add(this.groupBoxDataFormat);
            this.Controls.Add(this.groupBoxOutputType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_OutputConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Output config";
            this.Load += new System.EventHandler(this.Form_OutputFormat_Load);
            this.groupBoxOutputType.ResumeLayout(false);
            this.groupBoxOutputType.PerformLayout();
            this.groupBoxDataFormat.ResumeLayout(false);
            this.groupBoxDataFormat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOutputType;
        private System.Windows.Forms.GroupBox groupBoxDataFormat;
        private System.Windows.Forms.RadioButton radioButton_TCPServer;
        private System.Windows.Forms.RadioButton radioButton_TextFile;
        private System.Windows.Forms.RadioButton radioButton_UDPServer;
        private System.Windows.Forms.Label labelOutputParameter;
        private System.Windows.Forms.Button buttonOutputTypeApply;
        private System.Windows.Forms.TextBox textBoxOutputParameter;
        private System.Windows.Forms.CheckBox checkBoxRemoveNoBarcode;
        private System.Windows.Forms.Label labelDescribe;
    }
}
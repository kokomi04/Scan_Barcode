namespace Dynamsoft_KeyStudio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.listBox_KeyData = new System.Windows.Forms.ListBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_SetTimeStart = new System.Windows.Forms.Button();
            this.button_SetTimeEnd = new System.Windows.Forms.Button();
            this.dateTimePicker_CustomDateTime = new System.Windows.Forms.DateTimePicker();
            this.button_SetCustomDateTime = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_KeyData
            // 
            this.listBox_KeyData.FormattingEnabled = true;
            this.listBox_KeyData.Location = new System.Drawing.Point(4, 26);
            this.listBox_KeyData.Name = "listBox_KeyData";
            this.listBox_KeyData.Size = new System.Drawing.Size(704, 342);
            this.listBox_KeyData.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(712, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "&Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "&Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(550, 374);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(52, 23);
            this.button_Add.TabIndex = 3;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Location = new System.Drawing.Point(603, 374);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(52, 23);
            this.button_Edit.TabIndex = 4;
            this.button_Edit.Text = "Edit";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(656, 374);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(52, 23);
            this.button_Delete.TabIndex = 5;
            this.button_Delete.Text = "Delete";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_SetTimeStart
            // 
            this.button_SetTimeStart.Location = new System.Drawing.Point(4, 374);
            this.button_SetTimeStart.Name = "button_SetTimeStart";
            this.button_SetTimeStart.Size = new System.Drawing.Size(153, 23);
            this.button_SetTimeStart.TabIndex = 6;
            this.button_SetTimeStart.Text = "Set date of PC as DateStart";
            this.button_SetTimeStart.UseVisualStyleBackColor = true;
            this.button_SetTimeStart.Click += new System.EventHandler(this.button_SetTimeStart_Click);
            // 
            // button_SetTimeEnd
            // 
            this.button_SetTimeEnd.Location = new System.Drawing.Point(157, 374);
            this.button_SetTimeEnd.Name = "button_SetTimeEnd";
            this.button_SetTimeEnd.Size = new System.Drawing.Size(153, 23);
            this.button_SetTimeEnd.TabIndex = 7;
            this.button_SetTimeEnd.Text = "Set date of PC as DateEnd";
            this.button_SetTimeEnd.UseVisualStyleBackColor = true;
            this.button_SetTimeEnd.Click += new System.EventHandler(this.button_SetTimeEnd_Click);
            // 
            // dateTimePicker_CustomDateTime
            // 
            this.dateTimePicker_CustomDateTime.CustomFormat = "dd-MM-yyyy-hh-mm-ss";
            this.dateTimePicker_CustomDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_CustomDateTime.Location = new System.Drawing.Point(316, 375);
            this.dateTimePicker_CustomDateTime.Name = "dateTimePicker_CustomDateTime";
            this.dateTimePicker_CustomDateTime.Size = new System.Drawing.Size(141, 20);
            this.dateTimePicker_CustomDateTime.TabIndex = 8;
            this.dateTimePicker_CustomDateTime.Value = new System.DateTime(2020, 12, 12, 0, 0, 0, 0);
            // 
            // button_SetCustomDateTime
            // 
            this.button_SetCustomDateTime.Location = new System.Drawing.Point(460, 374);
            this.button_SetCustomDateTime.Name = "button_SetCustomDateTime";
            this.button_SetCustomDateTime.Size = new System.Drawing.Size(73, 23);
            this.button_SetCustomDateTime.TabIndex = 9;
            this.button_SetCustomDateTime.Text = "Set Custom DateTime";
            this.button_SetCustomDateTime.UseVisualStyleBackColor = true;
            this.button_SetCustomDateTime.Click += new System.EventHandler(this.button_SetCustomDateTime_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 403);
            this.Controls.Add(this.button_SetCustomDateTime);
            this.Controls.Add(this.dateTimePicker_CustomDateTime);
            this.Controls.Add(this.button_SetTimeEnd);
            this.Controls.Add(this.button_SetTimeStart);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.listBox_KeyData);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dynamsoft Key Studio";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_KeyData;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_SetTimeStart;
        private System.Windows.Forms.Button button_SetTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimePicker_CustomDateTime;
        private System.Windows.Forms.Button button_SetCustomDateTime;
    }
}


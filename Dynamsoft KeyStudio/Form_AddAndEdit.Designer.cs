namespace Dynamsoft_KeyStudio
{
    partial class Form_AddAndEdit
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
            this.textBox_License = new System.Windows.Forms.TextBox();
            this.dateTimePicker_TimeStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_TimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label_From = new System.Windows.Forms.Label();
            this.label_to = new System.Windows.Forms.Label();
            this.label_License = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_License
            // 
            this.textBox_License.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_License.Location = new System.Drawing.Point(54, 33);
            this.textBox_License.Name = "textBox_License";
            this.textBox_License.Size = new System.Drawing.Size(230, 21);
            this.textBox_License.TabIndex = 3;
            // 
            // dateTimePicker_TimeStart
            // 
            this.dateTimePicker_TimeStart.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker_TimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_TimeStart.Location = new System.Drawing.Point(54, 7);
            this.dateTimePicker_TimeStart.Name = "dateTimePicker_TimeStart";
            this.dateTimePicker_TimeStart.Size = new System.Drawing.Size(105, 20);
            this.dateTimePicker_TimeStart.TabIndex = 4;
            this.dateTimePicker_TimeStart.Value = new System.DateTime(2020, 12, 12, 0, 0, 0, 0);
            // 
            // dateTimePicker_TimeEnd
            // 
            this.dateTimePicker_TimeEnd.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker_TimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_TimeEnd.Location = new System.Drawing.Point(179, 7);
            this.dateTimePicker_TimeEnd.Name = "dateTimePicker_TimeEnd";
            this.dateTimePicker_TimeEnd.Size = new System.Drawing.Size(105, 20);
            this.dateTimePicker_TimeEnd.TabIndex = 5;
            this.dateTimePicker_TimeEnd.Value = new System.DateTime(2020, 12, 12, 0, 0, 0, 0);
            // 
            // label_From
            // 
            this.label_From.AutoSize = true;
            this.label_From.Location = new System.Drawing.Point(3, 9);
            this.label_From.Name = "label_From";
            this.label_From.Size = new System.Drawing.Size(30, 13);
            this.label_From.TabIndex = 6;
            this.label_From.Text = "From";
            // 
            // label_to
            // 
            this.label_to.AutoSize = true;
            this.label_to.Location = new System.Drawing.Point(163, 9);
            this.label_to.Name = "label_to";
            this.label_to.Size = new System.Drawing.Size(16, 13);
            this.label_to.TabIndex = 7;
            this.label_to.Text = "to";
            // 
            // label_License
            // 
            this.label_License.AutoSize = true;
            this.label_License.Location = new System.Drawing.Point(3, 38);
            this.label_License.Name = "label_License";
            this.label_License.Size = new System.Drawing.Size(44, 13);
            this.label_License.TabIndex = 8;
            this.label_License.Text = "License";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(290, 5);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 9;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(290, 32);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 10;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // Form_AddAndEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 59);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.label_License);
            this.Controls.Add(this.label_to);
            this.Controls.Add(this.label_From);
            this.Controls.Add(this.dateTimePicker_TimeEnd);
            this.Controls.Add(this.dateTimePicker_TimeStart);
            this.Controls.Add(this.textBox_License);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_AddAndEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_License;
        private System.Windows.Forms.DateTimePicker dateTimePicker_TimeStart;
        private System.Windows.Forms.DateTimePicker dateTimePicker_TimeEnd;
        private System.Windows.Forms.Label label_From;
        private System.Windows.Forms.Label label_to;
        private System.Windows.Forms.Label label_License;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
    }
}
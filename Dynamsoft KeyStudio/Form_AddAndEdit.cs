using System;
using System.Windows.Forms;

namespace Dynamsoft_KeyStudio
{
    public partial class Form_AddAndEdit : Form
    {
        public DateTime TimeStart
        {
            set { dateTimePicker_TimeStart.Value = value; }
            get { return dateTimePicker_TimeStart.Value; }
        }

        public DateTime TimeEnd
        {
            set { dateTimePicker_TimeEnd.Value = value; }
            get { return dateTimePicker_TimeEnd.Value; }
        }

        public string License
        {
            set { textBox_License.Text = value; }
            get { return textBox_License.Text; }
        }

        public Form_AddAndEdit()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

using System;
using System.Windows.Forms;

namespace Scan_Barcode_Dual
{
    public partial class Form_About : Form
    {
        public delegate void dlgVoidBool(bool bBool);
        public dlgVoidBool SetAutoUpdate;
        public dlgVoidBool UpdateNow;
        public bool bAutoUpdate;

        public Form_About()
        {
            InitializeComponent();
        }

        private void Form_About_Load(object sender, EventArgs e)
        {
            if (bAutoUpdate)
            {
                checkBoxAutoUpdate.Checked = true;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateNow?.Invoke(true);
        }

        private void checkBoxAutoUpdate_Click(object sender, EventArgs e)
        {
            SetAutoUpdate?.Invoke(checkBoxAutoUpdate.Checked);
        }
    }
}

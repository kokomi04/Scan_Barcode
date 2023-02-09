using System;
using System.Windows.Forms;

namespace Scan_Barcode
{
    public partial class Form_OutputConfig : Form
    {
        public delegate void dlgVoidString(string sString);
        public delegate void dlgVoidBool(bool bBool);

        public dlgVoidString SetOutputFileName;
        public dlgVoidBool SetRemoveNoBarcode;

        public string sOutputParameter;
        public bool bRemoveNoBarcode;

        public Form_OutputConfig()
        {
            InitializeComponent();
        }

        private void Form_OutputFormat_Load(object sender, EventArgs e)
        {
            textBoxOutputParameter.Text = sOutputParameter;
            checkBoxRemoveNoBarcode.Checked = bRemoveNoBarcode;
        }

        private void radioButton_TextFile_Click(object sender, EventArgs e)
        {
            if (radioButton_TextFile.Checked)
            {
                labelOutputParameter.Text = "File name";
                textBoxOutputParameter.Text = sOutputParameter;
            }
            else
            {
                labelOutputParameter.Text = "Server port";
                textBoxOutputParameter.Text = "166199";
            }
        }

        private void buttonOutputTypeApply_Click(object sender, EventArgs e)
        {
            if (radioButton_TextFile.Checked)
                SetOutputFileName?.Invoke(textBoxOutputParameter.Text);
            else
                MessageBox.Show("Can't user this method!","Waring",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void checkBoxRemoveNoBarcode_CheckedChanged(object sender, EventArgs e)
        {
            SetRemoveNoBarcode?.Invoke(checkBoxRemoveNoBarcode.Checked);
        }
    }
}

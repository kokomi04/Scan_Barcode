using System;
using System.Windows.Forms;

namespace Scan_Barcode
{
    public partial class Form_ScanType : Form
    {
        public delegate void dlgScanModuleType(ScanModuleType enScanModuleType);
        public delegate void dlgVoidBool(bool bBool);

        public dlgScanModuleType SetScanModuleType;
        public dlgVoidBool SetAutoStopAfterScanFinished;
        public dlgVoidBool SetAutoStopAfter30s;
        public dlgVoidBool SetAutoSearchBacode;

        public ScanModuleType enScanModuleType;

        public bool bAutoStopAfterScanFinished;
        public bool bAutoStopAfter30s;
        public bool bAutoSearchBacode;
        
        public Form_ScanType()
        {
            InitializeComponent();
        }

        private void Form_ScanType_Load(object sender, EventArgs e)
        {
            if (enScanModuleType == ScanModuleType.Zxing) radioButtonZxing.Checked = true;
            else if (enScanModuleType == ScanModuleType.Dynamsoft) radioButtonDynamsoft.Checked = true;
            else if (enScanModuleType == ScanModuleType.BacodeLib) radioButtonBacodeLib.Checked = true;

            checkBoxAutoStopAfterScanFinished.Checked = bAutoStopAfterScanFinished;
            checkBoxAutoStopAfter30s.Checked = bAutoStopAfter30s;
            checkBoxAutoSearchBacode.Checked = bAutoSearchBacode;
        }

        private void radioButtonScanModules_CheckedChanged(object sender, EventArgs e)
        {
            ScanModuleType enScanModuleTypeTemp = ScanModuleType.Zxing;
            if (radioButtonZxing.Checked) enScanModuleTypeTemp = ScanModuleType.Zxing;
            else if (radioButtonDynamsoft.Checked) enScanModuleTypeTemp = ScanModuleType.Dynamsoft;
            else if (radioButtonBacodeLib.Checked) enScanModuleTypeTemp = ScanModuleType.BacodeLib;

            if (enScanModuleTypeTemp != enScanModuleType)
            {
                enScanModuleType = enScanModuleTypeTemp;

                if (enScanModuleType != ScanModuleType.Dynamsoft)
                {
                    checkBoxAutoSearchBacode.Checked = false;
                    SetAutoSearchBacode?.Invoke(false);
                }
                SetScanModuleType?.Invoke(enScanModuleType);
            }
        }

        private void checkBoxAutoStopAfterScanFinished_Click(object sender, EventArgs e)
        {
            SetAutoStopAfterScanFinished?.Invoke(checkBoxAutoStopAfterScanFinished.Checked);
        }

        private void checkBoxAutoStopAfter30s_Click(object sender, EventArgs e)
        {
            SetAutoStopAfter30s?.Invoke(checkBoxAutoStopAfter30s.Checked);
        }

        private void checkBoxAutoSearchBacode_Click(object sender, EventArgs e)
        {
            if (radioButtonDynamsoft.Checked)
            {
                SetAutoSearchBacode?.Invoke(checkBoxAutoSearchBacode.Checked);
            }
            else
            {
                checkBoxAutoSearchBacode.Checked = false;
                MessageBox.Show("Auto search run only with Dynamsoft scan module", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

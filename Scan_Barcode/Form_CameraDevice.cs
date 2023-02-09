using System;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace Scan_Barcode
{
    public partial class Form_CameraDevice : Form
    {
        public delegate void dlgSetCameraDevice(bool bUsingTowCAM, int iCameraDeviceNo_1, int iCameraDeviceNo_2);
        public dlgSetCameraDevice SetCameraDevice;

        public bool bUsingTowCAM;
        public int iCameraDeviceNo_1, iCameraDeviceNo_2;

        public Form_CameraDevice()
        {
            InitializeComponent();     
        }

        private void Form_CameraDevice_Load(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                comboBoxCamera_1.Items.Clear();
                comboBoxCamera_2.Items.Clear();
                foreach (FilterInfo fFilterInfo in new FilterInfoCollection(FilterCategory.VideoInputDevice))
                {
                    count++;
                    comboBoxCamera_1.Items.Add($"{count}_{fFilterInfo.Name}");
                    comboBoxCamera_2.Items.Add($"{count}_{fFilterInfo.Name}");
                }

                if (comboBoxCamera_1.Items.Count > 0)
                {
                    comboBoxCamera_2.Items.Insert(0, "-----Do not use-----");
                    int ItemsIndex = iCameraDeviceNo_1;
                    if (comboBoxCamera_1.Items.Count > ItemsIndex)
                    {
                        comboBoxCamera_1.SelectedIndex = ItemsIndex;
                    }
                    else
                    {
                        comboBoxCamera_1.SelectedIndex = 0;
                    }
                    ItemsIndex = iCameraDeviceNo_2 + 1;
                    if (bUsingTowCAM && comboBoxCamera_2.Items.Count > ItemsIndex)
                    {
                        comboBoxCamera_2.SelectedIndex = ItemsIndex;
                    }
                    else
                    {
                        comboBoxCamera_2.SelectedIndex = 0;
                    }
                }
                else
                {
                    comboBoxCamera_1.Items.Add("-----No device-----");
                    comboBoxCamera_1.SelectedIndex = 0;
                    comboBoxCamera_2.Items.Add("-----No device-----");
                    comboBoxCamera_2.SelectedIndex = 0;
                }
            }
            catch
            {

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            iCameraDeviceNo_1 = comboBoxCamera_1.SelectedIndex;
            iCameraDeviceNo_2 = comboBoxCamera_2.SelectedIndex - 1;
            bUsingTowCAM = iCameraDeviceNo_2 < 0 ? false : true;

            if (iCameraDeviceNo_1 != iCameraDeviceNo_2)
            {
                SetCameraDevice?.Invoke(bUsingTowCAM, iCameraDeviceNo_1, iCameraDeviceNo_2);
            }
            else
            {
                MessageBox.Show("Can't use the same camera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

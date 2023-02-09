using System;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace Scan_Barcode_Dual
{
    public partial class Form_CameraDevice : Form
    {
        public delegate void dlgSetCameraDevice(int iCameraDeviceNo_1, int iCameraDeviceNo_2);
        public dlgSetCameraDevice SetCameraDevice;

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
                    int ItemsIndex = iCameraDeviceNo_1;
                    if (comboBoxCamera_1.Items.Count > ItemsIndex)
                    {
                        comboBoxCamera_1.SelectedIndex = ItemsIndex;
                    }
                    else
                    {
                        comboBoxCamera_1.SelectedIndex = 0;
                    }
                    ItemsIndex = iCameraDeviceNo_2;
                    if (comboBoxCamera_2.Items.Count > ItemsIndex)
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
                    MessageBox.Show("Not enough camera device!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch
            {

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            iCameraDeviceNo_1 = comboBoxCamera_1.SelectedIndex;
            iCameraDeviceNo_2 = comboBoxCamera_2.SelectedIndex;

            if (iCameraDeviceNo_1 != iCameraDeviceNo_2)
            {
                SetCameraDevice?.Invoke(iCameraDeviceNo_1, iCameraDeviceNo_2);
            }
            else
            {
                MessageBox.Show("Can't use the same camera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

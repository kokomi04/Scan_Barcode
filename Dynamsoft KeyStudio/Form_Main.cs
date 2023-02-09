using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Dynamsoft_KeyStudio
{
    public partial class Form_Main : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Miliseconds;

            public SYSTEMTIME(DateTime datetime)
            {
                Year = (ushort)datetime.Year;
                Month = (ushort)datetime.Month;
                DayOfWeek = (ushort)datetime.DayOfWeek;
                Day = (ushort)datetime.Day;
                Hour = (ushort)datetime.Hour;
                Minute = (ushort)datetime.Minute;
                Second = (ushort)datetime.Second;
                Miliseconds = (ushort)datetime.Millisecond;
            }
        }

        [DllImport("kernel32")]
        static extern bool SetSystemTime(SYSTEMTIME time);



        public Form_Main()
        {
            InitializeComponent();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.FileName = "DynamsoftKey.txt";
            OpenFile.DefaultExt = ".txt";
            OpenFile.Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*";
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                listBox_KeyData.Items.Clear();
                string[] keyFileData = File.ReadAllLines(OpenFile.FileName);
                for (int K = 0; K < keyFileData.Length; K++)
                {
                    listBox_KeyData.Items.Add(new DynamsoftKeyData(keyFileData[K]));
                }
                if (listBox_KeyData.Items.Count > 0) listBox_KeyData.SelectedIndex = listBox_KeyData.Items.Count - 1;
                VerifyListKeyData();
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!VerifyListKeyData() | listBox_KeyData.Items.Count == 0) return;

            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.FileName = "DynamsoftKey.txt";
            SaveFile.DefaultExt = ".txt";
            SaveFile.Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*";
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writeOutputFile = new StreamWriter(SaveFile.FileName);
                for (int K = 0; K < listBox_KeyData.Items.Count; K++)
                {
                    writeOutputFile.WriteLine(((DynamsoftKeyData)listBox_KeyData.Items[K]).DataLine);
                }
                writeOutputFile.Close();
                MessageBox.Show("Export success", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form_About().ShowDialog();
        }

        private void button_SetTimeStart_Click(object sender, EventArgs e)
        {
            if (listBox_KeyData.SelectedIndex < 0) return;

            SetPCDateTime(((DynamsoftKeyData)listBox_KeyData.Items[listBox_KeyData.SelectedIndex]).TimeStart);
        }

        private void button_SetTimeEnd_Click(object sender, EventArgs e)
        {
            if (listBox_KeyData.SelectedIndex < 0) return;

            SetPCDateTime(((DynamsoftKeyData)listBox_KeyData.Items[listBox_KeyData.SelectedIndex]).TimeEnd);
        }

        private void button_SetCustomDateTime_Click(object sender, EventArgs e)
        {
            SetPCDateTime(dateTimePicker_CustomDateTime.Value);
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            Form_AddAndEdit frmFormAdd = new Form_AddAndEdit();
            frmFormAdd.Text = "Add new data";
            if (listBox_KeyData.SelectedIndex >= 0)
            {
                frmFormAdd.TimeStart = ((DynamsoftKeyData)listBox_KeyData.Items[listBox_KeyData.SelectedIndex]).TimeEnd;
                frmFormAdd.TimeEnd = ((DynamsoftKeyData)listBox_KeyData.Items[listBox_KeyData.SelectedIndex]).TimeEnd.AddDays(29);
            }
            if (frmFormAdd.ShowDialog() == DialogResult.OK)
            {
                if(frmFormAdd.License.Length == 97 | frmFormAdd.License.Length == 98)
                {
                    frmFormAdd.License = frmFormAdd.License.Substring(10,86);
                    listBox_KeyData.Items.Add(new DynamsoftKeyData(frmFormAdd.TimeStart, frmFormAdd.TimeEnd, frmFormAdd.License));
                    if (listBox_KeyData.Items.Count > 0) listBox_KeyData.SelectedIndex = listBox_KeyData.Items.Count - 1;
                    VerifyListKeyData();
                }
                else if(frmFormAdd.License.Length == 86)
                {
                    listBox_KeyData.Items.Add(new DynamsoftKeyData(frmFormAdd.TimeStart, frmFormAdd.TimeEnd, frmFormAdd.License));
                    if (listBox_KeyData.Items.Count > 0) listBox_KeyData.SelectedIndex = listBox_KeyData.Items.Count - 1;
                    VerifyListKeyData();
                }
                else
                {
                    MessageBox.Show("The license length is error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (listBox_KeyData.SelectedIndex < 0) return;

            Form_AddAndEdit frmFormEdit = new Form_AddAndEdit();
            frmFormEdit.Text = "Edit data";
            frmFormEdit.TimeStart = ((DynamsoftKeyData)listBox_KeyData.Items[listBox_KeyData.SelectedIndex]).TimeStart;
            frmFormEdit.TimeEnd = ((DynamsoftKeyData)listBox_KeyData.Items[listBox_KeyData.SelectedIndex]).TimeEnd;
            frmFormEdit.License = ((DynamsoftKeyData)listBox_KeyData.Items[listBox_KeyData.SelectedIndex]).License;
            if (frmFormEdit.ShowDialog() == DialogResult.OK)
            {
                ((DynamsoftKeyData)listBox_KeyData.Items[listBox_KeyData.SelectedIndex]).TimeStart = frmFormEdit.TimeStart;
                ((DynamsoftKeyData)listBox_KeyData.Items[listBox_KeyData.SelectedIndex]).TimeEnd = frmFormEdit.TimeEnd;
                ((DynamsoftKeyData)listBox_KeyData.Items[listBox_KeyData.SelectedIndex]).License = frmFormEdit.License;
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (listBox_KeyData.SelectedIndex < 0) return;

            listBox_KeyData.Items.RemoveAt(listBox_KeyData.SelectedIndex);
            if (listBox_KeyData.Items.Count > 0) listBox_KeyData.SelectedIndex = listBox_KeyData.Items.Count - 1;
            VerifyListKeyData();
        }

        private bool VerifyListKeyData()
        {
            for (int K = 1; K < listBox_KeyData.Items.Count; K++)
            {
                if ((((DynamsoftKeyData)listBox_KeyData.Items[K - 1]).TimeEnd - ((DynamsoftKeyData)listBox_KeyData.Items[K]).TimeStart).Days < 0)
                {
                    listBox_KeyData.SelectedIndex = K;
                    MessageBox.Show($"The key date on line {K + 1} error{Environment.NewLine}DateStart is not less than or equal to the previous DateEnd!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void SetPCDateTime(DateTime DDateToSet)
        {
            SetSystemTime(new SYSTEMTIME(DDateToSet.AddHours(-7)));
        }
    }

    class DynamsoftKeyData
    {
        private DateTime DTimeStart, DTimeEnd;
        private string sLicense;

        public DateTime TimeStart
        {
            set { DTimeStart = value; }
            get { return DTimeStart; }
        }

        public DateTime TimeEnd
        {
            set { DTimeEnd = value; }
            get { return DTimeEnd; }
        }

        public string License
        {
            set { sLicense = value; }
            get { return sLicense; }
        }

        public string DataLine
        {
            get { return $"{DTimeStart.ToString("ddMMyyyy")};{DTimeEnd.ToString("ddMMyyyy")};{sLicense}"; }
        }

        public DynamsoftKeyData(DateTime DTimeStart, DateTime DTimeEnd, string sLicense)
        {
            this.DTimeStart = DTimeStart;
            this.DTimeEnd = DTimeEnd;
            this.sLicense = sLicense;
        }

        public DynamsoftKeyData(string sValue)
        {
            try
            {
                string[] DataValue = sValue.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                DTimeStart = DateTime.ParseExact(DataValue[0],"ddMMyyyy", null);
                DTimeEnd = DateTime.ParseExact(DataValue[1],"ddMMyyyy", null);
                sLicense   = DataValue[2];
            }
            catch
            {
                MessageBox.Show(sValue, "Dynamsoft key data format error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        public override string ToString()
        {
            return $"{DTimeStart.ToString("dd-MM-yyyy")} -> {DTimeEnd.ToString("dd-MM-yyyy")}\t{sLicense}";
        }
    }
}

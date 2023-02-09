using System;
using System.IO;
using System.Net;
using System.Drawing;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Compression;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Security.Cryptography;

using AForge.Video.DirectShow;

namespace Scan_Barcode
{
    public partial class Form_Main : Form
    {
        public string sProgramTempPath = $@"{Path.GetTempPath()}Scan_Bacode\";
        private string sThisProgramPath = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
        private string[] sFtpServerProgramPath = { "oper", "wireless", "ftp://200.166.40.150/Common/Scan_Barcode/Scan_Barcode.exx" };
        private string[] sFtpServerKeyPath = { "oper", "wireless", "ftp://200.166.40.150/Common/Scan_Barcode/DynamsoftKey.txt" };
        private string sRegistryPath = @"SOFTWARE\\Ambit\\CMTestProgram\\ScanBarcode";

        private VideoCaptureDevice videoCaptureDevice_1, videoCaptureDevice_2;
        private bool bUsingTowCAM, bShowCameraNo2;
        private int iCameraDeviceNo_1, iCameraDeviceNo_2;
        private Bitmap bmCameraInput_1, bmCameraInput_2;

        private bool bIsDrawingSelection;
        private int iStatusSelection = -1;
        private Point pStartSelection;
        private Rectangle rRegionSelection;

        private ScanModuleType enScanModuleType;
        private BarcodeReader DynamsoftBarcodeReader;
        private ZXing.BarcodeReader ZxingBarCodeReader;
        private bool bAutoStopAfterScanFinished;
        private bool bAutoStopAfter30s;
        private bool bAutoSearchBacode;

        private bool bRemoveNoBarcode;
        private string sOutputFileName;
        private string[] sDataOut = new string[3];
        private bool[] bScanOK = new bool[3];

        public Form_Main()
        {
            //if (bool.Parse(getRegistryKey("AutoUpdate", "False")))
            //{
            //    CheckUpdate(false);
            //}

            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(sProgramTempPath))
            {
                Directory.CreateDirectory(sProgramTempPath);
            }

            bUsingTowCAM = bool.Parse(getRegistryKey("UsingTowCAM", "False"));
            iCameraDeviceNo_1 = Convert.ToInt32(getRegistryKey("CameraDevice_1", "0"));
            iCameraDeviceNo_2 = Convert.ToInt32(getRegistryKey("CameraDevice_2", "1"));

            bRemoveNoBarcode = bool.Parse(getRegistryKey("RemoveNoBarcode", "False"));
            sOutputFileName = getRegistryKey("OutputFileName", "Barcode.txt");
            LoadListBoxSelectionBacodeRegion();

            enScanModuleType = (ScanModuleType)Convert.ToInt32(getRegistryKey("ScanModuleType", "0"));
            InitScanModule();
            bAutoStopAfterScanFinished = bool.Parse(getRegistryKey("AutoStopAfterScanFinished", "True"));
            bAutoStopAfter30s = bool.Parse(getRegistryKey("AutoStopAfter30s", "True"));
            bAutoSearchBacode = bool.Parse(getRegistryKey("AutoSearchBacode", "False"));

            toolStripMenuItemStartScan_Click(null, null);
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            toolStripMenuItemStopScan_Click(null, null);
        }

        private void toolStripMenuItemUnlock_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemUnlock.Text == "Unlock")
            {
                toolStripMenuItemUnlock.Text = "Lock";
                buttonAddBacodeRegion.Enabled = true;
                buttonEditBacodeRegion.Enabled = true;
                buttonDeleteBacodeRegion.Enabled = true;
            }
            else
            {
                toolStripMenuItemUnlock.Text = "Unlock";
                buttonAddBacodeRegion.Enabled = false;
                buttonEditBacodeRegion.Enabled = false;
                buttonDeleteBacodeRegion.Enabled = false;
            }
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItemCameraDevice_Click(object sender, EventArgs e)
        {
            Form_CameraDevice frmCameraDevice = new Form_CameraDevice();
            frmCameraDevice.SetCameraDevice = new Form_CameraDevice.dlgSetCameraDevice(SetCameraDevice);
            frmCameraDevice.bUsingTowCAM = bUsingTowCAM;
            frmCameraDevice.iCameraDeviceNo_1 = iCameraDeviceNo_1;
            frmCameraDevice.iCameraDeviceNo_2 = iCameraDeviceNo_2;
            frmCameraDevice.ShowDialog(this);          
        }

        private void scanTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ScanType ScanType = new Form_ScanType();
            ScanType.SetScanModuleType = new Form_ScanType.dlgScanModuleType(SetScanModuleType);
            ScanType.SetAutoStopAfterScanFinished = new Form_ScanType.dlgVoidBool(SetAutoStopAfterScanFinished);
            ScanType.SetAutoStopAfter30s = new Form_ScanType.dlgVoidBool(SetAutoStopAfter30s);
            ScanType.SetAutoSearchBacode = new Form_ScanType.dlgVoidBool(SetAutoSearchBacode);
            ScanType.enScanModuleType = enScanModuleType;
            ScanType.bAutoStopAfterScanFinished = bAutoStopAfterScanFinished;
            ScanType.bAutoStopAfter30s = bAutoStopAfter30s;
            ScanType.bAutoSearchBacode = bAutoSearchBacode;
            ScanType.ShowDialog(this);
        }

        private void ToolStripMenuItemOutputConfig_Click(object sender, EventArgs e)
        {
            Form_OutputConfig frmOutputFormat = new Form_OutputConfig();
            frmOutputFormat.SetOutputFileName = new Form_OutputConfig.dlgVoidString(SetOutputFileName);
            frmOutputFormat.SetRemoveNoBarcode = new Form_OutputConfig.dlgVoidBool(SetRemoveNoBarcode);
            frmOutputFormat.sOutputParameter = sOutputFileName;
            frmOutputFormat.bRemoveNoBarcode = bRemoveNoBarcode;
            frmOutputFormat.ShowDialog(this);
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            Form_About frmFormAbout = new Form_About();
            frmFormAbout.UpdateNow = new Form_About.dlgVoidBool(CheckUpdate);
            frmFormAbout.SetAutoUpdate = new Form_About.dlgVoidBool(SetAutoUpdate);
            frmFormAbout.bAutoUpdate = bool.Parse(getRegistryKey("AutoUpdate", "False"));
            frmFormAbout.ShowDialog(this);
        }

        public void toolStripMenuItemStartScan_Click(object sender, EventArgs e)
        {
            StartVideoCaptureDevice();
            StartScanBarcode();
            if (bAutoStopAfter30s)
            {
                timerAutoStop.Stop();  //Reset timer
                timerAutoStop.Start();
            }
        }

        private void StartVideoCaptureDevice()
        {
            try
            {
                FilterInfoCollection filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if ((filterInfoCollection.Count > iCameraDeviceNo_1 && !bUsingTowCAM) || (filterInfoCollection.Count > iCameraDeviceNo_1 && bUsingTowCAM && filterInfoCollection.Count > iCameraDeviceNo_2))
                {
                    if (!videoSourcePlayer_1.IsRunning)
                    {
                        videoCaptureDevice_1 = new VideoCaptureDevice(filterInfoCollection[iCameraDeviceNo_1].MonikerString);
                        videoSourcePlayer_1.VideoSource = videoCaptureDevice_1;
                        videoSourcePlayer_1.Start();
                    }
                    if (bUsingTowCAM && (!videoSourcePlayer_2.IsRunning))
                    {
                        videoCaptureDevice_2 = new VideoCaptureDevice(filterInfoCollection[iCameraDeviceNo_2].MonikerString);
                        videoSourcePlayer_2.VideoSource = videoCaptureDevice_2;
                        videoSourcePlayer_2.Start();
                    }
                }
                else
                {
                    MessageBox.Show("Lost the camera. Please to check the camera device again!", "Error start camera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can not start the camera!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartScanBarcode()
        {
            if (bAutoSearchBacode)
            {
                if (enScanModuleType != ScanModuleType.Dynamsoft)
                {
                    StopScanBarcode();
                    StopVideoCaptureDevice();
                    textBoxDataShow.Text = "Auto search bacode modoe only applies to the Dynamsoft module!";
                    buttonStatust.Text = "Scan error";
                    return;
                }

                for (int k = 0; k < listBoxSelectionBacodeRegion.Items.Count; k++)
                {
                    if (((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).StartsWith == "NOCHECK")
                    {
                        StopScanBarcode();
                        StopVideoCaptureDevice();
                        textBoxDataShow.Text = "Please enter the first text of the barcode!";
                        buttonStatust.Text = "Scan error";
                        return;
                    }
                }
            }

            buttonStatust.Text = "Scaning";
            bmCameraInput_1 = null;
            bmCameraInput_2 = null;
            textBoxDataShow.Text = null;

            timerScan.Start();
            bScanOK[0] = bScanOK[1] = bScanOK[2] = false;
        }
        private void videoSourcePlayer_1_NewFrame(object sender, ref Bitmap image)
        {
            try
            {
                bmCameraInput_1 = image;
            }
            catch { }
        }

        private void videoSourcePlayer_2_NewFrame(object sender, ref Bitmap image2)
        {
            try
            {
                bmCameraInput_2 = image2;
            }
            catch { }
        }

        public void toolStripMenuItemStopScan_Click(object sender, EventArgs e)
        {
            StopScanBarcode();
            StopVideoCaptureDevice();
        }

        private void StopVideoCaptureDevice()
        {
            videoSourcePlayer_1.Stop();
            videoSourcePlayer_2.Stop();
        }

        private void StopScanBarcode()
        {
            timerScan.Stop();
            bmCameraInput_1 = null;
            bmCameraInput_2 = null;
        }

        private void videoSourcePlayer_X_Paint(object sender, PaintEventArgs e)
        {
            if (iStatusSelection == -1)
            {
                for (int k = 0; k < listBoxSelectionBacodeRegion.Items.Count; k++)
                {
                    if (((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).IsCamera2 == bShowCameraNo2)
                    {
                        e.Graphics.DrawRectangle(Pens.Red, ((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).GetRectangle());
                        e.Graphics.DrawString($"{ k + 1}", new Font("Arial", 12), new SolidBrush(Color.Red), ((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).LocationText);
                    }
                }
            }
            else
            {
                e.Graphics.DrawRectangle(Pens.Blue, rRegionSelection);
            }
            e.Graphics.DrawString("CAM " + (bShowCameraNo2 ? "2" : "1"), new Font("Arial", 8), new SolidBrush(Color.Red), 3, 15);
        }

        private void videoSourcePlayer_X_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && iStatusSelection >= 0)
            {
                bIsDrawingSelection = true;
                pStartSelection = e.Location;
            }
            else if (e.Button == MouseButtons.Middle)
            {           
                try
                {
                    if (bShowCameraNo2)
                    {
                        videoCaptureDevice_2.DisplayPropertyPage(Handle);
                    }
                    else
                    {
                        videoCaptureDevice_1.DisplayPropertyPage(Handle);
                    }
                }
                catch (NotSupportedException Exception)
                {
                    MessageBox.Show(Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.Button == MouseButtons.Right && bUsingTowCAM && iStatusSelection == -1)
            {
                bShowCameraNo2 = !bShowCameraNo2;
                if (bShowCameraNo2)
                {
                    videoSourcePlayer_2.BringToFront();
                    videoSourcePlayer_1.SendToBack();
                }
                else
                {
                    videoSourcePlayer_1.BringToFront();
                    videoSourcePlayer_2.SendToBack();
                }
            }
        }

        private void videoSourcePlayer_X_MouseMove(object sender, MouseEventArgs e)
        {
            if (bIsDrawingSelection)
            {
                rRegionSelection = new Rectangle(Math.Min(pStartSelection.X, e.X), Math.Min(pStartSelection.Y, e.Y), Math.Abs(pStartSelection.X - e.Location.X), Math.Abs(pStartSelection.Y - e.Location.Y));
            }
        }

        private void videoSourcePlayer_X_MouseUp(object sender, MouseEventArgs e)
        {
            if (iStatusSelection >= 0)
            {
                bIsDrawingSelection = false;

                string sStartsWith;
                do
                {
                    sStartsWith = Interaction.InputBox("Please enter the first text of the barcode!\nExample: The Bacode value is \"YT0LOVN\" then input \"Y\" or \"YT...\"", "Check the first text of the barcode", "NOCHECK").ToUpper();
                } while (sStartsWith.Length < 1);

                if (iStatusSelection == listBoxSelectionBacodeRegion.SelectedIndex)
                {
                    ((RegionSelectionData)listBoxSelectionBacodeRegion.SelectedItem).UpdateValue(bShowCameraNo2, pStartSelection, e.Location, ConvertCoordinates(pStartSelection), ConvertCoordinates(e.Location), sStartsWith);
                    listBoxSelectionBacodeRegion.Items[listBoxSelectionBacodeRegion.SelectedIndex] = listBoxSelectionBacodeRegion.Items[listBoxSelectionBacodeRegion.SelectedIndex];
                }
                else
                {
                    listBoxSelectionBacodeRegion.Items.Add(new RegionSelectionData(bShowCameraNo2, pStartSelection, e.Location, ConvertCoordinates(pStartSelection), ConvertCoordinates(e.Location), sStartsWith));
                    listBoxSelectionBacodeRegion.SelectedIndex = listBoxSelectionBacodeRegion.Items.Count - 1;
                }
                iStatusSelection = -1;

                listBoxSelectionBacodeRegion_Save();
            }
        }

        private void buttonAddBacodeRegion_Click(object sender, EventArgs e)
        {
            if (listBoxSelectionBacodeRegion.Items.Count >= 3 || (bRemoveNoBarcode && listBoxSelectionBacodeRegion.Items.Count >= 1))
            {
                if (MessageBox.Show("Remove no barcode is checked, so only read the first bacode in the list!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }
            }
            StartVideoCaptureDevice();
            iStatusSelection = listBoxSelectionBacodeRegion.Items.Count;
        }

        private void buttonEditBacodeRegion_Click(object sender, EventArgs e)
        {
            if (listBoxSelectionBacodeRegion.SelectedIndex < 0) return;
            StartVideoCaptureDevice();
            iStatusSelection = listBoxSelectionBacodeRegion.SelectedIndex;
        }

        private void buttonDeleteBacodeRegion_Click(object sender, EventArgs e)
        {
            if (listBoxSelectionBacodeRegion.SelectedIndex < 0) return;
            listBoxSelectionBacodeRegion.Items.RemoveAt(listBoxSelectionBacodeRegion.SelectedIndex);
            if (listBoxSelectionBacodeRegion.Items.Count > 0)
            {
                listBoxSelectionBacodeRegion.SelectedIndex = 0;
            }
            listBoxSelectionBacodeRegion_Save();
        }

        private void listBoxSelectionBacodeRegion_Save()
        {
            setRegistryKey("NumberOfBarcodeRegionSelection", listBoxSelectionBacodeRegion.Items.Count.ToString());
            for (int k = 0; k < listBoxSelectionBacodeRegion.Items.Count; k++)
            {
                setRegistryKey($"BarcodeRegionSelection{k}", ((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).GetDataRegionSelection());
            }
        }

        private void timerScan_Tick(object sender, EventArgs e)
        {
            if (bmCameraInput_1 == null || (bmCameraInput_2 == null & bUsingTowCAM)) return;

            if (bAutoSearchBacode) ScanAutoSearch();
            else ScanMormal();
        }
        
        private void ScanAutoSearch()
        {
            Bitmap bmScanCode;
            for (int k = 0; k < listBoxSelectionBacodeRegion.Items.Count; k++)
            {
                if (bScanOK[k]) continue;

                try
                {
                    if (((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).IsCamera2)
                    {
                        bmScanCode = bmCameraInput_2.Clone(((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).GetImageRectangle(), bmCameraInput_2.PixelFormat);
                    }
                    else
                    {
                        bmScanCode = bmCameraInput_1.Clone(((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).GetImageRectangle(), bmCameraInput_1.PixelFormat);
                    }
                }
                catch { continue; }

                try
                {
                    string[] TextResult = DynamsoftBarcodeReader.DecodeBitmap(bmScanCode);
                    if (TextResult == null) return;

                    foreach (string DecodeResult in TextResult)
                    { 
                        if (checkDataResult(DecodeResult, ((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).StartsWith) == false) continue;
                        if (bRemoveNoBarcode)
                        {
                            textBoxDataShow.AppendText($"{DecodeResult}{Environment.NewLine}");
                            sDataOut[k] = DecodeResult.Trim();
                        }
                        else
                        {
                            textBoxDataShow.AppendText($"{k + 1}_{DecodeResult}{Environment.NewLine}");
                            sDataOut[k] = $"{k + 1}_{DecodeResult.Trim()}";
                        }

                        bScanOK[k] = true;
                    }
                }
                catch { continue; }
                if (CheckScanOK())
                {                   
                    StreamWriter writeOutputFile = new StreamWriter($@"{Application.StartupPath}\{sOutputFileName}");
                    for (k = 0; k < listBoxSelectionBacodeRegion.Items.Count; k++)
                    {
                        writeOutputFile.WriteLine(sDataOut[k]);
                    }
                    writeOutputFile.Close();
                    buttonStatust.Text = "Scan finished";

                    if (bAutoStopAfter30s) timerAutoStop.Stop();
                    if (iStatusSelection < 0)
                    {
                        StopScanBarcode();
                        if (bAutoStopAfterScanFinished) StopVideoCaptureDevice();
                    }
                }
            }
        }

        private void ScanMormal()
        {
            Bitmap bmScanCode;
            for (int k = 0; k < listBoxSelectionBacodeRegion.Items.Count; k++)
            {
                if (bScanOK[k]) continue;

                try
                {
                    if (((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).IsCamera2)
                    {
                        bmScanCode = bmCameraInput_2.Clone(((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).GetImageRectangle(), bmCameraInput_2.PixelFormat);
                    }
                    else
                    {
                        bmScanCode = bmCameraInput_1.Clone(((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).GetImageRectangle(), bmCameraInput_1.PixelFormat);
                    }
                }
                catch { continue; }

                try
                {
                    string DecodeResult = null;

                    switch (enScanModuleType)
                    {
                        case ScanModuleType.BacodeLib:
                            if ((((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).StartsWith) == "NOCHECK")
                            {
                                StopScanBarcode();
                                textBoxDataShow.Text = "Please enter the first text of the barcode!";
                                buttonStatust.Text = "Scan error";
                            }
                            DecodeResult = BarcodeLib.BarcodeReader.BarcodeReader.read(bmScanCode, 1)[0];   //QRCODE = 9;CODE128 = 1;
                            if( DecodeResult == null ) DecodeResult =  BarcodeLib.BarcodeReader.BarcodeReader.read(bmScanCode, 9)[0];
                            break;
                        case ScanModuleType.Dynamsoft:
                            DecodeResult = DynamsoftBarcodeReader.DecodeBitmap(bmScanCode)[0];
                            if (DecodeResult.Contains("THE LICENSE"))
                            {
                                StopScanBarcode();
                                textBoxDataShow.Text = $"The license of scan module has error, please check and try again later!{Environment.NewLine}{Environment.NewLine}";
                                buttonStatust.Text = "Scan error";
                            }
                            break;
                        default:
                            DecodeResult = ZxingBarCodeReader.Decode(bmScanCode).Text; ;
                            break;
                    }

                    if (DecodeResult == null) continue;
                    if (!checkDataResult(DecodeResult, ((RegionSelectionData)listBoxSelectionBacodeRegion.Items[k]).StartsWith)) continue;
                    if (bRemoveNoBarcode)
                    {
                        textBoxDataShow.Text = $"{DecodeResult}{Environment.NewLine}";
                        sDataOut[k] = DecodeResult.Trim();
                    }
                    else
                    {
                        textBoxDataShow.Text += $"{k + 1}_{DecodeResult}{Environment.NewLine}";
                        sDataOut[k] = $"{k + 1}_{DecodeResult.Trim()}";
                    }

                    bScanOK[k] = true;
                }
                catch
                {
                    continue;
                }

                if (CheckScanOK())
                {
                    StreamWriter writeOutputFile = new StreamWriter($@"{Application.StartupPath}\{sOutputFileName}");
                    for (k = 0; k < listBoxSelectionBacodeRegion.Items.Count; k++)
                    {
                        writeOutputFile.WriteLine(sDataOut[k]);
                    }
                    writeOutputFile.Close();
                    buttonStatust.Text = "Scan finished";

                    if (bAutoStopAfter30s) timerAutoStop.Stop();
                    if (iStatusSelection < 0)
                    {
                        StopScanBarcode();
                        if (bAutoStopAfterScanFinished) StopVideoCaptureDevice();
                    }
                }
            }
        }

        private void timerAutoStop_Tick(object sender, EventArgs e)
        {
            if (iStatusSelection == -1)
            {
                toolStripMenuItemStopScan_Click(null, null);
                timerAutoStop.Stop();
                if (!CheckScanOK())
                {
                    StopScanBarcode();
                    buttonStatust.Text = "Scan error";
                }
            }
        }

        private bool checkDataResult(string StringData, string StartsWith)
        {
            if (StartsWith != "NOCHECK" && !StringData.StartsWith(StartsWith)) return false;
            foreach (char charText in StringData.ToCharArray())
            {
                if (!char.IsLetterOrDigit(charText)) return false;                
            }
            return true;
        }

        private bool CheckScanOK()
        {
            for (int k = 0; k < listBoxSelectionBacodeRegion.Items.Count; k++)
            {
                if (!bScanOK[k]) return false;
            }
            return true;
        }

        private void LoadListBoxSelectionBacodeRegion()
        {
            int iNumberOfBarcode = bRemoveNoBarcode ? 1 : Convert.ToInt32(getRegistryKey("NumberOfBarcodeRegionSelection", "0"));
            listBoxSelectionBacodeRegion.Items.Clear();
            for (int k = 0; k < iNumberOfBarcode; k++)
            {
                listBoxSelectionBacodeRegion.Items.Add(new RegionSelectionData(getRegistryKey($"BarcodeRegionSelection{k}", "CAM1;0,0:1,1;0,0:1,1;Y")));
            }
            if (listBoxSelectionBacodeRegion.Items.Count > 0) listBoxSelectionBacodeRegion.SelectedIndex = 0;
        }

        private void InitScanModule()
        {
            if (enScanModuleType == ScanModuleType.Dynamsoft)
            {
                bool bIsKeyOnServer = false;
                string[] keyFileData = null;

                //FtpWebRequest FtpRepuest = (FtpWebRequest)WebRequest.Create(sFtpServerKeyPath[2]);
                //FtpRepuest.Method = WebRequestMethods.Ftp.DownloadFile;
                //FtpRepuest.Credentials = new NetworkCredential(sFtpServerKeyPath[0], sFtpServerKeyPath[1]);
                //try
                //{
                //    FtpWebResponse FtpResponse = (FtpWebResponse)FtpRepuest.GetResponse();
                //    StreamReader FtpReaderStream = new StreamReader(FtpResponse.GetResponseStream());
                //    keyFileData = FtpReaderStream.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                //    FtpReaderStream.Close();
                //    FtpResponse.Close();
                //    bIsKeyOnServer = true;
                //}
                //catch { }

                //if (!bIsKeyOnServer)
                {
                    if (File.Exists("DynamsoftKey.txt"))
                    {
                        keyFileData = File.ReadAllLines("DynamsoftKey.txt");
                    }
                    else
                    {
                        labelLicenseKeyStatus.Text = "Do not have any license key file, using ZXing as default!";
                        enScanModuleType = ScanModuleType.Zxing;
                        InitScanZxingModule();
                        return;
                    }
                }

                int CountDaysToStart = (DateTime.ParseExact(keyFileData[0].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[0], "ddMMyyyy", null) - DateTime.Now).Days;
                int CountDaysToEnd = (DateTime.ParseExact(keyFileData[keyFileData.Length - 1].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[1], "ddMMyyyy", null) - DateTime.Now).Days;
                if (CountDaysToStart > 0 || CountDaysToEnd < 0)
                {
                    MessageBox.Show("Fail");
                    labelLicenseKeyStatus.Text = "The license key file is expired, using ZXing as default!";
                    enScanModuleType = ScanModuleType.Zxing;
                    InitScanZxingModule();
                    return;
                }
                labelLicenseKeyStatus.Text = "The license key " + (bIsKeyOnServer ? "form server" : "on local") + $" is vaild {CountDaysToEnd} days";

                string sLicense = "";
                foreach (string sLineKey in keyFileData) sLicense += $"t0068MgAAA{sLineKey.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[2]}=;"; 
                DynamsoftBarcodeReader = new BarcodeReader(sLicense, sProgramTempPath);
                DynamsoftBarcodeReader.VanTamDefaltSetting();
            }

            if (enScanModuleType == ScanModuleType.Zxing)
            {
                labelLicenseKeyStatus.Text = "The license key is unlimited";
                InitScanZxingModule();
            }

            if (enScanModuleType == ScanModuleType.BacodeLib)
            {
                labelLicenseKeyStatus.Text = "The license key is limited";
            }
        }

        private void InitScanZxingModule()
        {
            ZxingBarCodeReader = new ZXing.BarcodeReader();
            ZxingBarCodeReader.AutoRotate = true;
            ZxingBarCodeReader.TryInverted = true;
            ZxingBarCodeReader.Options.TryHarder = true;
            ZxingBarCodeReader.Options.PossibleFormats = new List<ZXing.BarcodeFormat> { ZXing.BarcodeFormat.CODE_128, ZXing.BarcodeFormat.QR_CODE };
        }

        private Point ConvertCoordinates(Point pLocation)
        {
            Size videoSourcePlayerPic = bShowCameraNo2 ? videoSourcePlayer_2.ClientSize : videoSourcePlayer_1.ClientSize;
            Size videoSourcePlayerImg = bShowCameraNo2 ? bmCameraInput_2.Size : bmCameraInput_1.Size;

            pLocation.X = (int)(videoSourcePlayerImg.Width * pLocation.X / (float)videoSourcePlayerPic.Width);
            pLocation.Y = (int)(videoSourcePlayerImg.Height * pLocation.Y / (float)videoSourcePlayerPic.Height);

            if (pLocation.X < 0) pLocation.X = 0;
            if (pLocation.Y < 0) pLocation.Y = 0;
            if (pLocation.X > videoSourcePlayerImg.Width) pLocation.X = videoSourcePlayerImg.Width;
            if (pLocation.Y > videoSourcePlayerImg.Height) pLocation.Y = videoSourcePlayerImg.Height;

            return pLocation;
        }

        /*******************************************************Delegate fuction*******************************************************/
        private void SetCameraDevice(bool bUsingTowCAM, int iCameraDeviceNo_1, int iCameraDeviceNo_2)
        {
            this.bUsingTowCAM = bUsingTowCAM;
            this.iCameraDeviceNo_1 = iCameraDeviceNo_1;
            this.iCameraDeviceNo_2 = iCameraDeviceNo_2;

            setRegistryKey("UsingTowCAM", bUsingTowCAM.ToString());
            setRegistryKey("CameraDevice_1", iCameraDeviceNo_1.ToString());
            setRegistryKey("CameraDevice_2", iCameraDeviceNo_2.ToString());
            if (!bUsingTowCAM)
            {
                videoSourcePlayer_1.BringToFront();
                videoSourcePlayer_2.SendToBack();
                bShowCameraNo2 = false;
            }
            
            StopVideoCaptureDevice();
            StartVideoCaptureDevice();          
        }

        private void SetOutputFileName(string sFileName)
        {
            if (sFileName.IndexOf(".txt") < 0) sFileName += ".txt";
            sOutputFileName = sFileName;
            setRegistryKey("OutputFileName", sFileName);
        }

        private void SetScanModuleType(ScanModuleType enScanModuleType)
        {
            this.enScanModuleType = enScanModuleType;
            InitScanModule();
            setRegistryKey("ScanModuleType", Convert.ToInt32(enScanModuleType).ToString());
        }

        private void SetAutoStopAfterScanFinished(bool bCheckd)
        {
            bAutoStopAfterScanFinished = bCheckd;
            setRegistryKey("AutoStopAfterScanFinished", bCheckd.ToString());
        }

        private void SetAutoStopAfter30s(bool bCheckd)
        {
            bAutoStopAfter30s = bCheckd;
            if (!bAutoStopAfter30s) timerAutoStop.Stop();
            setRegistryKey("AutoStopAfter30s", bCheckd.ToString());
        }


        private void SetAutoSearchBacode(bool bCheckd)
        {
            bAutoSearchBacode = bCheckd;
            setRegistryKey("AutoSearchBacode", bCheckd.ToString());
        }

        private void SetRemoveNoBarcode(bool bCheckd)
        {
            bRemoveNoBarcode = bCheckd;
            LoadListBoxSelectionBacodeRegion();
            setRegistryKey("RemoveNoBarcode", bCheckd.ToString());
        }

        private void SetAutoUpdate(bool bCheckd)
        {
            setRegistryKey("AutoUpdate", bCheckd.ToString());
        }       

        /*******************************************************UPDATE FUNCTION*******************************************************/
        private void CheckUpdate(bool bShowMessage)
        {
            FtpWebRequest FtpRepuest = (FtpWebRequest)WebRequest.Create(sFtpServerProgramPath[2]);
            FtpRepuest.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpRepuest.Credentials = new NetworkCredential(sFtpServerProgramPath[0], sFtpServerProgramPath[1]);
            try
            {
                FtpWebResponse FtpResponse = (FtpWebResponse)FtpRepuest.GetResponse();
                Stream FtpResponseStream = FtpResponse.GetResponseStream();

                Stream fFileStream = File.Create("Scan_Barcode.exx");
                byte[] buffer = new byte[2048];
                int read = 0;
                while ((read = FtpResponseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fFileStream.Write(buffer, 0, read);
                }
                fFileStream.Close();

                if (string.Compare(CalculateMD5("Scan_Barcode.exx"), CalculateMD5(sThisProgramPath)) != 0)
                {                 
                    if (!File.Exists($"{sProgramTempPath}pskill.exe"))
                    {
                        MemoryStream memoryStream = new MemoryStream(Properties.Resources.pskill, false);
                        FileStream fileStream = new FileStream($"{sProgramTempPath}pskill.exe", FileMode.Create);
                        using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                        {
                            byte[] array = new byte[0x80000];
                            int count;
                            while ((count = gzipStream.Read(array, 0, array.Length)) > 0)
                            {
                                fileStream.Write(array, 0, count);
                            }
                        }
                        memoryStream.Close();
                        fileStream.Close();
                    }
                    if (!File.Exists($"{sProgramTempPath}Update.bat"))
                    {
                        StreamWriter WriteToFile = new StreamWriter($"{sProgramTempPath}Update.bat");
                        WriteToFile.WriteLine($@"{sProgramTempPath}pskill Scan_Barcode.exe /accepteula");
                        WriteToFile.WriteLine(@":Try");
                        WriteToFile.WriteLine(@"del Scan_Barcode.exe");
                        WriteToFile.WriteLine(@"if exist Scan_Barcode.exe goto Try");
                        WriteToFile.WriteLine($@"rename Scan_Barcode.exx Scan_Barcode.exe");
                        WriteToFile.WriteLine(@"start Scan_Barcode.exe");
                        WriteToFile.Close();
                    }

                    Process RunFileBat = new Process();
                    RunFileBat.StartInfo.FileName = $"{sProgramTempPath}Update.bat";
                    RunFileBat.StartInfo.CreateNoWindow = false;
                    RunFileBat.Start();
                }
                else
                {
                    File.Delete("Scan_Barcode.exx");
                    if (bShowMessage) MessageBox.Show("No have the new version", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                FtpResponseStream.Close();
                FtpResponse.Close();
            }
            catch
            {
                if (bShowMessage) MessageBox.Show("Can't not connect to server", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /***********************************************************LIBRARY***********************************************************/
        public string getRegistryKey(string nameKey, string Default)
        {
            try
            {
                RegistryKey Key = Registry.CurrentUser.CreateSubKey(sRegistryPath);
                if (Key != null)
                {
                    return Key.GetValue(nameKey).ToString();
                }
                Key.Close();
            }
            catch (Exception) { }
            return Default;
        }

        public void setRegistryKey(string nameKey, string Value)
        {
            RegistryKey Key = Registry.CurrentUser.CreateSubKey(sRegistryPath);
            try
            {
                if (Key != null)
                {
                    Key.SetValue(nameKey, Value);
                    Key.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show($@"Can't set the key '{nameKey}' with value '{Value  }'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CalculateMD5(string FileName)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(File.ReadAllBytes(FileName)));
        }

        private string CalculateMD5(Stream StreamName)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(StreamName));
        }
    }
}

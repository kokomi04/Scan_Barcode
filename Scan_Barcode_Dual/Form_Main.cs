using System;
using System.IO;
using System.Net;
using System.Drawing;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Compression;
using System.Collections.Generic;
using System.Security.Cryptography;

using AForge.Video.DirectShow;

namespace Scan_Barcode_Dual
{
    public partial class Form_Main : Form
    {
        public string sProgramTempPath = $@"{Path.GetTempPath()}Scan_Bacode_Dual\";
        private string sThisProgramPath = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
        private string[] sFtpServerProgramPath = { "oper", "wireless", "ftp://200.166.40.150/Common/Scan_Barcode/Scan_Barcode_Dual.exx" };
        private string[] sFtpServerKeyPath = { "oper", "wireless", "ftp://200.166.40.150/Common/Scan_Barcode/DynamsoftKey.txt" };
        private string sRegistryPath = @"SOFTWARE\Foxconn\ScanBarcodeDual";

        private VideoCaptureDevice videoCaptureDevice_1, videoCaptureDevice_2;
        private int iCameraDeviceNo_1, iCameraDeviceNo_2;
        private Bitmap bmCameraInput_1, bmCameraInput_2;

        private bool bIsDrawingSelection_1, bIsDrawingSelection_2;
        private int iStatusSelection_1 = -1, iStatusSelection_2 = -1;
        private Point pStartSelection;
        private Rectangle rRegionSelection_1, rRegionSelection_2;

        private ScanModuleType enScanModuleType;  
        private BarcodeReader DynamsoftBarcodeReader;
        private ZXing.BarcodeReader ZxingBarCodeReader;
        private bool bAutoStopAfterScanFinished;
        private bool bAutoStopAfter30s;
        private bool bAutoSearchBacode;

        private bool bRemoveNoBarcode;
        private string sOutputFileName;
        private string[] sDataOut_1 = new string[2]; 
        private bool[] bScanOK_1 = new bool[2];
        private string sDataOut_2;
        private bool bScanOK_2;

        public Form_Main()
        {
            if (bool.Parse(getRegistryKey("AutoUpdate", "False")))
            {
                CheckUpdate(false);
            }

            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(sProgramTempPath))
            {
                Directory.CreateDirectory(sProgramTempPath);
            }
       
            iCameraDeviceNo_1 = Convert.ToInt32(getRegistryKey("CameraDevice_1", "0"));
            listBoxSelectionBacodeRegion_1.Items.Add(new RegionSelectionData(getRegistryKey($"RegionSelection_1_0", "0,0:30,30;0,0:10,10")));
            listBoxSelectionBacodeRegion_1.Items.Add(new RegionSelectionData(getRegistryKey($"RegionSelection_1_1", "0,30:30,30;0,0:10,10")));
            listBoxSelectionBacodeRegion_1.SelectedIndex = 0;

            iCameraDeviceNo_2 = Convert.ToInt32(getRegistryKey("CameraDevice_2", "1"));
            listBoxSelectionBacodeRegion_2.Items.Add(new RegionSelectionData(getRegistryKey($"RegionSelection_2_0", "0,0:30,30;0,0:10,10")));
            listBoxSelectionBacodeRegion_2.SelectedIndex = 0;

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
                buttonROIBacodeRegion_1.Enabled = true;
                buttonROIBacodeRegion_2.Enabled = true;
            }
            else
            {
                toolStripMenuItemUnlock.Text = "Unlock";
                buttonROIBacodeRegion_1.Enabled = false;
                buttonROIBacodeRegion_2.Enabled = false;
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
            frmCameraDevice.iCameraDeviceNo_1 = iCameraDeviceNo_1;
            frmCameraDevice.iCameraDeviceNo_2 = iCameraDeviceNo_2;
            frmCameraDevice.ShowDialog(this);
        }
        private void toolStripMenuItemScanType_Click(object sender, EventArgs e)
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

        private void toolStripMenuItemAbout_Click_1(object sender, EventArgs e)
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
            //if (bAutoStopAfter30s)
            //{
            //    timerAutoStop.Stop();  //Reset timer
            //    timerAutoStop.Start();
            //}        
        }

        private void StartVideoCaptureDevice()
        {
            try
            {
                FilterInfoCollection filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (filterInfoCollection.Count > iCameraDeviceNo_1 && filterInfoCollection.Count > iCameraDeviceNo_2)
                {
                    if (!videoSourcePlayer_1.IsRunning)
                    {
                        videoCaptureDevice_1 = new VideoCaptureDevice(filterInfoCollection[iCameraDeviceNo_1].MonikerString);
                        videoSourcePlayer_1.VideoSource = videoCaptureDevice_1;
                        videoSourcePlayer_1.Start();
                    }
                    if (!videoSourcePlayer_2.IsRunning)
                    {
                        videoCaptureDevice_2 = new VideoCaptureDevice(filterInfoCollection[iCameraDeviceNo_2].MonikerString);
                        videoSourcePlayer_2.VideoSource = videoCaptureDevice_2;
                        videoSourcePlayer_2.Start();
                    }                   
                }
                else
                {
                    MessageBox.Show("The lost the camera device. Please to check the camera device again!", "Error start camera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can not start the camera!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartScanBarcode()
        {
            buttonStatust_1.Text = "Scaning";
            bmCameraInput_1 = null;
            textBoxDataShow_1.Text = null;

            buttonStatust_2.Text = "Scaning";
            bmCameraInput_2 = null;
            textBoxDataShow_2.Text = null;

            timerScan_1.Start();
            bScanOK_1[0] = bScanOK_1[1] = false;

            timerScan_2.Start();
            bScanOK_2 = false;
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

        private void StopVideoCaptureDevice(int iCamera = 0)
        {
            if (iCamera == 1 || iCamera == 0) videoSourcePlayer_1.Stop();
            if (iCamera == 2 || iCamera == 0) videoSourcePlayer_2.Stop();
        }

        private void StopScanBarcode(int iCamera = 0)
        {
            if (iCamera == 1 || iCamera == 0)
            {
                timerScan_1.Stop();
                bmCameraInput_1 = null;
            }
            if (iCamera == 2 || iCamera == 0)
            {
                timerScan_2.Stop();
                bmCameraInput_2 = null;
            }
        }

        private void videoSourcePlayer_1_Paint(object sender, PaintEventArgs e)
        {
            if (iStatusSelection_1 == -1)
            {
                e.Graphics.DrawRectangle(Pens.Red, ((RegionSelectionData)listBoxSelectionBacodeRegion_1.Items[0]).GetRectangle());
                e.Graphics.DrawRectangle(Pens.Red, ((RegionSelectionData)listBoxSelectionBacodeRegion_1.Items[1]).GetRectangle());
                e.Graphics.DrawString($"SN", new Font("Arial", 12), new SolidBrush(Color.Red), ((RegionSelectionData)listBoxSelectionBacodeRegion_1.Items[0]).LocationText);
                e.Graphics.DrawString($"Lo", new Font("Arial", 12), new SolidBrush(Color.Red), ((RegionSelectionData)listBoxSelectionBacodeRegion_1.Items[1]).LocationText);
            }
            else
            {
                e.Graphics.DrawRectangle(Pens.Blue, rRegionSelection_1);
            }
        }

        private void videoSourcePlayer_2_Paint(object sender, PaintEventArgs e)
        {
            if (iStatusSelection_2 == -1)
            {
                e.Graphics.DrawRectangle(Pens.Red, ((RegionSelectionData)listBoxSelectionBacodeRegion_2.Items[0]).GetRectangle());
                e.Graphics.DrawString($"SN", new Font("Arial", 12), new SolidBrush(Color.Red), ((RegionSelectionData)listBoxSelectionBacodeRegion_2.Items[0]).LocationText);
            }
            else
            {
                e.Graphics.DrawRectangle(Pens.Blue, rRegionSelection_2);
            }
        }

        private void videoSourcePlayer_1_MouseDown(object sender, MouseEventArgs e)
        {
            if (iStatusSelection_1 >= 0)
            {
                bIsDrawingSelection_1 = true;
                pStartSelection = e.Location;
            }
        }

        private void videoSourcePlayer_2_MouseDown(object sender, MouseEventArgs e)
        {
            if (iStatusSelection_2 >= 0)
            {
                bIsDrawingSelection_2 = true;
                pStartSelection = e.Location;
            }
        }

        private void videoSourcePlayer_1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bIsDrawingSelection_1)
            {
                rRegionSelection_1 = new Rectangle(Math.Min(pStartSelection.X, e.X), Math.Min(pStartSelection.Y, e.Y), Math.Abs(pStartSelection.X - e.Location.X), Math.Abs(pStartSelection.Y - e.Location.Y));
            }
        }

        private void videoSourcePlayer_2_MouseMove(object sender, MouseEventArgs e)
        {
            if (bIsDrawingSelection_2)
            {
                rRegionSelection_2 = new Rectangle(Math.Min(pStartSelection.X, e.X), Math.Min(pStartSelection.Y, e.Y), Math.Abs(pStartSelection.X - e.Location.X), Math.Abs(pStartSelection.Y - e.Location.Y));
            }
        }
        private void videoSourcePlayer_1_MouseUp(object sender, MouseEventArgs e)
        {
            if (iStatusSelection_1 >= 0)
            {
                bIsDrawingSelection_1 = false;
                ((RegionSelectionData)listBoxSelectionBacodeRegion_1.SelectedItem).UpdateValue(pStartSelection, e.Location, ConvertCoordinates_1(pStartSelection), ConvertCoordinates_1(e.Location));
                listBoxSelectionBacodeRegion_1.Items[listBoxSelectionBacodeRegion_1.SelectedIndex] = listBoxSelectionBacodeRegion_1.Items[listBoxSelectionBacodeRegion_1.SelectedIndex];
                iStatusSelection_1 = -1;

                listBoxSelectionBacodeRegion_1_Save();
            }
        }

        private void videoSourcePlayer_2_MouseUp(object sender, MouseEventArgs e)
        {
            if (iStatusSelection_2 >= 0)
            {
                bIsDrawingSelection_2 = false;
                ((RegionSelectionData)listBoxSelectionBacodeRegion_2.SelectedItem).UpdateValue(pStartSelection, e.Location, ConvertCoordinates_2(pStartSelection), ConvertCoordinates_2(e.Location));
                listBoxSelectionBacodeRegion_2.Items[listBoxSelectionBacodeRegion_2.SelectedIndex] = listBoxSelectionBacodeRegion_2.Items[listBoxSelectionBacodeRegion_2.SelectedIndex];
                iStatusSelection_2 = -1;

                listBoxSelectionBacodeRegion_2_Save();
            }
        }

        private void buttonROI_1_Click(object sender, EventArgs e)
        {
            if (listBoxSelectionBacodeRegion_1.SelectedIndex < 0 || videoCaptureDevice_1 == null) return;
            if (!videoCaptureDevice_1.IsRunning)
            {
                toolStripMenuItemStartScan_Click(null, null);
            }
            iStatusSelection_1 = listBoxSelectionBacodeRegion_1.SelectedIndex;
        }

        private void buttonROI_2_Click(object sender, EventArgs e)
        {
            if (listBoxSelectionBacodeRegion_2.SelectedIndex < 0 || videoCaptureDevice_2 == null) return;
            if (!videoCaptureDevice_2.IsRunning)
            {
                toolStripMenuItemStartScan_Click(null, null);
            }
            iStatusSelection_2 = listBoxSelectionBacodeRegion_2.SelectedIndex;
        }

        private void listBoxSelectionBacodeRegion_1_Save()
        {
            for (int k = 0; k < 2; k++)
            {
                setRegistryKey($"RegionSelection_1_{k}", ((RegionSelectionData)listBoxSelectionBacodeRegion_1.Items[k]).GetDataRegionSelection());
            }
        }

        private void listBoxSelectionBacodeRegion_2_Save()
        {
            setRegistryKey($"RegionSelection_2_0", ((RegionSelectionData)listBoxSelectionBacodeRegion_2.Items[0]).GetDataRegionSelection());
        }            

        private void timerScan_1_Tick(object sender, EventArgs e)
        {
            if (bmCameraInput_1 == null) return;
            Bitmap bmScanCode;

            for (int k = 0; k < 2; k++)
            {
                if (bScanOK_1[k]) continue;

                try
                {
                    bmScanCode = bmCameraInput_1.Clone(((RegionSelectionData)listBoxSelectionBacodeRegion_1.Items[k]).GetImageRectangle(), bmCameraInput_1.PixelFormat);
                }
                catch { continue; }               
                              
                try
                {
                    string DecodeResult = DynamsoftBarcodeReader.DecodeBitmap(bmScanCode)[0];
                    if (DecodeResult == null || DecodeResult.Length <= 0) continue;
                                          
                    if(k == 0)
                        textBoxDataShow_1.AppendText($"SN_{DecodeResult}{Environment.NewLine}");
                    else
                        textBoxDataShow_1.AppendText($"Lo_{DecodeResult}{Environment.NewLine}");
                    sDataOut_1[k] = DecodeResult.Trim();
                    bScanOK_1[k] = true;                                    
                }
                catch { continue; }              
            }

            if (bScanOK_1[0] && bScanOK_1[1])
            {
                buttonStatust_1.Text = "Scan finished";
                StreamWriter writeFile = new StreamWriter($@"{Application.StartupPath}\Barcode1.txt");
                writeFile.WriteLine(sDataOut_1[0]);
                writeFile.Close();
                if (iStatusSelection_1 < 0)
                {
                    StopVideoCaptureDevice(1);
                }
            }
        }

        private void timerAutoStop_Tick(object sender, EventArgs e)
        {
            //if (iStatusSelection == -1)
            //{
            //    toolStripMenuItemStopScan_Click(null, null);
            //    timerAutoStop.Stop();
            //    if (!CheckScanOK())
            //    {
            //        StopScanBarcode();
            //        buttonStatust.Text = "Scan error";
            //    }
            //}
        }

        private void timerScan_2_Tick(object sender, EventArgs e)
        {
            if (bmCameraInput_2 == null || bScanOK_2) return;
            Bitmap bmScanCode2;        
            try
            {
                bmScanCode2 = bmCameraInput_2.Clone(((RegionSelectionData)listBoxSelectionBacodeRegion_2.Items[0]).GetImageRectangle(), bmCameraInput_2.PixelFormat);
            }
            catch { return; }                             
            
            try
            {
                string DecodeResult2 = DynamsoftBarcodeReader.DecodeBitmap(bmScanCode2)[0];
                if (DecodeResult2 == null || DecodeResult2.Length <= 0) return;
                
                textBoxDataShow_2.AppendText($"SN_{DecodeResult2}{Environment.NewLine}");
                sDataOut_2 = DecodeResult2.Trim();
                bScanOK_2 = true;                        
            
            }
            catch { return; }

            if (bScanOK_2)
            {
                buttonStatust_2.Text = "Scan finished";
                StreamWriter writeFile = new StreamWriter($@"{Application.StartupPath}\Barcode2.txt");
                writeFile.WriteLine(sDataOut_2);
                writeFile.Close();
                if (iStatusSelection_2 < 0)
                {
                    StopVideoCaptureDevice(2);
                }
            }
        }

        private void InitScanModule()
        {
            if (enScanModuleType == ScanModuleType.Dynamsoft)
            {
                bool bIsKeyOnServer = false;
                string[] keyFileData = null;

                FtpWebRequest FtpRepuest = (FtpWebRequest)WebRequest.Create(sFtpServerKeyPath[2]);
                FtpRepuest.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpRepuest.Credentials = new NetworkCredential(sFtpServerKeyPath[0], sFtpServerKeyPath[1]);
                try
                {
                    FtpWebResponse FtpResponse = (FtpWebResponse)FtpRepuest.GetResponse();
                    StreamReader FtpReaderStream = new StreamReader(FtpResponse.GetResponseStream());
                    keyFileData = FtpReaderStream.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    FtpReaderStream.Close();
                    FtpResponse.Close();
                    bIsKeyOnServer = true;
                }
                catch { }

                if (!bIsKeyOnServer)
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

        private Point ConvertCoordinates_1(Point pLocation)
        {
            if (videoSourcePlayer_1.ClientSize.Width / (float)videoSourcePlayer_1.ClientSize.Height > bmCameraInput_1.Size.Width / (float)bmCameraInput_1.Size.Height)
            {
                pLocation.Y = (int)(bmCameraInput_1.Size.Height * pLocation.Y / (float)videoSourcePlayer_1.ClientSize.Height);
                pLocation.X = (int)((pLocation.X - ((videoSourcePlayer_1.ClientSize.Width - (bmCameraInput_1.Size.Width * videoSourcePlayer_1.ClientSize.Height / bmCameraInput_1.Size.Height)) / 2)) * bmCameraInput_1.Size.Height / (float)videoSourcePlayer_1.ClientSize.Height);
            }
            else
            {
                pLocation.X = (int)(bmCameraInput_1.Size.Width * pLocation.X / (float)videoSourcePlayer_1.ClientSize.Width);
                pLocation.Y = (int)((pLocation.Y - ((videoSourcePlayer_1.ClientSize.Height - (bmCameraInput_1.Size.Height * videoSourcePlayer_1.ClientSize.Width / bmCameraInput_1.Size.Width)) / 2)) * bmCameraInput_1.Size.Width / videoSourcePlayer_1.ClientSize.Width);
            }
            if (pLocation.X < 0) pLocation.X = 0;
            if (pLocation.Y < 0) pLocation.Y = 0;
            if (pLocation.X > bmCameraInput_1.Size.Width) pLocation.X = bmCameraInput_1.Size.Width;
            if (pLocation.Y > bmCameraInput_1.Size.Height) pLocation.Y = bmCameraInput_1.Size.Height;

            return pLocation;
        }

        private Point ConvertCoordinates_2(Point pLocation)
        {
            if (videoSourcePlayer_2.ClientSize.Width / (float)videoSourcePlayer_2.ClientSize.Height > bmCameraInput_2.Size.Width / (float)bmCameraInput_2.Size.Height)
            {
                pLocation.Y = (int)(bmCameraInput_2.Size.Height * pLocation.Y / (float)videoSourcePlayer_2.ClientSize.Height);
                pLocation.X = (int)((pLocation.X - ((videoSourcePlayer_2.ClientSize.Width - (bmCameraInput_2.Size.Width * videoSourcePlayer_2.ClientSize.Height / bmCameraInput_2.Size.Height)) / 2)) * bmCameraInput_2.Size.Height / (float)videoSourcePlayer_2.ClientSize.Height);
            }
            else
            {
                pLocation.X = (int)(bmCameraInput_2.Size.Width * pLocation.X / (float)videoSourcePlayer_2.ClientSize.Width);
                pLocation.Y = (int)((pLocation.Y - ((videoSourcePlayer_2.ClientSize.Height - (bmCameraInput_2.Size.Height * videoSourcePlayer_2.ClientSize.Width / bmCameraInput_2.Size.Width)) / 2)) * bmCameraInput_2.Size.Width / videoSourcePlayer_2.ClientSize.Width);
            }
            if (pLocation.X < 0) pLocation.X = 0;
            if (pLocation.Y < 0) pLocation.Y = 0;
            if (pLocation.X > bmCameraInput_2.Size.Width) pLocation.X = bmCameraInput_2.Size.Width;
            if (pLocation.Y > bmCameraInput_2.Size.Height) pLocation.Y = bmCameraInput_2.Size.Height;

            return pLocation;
        }

        /*******************************************************Delegate fuction*******************************************************/
        private void SetCameraDevice(int iCameraDeviceNo_1, int iCameraDeviceNo_2)
        {
            this.iCameraDeviceNo_1 = iCameraDeviceNo_1;
            this.iCameraDeviceNo_2 = iCameraDeviceNo_2;

            setRegistryKey("CameraDevice_1", iCameraDeviceNo_1.ToString());
            setRegistryKey("CameraDevice_2", iCameraDeviceNo_2.ToString());           

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

                Stream fFileStream = File.Create("Scan_Barcode_Dual.exx");
                byte[] buffer = new byte[2048];
                int read = 0;
                while ((read = FtpResponseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fFileStream.Write(buffer, 0, read);
                }
                fFileStream.Close();

                if (string.Compare(CalculateMD5("Scan_Barcode_Dual.exx"), CalculateMD5(sThisProgramPath)) != 0)
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
                        WriteToFile.WriteLine($@"{sProgramTempPath}pskill Scan_Barcode_Dual.exe /accepteula");
                        WriteToFile.WriteLine(@":Try");
                        WriteToFile.WriteLine(@"del Scan_Barcode_Dual.exe");
                        WriteToFile.WriteLine(@"if exist Scan_Barcode_Dual.exe goto Try");
                        WriteToFile.WriteLine($@"rename Scan_Barcode_Dual.exx Scan_Barcode_Dual.exe");
                        WriteToFile.WriteLine(@"start Scan_Barcode_Dual.exe");
                        WriteToFile.Close();
                    }

                    Process RunFileBat = new Process();
                    RunFileBat.StartInfo.FileName = $"{sProgramTempPath}Update.bat";
                    RunFileBat.StartInfo.CreateNoWindow = false;
                    RunFileBat.Start();
                }
                else
                {
                    File.Delete("Scan_Barcode_Dual.exx");
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
                RegistryKey key = Registry.LocalMachine.CreateSubKey(sRegistryPath);
                if (key != null)
                {
                    return key.GetValue(nameKey).ToString();
                }
                key.Close();
            }
            catch (Exception) { }
            return Default;
        }

        public void setRegistryKey(string nameKey, string Value)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.CreateSubKey(sRegistryPath);
                if (key != null)
                {
                    key.SetValue(nameKey, Value);
                    key.Close();
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
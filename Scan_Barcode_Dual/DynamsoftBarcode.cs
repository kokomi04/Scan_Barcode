using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.IO.Compression;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Scan_Barcode_Dual
{
    class BarcodeReader
    {
        public string sProgramTempPath = $@"{Application.StartupPath}\";

        public enum EnumBarcodeFormat
        {
            All = 0x1E0003FF,
            OneD = 0x3FF,
            CODE_39 = 1,
            CODE_128 = 2,
            CODE_93 = 4,
            CODABAR = 8,
            ITF = 0x10,
            EAN_13 = 0x20,
            EAN_8 = 0x40,
            UPC_A = 0x80,
            UPC_E = 0x100,
            INDUSTRIAL_25 = 0x200,
            PDF417 = 0x2000000,
            QR_CODE = 0x4000000,
            DATAMATRIX = 0x8000000,
            AZTEC = 0x10000000
        }

        public enum TextFilterMode
        {
            TFM_Disable = 1,
            TFM_Enable
        }

        public enum RegionPredetectionMode
        {
            RPM_Disable = 1,
            RPM_Enable
        }

        public enum BarcodeInvertMode
        {
            BIM_DarkOnLight,
            BIM_LightOnDark
        }

        public enum ColourImageConvertMode
        {
            CICM_Auto,
            CICM_Grayscale
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PublicRuntimeSettings
        {
            public int mTimeout;
            public int mPDFRasterDPI;
            public TextFilterMode mTextFilterMode;
            public RegionPredetectionMode mRegionPredetectionMode;
            public string mLocalizationAlgorithmPriority;
            public int mBarcodeFormatIds;
            public int mMaxAlgorithmThreadCount;
            public int mTextureDetectionSensitivity;
            public int mDeblurLevel;
            public int mAntiDamageLevel;
            public int mMaxDimOfFullImageAsBarcodeZone;
            public int mMaxBarcodesCount;
            public BarcodeInvertMode mBarcodeInvertMode;
            public int mScaleDownThreshold;
            public int mGrayEqualizationSensitivity;
            public int mEnableFillBinaryVacancy;
            public ColourImageConvertMode mColourImageConvertMode;
            public string mReserved;
            public int mExpectedBarcodesCount;
            public int mBinarizationBlockSize;
        }

        private enum EnumImagePixelFormat
        {
            IPF_Binary,
            IPF_BinaryInverted,
            IPF_GrayScaled,
            IPF_NV21,
            IPF_RGB_565,
            IPF_RGB_555,
            IPF_RGB_888,
            IPF_ARGB_8888,
            IPF_RGB_161616,
            IPF_ARGB_16161616
        }

        private enum EnumErrorCode
        {
            DBRERR_LICENSE_DLL_MISSING = -0x273A,
            DBRERR_LICENSEKEY_NOT_MATCHED = -0x273B,
            DBRERR_REQUESTED_FAILED = -0x273C,
            DBRERR_LICENSE_INIT_FAILED = -0x273D,
            DBR_AZTEC_LICENSE_INVALID = -0x2739,
            DBR_PARAMETER_VALUE_INVALID = -0x2736,
            DBR_JSON_NAME_REFERENCE_INVALID,
            DBR_TEMPLATE_NAME_INVALID,
            DBR_JSON_NAME_VALUE_DUPLICATED,
            DBR_JSON_NAME_KEY_MISSING,
            DBR_JSON_VALUE_INVALID,
            DBR_JSON_KEY_INVALID,
            DBR_JSON_TYPE_INVALID,
            DBR_JSON_PARSE_FAILED,
            DBR_RECOGNITION_TIMEOUT = -0x272A,
            DBR_CUSTOM_MODULESIZE_INVALID,
            DBR_CUSTOM_SIZE_INVALID,
            DBR_PAGE_NUMBER_INVALID,
            DBR_PDF_DLL_MISSING,
            DBR_PDF_READ_FAILED,
            DBR_DATAMATRIX_LICENSE_INVALID,
            DBR_PDF417_LICENSE_INVALID,
            DBR_DIB_BUFFER_INVALID,
            DBR_1D_LICENSE_INVALID,
            DBR_QR_LICENSE_INVALID,
            DBR_TIFF_READ_FAILED = -0x271D,
            DBR_IMAGE_READ_FAILED,
            DBR_MAX_BARCODE_NUMBER_INVALID,
            DBR_CUSTOM_REGION_INVALID,
            DBR_BARCODE_FORMAT_INVALID,
            DBR_INDEX_INVALID,
            DBR_BPP_NOT_SUPPORTED,
            DBR_FILETYPE_NOT_SUPPORTED,
            DBR_FILE_NOT_FOUND,
            DBR_LICENSE_EXPIRED,
            DBR_LICENSE_INVALID,
            DBR_NULL_REFERENCE,
            DBR_NO_MEMORY,
            DBR_UNKNOWN,
            DBR_SUCCESS = 0,
            DBR_SYSTEM_EXCEPTION
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct tagPublicRuntimeSettings
        {
            public int mTimeout;
            public int mPDFRasterDPI;
            public TextFilterMode mTextFilterMode;
            public RegionPredetectionMode mRegionPredetectionMode;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x40)]
            public string mLocalizationAlgorithmPriority;
            public int mBarcodeFormatIds;
            public int mMaxAlgorithmThreadCount;
            public int mTextureDetectionSensitivity;
            public int mDeblurLevel;
            public int mAntiDamageLevel;
            public int mMaxDimOfFullImageAsBarcodeZone;
            public int mMaxBarcodesCount;
            public BarcodeInvertMode mBarcodeInvertMode;
            public int mScaleDownThreshold;
            public int mGrayEqualizationSensitivity;
            public int mEnableFillBinaryVacancy;
            public ColourImageConvertMode mColourImageConvertMode;
            public int mExpecetedBarcodesCount;
            public int mBinarizationBlockSize;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0xF8)]
            public string mReserved;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct tagSTextResult
        {
            public EnumBarcodeFormat emBarcodeFormat;
            public IntPtr pszBarcodeFormatString;
            public IntPtr pszBarcodeText;
            public IntPtr pBarcodeBytes;
            public int nBarcodeBytesLength;
            public IntPtr pLocalizationResult;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct tagSTextResultArray
        {
            public int nResultsCount;
            public IntPtr ppResults;
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string strDllName);

        [DllImport("kernel32.dll")]
        private static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string strProcName);

        [DllImport("kernel32.dll")]
        private static extern void CopyMemory(IntPtr destination, IntPtr source, int length);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr DBR_CreateInstance();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void DBR_DestroyInstance(IntPtr hBarcode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int DBR_InitLicense(IntPtr hBarcode, string strLicense);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int DBR_DecodeBuffer(IntPtr hBarcode, IntPtr pBuffer, int iWidth, int iHeight, int iStride, EnumImagePixelFormat format, string templateName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int DBR_GetAllTextResults(IntPtr hBarcode, ref IntPtr pTextResultArray);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int DBR_FreeTextResults(ref IntPtr pTextResultArray);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int DBR_GetRuntimeSettings(IntPtr hBarcode, ref tagPublicRuntimeSettings settings);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int DBR_UpdateRuntimeSettings(IntPtr hBarcode, ref tagPublicRuntimeSettings settings, IntPtr pBuffer, int iLength);

        private IntPtr m_OMPModule = IntPtr.Zero;
        private IntPtr m_dbrModule = IntPtr.Zero;
        private IntPtr m_pInstance = IntPtr.Zero;

        private Hashtable m_tbl = new Hashtable();

        private object objLibLock = new object();

        public BarcodeReader(string strLicenseKey, string sProgramTempPath)
        {
            this.sProgramTempPath = sProgramTempPath;
            m_pInstance = DBRCreateInstace();
            RegisterDBRInstance(m_pInstance);
            DBRInitLicense(m_pInstance, strLicenseKey);
        }

        public BarcodeReader(string strLicenseKey)
        {
            m_pInstance = DBRCreateInstace();
            RegisterDBRInstance(m_pInstance);
            DBRInitLicense(m_pInstance, strLicenseKey);
        }

        ~BarcodeReader()
        {
            lock (m_tbl)
            {
                foreach (object obj in m_tbl)
                {
                    IntPtr hBarcode = (IntPtr)((DictionaryEntry)obj).Key;
                    DBRDestroyInstace(hBarcode);
                    hBarcode = IntPtr.Zero;
                }
            }
            FreeDBR();
        }

        private void RegisterDBRInstance(IntPtr ptr)
        {
            lock (m_tbl)
            {
                if (!m_tbl.ContainsKey(ptr))
                {
                    m_tbl.Add(ptr, 0);
                }
            }
        }

        private void LoadDBR()
        {
            lock (objLibLock)
            {
                if (m_dbrModule == IntPtr.Zero)
                {
                    string OMPPath = $"{sProgramTempPath}vcomp110.dll";
                    if (!File.Exists(OMPPath))
                    {
                        MemoryStream memoryStreamOMP = new MemoryStream((IntPtr.Size != 4 ? Properties.Resources.vcomp110x64 : Properties.Resources.vcomp110x86), false);
                        FileStream fileStreamOMP = new FileStream(OMPPath, FileMode.Create);
                        using (GZipStream gzipStreamDBR = new GZipStream(memoryStreamOMP, CompressionMode.Decompress))
                        {
                            byte[] array = new byte[0x80000];
                            int count;
                            while ((count = gzipStreamDBR.Read(array, 0, array.Length)) > 0)
                            {
                                fileStreamOMP.Write(array, 0, count);
                            }
                        }
                        memoryStreamOMP.Close();
                        fileStreamOMP.Close();
                    }

                    string DBRFullPath = $"{sProgramTempPath}DynamsoftBarcodeReader.dll";
                    if (!File.Exists(DBRFullPath))
                    {
                        MemoryStream memoryStreamDBR = new MemoryStream((IntPtr.Size != 4 ? Properties.Resources.DynamsoftBarcodeReaderx64 : Properties.Resources.DynamsoftBarcodeReaderx86), false);
                        FileStream fileStreamDBR = new FileStream(DBRFullPath, FileMode.Create);
                        using (GZipStream gzipStreamDBR = new GZipStream(memoryStreamDBR, CompressionMode.Decompress))
                        {
                            byte[] array = new byte[0x80000];
                            int count;
                            while ((count = gzipStreamDBR.Read(array, 0, array.Length)) > 0)
                            {
                                fileStreamDBR.Write(array, 0, count);
                            }
                        }
                        memoryStreamDBR.Close();
                        fileStreamDBR.Close();
                    }

                    m_OMPModule = LoadLibrary(OMPPath);
                    m_dbrModule = LoadLibrary(DBRFullPath);
                    if (m_dbrModule == IntPtr.Zero)
                    {
                        throw new Exception("Failed to load the DBR_Library");
                    }
                }
            }
        }

        private void FreeDBR()
        {
            lock (objLibLock)
            {
                if (m_dbrModule != IntPtr.Zero)
                {
                    FreeLibrary(m_dbrModule);
                    m_dbrModule = IntPtr.Zero;
                }

                if (m_OMPModule != IntPtr.Zero)
                {
                    FreeLibrary(m_OMPModule);
                    m_OMPModule = IntPtr.Zero;
                }
            }
        }

        private IntPtr DBRCreateInstace()
        {
            if (m_dbrModule == IntPtr.Zero)
            {
                LoadDBR();
            }
            IntPtr procAddress = GetProcAddress(m_dbrModule, "DBR_CreateInstance");
            if (procAddress == IntPtr.Zero)
            {
                throw new Exception("Failed to get the address of DBR_CreateInstance.");
            }
            DBR_CreateInstance dbr_CreateInstance = (DBR_CreateInstance)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DBR_CreateInstance));
            if (dbr_CreateInstance == null)
            {
                throw new Exception("Failed to get the DBR_CreateInstance function");
            }
            return dbr_CreateInstance();
        }

        private void DBRDestroyInstace(IntPtr hBarcode)
        {
            if (m_dbrModule == IntPtr.Zero)
            {
                LoadDBR();
            }
            IntPtr procAddress = GetProcAddress(m_dbrModule, "DBR_DestroyInstance");
            if (procAddress == IntPtr.Zero)
            {
                throw new Exception("Failed to get the address of DBR_DestroyInstance.");
            }
            DBR_DestroyInstance dbr_DestroyInstance = (DBR_DestroyInstance)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DBR_DestroyInstance));
            if (dbr_DestroyInstance == null)
            {
                throw new Exception("Failed to get the DBR_DestroyInstance function");
            }
            dbr_DestroyInstance(hBarcode);
        }

        private int DBRInitLicense(IntPtr hBarcode, string strLicense)
        {
            if (m_dbrModule == IntPtr.Zero)
            {
                LoadDBR();
            }
            IntPtr procAddress = GetProcAddress(m_dbrModule, "DBR_InitLicense");
            if (procAddress == IntPtr.Zero)
            {
                throw new Exception("Failed to get the address of DBR_InitLicense.");
            }
            DBR_InitLicense dbr_InitLicense = (DBR_InitLicense)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DBR_InitLicense));
            if (dbr_InitLicense == null)
            {
                throw new Exception("Failed to get the DBR_InitLicense function");
            }
            return dbr_InitLicense(hBarcode, strLicense);
        }

        private int DBRDecodeBuffer(IntPtr hBarcode, IntPtr pBuffer, int iWidth, int iHeight, int iStride, EnumImagePixelFormat format, string templateName)
        {
            if (m_dbrModule == IntPtr.Zero)
            {
                LoadDBR();
            }
            IntPtr procAddress = GetProcAddress(m_dbrModule, "DBR_DecodeBuffer");
            if (procAddress == IntPtr.Zero)
            {
                throw new Exception("Failed to get the address of DBR_DecodeBuffer.");
            }
            DBR_DecodeBuffer dbr_DecodeBuffer = (DBR_DecodeBuffer)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DBR_DecodeBuffer));
            if (dbr_DecodeBuffer == null)
            {
                throw new Exception("Failed to get the DBR_DecodeBuffer function");
            }
            return dbr_DecodeBuffer(hBarcode, pBuffer, iWidth, iHeight, iStride, format, templateName);
        }

        private int DBRGetAllTextResults(IntPtr hBarcode, ref IntPtr pTextResultArray)
        {
            if (m_dbrModule == IntPtr.Zero)
            {
                LoadDBR();
            }
            IntPtr procAddress = GetProcAddress(m_dbrModule, "DBR_GetAllTextResults");
            if (procAddress == IntPtr.Zero)
            {
                throw new Exception("Failed to get the address of DBR_GetAllTextResults.");
            }
            DBR_GetAllTextResults dbr_GetAllTextResults = (DBR_GetAllTextResults)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DBR_GetAllTextResults));
            if (dbr_GetAllTextResults == null)
            {
                throw new Exception("Failed to get the DBR_GetAllTextResults function");
            }
            return dbr_GetAllTextResults(hBarcode, ref pTextResultArray);
        }

        private int DBRFreeTextResults(ref IntPtr pTextResultArray)
        {
            if (m_dbrModule == IntPtr.Zero)
            {
                LoadDBR();
            }
            IntPtr procAddress = GetProcAddress(m_dbrModule, "DBR_FreeTextResults");
            if (procAddress == IntPtr.Zero)
            {
                throw new Exception("Failed to get the address of DBR_FreeTextResults.");
            }
            DBR_FreeTextResults dbr_FreeTextResults = (DBR_FreeTextResults)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DBR_FreeTextResults));
            if (dbr_FreeTextResults == null)
            {
                throw new Exception("Failed to get the DBR_FreeTextResults function");
            }
            return dbr_FreeTextResults(ref pTextResultArray);
        }

        private string[] GetAllTextResults()
        {
            string[] array = null;
            IntPtr zero = IntPtr.Zero;
            bool flag = false;
            checked
            {
                try
                {
                    flag = true;
                    DBRGetAllTextResults(m_pInstance, ref zero);
                    if (zero != IntPtr.Zero)
                    {
                        tagSTextResultArray tagSTextResultArray = (tagSTextResultArray)Marshal.PtrToStructure(zero, typeof(tagSTextResultArray));
                        array = new string[tagSTextResultArray.nResultsCount];
                        if (tagSTextResultArray.nResultsCount > 0 && tagSTextResultArray.nResultsCount < 0x7FFFFFFF)
                        {
                            IntPtr[] array2 = new IntPtr[tagSTextResultArray.nResultsCount];
                            Marshal.Copy(tagSTextResultArray.ppResults, array2, 0, tagSTextResultArray.nResultsCount);
                            for (int i = 0; i < tagSTextResultArray.nResultsCount; i++)
                            {
                                if (array2[i] != IntPtr.Zero)
                                {
                                    tagSTextResult tagBR = (tagSTextResult)Marshal.PtrToStructure(array2[i], typeof(tagSTextResult));
                                    byte[] m_aryData;
                                    byte[] array3 = new byte[tagBR.nBarcodeBytesLength];
                                    Marshal.Copy(tagBR.pBarcodeBytes, array3, 0, tagBR.nBarcodeBytesLength);
                                    if (array3[array3.Length - 1] == 0)
                                    {
                                        m_aryData = new byte[tagBR.nBarcodeBytesLength - 1];
                                        Marshal.Copy(tagBR.pBarcodeBytes, m_aryData, 0, tagBR.nBarcodeBytesLength - 1);
                                    }
                                    else
                                    {
                                        m_aryData = new byte[tagBR.nBarcodeBytesLength];
                                        Marshal.Copy(tagBR.pBarcodeBytes, m_aryData, 0, tagBR.nBarcodeBytesLength);
                                    }
                                    array[i] = Encoding.Default.GetString(m_aryData);
                                }
                            }
                        }
                    }
                    DBRFreeTextResults(ref zero);
                    flag = false;
                }
                catch
                {
                    if (flag)
                    {
                        DBRFreeTextResults(ref zero);
                    }
                }
                return array;
            }
        }

        private int DBRGetRuntimeSettings(IntPtr hBarcode, ref tagPublicRuntimeSettings settings)
        {
            if (m_dbrModule == IntPtr.Zero)
            {
                LoadDBR();
            }
            IntPtr procAddress = GetProcAddress(m_dbrModule, "DBR_GetRuntimeSettings");
            if (procAddress == IntPtr.Zero)
            {
                throw new Exception("Failed to get the address of DBR_GetRuntimeSettings");
            }
            DBR_GetRuntimeSettings dbr_GetRuntimeSettings = (DBR_GetRuntimeSettings)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DBR_GetRuntimeSettings));
            if (dbr_GetRuntimeSettings == null)
            {
                throw new Exception("Failed to get the DBR_GetRuntimeSettings function");
            }
            return dbr_GetRuntimeSettings(hBarcode, ref settings);
        }

        private int DBRUpdateRuntimeSettings(IntPtr hBarcode, ref tagPublicRuntimeSettings settings, IntPtr errMsg, int errLen)
        {
            if (m_dbrModule == IntPtr.Zero)
            {
                LoadDBR();
            }
            IntPtr procAddress = GetProcAddress(m_dbrModule, "DBR_UpdateRuntimeSettings");
            if (procAddress == IntPtr.Zero)
            {
                throw new Exception("Failed to get the address of DBR_UpdateRuntimeSettings");
            }
            DBR_UpdateRuntimeSettings dbr_UpdateRuntimeSettings = (DBR_UpdateRuntimeSettings)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DBR_UpdateRuntimeSettings));
            if (dbr_UpdateRuntimeSettings == null)
            {
                throw new Exception("Failed to get the DBR_UpdateRuntimeSettings function");
            }
            return dbr_UpdateRuntimeSettings(hBarcode, ref settings, errMsg, errLen);
        }

        public PublicRuntimeSettings GetRuntimeSettings()
        {
            PublicRuntimeSettings result = default(PublicRuntimeSettings);
            tagPublicRuntimeSettings tagPublicRuntimeSettings = default(tagPublicRuntimeSettings);
            EnumErrorCode num = (EnumErrorCode)DBRGetRuntimeSettings(m_pInstance, ref tagPublicRuntimeSettings);
            if (num != EnumErrorCode.DBR_SUCCESS)
            {
                throw new Exception("Failed to get the DBR_GetRuntimeSettings");
            }
            else
            {
                result.mTimeout = tagPublicRuntimeSettings.mTimeout;
                result.mPDFRasterDPI = tagPublicRuntimeSettings.mPDFRasterDPI;
                result.mTextFilterMode = tagPublicRuntimeSettings.mTextFilterMode;
                result.mRegionPredetectionMode = tagPublicRuntimeSettings.mRegionPredetectionMode;
                result.mLocalizationAlgorithmPriority = tagPublicRuntimeSettings.mLocalizationAlgorithmPriority;
                result.mBarcodeFormatIds = tagPublicRuntimeSettings.mBarcodeFormatIds;
                result.mMaxAlgorithmThreadCount = tagPublicRuntimeSettings.mMaxAlgorithmThreadCount;
                result.mTextureDetectionSensitivity = tagPublicRuntimeSettings.mTextureDetectionSensitivity;
                result.mDeblurLevel = tagPublicRuntimeSettings.mDeblurLevel;
                result.mAntiDamageLevel = tagPublicRuntimeSettings.mAntiDamageLevel;
                result.mMaxDimOfFullImageAsBarcodeZone = tagPublicRuntimeSettings.mMaxDimOfFullImageAsBarcodeZone;
                result.mMaxBarcodesCount = tagPublicRuntimeSettings.mMaxBarcodesCount;
                result.mBarcodeInvertMode = tagPublicRuntimeSettings.mBarcodeInvertMode;
                result.mScaleDownThreshold = tagPublicRuntimeSettings.mScaleDownThreshold;
                result.mGrayEqualizationSensitivity = tagPublicRuntimeSettings.mGrayEqualizationSensitivity;
                result.mEnableFillBinaryVacancy = tagPublicRuntimeSettings.mEnableFillBinaryVacancy;
                result.mColourImageConvertMode = tagPublicRuntimeSettings.mColourImageConvertMode;
                result.mReserved = tagPublicRuntimeSettings.mReserved;
                result.mExpectedBarcodesCount = tagPublicRuntimeSettings.mExpecetedBarcodesCount;
                result.mBinarizationBlockSize = tagPublicRuntimeSettings.mBinarizationBlockSize;
            }
            return result;
        }

        public void UpdateRuntimeSettings(PublicRuntimeSettings settings)
        {
            tagPublicRuntimeSettings tagPublicRuntimeSettings = default(tagPublicRuntimeSettings);
            tagPublicRuntimeSettings.mTimeout = settings.mTimeout;
            tagPublicRuntimeSettings.mPDFRasterDPI = settings.mPDFRasterDPI;
            tagPublicRuntimeSettings.mTextFilterMode = settings.mTextFilterMode;
            tagPublicRuntimeSettings.mRegionPredetectionMode = settings.mRegionPredetectionMode;
            tagPublicRuntimeSettings.mLocalizationAlgorithmPriority = settings.mLocalizationAlgorithmPriority;
            tagPublicRuntimeSettings.mBarcodeFormatIds = settings.mBarcodeFormatIds;
            tagPublicRuntimeSettings.mMaxAlgorithmThreadCount = settings.mMaxAlgorithmThreadCount;
            tagPublicRuntimeSettings.mTextureDetectionSensitivity = settings.mTextureDetectionSensitivity;
            tagPublicRuntimeSettings.mDeblurLevel = settings.mDeblurLevel;
            tagPublicRuntimeSettings.mAntiDamageLevel = settings.mAntiDamageLevel;
            tagPublicRuntimeSettings.mMaxDimOfFullImageAsBarcodeZone = settings.mMaxDimOfFullImageAsBarcodeZone;
            tagPublicRuntimeSettings.mMaxBarcodesCount = settings.mMaxBarcodesCount;
            tagPublicRuntimeSettings.mBarcodeInvertMode = settings.mBarcodeInvertMode;
            tagPublicRuntimeSettings.mScaleDownThreshold = settings.mScaleDownThreshold;
            tagPublicRuntimeSettings.mGrayEqualizationSensitivity = settings.mGrayEqualizationSensitivity;
            tagPublicRuntimeSettings.mEnableFillBinaryVacancy = settings.mEnableFillBinaryVacancy;
            tagPublicRuntimeSettings.mColourImageConvertMode = settings.mColourImageConvertMode;
            tagPublicRuntimeSettings.mReserved = settings.mReserved;
            tagPublicRuntimeSettings.mExpecetedBarcodesCount = settings.mExpectedBarcodesCount;
            tagPublicRuntimeSettings.mBinarizationBlockSize = settings.mBinarizationBlockSize;
            int num = 0x200;
            IntPtr intPtr = Marshal.AllocHGlobal(num);
            EnumErrorCode enumErrorCode = (EnumErrorCode)DBRUpdateRuntimeSettings(m_pInstance, ref tagPublicRuntimeSettings, intPtr, num);
            string msg = Marshal.PtrToStringAnsi(intPtr);
            Marshal.FreeHGlobal(intPtr);
            if (enumErrorCode != EnumErrorCode.DBR_SUCCESS)
            {
                throw new Exception("Failed to update the DBR_GetRuntimeSettings " + msg);
            }
        }

        public void UpdateLicenseKey(string strLicenseKey)
        {
            DBRInitLicense(m_pInstance, strLicenseKey);
        }

        public string[] DecodeBitmap(Bitmap image)
        {
            string[] result = null;
            checked
            {
                try
                {
                    PixelFormat pixelFormat = image.PixelFormat;
                    EnumImagePixelFormat format;
                    if (pixelFormat == PixelFormat.Format32bppArgb || pixelFormat == PixelFormat.Format32bppPArgb || pixelFormat == PixelFormat.Format32bppRgb)
                    {
                        format = EnumImagePixelFormat.IPF_ARGB_8888;
                    }
                    else if (pixelFormat == PixelFormat.Format24bppRgb)
                    {
                        format = EnumImagePixelFormat.IPF_RGB_888;
                    }
                    else if (pixelFormat == PixelFormat.Format1bppIndexed)
                    {
                        format = EnumImagePixelFormat.IPF_Binary;
                    }
                    else if (pixelFormat == PixelFormat.Format8bppIndexed)
                    {
                        format = EnumImagePixelFormat.IPF_GrayScaled;
                    }
                    else
                    {
                        pixelFormat = PixelFormat.Format24bppRgb;
                        format = EnumImagePixelFormat.IPF_RGB_888;
                    }

                    IntPtr intPtr = IntPtr.Zero;
                    BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, pixelFormat);
                    int num = bitmapData.Stride * bitmapData.Height;
                    intPtr = Marshal.AllocHGlobal(num);
                    int stride = bitmapData.Stride;
                    if (format == EnumImagePixelFormat.IPF_GrayScaled)
                    {
                        if (image.Palette != null && image.Palette.Entries != null)
                        {
                            byte[] array = new byte[image.Palette.Entries.Length];
                            for (int i = 0; i < image.Palette.Entries.Length; i++)
                            {
                                array[i] = (byte)(image.Palette.Entries[i].R * 0x4C6A + image.Palette.Entries[i].G * 0x9696 + image.Palette.Entries[i].B * 0x1D00 >> 0x10);
                            }

                            byte[] array2 = new byte[num];
                            Marshal.Copy(bitmapData.Scan0, array2, 0, num);
                            for (int j = 0; j < array2.Length; j++)
                            {
                                array2[j] = array[array2[j]];
                            }
                            Marshal.Copy(array2, 0, intPtr, num);
                        }
                    }
                    else
                    {
                        CopyMemory(intPtr, bitmapData.Scan0, num);
                    }
                    image.UnlockBits(bitmapData);

                    EnumErrorCode enumErrorCode = EnumErrorCode.DBR_SUCCESS;
                    enumErrorCode = (EnumErrorCode)DBRDecodeBuffer(m_pInstance, intPtr, image.Width, image.Height, stride, format, "");
                    Marshal.FreeHGlobal(intPtr);
                    intPtr = IntPtr.Zero;

                    if (enumErrorCode == EnumErrorCode.DBR_SUCCESS)
                    {
                        result = GetAllTextResults();
                    }
                    else if (enumErrorCode == EnumErrorCode.DBR_LICENSE_EXPIRED)
                    {
                        result = new string[] { "THE LICENSE EXPIRED" };
                    }
                    else if (enumErrorCode == EnumErrorCode.DBR_1D_LICENSE_INVALID)
                    {
                        result = new string[] { "THE LICENSE INVALID" };
                    }

                }
                catch { }
                return result;
            }
        }

        public void VanTamDefaltSetting()
        {
            PublicRuntimeSettings Setting = GetRuntimeSettings();
            Setting.mBarcodeFormatIds = (int)(EnumBarcodeFormat.CODE_128 | EnumBarcodeFormat.QR_CODE);
            Setting.mAntiDamageLevel = 9;
            Setting.mDeblurLevel = 9;
            Setting.mExpectedBarcodesCount = 512;
            Setting.mScaleDownThreshold = 214748347;
            Setting.mTextFilterMode = TextFilterMode.TFM_Disable;
            UpdateRuntimeSettings(Setting);
        }
    }
}

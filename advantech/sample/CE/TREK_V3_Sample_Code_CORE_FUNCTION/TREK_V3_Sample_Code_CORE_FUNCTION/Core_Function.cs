using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;   // for using other APIs

namespace TREK_V3_Sample_Code_CORE_FUNCTION
{
    public partial class Core_Function : Form
    {
        public const string strCoreFunctionDLLName = @"SUSI_IMC_CORE_FUNCTION.dll";

        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;

        protected UInt16 iLastErrCode;

        // The property
        public UInt16 LastErrCode
        {
            set
            {
                iLastErrCode = value;
            }
            get
            {
                return iLastErrCode;
            }
        }

        protected static string ConvertByte2String(byte[] byData, int nSize, out int nRealSize)
        {
            string strData = string.Empty;
            StringBuilder strBuilderData = new StringBuilder();
            nRealSize = 0;
            if (nSize != 0)
            {
                for (int i = 0; i < nSize; i++)
                {
                    char chData = (char)byData[i];
                    if (chData == 0)
                        break;
                    strBuilderData.Append(chData);
                    nRealSize++;
                }
                strData = strBuilderData.ToString();
            }
            return strData;
        }

        public class CoreFunction_API
        {
            public static UInt16 IMC_LIB_VERSION_SIZE = 17;

            public unsafe struct IMC_CORE_GETPLATFORMNAME
            {
                public char* PlatformName;
                public UInt32* size;
            };

            public unsafe struct IMC_CORE_ACCESS_BOOTCOUNTER
            {
                public UInt32 mode;
                public UInt32 OPFlag;
                public bool* enable;
                public Int32* value;
            };

            public unsafe struct IMGINFO
            {
                public char* WinCEImageVersion;
                public char* WinCEBuiltDate;
                public char* BootloaderVersion;
                public char* BootloaderDate;
            }

            [DllImport("kernel32")]
            public static extern IntPtr GetCurrentProcess();

            [DllImport(strCoreFunctionDLLName, EntryPoint = "SUSI_IMC_CORE_GetLibVersion")]
            public static extern UInt16 CORE_GetLibVersion(byte[] pVersion);

            [DllImport(strCoreFunctionDLLName, EntryPoint = "SUSI_IMC_CORE_Available")]
            public extern static UInt16 CORE_Available();

            [DllImport(strCoreFunctionDLLName, EntryPoint = "SUSI_IMC_CORE_GetPlatformName")]
            public unsafe extern static UInt16 CORE_GetPlatformName(ref IMC_CORE_GETPLATFORMNAME Parm);

            [DllImport(strCoreFunctionDLLName, EntryPoint = "SUSI_IMC_CORE_AccessBootCounter")]
            public unsafe extern static UInt16 CORE_AccessBootCounter(ref IMC_CORE_ACCESS_BOOTCOUNTER Parm);

            [DllImport(strCoreFunctionDLLName, EntryPoint = "SUSI_IMC_CORE_SoftReset")]
            public unsafe extern static UInt16 CORE_SoftReset();

            [DllImport(strCoreFunctionDLLName, EntryPoint = "SUSI_IMC_CORE_HardReset")]
            public unsafe extern static UInt16 CORE_HardReset();

            [DllImport(strCoreFunctionDLLName, EntryPoint = "SUSI_IMC_CORE_SetProgRAMSize")]
            public unsafe extern static UInt16 CORE_SetProgRAMSize(UInt32 Percent);

            [DllImport(strCoreFunctionDLLName, EntryPoint = "SUSI_IMC_CORE_GetImageinfo")]
            public unsafe extern static UInt16 CORE_GetImageinfo(ref IMGINFO Info);

            [DllImport(strCoreFunctionDLLName, EntryPoint = "SUSI_IMC_CORE_RegistrySave")]
            public extern static UInt16 CORE_RegistrySave();

            [DllImport(strCoreFunctionDLLName, EntryPoint = "SUSI_IMC_CORE_RegistryClean")]
            public extern static UInt16 CORE_RegistryClean();
        }

        public Core_Function()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] byLibVersion = new byte[CoreFunction_API.IMC_LIB_VERSION_SIZE];
            LastErrCode = CoreFunction_API.CORE_GetLibVersion(byLibVersion);

            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get library version");
                return;
            }

            int nRealSize;
            LibVersionTxtBx.Text = ConvertByte2String(byLibVersion, byLibVersion.Length, out nRealSize);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UInt16 result = CoreFunction_API.CORE_Available();
            if (IMC_ERR_NO_ERROR == result)
            {
                CoreAvailableTxtBx.Text = "Yes";
                return;
            }
            else
            {
                CoreAvailableTxtBx.Text = "No, Error code : " + Convert.ToString(result, 16);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UInt32 Size;
            CoreFunction_API.IMC_CORE_GETPLATFORMNAME Parm_PN = new CoreFunction_API.IMC_CORE_GETPLATFORMNAME();
            unsafe
            {
                Parm_PN.PlatformName = null;
                Parm_PN.size = &Size;

                LastErrCode = CoreFunction_API.CORE_GetPlatformName(ref Parm_PN);
                if (IMC_ERR_NO_ERROR == LastErrCode)
                {
                    UnicodeEncoding encodeW = new UnicodeEncoding();
                    Size = Size * 2;
                    byte[] name = new byte[Size];
                    fixed (byte* p = name)
                    {
                        Parm_PN.PlatformName = (char*)p;
                        CoreFunction_API.CORE_GetPlatformName(ref Parm_PN);
                        GetPlfNameTxtBx.Text = encodeW.GetString(name, 0, (int)Size);
                    }
                }
                else
                {
                    GetPlfNameTxtBx.Text = "Error code : " + Convert.ToString(LastErrCode, 16);
                    return;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CoreFunction_API.IMC_CORE_ACCESS_BOOTCOUNTER Parm_AB = new CoreFunction_API.IMC_CORE_ACCESS_BOOTCOUNTER();
            unsafe
            {
                bool status; Parm_AB.enable = &status;
                Int32 value; Parm_AB.value = &value;

                Parm_AB.mode = 0;
                Parm_AB.OPFlag = 1;

                CoreFunction_API.CORE_AccessBootCounter(ref Parm_AB);
                if (status == true)
                {
                    BootCntStatusCmbBox.Text = "True";
                }
                else
                {
                    BootCntStatusCmbBox.Text = "False";
                }

                Parm_AB.OPFlag = 2;
                CoreFunction_API.CORE_AccessBootCounter(ref Parm_AB);
                BootTimesTxtBx.Text = value.ToString();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            CoreFunction_API.IMC_CORE_ACCESS_BOOTCOUNTER Parm_AB = new CoreFunction_API.IMC_CORE_ACCESS_BOOTCOUNTER();
            unsafe
            {
                bool status; Parm_AB.enable = &status;
                Int32 value; Parm_AB.value = &value;

                Parm_AB.mode = 1;
                Parm_AB.OPFlag = 1;
                if (BootCntStatusCmbBox.Text == "True")
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                if (IMC_ERR_NO_ERROR != CoreFunction_API.CORE_AccessBootCounter(ref Parm_AB))
                {
                    MessageBox.Show("Fails to get boot counter status!");
                }

                Parm_AB.OPFlag = 2;
                value = Convert.ToInt32(BootTimesTxtBx.Text);
                if (IMC_ERR_NO_ERROR != CoreFunction_API.CORE_AccessBootCounter(ref Parm_AB))
                {
                    MessageBox.Show("Fails to get boot times!");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UInt16 result = CoreFunction_API.CORE_SoftReset();
            if (IMC_ERR_NO_ERROR != result)
            {
                MessageBox.Show("Soft Reset Fail!");
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UInt16 result = CoreFunction_API.CORE_HardReset();
            if (IMC_ERR_NO_ERROR != result)
            {
                MessageBox.Show("Hard Reset Fail!");
                return;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CoreFunction_API.IMGINFO Info = new CoreFunction_API.IMGINFO();

            byte[] CEImageVersion = new byte[60];
            byte[] CEBuiltData = new byte[60];
            byte[] BootloaderVersion = new byte[60];
            byte[] BootloaderDate = new byte[60];

            unsafe
            {
                fixed (byte* p1 = CEImageVersion)
                {
                    Info.WinCEImageVersion = (char*)p1;
                }

                fixed (byte* p2 = CEBuiltData)
                {
                    Info.WinCEBuiltDate = (char*)p2;
                }

                fixed (byte* p3 = BootloaderVersion)
                {
                    Info.BootloaderVersion = (char*)p3;
                }

                fixed (byte* p4 = BootloaderDate)
                {
                    Info.BootloaderDate = (char*)p4;
                }

                UInt16 result = CoreFunction_API.CORE_GetImageinfo(ref Info);
                UnicodeEncoding encodeW = new UnicodeEncoding();

                if (IMC_ERR_NO_ERROR != result)
                {
                    MessageBox.Show("Get image info Fail!");
                    return;
                }

                WinCEImgVersionTxtBx.Text = encodeW.GetString(CEImageVersion, 0, 60);
                WinCEBuiltDateTxtBx.Text = encodeW.GetString(CEBuiltData, 0, 60);
                BootloaderVersionTxtBx.Text = encodeW.GetString(BootloaderVersion, 0, 60);
                BootloaderDateTxtBx.Text = encodeW.GetString(BootloaderDate, 0, 60);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UInt16 result = CoreFunction_API.CORE_RegistrySave();
            if (IMC_ERR_NO_ERROR != result)
            {
                MessageBox.Show("Registry Save Fail!");
                return;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UInt16 result = CoreFunction_API.CORE_RegistryClean();
            if (IMC_ERR_NO_ERROR != result)
            {
                MessageBox.Show("Registry Cleab Fail!");
                return;
            }
        }
    }
}
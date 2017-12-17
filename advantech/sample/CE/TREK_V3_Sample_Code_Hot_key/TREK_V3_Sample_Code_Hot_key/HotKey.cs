using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;   // for using other APIs

namespace TREK_V3_Sample_Code_Hot_key
{
    public partial class HotKey : Form
    {

        //Advantech SUSI init
        
        public const string strSUSIDLLName = @"Susi.dll";
        public const string strCoreFunctionDLLName = @"SUSI_IMC_CORE_FUNCTION.dll";

        public string platform_name;

        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;

        public int iLastKey = 0;

        class SUSI_API
        {
            [DllImport(strSUSIDLLName, EntryPoint = "SusiDllInit")]
            public static extern bool SusiDllInit();

            [DllImport(strSUSIDLLName, EntryPoint = "SusiDllUnInit")]
            public static extern bool SusiDllUnInit();

            [DllImport(strSUSIDLLName, EntryPoint = "SusiDllGetLastError")]
            public static extern int SusiDllGetLastError();

            [DllImport(strSUSIDLLName, EntryPoint = "SusiIICHotKeyREGSetting")]
            public static extern bool SusiIICHotKeyREGSetting(UInt32 Key_Number, byte VK_Code);

            [DllImport(strSUSIDLLName, EntryPoint = "SusiIICHotKeyREGGet")]
            public unsafe static extern bool SusiIICHotKeyREGGet(UInt32 Key_Number, byte* VK_Code);

            [DllImport(strSUSIDLLName, EntryPoint = "SusiVCHotKeyREGSetting")]
            public static extern bool SusiVCHotKeyREGSetting(UInt32 Key_Number, byte VK_Code);
        }

        class SUSI_IMC_API
        {
            [DllImport(strCoreFunctionDLLName, EntryPoint = "SUSI_IMC_CORE_GetPlatformName")]
            public unsafe extern static UInt16 CORE_GetPlatformName(ref IMC_CORE_GETPLATFORMNAME Parm);

            public unsafe struct IMC_CORE_GETPLATFORMNAME
            {
                public char* PlatformName;
                public UInt32* size;
            };
        }

        public HotKey()
        {
            InitializeComponent();
        }

        private void HotKey_Load(object sender, EventArgs e)
        {
            bool bResult;
            int LastErrCode;
            bResult = SUSI_API.SusiDllInit();
            if (bResult != true)
            {
                LastErrCode = SUSI_API.SusiDllGetLastError();
                MessageBox.Show(LastErrCode.ToString());
            }

            UInt32 Size;
            SUSI_IMC_API.IMC_CORE_GETPLATFORMNAME Parm_PN = new SUSI_IMC_API.IMC_CORE_GETPLATFORMNAME();
            unsafe
            {
                Parm_PN.PlatformName = null;
                Parm_PN.size = &Size;

                if (IMC_ERR_NO_ERROR == SUSI_IMC_API.CORE_GetPlatformName(ref Parm_PN))
                {
                    UnicodeEncoding encodeW = new UnicodeEncoding();
                    Size = Size * 2;
                    byte[] name = new byte[Size];
                    fixed (byte* p = name)
                    {
                        Parm_PN.PlatformName = (char*)p;
                        SUSI_IMC_API.CORE_GetPlatformName(ref Parm_PN);
                        platform_name = encodeW.GetString(name, 0, (int)Size);
                    }
                }
                else
                {

                    return;
                }
            }

        }

        private void SetHotKey1Btn_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            int LastErrCode;
            if (platform_name == "TREK-72x")
            {
                bResult = SUSI_API.SusiIICHotKeyREGSetting(0, (byte)Convert.ToInt16(HotKey1MapTxt.Text));
            }
            else
            {
                bResult = SUSI_API.SusiVCHotKeyREGSetting(0, (byte)Convert.ToInt16(HotKey1MapTxt.Text));
            }
            
            if (bResult != true)
            {
                LastErrCode = SUSI_API.SusiDllGetLastError();
                MessageBox.Show(LastErrCode.ToString());
            }
        }

        private void SetHotKey2Btn_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            int LastErrCode;
            if (platform_name == "TREK-72x")
            {
                bResult = SUSI_API.SusiIICHotKeyREGSetting(1, (byte)Convert.ToInt16(HotKey2MapTxt.Text));
            }
            else
            {
                bResult = SUSI_API.SusiVCHotKeyREGSetting(1, (byte)Convert.ToInt16(HotKey2MapTxt.Text));
            }
           
            if (bResult != true)
            {
                LastErrCode = SUSI_API.SusiDllGetLastError();
                MessageBox.Show(LastErrCode.ToString());
            }
        }

        private void SetHotKey3Btn_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            int LastErrCode;
            if (platform_name == "TREK-72x")
            {
                bResult = SUSI_API.SusiIICHotKeyREGSetting(2, (byte)Convert.ToInt16(HotKey3MapTxt.Text));
            }
            else
            {
                bResult = SUSI_API.SusiVCHotKeyREGSetting(2, (byte)Convert.ToInt16(HotKey3MapTxt.Text));
            }

            if (bResult != true)
            {
                LastErrCode = SUSI_API.SusiDllGetLastError();
                MessageBox.Show(LastErrCode.ToString());
            }
        }

        private void SetHotKey4Btn_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            int LastErrCode;
            if (platform_name == "TREK-72x")
            {
                bResult = SUSI_API.SusiIICHotKeyREGSetting(3, (byte)Convert.ToInt16(HotKey4MapTxt.Text));
            }
            else
            {
                bResult = SUSI_API.SusiVCHotKeyREGSetting(3, (byte)Convert.ToInt16(HotKey4MapTxt.Text));
            }

            if (bResult != true)
            {
                LastErrCode = SUSI_API.SusiDllGetLastError();
                MessageBox.Show(LastErrCode.ToString());
            }
        }

        private void SetHotKey5Btn_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            int LastErrCode;
            if (platform_name == "TREK-72x")
            {
                bResult = SUSI_API.SusiIICHotKeyREGSetting(4, (byte)Convert.ToInt16(HotKey5MapTxt.Text));
            }
            else
            {
                bResult = SUSI_API.SusiVCHotKeyREGSetting(4, (byte)Convert.ToInt16(HotKey5MapTxt.Text));
            }
            if (bResult != true)
            {
                LastErrCode = SUSI_API.SusiDllGetLastError();
                MessageBox.Show(LastErrCode.ToString());
            }
        }

        private void HotKey_Closed(object sender, EventArgs e)
        {
            bool bResult;
            int LastErrCode;
            bResult = SUSI_API.SusiDllUnInit();
            if (bResult != true)
            {
                LastErrCode = SUSI_API.SusiDllGetLastError();
                MessageBox.Show(LastErrCode.ToString());
            }
        }

        private void HotKey1MapTxt_TextChanged(object sender, EventArgs e)
        {
            HotKey1MapTxt.Text = iLastKey.ToString();
        }

        private void HotKey2MapTxt_TextChanged(object sender, EventArgs e)
        {
            HotKey2MapTxt.Text = iLastKey.ToString();
        }

        private void HotKey3MapTxt_TextChanged(object sender, EventArgs e)
        {
            HotKey3MapTxt.Text = iLastKey.ToString();
        }

        private void HotKey4MapTxt_TextChanged(object sender, EventArgs e)
        {
            HotKey4MapTxt.Text = iLastKey.ToString();
        }

        private void HotKey5MapTxt_TextChanged(object sender, EventArgs e)
        {
            HotKey5MapTxt.Text = iLastKey.ToString();
        }

        private void HotKey1MapTxt_KeyDown(object sender, KeyEventArgs e)
        {
            iLastKey = e.KeyValue;
            HotKey1MapTxt.Text = iLastKey.ToString();
        }

        private void HotKey2MapTxt_KeyDown(object sender, KeyEventArgs e)
        {
            iLastKey = e.KeyValue;
            HotKey2MapTxt.Text = iLastKey.ToString();
        }

        private void HotKey3MapTxt_KeyDown(object sender, KeyEventArgs e)
        {
            iLastKey = e.KeyValue;
            HotKey3MapTxt.Text = iLastKey.ToString();
        }

        private void HotKey4MapTxt_KeyDown(object sender, KeyEventArgs e)
        {
            iLastKey = e.KeyValue;
            HotKey4MapTxt.Text = iLastKey.ToString();
        }

        private void HotKey5MapTxt_KeyDown(object sender, KeyEventArgs e)
        {
            iLastKey = e.KeyValue;
            HotKey5MapTxt.Text = iLastKey.ToString();
        }


    }
}
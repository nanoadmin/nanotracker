using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;   // for using other APIs

namespace TREK_V3_Sample_Code_Watch_Dog
{
    public partial class Watch_Dog : Form
    {
        public const string strWatchDogDLLName = @"SUSI_IMC_WATCH_DOG.dll";

        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;

        public static bool bActive = false;

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

        class Watch_Dog_API
        {
            public static UInt16 IMC_LIB_VERSION_SIZE = 17;

            [DllImport(strWatchDogDLLName, EntryPoint = "SUSI_IMC_WD_Initialize")]
            public static extern UInt16 WD_Initialize(byte port_number);

            [DllImport(strWatchDogDLLName, EntryPoint = "SUSI_IMC_WD_Deinitialize")]
            public static extern UInt16 WD_Deinitialize();
            
            [DllImport(strWatchDogDLLName, EntryPoint = "SUSI_IMC_WD_GetLibVersion")]
            public static extern UInt16 WD_GetLibVersion(byte[] pVersion);

            [DllImport(strWatchDogDLLName, EntryPoint = "SUSI_IMC_WD_SetTime")]
            public static extern UInt16 WD_SetTime(UInt16 Time);

            [DllImport(strWatchDogDLLName, EntryPoint = "SUSI_IMC_WD_GetTime")]
            public unsafe static extern UInt16 WD_GetTime(UInt16* Time);

            [DllImport(strWatchDogDLLName, EntryPoint = "SUSI_IMC_WD_Trigger")]
            public static extern UInt16 WD_Trigger();

            [DllImport(strWatchDogDLLName, EntryPoint = "SUSI_IMC_WD_Enabled")]
            public static extern UInt16 WD_Enabled(bool Active);

            [DllImport(strWatchDogDLLName, EntryPoint = "SUSI_IMC_WD_GetRange")]
            public unsafe static extern UInt16 WD_GetRange(UInt32* minimum, UInt32* maximum);
        }

        public Watch_Dog()
        {
            InitializeComponent();
        }

        private void Watch_Dog_Load(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            byte[] byLibVersion = new byte[Watch_Dog_API.IMC_LIB_VERSION_SIZE];

            LastErrCode = Watch_Dog_API.WD_GetLibVersion(byLibVersion);

            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get library version");
                return;
            }
            int nRealSize;
            LibVersionTxtBx.Text = ConvertByte2String(byLibVersion, byLibVersion.Length, out nRealSize);


            LastErrCode = Watch_Dog_API.WD_Initialize(6);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to start up the Watch_Dog library");
                return;
            }

            SetWDTimerTxt.Text = "0";
            GetWDTimerTxt.Text = "0";
        }

        private void Watch_Dog_Closed(object sender, EventArgs e)
        {
            UInt16 LastErrCode;

            LastErrCode = Watch_Dog_API.WD_Deinitialize();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to deinit the Watch dog library");
                return;
            }
        }

        private void SetWDTimerBtn_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;

            if (Convert.ToInt32(SetWDTimerTxt.Text) > 0xFFFF)
            {
                MessageBox.Show("Invalid value of timer.");
                return;
            }

            LastErrCode = Watch_Dog_API.WD_SetTime(Convert.ToUInt16(SetWDTimerTxt.Text));
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to set timer time to Watch Dog");
                return;
            }
        }

        private void GetWDTimerBtn_Click(object sender, EventArgs e)
        {
            unsafe
            {
                UInt16 LastErrCode;
                ushort Time; ushort* pTime = &Time;
                LastErrCode = Watch_Dog_API.WD_GetTime(pTime);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get timer time from Watch Dog");
                    return;
                }

                GetWDTimerTxt.Text = Time.ToString();

            }
        }

        private void GetRangeBtn_Click(object sender, EventArgs e)
        {
            unsafe
            {
                UInt16 LastErrCode;

                UInt32 MaxTime; UInt32* pMaxTime = &MaxTime;
                UInt32 MinTime; UInt32* pMinTime = &MinTime;

                LastErrCode = Watch_Dog_API.WD_GetRange(pMinTime, pMaxTime);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get Watch Dog timer ragne");
                    return;
                }

                TimeMinTxt.Text = MinTime.ToString();
                TimeMaxTxt.Text = MaxTime.ToString();

            }
        }

        private void WDTimerEnabledBtn_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;

            if (bActive == false)
            {
                LastErrCode = Watch_Dog_API.WD_Enabled(true);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to enable Watch Dog timer");
                    return;
                }
                bActive = true;
                WDTimerEnabledBtn.Text = "Stop WD Timer";
            }
            else
            {
                LastErrCode = Watch_Dog_API.WD_Enabled(false);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to disable Watch Dog timer");
                    return;
                }
                bActive = false;
                WDTimerEnabledBtn.Text = "Start WD Timer";

            }
        }

        private void WDTimerTriggerBtn_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;

            LastErrCode = Watch_Dog_API.WD_Trigger();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to trigger Watch Dog timer");
                return;
            }
        }
    }
}
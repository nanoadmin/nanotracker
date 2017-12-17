using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;   // for using other APIs

namespace TREK_V3_Sample_Code_DISPLAY
{
    public partial class Display : Form
    {

        public const string strDisplayDLLName = @"SUSI_IMC_DISPLAY.dll";

        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;

        public static UInt16 IMC_ERR_DISPLAY_FUNCTION_OK_PLATFORM_NOT_SUPPORT_ALL = 0xC0D0;
        public static UInt16 IMC_ERR_DISPLAY_FUNCTION_OK_ONLY_BRIGHTNESS = 0xC0D1;
        public static UInt16 IMC_ERR_DISPLAY_FUNCTION_OK_ONLY_SCREEN_CONTROL = 0xC0D2;
        public static UInt16 IMC_ERR_DISPLAY_FUNCTION_OK_SUPPORT = 0xC0D3;

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

        public class Display_API
        {
            public static UInt16 IMC_LIB_VERSION_SIZE = 17;

            public unsafe struct IMC_DISPLAY_GET_BRIGHT_RANGE
            {
                public Byte* minimum;
                public Byte* maximum;
                public Byte* stepping;
            };

            [DllImport(strDisplayDLLName, EntryPoint = "SUSI_IMC_DISPLAY_GetLibVersion")]
            public static extern UInt16 DISPLAY_GetLibVersion(byte[] pVersion);

            [DllImport(strDisplayDLLName, EntryPoint = "SUSI_IMC_DISPLAY_Available")]
            public extern static UInt16 DISPLAY_Available();

            [DllImport(strDisplayDLLName, EntryPoint = "SUSI_IMC_DISPLAY_ScreenOn")]
            public extern static UInt16 DISPLAY_ScreenOn();

            [DllImport(strDisplayDLLName, EntryPoint = "SUSI_IMC_DISPLAY_ScreenOff")]
            public extern static UInt16 DISPLAY_ScreenOff();

            [DllImport(strDisplayDLLName, EntryPoint = "SUSI_IMC_DISPLAY_GetBrightRange")]
            public extern static UInt16 DISPLAY_GetBrightRange(ref IMC_DISPLAY_GET_BRIGHT_RANGE Parm);

            [DllImport(strDisplayDLLName, EntryPoint = "SUSI_IMC_DISPLAY_GetBright")]
            public extern static UInt16 DISPLAY_GetBright(ref byte brightness);

            [DllImport(strDisplayDLLName, EntryPoint = "SUSI_IMC_DISPLAY_SetBright")]
            public extern static UInt16 DISPLAY_SetBright(byte brightness);
        }

        public Display()
        {
            InitializeComponent();
        }

        private void Display_Load(object sender, EventArgs e)
        {
            UInt16 LastErrCode = Display_API.DISPLAY_Available();
            if (LastErrCode == IMC_ERR_DISPLAY_FUNCTION_OK_SUPPORT)
            {
                DisplayBrightComBox.Enabled = true;
                DisplayBrightGetBtn.Enabled = true;
                DisplayBrightSetBtn.Enabled = true;
                DisplayOnRadioBtn.Enabled = true;
                DisplayOffRadioBtn.Enabled = true;
            }
            else if (LastErrCode == IMC_ERR_DISPLAY_FUNCTION_OK_ONLY_SCREEN_CONTROL)
            {
                MessageBox.Show("Platform only support screen on/off function!");
                DisplayBrightComBox.Enabled = false;
                DisplayBrightGetBtn.Enabled = false;
                DisplayBrightSetBtn.Enabled = false;
            }
            else if (LastErrCode == IMC_ERR_DISPLAY_FUNCTION_OK_ONLY_BRIGHTNESS)
            {
                MessageBox.Show("Platform only support brightness control function!");
                DisplayOnRadioBtn.Enabled = false;
                DisplayOffRadioBtn.Enabled = false;
            }
            else
            {
                MessageBox.Show("Platform not support display function!");
                DisplayBrightComBox.Enabled = false;
                DisplayBrightGetBtn.Enabled = false;
                DisplayBrightSetBtn.Enabled = false;
                DisplayOnRadioBtn.Enabled = false;
                DisplayOffRadioBtn.Enabled = false;
            }

            if ((LastErrCode == IMC_ERR_DISPLAY_FUNCTION_OK_SUPPORT) ||
                (LastErrCode == IMC_ERR_DISPLAY_FUNCTION_OK_ONLY_BRIGHTNESS))
            {
                Display_API.IMC_DISPLAY_GET_BRIGHT_RANGE Parm_GBR = new Display_API.IMC_DISPLAY_GET_BRIGHT_RANGE();
                DisplayBrightComBox.Items.Clear();
                unsafe
                {
                    byte max = 0; Parm_GBR.maximum = &max;
                    byte min = 0; Parm_GBR.minimum = &min;
                    byte step = 0; Parm_GBR.stepping = &step;
                    Display_API.DISPLAY_GetBrightRange(ref Parm_GBR);

                    byte ChangeScale = (byte)((max - min) / step);
                    for (int i = 0; i <= ChangeScale; i++)
                    {
                        int TempScale = i * step;
                        DisplayBrightComBox.Items.Add(TempScale.ToString());
                    }
                }
            }

            byte[] byLibVersion = new byte[Display_API.IMC_LIB_VERSION_SIZE];
            LastErrCode = Display_API.DISPLAY_GetLibVersion(byLibVersion);

            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get library version");
                return;
            }

            int nRealSize;
            StaticLibVersionValue.Text = ConvertByte2String(byLibVersion, byLibVersion.Length, out nRealSize);
        }

        private void DisplayBrightGetBtn_Click(object sender, EventArgs e)
        {
            byte brightness = 0;
            Display_API.DISPLAY_GetBright(ref brightness);
            DisplayBrightComBox.Text = brightness.ToString();
        }

        private void DisplayBrightSetBtn_Click(object sender, EventArgs e)
        {
            byte brightness = Convert.ToByte(DisplayBrightComBox.Text);
            Display_API.DISPLAY_SetBright(brightness);
        }

        private void DisplayOnRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            UInt16 LastErrCode = Display_API.DISPLAY_ScreenOn();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("DISPLAY_ScreenOn fail!");
            }
        }

        private void DisplayOffRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            UInt16 LastErrCode = Display_API.DISPLAY_ScreenOff();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("DISPLAY_ScreenOff fail!");
            }
        }
    }
}
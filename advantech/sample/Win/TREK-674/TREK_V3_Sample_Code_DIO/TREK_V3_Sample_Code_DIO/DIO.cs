using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;   // for using other APIs

namespace TREK_V3_Sample_Code_DIO
{
    public partial class DIO : Form
    {
        public const string strDIODLLName = @"SUSI_IMC_DIO.dll";

        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;

        static object LockReadWrite = new object();

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

        class DIO_API
        {
            // The constants
            public static UInt16 IMC_LIB_VERSION_SIZE = 17;

            // Note : Bool was 4 byte on CE6.0. So we need to assign 4 byte on this data structure.

            [System.Runtime.InteropServices.StructLayout(LayoutKind.Explicit)]
            public struct PIN_STATUS
            {
                [System.Runtime.InteropServices.FieldOffset(0)]
                public bool bPin0;
                [System.Runtime.InteropServices.FieldOffset(4)]
                public bool bPin1;
                [System.Runtime.InteropServices.FieldOffset(8)]
                public bool bPin2;
                [System.Runtime.InteropServices.FieldOffset(12)]
                public bool bPin3;
            };

            // The export functions
            [DllImport(strDIODLLName, EntryPoint = "SUSI_IMC_DIO_Initialize")]
            public static extern UInt16 DIO_Initialize();

            [DllImport(strDIODLLName, EntryPoint = "SUSI_IMC_DIO_Deinitialize")]
            public extern static UInt16 DIO_Deinitialize();

            [DllImport(strDIODLLName, EntryPoint = "SUSI_IMC_DIO_GetLibVersion")]
            public static extern UInt16 DIO_GetLibVersion(byte[] pVersion);

            [DllImport(strDIODLLName, EntryPoint = "SUSI_IMC_DIO_ReadDIPin")]
            public extern static UInt16 DIO_ReadDIPin(ref PIN_STATUS PinStatus);

            [DllImport(strDIODLLName, EntryPoint = "SUSI_IMC_DIO_WriteDOPin")]
            public extern static UInt16 DIO_WriteDOPin(ref PIN_STATUS PinStatus);

            [DllImport(strDIODLLName, EntryPoint = "SUSI_IMC_DIO_GetVoiceSourceControlPin")]
            public extern static UInt16 DIO_GetVoiceSourceControlPin(out UInt32 PinStatus);

            [DllImport(strDIODLLName, EntryPoint = "SUSI_IMC_DIO_SetVoiceSourceControlPin")]
            public extern static UInt16 DIO_SetVoiceSourceControlPin(UInt32 PinStatus);

            [DllImport(strDIODLLName, EntryPoint = "SUSI_IMC_DIO_GetBluetoothEnablePin")]
            public extern static UInt16 DIO_GetBluetoothEnablePin(out UInt32 PinStatus);

            [DllImport(strDIODLLName, EntryPoint = "SUSI_IMC_DIO_SetBluetoothEnablePin")]
            public extern static UInt16 DIO_SetBluetoothEnablePin(UInt32 PinStatus);

            [DllImport(strDIODLLName, EntryPoint = "SUSI_IMC_DIO_GetVoiceModuleSelectPin")]
            public extern static UInt16 DIO_GetVoiceModuleSelectPin(out UInt32 PinStatus);

            [DllImport(strDIODLLName, EntryPoint = "SUSI_IMC_DIO_SetVoiceModuleSelectPin")]
            public extern static UInt16 DIO_SetVoiceModuleSelectPin(UInt32 PinStatus);
        }

        private void ShowPinStatus(DIO_API.PIN_STATUS PinStatus)
        {
            if (PinStatus.bPin0)
                PicBoxDI0.Image = TREK_V3_Sample_Code_DIO.Properties.Resources.bulb_on_64x64;
            else
                PicBoxDI0.Image = TREK_V3_Sample_Code_DIO.Properties.Resources.bulb_off_64x64;

            if (PinStatus.bPin1)
                PicBoxDI1.Image = TREK_V3_Sample_Code_DIO.Properties.Resources.bulb_on_64x64;
            else
                PicBoxDI1.Image = TREK_V3_Sample_Code_DIO.Properties.Resources.bulb_off_64x64;

            if (PinStatus.bPin2)
                PicBoxDI2.Image = TREK_V3_Sample_Code_DIO.Properties.Resources.bulb_on_64x64;
            else
                PicBoxDI2.Image = TREK_V3_Sample_Code_DIO.Properties.Resources.bulb_off_64x64;

            if (PinStatus.bPin3)
                PicBoxDI3.Image = TREK_V3_Sample_Code_DIO.Properties.Resources.bulb_on_64x64;
            else
                PicBoxDI3.Image = TREK_V3_Sample_Code_DIO.Properties.Resources.bulb_off_64x64;
        }

        private bool ReadDIPin(ref DIO_API.PIN_STATUS PinStatus)
        {
            UInt16 LastErrCode;
            
            // Read data
            lock (LockReadWrite)
            {
                LastErrCode = DIO_API.DIO_ReadDIPin(ref PinStatus);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    //MessageBox.Show("Fails to read IO");
                    return false;
                }
            }
            return true;
        }

        private bool WriteDOPin()
        {
            UInt16 LastErrCode;
            
            DIO_API.PIN_STATUS PinStatus = new DIO_API.PIN_STATUS();
            PinStatus.bPin0 = RadioDO0.Checked ? true : false;
            PinStatus.bPin1 = RadioDO1.Checked ? true : false;
            PinStatus.bPin2 = false;
            PinStatus.bPin3 = false;

            lock (LockReadWrite)
            {
                LastErrCode = DIO_API.DIO_WriteDOPin(ref PinStatus);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to write IO");
                    return false;
                }
            }

            return true;
        }
        
        public DIO()
        {
            InitializeComponent();
        }

        private void DIO_Load(object sender, EventArgs e)
        {
            UInt16 LastErrCode;

            byte[] byLibVersion = new byte[DIO_API.IMC_LIB_VERSION_SIZE];

            LastErrCode = DIO_API.DIO_GetLibVersion(byLibVersion);

            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get library version");
                return;
            }
            int nRealSize;
            StaticLibVersionValue.Text = ConvertByte2String(byLibVersion, byLibVersion.Length, out nRealSize);

            LastErrCode = DIO_API.DIO_Initialize();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to start up the IO library");
                return;
            }

            UInt32 voice_source;
            LastErrCode = DIO_API.DIO_GetVoiceSourceControlPin(out voice_source);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to DIO_GetVoiceSourceControlPin " + LastErrCode.ToString("X4"));
            }

            if (voice_source == 1)
                radioButtonVoiceSourceMicIN.Checked = true;
            else
                radioButtonVoiceSourceBluetooth.Checked = true;

            UInt32 voice_module;
            LastErrCode = DIO_API.DIO_GetVoiceModuleSelectPin(out voice_module);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to DIO_GetVoiceModuleSelectPin " + LastErrCode.ToString("X4"));
            }

            if (voice_module == 0)
                radioButtonMC809X.Checked = true;
            else
                radioButtonMC73X4.Checked = true;

            WriteDOPin();         
        }

        private void GetDIOStatusTimer_Tick(object sender, EventArgs e)
        {
            DIO_API.PIN_STATUS PinStatus = new DIO_API.PIN_STATUS();
            if (ReadDIPin(ref PinStatus) == false)
            {
                GetDIOStatusTimer.Enabled = false;
                MessageBox.Show("Read Pin fail!");
                return;
            }

            ShowPinStatus(PinStatus);
        }

        private void DIO_Closed(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            
            GetDIOStatusTimer.Enabled = false;
            GetDIOStatusTimer.Dispose();

            LastErrCode = DIO_API.DIO_Deinitialize();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to deinit the IO library");
                return;
            }
        }

        private void MonitorBtn_Click(object sender, EventArgs e)
        {
            if (GetDIOStatusTimer.Enabled == false)
            {
                GetDIOStatusTimer.Enabled = true;
                MonitorBtn.Text = "Stop Monitor DI Status";

            }
            else
            {
                GetDIOStatusTimer.Enabled = false;
                MonitorBtn.Text = "Start Monitor DI Status";
            }
        }

        private void RadioDO0_CheckStateChanged(object sender, EventArgs e)
        {
            WriteDOPin();
        }

        private void RadioDO1_CheckStateChanged(object sender, EventArgs e)
        {
            WriteDOPin();
        }
        private void radioButtonVoiceSourceBluetooth_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 voice_source;
            if (radioButtonVoiceSourceBluetooth.Checked)
                voice_source = 0;
            else
                voice_source = 1;

            UInt16 LastErrCode = DIO_API.DIO_SetVoiceSourceControlPin(voice_source);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to DIO_SetVoiceSourceControlPin " + LastErrCode.ToString("X4"));
                return;
            }
        }

        private void radioButtonMC809X_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 voice_module;
            if (radioButtonMC809X.Checked)
                voice_module = 0;
            else
                voice_module = 1;

            UInt16 LastErrCode = DIO_API.DIO_SetVoiceModuleSelectPin(voice_module);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to DIO_SetVoiceModuleSelectPin " + LastErrCode.ToString("X4"));
                return;
            }
        }
    }
}
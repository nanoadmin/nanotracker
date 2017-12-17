using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;   // for using other APIs

namespace TREK_V3_Sample_Code_PeripheralCtrl
{
    public partial class PeripheralCtrl : Form
    {
        public const string strPeripheralCtrlDLLName = @"SUSI_IMC_PeripheralCtrl.dll";

        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;

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

        public static string[] strPeripheralCtrl = new string[]  // Caution : The order...
        { 
            "WWAN",
            "WIFI",
            "GPS"
        };

        public static string[] strPeripheralCtrlValue = new string[]  // Caution : The order...
        { 
            "Disable",
            "Enable"
        };

        // Set/Get Peripheral control
        bool AccessPeripheralCtrl(bool bSet)
        {
            UInt16 LastErrCode;
            
            PeripheralCtrl_API.PERIPHERAL_TYPE nType = (PeripheralCtrl_API.PERIPHERAL_TYPE)ComboPeripheralCtrl.SelectedIndex;
            int nEnable;
            if (bSet)
            {
                nEnable = ComboPeripheralCtrlValue.SelectedIndex;
                LastErrCode = PeripheralCtrl_API.PeripheralCtrl_SetPeripheralControl(nType, nEnable);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set peripheral control");
                    return false;
                }
            }
            else
            {
                LastErrCode = PeripheralCtrl_API.PeripheralCtrl_GetPeripheralControl(nType, out nEnable);

                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get peripheral control");
                    return false;
                }
                ComboPeripheralCtrlValue.SelectedIndex = (nEnable == 1? 1:0 );
            }
            return true;
        }

        // Peripheral Control
        class PeripheralCtrl_API
        {
            // Enumeration
            public enum PERIPHERAL_TYPE
            {
                PERIPHERAL_WWAN = 0,
                PERIPHERAL_WIFI = 1,
                PERIPHERAL_GPS = 2,                
                PERIPHERAL_SIZE = 3
            };

            // The constants
            public static UInt16 IMC_LIB_VERSION_SIZE = 17;

            // The structures

            // The export functions.
            [DllImport(strPeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_Initialize")]
            public static extern UInt16 PeripheralCtrl_Initialize();

            [DllImport(strPeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_Deinitialize")]
            public static extern UInt16 PeripheralCtrl_Deinitialize();

            [DllImport(strPeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_GetLibVersion")]
            public unsafe static extern UInt16 PeripheralCtrl_GetLibVersion(byte[] pVersion);

            [DllImport(strPeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_SetPeripheralControl")]
            public static extern UInt16 PeripheralCtrl_SetPeripheralControl(PERIPHERAL_TYPE nType, int bEnable);

            [DllImport(strPeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_GetPeripheralControl")]
            public unsafe static extern UInt16 PeripheralCtrl_GetPeripheralControl(PERIPHERAL_TYPE nType, out int bEnable);
        }
        
        public PeripheralCtrl()
        {
            InitializeComponent();
        }

        private void BtnPeripheralCtrlApply_Click(object sender, EventArgs e)
        {
            bool bSuccess = AccessPeripheralCtrl(RadioPeripheralCtrlSet.Checked);
        }

        private void PeripheralCtrl_Load(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            byte[] byLibVersion = new byte[PeripheralCtrl_API.IMC_LIB_VERSION_SIZE];
            LastErrCode = PeripheralCtrl_API.PeripheralCtrl_GetLibVersion(byLibVersion);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get library version");
                return;
            }
            int nRealSize;
            StaticLibVersionValue.Text = ConvertByte2String(byLibVersion, byLibVersion.Length, out nRealSize);

            // Initialize the Peripheral Control library.
            LastErrCode = PeripheralCtrl_API.PeripheralCtrl_Initialize();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to start up the PeripheralCtrl library");
                return;
            }

            for (int i = 0; i < (int)PeripheralCtrl_API.PERIPHERAL_TYPE.PERIPHERAL_SIZE; i++)
            {
                ComboPeripheralCtrl.Items.Add(strPeripheralCtrl[i]);
            }

            ComboPeripheralCtrl.SelectedIndex = 0;
            ComboPeripheralCtrlValue.Items.Add(strPeripheralCtrlValue[0]);
            ComboPeripheralCtrlValue.Items.Add(strPeripheralCtrlValue[1]);
            ComboPeripheralCtrlValue.SelectedIndex = 0;
        }

        private void PeripheralCtrl_Closed(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            LastErrCode = PeripheralCtrl_API.PeripheralCtrl_Deinitialize();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to clear up the peripheral control library");
                return;
            }
        }
    }
}
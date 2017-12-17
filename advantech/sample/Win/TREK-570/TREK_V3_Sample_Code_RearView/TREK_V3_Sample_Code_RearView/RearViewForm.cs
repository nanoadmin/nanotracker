using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TREK_V3_Sample_Code_RearView
{
    public partial class RearViewForm : Form
    {
        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;

        public static bool init_once = false;

        public byte curr_rearview_src = PeripheralCtrl_API.REAR_VIEW_SRC_SYSTEM;

        #region Peripheral ctrl API import
        public class PeripheralCtrl_API
        {
            public const string PeripheralCtrlDLLName = @"SUSI_IMC_PeripheralCtrl.dll";

            public const byte REAR_VIEW_SRC_SYSTEM = 0;
            public const byte REAR_VIEW_SRC_EXTERNAL1 = 1;
            public const byte REAR_VIEW_SRC_EXTERNAL2 = 2;

            public const UInt16 IMC_LIB_VERSION_SIZE = 17;

            // Enumeration
            public enum PERIPHERAL_TYPE
            {
                PERIPHERAL_WWAN = 0,
                PERIPHERAL_WIFI = 1,
                PERIPHERAL_GPS = 2,
                PERIPHERAL_SIM0 = 7,
                PERIPHERAL_SIM1 = 8,
                PERIPHERAL_SIZE = 5
            };
            
            // The export functions.
            [DllImport(PeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_Initialize")]
            public static extern UInt16 PeripheralCtrl_Initialize();

            [DllImport(PeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_Deinitialize")]
            public static extern UInt16 PeripheralCtrl_Deinitialize();

            [DllImport(PeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_GetLibVersion")]
            public unsafe static extern UInt16 PeripheralCtrl_GetLibVersion(byte[] pVersion);

            [DllImport(PeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_SetPeripheralControl")]
            public static extern UInt16 PeripheralCtrl_SetPeripheralControl(PERIPHERAL_TYPE nType, int bEnable);

            [DllImport(PeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_GetPeripheralControl")]
            public unsafe static extern UInt16 PeripheralCtrl_GetPeripheralControl(PERIPHERAL_TYPE nType, out int bEnable);

            [DllImport(PeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_SetRearViewSource")]
            public static extern UInt16 PeripheralCtrl_SetRearViewSource(byte source);

            [DllImport(PeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_GetRearViewSource")]
            public unsafe static extern UInt16 PeripheralCtrl_GetRearViewSource(out byte source);

            [DllImport(PeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_SetAutoRearView")]
            public static extern UInt16 PeripheralCtrl_SetAutoRearView(int enable);

            [DllImport(PeripheralCtrlDLLName, EntryPoint = "SUSI_IMC_PERIPHERALCTRL_GetAutoRearView")]
            public unsafe static extern UInt16 PeripheralCtrl_GetAutoRearView(out int enable);
        }
        #endregion

        public void SetRearViewSource(byte source)
        {
            if (curr_rearview_src == source)
                return;

            UInt16 LastErrCode;
            LastErrCode = PeripheralCtrl_API.PeripheralCtrl_SetRearViewSource(source);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to switch to desktop" + LastErrCode.ToString("X4"));
                return;
            }

            curr_rearview_src = source;

            if (curr_rearview_src == PeripheralCtrl_API.REAR_VIEW_SRC_SYSTEM)
            {
                btnMainSrc.Enabled = false;
                btnExtSrc.Enabled = true;
            }
            else
            {
                btnMainSrc.Enabled = true;
                btnExtSrc.Enabled = false;
            }
        }
        
        public RearViewForm()
        {
            InitializeComponent();
        }

        private void RearViewForm_Load(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            byte[] byLibVersion = new byte[PeripheralCtrl_API.IMC_LIB_VERSION_SIZE];
            LastErrCode = PeripheralCtrl_API.PeripheralCtrl_GetLibVersion(byLibVersion);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get library version " + LastErrCode.ToString("X4"));
                return;
            }

            tbLibVersion.Text = System.Text.Encoding.Default.GetString(byLibVersion);

            // Initialize the Peripheral Control library.
            LastErrCode = PeripheralCtrl_API.PeripheralCtrl_Initialize();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to start up the PeripheralCtrl library " + LastErrCode.ToString("X4"));
                return;
            }

            byte curr_source;
            LastErrCode = PeripheralCtrl_API.PeripheralCtrl_GetRearViewSource(out curr_source);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get RearView Source " + LastErrCode.ToString("X4"));
                return;
            }

            SetRearViewSource(PeripheralCtrl_API.REAR_VIEW_SRC_SYSTEM);

            cbAutoSwitchTime.SelectedIndex = 0;

            int auto_switch = 0;
            LastErrCode = PeripheralCtrl_API.PeripheralCtrl_GetAutoRearView(out auto_switch);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get auto RearView " + LastErrCode.ToString("X4"));
                return;
            }

            if (auto_switch == 0)
                checkBoxAutoSwitchBaseDI.Checked = false;
            else
                checkBoxAutoSwitchBaseDI.Checked = true;

            init_once = true;
        }

        private void RearViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetRearViewSource(PeripheralCtrl_API.REAR_VIEW_SRC_SYSTEM);

            UInt16 LastErrCode;
            LastErrCode = PeripheralCtrl_API.PeripheralCtrl_Deinitialize();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to clear up the peripheral control library");
                return;
            }
        }

        private void btnMainSrc_Click(object sender, EventArgs e)
        {
            SetRearViewSource(PeripheralCtrl_API.REAR_VIEW_SRC_SYSTEM);
        }

        private void btnExtSrc_Click(object sender, EventArgs e)
        {
            SetRearViewSource(PeripheralCtrl_API.REAR_VIEW_SRC_EXTERNAL1);

            if (checkBoxAutoSwitch.Checked)
            {
                timerAutoSwitchMainSrc.Interval = 5000 + cbAutoSwitchTime.SelectedIndex * 5000;
                timerAutoSwitchMainSrc.Enabled = true;
            }
        }

        private void timerAutoSwitchMainSrc_Tick(object sender, EventArgs e)
        {
            SetRearViewSource(PeripheralCtrl_API.REAR_VIEW_SRC_SYSTEM);
            timerAutoSwitchMainSrc.Enabled = false;
        }

        private void checkBoxAutoSwitchBaseDI_CheckedChanged(object sender, EventArgs e)
        {
            UInt16 LastErrCode;

            if (!init_once)
                return;

            int auto_switch = (checkBoxAutoSwitchBaseDI.Checked ? 1 : 0);
            LastErrCode = PeripheralCtrl_API.PeripheralCtrl_SetAutoRearView(auto_switch);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to set auto switch " + LastErrCode.ToString("X4"));
                return;
            }
        }
    }
}

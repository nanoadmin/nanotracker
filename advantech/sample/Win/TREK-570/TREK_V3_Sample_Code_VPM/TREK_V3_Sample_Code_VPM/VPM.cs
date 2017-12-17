using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;   // for using other APIs
using System.Threading;
using System.Diagnostics;

namespace TREK_V3_Sample_Code_VPM
{
    public partial class VPM : Form
    {
        public const string strVPMDLLName = @"SUSI_IMC_VPM.dll";

        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;
        public static UInt16 IMC_ERR_FW_VERSION_TOO_OLD = 0xC00E;

        public static byte VPM_PORT_NUMBER = 4;

        private bool init_once = false;

        static IntPtr power_off_event;
        bool isHandlePowerOff = false;
        Thread thPowerOffEventHandleThread;

        // The delegate function of showing the RTC current time.
        delegate void ShowRTCTimeDelegate(string strRTCTime);

        ShowRTCTimeDelegate ShowRTCTimeDelegateFunc;

        // The constants
        // The field        
        public static string[] strModeSwitch = new string[]
        {
            "Disabled",
            "Enabled"
        };

        public static string[] strWakeupSource = new string[]  // Caution : The order...
        { 
            "Power Button",
            "Ignition",
            "WWAN",
            "GSensor",
            "DI 0",
            "DI 1",
            "RTC Alarm",
            "Hot Key",
            "DI 2",
            "DI 3",
            "Reset"
        };

        public VPM_API.WAKEUP_SOURCE[] support_wakeup_source_array = new VPM_API.WAKEUP_SOURCE[]
        {
            VPM_API.WAKEUP_SOURCE.WAKEUP_SOURCE_POWER_BUTTON,
            VPM_API.WAKEUP_SOURCE.WAKEUP_SOURCE_IGNITION,
            VPM_API.WAKEUP_SOURCE.WAKEUP_SOURCE_WWAN,
            VPM_API.WAKEUP_SOURCE.WAKEUP_SOURCE_GSENSOR,
            VPM_API.WAKEUP_SOURCE.WAKEUP_SOURCE_ALARM,
            VPM_API.WAKEUP_SOURCE.WAKEUP_SOURCE_D0,
            VPM_API.WAKEUP_SOURCE.WAKEUP_SOURCE_D1
        };

        // The range of threshold
        public static UInt16 sDelayOffEventMin = 1;
        public static UInt16 sDelayOffEventMax = 18000;
        public static UInt16 sDelayOnMin = 1;
        public static UInt16 sDelayOnMax = 18000;
        public static UInt16 sDelayHardOffMin = 1;
        public static UInt16 sDelayHardOffMax = 18000;
        public static UInt16 sDelayLowMin = 1;
        public static UInt16 sDelayLowMax = 300;
        public static UInt16 sDelayLowHardMin = 1;
        public static UInt16 sDelayLowHardMax = 300;

        // The battery information
        VPM_API.IMC_VPM_BATTERY_INFO BatteryInfo12V;
        VPM_API.IMC_VPM_BATTERY_INFO BatteryInfo24V;

        // The flag of checking the worker thread.
        protected int nTimerThreadExit;

        // The time wait for the termination of the worker thread
        protected int nWaitForWorkerThreadTerminateTime;

        // The time interval the worker thread is invoked
        protected int nInvokeWorkerThreadTime;

        public static uint PM_REMOVE = 0x0001;

        // the return value of synchronization function
        public static uint WAIT_OBJECT_0 = 0;

        // The default time wait for the termination of the worker thread
        public static int sDefWaitForWorkerThreadTerminateTime = 2500;

        // The flag of checking if the system is shut down
        static int nSystemShutDown = 0;

        // The car power mode
        VPM_API.CAR_BATTERY_MODE nCarBatteryMode;

        [DllImport("Kernel32.dll")]
        public static extern IntPtr CreateEvent(IntPtr lpEventAttributes, bool bManualReset, bool bInitialState, string lpName);

        [DllImport("Kernel32.dll")]
        public static extern bool SetEvent(IntPtr hEvent);

        [DllImport("Kernel32.dll")]
        public static extern Int32 InterlockedExchange(ref Int32 Target, Int32 Value);

        [DllImport("User32.dll")]
        public static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

        [DllImport("User32.dll")]
        public static extern bool TranslateMessage(ref MSG lpMsg);

        [DllImport("User32.dll")]
        public static extern uint DispatchMessage(ref MSG lpMsg);

        [DllImport("Kernel32.dll")]
        public static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

        [DllImport("Kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        [StructLayout(LayoutKind.Sequential)]
        public struct IMC_RTC_TIME
        {
            public byte Year;
            public byte Month;
            public byte Day;
            public byte DayOfWeek;
            public byte Hour;
            public byte Minute;
            public byte Second;
            public byte PM;
        };

        // The delegate function
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate void RTC_GetRTCTime_Funptr(ref IMC_RTC_TIME RTCTime);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            POINT pt;
        };

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

        // Convert the pointer to array
        protected static unsafe bool ConvertPointer2Array(byte* pbySrc, byte[] byDst, int nLen)
        {
            if (pbySrc == null || byDst == null || nLen == 0 || nLen != byDst.Length)
                return false;

            fixed (byte* pDstTmp = byDst)
            {
                byte* pSrc = pbySrc;
                byte* pDst = pDstTmp;
                for (int i = 0; i < nLen; i++)
                {
                    *pDst = *pSrc;
                    pSrc++;
                    pDst++;
                }
            }
            return true;
        }

        // Convert the character into numbers
        protected static bool FormatFirmwareVersion(byte[] byData, int nSize, ref string strFormatData)
        {
            if (nSize != byData.Length)
                return false;

            strFormatData = System.Text.Encoding.Default.GetString(byData, 0, nSize);

            return true;
        }

        // Check if the characters are all numbers
        static public bool ChkNumChar(string strData)
        {
            byte[] byData = System.Text.Encoding.Default.GetBytes(strData);
            int nDataLen = byData.Length;
            bool bDot = false;
            for (int i = 0; i < nDataLen; i++)
            {
                if (byData[i] == '.')
                {
                    if (bDot)
                        return false;
                    else
                    {
                        bDot = true;
                        continue;
                    }
                }
                if (byData[i] < '0' || byData[i] > '9')
                    return false;
            }
            return true;
        }

        bool AccessLowBatteryProtectionData(bool bSet)
        {
            UInt16 nDelayLow;
            UInt16 nDelayLowHard;
            UInt16 LastErrCode;
            if (bSet)
            {
                try
                {
                    nDelayLow = Convert.ToUInt16(EditProtectionDelayLow.Text);
                    nDelayLowHard = Convert.ToUInt16(EditProtectionDelayLowHard.Text);
                }
                catch (System.OverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetLBPLowDelay(nDelayLow);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the low delay " + LastErrCode.ToString("X4"));
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetLBPLowHardDelay(nDelayLowHard);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the low hard delay " + LastErrCode.ToString("X4"));
                    return false;
                }
            }
            else
            {
                LastErrCode = VPM_API.VPM_GetLBPLowDelay(out nDelayLow);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the low delay");
                    return false;
                }

                LastErrCode = VPM_API.VPM_GetLBPLowHardDelay(out nDelayLowHard);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the low hard delay");
                    return false;
                }
                EditProtectionDelayLow.Text = nDelayLow.ToString();
                EditProtectionDelayLowHard.Text = nDelayLowHard.ToString();
            }
            return true;
        }

        bool AccessIgnitionData(bool bSet)
        {
            UInt16 nDelayOffEvent;
            UInt16 nDelayOn;
            UInt16 nDelayHardOff;
            UInt16 LastErrCode;

            if (bSet)
            {
                try
                {
                    if (!ChkNumChar(EditIgnDelayOffEvent.Text)
                        || !ChkNumChar(EditIgnDelayOn.Text)
                        || !ChkNumChar(EditIgnDelayHardOff.Text)
                        )
                    {
                        throw new OverflowException();
                    }
                    nDelayOffEvent = (UInt16)Convert.ToUInt32(EditIgnDelayOffEvent.Text);
                    nDelayOn = (UInt16)Convert.ToUInt32(EditIgnDelayOn.Text);
                    nDelayHardOff = (UInt16)Convert.ToUInt32(EditIgnDelayHardOff.Text);
                }
                catch (System.OverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetIgnOffEventDelay(nDelayOffEvent);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the off event delay " + LastErrCode.ToString("X4"));
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetIgnOnDelay(nDelayOn);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the on delay" + LastErrCode.ToString("X4"));
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetIgnHardOffDelay(nDelayHardOff);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the hard off delay" + LastErrCode.ToString("X4"));
                    return false;
                }
            }
            else
            {
                LastErrCode = VPM_API.VPM_GetIgnOffEventDelay(out nDelayOffEvent);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the off event delay");
                    return false;
                }

                LastErrCode = VPM_API.VPM_GetIgnOnDelay(out nDelayOn);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the on delay");
                    return false;
                }

                LastErrCode = VPM_API.VPM_GetIgnHardOffDelay(out nDelayHardOff);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the hard off delay");
                    return false;
                }

                EditIgnDelayOffEvent.Text = nDelayOffEvent.ToString();
                EditIgnDelayOn.Text = nDelayOn.ToString();
                EditIgnDelayHardOff.Text = nDelayHardOff.ToString();
            }
            return true;
        }

        // Set/Get battery low voltage value
        bool AccessLowBatteryVoltageValue(bool bSet)
        {
            UInt16 LastErrCode;
            float f12VBatteryVoltage = 0.0F;
            float f24VBatteryVoltage = 0.0F;
            float f12VBatteryPrebootVoltage = 0.0F;
            float f24VBatteryPrebootVoltage = 0.0F;
            if (bSet)
            {
                try
                {
                    if (!ChkNumChar(EditLowVoltageThresholdValue12V.Text)
                        || !ChkNumChar(EditLowVoltageThresholdValue24V.Text)
                        )
                    {
                        throw new OverflowException();
                    }
                    f12VBatteryVoltage = (float)Convert.ToDouble(EditLowVoltageThresholdValue12V.Text);
                    f24VBatteryVoltage = (float)Convert.ToDouble(EditLowVoltageThresholdValue24V.Text);
                    f12VBatteryPrebootVoltage = (float)Convert.ToDouble(EditPrebootThresholdValue12V.Text);
                    f24VBatteryPrebootVoltage = (float)Convert.ToDouble(EditPrebootThresholdValue24V.Text);
                }
                catch (System.OverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return false;
                }

                string strOutOfRange;
                if (f12VBatteryVoltage < BatteryInfo12V.fBatteryMinVoltage || f12VBatteryVoltage >= BatteryInfo12V.fBatteryMaxVoltage ||
                    f12VBatteryPrebootVoltage < BatteryInfo12V.fBatteryMinVoltage || f12VBatteryPrebootVoltage >= BatteryInfo12V.fBatteryMaxVoltage)
                {
                    strOutOfRange = String.Format("The range of 12V battery threshold is {0:N4} to {1:N4} V", BatteryInfo12V.fBatteryMinVoltage, BatteryInfo12V.fBatteryMaxVoltage);
                    MessageBox.Show(strOutOfRange, "Error");
                    return false;
                }
                if (f24VBatteryVoltage < BatteryInfo24V.fBatteryMinVoltage || f24VBatteryVoltage > BatteryInfo24V.fBatteryMaxVoltage ||
                    f24VBatteryPrebootVoltage < BatteryInfo24V.fBatteryMinVoltage || f24VBatteryPrebootVoltage > BatteryInfo24V.fBatteryMaxVoltage)
                {
                    strOutOfRange = String.Format("The range of 24V battery threshold is {0:N4} to {1:N4} V", BatteryInfo24V.fBatteryMinVoltage, BatteryInfo24V.fBatteryMaxVoltage);
                    MessageBox.Show(strOutOfRange, "Error");
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetLBPThresholdFor12VSystem(f12VBatteryVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the voltage level of 12 voltage battery" + LastErrCode.ToString("X4"));
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetLBPThresholdFor24VSystem(f24VBatteryVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the voltage level of 24 voltage battery" + LastErrCode.ToString("X4"));
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetPrebootThresholdFor12VSystem(f12VBatteryPrebootVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the preboot of 12 voltage battery" + LastErrCode.ToString("X4"));
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetPrebootThresholdFor24VSystem(f24VBatteryPrebootVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the preboot of 24 voltage battery" + LastErrCode.ToString("X4"));
                    return false;
                }
            }
            else
            {
                LastErrCode = VPM_API.VPM_GetLBPThresholdFor12VSystem(out f12VBatteryVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the voltage level of 12 voltage battery" + LastErrCode.ToString("X4"));
                    return false;
                }
                EditLowVoltageThresholdValue12V.Text = String.Format("{0:N4}", f12VBatteryVoltage);

                LastErrCode = VPM_API.VPM_GetLBPThresholdFor24VSystem(out f24VBatteryVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the voltage level of 24 voltage battery" + LastErrCode.ToString("X4"));
                    return false;
                }
                EditLowVoltageThresholdValue24V.Text = String.Format("{0:N4}", f24VBatteryVoltage);

                LastErrCode = VPM_API.VPM_GetPrebootThresholdFor12VSystem(out f12VBatteryVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the preboot of 12 voltage battery" + LastErrCode.ToString("X4"));
                    return false;
                }
                EditPrebootThresholdValue12V.Text = String.Format("{0:N4}", f12VBatteryVoltage);

                LastErrCode = VPM_API.VPM_GetPrebootThresholdFor24VSystem(out f24VBatteryVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the preboot of 24 voltage battery" + LastErrCode.ToString("X4"));
                    return false;
                }
                EditPrebootThresholdValue24V.Text = String.Format("{0:N4}", f24VBatteryVoltage);
            }
            return true;
        }

        private bool InitBatterySetLowVoltageCtrls()
        {
            UInt16 LastErrCode;
            
            //            float fVoltage;
            BatteryInfo12V = new VPM_API.IMC_VPM_BATTERY_INFO();
            LastErrCode = VPM_API.VPM_GetLBPThresholdInfo(VPM_API.CAR_BATTERY_MODE.CAR_BATTERY_12V, out BatteryInfo12V);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get 12V battery information");
                return false;
            }
            EditLowVoltageThresholdValue12V.Text = BatteryInfo12V.fBatteryDefVoltage.ToString();
            EditPrebootThresholdValue12V.Text = BatteryInfo12V.fBatteryDefPrebootVoltage.ToString();
            EditDefault12VMax.Text = BatteryInfo12V.fBatteryMaxVoltage.ToString();
            EditDefault12VDef.Text = BatteryInfo12V.fBatteryDefVoltage.ToString();
            EditDefault12VMin.Text = BatteryInfo12V.fBatteryMinVoltage.ToString();
            EditDefault12VPreboot.Text = BatteryInfo12V.fBatteryDefPrebootVoltage.ToString();

            BatteryInfo24V = new VPM_API.IMC_VPM_BATTERY_INFO();
            LastErrCode = VPM_API.VPM_GetLBPThresholdInfo(VPM_API.CAR_BATTERY_MODE.CAR_BATTERY_24V, out BatteryInfo24V);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get 24V battery information");
                return false;
            }
            EditLowVoltageThresholdValue24V.Text = BatteryInfo24V.fBatteryDefVoltage.ToString();
            EditPrebootThresholdValue24V.Text = BatteryInfo24V.fBatteryDefPrebootVoltage.ToString();
            EditDefault24VMax.Text = BatteryInfo24V.fBatteryMaxVoltage.ToString();
            EditDefault24VDef.Text = BatteryInfo24V.fBatteryDefVoltage.ToString();
            EditDefault24VMin.Text = BatteryInfo24V.fBatteryMinVoltage.ToString();
            EditDefault24VPreboot.Text = BatteryInfo24V.fBatteryDefPrebootVoltage.ToString();

            return true;
        }

        // Set/Get battery low voltage value
        bool AccessModeSwitch(bool bSet)
        {
            UInt16 LastErrCode;
            int nATModeEnable;
            int nKeepAliveModeEnable;
            if (bSet)
            {
                nATModeEnable = (DomainUDModeSwitchATMode.SelectedIndex == 1 ? 1 : 0);
                LastErrCode = VPM_API.VPM_SetATMode(nATModeEnable);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set AT mode");
                    return false;
                }

                nKeepAliveModeEnable = (DomainUDModeSwitchKeepAliveMode.SelectedIndex == 1 ? 1 : 0);
                LastErrCode = VPM_API.VPM_SetKeepAliveMode(nKeepAliveModeEnable);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set Keep Alive mode");
                    return false;
                }
            }
            else
            {
                LastErrCode = VPM_API.VPM_GetATMode(out nATModeEnable);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get AT mode");
                    return false;
                }
                DomainUDModeSwitchATMode.SelectedIndex = ((nATModeEnable != 0) ? 1 : 0);

                LastErrCode = VPM_API.VPM_GetKeepAliveMode(out nKeepAliveModeEnable);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get Keep Alive mode");
                    return false;
                }
                DomainUDModeSwitchKeepAliveMode.SelectedIndex = ((nKeepAliveModeEnable != 0) ? 1 : 0);
            }
            return true;
        }
        bool AccessWakeupSource(bool bSet)
        {
            int Enabled;
            UInt16 LastErrCode;
            VPM_API.WAKEUP_SOURCE nWakeup_Source;

            nWakeup_Source = support_wakeup_source_array[CmBxWakeupSource.SelectedIndex];


            if (bSet)
            {
                LastErrCode = VPM_API.VPM_SetWakeupSourceControlStatus(nWakeup_Source, DomainUDWakeupSourceStatus.SelectedIndex == 1 ? 1 : 0);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set wakeup source");
                    return false;
                }
            }
            else
            {
                LastErrCode = VPM_API.VPM_GetWakeupSourceControlStatus(nWakeup_Source, out Enabled);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get wakeup source");
                    return false;
                }
                DomainUDWakeupSourceStatus.SelectedIndex = ((Enabled != 0) ? 1 : 0);
            }
            return true;
        }
        // Enable/Disable the Low Battery Protection controls
        void EnableLowBatteryProtectionCtrl(bool bPostBootEnable, bool bPreBootEnable)
        {
            BtnProtectionApply.Enabled = bPostBootEnable | bPreBootEnable;
            EditProtectionDelayLow.Enabled = bPostBootEnable;
            EditProtectionDelayLowHard.Enabled = bPostBootEnable;
            BtnLowVoltageThresholdApply.Enabled = bPostBootEnable | bPreBootEnable;

            if (nCarBatteryMode == VPM_API.CAR_BATTERY_MODE.CAR_BATTERY_12V)
            {
                if (RadioLowVoltageThresholdSet.Checked)
                {
                EditLowVoltageThresholdValue12V.Enabled = bPostBootEnable;
                EditPrebootThresholdValue12V.Enabled = bPreBootEnable;
            }
            }
            else if (nCarBatteryMode == VPM_API.CAR_BATTERY_MODE.CAR_BATTERY_24V)
            {
                if (RadioLowVoltageThresholdSet.Checked)
                {
                EditLowVoltageThresholdValue24V.Enabled = bPostBootEnable;
                EditPrebootThresholdValue24V.Enabled = bPreBootEnable;
            }
        }
        }

        public class VPM_API
        {
            // Enumeration
            public enum CAR_BATTERY_MODE
            {
                CAR_BATTERY_UNKNOWN = -1,
                CAR_BATTERY_DEFAULT = 0,
                CAR_BATTERY_48V = 1,
                CAR_BATTERY_24V = 2,
                CAR_BATTERY_12V = 3,
                CAR_BATTERY_SIZE = 4
            };

            public enum IGNITION_MODE
            {
                IGNITION_NONE = 0,
                IGNITION_POWEROFF = 1,
                IGNITION_SUSPEND = 2,
                IGNITION_SIZE = 3
            };

            public enum PERIPHERAL_TYPE
            {
                PERIPHERAL_WWAN = 0,
                PERIPHERAL_GPS = 1,
                PERIPHERAL_WLAN = 2,
                PERIPHERAL_CAN = 3,
                PERIPHERAL_LAN = 4,
                PERIPHERAL_SIZE = 5
            };

            public enum ALARM_MODE
            {
	            HOURLY = 0,
	            DAILY  = 1,
	            WEEKLY = 2
            };

            public enum WAKEUP_SOURCE
            {
                WAKEUP_SOURCE_NONE = -1,
                WAKEUP_SOURCE_POWER_BUTTON = 0,
                WAKEUP_SOURCE_IGNITION,
                WAKEUP_SOURCE_WWAN,
                WAKEUP_SOURCE_GSENSOR,
                WAKEUP_SOURCE_D0,
                WAKEUP_SOURCE_D1,
                WAKEUP_SOURCE_ALARM,
                WAKEUP_SOURCE_HOTKEY,
                WAKEUP_SOURCE_D2,
                WAKEUP_SOURCE_D3,
                WAKEUP_SOURCE_RESET
            };

            public enum SHUTDOWN_SOURCE
            {
                SHUTDOWN_SOURCE_POWER_BUTTON = 0,
                SHUTDOWN_SOURCE_IGNITION
            };

            // The constants
            public static UInt16 IMC_LIB_VERSION_SIZE = 17;
            public const byte IMC_FIRMWARE_VERSION_SIZE = 32;
            public const byte IMC_PLATFORM_NAME_STRING_SIZE = 16;

            // The structures
            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_VPM_FIRMWARE_INFO
            {
                public unsafe fixed byte version[IMC_FIRMWARE_VERSION_SIZE];
            };

            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_VPM_BATTERY_INFO
            {
                public float fBatteryMaxVoltage;
                public float fBatteryMinVoltage;
                public float fBatteryDefVoltage;
                public float fBatteryDefPrebootVoltage;
            };

            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_VPM_BACKUP_BATTERY_FLAG_INFO
            {
                public bool DSG;
                public bool SOCF;
                public bool SOC1;
                public bool OCVTAKEN;
                public bool CHG;
                public bool FC;
                public bool XCHG;
                public bool CHG_INH;
                public bool OTD;
                public bool OTC;
            };

            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_VPM_BACKUP_BATTERY_INFO
            {
                public int iMaxCapacity;
                public int iCycleCount;
                public IMC_VPM_BACKUP_BATTERY_FLAG_INFO BattryFlag;
            };

            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_VPM_ALARM_TIME
            {
                public byte nDayOfWeek;
                public byte nHour;
                public byte nMinute;
            };

            // The export functions.
            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_Initialize")]
            public static extern UInt16 VPM_Initialize(byte byPort);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_Deinitialize")]
            public static extern UInt16 VPM_Deinitialize();

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetFWVersion")]
            public unsafe static extern UInt16 VPM_GetFWVersion(out IMC_VPM_FIRMWARE_INFO info);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetLibVersion")]
            public static extern UInt16 VPM_GetLibVersion(StringBuilder pVersion);

            [DllImport(strVPMDLLName, CharSet = CharSet.Ansi, EntryPoint = "SUSI_IMC_VPM_GetPlatformName")]
            public static extern UInt16 VPM_GetPlatformName(StringBuilder pName);
            
            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetIgnitionMode")]
            public static extern UInt16 VPM_SetIgnitionMode(IGNITION_MODE nMode);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetIgnitionMode")]
            public static extern UInt16 VPM_GetIgnitionMode(out IGNITION_MODE nMode);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetIgnOffEventDelay")]
            public static extern UInt16 VPM_SetIgnOffEventDelay(UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetIgnOffEventDelay")]
            public static extern UInt16 VPM_GetIgnOffEventDelay(out UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetIgnOnDelay")]
            public static extern UInt16 VPM_SetIgnOnDelay(UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetIgnOnDelay")]
            public static extern UInt16 VPM_GetIgnOnDelay(out UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetLBPLowDelay")]
            public static extern UInt16 VPM_SetLBPLowDelay(UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetLBPLowDelay")]
            public static extern UInt16 VPM_GetLBPLowDelay(out UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetIgnHardOffDelay")]
            public static extern UInt16 VPM_SetIgnHardOffDelay(UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetIgnHardOffDelay")]
            public static extern UInt16 VPM_GetIgnHardOffDelay(out UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetIgnSuspendHardOffDelay")]
            public static extern UInt16 VPM_SetIgnSuspendHardOffDelay(UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetIgnSuspendHardOffDelay")]
            public static extern UInt16 VPM_GetIgnSuspendHardOffDelay(out UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetForceShutDown")]
            public static extern UInt16 VPM_SetForceShutdown(int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetForceShutDown")]
            public static extern UInt16 VPM_GetForceShutdown(out int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetForceShutDownDelay")]
            public static extern UInt16 VPM_SetForceShutDownDelay(UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetForceShutDownDelay")]
            public static extern UInt16 VPM_GetForceShutDownDelay(out UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetLBPLowHardDelay")]
            public static extern UInt16 VPM_SetLBPLowHardDelay(UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetLBPLowHardDelay")]
            public static extern UInt16 VPM_GetLBPLowHardDelay(out UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetLBPThresholdFor12VSystem")]
            public static extern UInt16 VPM_SetLBPThresholdFor12VSystem(float fVoltage);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetLBPThresholdFor12VSystem")]
            public static extern UInt16 VPM_GetLBPThresholdFor12VSystem(out float fVoltage);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetLBPThresholdFor24VSystem")]
            public static extern UInt16 VPM_SetLBPThresholdFor24VSystem(float fVoltage);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetLBPThresholdFor24VSystem")]
            public static extern UInt16 VPM_GetLBPThresholdFor24VSystem(out float fVoltage);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetPrebootThresholdFor12VSystem")]
            public static extern UInt16 VPM_SetPrebootThresholdFor12VSystem(float fVoltage);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetPrebootThresholdFor12VSystem")]
            public static extern UInt16 VPM_GetPrebootThresholdFor12VSystem(out float fVoltage);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetPrebootThresholdFor24VSystem")]
            public static extern UInt16 VPM_SetPrebootThresholdFor24VSystem(float fVoltage);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetPrebootThresholdFor24VSystem")]
            public static extern UInt16 VPM_GetPrebootThresholdFor24VSystem(out float fVoltage);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetLBPThresholdInfo")]
            public static extern UInt16 VPM_GetLBPThresholdInfo(CAR_BATTERY_MODE nCarBatteryMode, out IMC_VPM_BATTERY_INFO BatteryInfo);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetCurrentCarBatteryMode")]
            public static extern UInt16 VPM_GetCurrentCarBatteryMode(ref CAR_BATTERY_MODE nCarBatteryMode);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetCurrentCarBatteryMode")]
            public static extern UInt16 VPM_SetCurrentCarBatteryMode(CAR_BATTERY_MODE nCarBatteryMode);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetIgnitionStatus")]
            public static extern UInt16 VPM_GetIgnitionStatus(out int bIngON);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetCarBatteryVoltage")]
            public static extern UInt16 VPM_GetCarBatteryVoltage(out float fVoltage);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetLBPStatus")]
            public static extern UInt16 VPM_SetLBPStatus(int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetLBPStatus")]
            public static extern UInt16 VPM_GetLBPStatus(out int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetPrebootLBPStatus")]
            public static extern UInt16 VPM_SetPrebootLBPStatus(int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetPrebootLBPStatus")]
            public static extern UInt16 VPM_GetPrebootLBPStatus(out int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetATMode")]
            public static extern UInt16 VPM_SetATMode(int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetATMode")]
            public static extern UInt16 VPM_GetATMode(out int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetKeepAliveMode")]
            public static extern UInt16 VPM_SetKeepAliveMode(int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetKeepAliveMode")]
            public static extern UInt16 VPM_GetKeepAliveMode(out int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetShutdownSourceControlStatus")]
            public static extern UInt16 VPM_SetShutdownSourceControlStatus(SHUTDOWN_SOURCE shutdown_source, int Enable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetShutdownSourceControlStatus")]
            public static extern UInt16 VPM_GetShutdownSourceControlStatus(SHUTDOWN_SOURCE shutdown_source, out int Enable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetWakeupSourceControlStatus")]
            public static extern UInt16 VPM_SetWakeupSourceControlStatus(WAKEUP_SOURCE wakeup_source, int Enable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetWakeupSourceControlStatus")]
            public static extern UInt16 VPM_GetWakeupSourceControlStatus(WAKEUP_SOURCE wakeup_source, out int Enable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetLastWakeupSource")]
            public static extern UInt16 VPM_GetLastWakeupSource(out WAKEUP_SOURCE Wakeup_source);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_LoadDefaultValue")]
            public static extern UInt16 VPM_LoadDefaultValue();

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_ForceShutdown")]
            public static extern UInt16 VPM_ForceShutdown();

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetAlarmActive")]
            public static extern UInt16 VPM_SetAlarmActive(bool bActive);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetAlarmActive")]
            public static extern UInt16 VPM_GetAlarmActive(out bool bActive);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetAlarmTime")]
            public static extern UInt16 VPM_SetAlarmTime(ALARM_MODE Alarm_mode, IMC_VPM_ALARM_TIME Alarm_time);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetAlarmTime")]
            public unsafe static extern UInt16 VPM_GetAlarmTime(out ALARM_MODE Alarm_mode, out IMC_VPM_ALARM_TIME Alarm_time);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetBackupBatteryVoltage")]
            public unsafe static extern UInt16 VPM_GetBackupBatteryVoltage(ref float fVoltage);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetBackupBatteryRemainingCapacity")]
            public unsafe static extern UInt16 VPM_GetBackupBatteryRemainingCapacity(ref int iValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetBackupBatteryPercentageOfCharge")]
            public unsafe static extern UInt16 VPM_GetBackupBatteryPercentageOfCharge(ref int iValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetBackupBatteryTemperture")]
            public unsafe static extern UInt16 VPM_GetBackupBatteryTemperture(ref float fTemperture);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetBackupBatteryRemainingTime")]
            public unsafe static extern UInt16 VPM_GetBackupBatteryRemainingTime(ref int iTime);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetBackupBatteryTimeToFull")]
            public unsafe static extern UInt16 VPM_GetBackupBatteryTimeToFul(ref int iTime);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetBackupBatteryInfo")]
            public unsafe static extern UInt16 VPM_GetBackupBatteryInfo(out IMC_VPM_BACKUP_BATTERY_INFO battery_pack_info);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetRTCTime")]
            public static extern UInt16 RTC_SetRTCTime(IMC_RTC_TIME RTCTime);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetRTCTime")]
            public static extern UInt16 RTC_GetRTCTime(out IMC_RTC_TIME RTCTime);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetPrePowerOffAlarm")]
            public static extern UInt16 VPM_SetPrePowerOffAlarm(int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetPrePowerOffAlarm")]
            public static extern UInt16 VPM_GetPrePowerOffAlarm(out int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetPrePowerOffAlarmDelay")]
            public static extern UInt16 VPM_SetPrePowerOffAlarmDelay(UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetPrePowerOffAlarmDelay")]
            public static extern UInt16 VPM_GetPrePowerOffAlarmDelay(out UInt16 usValue);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetIgnPowerOffEvent")]
            public unsafe static extern UInt16 VPM_SetIgnPowerOffEvent(void* hEvent);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetLBPPowerOffEvent")]
            public unsafe static extern UInt16 VPM_SetLBPPowerOffEvent(void* hEvent);
        }

        public VPM()
        {
            InitializeComponent();

            ShowRTCTimeDelegateFunc = new ShowRTCTimeDelegate(ShowRTCTime);
            //RTC_GetRTCTime_FuncPtr = new RTC_GetRTCTime_Funptr(ReadRTCTimeDelegateFunc);
        }


        private void ReadRTCTimeDelegateFunc(ref IMC_RTC_TIME RTCTime)
        {
            string strRTCTimeFormat;
            //if (n24HourExpression != 0)
            //{
            //    strRTCTimeFormat = "20{0:D2}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}";
            //}
            //else
            //{
                if (RTCTime.PM != 0)
                    strRTCTimeFormat = "20{0:D2}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2} PM";
                else
                    strRTCTimeFormat = "20{0:D2}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2} AM";
            //}
            string strRTCTime = String.Format(strRTCTimeFormat,
                RTCTime.Year,
                RTCTime.Month,
                RTCTime.Day,
                RTCTime.Hour,
                RTCTime.Minute,
                RTCTime.Second
                );
            BeginInvoke(ShowRTCTimeDelegateFunc, strRTCTime);
        }

        private void PowerManagement_Load(object sender, EventArgs e)
        {
            bool isFW_too_old = false;
            UInt16 LastErrCode;
            // Get library version
            StringBuilder byLibVersion = new StringBuilder(VPM_API.IMC_LIB_VERSION_SIZE);
            //byte[] byLibVersion = new byte[VPM_API.IMC_LIB_VERSION_SIZE];
            LastErrCode = VPM_API.VPM_GetLibVersion(byLibVersion);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get library version");
                return;
            }
            StaticLibVersionValue.Text = byLibVersion.ToString();

            // Initialize the Power Management library.
            LastErrCode = VPM_API.VPM_Initialize(VPM_PORT_NUMBER);
            if (LastErrCode == IMC_ERR_FW_VERSION_TOO_OLD)
            {
                isFW_too_old = true;
            }
            else if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to start up the VPM library");
                return;
            }

            // Get FW version
            VPM_API.IMC_VPM_FIRMWARE_INFO info;
            LastErrCode = VPM_API.VPM_GetFWVersion(out info);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get firmware version");
                return;
            }
            byte[] byFWVersion = new byte[VPM_API.IMC_FIRMWARE_VERSION_SIZE];
            string strFWFormatVersion = String.Empty;
            unsafe
            {
                ConvertPointer2Array(info.version, byFWVersion, VPM_API.IMC_FIRMWARE_VERSION_SIZE);
                FormatFirmwareVersion(byFWVersion, VPM_API.IMC_FIRMWARE_VERSION_SIZE, ref strFWFormatVersion);
            }
            StaticFirmwareVersionValue.Text = strFWFormatVersion;

            if (isFW_too_old)
            {
                MessageBox.Show("The firmware version is too old.  Please contact your vendor/FAE to upgrade the firmware.");
                return;
            }

            StringBuilder PlatformName = new StringBuilder(VPM_API.IMC_PLATFORM_NAME_STRING_SIZE);
            LastErrCode = VPM_API.VPM_GetPlatformName(PlatformName);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get platform name");
                return;
            }
            StaticPlatformName.Text = PlatformName.ToString();

            nCarBatteryMode = VPM_API.CAR_BATTERY_MODE.CAR_BATTERY_UNKNOWN;
            LastErrCode = VPM_API.VPM_GetCurrentCarBatteryMode(ref nCarBatteryMode);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get the current car battery mode");
                return;
            }
            CbBatteryVoltageModeValue.SelectedIndex = nCarBatteryMode ==  VPM_API.CAR_BATTERY_MODE.CAR_BATTERY_12V? 1 : 0;
            //StaticBatteryVoltageCBModeValue.Text = strBatterVoltageMode[(int)nCarBatteryMode];

            if (nCarBatteryMode == VPM_API.CAR_BATTERY_MODE.CAR_BATTERY_12V)
            {
                EditLowVoltageThresholdValue24V.Enabled = false;
                EditPrebootThresholdValue24V.Enabled = false;
            }
            else if (nCarBatteryMode == VPM_API.CAR_BATTERY_MODE.CAR_BATTERY_24V)
            {
                EditLowVoltageThresholdValue12V.Enabled = false;
                EditPrebootThresholdValue12V.Enabled = false;
            }

            AccessLowBatteryProtectionData(false);
            AccessIgnitionData(false);

            for (int i = 0; i < 2; i++)
            {
                DomainUDModeSwitchATMode.Items.Add(strModeSwitch[i]);
                DomainUDModeSwitchKeepAliveMode.Items.Add(strModeSwitch[i]);
                DomainUDWakeupSourceStatus.Items.Add(strModeSwitch[i]);
                DomianUDShutdownStatus.Items.Add(strModeSwitch[i]);
            }

            for (int i = 0; i < support_wakeup_source_array.Length; i++)
            {
                CmBxWakeupSource.Items.Add( strWakeupSource[ (int)support_wakeup_source_array[i] ]);
            }

            CmBxWakeupSource.SelectedIndex = 0;
            DomainUDWakeupSourceStatus.SelectedIndex = 0;
            DomainUDModeSwitchATMode.SelectedIndex = 0;
            DomainUDModeSwitchKeepAliveMode.SelectedIndex = 0;
            CmbShutdownSource.SelectedIndex = 0;

            AccessLowBatteryVoltageValue(false);

            if (!InitBatterySetLowVoltageCtrls())
            {
                MessageBox.Show("Fails to initialize the controls about setting low voltage");
                return;
            }

            int nPostBootChk, nPreBootChk;
            LastErrCode = VPM_API.VPM_GetLBPStatus(out nPostBootChk);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get low battery protection");
                return;
            }

            LastErrCode = VPM_API.VPM_GetPrebootLBPStatus(out nPreBootChk);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get low battery protection");
                return;
            }

            int nForceShutdownChk = 0;
            LastErrCode = VPM_API.VPM_GetForceShutdown(out nForceShutdownChk);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get force shutdown. firmware unsupprot?");
            }
            ChkEnableLowBatterProtection.Checked = ((nPostBootChk != 0) ? true : false);
            ChkEnablePreBootLowBatterProtection.Checked = ((nPreBootChk != 0) ? true : false);
            EnableLowBatteryProtectionCtrl(ChkEnableLowBatterProtection.Checked, ChkEnablePreBootLowBatterProtection.Checked);
            ChkEnableShutdownDelay.Checked = ((nForceShutdownChk != 0) ? true : false);

            VPMTimer.Enabled = true;

            bool bActive = false;
            LastErrCode = VPM_API.VPM_GetAlarmActive(out bActive);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get alarm status");
                return;
            }

            if (bActive)
            {
                AlarmStatusCmbx.Text = "ON";
            }
            else
            {
                AlarmStatusCmbx.Text = "OFF";
            }

            TimerWorkerThreadInternal();

            // Get Last wakeup source
            VPM_API.WAKEUP_SOURCE nLastWakeup_Source;

            LastErrCode = VPM_API.VPM_GetLastWakeupSource(out nLastWakeup_Source);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get last wakeup source " + LastErrCode.ToString("X4"));
                return;
            }
            else
            {
                if (nLastWakeup_Source > (int)VPM_API.WAKEUP_SOURCE.WAKEUP_SOURCE_POWER_BUTTON)
                {
                    StaticLastWakeupSourceRes.Text = strWakeupSource[(int)nLastWakeup_Source];
                }
            }

            power_off_event = CreateEvent((IntPtr)null, false, false, null);
            unsafe
            {
                fixed (void* pEvent = &power_off_event)
                {
                    if ((LastErrCode = VPM_API.VPM_SetIgnPowerOffEvent(pEvent)) != IMC_ERR_NO_ERROR)
                    {
                        MessageBox.Show("Fails to VPM_SetIgnPowerOffEvent " + LastErrCode.ToString("X4"));
                        Environment.Exit(-1);
                    }

                    if ((LastErrCode = VPM_API.VPM_SetLBPPowerOffEvent(pEvent)) != IMC_ERR_NO_ERROR)
                    {
                        MessageBox.Show("Fails to VPM_SetLBPPowerOffEvent " + LastErrCode.ToString("X4"));
                        Environment.Exit(-1);
                    }
                }
            }

            thPowerOffEventHandleThread = new Thread(PowerOffHandlerThread);
            thPowerOffEventHandleThread.IsBackground = true;
            thPowerOffEventHandleThread.Start();

            init_once = true;
        }

        private delegate void HandlePowerOffFunction();

        void power_off_handler()
        {
            MessageBox.Show("System trigger power off");
        }

        public void PowerOffHandlerThread()
        {
            isHandlePowerOff = true;

            while (isHandlePowerOff)
            {
                uint ret = WaitForSingleObject(power_off_event, 250);
                if (ret == 0 && isHandlePowerOff)
                {
                    HandlePowerOffFunction off_function = new HandlePowerOffFunction(power_off_handler);
                    this.Invoke(off_function);
                }
            }
        }

        protected bool StartTimer(int nInvokeWorkerThreadTimeTmp, int nWaitForWorkerThreadTerminateTimeTmp)
        {
            //nTimerThreadExit = 0;
            //nWaitForWorkerThreadTerminateTime = nWaitForWorkerThreadTerminateTimeTmp;
            //nInvokeWorkerThreadTime = nInvokeWorkerThreadTimeTmp;
            //hEvtTimerThreadDone = CreateEvent(IntPtr.Zero, true, false, null);

            //Thread WorkerThread = new Thread(TimerWorkerThread);
            //WorkerThread.Start();
            return true;
        }

        // The main thread still handle the message while waiting for a worker thread
        static public void WaitForWorkerThread(IntPtr hEvtWait, UInt32 dwMilliSec)
        {
            if (hEvtWait == IntPtr.Zero)
                return;
            MSG msg = new MSG();
            while (true)
            {
                UInt32 nRes = WaitForSingleObject(hEvtWait, dwMilliSec);
                if (nRes == WAIT_OBJECT_0)
                    break;
                if (PeekMessage(out msg, IntPtr.Zero, 0, 0, PM_REMOVE))
                {
                    TranslateMessage(ref msg);
                    DispatchMessage(ref msg);
                }
            }
            CloseHandle(hEvtWait);
        }

        protected bool StopTimer()
        {
            //InterlockedExchange(ref nTimerThreadExit, 1);
            ////            AutoEvtTimerThread.WaitOne(nWaitForWorkerThreadTerminateTime, false);
            //WaitForWorkerThread(hEvtTimerThreadDone, (UInt32)nWaitForWorkerThreadTerminateTime);
            //CloseHandle(hEvtTimerThreadDone);
            //hEvtTimerThreadDone = IntPtr.Zero;

            return true;
        }

        private bool StartReadRTCTime()
        {
            StartTimer(1000, sDefWaitForWorkerThreadTerminateTime);
            return true;
        }

        // Show the string of RTC time
        private void ShowRTCTime(string strRTCTime)
        {
            StaticRTCTimeValue.Text = strRTCTime;
        }

        // Check the flag to make sure that if the flag is shut down.
        static public bool GetSystemShutDown()
        {
            return (nSystemShutDown != 0 ? true : false);
        }

        //protected void TimerWorkerThread()
        //{
        //    if (hEvtTimerThreadDone != IntPtr.Zero)
        //    {
        //        while (nTimerThreadExit == 0)
        //        {
        //            if (GetSystemShutDown())
        //                break;

        //            if (!TimerWorkerThreadInternal())
        //                break;
                   
        //            Thread.Sleep(nInvokeWorkerThreadTime);
        //        }
        //        Thread.Sleep(0);
        //        //                AutoEvtTimerThread.Set();
        //        SetEvent(hEvtTimerThreadDone);
        //    }
        //}

        protected bool TimerWorkerThreadInternal()
        {
            UInt16 LastErrCode;

            TREK_V3_Sample_Code_VPM.VPM.IMC_RTC_TIME RTCTime = new TREK_V3_Sample_Code_VPM.VPM.IMC_RTC_TIME();
            unsafe
            {
                LastErrCode = TREK_V3_Sample_Code_VPM.VPM.VPM_API.RTC_GetRTCTime(out RTCTime);
            }
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to read RTC Time");
                return false;
            }

            string strRTCTimeFormat;
            //if (n24HourExpression != 0)
            //{
            //    strRTCTimeFormat = "20{0:D2}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}";
            //}
            //else
            //{
                if (RTCTime.PM != 0)
                    strRTCTimeFormat = "20{0:D2}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2} PM";
                else
                    strRTCTimeFormat = "20{0:D2}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2} AM";
            //}
            string strRTCTime = String.Format(strRTCTimeFormat,
                RTCTime.Year,
                RTCTime.Month,
                RTCTime.Day,
                RTCTime.Hour,
                RTCTime.Minute,
                RTCTime.Second
                );
            BeginInvoke(ShowRTCTimeDelegateFunc, strRTCTime);
            return true;
        }

        private void PowerManagementTimer_Tick(object sender, EventArgs e)
        {
            int nIngON;
            bool bBusy = false;
            UInt16 LastErrCode;

            LastErrCode = VPM_API.VPM_GetIgnitionStatus(out nIngON);

            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                if (nIngON != 0)
                    MessageBox.Show("Fails to get current ignition status");
                return;
            }
            string strIgnStatus = ((nIngON != 0) ? "ON" : "OFF");

            float fVoltage = 0;
            LastErrCode = VPM_API.VPM_GetCarBatteryVoltage(out fVoltage);

            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                if (nIngON != 0)
                    MessageBox.Show("Fails to get current battery voltage");
                return;
            }
            string strVoltage = fVoltage.ToString("f1") + " V";

            if (!bBusy)
            {
                StaticCurBatteryVoltageValue.Text = strVoltage;
                StaticCurIgnStatusValue.Text = strIgnStatus;
            }

            return;
        }

        private void PowerManagement_Closed(object sender, EventArgs e)
        {
            isHandlePowerOff = false;
            SetEvent(power_off_event);

            UInt16 LastErrCode;
            LastErrCode = VPM_API.VPM_Deinitialize();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to clear up the power management library");
                return;
            }

            CloseHandle(power_off_event);
        }

        private void ChkEnableLowBatterProtection_CheckStateChanged(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            int nEnable = (ChkEnableLowBatterProtection.Checked ? 1 : 0);
            LastErrCode = VPM_API.VPM_SetLBPStatus(nEnable);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to set low battery protection" + LastErrCode.ToString("X4"));
                return;
            }
            EnableLowBatteryProtectionCtrl(ChkEnableLowBatterProtection.Checked,
                ChkEnablePreBootLowBatterProtection.Checked);
        }

        private void RadioProtectionSet_CheckedChanged(object sender, EventArgs e)
        {
            EditProtectionDelayLow.ReadOnly = false;
            EditProtectionDelayLowHard.ReadOnly = false;
        }

        private void RadioProtectionGet_CheckedChanged(object sender, EventArgs e)
        {
            EditProtectionDelayLow.ReadOnly = true;
            EditProtectionDelayLowHard.ReadOnly = true;
        }

        private void BtnProtectionApply_Click(object sender, EventArgs e)
        {
            bool bSuccess = AccessLowBatteryProtectionData(RadioProtectionSet.Checked);
            StaticLowThresholdRes.Text = String.Format((bSuccess ? "Success" : "Failure"));
        }

        private void RadioLowVoltageThresholdSet_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioLowVoltageThresholdSet.Checked)
            {
                if (ChkEnableLowBatterProtection.Checked)
            EditLowVoltageThresholdValue12V.Enabled = true;
                if (ChkEnablePreBootLowBatterProtection.Checked)
                    EditPrebootThresholdValue12V.Enabled = true;
        }
            else
        {
                if (ChkEnableLowBatterProtection.Checked)
            EditLowVoltageThresholdValue12V.Enabled = false;
                if (ChkEnablePreBootLowBatterProtection.Checked)
                    EditPrebootThresholdValue12V.Enabled = false;
            }
        }

        private void BtnLowVoltageThresholdApply_Click(object sender, EventArgs e)
        {
            bool bSuccess = AccessLowBatteryVoltageValue(RadioLowVoltageThresholdSet.Checked);
            StaticLowVoltageThresholdRes.Text = String.Format((bSuccess ? "Success" : "Failure"));
        }


        private void BtnModeSwitchApply_Click(object sender, EventArgs e)
        {
            bool bSuccess = AccessModeSwitch(RadioModeSwitchSet.Checked);
            StaticModeSwitchRes.Text = String.Format((bSuccess ? "Success" : "Failure"));
        }

        private void RadioIgnDelaySet_CheckedChanged(object sender, EventArgs e)
        {
            EditIgnDelayOffEvent.ReadOnly = false;
            EditIgnDelayOn.ReadOnly = false;
            EditIgnDelayHardOff.ReadOnly = false;
        }

        private void RadioIgnDelayGet_CheckedChanged(object sender, EventArgs e)
        {
            EditIgnDelayOffEvent.ReadOnly = true;
            EditIgnDelayOn.ReadOnly = true;
            EditIgnDelayHardOff.ReadOnly = true;
        }

        private void BtnIgnDelayApply_Click(object sender, EventArgs e)
        {
            bool bSuccess = AccessIgnitionData(RadioIgnDelaySet.Checked);
            StaticIgnitionDelayRes.Text = String.Format((bSuccess ? "Success" : "Failure"));
        }

        private void BtnLoadDefault_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            // Load default value
            LastErrCode = VPM_API.VPM_LoadDefaultValue();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to load default value " + LastErrCode.ToString("X4"));
                return;
            }
            MessageBox.Show("Reset all parameters !\nPlease re-open the VPM dialog", "Warning");
        }

        private void BtnGetAlarmStatus_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            bool bActive = false;
            LastErrCode = VPM_API.VPM_GetAlarmActive(out bActive);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get alarm status");
                return;
            }

            if (bActive)
            {
                AlarmStatusCmbx.Text = "ON";
            }
            else
            {
                AlarmStatusCmbx.Text = "OFF";
            }
        }

        private void BtnSetAlarmStatus_Click(object sender, EventArgs e)
        {

            UInt16 LastErrCode;
            bool bActive;
            if (AlarmStatusCmbx.Text == "ON")
            {
                bActive = true;
            }
            else
            {
                bActive = false;
            }

            LastErrCode = VPM_API.VPM_SetAlarmActive(bActive);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get alarm status");
                return;
            }
        }

        private void BtnGetAlarmTime_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;

            unsafe
            {
                VPM_API.ALARM_MODE alarm_mode = new VPM_API.ALARM_MODE();
                VPM_API.IMC_VPM_ALARM_TIME alarm_time = new VPM_API.IMC_VPM_ALARM_TIME();
                LastErrCode = VPM_API.VPM_GetAlarmTime( out alarm_mode, out alarm_time);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get alarm time");
                    return;
                }

                switch (alarm_mode)
                { 
                    case VPM_API.ALARM_MODE.HOURLY:
                        AlarmModeCmbx.Text = "Hourly";
                        break;
                    case VPM_API.ALARM_MODE.DAILY:
                        AlarmModeCmbx.Text = "Daily";
                        break;
                    case VPM_API.ALARM_MODE.WEEKLY:
                        AlarmModeCmbx.Text = "Weekly";
                        break;
                    default:
                        MessageBox.Show("Error : other case! mode =" + alarm_mode.ToString());
                        break;
                }
                EditAlarmDayOfWeek.Text = alarm_time.nDayOfWeek.ToString();
                EditAlarmHour.Text = alarm_time.nHour.ToString();
                EditAlarmMinute.Text = alarm_time.nMinute.ToString();
            }
        }

        private void BtnSetAlarmTime_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            VPM_API.ALARM_MODE alarm_mode = new VPM_API.ALARM_MODE();
            VPM_API.IMC_VPM_ALARM_TIME alarm_time = new VPM_API.IMC_VPM_ALARM_TIME();
            switch (AlarmModeCmbx.Text)
            {
                case "Hourly":
                    alarm_mode = VPM_API.ALARM_MODE.HOURLY;
                    break;
                case "Daily":
                    alarm_mode = VPM_API.ALARM_MODE.DAILY;
                    break;
                case "Weekly":
                    alarm_mode = VPM_API.ALARM_MODE.WEEKLY;
                    break;
            }

            alarm_time.nDayOfWeek = (byte) Convert.ToUInt16(EditAlarmDayOfWeek.Text);
            alarm_time.nHour = (byte)Convert.ToUInt16(EditAlarmHour.Text);
            alarm_time.nMinute = (byte)Convert.ToUInt16(EditAlarmMinute.Text);


            LastErrCode = VPM_API.VPM_SetAlarmTime(alarm_mode, alarm_time);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to set alarm time");
                return;
            }
        }

        private void BtnWakeupSourceApply_Click(object sender, EventArgs e)
        {
            bool bSuccess = AccessWakeupSource(RadioWakeupSourceSet.Checked);
            StaticWakeupSourceRes.Text = String.Format((bSuccess ? "Success" : "Failure"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimerWorkerThreadInternal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            IMC_RTC_TIME dtRTC = new IMC_RTC_TIME();
            // yy/mm/dd
            DateTime DTDayObj = new DateTime();
            DTDayObj = DTDay.Value;

            dtRTC.Year = (byte)(DTDayObj.Year % 2000);
            dtRTC.Month = (byte)DTDayObj.Month;
            dtRTC.Day = (byte)DTDayObj.Day;
            dtRTC.DayOfWeek = (byte)DTDayObj.DayOfWeek;

            // HH/MM/SS
            DateTime DTTimeObj = new DateTime();
            DTTimeObj = DTTime.Value;
            dtRTC.Hour = (byte)DTTimeObj.Hour;
            dtRTC.Minute = (byte)DTTimeObj.Minute;
            dtRTC.Second = (byte)DTTimeObj.Second;

            unsafe
            {
                LastErrCode = TREK_V3_Sample_Code_VPM.VPM.VPM_API.RTC_SetRTCTime(dtRTC);
            }
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to set RTC Time");
                return;
            }

            TimerWorkerThreadInternal();
        }

        private void ChkEnablePreBootLowBatterProtection_CheckStateChanged(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            int nEnable = (ChkEnablePreBootLowBatterProtection.Checked ? 1 : 0);
            LastErrCode = VPM_API.VPM_SetPrebootLBPStatus(nEnable);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to set low battery protection" + LastErrCode.ToString("X4"));
                return;
            }
            EnableLowBatteryProtectionCtrl(ChkEnableLowBatterProtection.Checked,
                ChkEnablePreBootLowBatterProtection.Checked);
        }

        private void VPM_TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VPM_TabControl.SelectedTab == MainTabPage)
            {
                VPMTimer.Enabled = true;
            }
            else
            {
                VPMTimer.Enabled = false;
            }
        }

        private void ChkEnableShutdownDelay_CheckStateChanged(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            int nEnable = (ChkEnableShutdownDelay.Checked ? 1 : 0);
            LastErrCode = VPM_API.VPM_SetForceShutdown(nEnable);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to set force shutdown " + LastErrCode.ToString("X4") + " firmware un-support?");
                return;
            }            
        }

        private void BtnForceShutdownDelayApply_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            UInt16 delay_time_sec;

            if (RadioForceShutdownDelaySet.Checked)
            {  
                try
                {
                    delay_time_sec = Convert.ToUInt16(EditShutdownDelayTime.Text);
                    if (delay_time_sec < 1 || delay_time_sec > 3600)
                       throw new FormatException();
                }
                catch
                {
                    MessageBox.Show("invalid argument");
                    StaticForceShutdownDelayRes.Text = "Failure";
                    return;
                }
                LastErrCode = VPM_API.VPM_SetForceShutDownDelay(delay_time_sec);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set force shutdown delay" + LastErrCode.ToString("X4") + " firmware un-support?");
                    StaticForceShutdownDelayRes.Text = "Failure";
                    return;
                }
            }
            else
            {
                int nForceShutdownChk = 0;
                LastErrCode = VPM_API.VPM_GetForceShutdown(out nForceShutdownChk);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get force shutdown. firmware unsupprot?");
                }
                ChkEnableShutdownDelay.Checked = ((nForceShutdownChk != 0) ? true : false);

                LastErrCode = VPM_API.VPM_GetForceShutDownDelay(out delay_time_sec);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get force shutdown delay" + LastErrCode.ToString("X4") + " firmware un-support?");
                    StaticForceShutdownDelayRes.Text = "Failure";
                    return;
                }

                EditShutdownDelayTime.Text = delay_time_sec.ToString();
            }

            StaticForceShutdownDelayRes.Text = "Success";
        }

        private void CbBatteryVoltageModeValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!init_once)
                return;

            DialogResult result = MessageBox.Show("Do you want to changes battery mode?", "Confirmation", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }

            UInt16 LastErrCode;

            VPM_API.CAR_BATTERY_MODE mode = CbBatteryVoltageModeValue.SelectedIndex == 0 ? VPM_API.CAR_BATTERY_MODE.CAR_BATTERY_24V : VPM_API.CAR_BATTERY_MODE.CAR_BATTERY_12V;
            LastErrCode = VPM_API.VPM_SetCurrentCarBatteryMode(mode);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to set the current car battery mode");
                return;
            }

            nCarBatteryMode = mode;

            MessageBox.Show("Please reboot the system");
        }

        private void BtnShutdown_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("This process will Immediate shutdown the computer", 
                "Are you sure to Power Off?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans != DialogResult.Yes)
                return;

            UInt16 LastErrCode;

            LastErrCode = VPM_API.VPM_ForceShutdown();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to VPM_ForceShutdown " + LastErrCode.ToString("X4"));
                return;
            }            
        }

        private bool ControlShutdownSource()
        {
            UInt16 LastErrCode;
            VPM_API.SHUTDOWN_SOURCE shutdown_source;
            shutdown_source = (VPM_API.SHUTDOWN_SOURCE)CmbShutdownSource.SelectedIndex;

            if (radioShutdownSoruceSet.Checked)
            {
                LastErrCode = VPM_API.VPM_SetShutdownSourceControlStatus(shutdown_source, DomianUDShutdownStatus.SelectedIndex == 1 ? 1 : 0);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to VPM_SetShutdownSourceControlStatus ret = " + LastErrCode.ToString("X4"));
                    return false;
                }
            }
            else
            {
                int Enabled;
                LastErrCode = VPM_API.VPM_GetShutdownSourceControlStatus(shutdown_source, out Enabled);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to VPM_GetShutdownSourceControlStatus ret = " + LastErrCode.ToString("X4"));
                    return false;
                }
                DomianUDShutdownStatus.SelectedIndex = ((Enabled != 0) ? 1 : 0);
            }
            return true;
        }

        private void BtnShutdwonSource_Click(object sender, EventArgs e)
        {
            bool result = ControlShutdownSource();
            StaticShutdownRes.Text = String.Format((result ? "Success" : "Failure"));
        }

        private void ChkEnablePrePowerOff_CheckStateChanged(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            int nEnable = (ChkEnablePrePowerOff.Checked ? 1 : 0);
            LastErrCode = VPM_API.VPM_SetPrePowerOffAlarm(nEnable);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails toVPM_SetPrePowerOffAlarm " + LastErrCode.ToString("X4"));
                return;
            }
        }

        private void BtnPrePowerOffDelayApply_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            UInt16 delay_time_sec;

            if (RadioPrePowerDelaySet.Checked)
            {
                try
                {
                    delay_time_sec = Convert.ToUInt16(EditPrePowerOffAlarmDelayTime.Text);
                }
                catch
                {
                    MessageBox.Show("invalid argument");
                    StaticPrePowerOffDelayRes.Text = "Failure";
                    return;
                }
                LastErrCode = VPM_API.VPM_SetPrePowerOffAlarmDelay(delay_time_sec);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to VPM_SetPrePowerOffAlarmDelay " + LastErrCode.ToString("X4") + " firmware un-support?");
                    StaticPrePowerOffDelayRes.Text = "Failure";
                    return;
                }
            }
            else
            {
                int PrePowerOffAlarmChk = 0;
                LastErrCode = VPM_API.VPM_GetPrePowerOffAlarm(out PrePowerOffAlarmChk);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to VPM_GetPrePowerOffAlarm. firmware unsupprot?");
                }
                ChkEnablePrePowerOff.Checked = ((PrePowerOffAlarmChk != 0) ? true : false);

                LastErrCode = VPM_API.VPM_GetPrePowerOffAlarmDelay(out delay_time_sec);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails toVPM_GetPrePowerOffAlarmDelay " + LastErrCode.ToString("X4") + " firmware un-support?");
                    StaticPrePowerOffDelayRes.Text = "Failure";
                    return;
                }

                EditPrePowerOffAlarmDelayTime.Text = delay_time_sec.ToString();
            }

            StaticPrePowerOffDelayRes.Text = "Success";
        }        
    }
}
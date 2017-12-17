using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;   // for using other APIs
using System.Threading;

namespace TREK_V3_Sample_Code_VPM
{
    public partial class VPM : Form
    {

        public const string strVPMDLLName = @"SUSI_IMC_VPM.dll";

        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;
        public static UInt16 IMC_ERR_WAKEUP_SOURCE_NOT_SUPPORT = 0xC046;
        public static UInt16 IMC_ERR_FW_VERSION_TOO_OLD = 0xC00E;

        public static byte TREK722_CE_PWM_PORT_NUMBER = 6;

        private delegate void ShowVPMData();

        public bool VPMPollingDataThreadActive;

        public Thread VPMPollingDataThreadHandle;

        // The constants
        // The field
        public static string[] strBatterVoltageMode = new string[]  // Caution : The order...
        { 
            "Battery Default",
            "48V Battery",
            "24V Battery",
            "12V Battery", 
        };
        public static string[] strModeSwitch = new string[]
        {
            "Disabled",
            "Enabled"
        };

        public static string[] strWakeupSource = new string[]  // Caution : The order...
        { 
            "None",
            "Power Button",
            "Ignition",
            "WWAN",
            "G-Sensor",
            "DI 0",
            "DI 1",
            "RTC Alarm",
            "Hot Key",
            "DI 2",
            "DI 3"
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

                string strOutOfRange;
                if (nDelayLow < sDelayLowMin || nDelayLow > sDelayLowMax)
                {
                    strOutOfRange = String.Format("The range of Low Delay is {0} to {1} Sec(s)", sDelayLowMin, sDelayLowMax);
                    MessageBox.Show(strOutOfRange, "Error");
                    return false;
                }

                if (nDelayLowHard < sDelayLowHardMin || nDelayLowHard > sDelayLowHardMax)
                {
                    strOutOfRange = String.Format("The range of Low Hard Delay is {0} to {1} Sec(s)", sDelayLowHardMin, sDelayLowHardMax);
                    MessageBox.Show(strOutOfRange, "Error");
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetLBPLowDelay(nDelayLow);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the low delay");
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetLBPLowHardDelay(nDelayLowHard);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the low hard delay");
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
            UInt16 nDelaySuspend;
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
                    nDelaySuspend = (UInt16)Convert.ToUInt32(EditIgnDelaySuspendOff.Text);
                }
                catch (System.OverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return false;
                }

                string strOutOfRange;
                if (nDelayOffEvent < sDelayOffEventMin || nDelayOffEvent > sDelayOffEventMax)
                {
                    strOutOfRange = String.Format("The range of Off Event Delay is {0} to {1} Sec(s)", sDelayOffEventMin, sDelayOffEventMax);
                    MessageBox.Show(strOutOfRange, "Error");
                    return false;
                }
                if (nDelayOn < sDelayOnMin || nDelayOn > sDelayOnMax)
                {

                    strOutOfRange = String.Format("The range of On Delay is {0} to {1} Sec(s)", sDelayOnMin, sDelayOnMax);
                    MessageBox.Show(strOutOfRange, "Error");
                    return false;
                }
                if (nDelayHardOff < sDelayHardOffMin || nDelayHardOff > sDelayHardOffMax)
                {
                    strOutOfRange = String.Format("The range of Hard Off Delay is {0} to {1} Sec(s)", sDelayHardOffMin, sDelayHardOffMax);
                    MessageBox.Show(strOutOfRange, "Error");
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetIgnOffEventDelay(nDelayOffEvent);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the off event delay");
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetIgnOnDelay(nDelayOn);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the on delay");
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetIgnHardOffDelay(nDelayHardOff);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the hard off delay");
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetIgnSuspendHardOffDelay(nDelaySuspend);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the suspend hard delay");
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

                LastErrCode = VPM_API.VPM_GetIgnSuspendHardOffDelay(out nDelaySuspend);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the suspend hard delay");
                    return false;
                }

                EditIgnDelayOffEvent.Text = nDelayOffEvent.ToString();
                EditIgnDelayOn.Text = nDelayOn.ToString();
                EditIgnDelayHardOff.Text = nDelayHardOff.ToString();
                EditIgnDelaySuspendOff.Text = nDelaySuspend.ToString();
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
                    MessageBox.Show("Fails to set the voltage level of 12 voltage battery");
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetLBPThresholdFor24VSystem(f24VBatteryVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the voltage level of 24 voltage battery");
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetPrebootThresholdFor12VSystem(f12VBatteryPrebootVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the preboot of 12 voltage battery");
                    return false;
                }

                LastErrCode = VPM_API.VPM_SetPrebootThresholdFor24VSystem(f24VBatteryPrebootVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to set the preboot of 24 voltage battery");
                    return false;
                }
            }
            else
            {
                LastErrCode = VPM_API.VPM_GetLBPThresholdFor12VSystem(out f12VBatteryVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the voltage level of 12 voltage battery");
                    return false;
                }
                EditLowVoltageThresholdValue12V.Text = String.Format("{0:N4}", f12VBatteryVoltage);

                LastErrCode = VPM_API.VPM_GetLBPThresholdFor24VSystem(out f24VBatteryVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the voltage level of 24 voltage battery");
                    return false;
                }
                EditLowVoltageThresholdValue24V.Text = String.Format("{0:N4}", f24VBatteryVoltage);

                LastErrCode = VPM_API.VPM_GetPrebootThresholdFor12VSystem(out f12VBatteryVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the preboot of 12 voltage battery");
                    return false;
                }
                EditPrebootThresholdValue12V.Text = String.Format("{0:N4}", f12VBatteryVoltage);

                LastErrCode = VPM_API.VPM_GetPrebootThresholdFor24VSystem(out f24VBatteryVoltage);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get the preboot of 24 voltage battery");
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

            nWakeup_Source = (VPM_API.WAKEUP_SOURCE) CmBxWakeupSource.SelectedIndex;

            if (bSet)
            {
                LastErrCode = VPM_API.VPM_SetWakeupSourceControlStatus(nWakeup_Source, DomainUDWakeupSourceStatus.SelectedIndex == 1 ? 1 : 0);
            }
            else
            {
                LastErrCode = VPM_API.VPM_GetWakeupSourceControlStatus(nWakeup_Source, out Enabled);
                if (LastErrCode == IMC_ERR_NO_ERROR)
                {
                    DomainUDWakeupSourceStatus.SelectedIndex = ((Enabled != 0) ? 1 : 0);                    
                }                
            }

            if (LastErrCode == IMC_ERR_NO_ERROR)
            {

                return true;
            }
            else if (LastErrCode == IMC_ERR_WAKEUP_SOURCE_NOT_SUPPORT)
            {
                MessageBox.Show("This wakeup source didn't to support this platform!");
                return false;
            }
            else
            {
                MessageBox.Show("Fails to set wakeup source");
                return false;
            }
        }
        // Enable/Disable the Low Battery Protection controls
        void EnableLowBatteryProtectionCtrl(bool bEnable)
        {
            EditLowVoltageThresholdValue12V.Enabled = bEnable;
            EditLowVoltageThresholdValue24V.Enabled = bEnable;
        }

        void EnablePrebootLowBatteryProtectionCtrl(bool bEnable)
        {
            EditPrebootThresholdValue12V.Enabled = bEnable;
            EditPrebootThresholdValue24V.Enabled = bEnable;
        }

        void SetIgnitionModeOnTrekBar(VPM_API.IGNITION_MODE mode)
        {
            if (mode == VPM_API.IGNITION_MODE.IGNITION_POWEROFF)
            {
                TrkBrIgnitionDelayMode.Value = 0;
            }
            else if (mode == VPM_API.IGNITION_MODE.IGNITION_SUSPEND)
            {
                TrkBrIgnitionDelayMode.Value = 1;
            }
            else
            {
                TrkBrIgnitionDelayMode.Enabled = false;
            }
        }

        class VPM_API
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
	            NO_ALARM = -1,
                HOURLY = 0,
	            DAILY  = 1,
	            WEEKLY = 2
            };

            public enum WAKEUP_SOURCE
            {
                WAKEUP_SOURCE_NONE = 0,
                WAKEUP_SOURCE_POWER_BUTTON = 1,
                WAKEUP_SOURCE_IGNITION = 2,
                WAKEUP_SOURCE_WWAN = 3,
                WAKEUP_SOURCE_D0 = 4,
                WAKEUP_SOURCE_D1 = 5,
                WAKEUP_SOURCE_ALARM = 6
            };

            // The constants
            public static UInt16 IMC_LIB_VERSION_SIZE = 17;
            public const byte IMC_FIRMWARE_VERSION_SIZE = 32;

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
            public unsafe static extern UInt16 VPM_GetLibVersion(byte[] pVersion);

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
            public static extern UInt16 GetPrebootLBPStatus(out int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetATMode")]
            public static extern UInt16 VPM_SetATMode(int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetATMode")]
            public static extern UInt16 VPM_GetATMode(out int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetKeepAliveMode")]
            public static extern UInt16 VPM_SetKeepAliveMode(int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetKeepAliveMode")]
            public static extern UInt16 VPM_GetKeepAliveMode(out int bEnable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_SetWakeupSourceControlStatus")]
            public static extern UInt16 VPM_SetWakeupSourceControlStatus(WAKEUP_SOURCE wakeup_source, int Enable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetWakeupSourceControlStatus")]
            public static extern UInt16 VPM_GetWakeupSourceControlStatus(WAKEUP_SOURCE wakeup_source, out int Enable);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_GetLastWakeupSource")]
            public static extern UInt16 VPM_GetLastWakeupSource(out WAKEUP_SOURCE Wakeup_source);

            [DllImport(strVPMDLLName, EntryPoint = "SUSI_IMC_VPM_LoadDefaultValue")]
            public static extern UInt16 VPM_LoadDefaultValue();

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
        }

        public VPM()
        {
            InitializeComponent();
        }

        private void VPM_Load(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            bool isFW_too_old = false;
            // Get library version
            byte[] byLibVersion = new byte[VPM_API.IMC_LIB_VERSION_SIZE];
            LastErrCode = VPM_API.VPM_GetLibVersion(byLibVersion);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get library version");
                return;
            }
            int nRealSize;
            StaticLibVersionValue.Text = ConvertByte2String(byLibVersion, byLibVersion.Length, out nRealSize);

            // Initialize the Power Management library.
            LastErrCode = VPM_API.VPM_Initialize(TREK722_CE_PWM_PORT_NUMBER);
            if (LastErrCode == IMC_ERR_FW_VERSION_TOO_OLD)
            {
                isFW_too_old = true;
            }
            else if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to start up the VPM library, ErrorCode : "+ LastErrCode.ToString("X4"));
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


            //Get car battery mode
            VPM_API.CAR_BATTERY_MODE nCarBatteryMode = VPM_API.CAR_BATTERY_MODE.CAR_BATTERY_UNKNOWN;
            LastErrCode = VPM_API.VPM_GetCurrentCarBatteryMode(ref nCarBatteryMode);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get the current car battery mode");
                return;
            }
            StaticBatteryVoltageCBModeValue.Text = strBatterVoltageMode[(int)nCarBatteryMode];

            AccessLowBatteryProtectionData(false);
            AccessIgnitionData(false);

            for (int i = 0; i < 2; i++)
            {
                DomainUDModeSwitchATMode.Items.Add(strModeSwitch[i]);
                DomainUDModeSwitchKeepAliveMode.Items.Add(strModeSwitch[i]);
                DomainUDWakeupSourceStatus.Items.Add(strModeSwitch[i]);
            }

            for (int i = 1; i < strWakeupSource.Length; i++)
            {
                CmBxWakeupSource.Items.Add(strWakeupSource[i]);
            }

            CmBxWakeupSource.SelectedIndex = 0;
            DomainUDWakeupSourceStatus.SelectedIndex = 0;
            DomainUDModeSwitchATMode.SelectedIndex = 0;
            DomainUDModeSwitchKeepAliveMode.SelectedIndex = 0;

            AccessLowBatteryVoltageValue(false);

            if (!InitBatterySetLowVoltageCtrls())
            {
                MessageBox.Show("Fails to initialize the controls about setting low voltage");
                return;
            }

            int nChk;
            LastErrCode = VPM_API.VPM_GetLBPStatus(out nChk);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get low battery protection");
                return;
            }
            bool bChk = ((nChk != 0) ? true : false);
            ChkEnableLowBatterProtection.Checked = bChk;
            EnableLowBatteryProtectionCtrl(bChk);


            LastErrCode = VPM_API.GetPrebootLBPStatus(out nChk);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get preboot low battery protection");
                return;
            }
            bChk = ((nChk != 0) ? true : false);
            ChkEnablePrebootLowBatterProtection.Checked = bChk;
            EnablePrebootLowBatteryProtectionCtrl(bChk);

            RadioLowVoltageThresholdSet.Checked = true;

            VPM_API.IGNITION_MODE IgnMode;
            LastErrCode = VPM_API.VPM_GetIgnitionMode(out IgnMode);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get low Ignition Mode");
                return;
            }
            SetIgnitionModeOnTrekBar(IgnMode);

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

            VPM_API.IMC_VPM_BACKUP_BATTERY_INFO battery_pack_info;
            LastErrCode = VPM_API.VPM_GetBackupBatteryInfo(out battery_pack_info);
            EditBackupBatteryMaxCapacity.Text = battery_pack_info.iMaxCapacity.ToString();

            VPMPollingDataThreadActive = true;
            VPMPollingDataThreadHandle = new Thread(PollingVPMDataThread);
            VPMPollingDataThreadHandle.IsBackground = true;
            VPMPollingDataThreadHandle.Start();

        }

        private void VPM_Closed(object sender, EventArgs e)
        {
            UInt16 LastErrCode;

            VPMPollingDataThreadActive = false;
            VPMPollingDataThreadHandle.Abort();

            LastErrCode = VPM_API.VPM_Deinitialize();
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to clear up the power management library");
                return;
            }
        }

        public void PollingVPMDataThread()
        {
            while (VPMPollingDataThreadActive)
            {
                ShowVPMData sh = new ShowVPMData(ShowVPMDataFun);
                this.Invoke(sh);

                Thread.Sleep(1000);
            }
        }

        public void ShowVPMDataFun()
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
            string strIgnStatus = ((nIngON != 0) ? "IGN ON" : "IGN OFF");

            float fVoltage = 0;
            LastErrCode = VPM_API.VPM_GetCarBatteryVoltage(out fVoltage);

            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                if (nIngON != 0)
                    MessageBox.Show("Fails to get current battery voltage");
                return;
            }
            string strVoltage = String.Format("{0} V", fVoltage);

            if (!bBusy)
            {
                StaticCurBatteryVoltageValue.Text = strVoltage;
                StaticCurIgnStatusValue.Text = strIgnStatus;
            }

            float fBackupBatteryVoltage = 0;
            LastErrCode = VPM_API.VPM_GetBackupBatteryVoltage(ref fBackupBatteryVoltage);
            EditBackupBatteryVoltage.Text = fBackupBatteryVoltage.ToString();

            int iRemainingCapacity = 0;
            LastErrCode = VPM_API.VPM_GetBackupBatteryRemainingCapacity(ref iRemainingCapacity);
            EditBackupBatteryRemainingCapacity.Text = iRemainingCapacity.ToString();

            int iPercentage = 0;
            LastErrCode = VPM_API.VPM_GetBackupBatteryPercentageOfCharge(ref iPercentage);
            EditBackupBattery_BatteryCharge.Text = iPercentage.ToString();

            float fTemperture = 0;
            LastErrCode = VPM_API.VPM_GetBackupBatteryTemperture(ref fTemperture);
            EditBackupBatteryTemperture.Text = fTemperture.ToString();

            int iRemainingTime = 0;
            LastErrCode = VPM_API.VPM_GetBackupBatteryRemainingTime(ref iRemainingTime);
            EditBackupBatteryRemainingTime.Text = iRemainingTime.ToString();

            int iTimeToFull = 0;
            LastErrCode = VPM_API.VPM_GetBackupBatteryTimeToFul(ref iTimeToFull);
            EditBackupBatteryTimeToFull.Text = iTimeToFull.ToString();
        }

        private void ChkEnableLowBatterProtection_CheckStateChanged(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            int nEnable = (ChkEnableLowBatterProtection.Checked ? 1 : 0);
            LastErrCode = VPM_API.VPM_SetLBPStatus(nEnable);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to set low battery protection");
                return;
            }
            EnableLowBatteryProtectionCtrl((nEnable != 0 ? true : false));
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

        private void RadioLowVoltageThreshold_CheckedChanged(object sender, EventArgs e)
        {
            EditLowVoltageThresholdValue12V.Enabled = RadioLowVoltageThresholdSet.Checked;
            EditLowVoltageThresholdValue24V.Enabled = RadioLowVoltageThresholdSet.Checked;
            EditPrebootThresholdValue12V.Enabled = RadioLowVoltageThresholdSet.Checked;
            EditPrebootThresholdValue24V.Enabled = RadioLowVoltageThresholdSet.Checked;            
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
                MessageBox.Show("Fails to load default value");
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
                    case VPM_API.ALARM_MODE.NO_ALARM:
                        AlarmModeCmbx.Text = "No Alarm";
                        break;                    
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
                        MessageBox.Show("Error : other case!");
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

        private void TrkBrIgnitionDelayMode_ValueChanged(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            if (TrkBrIgnitionDelayMode.Value == 0)
            {
                LastErrCode = VPM_API.VPM_SetIgnitionMode(VPM_API.IGNITION_MODE.IGNITION_POWEROFF);
            }
            else
            {
                LastErrCode = VPM_API.VPM_SetIgnitionMode(VPM_API.IGNITION_MODE.IGNITION_SUSPEND);
            }

            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to set ignition mode");
                return;
            }
        }

        private void BtnWakeupSourceApply_Click(object sender, EventArgs e)
        {
            bool bSuccess = AccessWakeupSource(RadioWakeupSourceSet.Checked);
            StaticWakeupSourceRes.Text = String.Format((bSuccess ? "Success" : "Failure"));
        }

        private void BtnGetLastWakeupSource_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            VPM_API.WAKEUP_SOURCE nLastWakeup_Source;

            LastErrCode = VPM_API.VPM_GetLastWakeupSource(out nLastWakeup_Source);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get last wakeup source");
                return;
            }
            else
            {
                if (nLastWakeup_Source != (VPM_API.WAKEUP_SOURCE)0)
                {
                    StaticLastWakeupSourceRes.Text = strWakeupSource[(int)nLastWakeup_Source + 1];
                }
            }
        }

        private void ChkEnablePrebootLowBatterProtection_CheckStateChanged(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            int nEnable = (ChkEnablePrebootLowBatterProtection.Checked ? 1 : 0);
            LastErrCode = VPM_API.VPM_SetPrebootLBPStatus(nEnable);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to set preboot low battery protection");
                return;
            }
            EnablePrebootLowBatteryProtectionCtrl((nEnable != 0 ? true : false));
        }

        private void RadioLowVoltageThresholdGet_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
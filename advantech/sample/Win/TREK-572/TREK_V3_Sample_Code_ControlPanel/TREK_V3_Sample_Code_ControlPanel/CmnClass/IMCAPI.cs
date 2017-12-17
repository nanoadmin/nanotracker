using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;   // for using other APIs

namespace IMCDemo
{
    class IMCAPIDLLName
    {
        public const string strControlPanelDLLName = @"SUSI_IMC_CONTROLPANEL.dll"; 
    }

    class IMCAPIErrCode
    {
// Common error code
        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;
        public static UInt16 IMC_ERR_UNSUPPORT = 0xC003;
        public static UInt16 IMC_ERR_TIME_OUT = 0xC008;

// Hotkey
        public static UInt16 IMC_ERR_INVALID_ARGUMENT = 0xC002;
        public static UInt16 IMC_ERR_NON_ANY_KEY_PRESS = 0xC030;

// Display
        public static UInt16 IMC_ERR_DISPLAY_FUNCTION_OK_PLATFORM_NOT_SUPPORT_ALL = 0xC0D0;
        public static UInt16 IMC_ERR_DISPLAY_FUNCTION_OK_ONLY_BRIGHTNESS = 0xC0D1;
        public static UInt16 IMC_ERR_DISPLAY_FUNCTION_OK_ONLY_SCREEN_CONTROL = 0xC0D2;
        public static UInt16 IMC_ERR_DISPLAY_FUNCTION_OK_SUPPORT = 0xC0D3;
    }

    // Hot Key
    class HotKey_API
    {
        // some constants
        public const byte IMC_RESET_INTO_NORMAL_MODE = 0;
        public const byte IMC_RESET_INTO_BOOT_LOADER_MODE = 1;
        public const byte IMC_LIB_VERSION_SIZE = 17;
        public const byte IMC_FIRMWARE_VERSION_SIZE = 3;
        public const byte IMC_FIRMWARE_FORMAT_VERSION_SIZE = 8;
        public const byte IMC_FIRMWARE_MODEL_NAME_SIZE = 20;
        public const byte IMC_BRIGHTNESS_LEVEL_MIN = 0;
        public const byte IMC_BRIGHTNESS_LEVEL_MAX = 30;
        public const byte IMC_BRIGHTNESS_DUTY_CYCLE_MIN = 1;
        public const byte IMC_BRIGHTNESS_DUTY_CYCLE_MAX = 100;
        public const byte IMC_HOTKEY_BUFFER_SIZE = 7;

        // The structure
        [StructLayout(LayoutKind.Sequential)]
        public struct IMC_CONTROLPANEL_FIRMWARE_INFO
        {
            public unsafe fixed byte version[IMC_FIRMWARE_VERSION_SIZE];
            public unsafe fixed byte model_name[IMC_FIRMWARE_MODEL_NAME_SIZE];
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct IMC_BRIGHTNESS_LEVEL
        {
            public byte maximum;
            public byte minimum;
            public byte current;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct IMC_HOTKEY_MSG_OBJECT
        {
            public unsafe fixed byte buf[IMC_HOTKEY_BUFFER_SIZE];
        }

// The common functions
        // The delegate function
        //        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void HotKey_OnPressAndRelease_Funptr(ref IMC_HOTKEY_MSG_OBJECT msg);

        // The export functions
        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_CONTROLPANEL_GetVersion")]
        public unsafe extern static UInt16 ControlPanel_GetVersion(byte* pversion);

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_CONTROLPANEL_Initialize")]
        public extern static UInt16 ControlPanel_Initialize(byte port_number);

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_CONTROLPANEL_Deinitialize")]
        public extern static UInt16 ControlPanel_Deinitialize();

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_CONTROLPANEL_GetFirmwareInformation")]
        public unsafe extern static UInt16 ControlPanel_GetFirmwareInformation(out IMC_CONTROLPANEL_FIRMWARE_INFO info);

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_CONTROLPANEL_ResetFirmware")]
        public extern static UInt16 ControlPanel_ResetFirmware(byte mode);

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_CONTROLPANEL_LoadDefaultValue")]
        public extern static UInt16 ControlPanel_LoadDefaultValue();

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_LIGHTSENSOR_GetStatus")]
        public unsafe extern static UInt16 LightSensor_GetStatus(out UInt16 light_value);

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_BRIGHTNESS_GetDutyCycle")]
        public unsafe extern static UInt16 Brightness_GetDutyCycle(byte level, out UInt16 duty_cycle);

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_BRIGHTNESS_SetDutyCycle")]
        public extern static UInt16 Brightness_SetDutyCycle(byte level, UInt16 duty_cycle);

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_BRIGHTNESS_GetLevel")]
        public unsafe extern static UInt16 Brightness_GetLevel(out IMC_BRIGHTNESS_LEVEL level);

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_BRIGHTNESS_SetLevel")]
        public extern static UInt16 Brightness_SetLevel(ref IMC_BRIGHTNESS_LEVEL level);

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_HOTKEY_GetLedDutyCycle")]
        public unsafe extern static UInt16 HotKey_GetLedDutyCycle(out byte duty_cycle);

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_HOTKEY_SetLedDutyCycle")]
        public extern static UInt16 HotKey_SetLedDutyCycle(byte duty_cycle);

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_HOTKEY_Read")]
        public unsafe extern static UInt16 HotKey_Read(out IMC_HOTKEY_MSG_OBJECT msg);

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_HOTKEY_RegisterOnPressAndReleaseEventMonitor", CallingConvention = CallingConvention.Winapi)]
        public extern static UInt16 HotKey_RegisterOnPressAndReleaseEventMonitor(MulticastDelegate pFunc);

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_HOTKEY_ClearOnPressEventMonitor")]
        public unsafe extern static UInt16 HotKey_ClearOnPressEventMonitor();

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_HOTKEY_EnableEventMonitor")]
        public unsafe extern static UInt16 HotKey_EnableEventMonitor();

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_HOTKEY_DisableEventMonitor")]
        public unsafe extern static UInt16 HotKey_DisableEventMonitor();

        [DllImport(IMCAPIDLLName.strControlPanelDLLName, EntryPoint = "SUSI_IMC_CONTROLPANEL_TEMPERATURE_GetValue")]
        public unsafe extern static UInt16 Temperature_GetValue(out float val);
    }
}

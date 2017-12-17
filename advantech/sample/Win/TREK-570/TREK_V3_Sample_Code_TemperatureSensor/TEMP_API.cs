using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace TREK_V3_Sample_Code_TemperatureSensor
{
    class TEMP_API
    {
        public const string DLLName = @"SUSI_IMC_TEMPERATURESENSOR.dll";
        public const UInt16 IMC_ERR_NO_ERROR = 0xC000;

        [DllImport(DLLName, EntryPoint = "SUSI_IMC_TEMPERATURESENSOR_Initialize")]
        public static extern UInt16 SUSI_IMC_TEMPERATURESENSOR_Initialize();

        [DllImport(DLLName, EntryPoint = "SUSI_IMC_TEMPERATURESENSOR_Deinitialize")]
        public static extern UInt16 SUSI_IMC_TEMPERATURESENSOR_Deinitialize();

        [DllImport(DLLName, EntryPoint = "SUSI_IMC_TEMPERATURESENSOR_GetLibVersion")]
        public static extern UInt16 SUSI_IMC_TEMPERATURESENSOR_GetLibVersion(byte[] version);

        [DllImport(DLLName, EntryPoint = "SUSI_IMC_TEMPERATURESENSOR_GetCPUCore1Temperature")]
        public static extern UInt16 SUSI_IMC_TEMPERATURESENSOR_GetCPUCore1Temperature(out byte celsius);

        [DllImport(DLLName, EntryPoint = "SUSI_IMC_TEMPERATURESENSOR_GetSystem1Temperature")]
        public static extern UInt16 SUSI_IMC_TEMPERATURESENSOR_GetSystem1Temperature(out byte celsius);

        [DllImport(DLLName, EntryPoint = "SUSI_IMC_TEMPERATURESENSOR_GetCPUCore2Temperature")]
        public static extern UInt16 SUSI_IMC_TEMPERATURESENSOR_GetCPUCore2Temperature(out byte celsius);

        [DllImport(DLLName, EntryPoint = "SUSI_IMC_TEMPERATURESENSOR_GetSystem2Temperature")]
        public static extern UInt16 SUSI_IMC_TEMPERATURESENSOR_GetSystem2Temperature(out byte celsius);
    }
}

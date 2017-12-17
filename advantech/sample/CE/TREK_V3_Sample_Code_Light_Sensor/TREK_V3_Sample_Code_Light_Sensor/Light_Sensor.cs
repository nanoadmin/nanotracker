using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;   // for using other APIs

namespace TREK_V3_Sample_Code_Light_Sensor
{
    public partial class Light_Sensor : Form
    {
        public const string strLightSensorDLLName = @"SUSI_IMC_LIGHT_SENSOR.dll";
        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;

        public class LightSensor_API
        {
            public static UInt16 IMC_LIB_VERSION_SIZE = 18;

            [DllImport(strLightSensorDLLName, EntryPoint = "SUSI_IMC_LIGHTSENSOR_GetLibVersion")]
            public static extern UInt16 LightSensor_GetLibVersion(byte[] Version);

            [DllImport(strLightSensorDLLName, EntryPoint = "SUSI_IMC_LIGHTSENSOR_GetStatus")]
            public unsafe extern static UInt16 LightSensor_GetStatus(out UInt16 light_value);
        }

        public Light_Sensor()
        {
            InitializeComponent();
        }

        private void Light_Sensor_Load(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            byte[] byLibVersion = new byte[LightSensor_API.IMC_LIB_VERSION_SIZE];
            LastErrCode = LightSensor_API.LightSensor_GetLibVersion(byLibVersion);

            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get library version");
                return;
            }
            int nRealSize;
            StaticLibVersionValue.Text = ConvertByte2String(byLibVersion, byLibVersion.Length, out nRealSize);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UInt16 light_value;
            UInt16 LastErrCode;

            unsafe
            {
                LastErrCode = LightSensor_API.LightSensor_GetStatus(out light_value);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to get library version");
                    return;
                }
            }

            textBox1.Text = light_value.ToString();
        }

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
    }
}
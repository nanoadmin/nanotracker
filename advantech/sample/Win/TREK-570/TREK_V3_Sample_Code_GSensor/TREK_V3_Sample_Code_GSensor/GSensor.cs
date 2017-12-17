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

namespace TREK_V3_Sample_Code_GSensor
{
    public partial class GSensor : Form
    {
        public const string strGSensorDLLName = @"SUSI_IMC_GSensor.dll";

        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;
        public static UInt16 IMC_ERR_INVALID_ARGUMENT = 0xC002;
        
        static bool GSensorAlarmActive = false;
        static bool GSensorThreadActive;
        static bool GSensorThreadRunning = false;
        public IntPtr GSensorAlarmEvent;
        public Thread GSensorAlarmHandleThread;
        private delegate void ShowGSensorAlarmDataFunction();

        public static byte GSensor_PORT_NUMBER = 4;
        public const int max_display_message_count = 64;

        class System_API
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr CreateEvent(IntPtr eventAttributes, bool manualReset, bool initialState, String name);

            [DllImport("kernel32.dll")]
            public static extern int WaitForSingleObject(IntPtr hHandle, int dwMilliseconds);

            [DllImport("kernel32.dll")]
            public static extern bool CloseHandle(IntPtr hObject);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetEvent(IntPtr hEvent);
        }

        class GSensor_API
        {
            public static UInt16 IMC_LIB_VERSION_SIZE = 18;

            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_GSENSOR_DATA
            {
                public Int32 x_mg;
                public Int32 y_mg;
                public Int32 z_mg;
            };

            public enum IMC_GSENSOR_RES
            {
                IMC_GSENSOR_RES_2G = 0,
                IMC_GSENSOR_RES_4G,
                IMC_GSENSOR_RES_8G,
                IMC_GSENSOR_RES_16G
            };

            // The export functions.
            [DllImport(strGSensorDLLName, EntryPoint = "SUSI_IMC_GSENSOR_Initialize")]
            public static extern UInt16 GSENSOR_Initialize(byte byPort);

            [DllImport(strGSensorDLLName, EntryPoint = "SUSI_IMC_GSENSOR_Deinitialize")]
            public static extern UInt16 GSENSOR_Deinitialize();

            [DllImport(strGSensorDLLName, EntryPoint = "SUSI_IMC_GSENSOR_GetLibVersion")]
            public unsafe static extern UInt16 GSENSOR_GetLibVersion(byte[] pVersion);

            [DllImport(strGSensorDLLName, EntryPoint = "SUSI_IMC_GSENSOR_GetData")]
            public static extern UInt16 GSENSOR_GetData(out IMC_GSENSOR_DATA data);

            [DllImport(strGSensorDLLName, EntryPoint = "SUSI_IMC_GSENSOR_GetResolution")]
            public static extern UInt16 GSENSOR_GetResolution(out IMC_GSENSOR_RES res);

            [DllImport(strGSensorDLLName, EntryPoint = "SUSI_IMC_GSENSOR_SetResolution")]
            public static extern UInt16 GSENSOR_SetResolution(IMC_GSENSOR_RES res);

            [DllImport(strGSensorDLLName, EntryPoint = "SUSI_IMC_GSENSOR_AlarmEnabled")]
            public static extern UInt16 GSENSOR_AlarmEnabled(byte bActive);

            [DllImport(strGSensorDLLName, EntryPoint = "SUSI_IMC_GSENSOR_SetAlarmEvent")]
            public unsafe static extern UInt16 GSENSOR_SetAlarmEvent(void* hEvent);

            [DllImport(strGSensorDLLName, EntryPoint = "SUSI_IMC_GSENSOR_GetAlarmData")]
            public static extern UInt16 GSENSOR_GetAlarmData(out IMC_GSENSOR_DATA data);

            [DllImport(strGSensorDLLName, EntryPoint = "SUSI_IMC_GSENSOR_GetAlarmThreshold")]
            public static extern UInt16 GSENSOR_GetAlarmThreshold(out UInt32 mg);

            [DllImport(strGSensorDLLName, EntryPoint = "SUSI_IMC_GSENSOR_SetAlarmThreshold")]
            public static extern UInt16 GSENSOR_SetAlarmThreshold(UInt32 mg);

            [DllImport(strGSensorDLLName, EntryPoint = "SUSI_IMC_GSENSOR_GetWakeupThreshold")]
            public static extern UInt16 GSENSOR_GetWakeupThreshold(out UInt32 mg);

            [DllImport(strGSensorDLLName, EntryPoint = "SUSI_IMC_GSENSOR_SetWakeupThreshold")]
            public static extern UInt16 GSENSOR_SetWakeupThreshold(UInt32 mg);
        }
        
        public GSensor()
        {
            InitializeComponent();
        }

        private void GSensor_Load(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            // Get library version
            byte[] byLibVersion = new byte[GSensor_API.IMC_LIB_VERSION_SIZE];
            LastErrCode = GSensor_API.GSENSOR_GetLibVersion(byLibVersion);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get library version");
                return;
            }
            int nRealSize;
            StaticLibVersionValue.Text = ConvertByte2String(byLibVersion, byLibVersion.Length, out nRealSize);

            comboBoxGsensorResValue.Items.Add("+-2G");
            comboBoxGsensorResValue.Items.Add("+-4G");
            comboBoxGsensorResValue.Items.Add("+-8G");
            comboBoxGsensorResValue.Items.Add("+-16G");
            comboBoxGsensorResValue.SelectedIndex = 0;

            listViewGsensorData.Columns.Add("X", 50, HorizontalAlignment.Left);
            listViewGsensorData.Columns.Add("Y", 50, HorizontalAlignment.Left);
            listViewGsensorData.Columns.Add("Z", 50, HorizontalAlignment.Left);
            
            GSensorAlarmEvent = System_API.CreateEvent((IntPtr)null, false, false, null);

            GSensorThreadActive = true;
            GSensorAlarmHandleThread = new Thread(GSensorAlarmProcess);
            GSensorAlarmHandleThread.IsBackground = true;
            GSensorAlarmHandleThread.Start();            
        }

        public void GSensorAlarmProcess()
        {
            GSensorThreadRunning = true;
            while (GSensorThreadActive)
            {
                System_API.WaitForSingleObject(GSensorAlarmEvent, 1000);
                if (GSensorAlarmActive && GSensorThreadActive)
                {
                    this.Invoke(new ShowGSensorAlarmDataFunction(GSensorGetAlarmData));
                }
            }
            GSensorThreadRunning = false;
        }

        private void TkBarGSensorStatus_ValueChanged(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            if (TkBarGSensorStatus.Value == 1)
            {
                LastErrCode = GSensor_API.GSENSOR_Initialize(GSensor_PORT_NUMBER);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to init SDK " + LastErrCode.ToString("X4"));
                    return;
                }

                GSensorGetValueTimer.Interval = 500;
                GSensorGetValueTimer.Enabled = true;
                checkBoxAlarmActive.Enabled = true;

                unsafe
                {
                    fixed (void* pEvent = &GSensorAlarmEvent)
                    {
                        if ((LastErrCode = GSensor_API.GSENSOR_SetAlarmEvent(pEvent)) != IMC_ERR_NO_ERROR)
                        {
                            MessageBox.Show("Fails to GSENSOR_SetAlarmEvent " + LastErrCode.ToString("X4"));
                            Environment.Exit(-1);
                        }
                    }
                }
            }
            else
            {
                GSensorGetValueTimer.Enabled = false;
                checkBoxAlarmActive.Enabled = false;

                LastErrCode = GSensor_API.GSENSOR_Deinitialize();
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to De-init SDK");
                    return;
                }
            }
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

        void GSensorGetAlarmData()
        {
            UInt16 LastErrCode;
            GSensor_API.IMC_GSENSOR_DATA data;

            while (true)
            {
                LastErrCode = GSensor_API.GSENSOR_GetAlarmData(out data);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                return;
            }
            else
            {
                EditGSensorXValue.Text = data.x_mg.ToString();
                EditGSensorYValue.Text = data.y_mg.ToString();
                EditGSensorZValue.Text = data.z_mg.ToString();


                    string[] gsensor_item = { EditGSensorXValue.Text, EditGSensorYValue.Text, EditGSensorZValue.Text };
                    ListViewItem item = new ListViewItem(gsensor_item);

                    if (listViewGsensorData.Items.Count >= max_display_message_count)
                        listViewGsensorData.Items.RemoveAt(listViewGsensorData.Items.Count - 1);
                    listViewGsensorData.Items.Insert(0, item);
                }
            }
        }

        private void GSensorGetValueTimer_Tick(object sender, EventArgs e)
        {
            if (GSensorAlarmActive)
                return;

            UInt16 LastErrCode;
            GSensor_API.IMC_GSENSOR_DATA data;
            LastErrCode = GSensor_API.GSENSOR_GetData(out data);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                MessageBox.Show("Fails to get value " + LastErrCode.ToString("X4"));
                    return;
                }
            else
            {
                EditGSensorXValue.Text = data.x_mg.ToString();
                EditGSensorYValue.Text = data.y_mg.ToString();
                EditGSensorZValue.Text = data.z_mg.ToString();
            }
        }

        private void buttonGsensorResGet_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;

            GSensor_API.IMC_GSENSOR_RES res;
            LastErrCode = GSensor_API.GSENSOR_GetResolution(out res);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to GSENSOR_GetResolution " + LastErrCode.ToString("X4"));
                return;
            }

            comboBoxGsensorResValue.SelectedIndex = (int)res;
        }

        private void buttonGsensorResSet_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;

            GSensor_API.IMC_GSENSOR_RES res = (GSensor_API.IMC_GSENSOR_RES)(comboBoxGsensorResValue.SelectedIndex);
            LastErrCode = GSensor_API.GSENSOR_SetResolution(res);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to GSENSOR_SetResolution " + LastErrCode.ToString("X4"));
                return;
            }
        }

        private void GSensor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("FormClosing");

            GSensorThreadActive = false;
            while (GSensorThreadRunning)
            {
                System_API.SetEvent(GSensorAlarmEvent);
                Thread.Sleep(100);
            }

            TkBarGSensorStatus.Value = 0;

            System_API.CloseHandle(GSensorAlarmEvent);
        }

        private void checkBoxAlarmActive_CheckedChanged(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            if (checkBoxAlarmActive.Checked)
            {
                LastErrCode = GSensor_API.GSENSOR_AlarmEnabled(1);
                GSensorAlarmActive = true;
            }
            else
            {
                GSensorAlarmActive = false;
                LastErrCode = GSensor_API.GSENSOR_AlarmEnabled(0);                
            }
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to GSENSOR_AlarmEnabled " + LastErrCode.ToString("X4"));
                return;
            }
        }

        private void buttonAlarmThGet_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;

            UInt32 mg;
            LastErrCode = GSensor_API.GSENSOR_GetAlarmThreshold(out mg);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to GSENSOR_GetAlarmThreshold " + LastErrCode.ToString("X4"));
                return;
            }

            textBoxAlarmThresholdValue.Text = mg.ToString();
        }

        private void buttonWakeupThGet_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;

            UInt32 mg;
            LastErrCode = GSensor_API.GSENSOR_GetWakeupThreshold(out mg);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to GSENSOR_GetWakeupThreshold " + LastErrCode.ToString("X4"));
                return;
            }

            textBoxWakeupThresholdValue.Text = mg.ToString();
        }

        private void buttonAlarmThSet_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            UInt32 mg;

            try
            {
                mg = Convert.ToUInt32(textBoxAlarmThresholdValue.Text);
            }
            catch
            {
                MessageBox.Show("format error");
                return;
            }

            LastErrCode = GSensor_API.GSENSOR_SetAlarmThreshold(mg);
            if (LastErrCode == IMC_ERR_INVALID_ARGUMENT)
            {
                MessageBox.Show("Threshold over range [2000, 15000] mg");
                return;
            }
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to GSENSOR_SetAlarmThreshold " + LastErrCode.ToString("X4"));
                return;
            }
        }

        private void buttonWakeupThSet_Click(object sender, EventArgs e)
        {
            UInt16 LastErrCode;
            UInt32 mg;

            try
            {
                mg = Convert.ToUInt32(textBoxWakeupThresholdValue.Text);
            }
            catch
            {
                MessageBox.Show("format error");
                return;
            }

            LastErrCode = GSensor_API.GSENSOR_SetWakeupThreshold(mg);
            if (LastErrCode == IMC_ERR_INVALID_ARGUMENT)
            {
                MessageBox.Show("Threshold over range [63,16000) mg");
                return;
            }
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to GSENSOR_GetWakeupThreshold " + LastErrCode.ToString("X4"));
                return;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listViewGsensorData.Items.Clear();
        }
    }
}
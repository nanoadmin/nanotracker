using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;          // For registry
using IMCDemo;
using System.Threading;

namespace IMCDemo.HotKey
{
    public partial class HotKeyForm : IMCBaseForm
    {
// Field
        // The COM port No.
        int nCOMPortNo = 3;

        // The amount of functional hot key to be tested
        static int sFuncHotkeyAmount = 5;

        // The amount of hot key to be tested
        static int sHotkeyAmount = sFuncHotkeyAmount + 2;

// The flag of checking reading hot key status in callback way
        bool bReadHotKeyStatusCallback;

// The flag of checking the worker thread of reading hot key status.
        int nReadHotKeyStatusExit;

// The event of synchronizing the worker thread of reading hot key status
        AutoResetEvent AutoEvtReadHotKeyStatus;

// The delegate function type of showing the result of hot key status
        public delegate bool ShowHotKeyStatusDelegate(byte[] byHotkeyStatus);

// The delegate function of showing the result of hot key status
        ShowHotKeyStatusDelegate ShowHotKeyStatusDelegateFunc;

// The delegate function of showing the result of hot key status in callback way
        HotKey_API.HotKey_OnPressAndRelease_Funptr OnPressAndReleaseDelegateCallbackFunc;

// The flag of checking if the worker thread of reading hot key status exists.
        int nReadLightSensorExit;

        // The event of synchronizing the worker thread of reading light sensor
        AutoResetEvent AutoEvtReadLightSensor;

        bool nEnabledTemperatureSensor;
        AutoResetEvent AutoEvtReadTemperatureSensor;

        // The delegate function type of showing the value of light sensor
        public delegate void ShowLightSensorDelegate(string strLightSensorValue);

        // The delegate function type of showing the value of light sensor
        public delegate void ShowTemperatureSensorDelegate(string strTemperatrueSensorValue);

        // The delegate function of showing the value of light sensor
        ShowLightSensorDelegate ShowLightSensorDelegateFunc;

        // The delegate function of showing the value of temperature sensor
        ShowTemperatureSensorDelegate ShowTemperatureSensorDelegateFunc;

// The flag of checking if certain a process will be executed when the user clicks down a hot key
        int[] arrChkExecProcess;

// The original dialog caption
        string strOriginalDlgCaption;

// The event of checking if the worker thread of initializing the control panel library is done
        IntPtr hEvtInitLibraryDone;

// The critical section of reading/writing H-303 firmware
        static object LockReadWrite = new object();

        // The constructor.
        public HotKeyForm()
        {
            InitializeComponent();

            bReadHotKeyStatusCallback = false;
            nReadHotKeyStatusExit = 0;
            AutoEvtReadHotKeyStatus = new AutoResetEvent(false);
            ShowHotKeyStatusDelegateFunc = new ShowHotKeyStatusDelegate(ShowHotKeyStatus);
            unsafe
            {
                OnPressAndReleaseDelegateCallbackFunc = new HotKey_API.HotKey_OnPressAndRelease_Funptr(OnPressAndReleaseDelegateFunc);
            }

            nReadLightSensorExit = 0;
            AutoEvtReadLightSensor = new AutoResetEvent(false);

            nEnabledTemperatureSensor = false;
            AutoEvtReadTemperatureSensor = new AutoResetEvent(false);

            ShowLightSensorDelegateFunc = new ShowLightSensorDelegate(ShowLightSensor);
            ShowTemperatureSensorDelegateFunc = new ShowTemperatureSensorDelegate(ShowTemperatureSensor);

            arrChkExecProcess = new int[5]{ 1, 1, 1, 1, 1 };

            strOriginalDlgCaption = Text;
            hEvtInitLibraryDone = IntPtr.Zero;
        }

        // Show Hot key status
        private unsafe bool ShowHotKeyStatus(byte[] byHotkeyStatus)
        {
            Debug.WriteLine("ShowHotKeyStatus "+
                byHotkeyStatus[0].ToString("X2") + " "+
                byHotkeyStatus[1].ToString("X2") + " " +
                byHotkeyStatus[2].ToString("X2") + " " +
                byHotkeyStatus[3].ToString("X2") + " " +
                byHotkeyStatus[4].ToString("X2")
            );
            if (byHotkeyStatus == null)
                return false;
            byte byStatus;
            byStatus = byHotkeyStatus[0];
            EditKeyStatusValue1.Text = byStatus.ToString();
            byStatus = byHotkeyStatus[1];
            EditKeyStatusValue2.Text = byStatus.ToString();
            byStatus = byHotkeyStatus[2];
            EditKeyStatusValue3.Text = byStatus.ToString();
            byStatus = byHotkeyStatus[3];
            EditKeyStatusValue4.Text = byStatus.ToString();
            byStatus = byHotkeyStatus[4];
            EditKeyStatusValue5.Text = byStatus.ToString();
            byStatus = byHotkeyStatus[5];
            EditKeyStatusValue6.Text = byStatus.ToString();
            byStatus = byHotkeyStatus[6];
            EditKeyStatusValue7.Text = byStatus.ToString();
            Debug.WriteLine("ShowHotKeyStatus..Done");
            return true;
        }

        // Show the value of light sensor
        private void ShowLightSensor(string strLightSensorValue)
        {
            EditLightSeonsorGetValue.Text = strLightSensorValue;
        }

        // Show the value of temperature sensor
        private void ShowTemperatureSensor(string strTemperatureSensorValue)
        {
            EditTemperatureSeonsorGetValue.Text = strTemperatureSensorValue;
        }

        private unsafe void OnPressAndReleaseDelegateFunc(ref HotKey_API.IMC_HOTKEY_MSG_OBJECT msg)
        {
            byte[] byKeyBuf = new byte[HotKey_API.IMC_HOTKEY_BUFFER_SIZE];
            unsafe
            {
                fixed (byte* pDst = byKeyBuf)
                {
                    fixed (byte* pSrc = msg.buf)
                    {
                        IMCWin32API.CopyMemory(pDst, pSrc, HotKey_API.IMC_HOTKEY_BUFFER_SIZE);
                    }
                }
            }

            BeginInvoke(ShowHotKeyStatusDelegateFunc, byKeyBuf);
        }
        // Get the file name form the full path
        private static string GetFileName(string strFullPath)
        {
            string strFileName = null;
            char[] delimit = new char[] { '\\', 'e', 'x', 'e', '.' };

            foreach (string substr in strFullPath.Split(delimit[0]))
            {
                strFileName = substr.ToString();
            }

            for (int idx = 0; idx < 4; ++idx)
            {
                strFileName = strFileName.TrimEnd(delimit[1 + idx]);
            }

            return strFileName;
        }

        private bool StartReadHotKeyStatus()
        {
            if(bReadHotKeyStatusCallback)
            {
                HotKey_API.HotKey_EnableEventMonitor();
            }
            else
            {
                Thread ReadHotKeyStatusThread = new Thread(ReadHotKeyStatusWorkerThread);
                ReadHotKeyStatusThread.Start();
            }
            return true;
        }

        private bool StopReadHotKeyStatus()
        {
            if (bReadHotKeyStatusCallback)
            {
                HotKey_API.HotKey_DisableEventMonitor();
            }
            else
            {
                nReadHotKeyStatusExit = 1;
                AutoEvtReadHotKeyStatus.WaitOne(IMCTimerThreadBaseForm.sDefWaitForWorkerThreadTerminateTime, false);
            }
            return true;
        }

// The thread function of reading hot key status
        private void ReadHotKeyStatusWorkerThread()
        {
            ushort ret;
            HotKey_API.IMC_HOTKEY_MSG_OBJECT msg = new HotKey_API.IMC_HOTKEY_MSG_OBJECT();
            byte[] byKeyBuf = new byte[HotKey_API.IMC_HOTKEY_BUFFER_SIZE];

            nReadHotKeyStatusExit = 0;

            while (nReadHotKeyStatusExit == 0)
            {
                // Read hot key status from the registers
                ret = HotKey_API.HotKey_Read(out msg);
                if (ret != IMCAPIErrCode.IMC_ERR_NO_ERROR
                    && ret != IMCAPIErrCode.IMC_ERR_TIME_OUT
                    && ret != IMCAPIErrCode.IMC_ERR_NON_ANY_KEY_PRESS
                    )
                {
                    ShowWanringMessage("Fails to read the values of key status", ret);
                    AutoEvtReadHotKeyStatus.Set();
                    return;
                }

                unsafe
                {
                    fixed (byte* pDst = byKeyBuf)
                    {
                        byte* pSrc = msg.buf;
                        {
                            IMCWin32API.CopyMemory(pDst, pSrc, HotKey_API.IMC_HOTKEY_BUFFER_SIZE);
                        }
                    }
                }

                BeginInvoke(ShowHotKeyStatusDelegateFunc, byKeyBuf);
                Thread.Sleep(10);
            }
            Thread.Sleep(0);
            AutoEvtReadHotKeyStatus.Set();
        }

// The worker thread of reading the value of the light sensor
        private void ReadLightSensorWorkerThread()
        {
            ushort ret;

            while (nReadLightSensorExit == 0)
            {
                UInt16 nLightValue = 0;
                unsafe
                {
                    lock (LockReadWrite)
                    {
                        ret = HotKey_API.LightSensor_GetStatus(out nLightValue);
                    }
                }

                if (ret != IMCAPIErrCode.IMC_ERR_NO_ERROR && ret != IMCAPIErrCode.IMC_ERR_TIME_OUT)
                {
                    ShowWanringMessage("Fails to get the light value", ret);
                    break;
                }

                
                BeginInvoke(ShowLightSensorDelegateFunc, nLightValue.ToString());

                float val = 0;
                if (nEnabledTemperatureSensor)
                {
                    unsafe
                    {
                        lock (LockReadWrite)
                        {
                            ret = HotKey_API.Temperature_GetValue(out val);
                        }
                    }

                    if (ret != IMCAPIErrCode.IMC_ERR_NO_ERROR && ret != IMCAPIErrCode.IMC_ERR_TIME_OUT)
                    {
                        ShowWanringMessage("Fails to get the temperature value", ret);
                        RestoreAutoBrightnessCtrlStatus();
                        break;
                    }
                }

                if (nEnabledTemperatureSensor)
                {
                    BeginInvoke(ShowTemperatureSensorDelegateFunc, val.ToString());
                }
                Thread.Sleep(10);
            }
            Thread.Sleep(0);
            AutoEvtReadLightSensor.Set();
            if (nEnabledTemperatureSensor)
            {
                AutoEvtReadTemperatureSensor.Set();
            }
        }

// The worker thread of initializing the control panel library
        public void InitControlPanelLibraryWorkerThread()
        {
            LastErrCode = HotKey_API.ControlPanel_Initialize((byte)nCOMPortNo);
            IMCWin32API.SetEvent(hEvtInitLibraryDone);
        }

// Restore the auto brightness control status
        private void RestoreAutoBrightnessCtrlStatus()
        {
            this.Enabled = true;
            Text = strOriginalDlgCaption;
        }

// Set the string of reading data mode
        private void SetReadDataModeString()
        {
            StaticUseCallback.Text = (bReadHotKeyStatusCallback ? "Read Data Mode : Using Callback" : "Read Data Mode : Not Using Callback");
        }

// Enable/Disable brightness controls
        private void EnableBrightnessCtrls(bool bEnable)
        {
            BtnBrightnessLevelApply.Enabled = bEnable;
            RadioBrightnessLevelSet.Enabled = bEnable;
            RadioBrightnessLevelGet.Enabled = bEnable;
            EditBrightnessLevelMinValue.Enabled = bEnable;
            EditBrightnessLevelMaxValue.Enabled = bEnable;
            EditBrightnessLevelCurValue.Enabled = bEnable;
            BtnBrightnessDutyCycleApply.Enabled = bEnable;
            RadioBrightnessDutyCycleSet.Enabled = bEnable;
            RadioBrightnessDutyCycleGet.Enabled = bEnable;
            EditBrightnessDutyCycleLevelValue.Enabled = bEnable;
            EditBrightnessDutyCycleDutyCycleValue.Enabled = bEnable;
        }

        // The events
        private void HotKeyForm_Load(object sender, EventArgs e)
        {
            ChkShowScrollbar(PanelInner);

            nCOMPortNo = 3;
            FormWait = new IMCWaitForm();
            FormWait.Show();
            int nRealSize;
            try
            {
                // Get library version
                byte[] byLibVersion = new byte[HotKey_API.IMC_LIB_VERSION_SIZE];
                unsafe
                {
                    fixed (byte* pVersion = byLibVersion)
                    {
                        LastErrCode = HotKey_API.ControlPanel_GetVersion(pVersion);
                    }
                }

                if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
                {
                    ShowWanringMessage("Fails to get library version", LastErrCode);
                    NotifyLibInitFail(Text);
                    return;
                }
                StaticLibVersionValue.Text = ConvertByte2String(byLibVersion, byLibVersion.Length, out nRealSize);
            }
            catch (System.Exception ex)
            {
                bDllExist = false;
                MessageBox.Show(ex.Message, "Error");
                IMCWin32API.PostMessage(Handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                //                IMCWin32API.PostQuitMessage(0);
                return;
            }

            // Initialize the ControlPanel library.
            hEvtInitLibraryDone = IMCWin32API.CreateEvent(IntPtr.Zero, true, false, null);
            Thread InitControlPanelLibraryThread = new Thread(InitControlPanelLibraryWorkerThread);
            InitControlPanelLibraryThread.Start();
            // Wait for the worker thread
            IMCCmnFunc.WaitForWorkerThread(hEvtInitLibraryDone, 20);

            if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
            {
                ShowWanringMessage("Fails to initialize the library", LastErrCode);
                NotifyLibInitFail(Text);
                return;
            }

            // Get the firmware version
            HotKey_API.IMC_CONTROLPANEL_FIRMWARE_INFO info = new HotKey_API.IMC_CONTROLPANEL_FIRMWARE_INFO();
            LastErrCode = HotKey_API.ControlPanel_GetFirmwareInformation(out info);
            if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
            {
                ShowWanringMessage("Fails to get firmware information", LastErrCode);
                NotifyLibInitFail(Text);
                return;
            }

            //  Add the new future for TREK-306DH
            //  If the model name was 306D that means it fully supports temperature sensor function
            unsafe
            {
                if (info.model_name[6] == 'D')
                {
                    StaticTemperatureSensor.Enabled = true;
                    StaticTemperatureSensorValue.Enabled = true;
                    EditTemperatureSeonsorGetValue.Enabled = true;
                    nEnabledTemperatureSensor = true;
                }
            }

            byte[] byFWVersion = new byte[HotKey_API.IMC_FIRMWARE_VERSION_SIZE];
            string strFWFormatVersion = String.Empty;
            byte[] byFWModelName = new byte[HotKey_API.IMC_FIRMWARE_MODEL_NAME_SIZE];
            unsafe
            {
                ConvertPointer2Array(info.version, byFWVersion, HotKey_API.IMC_FIRMWARE_VERSION_SIZE);
                FormatFirmwareVersion(byFWVersion, HotKey_API.IMC_FIRMWARE_VERSION_SIZE, ref strFWFormatVersion);
                ConvertPointer2Array(info.model_name, byFWModelName, HotKey_API.IMC_FIRMWARE_MODEL_NAME_SIZE);
            }
            StaticFirmwareVersionValue.Text = strFWFormatVersion;
            StaticFirmwareModelNameValue.Text = ConvertByte2String(byFWModelName, HotKey_API.IMC_FIRMWARE_MODEL_NAME_SIZE, out nRealSize);

            HotKey_API.HotKey_RegisterOnPressAndReleaseEventMonitor(OnPressAndReleaseDelegateCallbackFunc);

// Start to read the hot key status
            StartReadHotKeyStatus();

            SetReadDataModeString();

            FormWait.Hide();
            FormWait = null;

// Create a worker thread to read the value of light sensor
            Thread LightSensorWorkerThread = new Thread(ReadLightSensorWorkerThread);
            LightSensorWorkerThread.IsBackground = true;
            LightSensorWorkerThread.Start();

            IMCCmnFunc.SetWindowZOrder(Handle, IMCWin32API.HWND_TOPMOST);
        }

        private void HotKeyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!bDllExist)
                return;

            LastErrCode = HotKey_API.ControlPanel_Deinitialize();
            if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
            {
                ShowWanringMessage("Fails to clear up the hot key library", LastErrCode);
                return;
            }
        }

        private void HotKeyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bDllExist)
                return;

            nReadLightSensorExit = 1;
            StopReadHotKeyStatus();
            AutoEvtReadLightSensor.WaitOne(IMCTimerThreadBaseForm.sDefWaitForWorkerThreadTerminateTime, false);
            HotKey_API.HotKey_ClearOnPressEventMonitor();
        }

        private void BtnBrightnessDutyCycleApply_Click(object sender, EventArgs e)
        {
            if (RadioBrightnessDutyCycleSet.Checked)
            {
                byte nLevel = Convert.ToByte(EditBrightnessDutyCycleLevelValue.Text);
                UInt16 nDutyCycle = Convert.ToUInt16(EditBrightnessDutyCycleDutyCycleValue.Text);
                if (nLevel < HotKey_API.IMC_BRIGHTNESS_LEVEL_MIN
                    || nLevel > HotKey_API.IMC_BRIGHTNESS_LEVEL_MAX
                    || nDutyCycle < HotKey_API.IMC_BRIGHTNESS_DUTY_CYCLE_MIN
                    || nDutyCycle > HotKey_API.IMC_BRIGHTNESS_DUTY_CYCLE_MAX
                    )
                {
                    string strWarning = String.Format("Out of Range !!\nLevel : {0} - {1}\nDuty Cycle : {2} - {3} ",
                        HotKey_API.IMC_BRIGHTNESS_LEVEL_MIN,
                        HotKey_API.IMC_BRIGHTNESS_LEVEL_MAX,
                        HotKey_API.IMC_BRIGHTNESS_DUTY_CYCLE_MIN,
                        HotKey_API.IMC_BRIGHTNESS_DUTY_CYCLE_MAX
                        );
                    MessageBox.Show(strWarning, "Warning");
                    return;
                }
                if(nLevel == 0)
                {
                    string strWarning = String.Format("Level 0 is read only");
                    MessageBox.Show(strWarning, "Warning");
                    return;
                }
                LastErrCode = HotKey_API.Brightness_SetDutyCycle(nLevel, nDutyCycle);
                if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
                {
                    ShowWanringMessage("Fails to set the brightness duty cycle", LastErrCode);
                    return;
                }
            }
            else
            {
                byte nLevel = (byte)Convert.ToUInt16(EditBrightnessDutyCycleLevelValue.Text);
                if (nLevel < HotKey_API.IMC_BRIGHTNESS_LEVEL_MIN || nLevel > HotKey_API.IMC_BRIGHTNESS_LEVEL_MAX)
                {
                    string strWarning = String.Format("Out of Range !!\nLevel : {0} - {1}",
                        HotKey_API.IMC_BRIGHTNESS_LEVEL_MIN,
                        HotKey_API.IMC_BRIGHTNESS_LEVEL_MAX
                        );
                    MessageBox.Show(strWarning, "Warning");
                    return;
                }
                UInt16 nDutyCycle;
                unsafe
                {
                    LastErrCode = HotKey_API.Brightness_GetDutyCycle(nLevel, out nDutyCycle);
                }
                if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
                {
                    ShowWanringMessage("Fails to get the brightness duty cycle", LastErrCode);
                    return;
                }
                EditBrightnessDutyCycleDutyCycleValue.Text = nDutyCycle.ToString();
            }
        }

        private void RadioBrightnessDutyCycleSet_CheckedChanged(object sender, EventArgs e)
        {
            //            EditBrightnessDutyCycleLevelValue.ReadOnly = false;
            EditBrightnessDutyCycleDutyCycleValue.ReadOnly = false;
        }

        private void RadioBrightnessDutyCycleGet_CheckedChanged(object sender, EventArgs e)
        {
            //            EditBrightnessDutyCycleLevelValue.ReadOnly = true;
            EditBrightnessDutyCycleDutyCycleValue.ReadOnly = true;
        }

        private void BtnBrightnessLevelApply_Click(object sender, EventArgs e)
        {
            ushort ret;

            if (RadioBrightnessLevelSet.Checked)
            {
                HotKey_API.IMC_BRIGHTNESS_LEVEL level = new HotKey_API.IMC_BRIGHTNESS_LEVEL();
                level.minimum = Convert.ToByte(EditBrightnessLevelMinValue.Text);
                level.maximum = Convert.ToByte(EditBrightnessLevelMaxValue.Text);
                level.current = Convert.ToByte(EditBrightnessLevelCurValue.Text);
/*
               string strTmp = String.Format("{0}, {1}, {2}", level.minimum, level.maximum, level.current);
                MessageBox.Show(strTmp, "Warning");
*/
                if (level.minimum < HotKey_API.IMC_BRIGHTNESS_LEVEL_MIN
                    || level.minimum > HotKey_API.IMC_BRIGHTNESS_LEVEL_MAX
                    || level.maximum < HotKey_API.IMC_BRIGHTNESS_LEVEL_MIN
                    || level.maximum > HotKey_API.IMC_BRIGHTNESS_LEVEL_MAX
                    )
                {
                    string strWarning = String.Format("Out of Range !!\nLevel : {0} - {1}\n",
                        HotKey_API.IMC_BRIGHTNESS_LEVEL_MIN,
                        HotKey_API.IMC_BRIGHTNESS_LEVEL_MAX
                        );
                    MessageBox.Show(strWarning, "Warning");
                    return;
                }
                if (level.minimum > level.maximum)
                {
                    string strWarning = String.Format("The min threshold should be larger than the max one");
                    MessageBox.Show(strWarning, "Warning");
                    return;
                }
                if (level.current > level.maximum || level.current < level.minimum)
                {
                    string strWarning = String.Format("Current Value is out of range !!");
                    MessageBox.Show(strWarning, "Warning");
                    return;
                }
                ret = HotKey_API.Brightness_SetLevel(ref level);
                if (ret != IMCAPIErrCode.IMC_ERR_NO_ERROR)
                {
                    ShowWanringMessage("Fails to set the value of the level", ret);
                    return;
                }
            }
            else
            {
                HotKey_API.IMC_BRIGHTNESS_LEVEL level = new HotKey_API.IMC_BRIGHTNESS_LEVEL();
                unsafe
                {
                    ret = HotKey_API.Brightness_GetLevel(out level);
                }
                if (ret != IMCAPIErrCode.IMC_ERR_NO_ERROR)
                {
                    ShowWanringMessage("Fails to get the brightness level", ret);
                    return;
                }
                EditBrightnessLevelMinValue.Text = level.minimum.ToString();
                EditBrightnessLevelMaxValue.Text = level.maximum.ToString();
                EditBrightnessLevelCurValue.Text = level.current.ToString();
            }
        }

        private void RadioBrightnessLevelSet_CheckedChanged(object sender, EventArgs e)
        {
            EditBrightnessLevelMinValue.ReadOnly = false;
            EditBrightnessLevelMaxValue.ReadOnly = false;
            EditBrightnessLevelCurValue.ReadOnly = false;
        }

        private void RadioBrightnessLevelGet_CheckedChanged(object sender, EventArgs e)
        {
            EditBrightnessLevelMinValue.ReadOnly = true;
            EditBrightnessLevelMaxValue.ReadOnly = true;
            EditBrightnessLevelCurValue.ReadOnly = true;
        }

        private void BtnHotKeyLEDDutyCycleSet_Click(object sender, EventArgs e)
        {
            byte byDutyCycle = (byte)Convert.ToUInt16(EditHotKeyLEDDutyCycleSetValue.Text);
            LastErrCode = HotKey_API.HotKey_SetLedDutyCycle(byDutyCycle);
            if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
            {
                ShowWanringMessage("Fails to set the value of the hot key duty cycle", LastErrCode);
                return;
            }
        }

        private void BtnHotKeyLEDDutyCycleGet_Click(object sender, EventArgs e)
        {
            byte byDutyCycle;
            LastErrCode = HotKey_API.HotKey_GetLedDutyCycle(out byDutyCycle);
            if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
            {
                ShowWanringMessage("Fails to get the value of the hot key duty cycle", LastErrCode);
                return;
            }
            EditHotKeyLEDDutyCycleGetValue.Text = byDutyCycle.ToString();
        }

        private void BtnKeyFuncDef_Click(object sender, EventArgs e)
        {
        }

        private void BtnHotKeyUseCallback_Click(object sender, EventArgs e)
        {
            IMCAskUsingCallbackForm dlg = new IMCAskUsingCallbackForm();
            dlg.Callback = bReadHotKeyStatusCallback;
            IMCCmnFunc.SetWindowZOrder(Handle, IMCWin32API.HWND_NOTOPMOST);
            dlg.ShowDialog();
            if(dlg.DialogResult == DialogResult.OK)
            {
                if(dlg.Callback != bReadHotKeyStatusCallback)
                {
// Stop reading the hot key status 
                    StopReadHotKeyStatus();
// Check the method. Using Callback or not ?
                    bReadHotKeyStatusCallback = dlg.Callback;
// Start to read the hot key status in different way
                    bool bSuccess = StartReadHotKeyStatus();
                    if(!bSuccess)
                    {
                        MessageBox.Show("Fails to read the hot key status in different way", "Warning");
                    }
                    SetReadDataModeString();
                }
            }
            IMCCmnFunc.SetWindowZOrder(Handle, IMCWin32API.HWND_TOPMOST);
        }

        private void BtnLoadDefault_Click(object sender, EventArgs e)
        {
            // Load default value
            LastErrCode = HotKey_API.ControlPanel_LoadDefaultValue();
            if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
            {
                ShowWanringMessage("Fails to load default value", LastErrCode);
                return;
            }
            // Reset the firmware into normal mode

            lock(LockReadWrite)
            {
                LastErrCode = HotKey_API.ControlPanel_ResetFirmware(HotKey_API.IMC_RESET_INTO_NORMAL_MODE);
            }
            if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
            {
                ShowWanringMessage("Fails to reset the firmware into normal mode", LastErrCode);
                return;
            }
            MessageBox.Show("The parameters are all reset !\nPlease re-open the HotKey dialog", "Warning");
            IMCWin32API.PostMessage(Handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        private void PanelInner_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(bNeedHScroll | bNeedVScroll))
                return;
            if (e.Button == MouseButtons.Right)
            {
                MenuPopup.Show(this, new Point(e.X, e.Y));
            }
        }
    }
}

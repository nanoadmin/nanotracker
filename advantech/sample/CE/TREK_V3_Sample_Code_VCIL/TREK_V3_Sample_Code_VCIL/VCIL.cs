using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;   // for using other APIs
using System.Threading;

namespace TREK_V3_CanTestTool
{
    public partial class VCIL : Form
    {
        // Hex value.
        static int[] iHexValue = new int[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
        
        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;
        public static UInt16 IMC_ERR_CAN_RX_NOT_READY = 0xC012;

        public static int CAN_SPEED_125K = 0;
        public static int CAN_SPEED_250K = 1;
        public static int CAN_SPEED_500K = 2;
        public static int CAN_SPEED_1M   = 3;

        public const string strVCILDLLName = @"SUSI_IMC_VCIL.dll";
        public const string strCANDLLName = @"SUSI_IMC_CAN.dll";

        public UInt16 LastErrCode;
        /* CAN Data*/
        public IntPtr GetCANDataEvent;
        public Thread thGetCANDataThread;

        public bool bCANPooling;
        public bool bCANStartReadData;
        public bool bCANThreadActive;
        public int can_channel01_speed;
        public int can_channel02_speed;
        private delegate void ShowCanDataFunction();

        /* J1708 Data*/
        public IntPtr GetJ1708DataEvent;
        public Thread thGetJ1708DataThread;

        public bool bJ1708Pooling;
        public bool bJ1708StartReadData;
        public bool bJ1708ThreadActive;
        private delegate void ShowJ1708DataFunction();

        /* J1939 Data*/
        public IntPtr GetJ1939DataEvent;
        public Thread thGetJ1939DataThread;

        public bool bJ1939Pooling;
        public bool bJ1939StartReadData;
        public bool bJ1939ThreadActive;
        private delegate void ShowJ1939DataFunction();

        /* J1587 Data*/
        public IntPtr GetJ1587DataEvent;
        public Thread thGetJ1587DataThread;

        public bool bJ1587Pooling;
        public bool bJ1587StartReadData;
        public bool bJ1587ThreadActive;
        private delegate void ShowJ1587DataFunction();

        /* OBD2 Data*/
        public IntPtr GetOBD2DataEvent;
        public Thread thGetOBD2DataThread;

        public bool bOBD2Pooling;
        public bool bOBD2StartReadData;
        public bool bOBD2ThreadActive;
        private delegate void ShowOBD2DataFunction();

        class System_API
        {
            [DllImport("CoreDll.dll")]
            public static extern IntPtr CreateEvent(IntPtr eventAttributes, bool manualReset, bool initialState, String name);

            [DllImport("CoreDll.dll")]
            public static extern int WaitForSingleObject(IntPtr hHandle, int dwMilliseconds);

            [DllImport("CoreDll.dll")]
            public static extern bool CloseHandle(IntPtr hObject);

            [DllImport("coredll.dll", SetLastError = true)]
            public static extern bool EventModify(IntPtr hEvent, int dEvent);

            public enum EventFlags
            {
                PULSE = 1,
                RESET = 2,
                SET = 3
            }

            public static bool SetEvent(IntPtr hEvent)
            {
                return EventModify(hEvent, (int)EventFlags.SET);
            } 
        }

        class VCIL_API
        {
            public const UInt16 IMC_LIB_VERSION_SIZE = 18;
            public const UInt16 IMC_FW_VERSION_SIZE = 4;

            public static UInt16 VCIL_MODE_CAN = 0x00;
            public static UInt16 VCIL_MODE_CAN_WITH_MASK = 0x01;
            public static UInt16 VCIL_MODE_J1939 = 0x02;
            public static UInt16 VCIL_MODE_J1939_WITH_FILTER = 0x03;
            public static UInt16 VCIL_MODE_OBD2 = 0x04;
            public static UInt16 VCIL_MODE_OBD2_WITH_FILTER = 0x05;

            public static UInt16 VCIL_MODE_J1708 = 0x00;
            public static UInt16 VCIL_MODE_J1587 = 0x01;

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_VCIL_Initialize")]
            public unsafe static extern UInt16 VCIL_Initialize(char* port);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_VCIL_Deinitialize")]
            public static extern UInt16 VCIL_Deinitialize();

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_VCIL_GetLibVersion")]
            public unsafe static extern UInt16 VCIL_GetLibVersion(byte[] pVersion);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_VCIL_GetFWVersion")]
            public unsafe static extern UInt16 VCIL_GetFWVersion(byte[] pVersion);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_VCIL_ResetModule")]
            public static extern UInt16 VCIL_ResetModule();

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_VCIL_ModuleControl")]
            public static extern UInt16 VCIL_ModuleControl(int can_channel_01, int can_channel_02, int j1708_channel);
        }

        class CAN_API
        {
            public const UInt16 IMC_MAX_CAN_MSG_BUFFER_SIZE = 8;

            public static UInt16 CAN_MESSAGE_STANDARD = 0x01; //CAN 2.0a
	        public static UInt16 CAN_MESSAGE_EXTENDED = 0x02; //CAN 2.0b
            public static UInt16 CAN_MESSAGE_RTR      = 0x04;
            public static UInt16 CAN_MESSAGE_STATUS = 0x08;

            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_CAN_MSG_OBJECT
            {
                public UInt32 can_bus_number;
                public UInt32 id;
                public UInt32 message_type;
                public unsafe fixed byte buf[IMC_MAX_CAN_MSG_BUFFER_SIZE];
                public byte buf_len;
            }
            
            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_CAN_MASK_OBJECT
            {
                public int can_bus_number;
                public int mask_number;
                public int enabled;
                public int message_type;
                public UInt32 id;
                public UInt32 mask;	
            }

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_SetMessageMask")]
            public unsafe static extern UInt16 CAN_SetMessageMask(ref IMC_CAN_MASK_OBJECT mask_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_GetMessageMask")]
            public unsafe static extern UInt16 CAN_GetMessageMask(IMC_CAN_MASK_OBJECT* mask_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_RemoveMessageMask")]
            public unsafe static extern UInt16 CAN_RemoveMessageMask(uint can_bus_number, int mask_id);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_ResetMessageMask")]
            public unsafe static extern UInt16 CAN_ResetMessageMask(UInt32 can_bus_number);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_SetBitTiming")]
            public static extern UInt16 CAN_SetBitTiming(uint can_bus_number, int bit_rate);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_Read")]
            public static extern UInt16 CAN_Read(out IMC_CAN_MSG_OBJECT msg_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_Write")]
            public static extern UInt16 CAN_Write(ref IMC_CAN_MSG_OBJECT msg_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_SetEvent")]
            public unsafe static extern UInt16 CAN_SetEvent(void* Event);

        }

        class J1708_API
        {
            public const UInt16 IMC_MAX_J1708_MSG_BUFFER_SIZE = 20;

            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_J1708_MSG_OBJECT
            {
	            public UInt32 mid;
	            public UInt32 pid;
	            public byte pri;
                public unsafe fixed byte buf [IMC_MAX_J1708_MSG_BUFFER_SIZE];
	            public byte buf_len;
            };

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1708_Read")]
            public static extern UInt16 J1708_Read(out IMC_J1708_MSG_OBJECT msg_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1708_Write")]
            public static extern UInt16 J1708_Write(ref IMC_J1708_MSG_OBJECT msg_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1708_SetEvent")]
            public unsafe static extern UInt16 J1708_SetEvent(void* Event);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1708_AddMessageFilter")]
            public unsafe static extern UInt16 J1708_AddMessageFilter(UInt32 mid);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1708_GetMessageFilter")]
            public unsafe static extern UInt16 J1708_GetMessageFilter(UInt32* total, UInt32* mid);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1708_RemoveMessageFilter")]
            public unsafe static extern UInt16 J1708_RemoveMessageFilter(UInt32 mid);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1708_RemoveAllMessageFilter")]
            public unsafe static extern UInt16 J1708_RemoveAllMessageFilter();

        }

        class J1939_API
        {
            public const UInt16 IMC_MAX_J1939_MSG_BUFFER_SIZE = 64;
            public const UInt16 J1939_TRANSMIT_CONFIG_NAME_LEN = 8;

            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_J1939_MSG_OBJECT
            {
                public byte channel_number;
                public UInt32 pgn;
                public byte dst;
                public byte src;
                public byte pri;                
                public unsafe fixed byte buf[IMC_MAX_J1939_MSG_BUFFER_SIZE];
                public ushort buf_len;
            };

            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_J1939_TRANSMIT_CONFIG
            {
                public byte channel_number;
                public byte source_address;
                public unsafe fixed byte source_name[J1939_TRANSMIT_CONFIG_NAME_LEN];
            };

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1939_Read")]
            public static extern UInt16 J1939_Read(out IMC_J1939_MSG_OBJECT msg_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1939_Write")]
            public static extern UInt16 J1939_Write(ref IMC_J1939_MSG_OBJECT msg_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1939_SetEvent")]
            public unsafe static extern UInt16 J1939_SetEvent(void* Event);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1939_AddMessageFilter")]
            public unsafe static extern UInt16 J1939_AddMessageFilter(byte channel_number, UInt32 pgn);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1939_GetMessageFilter")]
            public unsafe static extern UInt16 J1939_GetMessageFilter(byte channel_number, UInt32* total, UInt32* pgn);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1939_RemoveMessageFilter")]
            public unsafe static extern UInt16 J1939_RemoveMessageFilter(byte channel_number, UInt32 pgn);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1939_RemoveAllMessageFilter")]
            public unsafe static extern UInt16 J1939_RemoveAllMessageFilter(byte channel_number);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1939_SetTransmitConfig")]
            public unsafe static extern UInt16 J1939_SetTransmitConfig(IMC_J1939_TRANSMIT_CONFIG transmit_config);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1939_GetTransmitConfig")]
            public unsafe static extern UInt16 J1939_GetTransmitConfig(out IMC_J1939_TRANSMIT_CONFIG transmit_config);

        }

        class J1587_API
        {
            public const UInt16 IMC_MAX_J1587_MSG_BUFFER_SIZE = 20;

            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_J1587_MSG_OBJECT
            {
                public UInt32 mid;
                public UInt32 pid;
                public byte pri;
                public unsafe fixed byte buf[IMC_MAX_J1587_MSG_BUFFER_SIZE];
                public byte buf_len;
            };

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1587_Read")]
            public static extern UInt16 J1587_Read(out IMC_J1587_MSG_OBJECT msg_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1587_Write")]
            public static extern UInt16 J1587_Write(ref IMC_J1587_MSG_OBJECT msg_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1587_SetEvent")]
            public unsafe static extern UInt16 J1587_SetEvent(void* Event);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1587_AddMessageFilter")]
            public unsafe static extern UInt16 J1587_AddMessageFilter(UInt32 mid);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1587_GetMessageFilter")]
            public unsafe static extern UInt16 J1587_GetMessageFilter(UInt32* total, UInt32* mid);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1587_RemoveMessageFilter")]
            public unsafe static extern UInt16 J1587_RemoveMessageFilter(UInt32 mid);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1587_RemoveAllMessageFilter")]
            public unsafe static extern UInt16 J1587_RemoveAllMessageFilter();

        }

        class OBD2_API
        {
            public const UInt16 IMC_MAX_OBD2_MSG_BUFFER_SIZE = 64;

            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_OBD2_MSG_OBJECT
            {
                public byte channel_number;                
                public byte dst;
                public byte src;
                public byte pri;
                public byte tat;
                public unsafe fixed byte buf[IMC_MAX_OBD2_MSG_BUFFER_SIZE];
                public ushort buf_len;
            };

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_OBD2_Read")]
            public static extern UInt16 OBD2_Read(out IMC_OBD2_MSG_OBJECT msg_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_OBD2_Write")]
            public static extern UInt16 OBD2_Write(ref IMC_OBD2_MSG_OBJECT msg_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_OBD2_SetEvent")]
            public unsafe static extern UInt16 OBD2_SetEvent(void* Event);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_OBD2_AddMessageFilter")]
            public unsafe static extern UInt16 OBD2_AddMessageFilter(byte channel_number, UInt32 pid);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_OBD2_GetMessageFilter")]
            public unsafe static extern UInt16 OBD2_GetMessageFilter(byte channel_number, UInt32* total, UInt32* pid);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_OBD2_RemoveMessageFilter")]
            public unsafe static extern UInt16 OBD2_RemoveMessageFilter(byte channel_number, UInt32 pid);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_OBD2_RemoveAllMessageFilter")]
            public unsafe static extern UInt16 OBD2_RemoveAllMessageFilter(byte channel_number);
        }

        public void GetCANDataThread()
        {
            while (bCANThreadActive)
            {
                System_API.WaitForSingleObject(GetCANDataEvent, 6000000);
                if ((bCANPooling == false) && (bCANStartReadData == true))
                {
                    ShowCanDataFunction sh = new ShowCanDataFunction(ShowCanData);
                    this.Invoke(sh);
                }                
            }
        }

        public void GetJ1708DataThread()
        {
            while (bJ1708ThreadActive)
            {
                System_API.WaitForSingleObject(GetJ1708DataEvent, 6000000);
                if ((bJ1708Pooling == false) && (bJ1708StartReadData == true))
                {
                    ShowJ1708DataFunction sh = new ShowJ1708DataFunction(ShowJ1708Data);
                    this.Invoke(sh);
                }
            }
        }

        public void GetJ1939DataThread()
        {
            while (bJ1939ThreadActive)
            {
                System_API.WaitForSingleObject(GetJ1939DataEvent, 6000000);
                if ((bJ1939Pooling == false) && (bJ1939StartReadData == true))
                {
                    ShowJ1939DataFunction sh = new ShowJ1939DataFunction(ShowJ1939Data);
                    this.Invoke(sh);
                }
            }
        }

        public void GetJ1587DataThread()
        {
            while (bJ1587ThreadActive)
            {
                System_API.WaitForSingleObject(GetJ1587DataEvent, 6000000);
                if ((bJ1587Pooling == false) && (bJ1587StartReadData == true))
                {
                    ShowJ1587DataFunction sh = new ShowJ1587DataFunction(ShowJ1587Data);
                    this.Invoke(sh);
                }
            }
        }

        public void GetOBD2DataThread()
        {
            while (bOBD2ThreadActive)
            {
                System_API.WaitForSingleObject(GetOBD2DataEvent, 6000000);
                if ((bOBD2Pooling == false) && (bOBD2StartReadData == true))
                {
                    ShowOBD2DataFunction sh = new ShowOBD2DataFunction(ShowOBD2Data);
                    this.Invoke(sh);
                }
            }
        }

        public void ShowCanData()
        {
            CAN_API.IMC_CAN_MSG_OBJECT msg_object = new CAN_API.IMC_CAN_MSG_OBJECT();
            LastErrCode = CAN_API.CAN_Read(out msg_object);

            uint msg_channel_number = msg_object.can_bus_number;

            if (LastErrCode != IMC_ERR_NO_ERROR && LastErrCode != IMC_ERR_CAN_RX_NOT_READY)
            {
                MessageBox.Show("Fails to read data");
                ReadCanDataTimer.Enabled = false;
                BtnReadCANData.Text = "Stop";
            }

            if (msg_object.buf_len != 0)
            {
                if (ChkBxShowCANData.Checked == true)
                {

                    string strBufData = string.Empty;
                    string strMsgID = msg_object.id.ToString("X2");
                    StringBuilder strBufDataBuilder = new StringBuilder();
                    try
                    {
                        unsafe
                        {
                            byte* pBuf = msg_object.buf;
                            {
                                for (int j = 0; j < msg_object.buf_len; j++)
                                {
                                    strBufDataBuilder.Append(pBuf[j].ToString("X2"));
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        return;
                    }

                    strBufData = strBufDataBuilder.ToString();
                    string[] arrData = { msg_channel_number.ToString(), strMsgID, strBufData, msg_object.buf_len.ToString() };
                    ListViewItem item = new ListViewItem(arrData);
                    if (ListViewReadCANData.Items.Count >= 15)
                        ListViewReadCANData.Items.RemoveAt(0);
                    ListViewReadCANData.Items.Add(item);
                }
            }
        }

        public void ShowJ1708Data()
        {
            J1708_API.IMC_J1708_MSG_OBJECT msg_object = new J1708_API.IMC_J1708_MSG_OBJECT();
            LastErrCode = J1708_API.J1708_Read(out msg_object);

            if (LastErrCode != IMC_ERR_NO_ERROR && LastErrCode != IMC_ERR_CAN_RX_NOT_READY)
            {
                MessageBox.Show("Fails to read J1708 data");
                ReadJ1708DataTimer.Enabled = false;
                ReadJ1708DataBtn.Text = "Stop";
            }

            if ((msg_object.buf_len >= 0) && (LastErrCode == IMC_ERR_NO_ERROR))
            {
                if (ShowJ1708DataChkBx.Checked == true)
                {

                    string strBufData = string.Empty;
                    string strMsgID = msg_object.mid.ToString("X2");
                    StringBuilder strBufDataBuilder = new StringBuilder();
                    try
                    {
                        unsafe
                        {
                            byte* pBuf = msg_object.buf;
                            {
                                for (int j = 0; j < msg_object.buf_len; j++)
                                {
                                    strBufDataBuilder.Append(pBuf[j].ToString("X2"));
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        return;
                    }

                    strBufData = strBufDataBuilder.ToString();
                    string[] arrData = { strMsgID, strBufData, msg_object.buf_len.ToString() };
                    ListViewItem item = new ListViewItem(arrData);
                    if (ListViewReadJ1708Data.Items.Count >= 17)
                        ListViewReadJ1708Data.Items.RemoveAt(0);
                    ListViewReadJ1708Data.Items.Add(item);
                }
            }
        }

        public void ShowJ1939Data()
        {
            J1939_API.IMC_J1939_MSG_OBJECT msg_object = new J1939_API.IMC_J1939_MSG_OBJECT();
            LastErrCode = J1939_API.J1939_Read(out msg_object);

            if (LastErrCode != IMC_ERR_NO_ERROR && LastErrCode != IMC_ERR_CAN_RX_NOT_READY)
            {
                MessageBox.Show("Fails to read J1939 data");
                ReadJ1939DataTimer.Enabled = false;
                trBrJ1939Read.Value = 1; /* 1 is off */
            }

            if ((msg_object.buf_len >= 0) && (LastErrCode == IMC_ERR_NO_ERROR))
            {
                if (ChkBxShowJ1939Data.Checked == true)
                {                    
                    string strJ1939ChannelNumber = msg_object.channel_number.ToString("X2");
                    string strJ1939PGN = msg_object.pgn.ToString("X2");
                    string strJ1939DST = msg_object.dst.ToString("X2");
                    string strJ1939SRC = msg_object.src.ToString("X2");
                    string strJ1939PRI = msg_object.pri.ToString("X2");
                    string strBufData = string.Empty;
                    StringBuilder strBufDataBuilder = new StringBuilder();
                    try
                    {
                        unsafe
                        {
                            byte* pBuf = msg_object.buf;
                            {
                                for (int j = 0; j < msg_object.buf_len; j++)
                                {
                                    strBufDataBuilder.Append(pBuf[j].ToString("X2"));
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        return;
                    }

                    strBufData = strBufDataBuilder.ToString();
                    string[] arrData = { strJ1939ChannelNumber, strJ1939PGN, strJ1939DST, strJ1939SRC, strJ1939PRI, msg_object.buf_len.ToString(), strBufData };
                    ListViewItem item = new ListViewItem(arrData);
                    if (ListViewReadJ1939Data.Items.Count >= 18)
                        ListViewReadJ1939Data.Items.RemoveAt(0);
                    ListViewReadJ1939Data.Items.Add(item);
                }
            }
        }

        public void ShowJ1587Data()
        {
            J1587_API.IMC_J1587_MSG_OBJECT msg_object = new J1587_API.IMC_J1587_MSG_OBJECT();
            LastErrCode = J1587_API.J1587_Read(out msg_object);

            if (LastErrCode != IMC_ERR_NO_ERROR && LastErrCode != IMC_ERR_CAN_RX_NOT_READY)
            {
                MessageBox.Show("Fails to read J1587 data");
                ReadJ1587DataTimer.Enabled = false;
                trBrJ1587Read.Value = 1; /* 1 is off */
            }

            if ((msg_object.buf_len >= 0) && (LastErrCode == IMC_ERR_NO_ERROR))
            {
                if (ShowJ1587DataChkBx.Checked == true)
                {

                    string strBufData = string.Empty;
                    string strMsgID = msg_object.mid.ToString("X2");
                    string strPID = msg_object.pid.ToString("X2");
                    StringBuilder strBufDataBuilder = new StringBuilder();
                    try
                    {
                        unsafe
                        {
                            byte* pBuf = msg_object.buf;
                            {
                                for (int j = 0; j < msg_object.buf_len; j++)
                                {
                                    strBufDataBuilder.Append(pBuf[j].ToString("X2"));
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        return;
                    }

                    strBufData = strBufDataBuilder.ToString();
                    string[] arrData = { strMsgID, strPID, strBufData, msg_object.buf_len.ToString() };
                    ListViewItem item = new ListViewItem(arrData);
                    if (ListViewReadJ1587Data.Items.Count >= 17)
                        ListViewReadJ1587Data.Items.RemoveAt(0);
                    ListViewReadJ1587Data.Items.Add(item);
                }
            }
        }

        public void ShowOBD2Data()
        {
            OBD2_API.IMC_OBD2_MSG_OBJECT msg_object = new OBD2_API.IMC_OBD2_MSG_OBJECT();
            LastErrCode = OBD2_API.OBD2_Read(out msg_object);

            if (LastErrCode != IMC_ERR_NO_ERROR && LastErrCode != IMC_ERR_CAN_RX_NOT_READY)
            {
                MessageBox.Show("Fails to read OBD2 data");
                ReadOBD2DataTimer.Enabled = false;
                trBrOBD2Read.Value = 1; /* 1 is off */
            }

            if ((msg_object.buf_len >= 0) && (LastErrCode == IMC_ERR_NO_ERROR))
            {
                if (ChkBxShowOBD2Data.Checked == true)
                {
                    string strOBD2ChannelNumber = msg_object.channel_number.ToString("X2");
                    string strOBD2DST = msg_object.dst.ToString("X2");
                    string strOBD2SRC = msg_object.src.ToString("X2");
                    string strOBD2PRI = msg_object.pri.ToString("X2");
                    string strOBD2TAT = msg_object.tat.ToString("X2");
                    string strBufData = string.Empty;
                    StringBuilder strBufDataBuilder = new StringBuilder();
                    try
                    {
                        unsafe
                        {
                            byte* pBuf = msg_object.buf;
                            {
                                for (int j = 0; j < msg_object.buf_len; j++)
                                {
                                    strBufDataBuilder.Append(pBuf[j].ToString("X2"));
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        return;
                    }

                    strBufData = strBufDataBuilder.ToString();
                    string[] arrData = { strOBD2ChannelNumber, strOBD2DST, strOBD2SRC, strOBD2PRI, strOBD2TAT, msg_object.buf_len.ToString(), strBufData };
                    ListViewItem item = new ListViewItem(arrData);
                    if (ListViewReadOBD2Data.Items.Count >= 18)
                        ListViewReadOBD2Data.Items.RemoveAt(0);
                    ListViewReadOBD2Data.Items.Add(item);
                }
            }
        }

        public VCIL()
        {
            InitializeComponent();
        }

        private void VCIL_Load(object sender, EventArgs e)
        {
            CANSpeed SpeedForm = new CANSpeed();

            unsafe
            {
                fixed (int* pSpeed = &can_channel01_speed)
                {
                    SpeedForm.SetChannel01SpeedParm(pSpeed);
                }

                fixed (int* pSpeed = &can_channel02_speed)
                {
                    SpeedForm.SetChannel02SpeedParm(pSpeed);
                }
            }

            SpeedForm.ShowDialog();
            unsafe
            {
                char port = (char) 8;
                char* p_port = &port;

                LastErrCode = VCIL.VCIL_API.VCIL_Initialize(p_port);

                if (LastErrCode != VCIL.IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("init fail");
                }
            }

            byte[] byLibVersion = new byte[VCIL_API.IMC_LIB_VERSION_SIZE];
            LastErrCode = VCIL_API.VCIL_GetLibVersion(byLibVersion);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get Library version");
                return;
            }
            int nRealSize;
            StaticLibVersionValue.Text = ConvertByte2String(byLibVersion, byLibVersion.Length, out nRealSize);

            byte[] byFWVersion = new byte[VCIL_API.IMC_FW_VERSION_SIZE];
            LastErrCode = VCIL_API.VCIL_GetFWVersion(byFWVersion);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get Firmware version");
                return;
            }
            StaticFWVersionValue.Text = byFWVersion[0].ToString() + "." + byFWVersion[1].ToString();

            
            CmbxMsgType.SelectedIndex = 0;

            LastErrCode = CAN_API.CAN_SetBitTiming(1, can_channel01_speed);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("set can channel 01 speed faile!");
                return;
            }

            LastErrCode = CAN_API.CAN_SetBitTiming(2, can_channel02_speed);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("set can channel 02 speed faile!");
                return;
            }

            CmbxCanChannel01Speed.SelectedIndex = can_channel01_speed;
            CmbxCanChannel02Speed.SelectedIndex = can_channel02_speed;

            cbBxModuleControlCANChannel01.SelectedIndex = 0;
            cbBxModuleControlCANChannel02.SelectedIndex = 0;
            cbBxModuleControlJ1708Channel.SelectedIndex = 0;

            /* CAN */

            RdBtnCANPolling.Checked = true;
            bCANPooling = true;
            bCANStartReadData = false;
            bCANThreadActive = true;

            CmbxWriteCANDataChannel.Items.Add("1");
            CmbxWriteCANDataChannel.Items.Add("2");
            CmbxWriteCANDataChannel.SelectedIndex = 0;
            CmbxWriteCANDataMessageType.SelectedIndex = 0;

            CmbxCANMaskChannelNumber.Items.Add("1");
            CmbxCANMaskChannelNumber.Items.Add("2");
            CmbxCANMaskChannelNumber.SelectedIndex = 0;

            ListViewReadCANData.Columns.Add("Channel", 66, HorizontalAlignment.Left);
            ListViewReadCANData.Columns.Add("Message ID (HEX)", 120, HorizontalAlignment.Left);
            ListViewReadCANData.Columns.Add("Buffer (HEX)", 110, HorizontalAlignment.Left);
            ListViewReadCANData.Columns.Add("Buffer Size", 80, HorizontalAlignment.Left);

            for (int i = 0; i < 14; i++)
            {
                CmbxCANMaskNumber.Items.Add(i.ToString());
            }
            CmbxCANMaskNumber.SelectedIndex = 0;

            GetCANDataEvent = System_API.CreateEvent((IntPtr)null, false, false, null);

            thGetCANDataThread = new Thread(GetCANDataThread);
            unsafe
            {
                fixed (void* pEvent = &GetCANDataEvent)
                {
                    CAN_API.CAN_SetEvent(pEvent);
                }
            }
            thGetCANDataThread.IsBackground = true;
            thGetCANDataThread.Start();

            /* J1708 */

            ListViewReadJ1708Data.Columns.Add("MID (HEX)", 80, HorizontalAlignment.Left);
            ListViewReadJ1708Data.Columns.Add("Buffer (HEX)", 110, HorizontalAlignment.Left);
            ListViewReadJ1708Data.Columns.Add("Buffer Size", 90, HorizontalAlignment.Left);

            J1708PollingRdBtn.Checked = true;
            bJ1708Pooling = true;
            bJ1708StartReadData = false;
            bJ1708ThreadActive = true;

            GetJ1708DataEvent = System_API.CreateEvent((IntPtr)null, false, false, null);

            thGetJ1708DataThread = new Thread(GetJ1708DataThread);
            unsafe
            {
                fixed (void* pEvent = &GetJ1708DataEvent)
                {
                    J1708_API.J1708_SetEvent(pEvent);
                }
            }
            thGetJ1708DataThread.IsBackground = true;
            thGetJ1708DataThread.Start();

            /* J1939 */

            trBrJ1939Read.Value = 1;
            RdBtnJ1939Polling.Checked = true;            

            CmbxWriteJ1939DataChannel.Items.Add("1");
            CmbxWriteJ1939DataChannel.Items.Add("2");
            CmbxWriteJ1939DataChannel.SelectedIndex = 0;

            CmbxWriteJ1939FilterChannel.Items.Add("1");
            CmbxWriteJ1939FilterChannel.Items.Add("2");
            CmbxWriteJ1939FilterChannel.SelectedIndex = 0;

            cmbxJ1939TransmitConfigChannel.SelectedIndex = 0;

            ListViewReadJ1939Data.Columns.Add("Channel", 66, HorizontalAlignment.Left);
            ListViewReadJ1939Data.Columns.Add("PGN", 50, HorizontalAlignment.Left);
            ListViewReadJ1939Data.Columns.Add("DST", 50, HorizontalAlignment.Left);
            ListViewReadJ1939Data.Columns.Add("SRC", 50, HorizontalAlignment.Left);
            ListViewReadJ1939Data.Columns.Add("PRI", 50, HorizontalAlignment.Left);
            ListViewReadJ1939Data.Columns.Add("Buffer Size", 90, HorizontalAlignment.Left);
            ListViewReadJ1939Data.Columns.Add("Buffer (HEX)", 150, HorizontalAlignment.Left);

            RdBtnJ1939Polling.Checked = true;
            bJ1939Pooling = true;
            bJ1939StartReadData = false;
            bJ1939ThreadActive = true;

            GetJ1939DataEvent = System_API.CreateEvent((IntPtr)null, false, false, null);
            thGetJ1939DataThread = new Thread(GetJ1939DataThread);
            unsafe
            {
                fixed (void* pEvent = &GetJ1939DataEvent)
                {
                    J1939_API.J1939_SetEvent(pEvent);
                }
            }
            thGetJ1939DataThread.IsBackground = true;
            thGetJ1939DataThread.Start();

            /* J1587 */

            trBrJ1587Read.Value = 1;
            J1587PollingRdBtn.Checked = true;

            ListViewReadJ1587Data.Columns.Add("MID (HEX)", 60, HorizontalAlignment.Left);
            ListViewReadJ1587Data.Columns.Add("PID (HEX)", 60, HorizontalAlignment.Left);
            ListViewReadJ1587Data.Columns.Add("Buffer (HEX)", 100, HorizontalAlignment.Left);
            ListViewReadJ1587Data.Columns.Add("Buffer Size", 80, HorizontalAlignment.Left);

            bJ1587Pooling = true;
            bJ1587StartReadData = false;
            bJ1587ThreadActive = true;

            GetJ1587DataEvent = System_API.CreateEvent((IntPtr)null, false, false, null);

            thGetJ1587DataThread = new Thread(GetJ1587DataThread);
            unsafe
            {
                fixed (void* pEvent = &GetJ1587DataEvent)
                {
                    J1587_API.J1587_SetEvent(pEvent);
                }
            }
            thGetJ1587DataThread.IsBackground = true;
            thGetJ1587DataThread.Start();

            /* OBD2 */

            trBrOBD2Read.Value = 1;
            RdBtnOBD2Polling.Checked = true;

            CmbxWriteOBD2DataChannel.SelectedIndex = 0;
            CmbxWriteOBD2DataTAT.SelectedIndex = 0;
            CmbxWriteOBD2FilterChannel.SelectedIndex = 0;

            bOBD2Pooling = true;
            bOBD2StartReadData = false;
            bOBD2ThreadActive = true;

            ListViewReadOBD2Data.Columns.Add("Channel", 66, HorizontalAlignment.Left);            
            ListViewReadOBD2Data.Columns.Add("DST", 50, HorizontalAlignment.Left);
            ListViewReadOBD2Data.Columns.Add("SRC", 50, HorizontalAlignment.Left);
            ListViewReadOBD2Data.Columns.Add("PRI", 50, HorizontalAlignment.Left);
            ListViewReadOBD2Data.Columns.Add("TAT", 50, HorizontalAlignment.Left);
            ListViewReadOBD2Data.Columns.Add("Buffer Size", 90, HorizontalAlignment.Left);
            ListViewReadOBD2Data.Columns.Add("Buffer (HEX)", 150, HorizontalAlignment.Left);

            GetOBD2DataEvent = System_API.CreateEvent((IntPtr)null, false, false, null);
            thGetOBD2DataThread = new Thread(GetOBD2DataThread);
            unsafe
            {
                fixed (void* pEvent = &GetOBD2DataEvent)
                {
                    OBD2_API.OBD2_SetEvent(pEvent);
                }
            }
            thGetOBD2DataThread.IsBackground = true;
            thGetOBD2DataThread.Start();
        }

        private void VCIL_Closed(object sender, EventArgs e)
        {
            ushort LastErrCode;
            
            bCANThreadActive = false;
            bJ1708ThreadActive = false;
            bJ1939ThreadActive = false;
            bJ1587ThreadActive = false;
            bOBD2ThreadActive = false;

            System_API.SetEvent(GetCANDataEvent);
            System_API.SetEvent(GetJ1708DataEvent);
            System_API.SetEvent(GetJ1939DataEvent);
            System_API.SetEvent(GetJ1587DataEvent);
            System_API.SetEvent(GetOBD2DataEvent);
            
            LastErrCode = VCIL.VCIL_API.VCIL_Deinitialize();

            if (LastErrCode != VCIL.IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Deinit fail");
            }

            System_API.CloseHandle(GetCANDataEvent);
            //thGetCANDataThread.Abort();
            System_API.CloseHandle(GetJ1708DataEvent);
            //thGetJ1708DataThread.Abort();
            System_API.CloseHandle(GetJ1939DataEvent);
            //thGetJ1939DataThread.Abort();
            System_API.CloseHandle(GetOBD2DataEvent);
            //thGetOBD2DataThread.Abort();
        }

        private void ReadDataBtn_Click(object sender, EventArgs e)
        {
            if (BtnReadCANData.Text == "Start")
            {
                BtnReadCANData.Text = "Stop";
                if (RdBtnCANPolling.Checked == true)
                {
                    ReadCanDataTimer.Interval = 100;
                    ReadCanDataTimer.Enabled = true;
                }
                RdBtnCANPolling.Enabled = false;
                RdBtnCANEvent.Enabled = false;
                bCANStartReadData = true;

            }
            else
            {
                BtnReadCANData.Text = "Start";
                if (RdBtnCANPolling.Checked == true)
                {                    
                    ReadCanDataTimer.Enabled = false;
                }

                RdBtnCANPolling.Enabled = true;
                RdBtnCANEvent.Enabled = true;
                bCANStartReadData = false;
            }
        }

        private void ReadCanDataTimer_Tick(object sender, EventArgs e)
        {
            ShowCanData();
        }

        private void WriteDataBtn_Click(object sender, EventArgs e)
        {
            CAN_API.IMC_CAN_MSG_OBJECT msg_object = new CAN_API.IMC_CAN_MSG_OBJECT();
            msg_object.buf_len = Convert.ToByte(EditWriteDataBufSize.Text);
            if (msg_object.buf_len != 0)
            {
                msg_object.can_bus_number = (uint) (CmbxWriteCANDataChannel.SelectedIndex + 1);
                
                msg_object.id = ConvertString2UINT(EditWriteDataMsgID.Text);

                if (CmbxWriteCANDataMessageType.SelectedIndex == 0)
                {
                    msg_object.message_type = CAN_API.CAN_MESSAGE_STANDARD;
                }
                else
                {
                    msg_object.message_type = CAN_API.CAN_MESSAGE_EXTENDED;
                }

                string strBufData = EditWriteDataBuf.Text;
                unsafe
                {
                    int nLen = msg_object.buf_len * 2;

                    if (strBufData.Length != nLen)
                    {
                        MessageBox.Show("Data length was error!", LastErrCode.ToString());
                        return;
                    }

                    for (int x = 0, i = 0; i < nLen; i += 2, x += 1)
                    {
                        msg_object.buf[x] = (byte)(iHexValue[Char.ToUpper(strBufData[i + 0]) - '0'] << 4 | iHexValue[Char.ToUpper(strBufData[i + 1]) - '0']);
                    }
                }
            }

            LastErrCode = CAN_API.CAN_Write(ref msg_object);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {

                MessageBox.Show("Fails to write data", LastErrCode.ToString());
                return;
            }
            else
            {
                MessageBox.Show("Write CAN Data Successfully", "Warning");
            }
        }

        private void SetMaskBtn_Click(object sender, EventArgs e)
        {
            CAN_API.IMC_CAN_MASK_OBJECT object_mask = new CAN_API.IMC_CAN_MASK_OBJECT();

            object_mask.can_bus_number = CmbxCANMaskChannelNumber.SelectedIndex + 1;
            object_mask.mask_number = CmbxCANMaskNumber.SelectedIndex;
            object_mask.message_type = CmbxMsgType.SelectedIndex + 1;
            object_mask.id = Convert.ToUInt32(MaskIDTxt.Text, 16);
            object_mask.mask = Convert.ToUInt32(MaskConTxt.Text, 16);
            LastErrCode = VCIL.CAN_API.CAN_SetMessageMask(ref object_mask);
            if (LastErrCode != IMC_ERR_NO_ERROR)
            {

                MessageBox.Show("Fails to set message mask", LastErrCode.ToString());
                return;
            }
        }

        private void RemoveMaskBtn_Click(object sender, EventArgs e)
        {
            CAN_API.CAN_RemoveMessageMask(1, CmbxCANMaskNumber.SelectedIndex);
        }

        private void ResetModuleBtn_Click(object sender, EventArgs e)
        {
            VCIL_API.VCIL_ResetModule();
        }

        private void GetMaskBtn_Click(object sender, EventArgs e)
        {
            unsafe
            {
                CAN_API.IMC_CAN_MASK_OBJECT object_mask = new CAN_API.IMC_CAN_MASK_OBJECT();
                CAN_API.IMC_CAN_MASK_OBJECT* pobject_mask = &object_mask;
                object_mask.can_bus_number = CmbxCANMaskChannelNumber.SelectedIndex + 1;
                object_mask.mask_number = CmbxCANMaskNumber.SelectedIndex;

                LastErrCode = CAN_API.CAN_GetMessageMask(pobject_mask);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {

                    MessageBox.Show("Fails to get message mask", LastErrCode.ToString());
                    return;
                }

                MaskIDTxt.Text = Convert.ToString(object_mask.id,16);
                MaskConTxt.Text = Convert.ToString(object_mask.mask,16);
            }
        }

        private void PollingRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (RdBtnCANPolling.Checked == true)
            {
                bCANPooling = true;
            }
            else
            {
                bCANPooling = false;
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

        // Convert a string into a uint type value
        private uint ConvertString2UINT(string strNum)
        {
            uint nMsgIDHex = 0x0;
            if (strNum.Length % 2 != 0)
                strNum = "0" + strNum;
            unsafe
            {
                int nLen = strNum.Length;
                for (int i = 0; i < nLen; i += 2)
                {
                    nMsgIDHex <<= 8;
                    nMsgIDHex |= (byte)(iHexValue[Char.ToUpper(strNum[i + 0]) - '0'] << 4 | iHexValue[Char.ToUpper(strNum[i + 1]) - '0']);
                }
            }
            return nMsgIDHex;
        }

        private void ReadJ1708DataBtn_Click(object sender, EventArgs e)
        {
            if (ReadJ1708DataBtn.Text == "Start")
            {
                ReadJ1708DataBtn.Text = "Stop";
                if (J1708PollingRdBtn.Checked == true)
                {
                    ReadJ1708DataTimer.Interval = 100;
                    ReadJ1708DataTimer.Enabled = true;
                }
                J1708PollingRdBtn.Enabled = false;
                J1708EventRdBtn.Enabled = false;
                bJ1708StartReadData = true;

            }
            else
            {
                ReadJ1708DataBtn.Text = "Start";
                if (J1708PollingRdBtn.Checked == true)
                {
                    ReadJ1708DataTimer.Enabled = false;
                }

                J1708PollingRdBtn.Enabled = true;
                J1708EventRdBtn.Enabled = true;
                bJ1708StartReadData = false;
            }
        }

        private void ReadJ1708DataTimer_Tick(object sender, EventArgs e)
        {
            ShowJ1708Data();
        }

        private void J1708PollingRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (J1708PollingRdBtn.Checked == true)
            {
                bJ1708Pooling = true;
            }
            else
            {
                bJ1708Pooling = false;
            }
        }

         private void WriteJ1708DataBtn_Click(object sender, EventArgs e)
        {
            J1708_API.IMC_J1708_MSG_OBJECT msg_object = new J1708_API.IMC_J1708_MSG_OBJECT();
            msg_object.buf_len = Convert.ToByte(EditWriteJ1708DataBufSize.Text);
            if ((msg_object.buf_len != 0) && (msg_object.buf_len <= J1708_API.IMC_MAX_J1708_MSG_BUFFER_SIZE))
            {
                msg_object.mid = ConvertString2UINT(EditWriteJ1708DataMID.Text);

                msg_object.pid = ConvertString2UINT(EditWriteJ1708DataPID.Text);

                msg_object.pri = (byte) ConvertString2UINT(EditWriteJ1708DataPriority.Text);

                string strBufData = EditWriteJ1708DataBuf.Text;
                unsafe
                {
                    int nLen = msg_object.buf_len * 2;

                    if (strBufData.Length != nLen)
                    {
                        MessageBox.Show("J1708 Data length was error!", LastErrCode.ToString());
                        return;
                    }

                    for (int x = 0, i = 0; i < nLen; i += 2, x += 1)
                    {
                        msg_object.buf[x] = (byte)(iHexValue[Char.ToUpper(strBufData[i + 0]) - '0'] << 4 | iHexValue[Char.ToUpper(strBufData[i + 1]) - '0']);
                    }
                }

                LastErrCode = J1708_API.J1708_Write(ref msg_object);
                if (LastErrCode != IMC_ERR_NO_ERROR)
                {

                    MessageBox.Show("Fails to write J1708 data", LastErrCode.ToString());
                    return;
                }
                else
                {
                    MessageBox.Show("Write J1708 Data Successfully", "Warning");
                }
            }
            else
            {
                MessageBox.Show("Invild buffer size.", "Warning");
            }
        }

         private void SetJ1708FilterBtn_Click(object sender, EventArgs e)
         {
             LastErrCode = J1708_API.J1708_AddMessageFilter( Convert.ToUInt32(EditJ1708FilterMid.Text, 16) );
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to add J1708 filter", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListViewJ1708Filter.Items.Add(EditJ1708FilterMid.Text);
             }
         }

         private void RemoveJ1708FilterBtn_Click(object sender, EventArgs e)
         {
             if (ListViewJ1708Filter.Items.Count <= 0)
             {
                 MessageBox.Show("Filter box was empty!", LastErrCode.ToString());
                 return;
             }
             if (ListViewJ1708Filter.SelectedIndex < 0)
             {
                 MessageBox.Show("No filter is selected.!", LastErrCode.ToString());
                 return;
             }
             LastErrCode = J1708_API.J1708_RemoveMessageFilter(Convert.ToUInt32(ListViewJ1708Filter.SelectedItem.ToString(), 16));
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {

                 MessageBox.Show("Fails to remove J1708 filter", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListViewJ1708Filter.Items.RemoveAt(ListViewJ1708Filter.SelectedIndex);
             }
         }

         private void RemoveAllJ1708FilterBtn_Click(object sender, EventArgs e)
         {
             LastErrCode = J1708_API.J1708_RemoveAllMessageFilter();
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {

                 MessageBox.Show("Fails to remove All J1708 filters", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListViewJ1708Filter.Items.Clear();
             }
         }

         private void CleanAllCanMaskBtn_Click(object sender, EventArgs e)
         {
             CAN_API.CAN_ResetMessageMask(1);
             CAN_API.CAN_ResetMessageMask(2);
         }

         private void trBrModuleControl_ValueChanged(object sender, EventArgs e)
         {
             if ((cbBxModuleControlCANChannel01.SelectedIndex < 0) || (cbBxModuleControlCANChannel02.SelectedIndex < 0) || (cbBxModuleControlJ1708Channel.SelectedIndex) < 0)
                 return;

             LastErrCode = VCIL_API.VCIL_ModuleControl(cbBxModuleControlCANChannel01.SelectedIndex, cbBxModuleControlCANChannel02.SelectedIndex, cbBxModuleControlJ1708Channel.SelectedIndex);
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to set the module config", LastErrCode.ToString());
                 return;
             }
         }

         private void BtnWriteJ1939Data_Click(object sender, EventArgs e)
         {
             J1939_API.IMC_J1939_MSG_OBJECT msg_object = new J1939_API.IMC_J1939_MSG_OBJECT();
             msg_object.buf_len = Convert.ToUInt16(EditWriteJ1939BufSize.Text);
             if (msg_object.buf_len != 0)
             {
                 msg_object.channel_number = Convert.ToByte(CmbxWriteJ1939DataChannel.SelectedIndex + 1);

                 msg_object.pgn = ConvertString2UINT(EditWriteJ1939PGN.Text);

                 msg_object.dst = Convert.ToByte(ConvertString2UINT(EditWriteJ1939DST.Text));

                 msg_object.src = Convert.ToByte(ConvertString2UINT(EditWriteJ1939SRC.Text));

                 msg_object.pri = Convert.ToByte(ConvertString2UINT(EditWriteJ1939PRI.Text));
                     
                 string strBufData = EditWriteJ1939Buf.Text;
                 unsafe
                 {
                     int nLen = msg_object.buf_len * 2;

                     if (strBufData.Length != nLen)
                     {
                         MessageBox.Show("J1939 Data length was error!", LastErrCode.ToString());
                         return;
                     }

                     for (int x = 0, i = 0; i < nLen; i += 2, x += 1)
                     {
                         msg_object.buf[x] = (byte)(iHexValue[Char.ToUpper(strBufData[i + 0]) - '0'] << 4 | iHexValue[Char.ToUpper(strBufData[i + 1]) - '0']);
                     }
                 }

                 LastErrCode = J1939_API.J1939_Write(ref msg_object);
                 if (LastErrCode != IMC_ERR_NO_ERROR)
                 {

                     MessageBox.Show("Fails to write J1939 data", LastErrCode.ToString());
                     return;
                 }
                 else
                 {
                     MessageBox.Show("Write J1939 Data Successfully", "Warning");
                 }
             }
         }

         private void trBrJ1939Read_ValueChanged(object sender, EventArgs e)
         {
             if (trBrJ1939Read.Value == 0) /* on */
             {
                 if (RdBtnJ1939Polling.Checked == true)
                 {
                     ReadJ1939DataTimer.Interval = 100;
                     ReadJ1939DataTimer.Enabled = true;
                 }

                 RdBtnJ1939Polling.Enabled = false;
                 RdBtnJ1939Event.Enabled = false;
                 bJ1939StartReadData = true;
             }
             else /* off */
             {
                 ReadJ1939DataTimer.Enabled = false;
                 RdBtnJ1939Polling.Enabled = true;
                 RdBtnJ1939Event.Enabled = true;
                 bJ1939StartReadData = false;
             }
         }

         private void RdBtnJ1939Polling_CheckedChanged(object sender, EventArgs e)
         {

             bJ1939Pooling = RdBtnJ1939Polling.Checked;

         }

         private void ReadJ1939DataTimer_Tick(object sender, EventArgs e)
         {
             ShowJ1939Data();
         }

         private void BtnSetJ1939Filter_Click(object sender, EventArgs e)
         {
             LastErrCode = J1939_API.J1939_AddMessageFilter(Convert.ToByte(CmbxWriteJ1939FilterChannel.Text), Convert.ToUInt32(EditJ1939FilterPGN.Text, 16));
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to add J1939 filter", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListBxJ1939Filter.Items.Add(CmbxWriteJ1939FilterChannel.Text + "," + EditJ1939FilterPGN.Text);
             }
         }

         private void BtnRemoveJ1939Filter_Click(object sender, EventArgs e)
         {
             if (ListBxJ1939Filter.Items.Count <= 0)
             {
                 MessageBox.Show("Filter box was empty!", LastErrCode.ToString());
                 return;
             }
             if (ListBxJ1939Filter.SelectedIndex < 0)
             {
                 MessageBox.Show("No filter is selected.!", LastErrCode.ToString());
                 return;
             }
             string[] strFilter = ListBxJ1939Filter.SelectedItem.ToString().Split(new Char[] { ',' });
             LastErrCode = J1939_API.J1939_RemoveMessageFilter(Convert.ToByte(strFilter[0], 16), Convert.ToUInt32(strFilter[1], 16));
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to remove J1939 filter", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListBxJ1939Filter.Items.RemoveAt(ListBxJ1939Filter.SelectedIndex);
             }
         }

         private void ReadJ1708FilterBtn_Click(object sender, EventArgs e)
         {
             ListViewJ1708Filter.Items.Clear();
             
             unsafe
             {
                 uint total; uint* ptotal = &total;

                 /* First, get total number. */
                 LastErrCode = J1708_API.J1708_GetMessageFilter(ptotal, null);
                 if (LastErrCode != IMC_ERR_NO_ERROR)
                 {
                     MessageBox.Show("Fails to get J1708 total number of filter", LastErrCode.ToString());
                     return;
                 }

                 uint[] mid = new uint[total];
                 fixed (uint* pmid = mid)
                 {
                     LastErrCode = J1708_API.J1708_GetMessageFilter(ptotal, pmid);
                     if (LastErrCode != IMC_ERR_NO_ERROR)
                     {
                         MessageBox.Show("Fails to get J1708 filter", LastErrCode.ToString());
                         return;
                     }
                 }

                 for (uint i = 0; i < total; i++)
                 {
                     ListViewJ1708Filter.Items.Add(mid[i].ToString("X2"));
                 }
             }
         }

         private void BtnGetJ1939Filter_Click(object sender, EventArgs e)
         {
             ListBxJ1939Filter.Items.Clear();

             for (byte j1939_channel = 1; j1939_channel <= 2; j1939_channel++)
             {
                 unsafe
                 {
                     uint total; uint* ptotal = &total;

                     /* First, get total number. */
                     LastErrCode = J1939_API.J1939_GetMessageFilter(j1939_channel, ptotal, null);
                     if (LastErrCode != IMC_ERR_NO_ERROR)
                     {
                         MessageBox.Show("Fails to get J1939 total number of filter, chaneel = " + j1939_channel.ToString(), LastErrCode.ToString());
                         return;
                     }

                     uint[] pgn = new uint[total];
                     fixed (uint* ppgn = pgn)
                     {
                         LastErrCode = J1939_API.J1939_GetMessageFilter(j1939_channel, ptotal, ppgn);
                         if (LastErrCode != IMC_ERR_NO_ERROR)
                         {
                             MessageBox.Show("Fails to get J1939 filter, chaneel = " + j1939_channel.ToString(), LastErrCode.ToString());
                             return;
                         }
                     }

                     for (uint i = 0; i < total; i++)
                     {
                         ListBxJ1939Filter.Items.Add(j1939_channel.ToString() + "," + pgn[i].ToString("X2"));
                     }
                 }
             }
         }

         private void trBrJ1587Read_ValueChanged(object sender, EventArgs e)
         {
             if (trBrJ1587Read.Value == 0) /* on */
             {
                 if (J1587PollingRdBtn.Checked == true)
                 {
                     ReadJ1587DataTimer.Interval = 100;
                     ReadJ1587DataTimer.Enabled = true;
                 }

                 J1587PollingRdBtn.Enabled = false;
                 J1587EventRdBtn.Enabled = false;
                 bJ1587StartReadData = true;
             }
             else /* off */
             {
                 ReadJ1587DataTimer.Enabled = false;
                 J1587PollingRdBtn.Enabled = true;
                 J1587EventRdBtn.Enabled = true;
                 bJ1587StartReadData = false;
             }
         }

         private void J1587PollingRdBtn_CheckedChanged(object sender, EventArgs e)
         {
             if (J1587PollingRdBtn.Checked == true)
             {
                 bJ1587Pooling = true;
             }
             else
             {
                 bJ1587Pooling = false;
             }
         }

         private void WriteJ1587DataBtn_Click(object sender, EventArgs e)
         {
             J1587_API.IMC_J1587_MSG_OBJECT msg_object = new J1587_API.IMC_J1587_MSG_OBJECT();
             msg_object.buf_len = Convert.ToByte(EditWriteJ1587DataBufSize.Text);
             if ((msg_object.buf_len != 0) && (msg_object.buf_len <= J1708_API.IMC_MAX_J1708_MSG_BUFFER_SIZE))
             {
                 msg_object.mid = ConvertString2UINT(EditWriteJ1587DataMID.Text);

                 msg_object.pid = ConvertString2UINT(EditWriteJ1587DataPID.Text);

                 msg_object.pri = (byte)ConvertString2UINT(EditWriteJ1587DataPriority.Text);

                 string strBufData = EditWriteJ1587DataBuf.Text;
                 unsafe
                 {
                     int nLen = msg_object.buf_len * 2;

                     if (strBufData.Length != nLen)
                     {
                         MessageBox.Show("J1587 Data length was error!", LastErrCode.ToString());
                         return;
                     }

                     for (int x = 0, i = 0; i < nLen; i += 2, x += 1)
                     {
                         msg_object.buf[x] = (byte)(iHexValue[Char.ToUpper(strBufData[i + 0]) - '0'] << 4 | iHexValue[Char.ToUpper(strBufData[i + 1]) - '0']);
                     }
                 }

                 LastErrCode = J1587_API.J1587_Write(ref msg_object);
                 if (LastErrCode != IMC_ERR_NO_ERROR)
                 {

                     MessageBox.Show("Fails to write J1587 data", LastErrCode.ToString());
                     return;
                 }
                 else
                 {
                     MessageBox.Show("Write J1587 Data Successfully", "Warning");
                 }
             }
             else
             {
                 MessageBox.Show("Invild buffer size.", "Warning");
             }
         }

         private void SetJ1587FilterBtn_Click(object sender, EventArgs e)
         {
             LastErrCode = J1587_API.J1587_AddMessageFilter(Convert.ToUInt32(EditJ1587FilterMid.Text, 16));
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to add J1587 filter", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListViewJ1587Filter.Items.Add(EditJ1587FilterMid.Text);
             }
         }

         private void RemoveAllJ1587FilterBtn_Click(object sender, EventArgs e)
         {
             LastErrCode = J1587_API.J1587_RemoveAllMessageFilter();
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {

                 MessageBox.Show("Fails to remove All J1587 filters", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListViewJ1587Filter.Items.Clear();
             }
         }

         private void RemoveJ1587FilterBtn_Click(object sender, EventArgs e)
         {
             if (ListViewJ1587Filter.Items.Count <= 0)
             {
                 MessageBox.Show("Filter box was empty!", LastErrCode.ToString());
                 return;
             }
             if (ListViewJ1587Filter.SelectedIndex < 0)
             {
                 MessageBox.Show("No filter is selected.!", LastErrCode.ToString());
                 return;
             }
             LastErrCode = J1587_API.J1587_RemoveMessageFilter(Convert.ToUInt32(ListViewJ1587Filter.SelectedItem.ToString(), 16));
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {

                 MessageBox.Show("Fails to remove J1587 filter", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListViewJ1587Filter.Items.RemoveAt(ListViewJ1587Filter.SelectedIndex);
             }
         }

         private void ReadJ1587FilterBtn_Click(object sender, EventArgs e)
         {
             ListViewJ1587Filter.Items.Clear();

             unsafe
             {
                 uint total; uint* ptotal = &total;

                 /* First, get total number. */
                 LastErrCode = J1587_API.J1587_GetMessageFilter(ptotal, null);
                 if (LastErrCode != IMC_ERR_NO_ERROR)
                 {
                     MessageBox.Show("Fails to get J1587 total number of filter", LastErrCode.ToString());
                     return;
                 }

                 uint[] mid = new uint[total];
                 fixed (uint* pmid = mid)
                 {
                     LastErrCode = J1587_API.J1587_GetMessageFilter(ptotal, pmid);
                     if (LastErrCode != IMC_ERR_NO_ERROR)
                     {
                         MessageBox.Show("Fails to get J1587 filter", LastErrCode.ToString());
                         return;
                     }
                 }

                 for (uint i = 0; i < total; i++)
                 {
                     ListViewJ1587Filter.Items.Add(mid[i].ToString("X2"));
                 }
             }
         }

         private void ReadJ1587DataTimer_Tick(object sender, EventArgs e)
         {
             ShowJ1587Data();
         }

         private void BtnRemoveAllJ1939Filter_Click(object sender, EventArgs e)
         {
             LastErrCode = J1939_API.J1939_RemoveAllMessageFilter(byte.Parse(CmbxWriteJ1939FilterChannel.Text));
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to remove all  J1939 filters!", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListBxJ1939Filter.Items.Clear();
             }
         }

         private void BtnGetJ1939TransmitConfig_Click(object sender, EventArgs e)
         {
             J1939_API.IMC_J1939_TRANSMIT_CONFIG transmit_config = new J1939_API.IMC_J1939_TRANSMIT_CONFIG();
             transmit_config.channel_number = byte.Parse(cmbxJ1939TransmitConfigChannel.Text);
             LastErrCode = J1939_API.J1939_GetTransmitConfig(out transmit_config);
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to get J1939 transmit configuration!", LastErrCode.ToString());
                 return;
             }

             EditJ1939TransmitConfigAddress.Text = transmit_config.source_address.ToString();
             
             string strBufData = string.Empty;
             StringBuilder strBufDataBuilder = new StringBuilder();
             try
             {
                 unsafe
                 {
                     byte* pBuf = transmit_config.source_name;
                     {
                         for (int j = 0; j < 8; j++)
                         {
                             strBufDataBuilder.Append(pBuf[j].ToString("X2"));
                         }
                     }
                 }
             }
             catch (System.Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error");
                 return;
             }

             EditJ1939TransmitConfigName.Text = strBufDataBuilder.ToString();
         }

         private void BtnSetJ1939TransmitConfig_Click(object sender, EventArgs e)
         {
             J1939_API.IMC_J1939_TRANSMIT_CONFIG transmit_config = new J1939_API.IMC_J1939_TRANSMIT_CONFIG();
             transmit_config.channel_number = byte.Parse(cmbxJ1939TransmitConfigChannel.Text);
             transmit_config.source_address = byte.Parse(EditJ1939TransmitConfigAddress.Text);

             string strBufData = EditJ1939TransmitConfigName.Text;
             unsafe
             {
                 int nLen = 8 * 2;

                 if (strBufData.Length != nLen)
                 {
                     MessageBox.Show("J1939 source name was error!", LastErrCode.ToString());
                     return;
                 }

                 for (int x = 0, i = 0; i < nLen; i += 2, x += 1)
                 {
                     transmit_config.source_name[x] = (byte)(iHexValue[Char.ToUpper(strBufData[i + 0]) - '0'] << 4 | iHexValue[Char.ToUpper(strBufData[i + 1]) - '0']);
                 }
             }

             LastErrCode = J1939_API.J1939_SetTransmitConfig(transmit_config);
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to get J1939 transmit configuration!", LastErrCode.ToString());
                 return;
             }
         }

         private void ReadOBD2DataTimer_Tick(object sender, EventArgs e)
         {
             ShowOBD2Data();
         }

         private void BtnWriteOBD2Data_Click(object sender, EventArgs e)
         {
             OBD2_API.IMC_OBD2_MSG_OBJECT msg_object = new OBD2_API.IMC_OBD2_MSG_OBJECT();
             msg_object.buf_len = Convert.ToUInt16(EditWriteOBD2BufSize.Text);
             if (msg_object.buf_len != 0)
             {
                 msg_object.channel_number = Convert.ToByte(CmbxWriteOBD2DataChannel.SelectedIndex + 1);                 

                 msg_object.dst = Convert.ToByte(ConvertString2UINT(EditWriteOBD2DST.Text));

                 msg_object.src = Convert.ToByte(ConvertString2UINT(EditWriteOBD2SRC.Text));

                 msg_object.pri = Convert.ToByte(ConvertString2UINT(EditWriteOBD2PRI.Text));

                 msg_object.tat = (byte)(CmbxWriteOBD2DataTAT.SelectedIndex == 0 ? 218 : 219);

                 string strBufData = EditWriteOBD2Buf.Text;
                 unsafe
                 {
                     int nLen = msg_object.buf_len * 2;

                     if (strBufData.Length != nLen)
                     {
                         MessageBox.Show("OBD2 Data length was error!", LastErrCode.ToString());
                         return;
                     }

                     for (int x = 0, i = 0; i < nLen; i += 2, x += 1)
                     {
                         msg_object.buf[x] = (byte)(iHexValue[Char.ToUpper(strBufData[i + 0]) - '0'] << 4 | iHexValue[Char.ToUpper(strBufData[i + 1]) - '0']);
                     }
                 }

                 LastErrCode = OBD2_API.OBD2_Write(ref msg_object);
                 if (LastErrCode != IMC_ERR_NO_ERROR)
                 {

                     MessageBox.Show("Fails to write OBD2 data", LastErrCode.ToString());
                     return;
                 }
                 else
                 {
                     MessageBox.Show("Write OBD2 Data Successfully", "Warning");
                 }
             }
         }

         private void BtnSetOBD2Filter_Click(object sender, EventArgs e)
         {
             LastErrCode = OBD2_API.OBD2_AddMessageFilter(Convert.ToByte(CmbxWriteOBD2FilterChannel.Text), Convert.ToUInt32(EditOBD2FilterPGN.Text, 16));
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to add OBD2 filter", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListBxOBD2Filter.Items.Add(CmbxWriteOBD2FilterChannel.Text + "," + EditOBD2FilterPGN.Text);
                 
             }
         }

         private void BtnRemoveOBD2Filter_Click(object sender, EventArgs e)
         {
             if (ListBxOBD2Filter.Items.Count <= 0)
             {
                 MessageBox.Show("Filter box was empty!", LastErrCode.ToString());
                 return;
             }
             if (ListBxOBD2Filter.SelectedIndex < 0)
             {
                 MessageBox.Show("No filter is selected.!", LastErrCode.ToString());
                 return;
             }
             string[] strFilter = ListBxOBD2Filter.SelectedItem.ToString().Split(new Char[] { ',' });
             LastErrCode = OBD2_API.OBD2_RemoveMessageFilter(Convert.ToByte(strFilter[0], 16), Convert.ToUInt32(strFilter[1], 16));
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to remove OBD2 filter", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListBxOBD2Filter.Items.RemoveAt(ListBxOBD2Filter.SelectedIndex);
             }
         }

         private void BtnRemoveAllOBD2Filter_Click(object sender, EventArgs e)
         {
             LastErrCode = OBD2_API.OBD2_RemoveAllMessageFilter(byte.Parse(CmbxWriteOBD2FilterChannel.Text));
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to remove all  OBD2 filters!", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListBxOBD2Filter.Items.Clear();
             }
         }

         private void BtnGetOBD2Filter_Click(object sender, EventArgs e)
         {
             ListBxOBD2Filter.Items.Clear();

             byte obd2_channel = (byte) (CmbxWriteOBD2FilterChannel.SelectedIndex + 1);

             unsafe
             {
                 uint total; uint* ptotal = &total;

                 /* First, get total number. */
                 LastErrCode = OBD2_API.OBD2_GetMessageFilter(obd2_channel, ptotal, null);
                 if (LastErrCode != IMC_ERR_NO_ERROR)
                 {
                     MessageBox.Show("Fails to get OBD2 total number of filter, chaneel = " + obd2_channel.ToString(), LastErrCode.ToString());
                     return;
                 }

                 uint[] pid = new uint[total];
                 fixed (uint* ppid = pid)
                 {
                     LastErrCode = OBD2_API.OBD2_GetMessageFilter(obd2_channel, ptotal, ppid);
                     if (LastErrCode != IMC_ERR_NO_ERROR)
                     {
                         MessageBox.Show("Fails to get OBD2 filter, chaneel = " + obd2_channel.ToString(), LastErrCode.ToString());
                         return;
                     }
                 }

                 for (uint i = 0; i < total; i++)
                 {
                     ListBxOBD2Filter.Items.Add(obd2_channel.ToString() + "," + pid[i].ToString("X2"));
                 }
             }

         }

         private void trBrOBD2Read_ValueChanged(object sender, EventArgs e)
         {
             if (trBrOBD2Read.Value == 0) /* on */
             {
                 if (RdBtnOBD2Polling.Checked == true)
                 {
                     ReadOBD2DataTimer.Interval = 100;
                     ReadOBD2DataTimer.Enabled = true;
                 }

                 RdBtnOBD2Polling.Enabled = false;
                 RdBtnOBD2Event.Enabled = false;
                 bOBD2StartReadData = true;
             }
             else /* off */
             {
                 ReadOBD2DataTimer.Enabled = false;
                 RdBtnOBD2Polling.Enabled = true;
                 RdBtnOBD2Event.Enabled = true;
                 bOBD2StartReadData = false;
             }
         }

         private void RdBtnOBD2Polling_CheckedChanged(object sender, EventArgs e)
         {
             if (RdBtnOBD2Polling.Checked == true)
             {
                 bOBD2Pooling = true;
             }
             else
             {
                 bOBD2Pooling = false;
             }
         }

         private void CmbxCanChannel01Speed_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (CmbxCanChannel01Speed.Text == "125 K")
             {
                 CAN_API.CAN_SetBitTiming(1, CAN_SPEED_125K);
             }
             else if (CmbxCanChannel01Speed.Text == "250 K")
             {
                 CAN_API.CAN_SetBitTiming(1, CAN_SPEED_250K);
             }
             else if (CmbxCanChannel01Speed.Text == "500 K")
             {
                 CAN_API.CAN_SetBitTiming(1, CAN_SPEED_500K);
             }
             else
             {
                 CAN_API.CAN_SetBitTiming(1, CAN_SPEED_1M);
             }
         }

         private void CmbxCanChannel02Speed_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (CmbxCanChannel02Speed.Text == "125 K")
             {
                 CAN_API.CAN_SetBitTiming(2, CAN_SPEED_125K);
             }
             else if (CmbxCanChannel02Speed.Text == "250 K")
             {
                 CAN_API.CAN_SetBitTiming(2, CAN_SPEED_250K);
             }
             else if (CmbxCanChannel02Speed.Text == "500 K")
             {
                 CAN_API.CAN_SetBitTiming(2, CAN_SPEED_500K);
             }
             else
             {
                 CAN_API.CAN_SetBitTiming(2, CAN_SPEED_1M);
             }
         }
    }
}
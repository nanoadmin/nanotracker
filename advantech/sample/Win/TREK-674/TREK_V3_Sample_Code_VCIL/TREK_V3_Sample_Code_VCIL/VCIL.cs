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
        public static UInt16 IMC_ERR_J1939_RX_NOT_READY = 0xC021;

        public bool vcil_sample_init_status = false;

        public const string strVCILDLLName = @"SUSI_IMC_VCIL.dll";

        public UInt16 LastErrCode;
        /* CAN Data*/
        public IntPtr GetCANDataEvent;
        public Thread thGetCANDataThread;
        private UInt32 CANMsgRecvCount = 0;

        public bool bCANPooling = false;
        public bool bCANStartReadData;
        public bool bCANThreadActive;
        public char port_number;
        private delegate void ShowCanDataFunction();

        /* J1708 Data*/
        public IntPtr GetJ1708DataEvent;
        public Thread thGetJ1708DataThread;
        private UInt32 j1708_recv_count = 0;

        public bool bJ1708Pooling;
        public bool bJ1708StartReadData;
        public bool bJ1708ThreadActive;
        private delegate void ShowJ1708DataFunction();

        /* J1939 Data*/
        public IntPtr GetJ1939DataEvent;
        public Thread thGetJ1939DataThread;
        private UInt32 j1939_recv_count = 0;

        public bool bJ1939Pooling;
        public bool bJ1939StartReadData;
        public bool bJ1939ThreadActive;
        private delegate void ShowJ1939DataFunction();

        /* J1587 Data*/
        public IntPtr GetJ1587DataEvent;
        public Thread thGetJ1587DataThread;
        private UInt32 j1587_recv_count = 0;

        public bool bJ1587Pooling;
        public bool bJ1587StartReadData;
        public bool bJ1587ThreadActive;
        private delegate void ShowJ1587DataFunction();

        /* OBD2 Data*/
        public IntPtr GetOBD2DataEvent;
        public Thread thGetOBD2DataThread;
        private UInt32 obd2_recv_count = 0;

        public bool bOBD2Pooling = false;
        public bool bOBD2StartReadData;
        public bool bOBD2ThreadActive;
        private delegate void ShowOBD2DataFunction();

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
                public int message_type;
                public UInt32 id;
                public UInt32 mask;	
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_CAN_ERROR_STATUS_OBJECT
            {
                public int rec; // receive error counter
	            public int tec; // transmit error counter
	            public int last_error_code; // last error code
	            public int error_flag;
            }

            public enum CAN_BUS_MODE
            {
                CAN_BUS_MODE_NORMAL = 0,
                CAN_BUS_MODE_SILENCE = 1,
                CAN_BUS_MODE_INIT = 2
            };

            public enum CAN_SPEED
            {
                CAN_SPEED_125K = 0,
                CAN_SPEED_250K = 1,
                CAN_SPEED_500K = 2,
                CAN_SPEED_1M = 3,
                CAN_SPEED_200K = 4,
                CAN_SPEED_100K = 5,
                CAN_SPEED_INIT = 0xFE,
                CAN_SPEED_USER_DEFINE = 0xFF
            };
                        
            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_SetMessageMask")]
            public unsafe static extern UInt16 CAN_SetMessageMask(ref IMC_CAN_MASK_OBJECT mask_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_GetMessageMask")]
            public unsafe static extern UInt16 CAN_GetMessageMask(IMC_CAN_MASK_OBJECT* mask_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_RemoveMessageMask")]
            public unsafe static extern UInt16 CAN_RemoveMessageMask(uint can_bus_number, int mask_id);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_ResetMessageMask")]
            public unsafe static extern UInt16 CAN_ResetMessageMask(UInt32 can_bus_number);
                        
            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_SetBitTiming")]
            public static extern UInt16 CAN_SetBitTiming(uint can_bus_number, CAN_SPEED bit_rate);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_GetBitTiming")]
            public static extern UInt16 CAN_GetBitTiming(uint can_bus_number, out CAN_SPEED bit_rate, out CAN_BUS_MODE mode);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_SetBitTimingSilence")]
            public static extern UInt16 CAN_SetBitTimingSilence(uint can_bus_number, CAN_SPEED bit_rate);
                        
            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_CAN_GetBusErrorStatus")]
            public unsafe static extern UInt16 CAN_GetBusErrorStatus(UInt32 can_bus_number, out IMC_CAN_ERROR_STATUS_OBJECT err_object);

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
            public unsafe static extern UInt16 J1587_AddMessageFilter(UInt32 pid);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1587_GetMessageFilter")]
            public unsafe static extern UInt16 J1587_GetMessageFilter(UInt32* total, UInt32* pid);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_J1587_RemoveMessageFilter")]
            public unsafe static extern UInt16 J1587_RemoveMessageFilter(UInt32 pid);

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

            [StructLayout(LayoutKind.Sequential)]
            public struct IMC_OBD2_MSG_EX_OBJECT
            {
                public byte channel_number;                
                public byte type; /* 0: 11-bits or  1:  29 bits */
                public UInt32 id; /* OBD2 15765-4 CAN ID */
                public ushort buf_len;
                public unsafe fixed byte buf[IMC_MAX_OBD2_MSG_BUFFER_SIZE];                
            };

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_OBD2_Read")]
            public static extern UInt16 OBD2_Read(out IMC_OBD2_MSG_OBJECT msg_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_OBD2_ReadEx")]
            public static extern UInt16 OBD2_ReadEx(out IMC_OBD2_MSG_EX_OBJECT msg_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_OBD2_Write")]
            public static extern UInt16 OBD2_Write(ref IMC_OBD2_MSG_OBJECT msg_object);

            [DllImport(strVCILDLLName, EntryPoint = "SUSI_IMC_OBD2_WriteEx")]
            public static extern UInt16 OBD2_WriteEx(ref IMC_OBD2_MSG_EX_OBJECT msg_object);

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
                    try
                    {
                        this.Invoke(sh);
                    }
                    catch
                    {
                        continue;
                    }
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
                    try
                    {
                        ShowJ1708DataFunction sh = new ShowJ1708DataFunction(ShowJ1708Data);
                        this.Invoke(sh);
                    }
                    catch
                    {
                        continue;
                    }

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
                    try
                    {
                        ShowJ1939DataFunction sh = new ShowJ1939DataFunction(ShowJ1939Data);
                        this.Invoke(sh);
                    }
                    catch
                    {
                        continue;
                    }
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
                    try
                    {
                        ShowJ1587DataFunction sh = new ShowJ1587DataFunction(ShowJ1587Data);
                        this.Invoke(sh);
                    }
                    catch
                    {
                        continue;
                    }
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
                    try
                    {
                        ShowOBD2DataFunction sh = new ShowOBD2DataFunction(ShowOBD2Data);
                        this.Invoke(sh);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        public void ShowCanData()
        {
            bool read_once = false;
            CAN_API.IMC_CAN_MSG_OBJECT msg_object = new CAN_API.IMC_CAN_MSG_OBJECT();

            while (true)
            {
                LastErrCode = CAN_API.CAN_Read(out msg_object);

                if (LastErrCode == IMC_ERR_CAN_RX_NOT_READY)
                    break;

                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("CAN_Read fail " + LastErrCode.ToString("X4"));
                    ReadCanDataTimer.Enabled = false;
                    BtnReadCANData.Text = "Stop";
                    break;
                }

                CANMsgRecvCount++;

                uint msg_channel_number = msg_object.can_bus_number;


                if (ChkBxShowCANData.Checked == true)
                {
                    string strBufData = string.Empty;
                    string strMsgID = msg_object.id.ToString("X2");

                    string strType = ((msg_object.message_type & 0x02) > 0) ? "EXT" : "STR";
                    if ((msg_object.message_type & 0x04) > 0)
                        strType += "RTR";
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
                    string[] arrData = { msg_channel_number.ToString(), strMsgID, strType, msg_object.buf_len.ToString(), strBufData };
                    ListViewItem item = new ListViewItem(arrData);

                    if (read_once == false)
                    {
                        ListViewReadCANData.BeginUpdate();
                        read_once = true;
                    }

                    if (ListViewReadCANData.Items.Count >= 100)
                        ListViewReadCANData.Items.RemoveAt(0);
                    ListViewReadCANData.Items.Add(item);
                }

                if (read_once)
                {
                    ListViewReadCANData.EnsureVisible(ListViewReadCANData.Items.Count - 1);
                    ListViewReadCANData.EndUpdate();
                    labelCANRecvCount.Text = CANMsgRecvCount.ToString();
                }
            }
        }

        public void ShowJ1708Data()
        {
            bool read_once = false;

            while(true)
            {
                J1708_API.IMC_J1708_MSG_OBJECT msg_object = new J1708_API.IMC_J1708_MSG_OBJECT();
                LastErrCode = J1708_API.J1708_Read(out msg_object);

                if(LastErrCode == IMC_ERR_CAN_RX_NOT_READY)
                    break;

                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to read J1708 data");
                    ReadJ1708DataTimer.Enabled = false;
                    ReadJ1708DataBtn.Text = "Stop";
                    break;
                }

                j1708_recv_count++;

                if (msg_object.buf_len >= 0)
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
                        string[] arrData = { strMsgID, msg_object.buf_len.ToString(), strBufData};
                        ListViewItem item = new ListViewItem(arrData);

                        if (read_once == false)
                        {
                            ListViewReadJ1708Data.BeginUpdate();
                            read_once = true;
                        }

                        if (ListViewReadJ1708Data.Items.Count >= 100)
                            ListViewReadJ1708Data.Items.RemoveAt(0);
                        ListViewReadJ1708Data.Items.Add(item);
                    }
                }
            }

            if(read_once)
            {
                ListViewReadJ1708Data.EnsureVisible(ListViewReadJ1708Data.Items.Count - 1);
                ListViewReadJ1708Data.EndUpdate();
                labelJ1708RecvCount.Text = j1708_recv_count.ToString();                
            }
        }

        public void ShowJ1939Data()
        {
            bool read_once = false;

            while (true)
            {
                J1939_API.IMC_J1939_MSG_OBJECT msg_object = new J1939_API.IMC_J1939_MSG_OBJECT();
                LastErrCode = J1939_API.J1939_Read(out msg_object);

                if (LastErrCode == IMC_ERR_J1939_RX_NOT_READY)
                    break;

                if (LastErrCode != IMC_ERR_NO_ERROR && LastErrCode != IMC_ERR_J1939_RX_NOT_READY)
                {
                    MessageBox.Show("Fails to read J1939 data");
                    ReadJ1939DataTimer.Enabled = false;
                    trBrJ1939Read.Value = 1; /* 1 is off */
                    break;
                }

                j1939_recv_count++;

                if (msg_object.buf_len >= 0)
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
                        string[] arrData = { strJ1939ChannelNumber, strJ1939PRI, strJ1939PGN, strJ1939DST, strJ1939SRC, msg_object.buf_len.ToString(), strBufData };
                        ListViewItem item = new ListViewItem(arrData);

                        if (read_once == false)
                        {
                            ListViewReadJ1939Data.BeginUpdate();
                            read_once = true;
                        }
                        if (ListViewReadJ1939Data.Items.Count >= 100)
                            ListViewReadJ1939Data.Items.RemoveAt(0);
                        ListViewReadJ1939Data.Items.Add(item);
                    }
                }
            }

            if (read_once)
            {
                ListViewReadJ1939Data.EnsureVisible(ListViewReadJ1939Data.Items.Count - 1);
                ListViewReadJ1939Data.EndUpdate();
                labelJ1939RecvCount.Text = j1939_recv_count.ToString();
            }
        }

        public void ShowJ1587Data()
        {
            bool read_once = false;

            while (true)
            {
                J1587_API.IMC_J1587_MSG_OBJECT msg_object = new J1587_API.IMC_J1587_MSG_OBJECT();
                LastErrCode = J1587_API.J1587_Read(out msg_object);

                if(LastErrCode == IMC_ERR_CAN_RX_NOT_READY)
                {
                    break;
                }

                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to read J1587 data");
                    ReadJ1587DataTimer.Enabled = false;
                    trBrJ1587Read.Value = 1; /* 1 is off */
                    break;
                }

                j1587_recv_count++;

                if (msg_object.buf_len >= 0)
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
                        string[] arrData = { strMsgID, strPID, msg_object.buf_len.ToString(), strBufData };
                        ListViewItem item = new ListViewItem(arrData);

                        if (read_once == false)
                        {
                            ListViewReadJ1587Data.BeginUpdate();
                            read_once = true;
                        }

                        if (ListViewReadJ1587Data.Items.Count >= 100)
                            ListViewReadJ1587Data.Items.RemoveAt(0);
                        ListViewReadJ1587Data.Items.Add(item);
                    }
                }
            }

            if (read_once)
            {
                ListViewReadJ1587Data.EnsureVisible(ListViewReadJ1587Data.Items.Count - 1);
                ListViewReadJ1587Data.EndUpdate();
                labelJ1587RecvCount.Text = j1587_recv_count.ToString();
            }
        }

        unsafe string show_pid_supported(int s, int base_value)
        {
            string desc = string.Empty;

	        for(int i=7;i>=0;i--)
	        {
		        if( ((s>>i)&0x01) == 0x01)
		        {
                    desc+= (base_value + (8 - i)).ToString("X2") +", ";
		        }
	        }

            return desc;
        }

        unsafe string OBD2_DataTranslation(byte *data, int size)
        {
            string desc = string.Empty;

            if (data[0] >= 0x41 && data[0] <= 0x49)
            {
                desc += "Service$" + (data[0] & 0xF).ToString();
                if (data[0] == 0x41)
                {
                    desc += " PID " + (data[1]).ToString("X2") + ">";


                    switch (data[1])
                    {
                        case 0:
                        case 32:
                        case 64:
                        case 96:
                        case 128:
                        case 160:
                        case 192:
                        case 224:
                            {
                                int start_pid = data[1];
                                desc += String.Format(" PID({0}-{1}) Support list:", start_pid + 1, start_pid + 20);
                                desc += show_pid_supported(data[2], start_pid);
                                desc += show_pid_supported(data[3], start_pid + 8);
                                desc += show_pid_supported(data[4], start_pid + 16);
                                desc += show_pid_supported(data[5], start_pid + 24);

                                char[] remove_chars = { ',', ' ' };
                                desc = desc.TrimEnd(remove_chars);
                            }
                            break;

                        case 5:
                            {
                                int etc = data[2] - 40;
                                desc += String.Format("ETC={0}°C", etc);                                                            }
                            break;

                        case 0x0C:
                            {
                                int rpm = (data[2] << 8 | data[3])/4;
                                desc += String.Format("Engine RPM={0} rpm", rpm);
                            }
                            break;

                        case 0x0D:
                            {
                                int speed = data[2];
                                desc += String.Format("Vehicle Speed ={0} km/h", speed);
                            }
                            break;

                        default:
                            break;
                    }
                }

                if (data[0] == 0x43)
                {
                    desc += " >";

                    int num_dtc = data[1];

                    if (num_dtc == 0)
                    {
                        desc += "no emission-related DTC stored";
                    }
                    else
                    {
                        desc += num_dtc.ToString();
                        desc += " of DTC=";
                        for (int i = 0; i < num_dtc; i++)
                        {
                            UInt16 dtc = (UInt16)((data[i * 2+2] << 8) | (data[i * 2 + 3]));

                            int system = dtc >> 14;
                            if (system == 0)
                                desc += "P";
                            else if (system == 1)
                                desc += "C";
                            else if (system == 2)
                                desc += "B";
                            else if (system == 3)
                                desc += "U";

                            int code_1 = (dtc >> 12) & 0x3;
                            int code_2 = (dtc >> 8) & 0xF;
                            int code_3 = (dtc >> 4) & 0xF;
                            int code_4 = dtc& 0xF;

                            desc += code_1.ToString("X1");
                            desc += code_2.ToString("X1");
                            desc += code_3.ToString("X1");
                            desc += code_4.ToString("X1")+",";
                        }

                        char[] remove_chars = { ',', ' ' };
                        desc = desc.TrimEnd(remove_chars);
                    }
                }

                if (data[0] == 0x49)
                {
                    if (data[1] == 0x02)
                    {
                        if (size >= 20)
                        {
                            byte[] vin_code = new byte[17];
                            for (int i = 0; i < 17; i++)
                                vin_code[i] = data[3+i];

                            string str_vin = System.Text.Encoding.ASCII.GetString(vin_code);

                            desc += "VIN=";
                            desc += str_vin;
                        }
                    }
                }
            }

            return desc;
        }

        public void ShowOBD2Data()
        {
            bool read_once = false;
            OBD2_API.IMC_OBD2_MSG_EX_OBJECT obd2_msg_object = new OBD2_API.IMC_OBD2_MSG_EX_OBJECT();

            while (true)
            {
                LastErrCode = OBD2_API.OBD2_ReadEx(out obd2_msg_object);

                if (LastErrCode == IMC_ERR_CAN_RX_NOT_READY)
                    break;

                if (LastErrCode != IMC_ERR_NO_ERROR && LastErrCode != IMC_ERR_CAN_RX_NOT_READY)
                {
                    MessageBox.Show("OBD2_ReadEx fails");
                    ReadOBD2DataTimer.Enabled = false;
                    trBrOBD2Read.Value = 1; /* 1 is off */
                    break;
                }

                obd2_recv_count++;

                if (obd2_msg_object.buf_len >= 0)
                {
                    
                    if (ChkBxShowOBD2Data.Checked == true)
                    {
                        string strBufData = string.Empty;
                        string desc = string.Empty;
                        StringBuilder strBufDataBuilder = new StringBuilder();
                        try
                        {
                            unsafe
                            {
                                byte* pBuf = obd2_msg_object.buf;
                                {
                                    for (int j = 0; j < obd2_msg_object.buf_len; j++)
                                    {
                                        strBufDataBuilder.Append(pBuf[j].ToString("X2") + " ");
                                    }

                                    desc = OBD2_DataTranslation(pBuf, obd2_msg_object.buf_len);
                                }
                            }
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                            return;
                        }

                        UInt32 dst = (obd2_msg_object.id >> 8 & 0xFF);
                        UInt32 src = (obd2_msg_object.id & 0xFF);
                        strBufData = strBufDataBuilder.ToString();

                        string[] item_string = { obd2_msg_object.channel_number.ToString(),
                                             (obd2_msg_object.type == 0) ? "STD" : "EXT",
                                             (obd2_msg_object.type == 0) ? obd2_msg_object.id.ToString("X3") : obd2_msg_object.id.ToString("X8"),
                                             (obd2_msg_object.type == 0 ? "" : dst.ToString("X2")),
                                             (obd2_msg_object.type == 0 ? "" : src.ToString("X2")),
                                             obd2_msg_object.buf_len.ToString(),
                                             strBufData, desc};
                        ListViewItem item = new ListViewItem(item_string);
                        if (dst == 0xF1)
                            item.BackColor = Color.LightBlue;

                        if (read_once == false)
                        {
                            ListViewReadOBD2Data.BeginUpdate();
                            read_once = true;
                        }

                        if (ListViewReadOBD2Data.Items.Count >= 100)
                            ListViewReadOBD2Data.Items.RemoveAt(0);
                        ListViewReadOBD2Data.Items.Add(item);
                    }
                }                
            }

            if (read_once)
            {
                ListViewReadOBD2Data.EnsureVisible(ListViewReadOBD2Data.Items.Count - 1);
                ListViewReadOBD2Data.EndUpdate();
                labelOBD2RecvCount.Text = obd2_recv_count.ToString();
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
                fixed (char* pComPort = &port_number)
                {
                    SpeedForm.GetPortNumber(pComPort);
                }
            }

            SpeedForm.ShowDialog();
            unsafe
            {
                fixed (char* p_port = &port_number)
                {

                LastErrCode = VCIL.VCIL_API.VCIL_Initialize(p_port);
                }

                if (LastErrCode != VCIL.IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("init fail = " + LastErrCode.ToString("X4"));
                    Environment.Exit(LastErrCode);
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

            CmbxCanBusSpeed.Text = "250 K";
            CmbxMsgType.SelectedIndex = 0;

            cbBxModuleControlCANChannel01.SelectedIndex = 0;
            cbBxModuleControlCANChannel02.SelectedIndex = 0;
            cbBxModuleControlJ1708Channel.SelectedIndex = 0;

            /* CAN */
            bCANStartReadData = false;
            bCANThreadActive = true;

            CmbxWriteCANDataMessageType.SelectedIndex = 1;  //  CAN 2.0B                       

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

            CmbxWriteOBD2DataTAT.SelectedIndex = 0;
            cbOBDTempService.SelectedIndex = 0;

            bOBD2StartReadData = false;
            bOBD2ThreadActive = true;

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

            vcil_sample_init_status = true;
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
            
            if (!vcil_sample_init_status)
                return;

            LastErrCode = VCIL.VCIL_API.VCIL_Deinitialize();

            if (LastErrCode != VCIL.IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Deinit fail");
            }

            System_API.CloseHandle(GetCANDataEvent);
            System_API.CloseHandle(GetJ1708DataEvent);
            System_API.CloseHandle(GetJ1939DataEvent);
            System_API.CloseHandle(GetJ1587DataEvent);
            System_API.CloseHandle(GetOBD2DataEvent);
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
                msg_object.can_bus_number = (UInt32)(rbCANPort1.Checked ? 1 : 2);
                
                msg_object.id = ConvertString2UINT(EditWriteDataMsgID.Text);

                if (CmbxWriteCANDataMessageType.SelectedIndex %2 == 0)
                {
                    msg_object.message_type = CAN_API.CAN_MESSAGE_STANDARD;
                }
                else
                {
                    msg_object.message_type = CAN_API.CAN_MESSAGE_EXTENDED;
                }

                if (CmbxWriteCANDataMessageType.SelectedIndex > 1)
                {
                    msg_object.message_type = msg_object.message_type | CAN_API.CAN_MESSAGE_RTR;
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

            object_mask.can_bus_number = (rbCANPort1.Checked ? 1 : 2);
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
            CAN_API.CAN_RemoveMessageMask((uint)(rbCANPort1.Checked ? 1 : 2), CmbxCANMaskNumber.SelectedIndex);
            MaskIDTxt.Text = "0";
            MaskConTxt.Text = "0";
        }

        private void ResetModuleBtn_Click(object sender, EventArgs e)
        {
            VCIL_API.VCIL_ResetModule();
        }

        private void SetCanBusSpeedBtn_Click(object sender, EventArgs e)
        {
            UInt32 port = (UInt32)(rbCANPort1.Checked ? 1 : 2);
            CAN_API.CAN_SPEED can_bitrate;
            bool silence_mode = CANSilenceModeEnable.Checked;

            switch (CmbxCanBusSpeed.SelectedIndex)
            {
                case 0:
                    can_bitrate = CAN_API.CAN_SPEED.CAN_SPEED_125K;
                    break;
                case 1:
                    can_bitrate = CAN_API.CAN_SPEED.CAN_SPEED_250K;
                    break;
                case 2:
                    can_bitrate = CAN_API.CAN_SPEED.CAN_SPEED_500K;
                    break;
                case 3:
                    can_bitrate = CAN_API.CAN_SPEED.CAN_SPEED_1M;
                    break;
                case 4:
                    can_bitrate = CAN_API.CAN_SPEED.CAN_SPEED_200K;
                    break;
                case 5:
                    can_bitrate = CAN_API.CAN_SPEED.CAN_SPEED_100K;
                    break;
                default:
                    can_bitrate = CAN_API.CAN_SPEED.CAN_SPEED_250K;
                    break;
            }

            if( !silence_mode)
                CAN_API.CAN_SetBitTiming(port, can_bitrate);
            else
                CAN_API.CAN_SetBitTimingSilence(port, can_bitrate);
        }

        private void ShowCountChkBx_CheckStateChanged(object sender, EventArgs e)
        {
        }

        private void GetMaskBtn_Click(object sender, EventArgs e)
        {
            unsafe
            {
                CAN_API.IMC_CAN_MASK_OBJECT object_mask = new CAN_API.IMC_CAN_MASK_OBJECT();
                CAN_API.IMC_CAN_MASK_OBJECT* pobject_mask = &object_mask;
                object_mask.can_bus_number = (rbCANPort1.Checked ? 1 : 2);
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
                 msg_object.channel_number =  (byte)(rbJ1939Port1.Checked ? 1 : 2);

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
             LastErrCode = J1939_API.J1939_AddMessageFilter((byte)(rbJ1939Port1.Checked ? 1 : 2), Convert.ToUInt32(EditJ1939FilterPGN.Text, 16));
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to add J1939 filter", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListBxJ1939Filter.Items.Add((rbJ1939Port1.Checked ? 1 : 2).ToString()+"," + EditJ1939FilterPGN.Text);
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

             byte j1939_channel = (byte)(rbJ1939Port1.Checked ? 1 : 2);
             
             unsafe
             {
                 uint total; uint* ptotal = &total;

                 /* First, get total number. */
                 LastErrCode = J1939_API.J1939_GetMessageFilter(j1939_channel, ptotal, null);
                 if (LastErrCode != IMC_ERR_NO_ERROR)
                 {
                     MessageBox.Show("Fails to get J1939 total number of filter, channel = " + j1939_channel.ToString(), LastErrCode.ToString());
                     return;
                 }

                 uint[] pgn = new uint[total];
                 fixed (uint* ppgn = pgn)
                 {
                     LastErrCode = J1939_API.J1939_GetMessageFilter(j1939_channel, ptotal, ppgn);
                     if (LastErrCode != IMC_ERR_NO_ERROR)
                     {
                         MessageBox.Show("Fails to get J1939 filter, channel = " + j1939_channel.ToString(), LastErrCode.ToString());
                         return;
                     }
                 }

                 for (uint i = 0; i < total; i++)
                 {
                     ListBxJ1939Filter.Items.Add(j1939_channel.ToString() + "," + pgn[i].ToString("X2"));
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
             LastErrCode = J1587_API.J1587_AddMessageFilter(Convert.ToUInt32(EditJ1587FilterPid.Text, 16));
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to add J1587 filter", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListViewJ1587Filter.Items.Add(EditJ1587FilterPid.Text);
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
             LastErrCode = J1939_API.J1939_RemoveAllMessageFilter((byte)(rbJ1939Port1.Checked ? 1 : 2));
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
             transmit_config.channel_number = (byte)(rbJ1939Port1.Checked ? 1 : 2);
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
             transmit_config.channel_number = (byte)(rbJ1939Port1.Checked ? 1 : 2);
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
             OBD2_API.IMC_OBD2_MSG_EX_OBJECT msg_object = new OBD2_API.IMC_OBD2_MSG_EX_OBJECT();
             msg_object.buf_len = Convert.ToUInt16(EditWriteOBD2BufSize.Text);

             if (msg_object.buf_len != 0)
             {
                 msg_object.channel_number = (byte)(rbOBD2Port1.Checked ? 1 : 2 );
                 msg_object.type = (byte)(RDOBD11b.Checked ? 0 : 1);

                 try
                 {
                     msg_object.id = Convert.ToUInt32(EditWriteOBD2ID.Text, 16);
                 }
                 catch
                 {
                     MessageBox.Show("format error");
                     return;
                 }                 

                 string strBufData = EditWriteOBD2Buf.Text;
                 unsafe
                 {
                     int nLen = msg_object.buf_len * 2;

                     if (strBufData.Length != nLen)
                     {
                         MessageBox.Show("OBD2 Data length was error!");
                         return;
                     }

                     for (int x = 0, i = 0; i < nLen; i += 2, x += 1)
                     {
                         msg_object.buf[x] = (byte)(iHexValue[Char.ToUpper(strBufData[i + 0]) - '0'] << 4 | iHexValue[Char.ToUpper(strBufData[i + 1]) - '0']);
                     }
                 }

                 LastErrCode = OBD2_API.OBD2_WriteEx(ref msg_object);
                 if (LastErrCode != IMC_ERR_NO_ERROR)
                 {

                     MessageBox.Show("OBD2_WriteEx fail "+LastErrCode.ToString("X4"));
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
             LastErrCode = OBD2_API.OBD2_AddMessageFilter((byte)(rbOBD2Port1.Checked? 1: 2), Convert.ToUInt32(EditOBD2FilterPGN.Text, 16));
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to add OBD2 filter", LastErrCode.ToString());
                 return;
             }
             else
             {
                 ListBxOBD2Filter.Items.Add((rbOBD2Port1.Checked? 1: 2).ToString() + "," + EditOBD2FilterPGN.Text);
                 
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
             LastErrCode = OBD2_API.OBD2_RemoveAllMessageFilter((byte)(rbOBD2Port1.Checked ? 1 : 2));
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

             byte obd2_channel = (byte)(rbOBD2Port1.Checked ? 1 : 2);

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

         private void GetCanBusSpeedBtn_Click(object sender, EventArgs e)
         {
             UInt32 port = (UInt32)(rbCANPort1.Checked ? 1 : 2);
             CAN_API.CAN_SPEED bitrate;
             CAN_API.CAN_BUS_MODE mode;

             LastErrCode = CAN_API.CAN_GetBitTiming(port, out bitrate, out mode);
             if( LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to CAN_GetBitTiming = " + LastErrCode.ToString("X4"));
                 return;
             }

             switch (bitrate)
             {
                 case CAN_API.CAN_SPEED.CAN_SPEED_125K:
                     CmbxCanBusSpeed.SelectedIndex = 0;
                     break;
                 case CAN_API.CAN_SPEED.CAN_SPEED_250K:
                     CmbxCanBusSpeed.SelectedIndex = 1;
                     break;
                 case CAN_API.CAN_SPEED.CAN_SPEED_500K:
                     CmbxCanBusSpeed.SelectedIndex = 2;
                     break;
                 case CAN_API.CAN_SPEED.CAN_SPEED_1M:
                     CmbxCanBusSpeed.SelectedIndex = 3;
                     break;
                 case CAN_API.CAN_SPEED.CAN_SPEED_200K:
                     CmbxCanBusSpeed.SelectedIndex = 4;
                     break;
                 case CAN_API.CAN_SPEED.CAN_SPEED_100K:
                     CmbxCanBusSpeed.SelectedIndex = 5;
                     break;
                 case CAN_API.CAN_SPEED.CAN_SPEED_INIT:
                     MessageBox.Show("Bus-off in Initiation status");
                     break;
                 case CAN_API.CAN_SPEED.CAN_SPEED_USER_DEFINE:
                     MessageBox.Show("User define bitrate");
                     break;
                 default:
                     break;
             }

             switch (mode)
             {
                 case CAN_API.CAN_BUS_MODE.CAN_BUS_MODE_INIT:
                     MessageBox.Show("CAN Bus current not initialization");
                     CANSilenceModeEnable.Checked = false;
                     break;
                 case CAN_API.CAN_BUS_MODE.CAN_BUS_MODE_NORMAL:
                     CANSilenceModeEnable.Checked = false;
                     break;
                 case CAN_API.CAN_BUS_MODE.CAN_BUS_MODE_SILENCE:
                     CANSilenceModeEnable.Checked = true;
                     break;
             }
         }

         private void btnGetCANErrorStatus_Click(object sender, EventArgs e)
         {
             UInt32 port = (UInt32)(rbCANPort1.Checked ? 1 : 2);
             CAN_API.IMC_CAN_ERROR_STATUS_OBJECT obj;
             LastErrCode = CAN_API.CAN_GetBusErrorStatus(port, out obj);
             if (LastErrCode != IMC_ERR_NO_ERROR)
             {
                 MessageBox.Show("Fails to CAN_GetBusErrorStatus = " + LastErrCode.ToString("X4"));
                 return;
             }

             CANErrorStatusValue.Text = "REC="+obj.rec.ToString()+" TEC=" + obj.tec.ToString()+" LEC"+obj.last_error_code.ToString() +" F="+obj.error_flag.ToString("X2");
         }

         private void OBD2_FieldChanged(object sender, EventArgs e)
         {
             int pri, tat, dst, src;

             try
             {
                 pri = Convert.ToInt32(EditWriteOBD2PRI.Text, 16);
                 tat = CmbxWriteOBD2DataTAT.SelectedIndex == 0 ? 0xDB : 0xDA;
                 dst = Convert.ToInt32(EditWriteOBD2DST.Text, 16);
                 src = Convert.ToInt32(EditWriteOBD2SRC.Text, 16);
             }
             catch
             {
                 return;
             }

             int id = ((pri&0xF) << 26) | (tat << 16) | ((dst&0xFF) << 8 ) | (src&0xFF);

             EditWriteOBD2ID.Text = id.ToString("X8");
         }

         private void EditWriteOBD2Buf_TextChanged(object sender, EventArgs e)
         {
             EditWriteOBD2BufSize.Text = (EditWriteOBD2Buf.Text.Length / 2).ToString();
         }

         private void OBD2_TempValueChanged(object sender, EventArgs e)
         {
             int pid;
             try
             {
                 pid = Convert.ToInt32(tbOBDTempPID.Text, 16);                 
             }
             catch
             {
                 return;
             }

             EditWriteOBD2Buf.Text = (cbOBDTempService.SelectedIndex + 1).ToString("X2") + pid.ToString("X2");
         }

         private void textBox15_TextChanged(object sender, EventArgs e)
         {
             int reuqest_pgn;

             try
             {
                reuqest_pgn = Convert.ToInt32(tbRequestPGN.Text, 16);                 
             }
             catch
             {
                 return;
             }
             EditWriteJ1939DST.Text = "FF";
             EditWriteJ1939PGN.Text = "EA00";
             EditWriteJ1939Buf.Text = (reuqest_pgn & 0xFF).ToString("X2") + ((reuqest_pgn >> 8) & 0xFF).ToString("X2") +
                 ((reuqest_pgn >> 16) & 0xFF).ToString("X2") + "0000000000";
         }

         private void EditWriteJ1939Buf_TextChanged(object sender, EventArgs e)
         {
             EditWriteJ1939BufSize.Text = (EditWriteJ1939Buf.Text.Length / 2).ToString();
         }

         private void OBD2Bitrate_Click(object sender, EventArgs e)
         {
             UInt32 port = (UInt32)(rbOBD2Port1.Checked ? 1 : 2);
             CAN_API.CAN_SPEED can_bitrate;

             switch (cbOBD2Bitrate.SelectedIndex)
             {
                 case 0:
                     can_bitrate = CAN_API.CAN_SPEED.CAN_SPEED_125K;
                     break;
                 case 1:
                     can_bitrate = CAN_API.CAN_SPEED.CAN_SPEED_250K;
                     break;
                 case 2:
                     can_bitrate = CAN_API.CAN_SPEED.CAN_SPEED_500K;
                     break;
                 default:
                     can_bitrate = CAN_API.CAN_SPEED.CAN_SPEED_250K;
                     break;
             }

             CAN_API.CAN_SetBitTiming(port, can_bitrate);             
         }

         private void btCANMsgClear_Click(object sender, EventArgs e)
         {
             ListViewReadCANData.Items.Clear();
             CANMsgRecvCount = 0;
             labelCANRecvCount.Text = "0";
         }

         private void btJ1939MsgClear_Click(object sender, EventArgs e)
         {
             ListViewReadJ1939Data.Items.Clear();
             j1939_recv_count = 0;
             labelJ1939RecvCount.Text = "0";
         }

         private void btOBD2MsgClear_Click(object sender, EventArgs e)
         {
             ListViewReadOBD2Data.Items.Clear();
             obd2_recv_count = 0;
             labelOBD2RecvCount.Text = "0";
         }

         private void btJ1708MsgClear_Click(object sender, EventArgs e)
         {
             ListViewReadJ1708Data.Items.Clear();
             j1708_recv_count = 0;
             labelJ1708RecvCount.Text = "0";
         }

         private void btJ1587MsgClear_Click(object sender, EventArgs e)
         {
             ListViewReadJ1587Data.Items.Clear();
             j1587_recv_count = 0;
             labelJ1587RecvCount.Text = "0";
         }

         private void EditWriteDataBuf_TextChanged(object sender, EventArgs e)
         {
             EditWriteDataBufSize.Text = (EditWriteDataBuf.Text.Length / 2).ToString();
         }

         private void RDOBD11b_CheckedChanged(object sender, EventArgs e)
         {
             if (RDOBD11b.Checked)
             {
                 EditWriteOBD2ID.Text = "7DF";
                 CmbxWriteOBD2DataTAT.Enabled = false;
                 EditWriteOBD2DST.Enabled = false;
                 EditWriteOBD2SRC.Enabled = false;
                 EditWriteOBD2PRI.Enabled = false;
             }
             else
             {
                 EditWriteOBD2ID.Text = "18DB33F1";
                 CmbxWriteOBD2DataTAT.Enabled = true;
                 EditWriteOBD2DST.Enabled = true;
                 EditWriteOBD2SRC.Enabled = true;
                 EditWriteOBD2PRI.Enabled = true;
             }
         }
    }
}
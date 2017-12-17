using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;   // for using other APIs

namespace TREK_V3_Sample_Code_IIC
{
    public partial class IIC : Form
    {
        public const string strIICDLLName = @"SUSI_IMC_IIC.dll";

        public static UInt16 IMC_ERR_NO_ERROR = 0xC000;

        public static UInt16 IMC_ERR_IIC_STATUS_OK_PLATFORM_NOT_SUPPORT_ALL = 0xC0E0;
        public static UInt16 IMC_ERR_IIC_STATUS_OK_PLATFORM_ONLY_SUPPORT_PRIMARY = 0xC0E1;
        public static UInt16 IMC_ERR_IIC_STATUS_OK_PLATFORM_ONLY_SUPPORT_SMBUS = 0xC0E2;
        public static UInt16 IMC_ERR_IIC_STATUS_OK_PLATFORM_SUPPORT = 0xC0E3;

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

        public static bool HexStringToByteArray(string sTemp, ref byte[] baByte)
        {
            try
            {
                sTemp = sTemp.Trim();

                string[] saTemp = sTemp.Split(new char[] { ' ' });
                UInt32 dwLen = (UInt32)saTemp.Length;
                baByte = new byte[dwLen];

                for (int i = 0; i < dwLen; i++)
                {
                    if (saTemp[i].Length > 2)
                        return false;

                    baByte[i] = Convert.ToByte(saTemp[i], 16);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public class IIC_API
        {

            public static UInt16 IMC_LIB_VERSION_SIZE = 17;

            public enum BusType : uint
            {
                Primary = 1,
                SmbusIIC
            }

            public unsafe struct IMC_IIC_READ
            {
                public UInt32 IICType;
                public byte SlaveAddress;
                public byte* ReadBuf;
                public UInt32 ReadLen;
            };

            public unsafe struct IMC_IIC_WRITE
            {
                public UInt32 IICType;
                public byte SlaveAddress;
                public byte* WriteBuf;
                public UInt32 WriteLen;
            };

            public unsafe struct IMC_IIC_WRITE_READ_COMBINE
            {
                public UInt32 IICType;
                public byte SlaveAddress;
                public byte* WriteBuf;
                public UInt32 WriteLen;
                public byte* ReadBuf;
                public UInt32 ReadLen;
            };

            [DllImport(strIICDLLName, EntryPoint = "SUSI_IMC_IIC_GetLibVersion")]
            public static extern UInt16 IIC_GetLibVersion(byte[] pVersion);

            [DllImport(strIICDLLName, EntryPoint = "SUSI_IMC_IIC_Available")]
            public extern static UInt16 IIC_Available();

            [DllImport(strIICDLLName, EntryPoint = "SUSI_IMC_IIC_Read")]
            public extern static UInt16 IIC_Read(ref IMC_IIC_READ Parm);

            [DllImport(strIICDLLName, EntryPoint = "SUSI_IMC_IIC_Write")]
            public extern static UInt16 IIC_Write(ref IMC_IIC_WRITE Parm);

            [DllImport(strIICDLLName, EntryPoint = "SUSI_IMC_IIC_WriteReadCombine")]
            public extern static UInt16 IIC_WriteReadCombine(ref IMC_IIC_WRITE_READ_COMBINE Parm);

        }

        public IIC()
        {
            InitializeComponent();
        }

        private void IIC_Load(object sender, EventArgs e)
        {
            UInt16 LastErrCode = IIC_API.IIC_Available();
            if (LastErrCode == IMC_ERR_IIC_STATUS_OK_PLATFORM_SUPPORT)
            {
                IICPrimaryRdBtn.Enabled = true;
                IICSmbusIICRdBtn.Enabled = true;
                MessageBox.Show("IIC support all type!");
            }
            else if (LastErrCode == IMC_ERR_IIC_STATUS_OK_PLATFORM_ONLY_SUPPORT_PRIMARY)
            {
                IICPrimaryRdBtn.Enabled = true;
                IICSmbusIICRdBtn.Enabled = false;

                IICPrimaryRdBtn.Checked = true;

                MessageBox.Show("IIC only support primary mode!");
            }
            else if (LastErrCode == IMC_ERR_IIC_STATUS_OK_PLATFORM_ONLY_SUPPORT_SMBUS)
            {
                IICPrimaryRdBtn.Enabled = false;
                IICSmbusIICRdBtn.Enabled = true;

                IICSmbusIICRdBtn.Checked = true;

                MessageBox.Show("IIC only support SMBus mode!");
            }
            else if (LastErrCode == IMC_ERR_IIC_STATUS_OK_PLATFORM_NOT_SUPPORT_ALL)
            {
                IICPrimaryRdBtn.Enabled = false;
                IICSmbusIICRdBtn.Enabled = false;

                IICPrimaryRdBtn.Checked = false;
                IICSmbusIICRdBtn.Checked = false;

                MessageBox.Show("IIC not support any type!");

            }
            else
            {
                IICPrimaryRdBtn.Enabled = false;
                IICSmbusIICRdBtn.Enabled = false;

                IICPrimaryRdBtn.Checked = false;
                IICSmbusIICRdBtn.Checked = false;

                MessageBox.Show("Fails to init IIC!");
            }

            byte[] byIICLibVersion = new byte[IIC_API.IMC_LIB_VERSION_SIZE];
            LastErrCode = IIC_API.IIC_GetLibVersion(byIICLibVersion);

            if (LastErrCode != IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get library version");
                return;
            }

            int nIICRealSize;
            IICStaticLibVersionValue.Text = ConvertByte2String(byIICLibVersion, byIICLibVersion.Length, out nIICRealSize);
        }

        private void IICReadBtn_Click(object sender, EventArgs e)
        {
            if ((IICSlaveAddressTextBox.Text == "") || (IICReadNumTextBox.Text == ""))
            {
                MessageBox.Show("Invalid Value !!!");
                return;
            }
            
            if ((Convert.ToInt16(IICSlaveAddressTextBox.Text, 16) < 0) || (Convert.ToInt16(IICReadNumTextBox.Text) < 0))
            {
                MessageBox.Show("Invalid Value !!!");
                return;
            }
            
            byte SlaveAddr = Convert.ToByte(IICSlaveAddressTextBox.Text, 16);
            byte ReadNum = Convert.ToByte(IICReadNumTextBox.Text, 16);

            UInt16 LastErrCode;

            if (IICReadNumTextBox.Text == "")
            {
                MessageBox.Show("Please input Read number!");
                return;
            }

            IIC_API.IMC_IIC_READ Parm_IICR = new IIC_API.IMC_IIC_READ();

            unsafe
            {
                if (IICPrimaryRdBtn.Checked == true)
                {
                    Parm_IICR.IICType = (uint)IIC_API.BusType.Primary;
                }
                else if (IICSmbusIICRdBtn.Checked == true)
                {
                    Parm_IICR.IICType = (uint)IIC_API.BusType.SmbusIIC;
                }
                else
                {
                    MessageBox.Show("IIC not support all type!");
                    return;
                }

                Parm_IICR.SlaveAddress = SlaveAddr;
                Parm_IICR.ReadLen = ReadNum;
                byte[] ResultIIC = new byte[ReadNum];

                fixed (byte* pResultIIC = ResultIIC)
                {
                    Parm_IICR.ReadBuf = pResultIIC;
                    LastErrCode = IIC_API.IIC_Read(ref Parm_IICR);
                }

                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("IMC_IIC_READ fail!");
                }
                else
                {

                    IICResultTextBox.Text = "";

                    string tempString = "";                    

                    for (int i = 0; i < ReadNum; i++)
                    {
                        tempString += Convert.ToString(ResultIIC[i], 16) + " ";
                    }

                    IICResultTextBox.Text = tempString;
                }
            }
        }

        private void IICWriteBtn_Click(object sender, EventArgs e)
        {
            if ((IICSlaveAddressTextBox.Text == "") || (IICWriteNumTextBox.Text == ""))
            {
                MessageBox.Show("Invalid Value !!!");
                return;
            }

            if ((Convert.ToInt16(IICSlaveAddressTextBox.Text, 16) < 0) || (Convert.ToInt16(IICWriteNumTextBox.Text) < 0))
            {
                MessageBox.Show("Invalid Value !!!");
                return;
            }

            byte SlaveAddr = Convert.ToByte(IICSlaveAddressTextBox.Text, 16);
            UInt32 WriteNum = Convert.ToUInt32(IICWriteNumTextBox.Text);
            UInt16 LastErrCode;

            IIC_API.IMC_IIC_WRITE Parm_IICW = new IIC_API.IMC_IIC_WRITE();

            unsafe
            {
                if (IICPrimaryRdBtn.Checked == true)
                {
                    Parm_IICW.IICType = (uint)IIC_API.BusType.Primary;
                }
                else if (IICSmbusIICRdBtn.Checked == true)
                {
                    Parm_IICW.IICType = (uint)IIC_API.BusType.SmbusIIC;
                }
                else
                {
                    MessageBox.Show("IIC not support all type!");
                    return;
                }

                Parm_IICW.SlaveAddress = SlaveAddr;
                Parm_IICW.WriteLen = WriteNum;
                byte[] ResultIIC = new byte[WriteNum];

                HexStringToByteArray(IICInputTextBox.Text, ref ResultIIC);

                fixed (byte* pResultIIC = ResultIIC)
                {
                    Parm_IICW.WriteBuf = pResultIIC;
                    LastErrCode = IIC_API.IIC_Write(ref Parm_IICW);
                }

                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("IMC_IIC_READ fail!");
                }
            }
        }

        private void IICWRCombineBtn_Click(object sender, EventArgs e)
        {
            if ((IICReadNumTextBox.Text == "") || (IICWriteNumTextBox.Text == "") || (IICSlaveAddressTextBox.Text == ""))
            {
                MessageBox.Show("Invalid Value !!!");
                return;
            }

            if ((Convert.ToInt16(IICSlaveAddressTextBox.Text, 16) < 0) || (Convert.ToInt16(IICReadNumTextBox.Text) < 0) || (Convert.ToInt16(IICWriteNumTextBox.Text) < 0))
            {
                MessageBox.Show("Invalid Value !!!");
                return;
            }

            byte SlaveAddr = Convert.ToByte(IICSlaveAddressTextBox.Text, 16);
            byte ReadNum = Convert.ToByte(IICReadNumTextBox.Text, 16);
            UInt32 WriteNum = Convert.ToUInt32(IICWriteNumTextBox.Text);
            UInt16 LastErrCode;

            IIC_API.IMC_IIC_WRITE_READ_COMBINE Parm_IICRW = new IIC_API.IMC_IIC_WRITE_READ_COMBINE();

            unsafe
            {
                if (IICPrimaryRdBtn.Checked == true)
                {
                    Parm_IICRW.IICType = (uint)IIC_API.BusType.Primary;
                }
                else if (IICSmbusIICRdBtn.Checked == true)
                {
                    Parm_IICRW.IICType = (uint)IIC_API.BusType.SmbusIIC;
                }
                else
                {
                    MessageBox.Show("IIC not support all type!");
                    return;
                }

                Parm_IICRW.SlaveAddress = SlaveAddr;
                Parm_IICRW.ReadLen = ReadNum;
                Parm_IICRW.WriteLen = WriteNum;

                byte[] ResultIICR = new byte[ReadNum];
                byte[] ResultIICW = new byte[WriteNum];

                HexStringToByteArray(IICInputTextBox.Text, ref ResultIICW);

                fixed (byte* pResultIICR = ResultIICR)
                fixed (byte* pResultIICW = ResultIICW)
                {

                    Parm_IICRW.WriteBuf = pResultIICW;
                    Parm_IICRW.ReadBuf = pResultIICR;

                    LastErrCode = IIC_API.IIC_WriteReadCombine(ref Parm_IICRW);
                }

                if (LastErrCode != IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("IMC_IIC_WriteReadCombine fail!", LastErrCode.ToString());
                    return;
                }
                else
                {

                    IICResultTextBox.Text = "";

                    string tempString = "";

                    for (int i = 0; i < ReadNum; i++)
                    {
                        tempString += Convert.ToString(ResultIICR[i], 16) + " ";
                    }

                    IICResultTextBox.Text = tempString;
                }
            }
        }
    }
}
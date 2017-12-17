using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace TREK_V3_Sample_Code_EEPROM
{
    public partial class EEPROM : Form
    {
        public UInt16 LastErrCode;
        public uint ROMSize;

        class IMCAPIErrCode
        {
            // Common error code
            public static UInt16 IMC_ERR_NO_ERROR = 0xC000;
            public static UInt16 IMC_ERR_UNSUPPORT = 0xC003;
            public static UInt16 IMC_ERR_TIME_OUT = 0xC008;
        }

        public EEPROM()
        {
            InitializeComponent();
        }

        #region EEPROM API DLL export
        class EEPROM_API
        {
            public const string DLLName = @"SUSI_IMC_SMBUS.dll";
            public const int IMC_LIB_VERSION_SIZE = 17;
            public const int PAGE_SIZE = 16;
            // The export functions.
            [DllImport(DLLName, EntryPoint = "SUSI_IMC_EEPROM_Initialize")]
            public static extern UInt16 Initialize();

            [DllImport(DLLName, EntryPoint = "SUSI_IMC_EEPROM_Deinitialize")]
            public static extern UInt16 Deinitialize();

            [DllImport(DLLName, EntryPoint = "SUSI_IMC_EEPROM_GetLibVersion")]
            public static extern UInt16 GetLibVersion(byte[] pVersion);

            [DllImport(DLLName, EntryPoint = "SUSI_IMC_EEPROM_GetEEPROMSize")]
            public static extern UInt16 GetEEPROMSize(out UInt32 size);

            [DllImport(DLLName, EntryPoint = "SUSI_IMC_EEPROM_ReadByte")]
            public static extern UInt16 ReadByte(byte address, out byte data);

            [DllImport(DLLName, EntryPoint = "SUSI_IMC_EEPROM_WriteByte")]
            public static extern UInt16 WriteByte(byte address, byte data);

            [DllImport(DLLName, EntryPoint = "SUSI_IMC_EEPROM_ReadMultiByte")]
            public static extern UInt16 ReadMultiByte(byte address, byte size, byte[] data, out byte isReadWrite);

            [DllImport(DLLName, EntryPoint = "SUSI_IMC_EEPROM_WriteMultiByte")]
            public static extern UInt16 WriteMultiByte(byte address, byte size, byte[] data, out byte isReadWrite);
        }
        #endregion

        #region Convenient format changer
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

        protected static string ConvertByte2HexString(byte[] byData, int nSize)
        {
            string strData = string.Empty;

            for (int i = 0; i < nSize; i++)
                strData += byData[i].ToString("X2");
            
            return strData;
        }

        protected static byte[] String2ByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        #endregion

        private void EEPROM_Load(object sender, EventArgs e)
        {
            byte[] byLibVersion = new byte[EEPROM_API.IMC_LIB_VERSION_SIZE];
            LastErrCode = EEPROM_API.GetLibVersion(byLibVersion);
            if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get library version " + LastErrCode.ToString("X4") );
                return;
            }

            int nRealSize;
            textBoxLibVersion.Text = ConvertByte2String(byLibVersion, byLibVersion.Length, out nRealSize);

            LastErrCode = EEPROM_API.GetEEPROMSize(out ROMSize);
            if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to get EERPOM size version " + LastErrCode.ToString("X4"));
                return;
            }
            textBoxEEPROMSize.Text = ROMSize.ToString();
            
            LastErrCode = EEPROM_API.Initialize();
            if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to Initialize the EEPROM library" + LastErrCode.ToString("X4"));
                return;
            }
        }

        private void EEPROM_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastErrCode = EEPROM_API.Deinitialize();
            if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
            {
                MessageBox.Show("Fails to Deinitialize the EEPROM library" + LastErrCode.ToString("X4"));
                return;
            }
        }

        private void buttonByteApply_Click(object sender, EventArgs e)
        {
            byte byAddr;

            try
            {
                if (textBoxByteAddress.Text.Length <= 0 || textBoxByteAddress.Text.Length > 2)
                    throw new FormatException();
            
                byAddr = Convert.ToByte(textBoxByteAddress.Text, 16);
            }
            catch
            {
                MessageBox.Show("Address format incorrect. Hex?", "Warning");
                return;
            }
            
            if (radioButtonReadByte.Checked == true)
            {
                byte byData;
                LastErrCode = EEPROM_API.ReadByte(byAddr, out byData);
                if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to ReadByte EERPOM " + LastErrCode.ToString("X4"));
                    return;
                }
                textBoxByteData.Text = byData.ToString("X2");
            }
            else
            {
                byte byData;

                try
                {
                    if (textBoxByteData.Text.Length <= 0 || textBoxByteData.Text.Length > 2)
                        throw new FormatException(); 
                    byData = Convert.ToByte(textBoxByteData.Text, 16);
                }
                catch
                {
                    MessageBox.Show("Format incorrect. Hex?", "Warning");
                    return;
                }

                LastErrCode = EEPROM_API.WriteByte(byAddr, byData);
                if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to WriteByte EERPOM " + LastErrCode.ToString("X4"));
                    return;
                }
            }
        }

        private void buttonMultiApply_Click(object sender, EventArgs e)
        {
            byte byAddr, bySize;

            try
            {
                if (textBoxMultiAddress.Text.Length <= 0 || textBoxMultiAddress.Text.Length > 2 ||
                    textBoxMultiSize.Text.Length <= 0 || textBoxMultiSize.Text.Length > 2)
                    throw new FormatException();

                byAddr = Convert.ToByte(textBoxMultiAddress.Text, 16);
                bySize = Convert.ToByte(textBoxMultiSize.Text, 16);
            }
            catch
            {
                MessageBox.Show("Format incorrect. Hex?", "Warning");
                return;
            }

            if (bySize < 1 || bySize > EEPROM_API.PAGE_SIZE)
            {
                MessageBox.Show("Incorrect Input. The range of the input should be 1 to " 
                    + EEPROM_API.PAGE_SIZE.ToString(), "Warning");
                return;
            }

            byte isReadWrite = 0;
            byte[] byDataArray = new byte[bySize];
            if (radioButtonReadMulti.Checked == true)
            {
                LastErrCode = EEPROM_API.ReadMultiByte(byAddr, bySize, byDataArray, out isReadWrite);     
                if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to ReadMultiByte EERPOM " + LastErrCode.ToString("X4"));
                    return;
                }

                textBoxMultiData.Text = ConvertByte2HexString(byDataArray, isReadWrite);
            }
            else
            {
                if (textBoxMultiData.Text.Length != bySize*2)
                {
                    MessageBox.Show("Incorrect Input. The data not match the size", "Warning");
                    return;
                }

                byDataArray = String2ByteArray(textBoxMultiData.Text);
                LastErrCode = EEPROM_API.WriteMultiByte(byAddr, bySize, byDataArray, out isReadWrite);
                if (LastErrCode != IMCAPIErrCode.IMC_ERR_NO_ERROR)
                {
                    MessageBox.Show("Fails to WriteMultiByte EERPOM " + LastErrCode.ToString("X4"));
                    return;
                }
            }
            textBoxMultiNumReadWrite.Text = isReadWrite.ToString("X2");
        }
    }
}

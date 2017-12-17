using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IMCDemo
{
    public partial class IMCBaseForm : Form
    {
 // Field
        // The last error code.
        protected UInt16 iLastErrCode;
/*
// The time of waiting for the worker thread to be terminated. In millisecond
        protected static int nWaitForWorkerThreadTerminateTime = 2500;
*/
// The parent window handle
        IntPtr hParentWnd;

// The flag of checking if the DLL exists or not.
        protected bool bDllExist;

// The flag of checking if the error debugger is enabled
        protected bool bErrorDebugEnabled;

// The flag of showing scrolls or not
        protected bool bNeedHScroll;
        protected bool bNeedVScroll;

// The messages
        public const uint WM_CLOSE = 0x0010;
        public const int WM_QUERYENDSESSION = 0x0011;
        public const int WM_ENDSESSION = 0x0016;
        public const uint WM_APP = 0x8000;
// The message which the window is closed
        public const uint WM_IMC_FORM_CLOSED = WM_APP + 1000;

        // The dialog of showing the system is busy now...
        public IMCWaitForm FormWait;

 // The property
        public UInt16 LastErrCode
        {
            set
            {
                iLastErrCode = value;
            }
            get
            {
                return iLastErrCode;
            }
        }

// The constructor
        public IMCBaseForm()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            LastErrCode = IMCAPIErrCode.IMC_ERR_NO_ERROR;
            hParentWnd = IntPtr.Zero;
            bDllExist = true;
            bNeedHScroll = false;
            bNeedVScroll = false;
            FormWait = null;
        }

// member functions

        // Show warning message.
        protected void ShowWanringMessage(string strErrDesc, UInt16 iErrorCode)
        {
            IMCErrorForm dlg = new IMCErrorForm();
            dlg.ErrCode = String.Format("0x{0:X8}", iErrorCode);
            dlg.ErrDesc = strErrDesc;
            dlg.ShowDialog();
 //           string strWarning = String.Format("{0}, ErrorCode : {1:X8}", strErrDesc, iErrorCode);
//            MessageBox.Show(strWarning, "Warning");
        }

        // Convert Byte data into string
        protected static string ConvertByte2String(byte[] byData, int nSize, out int nRealSize)
        {
            string strData = string.Empty;
            StringBuilder strBuilderData = new StringBuilder();
            nRealSize = 0;
            if (nSize != 0)
            {
//                char[] chData = new char[nSize];
                for (int i = 0; i < nSize; i++)
                {
                    char chData = (char)byData[i];
                    if (chData == 0)
                        break;
                    strBuilderData.Append(chData);
                    nRealSize++;
                }
                strData = strBuilderData.ToString();// new String(chData);
            }
            return strData;
        }

        protected static unsafe string ConvertByte2String(byte* pData, int nSize, out int nRealSize)
        {
            String strConvert = String.Empty;
            nRealSize = 0;

            if(nSize == 0)
                return strConvert;
            byte[] byDataTmp = new byte[nSize];
            unsafe
            {
                fixed(byte* pDataTmp = byDataTmp)
                {
                    IMCWin32API.CopyMemory(pDataTmp, pData, (uint)nSize);
                    strConvert = ConvertByte2String(byDataTmp, nSize, out nRealSize);
                }
            }
            return strConvert;
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
            unsafe
            {
                fixed (byte* pData = byData)
                {
                    strFormatData = String.Empty;
                    bool bFirst = true;
                    for (int i = 0; i < nSize ; i++)
                    {
                        if (!bFirst)
                            strFormatData += '.';
                        strFormatData += String.Format("{0}", *(pData + i));
                        if (bFirst)
                            bFirst = false;
                    }
                }
            }
            return true;
        }

// Set parent handle
        public void SetParent(IntPtr hParent)
        {
            hParentWnd = hParent;
        }

// Notify its parent that the form is closed
        public bool NotifyParentFormClosed()
        {
            if(hParentWnd == IntPtr.Zero)
                return false;
            IMCWin32API.PostMessage(hParentWnd, WM_IMC_FORM_CLOSED, IntPtr.Zero, IntPtr.Zero);
            return true;
        }

// Notify user that the library initialization fails
        protected void NotifyLibInitFail(string strOldCaption)
        {
            string strNewCaption = Text + " -(Initialization fails)";
            Text = strNewCaption;
            if (FormWait != null)
                FormWait.Hide();
        }

        public bool ChkShowScrollbar(object sender)
        {
            Panel PanelInner = (Panel)sender;
            int nPanelInnerWndX;
            int nPanelInnerWndY;
            if (!IMCCmnFunc.GetWindowSize(PanelInner.Handle, out nPanelInnerWndX, out nPanelInnerWndY))
                return false;

            // The size of the snapshot buttons
            int nSnapshotPanelWndX;
            int nSnapshotPanelWndY;
            if (!IMCCmnFunc.GetWindowSize(PanelShowScroll.Handle, out nSnapshotPanelWndX, out nSnapshotPanelWndY))
                return false;

            int nPosX = nPanelInnerWndX - nSnapshotPanelWndX;
            int nPosY = nPanelInnerWndY - nSnapshotPanelWndY;
//            PanelShowScroll.Visible = true;
            PanelShowScroll.Location = new Point(nPosX + (bNeedHScroll ? 10 : 0), nPosY + (bNeedVScroll ? 10 : 0));
            PanelInner.Controls.Add(PanelShowScroll);

            return true;
        }

        // Check the return value : SUCCESS/FAILURE
        protected bool SUCCESS(UInt16 nLastErrCode)
        {
            LastErrCode = nLastErrCode;
            if (LastErrCode == IMCAPIErrCode.IMC_ERR_NO_ERROR || LastErrCode == IMCAPIErrCode.IMC_ERR_UNSUPPORT)
                return true;
            return false;
        }

        protected bool FAILURE(UInt16 nLastErrCode)
        {
            return (!SUCCESS(nLastErrCode));
        }

// events
        private void IMCBaseForm_Load(object sender, EventArgs e)
        {
            IMCCmnFunc.SetWindowPosAndSize(Handle, out bNeedHScroll, out bNeedVScroll);
            bErrorDebugEnabled = true;
        }

        private void IMCBaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
// Notify its parent
            NotifyParentFormClosed();
        }
    }
}

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
    public partial class IMCErrorForm : IMCBaseForm
    {
// Field
// The error code
        string strErrCode;
// The error description
        string strErrDesc;

// The property
        public string ErrCode
        {
            set
            {
                strErrCode = value;
                StaticErrCodeValue.Text = strErrCode;
            }
            get
            {
                return strErrCode;
            }
        }

        public string ErrDesc
        {
            set
            {
                strErrDesc = value;
                EditErrDescValue.Text = strErrDesc;
            }
            get
            {
                return strErrDesc;
            }
        }

// The constructor;
        public IMCErrorForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            //            ControlBox = false;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void IMCErrorForm_Load(object sender, EventArgs e)
        {
            ChkShowScrollbar(PanelInner);

            if (!bErrorDebugEnabled)
                BtnScreenSnapshot.Enabled = false;

            bool bNeedHScroll;
            bool bNeedVScroll;
            IMCCmnFunc.SetWindowPosAndSize(Handle, out bNeedHScroll, out bNeedVScroll);
            IMCCmnFunc.SetWindowZOrder(Handle, IMCWin32API.HWND_TOPMOST);
        }

        private void BtnScreenSnapshot_Click(object sender, EventArgs e)
        {
//  TODO:
#if false
            IMCDebuggerHandler.DumpSnapshot(IMCDemo.DEV_TYPE.DEV_UNKNOWN);
            IMCCmnFunc.PlayCameraSound();
#endif
        }

        private void snapshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
//  TODO:
#if false
            IMCDebuggerHandler.DumpSnapshot(IMCDemo.DEV_TYPE.DEV_UNKNOWN);
            IMCCmnFunc.PlayCameraSound();
#endif
        }
    }
}

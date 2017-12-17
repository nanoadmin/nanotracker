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
    public partial class IMCProgressForm : IMCBaseForm
    {
        bool bCancel;
        uint nValue;

        public bool Cancel
        {
            set
            {
                bCancel = value;
            }
            get
            {
                return bCancel;
            }
        }

        public uint Value
        {
            set
            {
                nValue = value;
                ProgressValue.Value = (Int32)nValue;
                StaticValue.Text = String.Format("{0}%", nValue);
            }
            get
            {
                return nValue;
            }
        }

        public IMCProgressForm()
        {
            InitializeComponent();
        }

        private void IMCProgressForm_Load(object sender, EventArgs e)
        {
            Cancel = false;
            Value = 0;

/*
            // Get window resolution
            int nResolutionX = IMCWin32API.GetSystemMetrics(IMCWin32API.SM_CXSCREEN);
            int nResolutionY = IMCWin32API.GetSystemMetrics(IMCWin32API.SM_CYSCREEN);
            // Get window size
            IMCWin32API.RECT rcWnd = new IMCWin32API.RECT();
            IMCWin32API.GetWindowRect(Handle, out rcWnd);
            // Get the start position
            int nStartX = (nResolutionX - (rcWnd.right - rcWnd.left)) >> 1;
            int nStartY = (nResolutionY - (rcWnd.bottom - rcWnd.top)) >> 1;
            // Set window position
            IMCWin32API.SetWindowPos(
                Handle,
                IntPtr.Zero,
                nStartX,
                nStartY + 250,
                0,
                0,
                IMCWin32API.SWP_NOSIZE | IMCWin32API.SWP_NOZORDER
                );
*/
        }
    }
}
